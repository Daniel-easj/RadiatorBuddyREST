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
    internal class Reciever
    {
        private int PORT;
        private static string baseURL = "http://localhost:63998/api/SensorsData/";
        private static List<PiData> maclist = new List<PiData>();

        public Reciever(int port)
        {
            PORT = port;
        }

        public void start()
        {
            IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, 0);

            using (UdpClient recieversocket = new UdpClient(PORT))
            {
                while (true)
                {
                    
                    if (maclist.Count >= 1)
                    {
                        Post(HandleOneRequest(recieversocket, remoteEP));
                    }
                    else
                    {
                        HandleOneRequest(recieversocket, remoteEP);
                    }
                            
                }
            }

        
        }

        private static List<PiData> HandleOneRequest(UdpClient recieversocket, IPEndPoint remoteEP)
        {
            byte[] data = recieversocket.Receive(ref remoteEP);
            string instr = Encoding.ASCII.GetString(data);
            PiData piobj = new PiData();
                
            piobj = JsonConvert.DeserializeObject<PiData>(instr);

            Console.WriteLine("modtaget " + instr);
            Console.WriteLine("sender ip= " + remoteEP.Address + " port=" + remoteEP.Port);

            if (!maclist.Contains(piobj))
            {
                maclist.Add(piobj);
            }

            Console.WriteLine(maclist.Count);
            return maclist;

        }

        private static bool Post(List<PiData> obj)
        {
            using (HttpClient client = new HttpClient())
            {
                var jsonStr = JsonConvert.SerializeObject(obj);
                StringContent content = new StringContent(jsonStr, Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PostAsync(baseURL, content).Result;
                maclist.Clear();

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
        }

    }
}