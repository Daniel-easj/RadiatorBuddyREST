using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLib.Models
{
    public class QueryData
    {
        private string _timeFrom;
        private string _timeTo;

        public QueryData()
        {
            
        }

        public string TimeFrom
        {
            get { return _timeFrom; }
            set { _timeFrom = value; }
        }

        public string TimeTo
        {
            get { return _timeTo; }
            set { _timeTo = value; }
        }
    }
}
