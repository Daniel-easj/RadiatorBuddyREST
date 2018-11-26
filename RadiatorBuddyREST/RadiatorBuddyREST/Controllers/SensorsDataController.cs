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

        private static List<PiData> piList = new List<PiData>()
        {
            new PiData(1,20,15,DateTime.Now)
        };

        // GET: api/SensorsData
        [HttpGet]
        public List<PiData> Get()
        {
            return piList;
        }

        // GET: api/SensorsData/5
        [HttpGet("{id}", Name = "Get")]
        public PiData Get(int id)
        {
            return piList.Find(i => i.Id == id);
        }

        // POST: api/SensorsData
        [HttpPost]
        public void Post([FromBody] PiData obj)
        {
            obj.Id = piList.Count() + 1;
            obj.OutTemp = obj.InTemp - 2;
            obj.DateTime = DateTime.Now;
            piList.Add(obj);
        }

        // PUT: api/SensorsData/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] PiData obj)
        {
            obj.Id = id;
            piList.Remove(piList.Find(i => i.Id == id));
            obj.DateTime = DateTime.Now;
            piList.Add(obj);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            piList.Remove(piList.Find(i => i.Id == id));
        }
    }
}
