﻿using System;
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
        private int paymentID;
        #endregion


        #region Access Modifiers
        public string getInvoiceDescription
        {
            get { return Description; }
            set { Description = value; }
        }

        public string InvoiceID1 { get => InvoiceID; set => InvoiceID = value; }
        public string Description { get => description; set => description = value; }
        internal int Payment { get => paymentID; set => paymentID = value; }
        #endregion

        #region 
        public string generateInvoice()
        {
            return Payment.toString();
        }
        #endregion
    }
}
