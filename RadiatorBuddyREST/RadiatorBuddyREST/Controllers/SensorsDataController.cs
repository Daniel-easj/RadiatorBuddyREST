using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLib.Models;
using RadiatorBuddyREST.DbUtil;

namespace RadiatorBuddyREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensorsDataController : ControllerBase
    {
        private const string baseQueryString = "select * from PiData";
        private static ManagePiData piDataManager = new ManagePiData();

        // GET: api/SensorsData
        [HttpGet]
        public List<PiData> GetSensorData([FromQuery] QueryData qData)
        {
            StringBuilder queryString = new StringBuilder();
            queryString.Append(baseQueryString);

            // Hvis variablerne i qData er null må det betyde at der ikke er givet nogle parametre i uri - og så returneres alt pidata
            if (qData.TimeFrom == null && qData.TimeTo == null)
            {
                return piDataManager.GetAllPiData();
            }

            queryString.Append(" WHERE");

            // Eksempel: http://localhost:52588/api/sensorsdata?timefrom=2019-01-01%2014:00:00&timeto=2019-02-01%2014:00:00
            if (qData.TimeFrom != null && qData.TimeTo != null)
            {

                queryString.Append($" TimeStamp Between '{qData.TimeFrom}' AND '{qData.TimeTo}'");

                return piDataManager.GetPiDataFromPeriod(queryString.ToString());
            }

            if (qData.TimeFrom == null && qData.TimeTo != null)
            {

            }

            if (qData.TimeFrom != null && qData.TimeTo == null)
            {

            }

            return null;


        }

        // GET: api/SensorsData/5
        [HttpGet("{id}")]
        public List<PiData> GetOneSensorData(string id)
        {
            return piDataManager.GetSpecificPiSensorData(id);
        }

        // POST: api/SensorsData
        [HttpPost]
        public void Post([FromBody] PiData obj)
        {
            piDataManager.CreatePiData(obj);
        }

        // PUT: api/SensorsData/5
        //[HttpPut("{id}")]
        //public void Put(string id, [FromBody] List<PiData> obj)
        //{
            
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(string id)
        //{
            
        //}
    }
}
