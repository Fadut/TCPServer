using System;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            ClientWorker client = new ClientWorker();
            client.Start();

            Console.ReadLine();
        }
    }
}
