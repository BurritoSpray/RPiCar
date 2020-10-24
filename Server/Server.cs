using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Data;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace RPiCar
{
    public delegate void StringEventHandler(object sender, StringEventArgs e);

    public class StringEventArgs : EventArgs
    {
        public string Text;
        public StringEventArgs(string text)
        {
            Text = text;
        }
    }
    class Server
    {
        Socket listener;
        int serverPort = 22222;
        public event EventHandler ServerStarted;
        public event StringEventHandler msg;
        public Server()
        {

        }
        public void StartServer()
        {
            IPHostEntry IPHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress IPAdress = IPHostInfo.AddressList[1];
            IPEndPoint localEndPoint = new IPEndPoint(IPAdress, serverPort);
            listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            listener.Bind(localEndPoint);
            listener.Listen(10);
            OnServerStarted();
            OnMsg(listener.LocalEndPoint.ToString());
            //---------------------------------------------
            handleConnection();
        }

        protected virtual void OnServerStarted()
        {
            ServerStarted(this, EventArgs.Empty);
        }
        protected virtual void OnMsg(string host)
        {
            msg(this, new StringEventArgs(host));
        }
        private void handleConnection()
        {
            Socket handler = listener.Accept();
            String data = string.Empty;
            byte[] bytes;
            while (true)
            {
                bytes = new byte[1024];
                int bytesRec = handler.Receive(bytes);
                data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                if (data.IndexOf("<EOF>") > -1)
                {
                    break;
                }
            }
            Console.WriteLine(data);
        }
    }
}
