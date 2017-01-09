using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace UDP___ExamPrep
{
    class Program
    {
        static void Main(string[] args)
        {
            //Send to IP
            var server = new UdpClient(8989);

            IPAddress ip = IPAddress.Parse("127.0.0.1");
            IPEndPoint endPoint = new IPEndPoint(ip, 8989);

            try
            {
                Console.WriteLine("Server is blocked");
                while (true)
                {
                    Byte[] receiveBytes = server.Receive(ref endPoint);
                    //server is now active

                    string receivedData = Encoding.ASCII.GetString(receiveBytes);
                    string[] data = receivedData.Split(' ');
                    string clientName = data[0];
                    string text = data[1] + data[2];

                    Console.WriteLine(receivedData);

                    string sendData = $"Server: {text.ToUpper()}";
                    byte[] sendBytes = Encoding.ASCII.GetBytes(sendData);

                    server.Send(sendBytes, sendBytes.Length, endPoint);

                    Console.WriteLine($"This Message was sent from {endPoint.Address.ToString()} on their port number {endPoint.Port.ToString()}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
