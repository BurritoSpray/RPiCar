using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.ComponentModel;
//TODO Ameliorer le code du server ouachhh!
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
        public event StringEventHandler MessageReceived;
        public event StringEventHandler CommandReceived;
        private BackgroundWorker controllerWorker = new BackgroundWorker();
        private BackgroundWorker connectionHandler = new BackgroundWorker();
        public Dictionary<string, Socket> connections = new Dictionary<string, Socket>();
        private String receiverID = "Car";
        private String controllerID = "Controller";
        public Server()
        {
            controllerWorker.DoWork += ControllerWorker_DoWork;
            controllerWorker.RunWorkerCompleted += ControllerWorker_RunWorkerCompleted;
            controllerWorker.RunWorkerCompleted += ControllerWorker_RunWorkerCompleted1;
            controllerWorker.WorkerReportsProgress = true;
            controllerWorker.WorkerSupportsCancellation = true;
            connectionHandler.DoWork += ConnectionHandler_DoWork;
        }

        private void ConnectionHandler_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                handleConnection();
                Thread.Sleep(10);
            }
        }

        private void ControllerWorker_RunWorkerCompleted1(object sender, RunWorkerCompletedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ControllerWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ControllerWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                try
                {
                    if (connections.ContainsKey("Controller"))
                    {
                        Socket controller = connections["Controller"];
                        BackgroundWorker worker = sender as BackgroundWorker;
                        while (true)
                        {
                            controller = connections["Controller"];
                            if (worker.CancellationPending != true)
                            {
                                Thread.Sleep(10);
                                byte[] bytes = new byte[1024];
                                int bytesCount = controller.Receive(bytes);
                                string msg = Encoding.ASCII.GetString(bytes, 0, bytesCount);
                                if (msg != string.Empty)
                                {
                                    OnCommandReceived(this, new StringEventArgs(msg));
                                }
                            }
                            else
                            {
                                controller.Disconnect(false);
                                break;
                            }
                        }
                    }
                    Thread.Sleep(100);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        protected virtual void OnCommandReceived(Object sender, StringEventArgs e)
        {
            try
            {
                if (connections.ContainsKey("Car"))
                {
                    connections["Car"].Send(Encoding.ASCII.GetBytes(e.Text));
                }
                else
                {
                    Console.WriteLine(String.Format("Message '{0}' received but cant reach the car", e.Text));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            CommandReceived?.Invoke(this, new StringEventArgs(e.Text));
        }

        public void StartServer()
        {
            try
            {
                IPHostEntry IPHostInfo = Dns.GetHostEntry(Dns.GetHostName());
                IPAddress IPAdress = IPAddress.Any;
                foreach (IPAddress ip in IPHostInfo.AddressList)
                {
                    if(ip.AddressFamily == AddressFamily.InterNetwork)
                    {
                        IPAdress = ip;
                    }
                }
                IPEndPoint localEndPoint = new IPEndPoint(IPAdress, serverPort);
                listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                listener.Bind(localEndPoint);
                listener.Listen(10);
                OnServerStarted();
                //---------------------------------------------
                connectionHandler.RunWorkerAsync();
                controllerWorker.RunWorkerAsync();
                while (controllerWorker.IsBusy)
                {
                    Thread.Sleep(10);
                }
            }
            catch(SocketException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected virtual void OnServerStarted()
        {
            ServerStarted(this, EventArgs.Empty);
        }
        protected virtual void OnMessageReceived(string host)
        {
            MessageReceived(this, new StringEventArgs(host));
        }
        private void OnClientConnected(string client)
        {
            Console.WriteLine(String.Format("{0} Connected!", client));
        }
        private void handleConnection()
        {
            byte[] bytes;
            while (true)
            {
                String data = string.Empty;
                Socket handler = listener.Accept();
                bytes = new byte[1024];
                int bytesRec = handler.Receive(bytes);
                data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                if (data != string.Empty)
                {
                    if (data == receiverID || data == controllerID)
                    {
                        connections[data] = handler;
                        OnClientConnected(data);
                        break;
                    }
                    //connections.Add(data, handler);
                    //break;

                }
            }

        }
    }
}
