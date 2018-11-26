using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLib.Models
{
    public class PiData
    {
        private int _id;
        private double _inTemp;
        private double _OutTemp;
        private DateTime _dateTime;

        public PiData(int id, double inTemp, double outTemp, DateTime dateTime)
        {
            _id = id;
            _inTemp = inTemp;
            _OutTemp = outTemp;
            _dateTime = dateTime;
        }

        public PiData()
        {
        }

        public double InTemp
        {
            get => _inTemp;
            set => _inTemp = value;
        }

        public double OutTemp
        {
            get => _OutTemp;
            set => _OutTemp = value;
        }

        public DateTime DateTime
        {
            get => _dateTime;
            set => _dateTime = value;
        }

        public int Id
        {
            get => _id;
            set => _id = value;
        }
    }
}
