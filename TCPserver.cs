using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TCPserver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TcpListener server = new TcpListener(IPAddress.Any, 5000);
            server.Start();
            Console.WriteLine("Server started...");

            while (true)
            {
                using (TcpClient client = server.AcceptTcpClient())
                {
                    NetworkStream stream = client.GetStream();
                    // Simuler sensor data
                    string sensorData = "Sensor data: " + DateTime.Now;
                    byte[] data = Encoding.UTF8.GetBytes(sensorData);
                    stream.Write(data, 0, data.Length);
                    Console.WriteLine($"Sent: {sensorData}");
                }
            }
        }

    }
}


