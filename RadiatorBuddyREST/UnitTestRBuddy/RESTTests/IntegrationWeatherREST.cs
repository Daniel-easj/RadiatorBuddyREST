using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLib.Models.APIModels;
using Newtonsoft.Json;
using RadiatorBuddyREST.Controllers;

namespace UnitTestRBuddy.RESTTests
{
    [TestClass]
    public class IntegrationWeatherREST
    {

        // Det bør være muligt at lave et Get request på vores Weather API
        [TestMethod]
        public void GetWeatherRegulationDataOk()
        {
            var client = new HttpClient();

            var request = new HttpRequestMessage
            {
                RequestUri = new Uri("https://radiatorbuddy.azurewebsites.net/api/weatherdata/"),
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

            //WeatherDictData bør altid indeholde 40 elementer da det er den mængde af data vi forespørger fra OpenWeatherMap API (Svarende til 5 dages vejrprognose). 
            //Hvis vi modtager flere elementer må det betyde at vi enten får for lidt eller for meget data 
            Assert.AreEqual(40, weatherDictData.Count);
        }

        // Det bør ikke være muligt at sende et POST request til vores WeatherData API, da den udelukkende eksisterer for at nedhente data
        [TestMethod]
        public void PostWeatherFail()
        {
            var client = new HttpClient();
            APIData apiData = new APIData(new APIMain(22), new APIClouds(56), "2018-12-07 12:00:00");
            Uri RequestUri = new Uri("https://radiatorbuddy.azurewebsites.net/api/weatherdata/");

            string jstring = JsonConvert.SerializeObject(apiData);
            StringContent content = new StringContent(jstring, Encoding.UTF8, "application/json");

            var response = client.PostAsync(RequestUri, content).Result;

            Assert.AreEqual(false, response.IsSuccessStatusCode);
        }
    }
}
