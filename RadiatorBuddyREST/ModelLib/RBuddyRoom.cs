using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ModelLib
{
    public class RBuddyRoom
    {
        private string _macAddress;
        private string _location;
        private bool _inDoor;
        private double _optimalTemperature;
        private double _minTemperature;
        private double _maxTemperature;

        public RBuddyRoom()
        {
        }

        public RBuddyRoom(string macAddress, string location, bool inDoor, double optimalTemperature, double minTemperature, double maxTemperature)
        {
            _macAddress = macAddress;
            _location = location;
            _inDoor = inDoor;
            OptimalTemperature = optimalTemperature;
            MinTemperature = minTemperature;
            MaxTemperature = maxTemperature;
        }

        [Required, StringLength(17, MinimumLength = 17)]
        public string MacAddress
        {
            get { return _macAddress; }
            set { _macAddress = value; }
        }

        public string Location
        {
            get { return _location; }
            set { _location = value; }
        }

        public bool InDoor
        {
            get { return _inDoor; }
            set { _inDoor = value; }
        }

        public double OptimalTemperature
        {
            get { return _optimalTemperature; }
            set { _optimalTemperature = value; }
        }

        public double MinTemperature
        {
            get { return _minTemperature; }
            set { _minTemperature = value; }
        }

        public double MaxTemperature
        {
            get { return _maxTemperature; }
            set { _maxTemperature = value; }
        }
    }
}
