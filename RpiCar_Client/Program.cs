using RPiCar_Controller;
using System;
using System.Threading;

namespace RpiCar_Client
{
    class Program
    {
        private static Connection con = new Connection("Car", "goy.ddns.net");
        static void Main(string[] args)
        {
            con.ConnectionSuccessEvent += Con_ConnectionSuccess;
            con.MessageReceivedEvent += Con_MessageReceived;
            con.ConnectionLostEvent += Con_ConnectionLost;
            while (true)
            {
                while (con.IsConnected)
                {
                    Thread.Sleep(100);
                }
                if (con.IsConnected == false)
                {
                    try
                    {
                        Console.WriteLine("Connecting to server...");
                        con.Connect();
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    Thread.Sleep(5000);
                }
            }
        }

        private static void Con_ConnectionLost(object sender, EventArgs e)
        {
            Console.WriteLine("Connection to the server has been lost");
        }

        private static void Con_MessageReceived(object sender, StringEventArgs e)
        {

        }

        private static void Con_ConnectionSuccess(object sender, EventArgs e)
        {
            Console.WriteLine("Connected!");
        }
    }
}
