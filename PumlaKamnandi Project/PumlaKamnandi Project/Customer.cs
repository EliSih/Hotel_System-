using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace PumlaKamnandi_Project.Data
{
    class Customer: Person
    {
        #region data field
        private string customerID;
        private Booking booking;
        private Room room;
        private int accountNumber;
        private string PaymentType;
        private string description;
        private string balance;
        #endregion
        #region constructer

        public Customer() : base() {

           // GetPersonType = TypeOfPerson.PersonType.Customer;

        }
        #endregion
        #region accessor Methods
        public string Paymenttype
        {
            get { return PaymentType; }
            set { PaymentType = value; }
        }
        public string Balance {
            get { return balance; }
            set { balance = value; }
        }
        public Booking CustomerBooking
        {
            get { return booking; }
            set { booking = value; }
        }
        public Room CustomerRoom
        {
            get { return room; }
            set { room = value; }
        }
        public string CustomerID
        {
            get { return customerID; }
            set { customerID = value; }
        } 
        public int AccountNumber
        {
            get { return accountNumber; }
            set { accountNumber =value;}
        
        }

        #endregion

    }
}
