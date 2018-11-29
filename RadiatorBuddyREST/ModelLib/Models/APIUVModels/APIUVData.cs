using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLib.Models.APIUVModels
{
    public class APIUVData
    {
        private string dateISO;
        private float uvValue;

        public APIUVData()
        {
            
        }

        public string date_iso
        {
            get { return dateISO; }
            set { dateISO = value; }
        }

        public float value
        {
            get { return uvValue; }
            set { uvValue = value; }
        }
    }
}
