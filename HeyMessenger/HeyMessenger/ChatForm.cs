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
        string serverIP = "127.0.0.1";  // TO DO: Konfigurationsdatei
        int port = 4334;
        string benutzer;
        bool connection;

        public formChat()
        {
            InitializeComponent();
            //TcpClient client = new TcpClient(); //  not done
            //NetworkStream stream = client.GetStream(); //  not done
            // Connect(client); // Verbindungsaufbau vor dem ChatForm start
        }

        /// <summary>
        /// Send the data on the stream
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSend_Click(object sender, EventArgs e)
        {
            labelChat.Text += benutzer + ": " + textBoxMessage.Text + "\n";


            //IPAddress ip = Dns.GetHostEntry("localhost").AddressList[0];

            string privateMsg = "192.168.2.126";    // eigene IP-Adresse unklar
            byte[] pBytes = Encoding.ASCII.GetBytes(privateMsg);


            //Write Message
            TcpClient client = new TcpClient(); //  not done

            Connect(client); // Verbindungsaufbau

            int byteCount = Encoding.ASCII.GetByteCount(textBoxMessage.Text);
            byte[] sendData = new byte[byteCount];

            sendData = Encoding.ASCII.GetBytes(textBoxMessage.Text);


            NetworkStream stream = client.GetStream(); //  not done

            stream.Write(pBytes, 0, pBytes.Length); // eigene IP-Adresse wird gesendet

            // TO DO: be able to choose a client in the same network, send again if error accrued
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

            // tcpListener listener = new TcpListener(ip, 4334);
            // listener.Start();

            // TcpClient foreignClient = TcpListener.AcceptTcpClient();

            // foreignClient.Close();
            // listener.Stop(); 

            //} while (true);
        }

        /// <summary>
        /// trys to connect with the server (error message if not connected properly) and trys it after a period of time again
        /// </summary>
        /// <param name="client"></param>
        private void Connect(TcpClient client)
        {
            do
            {
                try
                {
                   // Thread.Sleep(30000);          
                    client.Connect(IPAddress.Loopback, port);
                    MessageBox.Show("Verbindungsaufbau erfolgreich");
                }

                catch (Exception ex)
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
        /// the name of the user will be saved in benutzer
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
        /// shows the incoming message on the label and shows a messagebox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                TcpClient client = new TcpClient();             //  not done
                NetworkStream stream = client.GetStream();      //  not done
                MessageBox.Show("Eingehende Nachricht");

                int length = stream.ReadByte();
                byte[] readData = new byte[length];
                stream.Read(readData, 0, length);

                labelChat.Text += stream.ReadByte();    // not sure if it will work
            }
            catch (Exception)
            {}

        }
    }
}
