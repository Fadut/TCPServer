using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ModelLib.Model;
using Newtonsoft.Json;
using JsonConverter = System.Text.Json.Serialization.JsonConverter;

namespace TCPServer
{
    public class ServerWorker
    {

        private static readonly List<Bicycle> Bicycles = new List<Bicycle>()
        {
            new Bicycle("1", "Blue", 4230, 7),
            new Bicycle("2", "Silver", 2450, 5),
            new Bicycle("3", "Purple", 3100, 6),
            new Bicycle("4", "Black", 1950, 3),
        };

        public void Start()
        {
            TcpListener serverListener = new TcpListener(IPAddress.Loopback, 4646);
            serverListener.Start();
            Console.WriteLine("Server start...");

            while (true)
            {
                TcpClient socket = serverListener.AcceptTcpClient();

                Task.Run(() =>
                {
                    TcpClient tempSocket = socket;
                    DoClient(tempSocket);
                });
            }

        }

        public void DoClient(TcpClient socket)
        {
            StreamReader sr = new StreamReader(socket.GetStream());
            StreamWriter sw = new StreamWriter(socket.GetStream());

            sw.AutoFlush = true;

            
            string message = "1";

            while (true)
            {
                try
                {
                    string[] msgArray = message.Split(' ');
                    string parameter = message.Substring(message.IndexOf(' ') + 1);
                    string command = msgArray[0];
                    switch (command)
                    {
                        case "GetAll":
                            sw.WriteLine("Retrieving all bicycles");
                            sw.WriteLine(JsonConvert.SerializeObject(Bicycles));
                            break;

                        case "Get":
                            sw.WriteLine($"Retrieving bicycle with id: {parameter}");
                            sw.WriteLine(JsonConvert.SerializeObject(Bicycles.Find(bicycle => bicycle.Id == parameter)));
                            break;

                        case "Save":
                            sw.WriteLine("Saving bicycle");
                            try
                            {
                                var savedBicycle = JsonConvert.DeserializeObject<Bicycle>(parameter);
                                Bicycles.Add(savedBicycle);
                                break;
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e);
                                throw;
                            }
                    }

                    message = sr.ReadLine();
                    if (string.IsNullOrWhiteSpace(message)) break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    break;
                }
            }
        }
    }
}
