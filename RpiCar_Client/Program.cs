using RPiCar_Controller;
using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace RpiCar_Client
{
    class Program
    {
        static bool isConnected = false;
        static Connection con;
        static readonly string serverIP = "goy.ddns.net";


        static void Main(string[] args)
        {
            while (true) {
                Console.Clear();
                Console.WriteLine("Selectionner le mode de connection!\n1.Car\n2.Controller");
                ConsoleKeyInfo choice = Console.ReadKey();
                Console.WriteLine("\n");
                if (choice.KeyChar.ToString() == "1")//Car choice
                {
                    con = new Connection("Car", serverIP);
                }
                else if(choice.KeyChar.ToString() == "2")//Controller
                {
                    con = new Connection("Controller", serverIP);
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                    Thread.Sleep(3000);
                }
                if(choice.KeyChar.ToString() == "1" || choice.KeyChar.ToString() == "2")
                {
                    con.MessageReceivedEvent += Con_MessageReceived;
                    con.ConnectionSuccessEvent += Con_ConnectionSuccess;
                    con.ConnectionLostEvent += Con_ConnectionLost;
                    con.ConnectionFailedEvent += Con_ConnectionFailedEvent;
                    con.PingErrorEvent += Con_PingErrorEvent;
                    con.PingEvent += Con_PingEvent;
                    break;
                }
            }

            while (true)
            {
                if(isConnected)
                {
                    Thread.Sleep(100);
                    string input = Console.ReadLine();
                    if(input != string.Empty)
                        con.Send(input);
                }
                if (!isConnected)
                {
                    Console.WriteLine("Connecting to server...");
                    isConnected = con.Connect();
                    
                }
                if(!isConnected)
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
