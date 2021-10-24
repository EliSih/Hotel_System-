using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using PumlaKamnandi_Project.Data;

namespace PumlaKamnandi_Project.Business
{
    class CustomerController
    {
        #region Data Members
        PhumlaKamnandiDatabase phumlaKamnandiDB;
        private Collection<Customer> customers;
        private Collection<Employee> employees;
        private Collection<Invoice> invoices;
        private Collection<Hotel> hotels;
        private Collection<Payment> payments;
        private Collection<Room> rooms;
        private Collection<Booking> bookings;
        #endregion

        #region Properties
        

        internal Collection<Customer> Customers { get => customers; set => customers = value; }
        internal Collection<Employee> Employees { get => employees; set => employees = value; }
        internal Collection<Invoice> Invoices { get => invoices; set => invoices = value; }
        internal Collection<Hotel> Hotels { get => hotels; set => hotels = value; }
        internal Collection<Payment> Payments { get => payments; set => payments = value; }
        internal Collection<Room> Rooms { get => rooms; set => rooms = value; }
        internal Collection<Booking> Bookings { get => bookings; set => bookings = value; }
        #endregion

        #region Constructor
        public CustomerController()
        {
            phumlaKamnandiDB = new PhumlaKamnandiDatabase();
            this.customers = phumlaKamnandiDB.Customers;
            this.employees = phumlaKamnandiDB.AllEmployees;
            this.invoices = phumlaKamnandiDB.Invoices;
            this.hotels = phumlaKamnandiDB.Hotels;
            this.payments = phumlaKamnandiDB.Payments;
            this.rooms = phumlaKamnandiDB.Rooms;
            this.bookings = phumlaKamnandiDB.Bookings;
        }
        #endregion

        #region Database Communication.
        public void DataMaintenance(object obj, DataBase.DBOperation operation, string table)
        {
            int index = 0;
            phumlaKamnandiDB.DataSetChange(obj, operation,table);
            //employees.Add(anEmp);
            switch (operation)
            {
                case DataBase.DBOperation.Add:
                    switch (table)
                    {
                        case "Booking":
                            bookings.Add(obj as Booking);
                            break;


                        case "Customer":
                            customers.Add(obj as Customer);
                            break;
                        case "Employee":
                            employees.Add(obj as Employee);
                            break;
                        case "Room":
                            rooms.Add(obj as Room);
                            break;
                        case "Payment":
                            payments.Add(obj as Payment);
                            break;
                        case "Invoice":
                            invoices.Add(obj as Invoice);
                            break;
                        case "Hotel":
                            hotels.Add(obj as Hotel);
                            break;
                    }
                    break;
                case DataBase.DBOperation.Edit:
                    index = FindIndex(obj, table);
                    switch (table)
                    {
                        case "Booking":
                            bookings[index] = obj as Booking;
                            break;


                        case "Customer":
                            customers[index] = obj as Customer;
                            break;
                        case "Employee":
                            employees[index] = obj as Employee;
                            break;
                        case "Room":
                            rooms[index] = obj as Room;
                            break;
                        case "Payment":
                            payments[index] = obj as Payment;
                            break;
                        case "Invoice":
                            invoices[index] = obj as Invoice;
                            break;
                        case "Hotel":
                            hotels[index] = obj as Hotel;
                            break;
                    }
                    break;
                case DataBase.DBOperation.Delete:
                    index = FindIndex(obj, table);
                    if (index < 0) return;
                    switch (table)
                    {
                        case "Booking":
                            bookings.RemoveAt(index);
                            break;
                        case "Customer":
                            customers.RemoveAt(index);
                            break;
                        case "Employee":
                            employees.RemoveAt(index);
                            break;
                        case "Room":
                            rooms.RemoveAt(index);
                            break;
                        case "Payment":
                            payments.RemoveAt(index);
                            break;
                        case "Invoice":
                            invoices.RemoveAt(index);
                            break;
                        case "Hotel":
                            hotels.RemoveAt(index);
                            break;
                    }
                    break;
            }
        }

        //***Commit the changes to the database
        public bool FinalizeChanges(object obj,string table)
        {
            return phumlaKamnandiDB.UpdateDataSource(obj,table);
        }
        #endregion

