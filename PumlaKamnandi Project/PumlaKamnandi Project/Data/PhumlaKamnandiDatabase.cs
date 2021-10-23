using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using PumlaKamnandi_Project.Business; 

namespace PumlaKamnandi_Project.Data
{
    class PhumlaKamnandiDatabase:DataBase
    {
        #region  Data members        
        private string customerTable = "Customer";
        private string sqlLocalCustomer = "SELECT * FROM Customer";
        private string tableBooking = "Booking";
        private string sqlLocalBooking = "SELECT * FROM Booking";
        private string tableRoom = "Room";
        private string sqlLocalRoom = "SELECT * FROM Room";
        private string tablePayment = "Payment";
        private string sqlLocalPayment = "SELECT * FROM Payment";
        private string tableHotel = "Hotel";
        private string sqlLocalHotel = "SELECT * FROM Hotel";
        private string tableInvoice = "Invoice";
        private string sqlLocalInvoice = "SELECT * FROM Invoice";
        private string tableEmployee = "Employee";
        private string sqlLocalEmployee = "SELECT * FROM Employee";
        private Collection<Customer> customers;
        private Collection<Employee> employees;
        private Collection<Invoice> invoices;
        private Collection<Hotel> hotels;
        private Collection<Payment> payments;
        private Collection<Room> rooms;
        private Collection<Booking> bookings;
        

        #endregion

        #region Property Method: Collection
        public Collection<Employee> AllEmployees
        {
            get 
            {
                return employees;
            }
        }

        public Collection<Customer> Customers { get => customers; set => customers = value; }
        public Collection<Employee> Employees { get => employees; set => employees = value; }
        public Collection<Invoice> Invoices { get => invoices; set => invoices = value; }
        public Collection<Hotel> Hotels { get => hotels; set => hotels = value; }
        public Collection<Payment> Payments { get => payments; set => payments = value; }
        public Collection<Room> Rooms { get => rooms; set => rooms = value; }
        public Collection<Booking> Bookings { get => bookings; set => bookings = value; }
        #endregion

        #region Constructor
        public PhumlaKamnandiDatabase() : base()
        {
            customers = new Collection<Customer>();
            employees = new Collection<Employee>();
            invoices = new Collection<Invoice>();
            hotels = new Collection<Hotel>();
            payments = new Collection<Payment>();
            rooms = new Collection<Room>();
            bookings = new Collection<Booking>();
            FillDataSet(sqlLocalEmployee, tableEmployee);
            Add2Collection(tableEmployee);
            FillDataSet(sqlLocalCustomer, customerTable);
            Add2Collection(customerTable);
            FillDataSet(sqlLocalInvoice, tableInvoice);
            Add2Collection(tableInvoice);
            FillDataSet(sqlLocalHotel, tableHotel);
            Add2Collection(tableHotel);
            FillDataSet(sqlLocalPayment, tablePayment);
            Add2Collection(tablePayment);
            FillDataSet(sqlLocalRoom, tableRoom);
            Add2Collection(tableRoom);
            FillDataSet(sqlLocalBooking, tableBooking);
            Add2Collection(tableBooking);
            
        }
        #endregion

        #region Utility Methods
        public DataSet GetDataSet()
        {
            return dsMain;
        }

