using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ModelLib.Models;

namespace RadiatorBuddyREST.DbUtil
{
    public class ManagePiData
    {
        private static List<PiData> piDataList = new List<PiData>(); 
        private const string CONNECTIONSTRING =
                "Server=tcp:db4490.database.windows.net,1433;Initial Catalog=MyDatabase;Persist Security Info=False;User ID=DanielB;Password=;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        private string queryStringAll = "select * from PiData";
        private string queryStringId = "select * from PiData WHERE MacAddress = @MacAddress";
        private string insertSql = "insert into PiData (MacAddress, Location, Temperature, InDoor, TimeStamp) " +
                                   "Values (@MacAddress, @Location, @Temperature, @InDoor, @TimeStamp)";


        // Returner alt Data fra Pi sensorerne
        public List<PiData> GetAllPiData()
        {
            piDataList.Clear();

            using (SqlConnection connection = new SqlConnection(CONNECTIONSTRING))
            {
                SqlCommand command = new SqlCommand(queryStringAll, connection);
                command.Connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                  
                    string macAddress = reader.GetString(1);
                    string location = reader.GetString(2);
                    int temperature = reader.GetInt32(3);
                    bool inDoor = reader.GetBoolean(4);
                    DateTime timeStamp = reader.GetDateTime(5);


                    piDataList.Add(new PiData(macAddress, temperature,timeStamp,location,inDoor));
                }
            }
            return piDataList;
        }

        // Henter al data fra en specific PiSensor bestemt af dens MacAdresse. Da en PiSensor typisk har målt data flere gange vil der returneres en liste af PiData
        public List<PiData> GetSpecificPiSensorData(string macAddressId)
        {

            piDataList.Clear();
            using (SqlConnection connection = new SqlConnection(CONNECTIONSTRING))
            {
                SqlCommand command = new SqlCommand(queryStringId, connection);
                command.Parameters.AddWithValue("@MacAddress", macAddressId);

                command.Connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    while (reader.Read())
                    {
                        string macAddress = reader.GetString(1);
                        string location = reader.GetString(2);
                        int temperature = reader.GetInt32(3);
                        bool inDoor = reader.GetBoolean(4);
                        DateTime timeStamp = reader.GetDateTime(5);

                        piDataList.Add(new PiData(macAddress, temperature, timeStamp, location, inDoor));
                    }

                    return piDataList;
                }

            }


            return null;
        }


        // Tilføj ny PiData til Database
        public void CreatePiData(PiData piData)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTIONSTRING))
            {
                SqlCommand command = new SqlCommand(insertSql, connection);

                command.Parameters.AddWithValue("@MacAddress", piData.Id);
                command.Parameters.AddWithValue("@Location", piData.Location);
                command.Parameters.AddWithValue("@Temperature", piData.Temperature);
                command.Parameters.AddWithValue("@InDoor", piData.InDoor);
                command.Parameters.AddWithValue("@TimeStamp", piData.Timestamp);


                command.Connection.Open();

                command.ExecuteNonQuery();

            }
        }

    }
}
