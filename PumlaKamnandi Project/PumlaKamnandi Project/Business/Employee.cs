using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PumlaKamnandi_Project.Data
{
    class Employee : Person
    {
        #region data fields
        private string employeeID;
        #endregion
        #region method
        public string EmployeeID
        {
            get { return employeeID; }
            set { employeeID = value; }
        }
        //public Employee() { }
        #endregion
    }
}
