using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PumlaKamnandi_Project.Business
{
    class Booking
    {
        #region Data Members
        private string reservationID;
        private string checkInDate;
        private string checkOutDate;
        private string description;
        private decimal totalCost;
        #endregion

        #region Access Modifiers
        public string getReservationID
        {
            get { return reservationID; }
            set { reservationID = value; }
        }

        public string getCheckInDate
        {
            get { return checkInDate; }
            set { checkInDate = value; }
        }

        public string getCheckOutDate
        {
            get { return checkOutDate; }
            set { checkOutDate = value; }
        }

        public string getDescription
        {
            get { return description; }
            set { description = value; }
        }

        public decimal getTotalCost
        {
            get { return totalCost; }
            set { totalCost = value; }
        }
        #endregion

        #region Constructor
        public Booking(string checkInDate, string checkOutDate, string description)
        {
            this.checkInDate = checkInDate;
            this.checkOutDate = checkOutDate;
            this.description = description;
        }
        #endregion
    }
}
