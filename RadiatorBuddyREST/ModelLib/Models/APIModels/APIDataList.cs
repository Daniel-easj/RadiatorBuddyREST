using System;
using System.Collections.Generic;
using System.Text;
using ModelLib.Models.APIUVModels;

namespace ModelLib.Models.APIModels
{
    public class APIDataList
    {
        private IEnumerable<APIData> _apiDataList;
        private static IEnumerable<APIUVData> _apiUvDataList;

        public APIDataList(IEnumerable<APIData> apiDataList, IEnumerable<APIUVData> apiUvDataList)
        {
            list = apiDataList;
            ApiUvDataList = apiUvDataList;
        }

        public APIDataList()
        {
        }


        public IEnumerable<APIData> list
        {
            get { return _apiDataList; }
            set { _apiDataList = value; }
        }

        public IEnumerable<APIUVData> ApiUvDataList
        {
            get { return _apiUvDataList; }
            set { _apiUvDataList = value; }
        }

    }
}
