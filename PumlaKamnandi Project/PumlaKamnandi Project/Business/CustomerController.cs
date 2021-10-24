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
        public void DataMaintenance(Employee employee, DataBase.DBOperation operation)
        {
            int index = 0;
            //perform a given database operation to the dataset in meory; 
            phumlaKamnandiDB.DataSetChange(employee, operation);
            //perform operations on the collection
            switch (operation)
            {
                case DataBase.DBOperation.Add:
                    //*** Add the employee to the Collection
                    employees.Add(employee);
                    break;
                case DataBase.DBOperation.Edit:
                    index = FindIndex(employee, "Employee");
                    employees[index] = employee;  // replace employee at this index with the updated employee
                    break;
                case DataBase.DBOperation.Delete:
                    index = FindIndex(employee, "Employee");  // find the index of the specific employee in collection
                    employees.RemoveAt(index);  // remove that employee form the collection
                    break;

            }
        }

        public void DataMaintenance(Customer customer, DataBase.DBOperation operation)
        {
            int index = 0;
            //perform a given database operation to the dataset in meory; 
            phumlaKamnandiDB.DataSetChange(customer, operation);
            //perform operations on the collection
            switch (operation)
            {
                case DataBase.DBOperation.Add:
                    //*** Add the employee to the Collection
                    customers.Add(customer);
                    break;
                case DataBase.DBOperation.Edit:
                    index = FindIndex(customer, "Customer");
                    customers[index] = customer;  // replace employee at this index with the updated employee
                    break;
                case DataBase.DBOperation.Delete:
                    index = FindIndex(customer, "Customer");  // find the index of the specific employee in collection
                    customers.RemoveAt(index);  // remove that employee form the collection
                    break;

            }
        }

        public void DataMaintenance(Booking booking, DataBase.DBOperation operation)
        {
            int index = 0;
            //perform a given database operation to the dataset in meory; 
            phumlaKamnandiDB.DataSetChange(booking, operation);
            //perform operations on the collection
            switch (operation)
            {
                case DataBase.DBOperation.Add:
                    //*** Add the employee to the Collection
                    bookings.Add(booking);
                    break;
                case DataBase.DBOperation.Edit:
                    index = FindIndex(booking, "Booking");
                    bookings[index] = booking;  // replace employee at this index with the updated employee
                    break;
                case DataBase.DBOperation.Delete:
                    index = FindIndex(booking, "Booking");  // find the index of the specific employee in collection
                    bookings.RemoveAt(index);  // remove that employee form the collection
                    break;

            }
        }

        public void DataMaintenance(Payment payment, DataBase.DBOperation operation)
        {
            int index = 0;
            //perform a given database operation to the dataset in meory; 
            phumlaKamnandiDB.DataSetChange(payment, operation);
            //perform operations on the collection
            switch (operation)
            {
                case DataBase.DBOperation.Add:
                    //*** Add the employee to the Collection
                    payments.Add(payment);
                    break;
                case DataBase.DBOperation.Edit:
                    index = FindIndex(payment, "Payment");
                    payments[index] = payment;  // replace employee at this index with the updated employee
                    break;
                case DataBase.DBOperation.Delete:
                    index = FindIndex(payment, "Payment");  // find the index of the specific employee in collection
                    payments.RemoveAt(index);  // remove that employee form the collection
                    break;

            }
        }

        public void DataMaintenance(Room room, DataBase.DBOperation operation)
        {
            int index = 0;
            //perform a given database operation to the dataset in meory; 
            phumlaKamnandiDB.DataSetChange(room, operation);
            //perform operations on the collection
            switch (operation)
            {
                case DataBase.DBOperation.Add:
                    //*** Add the employee to the Collection
                    rooms.Add(room);
                    break;
                case DataBase.DBOperation.Edit:
                    index = FindIndex(room, "Room");
                    rooms[index] = room;  // replace employee at this index with the updated employee
                    break;
                case DataBase.DBOperation.Delete:
                    index = FindIndex(room, "Room");  // find the index of the specific employee in collection
                    rooms.RemoveAt(index);  // remove that employee form the collection
                    break;

            }
        }

        public void DataMaintenance(Invoice invoice, DataBase.DBOperation operation)
        {
            int index = 0;
            //perform a given database operation to the dataset in meory; 
            phumlaKamnandiDB.DataSetChange(invoice, operation);
            //perform operations on the collection
            switch (operation)
            {
                case DataBase.DBOperation.Add:
                    //*** Add the employee to the Collection
                    invoices.Add(invoice);
                    break;
                case DataBase.DBOperation.Edit:
                    index = FindIndex(invoice, "Invoice");
                    invoices[index] = invoice;  // replace employee at this index with the updated employee
                    break;
                case DataBase.DBOperation.Delete:
                    index = FindIndex(invoice, "Invoice");  // find the index of the specific employee in collection
                    invoices.RemoveAt(index);  // remove that employee form the collection
                    break;

            }
        }
        //***Commit the changes to the database
        public bool FinalizeChanges(Employee employee)
        {
            return phumlaKamnandiDB.UpdateDataSource(employee);
        }
        public bool FinalizeChanges(Booking booking)
        {
            return phumlaKamnandiDB.UpdateDataSource(booking);
        }
        public bool FinalizeChanges(Customer customer)
        {
            return phumlaKamnandiDB.UpdateDataSource(customer);
        }
        public bool FinalizeChanges(Payment payment)
        {
            return phumlaKamnandiDB.UpdateDataSource(payment);
        }
        public bool FinalizeChanges(Invoice invoice)
        {
            return phumlaKamnandiDB.UpdateDataSource(invoice);
        }
        public bool FinalizeChanges(Room room)
        {
            return phumlaKamnandiDB.UpdateDataSource(room);
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
                    found = (employee.EmployeeID == employees[counter].EmployeeID);
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
                            found = (employee.EmployeeID == employees[counter].EmployeeID);
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
                    found = (room.RoomNumber == rooms[counter].RoomNumber);
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
                            found = (room.RoomNumber == rooms[counter].RoomNumber);
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
                    found = (payment.paymentID == payments[counter].paymentID);
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
                            found = (payment.paymentID == payments[counter].paymentID);
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
                    found = (invoice.InvoiceID == invoices[counter].InvoiceID);
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
                            found = (invoice.InvoiceID == invoices[counter].InvoiceID);
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
                    found = (employee.EmployeeID == employees[counter].EmployeeID);
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
                            found = (employee.EmployeeID == employees[counter].EmployeeID);
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
                    found = (room.RoomNumber == rooms[counter].RoomNumber);
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
                            found = (room.RoomNumber == rooms[counter].RoomNumber);
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
                    found = (payment.paymentID == payments[counter].paymentID);
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
                            found = (payment.paymentID == payments[counter].paymentID);
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
                    found = (invoice.InvoiceID == invoices[counter].InvoiceID);
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
                            found = (invoice.InvoiceID == invoices[counter].InvoiceID);
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
