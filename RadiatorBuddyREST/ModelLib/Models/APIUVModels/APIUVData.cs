using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLib.Models.APIUVModels
{
    public class APIUVData
    {
        private string dateISO;
        private double uvValue;

        public APIUVData()
        {
            
        }

        public APIUVData(double uvValue)
        {
            this.uvValue = uvValue;
        }

        public string date_iso
        {
            get { return dateISO; }
            set { dateISO = value; }
        }

        public double value
        {
            get { return uvValue; }
            set { uvValue = value; }
        }
    }
}
