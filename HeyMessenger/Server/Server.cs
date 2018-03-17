using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;


namespace Server
{
    class Server
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
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
            catch(Exception ex) //Fehlerausgabe
            {
                
                Console.WriteLine(ex.ToString());
               // Console.Read();
            }
            
            
            while(true)
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
                Console.WriteLine(msg.ToString()+ receivedBuffer.Length);
                
            }
            
        }
    }
}
