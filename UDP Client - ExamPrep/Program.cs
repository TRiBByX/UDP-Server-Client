using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UDP_Client___ExamPrep
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = 0;

            IPAddress ip = IPAddress.Parse("127.0.0.1");
            UdpClient client = new UdpClient("127.0.0.1", 8989);

            IPEndPoint endPoint = new IPEndPoint(ip, 8989);

            Console.WriteLine("State name: ");
            string name = Console.ReadLine();

            for (int i = 0; i < 6000; i++)
            {
                byte[] sendBytes = Encoding.ASCII.GetBytes($"{name} {num} Hello");

                client.Send(sendBytes, sendBytes.Length);
                byte[] receiveBytes = client.Receive(ref endPoint);

                string receivedData = Encoding.ASCII.GetString(receiveBytes);
                Console.WriteLine(receivedData);
                num++;

                Thread.Sleep(100);

            }
        }
    }
}
