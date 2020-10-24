using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace RPiCar_Controller
{
    //Argument personnaliser pour les events
    public class StringEventArgs : EventArgs
    {
        private String _Message = String.Empty;
        public StringEventArgs()
        {
            _Message = String.Empty;
        }
        public StringEventArgs(string message)
        {
            _Message = message;
        }
        public String Message { get { return _Message; } set { _Message = value; } }
    }
    public class PingEventArgs : EventArgs
    {
        private PingReply _pingReply;
        public PingReply PingReply
        {
            get { return _pingReply; }
            set { _pingReply = value; }
        }
        public PingEventArgs(PingReply ping)
        {
            PingReply = ping;        }
    }
    //----------------------------------------------------------------------------------------------------------------
    class Connection
    {
        //Declaration des events
        public event EventHandler<StringEventArgs> MessageReceived;
        public event EventHandler<PingEventArgs> PingEvent;
        public event EventHandler ConnectionSuccess;
        public event EventHandler ConnectionFailed;
        public event EventHandler<StringEventArgs> ConnectionLost;
        //Declaration des backgroundWorker pour recevoir et enver les ping
        private BackgroundWorker ReceiverWorker = new BackgroundWorker();
        private BackgroundWorker PingWorker = new BackgroundWorker();
        //Info pour la connection
        private string hostIP = "goy.ddns.net";
        private int port = 22222;
        private string connectionID = "Default";
        private bool isConnected = false;
        private long _ping = 0;
        IPHostEntry ipHostInfo;
        IPAddress ipAddress;
        IPEndPoint ipe;
        //Socket utiliser pour gerer la connection
        Socket socket;
        //Creation d'une connection en declarant lidentifiant utiliser pour que le serveur reconnaisse la connection
        public Connection(String ID, string IP)
        {
            connectionID = ID;
            hostIP = IP;
            ipHostInfo = Dns.GetHostEntry(hostIP);
            foreach(IPAddress ip in ipHostInfo.AddressList)
            {
                if(ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    ipAddress = ip;
                    break;
                }
            }
            ipe = new IPEndPoint(ipAddress, port);
            ReceiverWorker.DoWork += ReceiverWorker_DoWork;
            PingWorker.DoWork += PingWorker_DoWork;
        }
        //Connection en specifiant le port et l'ip
        public Connection(String ID, String IP, int PORT) : this(ID, IP)
        {
            port = PORT;
        }
        //---------------------------------------------------------------------------------------------------------

        public bool IsConnected
        {
            get
            {
                return isConnected;
            }
            private set
            {
                isConnected = value;
                
            }
        }
        //Etablie la connection retourne true sur un succes et false sur un echec
        public bool Connect()
        {
            try
            {
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(ipe);
                socket.Send(Encoding.ASCII.GetBytes(connectionID));
                OnConnectionSuccess(EventArgs.Empty);
                ReceiverWorker.RunWorkerAsync();
                PingWorker.RunWorkerAsync();
                return true;
            }
            catch (Exception ex)
            {
                OnConnectionFailed(EventArgs.Empty);
                Debug.WriteLine(ex.Message);
                return false;
            }
        }

        //---------------------------------------------------------------------------------------------------------
        
        //Section de code pour les BackGroundWorker

        //Envoie des pings au serveur pour verifier sa disponibiliter si le ping se rend pas la connection est fermer
        private void PingWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (IsConnected)
            {
                Thread.Sleep(10000);
                try
                {
                    Ping ping = new Ping();
                    PingReply RPing = ping.Send(IPAddress.Parse(hostIP));
                    if(RPing.Status != IPStatus.Success)
                    {
                        IsConnected = false;
                    }
                    else
                    {
                        _ping = RPing.RoundtripTime;
                        OnPingEvent(new PingEventArgs(RPing));
                    }
                    
                }
                catch(Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
                
            }
        }

        //Loop qui recois les message en utilisant la connection socket
        private void ReceiverWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                while (true)
                {
                    Thread.Sleep(10);
                    byte[] bytes = new byte[1024];
                    int byteCount = socket.Receive(bytes);
                    string data = Encoding.ASCII.GetString(bytes, 0, byteCount);
                    OnMessageReceived(new StringEventArgs(data));
                }
            }
            catch(Exception ex)
            {

                OnConnectionLost(new StringEventArgs(ex.Message));
            }
        }

        //---------------------------------------------------------------------------------------------------------

        //Section de code pour les events
        //Event message recu du serveur
        protected virtual void OnMessageReceived(StringEventArgs e)
        {
            Console.WriteLine(e.Message);
            MessageReceived(this, e);
        }
        //Event avec les info du ping
        protected virtual void OnPingEvent(PingEventArgs e)
        {
            Console.WriteLine("Ping to server is + " + e.PingReply.RoundtripTime);
            PingEvent(this, e);
        }
        //Event connection etablie
        protected virtual void OnConnectionSuccess(EventArgs e)
        {
            if(ConnectionSuccess != null)
            {
                IsConnected = true;
                ConnectionSuccess(this, e);
            }
        }
        //Event erreur de connection
        protected virtual void OnConnectionFailed(EventArgs e)
        {
            if(ConnectionFailed != null)
            {
                IsConnected = false;
                ConnectionFailed(this, e);
            }
        }
        //Event connection perdu
        protected virtual void OnConnectionLost(StringEventArgs e)
        {
            if(ConnectionLost != null)
            {
                IsConnected = false;
                ConnectionLost(this, e);
            }
        }

        //---------------------------------------------------------------------------------------------------------


        //Probablement inutile fonction pour envoyer des message je devrais plutot utiliser la fonction socket.Send() directement
        public void Send(String message)
        {
            if(socket != null)
            {
                try
                {
                    byte[] bytes = Encoding.ASCII.GetBytes(message);
                    socket.Send(bytes);
                }
                catch(Exception ex)
                {
                    ConnectionFailed?.Invoke(this, EventArgs.Empty);
                }
            }
        }
    }
}
