using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PumlaKamnandi_Project.Business
{
    class Room
    {
        #region Data members
        private int roomNumber;
        private decimal price;
        private string description;
        private int capacity;
        string occupied; 
        #endregion

        #region Access Modifiers 
        public int RoomNumber
        {
            get { return roomNumber; }
            set { roomNumber = value; }
        }

        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }
        #endregion

        public string Occupied 
        {
            get { return occupied; }
            set { occupied = value; }
        }

        #region Constructor
        public Room()
        {

        }
        #endregion
    }
}
