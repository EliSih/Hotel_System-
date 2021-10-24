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
        private int ID;
        private string type;
        private string description;
        private string date;
        private decimal Amount;

        public int ID1 { get => ID; set => ID = value; }
        public string Type { get => type; set => type = value; }
        public string Description { get => description; set => description = value; }
        public string Date { get => date; set => date = value; }
        public decimal Amount1 { get => Amount; set => Amount = value; }
        #endregion

        #region Constructor 
        public Payment(String date)
        {
            this.Date = date;
        }
        public Payment()
        {
            this.Date = Date;
        }

        public Payment(int iD, string type, string description, string date, string amount)
        {
            ID1 = iD;
            this.Type = type;
            this.Description = description;
            this.Date = date;
            Amount1 = amount;
        }
        #endregion

        #region Methods (toString)
        public string toString()
        {
            return ID1.ToString() + " " + Type + " " + Description + " " + Date;
        }
        #endregion
    }
}
