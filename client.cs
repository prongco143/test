using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;

namespace ClientSide
{
    public partial class Form1 : Form
    {
        TcpClient client = null;
        public Form1()
        {
            InitializeComponent();
            client = new TcpClient("127.0.0.1", 8888);
            NetworkStream ns = client.GetStream();
            StreamReader sr = new StreamReader(ns);

            serverMsg.Text = "Server >> " + sr.ReadLine();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (clientMsg.Text != "")
            {
                NetworkStream ns = client.GetStream();
                StreamWriter sw = new StreamWriter(ns);
                sw.WriteLine(clientMsg.Text);

                sw.Flush();

                sw.Close();
                ns.Close();
            }
            clientMsg.Text = "";
        }
    }
}