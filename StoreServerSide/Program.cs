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
    internal class Program
    {
        private static void Main(string[] args)
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            Thread serverThread = new Thread(() => new StoreServer(cts.Token).Start());
            serverThread.Start();
            Console.WriteLine("Server is running");
            Console.WriteLine("Hostname: localhost");
            Console.WriteLine("Port: 8080");
            Console.WriteLine("Press Q to QUIT");
      
            while (serverThread.IsAlive && (!Console.KeyAvailable || Console.ReadKey(true).Key != ConsoleKey.Q)) { }

            cts.Cancel();
            Console.WriteLine("Server is shutting down.");
            Console.ReadKey();
        }
    }
}