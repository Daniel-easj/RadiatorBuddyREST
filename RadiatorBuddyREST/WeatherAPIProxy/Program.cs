using System;

namespace WeatherAPIProxy
{
    class Program
    {
        static void Main(string[] args)
        {
            WeatherDataProxy wdp = new WeatherDataProxy();

            wdp.Start();

            Console.ReadKey();
        }
    }
}
