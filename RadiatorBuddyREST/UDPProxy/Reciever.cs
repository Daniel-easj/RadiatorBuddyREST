using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using ModelLib.Models;
using System.Threading;
using System.Linq;

namespace UDPProxy
{
    // Reciever klassen har til formål at videresende den data som modtages med UDP på port 11912. Dataen vil udgøres af temperaturmålinger fra en eller flere raspberry Pi.
    public class Reciever
    {
        private int PORT;
        private static string baseURL = "https://radiatorbuddy.azurewebsites.net/api/sensorsdata";

        public Reciever(int port)
        {
            PORT = port;
        }

        public Reciever()
        {
            
        }

        public void start()
        {
            IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, 0);

            using (UdpClient recieversocket = new UdpClient(PORT))
            {
                while (true)
                {
                    Post(HandleOneRequest(recieversocket, remoteEP));
                }
            }

        
        }

        private static PiData HandleOneRequest(UdpClient recieversocket, IPEndPoint remoteEP)
        {
            byte[] data = recieversocket.Receive(ref remoteEP);
            string instr = Encoding.ASCII.GetString(data);
            PiData piobj = new PiData();
                
            piobj = JsonConvert.DeserializeObject<PiData>(instr);

            Console.WriteLine("modtaget " + instr);
            Console.WriteLine("sender ip= " + remoteEP.Address + " port=" + remoteEP.Port);
            return piobj;

        }

        public bool Post(PiData obj)
        {
            using (HttpClient client = new HttpClient())
            {
                var jsonStr = JsonConvert.SerializeObject(obj);
                StringContent content = new StringContent(jsonStr, Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PostAsync(baseURL, content).Result;

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
        }

    }
}