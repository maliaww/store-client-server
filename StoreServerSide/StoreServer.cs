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
    public class StoreServer
    {
        private readonly Random _rnd = new Random();
        private readonly CancellationToken _cancellationToken;
        private IList<Item> _items = new List<Item>();
        private IList<Customer> _customers = new List<Customer>();
        public int ServerPort { get; set; } = 8080;
        public IPAddress ServerIP { get; set; } = IPAddress.Any;


        public StoreServer(CancellationToken cancellationToken)
        {
            _cancellationToken = cancellationToken;
        }

        public void Start()
        {
            try
            {
                InitializeAccounts();
                InitializeItems();
                TcpListener listener = new TcpListener(ServerIP, ServerPort);
                listener.Start();

                while (!_cancellationToken.IsCancellationRequested)
                {
                    if (listener.Pending())
                    {
                        new Thread(() => new StoreClientHandler(_items, _customers, listener.AcceptTcpClient(), _cancellationToken).Handle()).Start();
                    }
                    else
                    {
                        Thread.Sleep(100);
                    }
                }

                listener.Stop();
            }
            catch (SocketException)
            {
                // Handle socket exception
            }
        }

        private void InitializeItems()
        {
            List<string> itemNames = new List<string>
    {
        "Watermelon",
        "Orange",
        "Banana",
        "Headset",
        "Keyboard",
        "T-Shirt"
    };

            _items = itemNames.Select(name => new Item(name, _rnd.Next(1, 4))).ToList();
        }

        private void InitializeAccounts()
        {
            _customers.Add(new Customer(1111, "Abdumalik"));
            _customers.Add(new Customer(2222, "Sultan"));
            _customers.Add(new Customer(3333, "Sushen"));
            _customers.Add(new Customer(4444, "Ali"));
            _customers.Add(new Customer(5555, "Alise"));
        }
    }
}
