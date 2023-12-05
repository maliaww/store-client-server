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
    public class Order
    {
        public string ProductName { get; }
        public int Quantity { get; }
        public string CustomerName { get; }

        public Order(string productName, int quantity, string customerName)
        {
            ProductName = productName;
            Quantity = quantity;
            CustomerName = customerName;
        }
    }
    }
