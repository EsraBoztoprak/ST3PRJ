using System;
using System.IO.Ports; 
using System.Text;

namespace BluetoothSender
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Replace the TCP logic with SerialPort for Bluetooth
            string portName = "COM3"; 
            int baudRate = 115200; 

            try
            {
                // Open a serial port for Bluetooth communication
                using (SerialPort serialPort = new SerialPort(portName, baudRate))
                {
                    serialPort.Open();
                    Console.WriteLine("Bluetooth connection established!");

                    while (true)
                    {
                      
                        string sensorData = "Sensor data: " + DateTime.Now;
                        byte[] data = Encoding.UTF8.GetBytes(sensorData);
                        serialPort.Write(data, 0, data.Length);
                        Console.WriteLine($"Sent: {sensorData}");
                        // Wait for a second before sending the next piece of data
                        System.Threading.Thread.Sleep(1000);
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any errors related to serial communication
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
