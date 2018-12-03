using System;

namespace ModelLib.Models.APIModels
{
    public class APIData
    {
        private APIMain apiMain;
        private APIClouds apiClouds;
        private string apitext;
        private int timeDataUnix;

        public APIData()
        {
            
        }

        public APIData(APIMain apiMain, APIClouds apiClouds, string apitext)
        {
            this.apiMain = apiMain;
            this.apiClouds = apiClouds;
            this.apitext = apitext;
        }

        public APIMain main
        {
            get { return apiMain; }
            set { apiMain = value; }
        }


        public string dt_txt
        {
            get { return apitext; }
            set { apitext = value; }
        }

        public APIClouds clouds
        {
            get { return apiClouds; }
            set { apiClouds = value; }
        }

        public int dt
        {
            get { return timeDataUnix; }
            set { timeDataUnix = value; }
        }
    }
}
