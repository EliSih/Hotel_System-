using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PumlaKamnandi_Project.Data
{
    class TypeOfPerson
    {

        public enum PersonType { 
            Customer,
            Employee
        }
        protected PersonType personType;
        #region Property Methods
        protected PersonType getPersonType
        {
            get { return personType; }
            set { personType = value; }
        
        }


        #endregion
        public TypeOfPerson() {
            personType = PersonType.Customer;
        }
        public PersonType GetPersonType {
            get { return personType; }
            set { personType = value; }
        }
    }
}
