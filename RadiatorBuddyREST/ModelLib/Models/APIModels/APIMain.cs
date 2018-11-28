using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLib.Models.APIModels
{
    public class APIMain
    {
        private double _temp;


        public APIMain(double temperature)
        {
            temp = temperature;
        }

        public APIMain()
        {
            
        }

        public double temp
        {
            get { return _temp; }
            set { _temp = value; }
        }
    }
}
