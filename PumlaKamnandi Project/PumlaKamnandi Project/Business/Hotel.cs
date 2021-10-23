using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PumlaKamnandi_Project.Business
{
    class Hotel
    {
        #region fields
        private int hotelID;
        private string location;
        private string contactDetails;
        #endregion

        #region contructor
        public Hotel()
        {

        }
        #endregion 

        #region methods 
        public int HotelID
        {
            get { return hotelID; }
            set { hotelID = value; }
        }

        public string Location
        {
            get { return location;  }
            set { location = value; }
        }

        public string ContactDetails
        {
            get { return contactDetails; }
            set { contactDetails = value; }
        }
        #endregion 
    }
}
