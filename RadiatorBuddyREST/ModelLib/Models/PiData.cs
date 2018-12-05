using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLib.Models
{
    public class PiData
    {
        private string _id;
        private double _temperature;
        private string _location;
        private bool _inDoor;
        private DateTime _timestamp;

        public PiData(string id, double temperature, DateTime timestamp, string location, bool inDoor)
        {
            _id = id;
            _temperature = temperature;
            _timestamp = timestamp;
            _location = location;
            _inDoor = inDoor;
        }

        public PiData(string id, double temperature, DateTime timestamp)
        {
            _id = id;
            _temperature = temperature;
            _timestamp = timestamp;
        }

        public PiData()
        {
        }

        // brugt af list.contains for at skelne i mellem objekter
        public override bool Equals(Object obj)
        {
            PiData other = (PiData) obj;
            return this.Id == other.Id;
        }

        public bool InDoor
        {
            get => _inDoor;
            set => _inDoor = value;
        }

        public string Location
        {
            get => _location;
            set => _location = value;
        }

        public double Temperature
        {
            get => _temperature;
            set => _temperature = value;
        }

        public DateTime Timestamp
        {
            get => _timestamp;
            set => _timestamp = value;
        }

        public string Id
        {
            get => _id;
            set => _id = value;
        }
    }
}
