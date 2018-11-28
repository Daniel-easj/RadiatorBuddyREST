using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;

namespace WeatherAPIProxy
{
    class WeatherDataProxy
    {
        private static HttpClient client = new HttpClient();


        public void Start()
        {
            string content = client.GetStringAsync("http://api.openweathermap.org/data/2.5/forecast?id=6543938&APPID=e46578c868b44e44510749d46ef3fd2f&units=metric").Result;
            Console.WriteLine(content);
        }
        


    }
}
