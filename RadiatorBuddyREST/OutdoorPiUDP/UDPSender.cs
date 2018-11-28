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

        public void start()
        {


            PiData pidata = new PiData("181DEA819754" + "*", Math.Round(random.NextDouble() * (maxTemp - minTemp), 2), DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"), "forhave", false);

            string jsonString = JsonConvert.SerializeObject(pidata);


            byte[] data = Encoding.ASCII.GetBytes(jsonString);

            IPEndPoint receiverEP = new IPEndPoint(IPAddress.Broadcast, PORT);

            using (UdpClient senderSock = new UdpClient()) // ingen port = lytter IKKE
            {
                senderSock.EnableBroadcast = true;
          
                while (true)
                {
                    senderSock.Send(data, data.Length, receiverEP);
                    Thread.Sleep(30000);
                }

            }
        }

    }
}
