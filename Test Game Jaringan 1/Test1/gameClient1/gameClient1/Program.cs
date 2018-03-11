using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.Sockets;

namespace gameServer
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Any, 8000);
                Socket newsock = new Socket(AddressFamily.InterNetwork,
                                   SocketType.Stream, ProtocolType.Tcp);
                newsock.Bind(localEndPoint);
                newsock.Listen(10);
                Socket client = newsock.Accept();

                if (client.Connected)
                {
                    Console.WriteLine("client connected.");
                }

                string msg = "Who's there?";
                byte[] buffer = new byte[msg.Count()];
                buffer = Encoding.ASCII.GetBytes(msg);
                client.Send(buffer);

                while (client.Connected)
                {
                    Console.WriteLine("enter msg: ");
                    string userMsg = Console.ReadLine();
                    byte[] userBuffer = new byte[userMsg.Count()];
                    userBuffer = Encoding.ASCII.GetBytes(userMsg);
                    client.Send(userBuffer);

                    Console.ReadKey();
                }

            }

            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
            }
        }
    }
}
