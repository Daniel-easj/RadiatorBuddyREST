using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;

namespace UDPProxy
{
    internal class Reciever
    {
        private int PORT;
        private static string baseURL = "http://localhost:63998/api/SensorsData/";
        private static List<string> maclist = new List<string>();

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
                    Post(HandleOneRequest(recieversocket, remoteEP));
                }
            }
        }

        private static string HandleOneRequest(UdpClient recieversocket, IPEndPoint remoteEP)
        {
            byte[] data = recieversocket.Receive(ref remoteEP);
            string instr = Encoding.ASCII.GetString(data);

            Console.WriteLine("modtaget " + instr);
            Console.WriteLine("sender ip= " + remoteEP.Address + " port=" + remoteEP.Port);

            string[] tempobj;


            tempobj = Regex.Split(instr, "[*]");

            if (!maclist.Contains(tempobj[0]))
            {
                maclist.Add(tempobj[0] + tempobj[1]);
            }

            return maclist.ToString();

        }

        private static bool Post(string obj)
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