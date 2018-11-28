using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLib.Models.APIModels
{
    public class APIClouds
    {
        private int _cloudPercentage;

        public APIClouds(int cloudPercentage)
        {
            all = cloudPercentage;
        }

        public APIClouds()
        {
            
        }

        public int all
        {
            get { return _cloudPercentage; }
            set { _cloudPercentage = value; }
        }
    }
}
