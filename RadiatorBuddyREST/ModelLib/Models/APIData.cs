using System;

namespace ModelLib.Models
{
    public class APIData
    {
        private double _temp;
        private int _cloudPercentage;
        private string _datetimeString;

        public APIData(double temp, int cloudPercentage, string datetimeString)
        {
            Temp = temp;
            CloudPercentage = cloudPercentage;
            DatetimeString = datetimeString;
        }


        public double Temp
        {
            get { return _temp; }
            set { _temp = value; }
        }

        public int CloudPercentage
        {
            get { return _cloudPercentage; }
            set { _cloudPercentage = value; }
        }

        public string DatetimeString
        {
            get { return _datetimeString; }
            set { _datetimeString = value; }
        }
    }
}
