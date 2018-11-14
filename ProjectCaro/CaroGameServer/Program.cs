using System;

namespace CaroGameServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Server start listening on port 12345...");
            Server.Listener();
           
        }
    }
}
