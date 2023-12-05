using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections.Concurrent;

namespace StoreServer
{
    public class StoreClientHandler
    {
        private readonly TcpClient _tcpClient;
        private readonly CancellationToken _cancellationToken;
        private IList<Item> _items;
        private IList<Customer> _customers;
        private StreamReader _reader;
        private StreamWriter _writer;
        private string _customerName = "";
        private readonly object _lock = new object();

        private static BlockingCollection<Order> ActivePurchases { get; set; } = new BlockingCollection<Order>();

        public StoreClientHandler(
          IList<Item> items,
          IList<Customer> customers,
          TcpClient tcpClient,
          CancellationToken cancellationToken)
        {
            _items = items;
            _tcpClient = tcpClient;
            _customers = customers;
            _cancellationToken = cancellationToken;
        }

        public void Handle()
        {
            using (_tcpClient)
            {
                try
                {
                    NetworkStream stream = _tcpClient.GetStream();
                    _reader = new StreamReader(stream);
                    _writer = new StreamWriter(stream);
                    _cancellationToken.Register(stream.Close);

                    while (!_cancellationToken.IsCancellationRequested)
                    {
                        string response = "";
                        string line = _reader.ReadLine();
                        Console.WriteLine(line);

                        if (line == null || line == "DISCONNECT")
                            break;

                        switch (line)
                        {
                            case var s when s.StartsWith("CONNECT"):
                                int account = int.Parse(s.Split(':')[1]);
                                Customer customer = _customers.FirstOrDefault(c => c.AccountId == account);
                                if (customer != null)
                                {
                                    _customerName = customer.Name;
                                    response = $"CONNECTED:{customer.Name}";
                                }
                                else
                                {
                                    response = "CONNECT_ERROR";
                                }
                                break;

                            case "GET_PRODUCTS":
                                response = $"PRODUCTS:{string.Join("|", _items.Select(i => $"{i.ProductName},{i.Stock}"))}";
                                break;

                            case "GET_ORDERS":
                                response = $"ORDERS:{string.Join("|", ActivePurchases.Select(p => $"{p.ProductName},{p.Quantity},{p.CustomerName}"))}";
                                break;

                            case var s when s.StartsWith("PURCHASE"):
                                string product = s.Split(':')[1];
                                Item selectedItem = _items.FirstOrDefault(i => i.ProductName == product);
                                if (selectedItem != null)
                                {
                                    if (selectedItem.Stock > ActivePurchases.Count(p => p.ProductName == selectedItem.ProductName))
                                    {
                                        ActivePurchases.Add(new Order(selectedItem.ProductName, 1, _customerName));
                                        response = "DONE";
                                    }
                                    else
                                    {
                                        response = "NOT_AVAILABLE";
                                    }
                                }
                                else
                                {
                                    response = "NOT_VALID";
                                }
                                break;
                        }

                        if (!string.IsNullOrEmpty(response))
                            WriteToConsoleAndStream(response);
                    }
                }
                catch (IOException)
                {
                    Console.WriteLine("***Network Error***");
                }
                catch (ObjectDisposedException)
                {
                    Console.WriteLine("***Network Error***");
                }
                catch (OutOfMemoryException)
                {
                }
            }
        }

        private void WriteToConsoleAndStream(string message)
        {
            lock (_lock)
            {
                _writer.WriteLine(message);
                _writer.Flush();
                Console.WriteLine(message);
            }
        }
    }
}
