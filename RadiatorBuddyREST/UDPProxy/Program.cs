using System;

namespace UDPProxy
{
    class Program
    {
        private const int PORT = 11912;
        static void Main(string[] args)
        {
            Reciever reciever = new Reciever(PORT);
            reciever.start();

            Console.ReadLine();
        }
    }
}
