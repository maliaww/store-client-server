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
    public class Item
    {
        public string ProductName { get; }
        public int Stock { get; }

        public Item(string productName, int stock)
        {
            ProductName = productName;
            Stock = stock;
        }
    }
}
