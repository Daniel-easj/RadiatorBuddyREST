using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLib.Models.APIModels;
using Newtonsoft.Json;

namespace RadiatorBuddyREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherDataController : ControllerBase
    {
        private static string weatherURI = "http://api.openweathermap.org/data/2.5/forecast?id=6543938&APPID=e46578c868b44e44510749d46ef3fd2f&units=metric";
        private static HttpClient client = new HttpClient();
        private static List<APIData> apiData = new List<APIData>();
        private APIDataList weatherList;

        public WeatherDataController()
        {
            string jsonString = client
                .GetStringAsync(weatherURI)
                .Result;
            weatherList = JsonConvert.DeserializeObject<APIDataList>(jsonString);

        }

        // GET: api/WeatherData
        [HttpGet]
        public IEnumerable<APIData> Get()
        {
            return weatherList.list;
        }

        // GET: api/WeatherData/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/WeatherData
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/WeatherData/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
