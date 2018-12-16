using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using ModelLib.Models;
using Newtonsoft.Json;

namespace OutdoorPiUDP
{
    // Da vi i projektet kun har 1 Raspberry Pi til rådighed har vi denne UDPSender class 
    // som skal forestille sig at være en falsk Raspberry pi sensor der er placeret udenfor.
    public class UDPSender
    {
        private int PORT;
        private static Random random = new Random();
        private const double maxTemp = 7;
        private const double minTemp = 2;

        public UDPSender(int port)
        {
            this.PORT = port;
        }

        // Data sendes med mellemrum på 30 sekunder (30000ms)
        public void start()
        {
            IPEndPoint receiverEP = new IPEndPoint(IPAddress.Broadcast, PORT);

            using (UdpClient senderSock = new UdpClient()) // ingen port = lytter IKKE
            {
                senderSock.EnableBroadcast = true;
          
                while (true)
                {
                    senderClass(senderSock, receiverEP);

                    Thread.Sleep(30000);
                }

            }
        }

        public static bool senderClass(UdpClient senderSock, IPEndPoint receiverEP)
        {
            // Kunstigt sensor data objekt. Skabes for at simulere en udendørs PI
            PiData pidata = new PiData("k4:27:ij:94:aa:a7", Math.Round(random.NextDouble() * (maxTemp - minTemp), 2), DateTime.Now.AddHours(1), "forhave", false);

            string jsonString = JsonConvert.SerializeObject(pidata);


            byte[] data = Encoding.ASCII.GetBytes(jsonString);
            senderSock.Send(data, data.Length, receiverEP);

            return true;
        }

    }
}
