using RPiCar;
using System;

namespace Serveur
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Server s = new Server();
            s.MessageReceived += S_MessageReceived;
            s.ServerStarted += S_ServerStarted;
            s.msg += S_msg;
            s.StartServer();
        }

        private static void S_msg(object sender, StringEventArgs e)
        {
            Console.WriteLine(e.Text);
            Console.WriteLine(sender.GetType());
        }

        private static void S_ServerStarted(object sender, EventArgs e)
        {
            Console.WriteLine("This is the handler!");
        }

        private static void S_MessageReceived(object sender, EventArgs e)
        {
            Console.WriteLine(sender.GetType());
        }
    }
}
