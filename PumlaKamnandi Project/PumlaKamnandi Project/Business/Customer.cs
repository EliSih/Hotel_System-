using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PumlaKamnandi_Project.Business;


namespace PumlaKamnandi_Project.Data
{
    class Customer : Person
    {
        #region data field
        private string customerID;
        private string booking;
        private string room;
        private int accountNumber;
        private string PaymentType;
        private string description;
        private string balance;
        #endregion
        #region constructer

        public Customer() : base()
        {

            // GetPersonType = TypeOfPerson.PersonType.Customer;

        }
        #endregion
        #region accessor Methods
        public string Paymenttype
        {
            get { return PaymentType; }
            set { PaymentType = value; }
        }
        public string Balance
        {
            get { return balance; }
            set { balance = value; }
        }
        public string BookingID
        {
            get { return booking; }
            set { booking = value; }
        }
        public string CustomerRoomID
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
            set { accountNumber = value; }

        }

        #endregion

    }
}
