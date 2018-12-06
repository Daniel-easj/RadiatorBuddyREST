using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RadiatorBuddyREST.Controllers;

namespace UnitTestRBuddy.RESTTests
{
    [TestClass]
    public class UnitTestWeatherREST
    {
        [TestMethod]
        public void GetWeatherRegulationDataOk()
        {
            var client = new HttpClient();

            var request = new HttpRequestMessage
            {
                RequestUri = new Uri("https://radiatorbuddy.azurewebsites.net/api/weatherdata/dict"),
                Method = HttpMethod.Get
            };

            //request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            using (var response = client.SendAsync(request).Result)
            {
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            }
        }

        [TestMethod]
        public void GetWeatherRegulationDataCountOk()
        {
            var client = new HttpClient();
            Dictionary<string, double> weatherDictData = new Dictionary<string, double>();
            Uri RequestUri = new Uri("https://radiatorbuddy.azurewebsites.net/api/weatherdata/dict");

            var response = client.GetStringAsync(RequestUri).Result;


            weatherDictData = JsonConvert.DeserializeObject<Dictionary<string, double>>(response);

            //WeatherDictData bør altid indeholde 40 elementer da det er den mængde af data vi forespørger fra OpenWeatherMap API. 
            //Hvis vi modtager flere elementer må det betyde at vi enten får for lidt eller for meget data 
            Assert.AreEqual(40, weatherDictData.Count);
        }

        //[TestMethod]
        //public void PostWeatherFail()
        //{
        //    var client = new HttpClient();

        //    var request = new HttpRequestMessage
        //    {
        //        RequestUri = new Uri("https://radiatorbuddy.azurewebsites.net/api/weatherdata/dict"),
        //        Method = HttpMethod.Post
        //    };

        //    //request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //    using (var response = client.SendAsync(request).Result)
        //    {
        //        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        //    }
        //}
    }
}
