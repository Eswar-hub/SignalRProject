using Microsoft.AspNetCore.SignalR.Client;
using System;

namespace SignalRConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var connection = new HubConnectionBuilder().WithUrl("http://localhost:5000/notification").Build();
            connection.StartAsync().Wait();
            connection.InvokeAsync("SendMessage", "eswar", "Hello World");
            connection.On("ReceiveMessage", (string message) =>
             {
                 Console.WriteLine( message);
             });
            Console.ReadLine();
        }
    }
}
