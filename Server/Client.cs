using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Sockets;
using System.Text;

namespace Server
{
    public delegate string SocketMessageHandler(object sender, EventArgs e);
    class Client
    {
        private BackgroundWorker socketWorker = new BackgroundWorker();
        private Socket clientSocket;
        private static List<Socket> clients = new List<Socket>();
        public event SocketMessageHandler SocketMessage;

        public Client(Socket socket)
        {
            socketWorker.DoWork += SocketWorker_DoWork;
            socketWorker.ProgressChanged += SocketWorker_ProgressChanged;
            socketWorker.RunWorkerCompleted += SocketWorker_RunWorkerCompleted;
            clientSocket = socket;
            clients.Add(socket);
        }


        private void SocketWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void SocketWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void SocketWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            byte[] bytes = new byte[1024];
            int byteCount = clientSocket.Receive(bytes);
            

        }

        public List<Socket> ClientList { get; }
        public void Listen()
        {
            socketWorker.RunWorkerAsync();
        }
    }
}
