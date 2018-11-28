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
        private string _timestamp;

        public PiData(string id, double temperature, string timestamp, string location, bool inDoor)
        {
            _id = id;
            _temperature = temperature;
            _timestamp = timestamp;
            _location = location;
            _inDoor = inDoor;
        }

        public PiData()
        {
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

        public string Timestamp
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
