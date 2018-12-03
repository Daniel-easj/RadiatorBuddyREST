using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Net.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLib.Models;
using RadiatorBuddyREST.Controllers;
using System.Net.Http.Headers;
using System.Net;
using System.Text;
using Microsoft.AspNetCore.Mvc;
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

            //request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

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

            //request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            using (var response = client.SendAsync(request).Result)
            {
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            }
        }

        [TestMethod]
        public void GetOne_needstofail()
        {
            var client = new HttpClient(); // no HttpServer

            var request = new HttpRequestMessage
            {
                RequestUri = new Uri("http://localhost:63998/api/SensorsData/999"),
                Method = HttpMethod.Get
            };

            //request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            using (var response = client.SendAsync(request).Result)
            {
                Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);
            }
        }

        [TestMethod]
        public void Post_needstopass()
        {
            var client = new HttpClient(); // no HttpServer

            var send = new HttpRequestMessage
            {
                RequestUri = new Uri("http://localhost:63998/api/SensorsData/"),
                Method = HttpMethod.Post
            };

            PiData newpi = new PiData("55", 20, DateTime.Now, "here", true);
            string jstring = JsonConvert.SerializeObject(newpi);
            send.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(jstring));

            using (var response = client.SendAsync(send).Result)
            {
                Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            }
        }
    }
}
