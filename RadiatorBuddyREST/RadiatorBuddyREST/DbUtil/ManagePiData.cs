using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ModelLib;
using ModelLib.Models;

namespace RadiatorBuddyREST.DbUtil
{
    public class ManagePiData
    {
        private static List<PiData> piDataList = new List<PiData>();
        private static List<RBuddyRoom> roomDataList = new List<RBuddyRoom>();

        //DB instancefields
        private const string dbPass = "Rbuddy4067?";
        private string CONNECTIONSTRING =
                $"Server=tcp:db4490.database.windows.net,1433;Initial Catalog=MyDatabase;Persist Security Info=False;User ID=DanielB;Password={dbPass};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        //PiData Query strings
        private string queryStringAll = "SELECT * from PiData order by Id asc";
        private string queryStringId = "SELECT * from PiData WHERE MacAddress = @MacAddress order by TimeStamp asc";
        private string insertSql = "INSERT into PiData (MacAddress, Location, Temperature, InDoor, TimeStamp) " +
                                   "VALUES (@MacAddress, @Location, @Temperature, @InDoor, @TimeStamp)";
        private string deleteSqlResetAllPiData = "DELETE FROM PiData";
        
        //RBuddyRoom Query strings
        private string queryStringAllRoom = "SELECT * from RBuddyRoom";
        private string insertSqlRoom = "INSERT into RBuddyRoom (MacAddress, Location, InDoor, OptimalTemperature, MinTemperature, MaxTemperature) " +
                                   "VALUES (@MacAddress, @Location, @InDoor, @OptimalTemperature, @MinTemperature, @MaxTemperature)";
        private string updateSqlRoom = "UPDATE RBuddyRoom " + "SET MacAddress = @MacAddress, Location = @Location, InDoor = @InDoor, OptimalTemperature = @OptimalTemperature, MinTemperature = @MinTemperature, MaxTemperature = @MaxTemperature"
                                        + " WHERE MacAddress = @id";
        private string deleteSqlRoom = "DELETE FROM RBuddyRoom WHERE MacAddress = @id";


        //
        // PIDATA:
        //

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
                    double temperature = reader.GetFloat(3);
                    bool inDoor = reader.GetBoolean(4);
                    DateTime timeStamp = reader.GetDateTime(5);


                    piDataList.Add(new PiData(macAddress.Replace(" ", ""), temperature,timeStamp,location,inDoor));
                }
            }
            return piDataList;
        }

        

        // Returner piData fra given periode til slut periode
        public List<PiData> GetPiDataFromPeriod(string queryString)
        {
            piDataList.Clear();

            using (SqlConnection connection = new SqlConnection(CONNECTIONSTRING))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    string macAddress = reader.GetString(1);
                    string location = reader.GetString(2);
                    double temperature = reader.GetFloat(3);
                    bool inDoor = reader.GetBoolean(4);
                    DateTime timeStamp = reader.GetDateTime(5);


                    piDataList.Add(new PiData(macAddress.Replace(" ",""),temperature,timeStamp,location,inDoor));
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
                        double temperature = reader.GetFloat(3);
                        bool inDoor = reader.GetBoolean(4);
                        DateTime timeStamp = reader.GetDateTime(5);

                        piDataList.Add(new PiData(macAddress, temperature, timeStamp,location,inDoor));
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
                command.Parameters.AddWithValue("@Location", piData.Location ?? "");
                command.Parameters.AddWithValue("@Temperature", piData.Temperature);
                command.Parameters.AddWithValue("@InDoor", piData.InDoor);
                command.Parameters.AddWithValue("@TimeStamp", piData.Timestamp);

                command.Connection.Open();
                command.ExecuteNonQuery();

            }
        }

        public void ResetPiDataTable()
        {
            using (SqlConnection connection = new SqlConnection(CONNECTIONSTRING))
            {
                SqlCommand command = new SqlCommand(deleteSqlResetAllPiData, connection);


                command.Connection.Open();
                command.ExecuteNonQuery();

            }
        }

        //
        // RUMDATA:
        //

        // Returner alt data fra alle rum
        public List<RBuddyRoom> GetAllRoomData()
        {
            roomDataList.Clear();

            using (SqlConnection connection = new SqlConnection(CONNECTIONSTRING))
            {
                SqlCommand command = new SqlCommand(queryStringAllRoom, connection);
                command.Connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    string macAddress = reader.GetString(0);
                    string location = reader.GetString(1);
                    bool inDoor = reader.GetBoolean(2);
                    double optimalTemperature = reader.GetFloat(3);
                    double minTemperature = reader.GetFloat(4);
                    double maxTemperature = reader.GetFloat(5);



                    roomDataList.Add(new RBuddyRoom(macAddress.Replace(" ", ""),location,inDoor, optimalTemperature, minTemperature,maxTemperature));
                }
            }
            return roomDataList;
        }

        // Opret rum til database
        public void CreateRoomData(RBuddyRoom room)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTIONSTRING))
            {
                SqlCommand command = new SqlCommand(insertSqlRoom, connection);

                command.Parameters.AddWithValue("@MacAddress", room.MacAddress);
                command.Parameters.AddWithValue("@Location", room.Location);
                command.Parameters.AddWithValue("@InDoor", room.InDoor);
                command.Parameters.AddWithValue("@OptimalTemperature", room.OptimalTemperature);
                command.Parameters.AddWithValue("@MinTemperature", room.MinTemperature);
                command.Parameters.AddWithValue("@MaxTemperature", room.MaxTemperature);

                command.Connection.Open();

                command.ExecuteNonQuery();

            }
        }

        //Opdater rum data
        public void UpdateRoomData(RBuddyRoom room)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTIONSTRING))
            {
                SqlCommand command = new SqlCommand(updateSqlRoom, connection);

                command.Parameters.AddWithValue("@MacAddress", room.MacAddress);
                command.Parameters.AddWithValue("@Location", room.Location);
                command.Parameters.AddWithValue("@InDoor", room.InDoor);
                command.Parameters.AddWithValue("@OptimalTemperature", room.OptimalTemperature);
                command.Parameters.AddWithValue("@MinTemperature", room.MinTemperature);
                command.Parameters.AddWithValue("@MaxTemperature", room.MaxTemperature);
                command.Parameters.AddWithValue("@id", room.MacAddress);

                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

        //Fjern et rum fra Database
        public void DeleteRoomData(RBuddyRoom room)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTIONSTRING))
            {
                SqlCommand command = new SqlCommand(deleteSqlRoom, connection);

                command.Parameters.AddWithValue("@id", room.MacAddress);

                command.Connection.Open();
                command.ExecuteNonQuery();

            }
        }


    }
}