       /* public int FindRow(object item, string table)
        {
            
            {
                
                int rowIndex = 0;
                
                DataRow myRow;
                
                int returnValue = -1;
                foreach (DataRow myRow_loopVariable in dsMain.Tables[table].Rows)
                {
                    
                    myRow = myRow_loopVariable;
                   
                    if (myRow.RowState == System.Data.DataRowState.Deleted)
                    {
                        continue;
                    }
                    
                   else
                    {
                        if (anEmp.ID == Convert.ToString(dsMain.Tables[table].Rows[rowIndex]["ID"]))
                        {
                            //2.3.7 assign rowIndex to returnValue
                            returnValue = rowIndex;
                        }
                    }
                    //2.3.8 Increment the rowIndex counter
                    rowIndex++;
                }
                //2.3.9 the method should return the variable returnValue to its caller;
                return returnValue;
            }
        }*/
        private void Add2Collection(string table)
        {
            //Declare references to a myRow object and an Employee object
            DataRow myRow = null;
            Customer customer;
            Employee employee;
            Invoice invoice;
            Hotel hotel;
            Payment payment;
            Room room;
            Booking booking;
            
            switch (table)
            {
                case "Booking":
                    foreach (DataRow myRow_loopVariable in dsMain.Tables[table].Rows)
                    {
                        myRow = myRow_loopVariable;
                        if (!(myRow.RowState == DataRowState.Deleted))
                        {
                            booking = new Booking();
                            booking.ReservationID = Convert.ToInt32(myRow["ReservationID"]);
                            booking.RoomNumber = Convert.ToInt32(myRow["roomNumber"]);
                            booking.CheckInDate = Convert.ToString(myRow["checkInDate"]).TrimEnd();
                            booking.CheckOutDate = Convert.ToString(myRow["checkOutDate"]).TrimEnd();
                            booking.Description = Convert.ToString(myRow["Description"]).TrimEnd();
                            booking.TotalCost = Convert.ToInt32(myRow["totalCost"]);
                            booking.EmployeeID = Convert.ToInt32(myRow["EmployeeID"]);
                            bookings.Add(booking);
                        }
                    }
                 break;


                case "Customer":
                    foreach (DataRow myRow_loopVariable in dsMain.Tables[table].Rows)
                    {
                        myRow = myRow_loopVariable;
                        if (!(myRow.RowState == DataRowState.Deleted))
                        {
                            customer = new Customer();
                            customer.CustomerID = Convert.ToString(myRow["CustomerID"]).TrimEnd();
                            customer.Name = Convert.ToString(myRow["Name"]).TrimEnd();
                            customer.EmailAddress = Convert.ToString(myRow["email Address"]).TrimEnd();
                            customer.Balance = Convert.ToString(myRow["Balance"]).TrimEnd();
                            customer.Address = Convert.ToString(myRow["Address"]).TrimEnd();
                            customer.AccountNumber = Convert.ToInt32(myRow["AccountNumber"]);
                            customer.CustomerBooking = Convert.ToString(myRow["CustomerBooking"]).TrimEnd();
                            customer.CustomerRoom = Convert.ToString(myRow["CustomerRoom"]).TrimEnd();
                            customer.ID = Convert.ToString(myRow["ID"]).TrimEnd();
                            customer.Paymenttype = Convert.ToString(myRow["PaymentType"]).TrimEnd();
                            customer.Telephone = Convert.ToString(myRow["Telephone"]).TrimEnd();
                            customers.Add(customer);
                        }
                    }
                    break;
                case "Employee":
                    foreach (DataRow myRow_loopVariable in dsMain.Tables[table].Rows)
                    {
                        myRow = myRow_loopVariable;
                        if (!(myRow.RowState == DataRowState.Deleted))
                        {
                            employee = new Employee();
                            employee.Name = Convert.ToString(myRow["Name"]).TrimEnd();
                            employee.ID = Convert.ToString(myRow["ID"]).TrimEnd();
                            employee.Telephone = Convert.ToString(myRow["Telephone"]).TrimEnd();
                            employee.EmailAddress = Convert.ToString(myRow["EmailAddress"]).TrimEnd();
                            employee.Address= Convert.ToString(myRow["Address"]).TrimEnd();
                            /* Add the extra attributes
                             * employee. = Convert.ToString(myRow["totalCost"]).TrimEnd();
                            booking.EmployeeID = Convert.ToString(myRow["EmployeeID"]).TrimEnd();*/
                            employees.Add(employee);
                        }
                    }
                    break;
                case "Room":
                    foreach (DataRow myRow_loopVariable in dsMain.Tables[table].Rows)
                    {
                        myRow = myRow_loopVariable;
                        if (!(myRow.RowState == DataRowState.Deleted))
                        {
                            room = new Room();
                            room.RoomNumber = Convert.ToInt32(myRow["roomNumber"]);
                            room.Cost = Convert.ToString(myRow["Cost"]).TrimEnd();
                            room.HotelID = Convert.ToString(myRow["HotelID"]).TrimEnd();
                            room.Description = Convert.ToString(myRow["Description"]).TrimEnd();
                            room.Capacity = Convert.ToInt32(myRow["Capacity"]);
                            rooms.Add(room);
                        }
                    }
                    break;
                case "Payment":
                    foreach (DataRow myRow_loopVariable in dsMain.Tables[table].Rows)
                    {
                        myRow = myRow_loopVariable;
                        if (!(myRow.RowState == DataRowState.Deleted))
                        {
                            payment = new Payment();
                            payment.PaymentID = Convert.ToInt32(myRow["PaymentID"]);
                            payment.Type = Convert.ToString(myRow["Type"]).TrimEnd();
                            payment.Descriptiom = Convert.ToString(myRow["Description"]).TrimEnd();
                            payment.Date = Convert.ToString(myRow["Date"]).TrimEnd();
                            payment.Amount = Convert.ToInt32(myRow["Amount"]);
                            payments.Add(payment);
                        }
                    }
                    break;
                case "Invoice":
                    foreach (DataRow myRow_loopVariable in dsMain.Tables[table].Rows)
                    {
                        myRow = myRow_loopVariable;
                        if (!(myRow.RowState == DataRowState.Deleted))
                        {
                            invoice = new Invoice();
                            invoice.PaymentID = Convert.ToInt32(myRow["PaymentID"]);
                            invoice.InvoiceNumber = Convert.ToString(myRow["InvoiceNumber"]).TrimEnd();
                            invoice.Description = Convert.ToString(myRow["Description"]).TrimEnd();
                            invoices.Add(invoice);
                        }
                    }
                    break;
                case "Hotel":
                    foreach (DataRow myRow_loopVariable in dsMain.Tables[table].Rows)
                    {
                        myRow = myRow_loopVariable;
                        if (!(myRow.RowState == DataRowState.Deleted))
                        {
                            hotel = new Hotel();
                            hotel.HotelID = Convert.ToInt32(myRow["HotelID"]);
                            hotel.Location = Convert.ToString(myRow["Location"]).TrimEnd();
                            hotel.ContactDetails = Convert.ToString(myRow["contactDetails"]).TrimEnd();
                            invoices.Add(invoice);
                        }
                    }
                    break;

            }
            //READ from the table  
            
                
            }
        }
        private void FillRow(DataRow aRow, Employee anEmp, DBOperation operation)
        {
            HeadWaiter headwaiter;
            Runner runner;
            Waiter waiter;
            if (operation == DBOperation.Add)
            {
                aRow["ID"] = anEmp.ID;  //NOTE square brackets to indicate index of collections of fields in row.
                aRow["EmpID"] = anEmp.EmployeeID;
            }

            aRow["Name"] = anEmp.Name;
            aRow["Phone"] = anEmp.Telephone;
            aRow["Role"] = (byte)anEmp.role.getRoleValue;
            //*** For each role add the specific data variables
            switch (anEmp.role.getRoleValue)
            {
                case Role.RoleType.Headwaiter:
                    headwaiter = (HeadWaiter)anEmp.role;
                    aRow["Salary"] = headwaiter.SalaryAmount;
                    break;
                case Role.RoleType.Waiter:
                    waiter = (Waiter)anEmp.role;
                    aRow["DayRate"] = waiter.getRate;
                    aRow["NoOfShifts"] = waiter.getShifts;
                    aRow["Tips"] = waiter.getTips;
                    break;
                case Role.RoleType.Runner:
                    runner = (Runner)anEmp.role;
                    aRow["DayRate"] = runner.getRate;
                    aRow["NoOfShifts"] = runner.getShifts;
                    aRow["Tips"] = runner.getTips;
                    break;
            }
        }
        #endregion

