using System;

namespace TCPServer
{
    class Program
    {
        static void Main(string[] args)
        {
            ServerWorker server = new ServerWorker();
            server.Start();

            Console.ReadLine();

        }
    }
}
