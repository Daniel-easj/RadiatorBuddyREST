using System;

namespace ModelLib.Models.APIModels
{
    public class APIData
    {
        private APIMain apiMain;
        private APIClouds apiClouds;
        private string apitext;

        public APIData()
        {
            
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
    }
}
