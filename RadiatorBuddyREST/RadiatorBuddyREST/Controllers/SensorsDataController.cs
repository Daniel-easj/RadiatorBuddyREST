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
using ModelLib;
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

        //
        // SENSORDATA:
        //

        // GET: api/SensorsData
        [HttpGet]
        public List<PiData> GetSensorData([FromQuery] QueryData qData)
        {
            StringBuilder queryString = new StringBuilder();
            queryString.Append(baseQueryString);

            if (ModelState.IsValid)
            {
                // Hvis variablerne i qData er null må det betyde at der ikke er givet nogle parametre i uri - og så returneres alt pidata
                if (qData.TimeFrom == null && qData.TimeTo == null)
                {
                    return piDataManager.GetAllPiData();
                }

                queryString.Append(" WHERE");

                // Filtrering af data baseret på tidspunkt
                // Eksempel: https://radiatorbuddy.azurewebsites.net/api/sensorsdata?timefrom=2018-03-12%2013:00:00&timeto=2018-03-12%2013:16:00
                if (qData.TimeFrom != null && qData.TimeTo != null)
                {

                    queryString.Append($" TimeStamp Between '{qData.TimeFrom}' AND '{qData.TimeTo}'");

                    return piDataManager.GetPiDataFromPeriod(queryString.ToString());
                }

                if (qData.TimeFrom == null && qData.TimeTo != null)
                {
                    queryString.Append($" TimeStamp Between '{qData.TimeFrom}' AND '{DateTime.Now}'");

                    return piDataManager.GetPiDataFromPeriod(queryString.ToString());
                }

                if (qData.TimeFrom != null && qData.TimeTo == null)
                {
                    queryString.Append($" TimeStamp Between '{DateTime.Now.Subtract(TimeSpan.MaxValue)}' AND '{qData.TimeTo}'");

                    return piDataManager.GetPiDataFromPeriod(queryString.ToString());
                }
            }
            



            return null;
        }

        // GET: api/SensorsData/id
        [HttpGet("{id}")]
        public List<PiData> GetOneSensorData([FromQuery] string macAddress)
        {
            return piDataManager.GetSpecificPiSensorData(macAddress.TrimEnd());
        }

        // POST: api/SensorsData
        [HttpPost]
        public void Post([FromBody] PiData obj)
        {
            if (ModelState.IsValid)
            {
                piDataManager.CreatePiData(obj);
            }
        }

        // Reset PiData table: api/SensorsData/resetdata
        [HttpDelete]
        [Route("resetdata")]
        public void ResetPiDataTable()
        {
            piDataManager.ResetPiDataTable();
        }

        //
        // ROOMDATA
        //

        //Get data from all rooms
        [HttpGet]
        [Route("rooms")]
        public List<RBuddyRoom> GetRoomData()
        {
            return piDataManager.GetAllRoomData();
        }

        //Create a room
        [HttpPost]
        [Route("rooms")]
        public void CreateRoomData(RBuddyRoom room)
        {

                piDataManager.CreateRoomData(room);
       
        }

        //Update room
        [HttpPut]
        [Route("rooms")]
        public void UpdateRoomData(RBuddyRoom room)
        {
            piDataManager.UpdateRoomData(room);
        }

        //Delete room
        [HttpDelete]
        [Route("rooms")]
        public void DeleteRoomData(RBuddyRoom room)
        {
            piDataManager.DeleteRoomData(room);
        }

    }
}
