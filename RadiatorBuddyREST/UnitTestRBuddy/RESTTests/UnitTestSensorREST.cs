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
            var client = new HttpClient();

            var request = new HttpRequestMessage
            {
                RequestUri = new Uri("https://radiatorbuddy.azurewebsites.net/api/sensorsdata"),
                Method = HttpMethod.Get
            };

            using (var response = client.SendAsync(request).Result)
            {
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            }
        }

        [TestMethod]
        public void GetFromPeriod_needstopass()
        {
            var client = new HttpClient();
            Uri requestUri = new Uri("https://radiatorbuddy.azurewebsites.net/api/sensorsdata?timefrom=2018-03-12%2013:00:00&timeto=2018-03-12%2013:16:00");

            var response = client.GetAsync(requestUri).Result;
            Assert.AreEqual(true, response.IsSuccessStatusCode);
            
        }

        [TestMethod]
        public void Post_needstopass()
        {
            var client = new HttpClient();

            Uri RequestUri = new Uri("https://radiatorbuddy.azurewebsites.net/api/sensorsdata/");


            PiData newpi = new PiData("55", 20, DateTime.Now, "here", true);
            string jstring = JsonConvert.SerializeObject(newpi);
            StringContent content = new StringContent(jstring, Encoding.UTF8, "application/json");

            var response = client.PostAsync(RequestUri, content).Result;

            Assert.AreEqual(true, response.IsSuccessStatusCode);

        }
    }
}
