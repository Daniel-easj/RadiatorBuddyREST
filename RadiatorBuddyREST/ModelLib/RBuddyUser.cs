using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLib
{
    public class RBuddyUser
    {
        private string _userName;
        private string _password;
        private double _globalOptimalTemperature;
        private double _globalMinTemperature;
        private double _globalMaxTemperature;

        public RBuddyUser()
        {
            
        }
        public RBuddyUser(string userName, string password, double globalOptimalTemperature, double globalMinTemperature, double globalMaxTemperature)
        {
            UserName = userName;
            Password = password;
            GlobalOptimalTemperature = globalOptimalTemperature;
            GlobalMinTemperature = globalMinTemperature;
            GlobalMaxTemperature = globalMaxTemperature;
        }

        public string UserName { get => _userName; set => _userName = value; }
        public string Password { get => _password; set => _password = value; }
        public double GlobalOptimalTemperature { get => _globalOptimalTemperature; set => _globalOptimalTemperature = value; }
        public double GlobalMinTemperature { get => _globalMinTemperature; set => _globalMinTemperature = value; }
        public double GlobalMaxTemperature { get => _globalMaxTemperature; set => _globalMaxTemperature = value; }
    }
}
