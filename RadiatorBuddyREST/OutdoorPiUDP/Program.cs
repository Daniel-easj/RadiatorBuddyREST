using System;

namespace OutdoorPiUDP
{
    class Program
    {
        static void Main(string[] args)
        {
            const int PORT = 11912;

            UDPSender udpSender = new UDPSender(PORT);
            udpSender.start();

            Console.ReadKey();
        }
    }
}
