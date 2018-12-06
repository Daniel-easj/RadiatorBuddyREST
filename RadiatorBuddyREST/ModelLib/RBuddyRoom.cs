using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLib
{
    public class RBuddyRoom
    {
        private string _macAddress;
        private string _location;
        private bool _inDoor;

        public RBuddyRoom()
        {
            
        }

        public RBuddyRoom(string macAddress, string location, bool inDoor)
        {
            _macAddress = macAddress;
            _location = location;
            _inDoor = inDoor;
        }

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
    }
}
