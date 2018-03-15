using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace HeyMessenger
{
    public partial class formChat : Form
    {
      //  string serverIP = "127.0.0.1";
        int port = 4334;
        string benutzer;
        bool connection;
      //  string clientIP = "localhost";

        public formChat()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Send the data on the stream
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSend_Click(object sender, EventArgs e)
        {
            //if (benutzer == null)
            //{
            //    MessageBox.Show("Bitte einen Benutzer eingeben! Es wird ein Ersatznamen benutzt");
            //    benutzer = "John Doe";
            //}

            labelChat.Text += benutzer + ": " + textBoxMessage.Text + "\n";



            string privateMsg = "192.168.2.126";    // eigene IP-Adresse unklar
            byte[] pBytes = Encoding.ASCII.GetBytes(privateMsg);


            //Write Message
            TcpClient client = new TcpClient();

            Connect(client); // Verbindungsaufbau

            int byteCount = Encoding.ASCII.GetByteCount(textBoxMessage.Text);
            byte[] sendData = new byte[byteCount];

            sendData = Encoding.ASCII.GetBytes(textBoxMessage.Text);

            NetworkStream stream = client.GetStream();

            stream.Write(pBytes, 0, pBytes.Length); // eigene IP-Adresse wird gesendet

            stream.Write(sendData, 0, sendData.Length);
            stream.Flush();

            stream.Close();    
            client.Close();     
        }

        /// <summary>
        ///  Working on accepting another client/server connection
        /// </summary>
        /// <param name="listener"></param>
        private void AcceptConnection(TcpListener listener)
        {
            //do
            //{

            //    TcpListener ClientListener = new TcpListener(clientIP, 4334);
            //    ClientListener.Start();

            //    TcpClient foreignClient = ClientListener.AcceptTcpClient();

            //    foreignClient.Close();
            //    listener.Stop();

            //} while (true);
        }

        /// <summary>
        /// Read text file
        /// </summary>
        //private void Reader()
        //{
        //    try
        //    {
        //        using (StreamReader sr = new StreamReader("ServerIPAddress.txt")) ;
        //        {
        //            string line;

        //            while ((line = sr.Readline()) != null)
        //            {
        //                sr.Readline();
        //            }

        //        }
        //    }
        //    catch (Exception)
        //    {
        //        MessageBox.Show("Error with reading the text file");
        //    }

        //}



        /// <summary>
        /// Tries to connect with the server (error message if not connected properly) and tries it after a period of time again
        /// </summary>
        /// <param name="client"></param>
        private void Connect(TcpClient client)
        {
            do
            {
                try
                {
                    Thread.Sleep(30000);
                    client.Connect(IPAddress.Loopback, port);
                    MessageBox.Show("Verbindungsaufbau erfolgreich");
                }

                catch (Exception)
                {
                    MessageBox.Show("Verbindungsaufbau fehlgeschlagen");
                    connection = false;
                }

            }
            while (connection == false);
        }

        private void textBoxMessage_TextChanged(object sender, EventArgs e)
        {}

        /// <summary>
        /// The name of the user will be saved in benutzer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonBenutzer_Click(object sender, EventArgs e)
        {
            benutzer = textBoxUser.Text;
            textBoxUser.Text = "";
        }

        private void formChat_Load(object sender, EventArgs e)
        {}

        /// <summary>
        /// Shows the incoming message on the label
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                string benutzer2 = "Client";    // anderer Client

                TcpClient client = new TcpClient(); 
                NetworkStream stream = client.GetStream(); 

                int length = stream.ReadByte();
                byte[] readData = new byte[length];
                stream.Read(readData, 0, length);

                labelChat.Text += benutzer2 + ":" + stream.ReadByte();

            }
            catch (Exception)
            {}

        }
    }
}
