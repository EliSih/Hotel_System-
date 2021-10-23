using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PumlaKamnandi_Project.Business
{
    class Payment
    {
        #region Data Members
        public int ID;
        public string type;
        public string description;
        public string date;
        #endregion

        #region Constructor 
        public Payment(String date)
        {
            this.date = date;
        }
        #endregion

        #region Methods (toString)
        public string toString()
        {
            return ID.ToString() + " " + type + " " + description + " " + date;
        }
        #endregion
    }
}
