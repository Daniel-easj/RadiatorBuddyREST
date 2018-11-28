using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLib.Models.APIModels
{
    public class APIDataList
    {
        private IEnumerable<APIData> _apiDataList;

        public APIDataList(IEnumerable<APIData> apiDataList)
        {
            list = apiDataList;
        }

        public APIDataList()
        {
        }


        public IEnumerable<APIData> list
        {
            get { return _apiDataList; }
            set { _apiDataList = value; }
        }

    }
}
