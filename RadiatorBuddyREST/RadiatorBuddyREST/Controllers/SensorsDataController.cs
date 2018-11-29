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

namespace RadiatorBuddyREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensorsDataController : ControllerBase
    {
        private static List<PiData> data1 = new List<PiData>()
        {
            new PiData("1", 20, "time.exe", "room", true),
            new PiData("2", 22, "time.exe", "room", true),
            new PiData("3", 22, "time.exe", "room", true)
        };

        private List<PiData> data2 = new List<PiData>()
        {
            new PiData("2", 22, "time.exe", "room", true)
        };

        private static Dictionary<string, List<PiData>> piDictionary = new Dictionary<string, List<PiData>>();
        

        public SensorsDataController()
        {
            if (!piDictionary.ContainsKey("1") && !piDictionary.ContainsKey("2"))
            {
                piDictionary.Add("0", data1);
                piDictionary.Add("1", data2);
            }
        }

        // GET: api/SensorsData
        [HttpGet]
        public Dictionary<string, List<PiData>> GetSensorData()
        {
            return piDictionary;
        }

        // GET: api/SensorsData/5
        [HttpGet("{id}")]
        public List<PiData> GetOneSensorData(string id)
        {
            Dictionary<string, List<PiData>> tempdic = new Dictionary<string, List<PiData>>();
            List<PiData> piitems = piDictionary[id];
            return piitems;
        }

        // POST: api/SensorsData
        [HttpPost]
        public void Post([FromBody] List<PiData> obj)
        {
            string tempcount = (piDictionary.Count()).ToString();
            piDictionary.Add(tempcount, obj);
        }

        // PUT: api/SensorsData/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] List<PiData> obj)
        {
            piDictionary[id] = obj;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            piDictionary.Remove(id);
        }
    }
}
