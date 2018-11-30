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
                "Server=tcp:db4490.database.windows.net,1433;Initial Catalog=MyDatabase;Persist Security Info=False;User ID={your_username};Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        private string queryStringAll = "select * from PiData";
        private string queryStringId = "select * from PiData WHERE MacAddress = @MacAddress";
        private string insertSql = "insert into PiData (MacAddress, Location, Temperature, InDoor, TimeStamp) " +
                                   "Values (@MacAddress, @Location, @Temperature, @InDoor, @TimeStamp)";

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
                    int guestNr = reader.GetInt32(0);
                    string guestNavn = reader.GetString(1);
                    string guestAdr = reader.GetString(2);

                    string macAddress = reader.GetString(1);
                    string location = reader.GetString(2);
                    int temperature = reader.GetInt32(3);
                    bool inDoor = reader.GetBoolean(4);


                    piDataList.Add(new PiData());
                }
            }
            return piDataList;
        }

    }
}
