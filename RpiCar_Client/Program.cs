using RPiCar_Controller;
using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace RpiCar_Client
{
    class Program
    {
        static bool isConnected = false;
        static Connection con = new Connection("Car", "goy.ddns.net");


        static void Main(string[] args)
        {
            con.MessageReceivedEvent += Con_MessageReceived;
            con.ConnectionSuccessEvent += Con_ConnectionSuccess;
            con.ConnectionLostEvent += Con_ConnectionLost;
            con.ConnectionFailedEvent += Con_ConnectionFailedEvent;
            con.PingErrorEvent += Con_PingErrorEvent;
            con.PingEvent += Con_PingEvent;

            while (true)
            {
                if(isConnected)
                {
                    Thread.Sleep(100);
                }
                if (!isConnected)
                {
                    Console.WriteLine("Connecting to server...");
                    isConnected = con.Connect();
                    
                }
                Thread.Sleep(10000);
            }

        }
        private static void Con_ConnectionFailedEvent(object sender, ExceptionEventArgs e)
        {
            Console.WriteLine("Connection failed!\n" + e.Message);
            isConnected = false;

        }

        private static void Con_ConnectionLost(object sender, ExceptionEventArgs e)
        {
            Console.WriteLine("Connection to the server has been lost\n" + e.Message);
            isConnected = false;
        }

        private static void Con_MessageReceived(object sender, StringEventArgs e)
        {
            Console.WriteLine(e.Message);
        }

        private static void Con_ConnectionSuccess(object sender, EventArgs e)
        {
            Program p = sender as Program;
            Console.WriteLine("Connected!");
        }

        private static void Con_PingEvent(object sender, PingEventArgs e)
        {

            if (isConnected)
            {
                Console.WriteLine("Ping is " + e.PingReply.RoundtripTime + " ms");
            }
        }

        private static void Con_PingErrorEvent(object sender, ExceptionEventArgs e)
        {
            con.StopPingWorker();
        }
    }
}
