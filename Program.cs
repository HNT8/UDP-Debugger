using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class Program
{
    private static string IP;
    private static int PORT;

    static void Main(string[] args)
    {
        if (args.Length > 0)
        {
            if (args.Length == 2)
            {
                IP = args[0];
                PORT = Convert.ToInt32(args[1]);
            }
        } else
        {
            Console.Write("IP: ");
            IP = Console.ReadLine();
            Console.Write("PORT: ");
            PORT = Convert.ToInt32(Console.ReadLine());
            if (IP == null) 
            {
                Console.WriteLine("Invalid IP");
                Thread.Sleep(1000);
                Environment.Exit(0);
            }
        }

        while (true)
        {
            Console.Write("> ");
            byte[] cmd = Encoding.ASCII.GetBytes(Console.ReadLine());
            
            try
            {
                Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                IPAddress ip = IPAddress.Parse(IP);
                IPEndPoint endPoint = new IPEndPoint(ip, PORT);
                sock.SendTo(cmd, endPoint);
                Console.WriteLine("Successfully sent message.");
            } catch (Exception ex)
            {
                Console.WriteLine("Failed to send message. Error: " + ex.Message);
            }
        }
    }
}