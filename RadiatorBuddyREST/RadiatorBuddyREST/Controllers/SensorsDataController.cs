using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO.Pipes;
using System.Linq;
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
        private static List<PiData> piList = new List<PiData>()
        {
            new PiData("1", 20, DateTime.Now, "here", true)
        };

        //private ManagePiData dbConnection = new ManagePiData();

        // GET: api/SensorsData
        [HttpGet]
        public List<PiData> GetSensorData()
        {
            return piList;
        }

        // GET: api/SensorsData/5
        [HttpGet("{id}")]
        public PiData GetOneSensorData(string id)
        {
            return piList.Find(i => i.Id == id);
        }

        // POST: api/SensorsData
        [HttpPost]
        public void Post([FromBody] PiData obj)
        {
            piList.Add(obj);
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
