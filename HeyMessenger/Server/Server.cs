using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections;

namespace Server
{
    class Server
    {
        /// <summary>
        /// Server-Part
        /// </summary>
        /// <param name="args"></param>
        public static Hashtable clientsList = new Hashtable();
        static void Main(string[] args)
        {
            IPAddress ip = Dns.GetHostEntry("localhost").AddressList[0];
            TcpListener server = new TcpListener(IPAddress.Loopback, 4334);
            TcpClient client = default(TcpClient);

            try //Versuch um Server zu starten
            {
                //Thread.Sleep(30000);
                server.Start(); //Server wird gestartet
                Console.WriteLine("Server gestartet...");
                //Console.Read();

            }
            catch (Exception ex) //Fehlerausgabe
            {

                Console.WriteLine(ex.ToString());
                // Console.Read();
            }


            while (true)
            {
                client = server.AcceptTcpClient();   //Akzeptiere TCP Client

                byte[] receivedBuffer = new byte[100];
                NetworkStream stream = client.GetStream();

                stream.Read(receivedBuffer, 0, receivedBuffer.Length);

                StringBuilder msg = new StringBuilder();

                foreach (byte b in receivedBuffer)
                {
                    if (b.Equals(59))
                    {
                        break;
                    }
                    else
                        msg.Append(Convert.ToChar(b).ToString());
                }
                Console.WriteLine(msg.ToString() + receivedBuffer.Length);

            }
        }

            public static void broadcast(string msg, string uName, bool flag) //Broadcast Funktion, müsste klappen wenn das Client es auch unterstützt
        {
            
            foreach (DictionaryEntry Item in clientsList)
            {
                
                TcpClient broadcastSocket; //TCPClient für Broadcast
                broadcastSocket = (TcpClient)Item.Value;
                NetworkStream broadcastStream = broadcastSocket.GetStream(); //für Stream
                Byte[] broadcastBytes = null;
                
                if (flag == true) //Übertragung der Bytes
                {
                    broadcastBytes = Encoding.ASCII.GetBytes(uName + " says : " + msg);
                }
                else
                {
                    broadcastBytes = Encoding.ASCII.GetBytes(msg);
                }
                
                broadcastStream.Write(broadcastBytes, 0, broadcastBytes.Length);
                broadcastStream.Flush();
            }
            
            //Beenden der Broadcast Funktion
        
        }
    }
}
