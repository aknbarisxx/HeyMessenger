using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace TestClientServerNiklas
{
    class Program
    {
        /// <summary>
        /// Der Socket wartet auf eine Verbindunsanfrage und akzeptiert jede IP-Adresse und benutzt den Port 3443 VERSUCH
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //IPEndPoint endpoint = new IPEndPoint(IPAddress.Any, 3443);
            //Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //socket.Bind(endpoint);
            //socket.Listen(0); // Länge der Warteschlange

            //socket.Accept();

            //Console.WriteLine("Hey!");
            //Console.ReadKey();

            //socket.Close();


        }
    }
}
