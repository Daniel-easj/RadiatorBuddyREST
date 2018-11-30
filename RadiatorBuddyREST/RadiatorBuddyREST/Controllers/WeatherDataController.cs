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

        private static string weatherUVURI = "http://api.openweathermap.org/data/2.5/uvi/forecast?appid=e46578c868b44e44510749d46ef3fd2f&lat=55.646016&lon=12.297937&cnt=5";
        private static HttpClient client = new HttpClient();
        private APIDataList weatherList;
        private APIUVDataList uvList;
        private static List<APIUVData> tempApiUVDataList = new List<APIUVData>();

        public WeatherDataController()
        {
            //string jsonWeatherString = client
            //    .GetStringAsync(weatherURI)
            //    .Result;
            //weatherList = JsonConvert.DeserializeObject<APIDataList>(jsonWeatherString);

            //string jsonUVstring =
            //     client
            //    .GetStringAsync(weatherUVURI)
            //    .Result;
            //weatherList.ApiUvDataList = JsonConvert.DeserializeObject<List<APIUVData>>(jsonUVstring);
        }

        private async Task<string> JsonWeatherStringAsync()
        {
            string result = await client.GetStringAsync(weatherURI);
            return result;
        }

        private async Task<IEnumerable<APIData>> JsonWeatherStringToObject()
        {
            weatherList = JsonConvert.DeserializeObject<APIDataList>(await JsonWeatherStringAsync());
            return weatherList.list;
        }

        private async Task<string> JsonWeatherUVStringAsync()
        {
            string result = await client.GetStringAsync(weatherUVURI);
            return result;
        }

        private async Task<IEnumerable<APIUVData>> JsonWeatherUVStringToObject()
        {       
            if (weatherList != null)
            {
                weatherList.ApiUvDataList = JsonConvert.DeserializeObject<List<APIUVData>>(await JsonWeatherUVStringAsync());
                return weatherList.ApiUvDataList;
            }
            else
            {
                tempApiUVDataList = JsonConvert.DeserializeObject<List<APIUVData>>(await JsonWeatherUVStringAsync());
                return tempApiUVDataList;
            }
            
        }


        // GET: api/WeatherData
        [HttpGet]
        public async Task<IEnumerable<APIData>> Get()
        {
            // TODO: sørg for at UV data kommer ind i weatherlist.ApiUVDataList
            return await JsonWeatherStringToObject();
        }

        // GET: api/WeatherData
        [HttpGet]
        [Route("uv")]
        public async Task<IEnumerable<APIUVData>> GetUVData()
        {
            return await JsonWeatherUVStringToObject();
        }

    }
}
