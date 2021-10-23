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
        #endregion

        #region Access Modifiers 
        public int getRoomNumber
        {
            get { return roomNumber; }
            set { roomNumber = value; }
        }

        public decimal getPrice
        {
            get { return price; }
            set { price = value; }
        }

        public string getDescription
        {
            get { return description; }
            set { description = value; }
        }

        public int getCapacity
        {
            get { return capacity; }
            set { capacity = value; }
        }
        #endregion

        #region Constructor
        public Room()
        {

        }
        #endregion
    }
}