        #region Searching through a collection
        public int FindIndex(object obj, string table)
        {
            
            int counter = 0;
            bool found = false;
            switch (table)
            {
                case "Booking":
                    Booking booking = obj as Booking;
                    found = (booking.ReservationID == bookings[counter].ReservationID);
                    while (!found)
                    {
                        counter++;

                        if (bookings.Count <= counter)
                        {
                            //MessageBox.Show("Employee: " + anEmp.ID + " was not found!", "Collection searching", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return -1;
                        }
                        else
                        {
                            found = (booking.ReservationID == bookings[counter].ReservationID);
                        }

                    }
                    if (found)
                    {
                        return counter;
                    }
                    else
                    {
                        return -1;
                    }
                    break;
                case "Customer":
                    Customer customer = obj as Customer;
                    found = (customer.CustomerID == customers[counter].CustomerID);
                    while (!found)
                    {
                        counter++;

                        if (customers.Count <= counter)
                        {
                            //MessageBox.Show("Employee: " + anEmp.ID + " was not found!", "Collection searching", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return -1;
                        }
                        else
                        {
                            found = (customer.CustomerID == customers[counter].CustomerID);
                        }

                    }
                    if (found)
                    {
                        return counter;
                    }
                    else
                    {
                        return -1;
                    }
                    break;
                case "Employee":
                    Employee employee = obj as Employee;
                    found = (employee.getEmployeeID == employees[counter].getEmployeeID);
                    while (!found)
                    {
                        counter++;

                        if (employees.Count <= counter)
                        {
                            //MessageBox.Show("Employee: " + anEmp.ID + " was not found!", "Collection searching", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return -1;
                        }
                        else
                        {
                            found = (employee.getEmployeeID == employees[counter].getEmployeeID);
                        }

                    }
                    if (found)
                    {
                        return counter;
                    }
                    else
                    {
                        return -1;
                    }
                    break;
                case "Room":
                    Room room = obj as Room;
                    found = (room.getRoomNumber == rooms[counter].getRoomNumber);
                    while (!found)
                    {
                        counter++;

                        if (rooms.Count <= counter)
                        {
                            //MessageBox.Show("Employee: " + anEmp.ID + " was not found!", "Collection searching", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return -1;
                        }
                        else
                        {
                            found = (room.getRoomNumber == rooms[counter].getRoomNumber);
                        }

                    }
                    if (found)
                    {
                        return counter;
                    }
                    else
                    {
                        return -1;
                    }
                    break;
                case "Payment":
                    Payment payment = obj as Payment;
                    found = (payment.ID1 == payments[counter].ID1);
                    while (!found)
                    {
                        counter++;

                        if (payments.Count <= counter)
                        {
                            //MessageBox.Show("Employee: " + anEmp.ID + " was not found!", "Collection searching", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return -1;
                        }
                        else
                        {
                            found = (payment.ID1 == payments[counter].ID1);
                        }

                    }
                    if (found)
                    {
                        return counter;
                    }
                    else
                    {
                        return -1;
                    }
                    break;
                case "Invoice":
                    Invoice invoice = obj as Invoice;
                    found = (invoice.InvoiceID1 == invoices[counter].InvoiceID1);
                    while (!found)
                    {
                        counter++;

                        if (invoices.Count <= counter)
                        {
                            //MessageBox.Show("Employee: " + anEmp.ID + " was not found!", "Collection searching", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return -1;
                        }
                        else
                        {
                            found = (invoice.InvoiceID1 == invoices[counter].InvoiceID1);
                        }

                    }
                    if (found)
                    {
                        return counter;
                    }
                    else
                    {
                        return -1;
                    }
                    break;
                case "Hotel":
                    Hotel hotel = obj as Hotel;
                    found = (hotel.HotelID == hotels[counter].HotelID); 
                    while (!found)
                    {
                        counter++;

                        if (hotels.Count <= counter)
                        {
                            //MessageBox.Show("Employee: " + anEmp.ID + " was not found!", "Collection searching", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return -1;
                        }
                        else
                        {
                            found = (hotel.HotelID == hotels[counter].HotelID);
                        }

                    }
                    if (found)
                    {
                        return counter;
                    }
                    else
                    {
                        return -1;
                    }
                    break;
            }
            return counter;
        }
        /*public Collection<Employee> FindByRole(Collection<Employee> emps, Role.RoleType roleVal)
        {
            Collection<Employee> matches = new Collection<Employee>();
            foreach (Employee emp in emps)
            {
                if (emp.role.getRoleValue == roleVal)
                {
                    matches.Add(emp);
                }
            }
            return matches;
        }*/

