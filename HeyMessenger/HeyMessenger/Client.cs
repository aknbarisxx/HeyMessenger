﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace HeyMessenger //Versuchsklasse
{
    public class Client
    {

        public IPEndPoint EndPoint { get; private set; }

        public Guid ID { get; set; }

        public Thread ReceiveThread { get; private set; }

        public TcpClient ChatClient { get; private set; }

        public StreamReader Reader { get; private set; }

        public StreamWriter Writer { get; private set; }

        public string Name { get; private set; }

        public Client(TcpClient client, formChat chat)
        {
            EndPoint = EndPoint;
            ChatClient = client;
            this.ChatClient = ChatClient;
        }

        public void Connect()
        {
            ChatClient.Connect(EndPoint);
            Reader = new StreamReader(ChatClient.GetStream());
            Writer = new StreamWriter(ChatClient.GetStream());
            ReceiveThread = new Thread(Receive);
            ReceiveThread.IsBackground = true;
            ReceiveThread.Start();
        }

        /// <summary>
        /// Ein Socket wird erstellt und versucht eine Verbindung herzustelllen VERSUCH
        /// </summary>
        public void ConnectSocket()
        {
            IPAddress address = IPAddress.Parse("127.0.0.1");
            IPEndPoint EndPointSocket = new IPEndPoint(address, 3443);

            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(EndPointSocket);
        }
        public void Close()
        {
            ReceiveThread.Abort();
            Writer.Close();
            Reader.Close();

        }

        public void Write()
        {

        }

        private void Receive()
        {

        }


    }
}
