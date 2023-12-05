using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;

namespace StoreClient
{
    public class CustomerServerHandler : StoreDataInterface
    {
        private TcpClient _tcpClient;
        private StreamReader _reader;
        private StreamWriter _writer;

        public string Host { get; set; } = "localhost";
        public int Port { get; set; } = 8080;
        public bool IsDisconnected => _tcpClient == null;
        public int AccountNumber { get; set; }
        public string Username { get; set; }

        public async Task StartAsync()
        {
            try
            {
                _tcpClient = new TcpClient();
                _tcpClient.Connect(Host, Port);
                NetworkStream stream = _tcpClient.GetStream();
                _reader = new StreamReader(stream);
                _writer = new StreamWriter(stream);
                await ConnectAsync();
            }
            catch (SocketException ex)
            {
                _tcpClient = null;
                throw new InvalidOperationException("Server Unavailable", ex);
            }
        }

        private void Close()
        {
            _tcpClient?.Close();
            _tcpClient = null;
        }

        private async Task WriteToConsoleAndStreamAsync(string message)
        {
            await _writer.WriteLineAsync(message);
            await _writer.FlushAsync();
            Console.WriteLine(message);
        }

        public async Task DisconnectAsync()
        {
            if (IsDisconnected) return;

            try
            {
                await WriteToConsoleAndStreamAsync("DISCONNECT");
            }
            catch (IOException)
            {
            }
            finally
            {
                Close();
            }
        }

        public async Task ConnectAsync()
        {
            try
            {
                await WriteToConsoleAndStreamAsync($"CONNECT:{AccountNumber}");
                string line = await _reader.ReadLineAsync();

                switch (line)
                {
                    case "CONNECT_ERROR":
                        throw new InvalidOperationException("Account number invalid");

                    case var s when s.StartsWith("CONNECTED"):
                        int pos = line.IndexOf(':') + 1;
                        if (pos > 0)
                            Username = line.Substring(pos);
                        break;

                    default:
                        throw new InvalidOperationException("Unexpected response from server");
                }
            }
            catch (IOException ex)
            {
                throw new InvalidOperationException("Server Unavailable", ex);
            }
        }

        public async Task<IList<Product>> GetProductsAsync()
        {
            try
            {
                IList<Product> products = new List<Product>();
                await WriteToConsoleAndStreamAsync("GET_PRODUCTS");
                string line = await _reader.ReadLineAsync();
                if ("NOT_CONNECTED" == line)
                    throw new InvalidOperationException("Client not connected");

                if (line.StartsWith("PRODUCTS"))
                {
                    line = line.Substring(line.IndexOf(':') + 1);
                    string[] productEntries = line.Split('|');

                    foreach (string productEntry in productEntries)
                    {
                        string[] productInfo = productEntry.Split(',');
                        if (productInfo.Length == 2 && !string.IsNullOrEmpty(productInfo[0]) && int.TryParse(productInfo[1], out int quantity))
                        {
                            products.Add(new Product(productInfo[0], quantity));
                        }
                    }
                }
                return products;
            }
            catch (IOException ex)
            {
                Close();
                throw new InvalidOperationException("Server Unavailable", ex);
            }
        }

        public async Task<IList<Order>> GetOrdersAsync()
        {
            try
            {
                IList<Order> orders = new List<Order>();
                await WriteToConsoleAndStreamAsync("GET_ORDERS");
                string line = await _reader.ReadLineAsync();
                if ("NOT_CONNECTED" == line)
                    throw new InvalidOperationException("Client not connected");

                if (line.StartsWith("ORDERS"))
                {
                    line = line.Substring(line.IndexOf(':') + 1);
                    string[] orderEntries = line.Split('|');

                    foreach (string orderEntry in orderEntries)
                    {
                        string[] orderInfo = orderEntry.Split(',');
                        if (orderInfo.Length == 3 && !string.IsNullOrEmpty(orderInfo[0]) && int.TryParse(orderInfo[1], out int quantity) && !string.IsNullOrEmpty(orderInfo[2]))
                        {
                            orders.Add(new Order(orderInfo[0], quantity, orderInfo[2]));
                        }
                    }
                }
                return orders;
            }
            catch (IOException ex)
            {
                Close();
                throw new InvalidOperationException("Server Unavailable", ex);
            }
        }

        public async Task PurchaseAsync(string product)
        {
            if (IsDisconnected)
                throw new InvalidOperationException("Client Closed");

            try
            {
                await WriteToConsoleAndStreamAsync($"PURCHASE:{product}");
                string line = await _reader.ReadLineAsync();

                switch (line)
                {
                    case "NOT_CONNECTED":
                        throw new InvalidOperationException("Client not connected");

                    case "NOT_VALID":
                        throw new InvalidOperationException("The specified product is not valid");

                    case "NOT_AVAILABLE":
                        throw new InvalidOperationException("The product is not available");

                    case "DONE":
                        break;

                    default:
                        throw new InvalidOperationException("Unexpected server response");
                }
            }
            catch (IOException ex)
            {
                Close();
                throw new InvalidOperationException("Server Unavailable", ex);
            }
        }
    }
}
