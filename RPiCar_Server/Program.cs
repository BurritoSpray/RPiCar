using RPiCar;
using System;

namespace RPiCar_Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Server s = new Server();
            s.ServerStarted += S_ServerStarted;
            s.MessageReceived += S_MessageReceived;
            s.CommandReceived += S_CommandReceived;
            s.StartServer();
        }

        private static void S_CommandReceived(object sender, StringEventArgs e)
        {
            Console.WriteLine(e.Text);
        }

        private static void S_MessageReceived(object sender, StringEventArgs e)
        {
            
        }

        private static void S_ServerStarted(object sender, EventArgs e)
        {
            Console.WriteLine("Server Started!");
        }
    }
}
