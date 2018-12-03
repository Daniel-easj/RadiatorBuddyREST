using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ModelLib.Models;
using ModelLib.Models.APIModels;
using ModelLib.Models.APIUVModels;

namespace RadiatorBuddyREST.DbUtil
{
    public class ManageWeatherAPI
    {
        private static List<APIData> apiData = new List<APIData>();
        private static APIDataList apiDataList = new APIDataList();
        private static List<APIUVData> apiUvData = new List<APIUVData>();
        private const string CONNECTIONSTRING =
            "Server=tcp:db4490.database.windows.net,1433;Initial Catalog=MyDatabase;Persist Security Info=False;User ID=DanielB;Password=Rbuddy2980?;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        private string queryStringAll = "select * from WeatherAPI";

        // Returner alt Data fra WeatherAPI Database
        public List<APIData> GetAllPiData()
        {
            apiData.Clear();

            using (SqlConnection connection = new SqlConnection(CONNECTIONSTRING))
            {
                SqlCommand command = new SqlCommand(queryStringAll, connection);
                command.Connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    double temperature = reader.GetFloat(1);
                    int cloudPercentage = reader.GetInt32(2);
                    double uvIndex = reader.GetFloat(3);
                    DateTime timeStamp = reader.GetDateTime(4);
                        


                    apiData.Add(new APIData(new APIMain(temperature), new APIClouds(cloudPercentage), timeStamp.ToString()));
                    apiUvData.Add(new APIUVData(uvIndex));
                }
            }
            apiDataList.list = apiData;
            apiDataList.ApiUvDataList = apiUvData;
            return apiDataList.list as List<APIData>;
        }
    }
}
