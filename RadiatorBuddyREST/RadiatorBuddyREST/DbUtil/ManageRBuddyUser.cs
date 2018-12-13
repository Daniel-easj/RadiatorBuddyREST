using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ModelLib;
using ModelLib.Models;

namespace RadiatorBuddyREST.DbUtil
{
    public class ManageRBuddyUser
    {
        //List objects
        private static List<RBuddyUser> userList = new List<RBuddyUser>();

        //DB instancefields
        private const string dbPass = "Rbuddy4067?";
        private string CONNECTIONSTRING =
            $"Server=tcp:db4490.database.windows.net,1433;Initial Catalog=MyDatabase;Persist Security Info=False;User ID=DanielB;Password={dbPass};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        //SQL Querystrings
        private string queryStringAll = "select * from RBuddyUser";

        private string updateSqlUser = "UPDATE RBuddyUser " + "SET Username = @Username, Password = @Password, GlobalOptimalTemperature = @GlobalOptimalTemperature, GlobalMinTemperature = @GlobalMinTemperature, GlobalMaxTemperature = @GlobalMaxTemperature"
                                       + " WHERE Username = @id";


        // Returner alt fra users
        public List<RBuddyUser> GetAllUserData()
        {
            userList.Clear();

            using (SqlConnection connection = new SqlConnection(CONNECTIONSTRING))
            {
                SqlCommand command = new SqlCommand(queryStringAll, connection);
                command.Connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string username = reader.GetString(1);
                    string password = reader.GetString(2);
                    double globalOptimalTemperature = reader.GetFloat(3);
                    double globalMinTemperature = reader.GetFloat(4);
                    double globalMaxTemperature = reader.GetFloat(5);

                    userList.Add(new RBuddyUser(username,password,globalOptimalTemperature,globalMinTemperature,globalMaxTemperature));
                }
            }
            return userList;
        }

        //Opdater user data
        public void UpdateRoomData(RBuddyUser user)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTIONSTRING))
            {
                SqlCommand command = new SqlCommand(updateSqlUser, connection);

                command.Parameters.AddWithValue("@Username", user.UserName);
                command.Parameters.AddWithValue("@Password", user.Password);
                command.Parameters.AddWithValue("@GlobalOptimalTemperature", user.GlobalOptimalTemperature);
                command.Parameters.AddWithValue("@GlobalMinTemperature", user.GlobalMinTemperature);
                command.Parameters.AddWithValue("@GlobalMaxTemperature", user.GlobalMaxTemperature);
                command.Parameters.AddWithValue("@id", user.UserName);

                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
