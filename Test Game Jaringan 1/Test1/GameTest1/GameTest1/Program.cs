using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.Sockets;
using System.IO;

namespace GameTest1
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            server.Connect("127.0.0.1", 8000);
            byte[] buffer = new byte[1024];

            while (true)
            {
                int bytes = server.Receive(buffer);
                Console.WriteLine(Encoding.Default.GetString(buffer, 0, bytes));
            }
        }
    }
}