        //This method receives a employee ID as a parameter; finds the employee object in the collection of employees and then returns this object
        public object Find(object obj,string table)
        {
            int counter = 0;
            bool found = false;
            switch (table)
            {
                case "Booking":
                    Booking booking = obj as Booking;
                    found = (booking.ReservationID == bookings[counter].ReservationID);
                    while (!found)
                    {
                        counter++;

                        if (bookings.Count <= counter)
                        {
                            //MessageBox.Show("Employee: " + anEmp.ID + " was not found!", "Collection searching", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return -1;
                        }
                        else
                        {
                            found = (booking.ReservationID == bookings[counter].ReservationID);
                        }

                    }
                    if (found)
                    {
                        return bookings[counter];
                    }
                    else
                    {
                        return null;
                    }
                    break;
                case "Customer":
                    Customer customer = obj as Customer;
                    found = (customer.CustomerID == customers[counter].CustomerID);
                    while (!found)
                    {
                        counter++;

                        if (customers.Count <= counter)
                        {
                            //MessageBox.Show("Employee: " + anEmp.ID + " was not found!", "Collection searching", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return null;
                        }
                        else
                        {
                            found = (customer.CustomerID == customers[counter].CustomerID);
                        }

                    }
                    if (found)
                    {
                        return customers[counter];
                    }
                    else
                    {
                        return null;
                    }
                    break;
                case "Employee":
                    Employee employee = obj as Employee;
                    found = (employee.getEmployeeID == employees[counter].getEmployeeID);
                    while (!found)
                    {
                        counter++;

                        if (employees.Count <= counter)
                        {
                            //MessageBox.Show("Employee: " + anEmp.ID + " was not found!", "Collection searching", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return null;
                        }
                        else
                        {
                            found = (employee.getEmployeeID == employees[counter].getEmployeeID);
                        }

                    }
                    if (found)
                    {
                        return employees[counter];
                    }
                    else
                    {
                        return null;
                    }
                    break;
                case "Room":
                    Room room = obj as Room;
                    found = (room.getRoomNumber == rooms[counter].getRoomNumber);
                    while (!found)
                    {
                        counter++;

                        if (rooms.Count <= counter)
                        {
                            //MessageBox.Show("Employee: " + anEmp.ID + " was not found!", "Collection searching", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return null;
                        }
                        else
                        {
                            found = (room.getRoomNumber == rooms[counter].getRoomNumber);
                        }

                    }
                    if (found)
                    {
                        return rooms[counter];
                    }
                    else
                    {
                        return null;
                    }
                    break;
                case "Payment":
                    Payment payment = obj as Payment;
                    found = (payment.ID1 == payments[counter].ID1);
                    while (!found)
                    {
                        counter++;

                        if (payments.Count <= counter)
                        {
                            //MessageBox.Show("Employee: " + anEmp.ID + " was not found!", "Collection searching", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return null;
                        }
                        else
                        {
                            found = (payment.ID1 == payments[counter].ID1);
                        }

                    }
                    if (found)
                    {
                        return payments[counter];
                    }
                    else
                    {
                        return null;
                    }
                    break;
                case "Invoice":
                    Invoice invoice = obj as Invoice;
                    found = (invoice.InvoiceID1 == invoices[counter].InvoiceID1);
                    while (!found)
                    {
                        counter++;

                        if (invoices.Count <= counter)
                        {
                            //MessageBox.Show("Employee: " + anEmp.ID + " was not found!", "Collection searching", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return null;
                        }
                        else
                        {
                            found = (invoice.InvoiceID1 == invoices[counter].InvoiceID1);
                        }

                    }
                    if (found)
                    {
                        return invoices[counter];
                    }
                    else
                    {
                        return null;
                    }
                    break;
                case "Hotel":
                    Hotel hotel = obj as Hotel;
                    found = (hotel.HotelID == hotels[counter].HotelID);
                    while (!found)
                    {
                        counter++;

                        if (hotels.Count <= counter)
                        {
                            //MessageBox.Show("Employee: " + anEmp.ID + " was not found!", "Collection searching", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return null;
                        }
                        else
                        {
                            found = (hotel.HotelID == hotels[counter].HotelID);
                        }

                    }
                    if (found)
                    {
                        return hotels[counter];
                    }
                    else
                    {
                        return null;
                    }
                    break;
            }
            return null;
        }
        #endregion
    }
}
