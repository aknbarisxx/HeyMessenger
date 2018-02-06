using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;


namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            IPAddress ip = Dns.GetHostEntry("localhost").AddressList[0];
            TcpListener server = new TcpListener(ip, 8888);
            TcpClient client = default(TcpClient);

            try
            {
                server.Start();
                Console.WriteLine("Server gestartet...");
                Console.Read();
            }
            catch(Exception ex)
            {
                //Console.WriteLine(ex.ToString());
                //Console.Read();
                throw;
            }
            while(true)
            {
                client = server.AcceptTcpClient();

                byte[] receivedBuffer = new byte[100];
                NetworkStream stream = client.GetStream();

                stream.Read(receivedBuffer, 0, receivedBuffer.Length);

                string msg = Encoding.ASCII.GetString(receivedBuffer, 0, receivedBuffer.Length);  //Konvertierung Bytes zu String

                Console.WriteLine(msg + receivedBuffer.Length);
                Console.Read();
                
            }
        }
    }
}
