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

        string serverIP = "127.0.0.1";
        int port = 4334;
        string benutzer;
        bool connection;

        public formChat()
        {
            InitializeComponent();
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {

            labelChat.Text += benutzer + ": " + textBoxMessage.Text + "\n";

            //Split
            string privateMsg = "Das ist eine Private Nachricht"; // 192.168.2.126
            privateMsg = "pm[!]192.168.2.126[!]" + privateMsg;
            byte[] pBytes = Encoding.ASCII.GetBytes(privateMsg);



            //string bMsg = "Das ist eine Broadcast Nachricht";
            //bMsg = "bc[!]" + bMsg;
            //byte[] bBytes = Encoding.ASCII.GetBytes(bMsg);

            //Write Message
            TcpClient client = new TcpClient();//serverIP, port);

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

            //Read Message
            int length = stream.ReadByte();
            byte[] readData = new byte[length];
            stream.Read(readData, 0, length);


            

            // Split Message
            //string sData = Encoding.ASCII.GetString(readData);
            //if (sData.Split(new string[] { "[;]" }, StringSplitOptions.None)[0].ToLower() == "pm")
            //{

            //}


            stream.Close();
            client.Close();

        }

        private void Connect(TcpClient client)
        {
            do
            {
                try
                {
                    Thread.Sleep(30000);
                    client.Connect(serverIP, port);
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
        {

        }

        private void buttonBenutzer_Click(object sender, EventArgs e)
        {
            benutzer = textBoxBenutzer.Text;
            textBoxBenutzer.Text = "";
        }
        
    }
}
