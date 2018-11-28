using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLib.Models
{
    public class Listelements
    {
        private List<PiData> piLists = new List<PiData>();
        private string id;

        public Listelements(string id)
        {
            this.id = id;
            
        }

        public Listelements()
        {
        }

        public List<PiData> PiLists
        {
            get => piLists;
            set => piLists = value;
        }

        public string Id
        {
            get => id;
            set => id = value;
        }
    }
}
