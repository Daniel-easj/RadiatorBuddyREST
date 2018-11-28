using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLib.Models;

namespace RadiatorBuddyREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensorsDataController : ControllerBase
    {
        private static Dictionary<string, List<PiData>> piDictionary = new Dictionary<string, List<PiData>>();

        public SensorsDataController()
        {
            piDictionary.Add("1", new List<PiData>()
            {
                new PiData("1", 20, "time.exe", "room", true),
                new PiData("2", 22, "time.exe", "room", true),
                new PiData("2", 22, "time.exe", "room", true)
            });
            piDictionary.Add("2", new List<PiData>()
            {
                new PiData("2", 22, "time.exe", "room", true)
            });
        }

        // GET: api/SensorsData
        [HttpGet]
        public Dictionary<string, List<PiData>> Get()
        {
            return piDictionary;
        }

        // GET: api/SensorsData/5
        [HttpGet("{id}", Name = "Get")]
        public Dictionary<string, List<PiData>> Get(string id)
        {
            Dictionary<string, List<PiData>> tempdic = new Dictionary<string, List<PiData>>();
            List<PiData> piitems = new List<PiData>();
            foreach(var item in piDictionary[id])
            {
                piitems.Add(item);
            }

            tempdic.Add(id, piitems);
            return tempdic;

        }

        // POST: api/SensorsData
        [HttpPost]
        public void Post([FromBody] List<PiData> obj)
        {

        }

        // PUT: api/SensorsData/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] List<PiData> obj)
        {

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            
        }
    }
}
