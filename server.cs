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
                Console.WriteLine("Connected...");
                Console.WriteLine("*********************************");
                NetworkStream ns = new NetworkStream(socketForClients);
                StreamWriter sw = new StreamWriter(ns);
                StreamReader sr = new StreamReader(ns);


                Console.Write("Server >> ");
                string s = Console.ReadLine();
                sw.WriteLine(s);
                sw.Flush();
                Console.WriteLine("Client >> " + sr.ReadLine());
                Console.WriteLine("*********************************");
                Console.WriteLine("\n Hit ENTER to close");
                Console.ReadLine();

                sw.Close();
                ns.Close();
            }

            socketForClients.Close();
        }
    }
}