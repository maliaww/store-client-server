using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreClient
{
    public interface StoreDataInterface
    {
        string Host { get; set; }
        int Port { get; set; }
        int AccountNumber { get; set; }
        bool IsDisconnected { get; }
        string Username { get; set; }
        Task StartAsync();
        Task DisconnectAsync();
        Task ConnectAsync();
        Task<IList<Product>> GetProductsAsync();
        Task<IList<Order>> GetOrdersAsync();
        Task PurchaseAsync(string product);
    }
}
