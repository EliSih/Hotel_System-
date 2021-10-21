using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PumlaKamnandi_Project.Data
{
    class Employee: Person
    {
        #region data fields
        private string EmployeeID;
        #endregion
        #region method
        public string getEmployeeID
        {
            get { return EmployeeID; }
            set { EmployeeID = value; }
        }
        //public Employee() { }
        #endregion
    }
}
