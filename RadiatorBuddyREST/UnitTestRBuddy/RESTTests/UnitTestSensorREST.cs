using System;
using System.Net.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLib.Models;
using RadiatorBuddyREST.Controllers;
using System.Net.Http.Headers;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace UnitTestRBuddy.RESTTests
{
    [TestClass]
    public class UnitTestSensorREST
    {
        [TestMethod]
        public void GetAll_needstopass()
        {
            var client = new HttpClient(); // no HttpServer

            var request = new HttpRequestMessage
            {
                RequestUri = new Uri("http://localhost:63998/api/SensorsData/"),
                Method = HttpMethod.Get
            };

            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            using (var response = client.SendAsync(request).Result)
            {
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            }
        }

        [TestMethod]
        public void GetOne_needstopass()
        {
            var client = new HttpClient(); // no HttpServer

            var request = new HttpRequestMessage
            {
                RequestUri = new Uri("http://localhost:63998/api/SensorsData/1"),
                Method = HttpMethod.Get
            };

            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            using (var response = client.SendAsync(request).Result)
            {
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            }
        }

        [TestMethod]
        public void Post_needstopass()
        {
            var client = new HttpClient(); // no HttpServer

            var request = new HttpRequestMessage
            {
                RequestUri = new Uri("http://localhost:63998/api/SensorsData/"),
                Method = HttpMethod.Post
            };

            PiData obj = new PiData("1", 20, DateTime.Now.ToString(), "kitchen", true);

            string jsonobj = JsonConvert.SerializeObject(obj);

            //byte[] data = Encoding.ASCII(jsonobj);

            using (var response = client.SendAsync(request).Result)
            {
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            }
        }
    }
}
