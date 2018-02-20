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
    class Program
    {
        static void Main(string[] args)
        {
            IPAddress ip = Dns.GetHostEntry("localhost").AddressList[0];
            TcpListener server = new TcpListener(ip, 4334);
            TcpClient client = default(TcpClient);

            try
            {
                //Thread.Sleep(30000);
                server.Start();
                Console.WriteLine("Server gestartet...");
                Console.Read();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.Read();
            }
            while(true)
            {
                client = server.AcceptTcpClient();

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
