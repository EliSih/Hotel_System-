using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PumlaKamnandi_Project.Data
{

    public class Person
    {


        #region data members
        private string Id, name, Phone, address, emailaddress;
        #endregion

        #region Properties
        public string ID
        {
            get { return Id; }
            set { Id = value; }
        }
        public string EmailAddress
        {
            get { return emailaddress; }
            set { emailaddress = value; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Telephone
        {
            get { return Phone; }
            set { Phone = value; }
        }
        #endregion

        #region Construtor
        public Person()
        {
            Id = "";
            name = "";
            Phone = "";
            emailaddress = "";
            address = "";
        }

        public Person(string pID, string pName, string pPhone, string pEmailAddress, string pAddress)
        {
            Id = pID;
            name = pName;
            Phone = pPhone;
            address = pAddress;
            emailaddress = pEmailAddress;

        }
        #endregion

        #region ToStringMethod
        public override string ToString()
        {
            return name + '\n' + Phone;
        }

        #endregion
    }

}
