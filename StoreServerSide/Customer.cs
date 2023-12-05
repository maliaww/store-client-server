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
    public class Customer
    {
        public int AccountId { get; set; }
        public string Name { get; set; }

        public Customer(int accountId, string name)
        {
            AccountId = accountId;
            Name = name;
        }
    }
}