        #region Database Operations CRUD
        public void DataSetChange(Employee anEmp, DBOperation operation)
        {
            DataRow aRow = null;
            string dataTable = table1;
            switch (anEmp.role.getRoleValue)
            {
                case Role.RoleType.Headwaiter:
                    dataTable = table1;
                    break;
                case Role.RoleType.Waiter:
                    dataTable = table2;
                    break;
                case Role.RoleType.Runner:
                    dataTable = table3;
                    break;
            }
            switch (operation)
            {
                case DBOperation.Add:
                    aRow = dsMain.Tables[dataTable].NewRow();
                    FillRow(aRow, anEmp, operation);
                    dsMain.Tables[dataTable].Rows.Add(aRow); //Add to the dataset
                    break;
                case DBOperation.Edit:
                    // For the Edit section you have to find a row instead of creating a new row. 
                    aRow = dsMain.Tables[dataTable].Rows[FindRow(anEmp, dataTable)];
                    FillRow(aRow, anEmp, operation);
                    break;
                //2.4.1 Write the code to Fill this row for the Edit operation by calling the FillRow method
                case DBOperation.Delete:
                    aRow = dsMain.Tables[dataTable].Rows[FindRow(anEmp, dataTable)];
                    //FillRow(aRow, anEmp, operation);
                    dsMain.Tables[dataTable].Rows.Remove(aRow);
                    break;
                default:
                    break;
            }
            /*aRow = dsMain.Tables[dataTable].NewRow();
            FillRow(aRow, anEmp);
            dsMain.Tables[dataTable].Rows.Add(aRow);  //Add to the dataset*/
        }
        #endregion

