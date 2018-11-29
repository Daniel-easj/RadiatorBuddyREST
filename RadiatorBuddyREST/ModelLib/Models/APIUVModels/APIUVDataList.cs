using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLib.Models.APIUVModels
{
    public class APIUVDataList
    {
        private IEnumerable<APIUVData> apiuvData;
        private APIUVData[] apiUvDataArray;

        public APIUVDataList(IEnumerable<APIUVData> apiuvData)
        {
            this.ApiuvData = apiuvData;
        }

        public APIUVDataList()
        {
            
        }

        public IEnumerable<APIUVData> ApiuvData
        {
            get { return apiuvData; }
            set { apiuvData = value; }
        }

        public APIUVData[] ApiUvDataArray
        {
            get { return apiUvDataArray; }
            set { apiUvDataArray = value; }
        }
    }
}
