using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLib.Models.APIModels;
using ModelLib.Models.APIUVModels;
using Newtonsoft.Json;

namespace RadiatorBuddyREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherDataController : ControllerBase
    {
        private static string weatherURI = "http://api.openweathermap.org/data/2.5/forecast?id=6543938&APPID=e46578c868b44e44510749d46ef3fd2f&units=metric";
        private static string weatherURIUV = "";
        private static HttpClient client = new HttpClient();
        private APIDataList weatherList;
        private APIUVDataList uvList;
        private static List<APIUVData> apiuvDataList = new List<APIUVData>();

        public WeatherDataController()
        {
            string jsonWeatherString = client
                .GetStringAsync(weatherURI)
                .Result;
            weatherList = JsonConvert.DeserializeObject<APIDataList>(jsonWeatherString);

            string jsonUVstring =
                 client
                .GetStringAsync(
                         "http://api.openweathermap.org/data/2.5/uvi/forecast?appid=e46578c868b44e44510749d46ef3fd2f&lat=55.646016&lon=12.297937&cnt=5")
                    .Result;
            apiuvDataList = JsonConvert.DeserializeObject<List<APIUVData>>(jsonUVstring);

            weatherList.ApiUvDataList = apiuvDataList;

        }

        // GET: api/WeatherData
        [HttpGet]
        public IEnumerable<APIData> Get()
        {
            return weatherList.list;
        }

        // GET: api/WeatherData
        [HttpGet]
        [Route("uv")]
        public IEnumerable<APIUVData> GetUVData()
        {
            return weatherList.ApiUvDataList;
        }

    }
}
