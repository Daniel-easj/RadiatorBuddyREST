using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLib.Models
{
    class Listelements
    {
        private List<PiData> piList = new List<PiData>();
        private int id;

        public Listelements(int id)
        {
            this.id = id;
        }

        public Listelements()
        {
        }

        public List<PiData> PiList
        {
            get => piList;
            set => piList = value;
        }

        public int Id
        {
            get => id;
            set => id = value;
        }
    }
}