        #region Build Parameters, Create Commands & Update database

        private void Build_UPDATE_Parameters(Employee anEmp)
        {
            SqlParameter param = default(SqlParameter);
            param = new SqlParameter("@Name", SqlDbType.NVarChar, 100, "Name");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);
            // 2.5.1 TO DO: -: Do for all fields other than ID and EMPID as for the Build Insert parameters. 
            //Ofcourse, depending on the role. The code is similar to the Build_INSERT_Parameters that you created
            param = new SqlParameter("@Original_ID", SqlDbType.NVarChar, 15, "ID");
            param.SourceVersion = DataRowVersion.Original;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@Phone", SqlDbType.NVarChar, 15, "Phone");
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@Role", SqlDbType.TinyInt, 1, "Role");
            daMain.UpdateCommand.Parameters.Add(param);
            switch (anEmp.role.getRoleValue)
            {
                case Role.RoleType.Headwaiter:
                    param = new SqlParameter("@Salary", SqlDbType.Money, 8, "Salary");
                    daMain.UpdateCommand.Parameters.Add(param);
                    break;
                case Role.RoleType.Waiter:
                    param = new SqlParameter("@Tips", SqlDbType.Money, 8, "Tips");
                    daMain.UpdateCommand.Parameters.Add(param);

                    param = new SqlParameter("@DayRate", SqlDbType.Money, 8, "DayRate");
                    daMain.UpdateCommand.Parameters.Add(param);

                    param = new SqlParameter("@NoOfShifts", SqlDbType.SmallInt, 4, "NoOfShifts");
                    daMain.UpdateCommand.Parameters.Add(param);
                    break;
                case Role.RoleType.Runner:
                    param = new SqlParameter("@DayRate", SqlDbType.Money, 8, "DayRate");
                    daMain.UpdateCommand.Parameters.Add(param);

                    param = new SqlParameter("@NoOfShifts", SqlDbType.SmallInt, 4, "NoOfShifts");
                    daMain.UpdateCommand.Parameters.Add(param);
                    break;
            }

        }
        private void Create_UPDATE_Command(Employee anEmp)
        {
            switch (anEmp.role.getRoleValue)
            {
                case Role.RoleType.Headwaiter:
                    daMain.UpdateCommand = new SqlCommand("UPDATE HeadWaiter SET Name =@Name,Phone =@Phone, Role = @Role, Salary =@Salary " + "WHERE ID = @Original_ID", cnMain);
                    break;
                //2.6.1 TO DO: -: Do the same for the other tables
                case Role.RoleType.Waiter:
                    daMain.UpdateCommand = new SqlCommand("UPDATE Waiter SET Name =@Name,Phone =@Phone, Role = @Role, Tips = @Tips,DayRate = @DayRate,NoOfShifts= @NoOfShifts " + "WHERE ID = @Original_ID", cnMain);
                    break;
                case Role.RoleType.Runner:
                    daMain.UpdateCommand = new SqlCommand("UPDATE Runner SET Name =@Name,Phone =@Phone, Role = @Role, DayRate = @DayRate, NoOfShifts = @NoOfShifts " + "WHERE ID = @Original_ID", cnMain);
                    break;
            }
            //2.6.2 Write the code to call the Build_UPDATE_Parameters method
            Build_UPDATE_Parameters(anEmp);
        }

        private void Build_INSERT_Parameters(Employee anEmp)
        {
            //Create Parameters to communicate with SQL INSERT...add the input parameter and set its properties.
            SqlParameter param = default(SqlParameter);
            param = new SqlParameter("@ID", SqlDbType.NVarChar, 15, "ID");
            daMain.InsertCommand.Parameters.Add(param);//Add the parameter to the Parameters collection.

            param = new SqlParameter("@EMPID", SqlDbType.NVarChar, 10, "EMPID");
            daMain.InsertCommand.Parameters.Add(param);

            //Do the same for Description & answer -ensure that you choose the right size
            param = new SqlParameter("@Name", SqlDbType.NVarChar, 100, "Name");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@Phone", SqlDbType.NVarChar, 15, "Phone");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@Role", SqlDbType.TinyInt, 1, "Role");
            daMain.InsertCommand.Parameters.Add(param);
            switch (anEmp.role.getRoleValue)
            {
                case Role.RoleType.Headwaiter:
                    param = new SqlParameter("@Salary", SqlDbType.Money, 8, "Salary");
                    daMain.InsertCommand.Parameters.Add(param);
                    break;
                case Role.RoleType.Waiter:
                    param = new SqlParameter("@Tips", SqlDbType.Money, 8, "Tips");
                    daMain.InsertCommand.Parameters.Add(param);

                    param = new SqlParameter("@DayRate", SqlDbType.Money, 8, "DayRate");
                    daMain.InsertCommand.Parameters.Add(param);

                    param = new SqlParameter("@NoOfShifts", SqlDbType.SmallInt, 4, "NoOfShifts");
                    daMain.InsertCommand.Parameters.Add(param);
                    break;
                case Role.RoleType.Runner:
                    param = new SqlParameter("@DayRate", SqlDbType.Money, 8, "DayRate");
                    daMain.InsertCommand.Parameters.Add(param);

                    param = new SqlParameter("@NoOfShifts", SqlDbType.SmallInt, 4, "NoOfShifts");
                    daMain.InsertCommand.Parameters.Add(param);
                    break;
            }

        }

        private void Create_INSERT_Command(Employee anEmp)
        {
            //Create the command that must be used to insert values into the Books table..
            switch (anEmp.role.getRoleValue)
            {
                case Role.RoleType.Headwaiter:
                    daMain.InsertCommand = new SqlCommand("INSERT into HeadWaiter (ID, EMPID, Name, Phone, Role, Salary) VALUES (@ID, @EmpID, @Name, @Phone, @Role, @Salary)", cnMain);
                    break;
                case Role.RoleType.Waiter:
                    daMain.InsertCommand = new SqlCommand("INSERT into Waiter (ID, EMPID, Name, Phone, Role, Tips, DayRate, NoOfShifts) VALUES (@ID, @EmpID, @Name, @Phone, @Role, @Tips, @DayRate, @NoOfShifts)", cnMain);
                    break;
                case Role.RoleType.Runner:
                    daMain.InsertCommand = new SqlCommand("INSERT into Runner (ID, EMPID, Name, Phone, Role, DayRate, NoOfShifts) VALUES (@ID, @EmpID, @Name, @Phone, @Role, @DayRate, @NoOfShifts)", cnMain);
                    break;
            }
            Build_INSERT_Parameters(anEmp);
        }

        public bool UpdateDataSource(Employee anEmp)
        {
            bool success = true;
            Create_INSERT_Command(anEmp);
            Create_UPDATE_Command(anEmp);
            switch (anEmp.role.getRoleValue)
            {
                case Role.RoleType.Headwaiter:
                    success = UpdateDataSource(sqlLocal1, table1);
                    break;
                case Role.RoleType.Waiter:
                    success = UpdateDataSource(sqlLocal2, table2);
                    break;
                case Role.RoleType.Runner:
                    success = UpdateDataSource(sqlLocal3, table3);
                    break;
            }

            return success;
        }

        #endregion
    }
}
