using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Text.Json.Serialization;
using ModelLib.Model;
using Newtonsoft.Json;

namespace Client
{
    public class ClientWorker
    {

        public void Start()
        {
            TcpClient socket = new TcpClient("localhost", 4646);

            StreamReader sr = new StreamReader(socket.GetStream());
            StreamWriter sw = new StreamWriter(socket.GetStream());

            sw.AutoFlush = true;

            socket.Close();
        }
    }
}
