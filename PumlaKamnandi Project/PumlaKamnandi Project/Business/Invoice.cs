using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PumlaKamnandi_Project.Business
{
    class Invoice
    {
        #region Data Members
        private string InvoiceID;
        private string description;
        private Payment payment;
        #endregion

        #region Access Modifiers
        public string getInvoiceDescription
        {
            get { return description; }
            set { description = value; }
        }
        #endregion

        #region 
        public string generateInvoice()
        {
            return payment.toString();
        }
        #endregion
    }
}
