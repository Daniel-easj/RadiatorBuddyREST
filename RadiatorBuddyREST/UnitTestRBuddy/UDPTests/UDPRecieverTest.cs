using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OutdoorPiUDP;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using ModelLib.Models;
using UDPProxy;

namespace UnitTestRBuddy.UDPTests
{
    [TestClass]
    public class UDPRecieverTest
    {
        [TestMethod]
        public void TestCreatePiData_NeedsToPass()
        {
            Reciever udpReciever = new Reciever();
            PiData piDataTestObject = new PiData("MacTest", 22.2, DateTime.Now, "LocationTest", true);

            Assert.AreEqual(true, udpReciever.Post(piDataTestObject));
        }
    }
}
