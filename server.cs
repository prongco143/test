using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ServerSide
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener server = new TcpListener(8888);
            server.Start();
            Console.WriteLine("Server Started and waiting for clients.");
            Socket socketForClients = server.AcceptSocket();

            if (socketForClients.Connected)
            {
                NetworkStream ns = new NetworkStream(socketForClients);
                StreamWriter sw = new StreamWriter(ns);
                Console.WriteLine("Server >> Welcome Client.");
                sw.WriteLine("Welcome Client");
                sw.Flush();

                StreamReader sr = new StreamReader(ns);
                Console.WriteLine("Client >> " + sr.ReadLine());
                Console.WriteLine("Press enter key to continue...");
                Console.ReadLine();
                sw.Close();
                ns.Close();
            }

            socketForClients.Close();
        }
    }
}
