using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PumlaKamnandi_Project.Business
{
    class Booking: object
    {
        #region Data Members
        private int reservationID;
        private string checkInDate;
        private string checkOutDate;
        private string description;
        private decimal totalCost;
        private int employeeID;
        private int roomNumber;
        private string customerID;
        private string customer;
        #endregion

        #region Constructor
        public Booking(int reservationID, string checkInDate, string checkOutDate, string description, decimal totalCost)
        {
            this.reservationID = reservationID;
            this.checkInDate = checkInDate;
            this.checkOutDate = checkOutDate;
            this.description = description;
            this.totalCost = totalCost;
        }

        public Booking()
        {

        }
        #endregion

        #region Access Modifiers
        public string CustomerID 
        {
            get { return customerID; }
            set { customerID = value; }
        }

        public int ReservationID
        {
            get { return reservationID; }
            set { reservationID = value; }
        }

        public string CheckInDate
        {
            get { return checkInDate; }
            set { checkInDate = value; }
        }

        public string CheckOutDate
        {
            get { return checkOutDate; }
            set { checkOutDate = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public decimal TotalCost
        {
            get { return totalCost; }
            set { totalCost = value; }
        }

        public int RoomNumber
        {
            get { return roomNumber; }
            set { roomNumber = value; }
        }

        public int EmployeeID
        {
            get { return employeeID; }
            set { employeeID = value; }
        }
        #endregion


    }
}
