using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreClient
{
    public class Order
    {
        public string ProductName { get; }
        public int Quantity { get; }
        public string Username { get; }

        public Order(string productName, int quantity, string username)
        {
            ProductName = productName;
            Quantity = quantity;
            Username = username;
        }

        public override string ToString() => $"{ProductName}, {Quantity}, {Username}";
    }
}
