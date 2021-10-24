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
    enum DBOperation { Add, Delete, Edit };
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
                            customer.BookingID = Convert.ToString(myRow["CustomerBooking"]).TrimEnd();
                            customer.CustomerRoomID = Convert.ToString(myRow["CustomerRoom"]).TrimEnd();
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
                            employee.Address = Convert.ToString(myRow["Address"]).TrimEnd();
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
                            room.getRoomNumber = Convert.ToInt32(myRow["roomNumber"]);
                            room.getPrice = Convert.ToDecimal(myRow["Cost"]);
                            //room.getHotelID = Convert.ToString(myRow["HotelID"]).TrimEnd();
                            room.getDescription = Convert.ToString(myRow["Description"]).TrimEnd();
                            room.getCapacity = Convert.ToInt32(myRow["Capacity"]);
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
                            payment.ID1 = Convert.ToInt32(myRow["PaymentID"]);
                            payment.Type = Convert.ToString(myRow["Type"]).TrimEnd();
                            payment.Description = Convert.ToString(myRow["Description"]).TrimEnd();
                            payment.Date = Convert.ToString(myRow["Date"]).TrimEnd();
                            payment.Amount1 = Convert.ToDecimal(myRow["Amount"]);
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
                            invoice.Payment = Convert.ToInt32(myRow["PaymentID"]);
                            invoice.InvoiceID1 = Convert.ToString(myRow["InvoiceNumber"]).TrimEnd();
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
                            hotels.Add(hotel);
                        }
                    }
                    break;


            }
            //READ from the table  ;


        }
    
        
        private void FillRow(DataRow aRow, object obj, DBOperation operation,string table)
        {
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
                    booking = obj as Booking;
                    if (operation == DBOperation.Add)
                    {
                        aRow["ReservationID"] = booking.ReservationID;
                    }
                    aRow["roomNumber"] = booking.RoomNumber;
                    aRow["checkInDate"] = booking.CheckInDate;
                    aRow["checkOutDate"] = booking.CheckOutDate;
                    aRow["Description"] = booking.Description;
                    aRow["totalCost"]=booking.TotalCost;
                    aRow["EmployeeID"] = booking.EmployeeID;
                    break;
                case "Customer":
                    customer = obj as Customer;
                    if (operation == DBOperation.Add)
                    {
                        aRow["CustomerID"] = customer.CustomerID;
                    }
                    aRow["Name"] = customer.Name;
                    aRow["email Address"] = customer.EmailAddress;
                    aRow["Balance"] = customer.Balance;
                    aRow["Address"] = customer.Address;
                    aRow["AccountNumber"] = customer.AccountNumber;
                    aRow["CustomerBooking"] = customer.BookingID;
                    aRow["CustomerRoom"] = customer.CustomerRoomID;
                    aRow["ID"] = customer.ID;
                    aRow["PaymentType"] = customer.Paymenttype;
                    aRow["Telephone"] = customer.Telephone;
                    break;
                case "Employee":
                    employee = obj as Employee;

                    aRow["Name"] = employee.Name;
                    if (operation == DBOperation.Add)
                    {
                        aRow["ID"] = employee.ID;
                    }
                    aRow["Telephone"] = employee.Telephone;
                    aRow["EmailAddress"] = employee.EmailAddress;
                    aRow["Address"] = employee.Address;
                    /* Add the extra attributes
                        * employee. = Convert.ToString(myRow["totalCost"]).TrimEnd();
                    booking.EmployeeID = Convert.ToString(myRow["EmployeeID"]).TrimEnd();*/
                    break;
                case "Room":
                    room = obj as Room;
                    if (operation == DBOperation.Add)
                    {
                        aRow["roomNumber"] = room.getRoomNumber;
                    }
                    aRow["Cost"] = room.getPrice;
                    //room.getHotelID = Convert.ToString(myRow["HotelID"]).TrimEnd();
                    aRow["Description"] = room.getDescription;
                    aRow["Capacity"] = room.getCapacity;
                    break;
                case "Payment":
                    payment = obj as Payment;
                    if (operation == DBOperation.Add)
                    {
                        aRow["PaymentID"] = payment.ID1;
                    }
                    aRow["Type"] = payment.Type;
                    aRow["Description"] = payment.Description;
                    aRow["Date"] = payment.Date;
                    aRow["Amount"] =payment.Amount1;
                    break;
                case "Invoice":
                    invoice = obj as Invoice;
                    aRow["PaymentID"] = invoice.Payment;
                    if (operation == DBOperation.Add)
                    {
                        aRow["InvoiceNumber"] = invoice.InvoiceID1;
                    }
                    aRow["Description"] = invoice.Description;
                    break;
                case "Hotel":
                    hotel = obj as Hotel;
                    if (operation == DBOperation.Add)
                    {
                        aRow["HotelID"] = hotel.HotelID;
                    }
                    aRow["Location"] = hotel.Location;
                    aRow["contactDetails"] = hotel.ContactDetails;
                    break;


            }
        }
        #endregion

        #region Database Operations CRUD
        public void DataSetChange(object obj, DBOperation operation,string table)
        {
            DataRow aRow = null;
            string dataTable = table;
            switch (operation)
            {
                case DBOperation.Add:
                    aRow = dsMain.Tables[dataTable].NewRow();
                    FillRow(aRow, obj, operation,table);
                    dsMain.Tables[dataTable].Rows.Add(aRow); //Add to the dataset
                    break;
                case DBOperation.Edit:
                    // For the Edit section you have to find a row instead of creating a new row. 
                    aRow = dsMain.Tables[dataTable].Rows[FindRow(anEmp, dataTable)];
                    FillRow(aRow, obj, operation, table);
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

        private void Build_UPDATE_Parameters(Customer customer)
        {
            SqlParameter param = default(SqlParameter);
            param = new SqlParameter("@Name", SqlDbType.NVarChar, 100, "Name");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);
            // 2.5.1 TO DO: -: Do for all fields other than ID and EMPID as for the Build Insert parameters. 
            //Ofcourse, depending on the role. The code is similar to the Build_INSERT_Parameters that you created
            param = new SqlParameter("@Original_ID", SqlDbType.Int, 15, "CustomerID");
            param.SourceVersion = DataRowVersion.Original;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@email", SqlDbType.NVarChar, 15, "emailAddress");
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@Balance", SqlDbType.Money, 10, "Balance");
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@resID", SqlDbType.Int, 10, "ReservationID");
            daMain.UpdateCommand.Parameters.Add(param);



        }


        private void Build_UPDATE_Parameters(Booking booking)
        {
            SqlParameter param = default(SqlParameter);
            param = new SqlParameter("@roomNumber", SqlDbType.NVarChar, 100, "roomNumber");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);
            // 2.5.1 TO DO: -: Do for all fields other than ID and EMPID as for the Build Insert parameters. 
            //Ofcourse, depending on the role. The code is similar to the Build_INSERT_Parameters that you created
            param = new SqlParameter("@Original_ID", SqlDbType.NVarChar, 15, "ReservationID");
            param.SourceVersion = DataRowVersion.Original;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@checkInDate", SqlDbType.Date, 15, "checkInDate");
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@checkOutDate", SqlDbType.Date, 10, "checkOutDate");
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@Description", SqlDbType.NVarChar, 50, "Description");
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@totalCost", SqlDbType.Money, 100, "totalCost");
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@employeeID ", SqlDbType.Int, 10, "employeeID ");
            daMain.UpdateCommand.Parameters.Add(param);


        }


        private void Build_UPDATE_Parameters(Employee employee)
        {
            SqlParameter param = default(SqlParameter);
            param = new SqlParameter("@Name", SqlDbType.NVarChar, 100, "Name");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);
            // 2.5.1 TO DO: -: Do for all fields other than ID and EMPID as for the Build Insert parameters. 
            //Ofcourse, depending on the role. The code is similar to the Build_INSERT_Parameters that you created
            param = new SqlParameter("@Original_ID", SqlDbType.Int, 15, "employeeID");
            param.SourceVersion = DataRowVersion.Original;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@EmployeeRole", SqlDbType.NVarChar, 15, "EmployeeRole");
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@Salary", SqlDbType.Money, 10, "Salary");
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@NoOfShifts", SqlDbType.Int, 10, "NoOfShifts");
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@Supervisor", SqlDbType.NVarChar, 50, "Supervisor");
            daMain.UpdateCommand.Parameters.Add(param);


            param = new SqlParameter("@cellNumber ", SqlDbType.NVarChar, 10, "cellNumber ");
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@ReservationID  ", SqlDbType.Int, 10, "ReservationID  ");
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@HotelID   ", SqlDbType.Int, 10, "HotelID   ");
            daMain.UpdateCommand.Parameters.Add(param);

        }


        private void Build_UPDATE_Parameters(Hotel hotel)
        {
            SqlParameter param = default(SqlParameter);
            param = new SqlParameter("@Location ", SqlDbType.NVarChar, 100, "Location ");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);
            // 2.5.1 TO DO: -: Do for all fields other than ID and EMPID as for the Build Insert parameters. 
            //Ofcourse, depending on the role. The code is similar to the Build_INSERT_Parameters that you created
            param = new SqlParameter("@Original_ID", SqlDbType.Int, 15, "HotelID");
            param.SourceVersion = DataRowVersion.Original;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@contactDetails ", SqlDbType.NVarChar, 15, "contactDetails ");
            daMain.UpdateCommand.Parameters.Add(param);

        }

        private void Build_UPDATE_Parameters(Invoice invoice)
        {
            SqlParameter param = default(SqlParameter);
            param = new SqlParameter("@Description", SqlDbType.NVarChar, 100, "Description");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);
            // 2.5.1 TO DO: -: Do for all fields other than ID and EMPID as for the Build Insert parameters. 
            //Ofcourse, depending on the role. The code is similar to the Build_INSERT_Parameters that you created
            param = new SqlParameter("@invoiceNumber", SqlDbType.Int, 10, "invoiceNumber");
            param.SourceVersion = DataRowVersion.Original;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@Description", SqlDbType.NVarChar, 50, "Description");
            daMain.UpdateCommand.Parameters.Add(param);

        }


        private void Build_UPDATE_Parameters(Payment payment)
        {
            SqlParameter param = default(SqlParameter);
            param = new SqlParameter("@Type", SqlDbType.NVarChar, 100, "Type");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);
            // 2.5.1 TO DO: -: Do for all fields other than ID and EMPID as for the Build Insert parameters. 
            //Ofcourse, depending on the role. The code is similar to the Build_INSERT_Parameters that you created
            param = new SqlParameter("@Original_ID", SqlDbType.NVarChar, 15, "PaymentID");
            param.SourceVersion = DataRowVersion.Original;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@Date", SqlDbType.Date, 1, "Date");
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@Description", SqlDbType.NVarChar, 50, "Description");
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@Amount", SqlDbType.Money, 10, "Amount");
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@employeeID ", SqlDbType.Int, 10, "employeeID ");
            daMain.UpdateCommand.Parameters.Add(param);


        }


        private void Build_UPDATE_Parameters(Room room)
        {
            SqlParameter param = default(SqlParameter);
            param = new SqlParameter("@Type", SqlDbType.NVarChar, 100, "Type");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);
            // 2.5.1 TO DO: -: Do for all fields other than ID and EMPID as for the Build Insert parameters. 
            //Ofcourse, depending on the role. The code is similar to the Build_INSERT_Parameters that you created
            param = new SqlParameter("@Original_ID", SqlDbType.NVarChar, 15, "roomNumber");
            param.SourceVersion = DataRowVersion.Original;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@Capacity", SqlDbType.Int, 1, "Capacity");
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@Description", SqlDbType.NVarChar, 50, "Description");
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@Cost", SqlDbType.Money, 10, "Cost");
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@HotelID", SqlDbType.Int, 10, "HotelID");
            daMain.UpdateCommand.Parameters.Add(param);


        }

        private void Create_UPDATE_Command(Customer customer)
        {

            daMain.UpdateCommand = new SqlCommand("UPDATE Customer SET Name =@Name,emailAddress =@emailAddress, ReservationID = @ReservationID, Balance = @Balance " + "WHERE CustomerID = @Original_ID", cnMain);

            Build_UPDATE_Parameters(customer);
        }


        private void Create_UPDATE_Command(Booking booking)
        {

            daMain.UpdateCommand = new SqlCommand("UPDATE Booking SET roomNumber = @roomNumber ,checkInDate = @checkInDate , checkOutDate = @checkOutDate, Description = @Description, totalCost = @totalCost, employeeID = @employeeID " + "WHERE ReservationID  = @Original_ID", cnMain);

            Build_UPDATE_Parameters(booking);
        }

        private void Create_UPDATE_Command(Employee employee)
        {

            daMain.UpdateCommand = new SqlCommand("UPDATE Employee SET Name = @Name ,Salary = @Salary, NoOfShifts  = @NoOfShifts, Supervisor  = @Supervisor , cellNumber  = @cellNumber , ReservationID  = @ReservationID, HotelID   = @HotelID   " + "WHERE employeeID  = @Original_ID", cnMain);

            Build_UPDATE_Parameters(employee);
        }

        private void Create_UPDATE_Command(Hotel hotel)
        {

            daMain.UpdateCommand = new SqlCommand("UPDATE Hotel SET Location  = @Location  ,contactDetails  = @contactDetails" + "WHERE HotelID  = @Original_ID", cnMain);

            Build_UPDATE_Parameters(hotel);
        }

        private void Create_UPDATE_Command(Invoice invoice)
        {

            daMain.UpdateCommand = new SqlCommand("UPDATE Invoice PaymentID   = @PaymentID , Description = @Description    " + "WHERE invoiceNumber  = @Original_ID", cnMain);

            Build_UPDATE_Parameters(invoice);
        }

        private void Create_UPDATE_Command(Payment payment)
        {

            daMain.UpdateCommand = new SqlCommand("UPDATE Payment SET Type = @Type , Description  = @Description , Date   = @Date , Amount   = @Amount  " + "WHERE PaymentID  = @Original_ID", cnMain);

            Build_UPDATE_Parameters(payment);
        }

        private void Create_UPDATE_Command(Room room)
        {

            daMain.UpdateCommand = new SqlCommand("UPDATE Room SET HotelID  = @HotelID  ,Cost  = @Cost , Description   = @Description , Capacity   = @Capacity  " + "WHERE roomNumber   = @Original_ID", cnMain);

            Build_UPDATE_Parameters(room);
        }


        private void Build_INSERT_Parameters(Customer customer)
        {
            SqlParameter param = default(SqlParameter);
            param = new SqlParameter("@Name", SqlDbType.NVarChar, 100, "Name");
            param.SourceVersion = DataRowVersion.Current;
            daMain.InsertCommand.Parameters.Add(param);
            // 2.5.1 TO DO: -: Do for all fields other than ID and EMPID as for the Build Insert parameters. 
            //Ofcourse, depending on the role. The code is similar to the Build_INSERT_Parameters that you created
            param = new SqlParameter("@CustomerID", SqlDbType.Int, 15, "CustomerID");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@email", SqlDbType.NVarChar, 15, "emailAddress");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@Balance", SqlDbType.Money, 10, "Balance");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@resID", SqlDbType.Int, 10, "ReservationID");
            daMain.InsertCommand.Parameters.Add(param);



        }

         private void Build_INSERT_Parameters(Booking booking)
        {
            SqlParameter param = default(SqlParameter);
            param = new SqlParameter("@roomNumber", SqlDbType.NVarChar, 100, "roomNumber");
            param.SourceVersion = DataRowVersion.Current;
            daMain.InsertCommand.Parameters.Add(param);
            // 2.5.1 TO DO: -: Do for all fields other than ID and EMPID as for the Build Insert parameters. 
            //Ofcourse, depending on the role. The code is similar to the Build_INSERT_Parameters that you created
            param = new SqlParameter("@ReservationID", SqlDbType.NVarChar, 15, "ReservationID");
            param.SourceVersion = DataRowVersion.Original;
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@checkInDate", SqlDbType.Date, 15, "checkInDate");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@checkOutDate", SqlDbType.Date, 10, "checkOutDate");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@Description", SqlDbType.NVarChar, 50, "Description");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@totalCost", SqlDbType.Money, 100, "totalCost");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@employeeID ", SqlDbType.Int, 10, "employeeID ");
            daMain.InsertCommand.Parameters.Add(param);


        }

        private void Build_INSERT_Parameters(Employee employee)
        {
            SqlParameter param = default(SqlParameter);
            param = new SqlParameter("@Name", SqlDbType.NVarChar, 100, "Name");
            param.SourceVersion = DataRowVersion.Current;
            daMain.InsertCommand.Parameters.Add(param);
            // 2.5.1 TO DO: -: Do for all fields other than ID and EMPID as for the Build Insert parameters. 
            //Ofcourse, depending on the role. The code is similar to the Build_INSERT_Parameters that you created
            param = new SqlParameter("@employeeID", SqlDbType.Int, 15, "employeeID");
            param.SourceVersion = DataRowVersion.Original;
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@EmployeeRole", SqlDbType.NVarChar, 15, "EmployeeRole");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@Salary", SqlDbType.Money, 10, "Salary");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@NoOfShifts", SqlDbType.Int, 10, "NoOfShifts");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@Supervisor", SqlDbType.NVarChar, 50, "Supervisor");
            daMain.InsertCommand.Parameters.Add(param);


            param = new SqlParameter("@cellNumber ", SqlDbType.NVarChar, 10, "cellNumber ");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@ReservationID  ", SqlDbType.Int, 10, "ReservationID  ");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@HotelID   ", SqlDbType.Int, 10, "HotelID   ");
            daMain.InsertCommand.Parameters.Add(param);

        }

        private void Build_INSERT_Parameters(Hotel hotel)
        {
            SqlParameter param = default(SqlParameter);
            param = new SqlParameter("@Location ", SqlDbType.NVarChar, 100, "Location ");
            param.SourceVersion = DataRowVersion.Current;
            daMain.InsertCommand.Parameters.Add(param);
            // 2.5.1 TO DO: -: Do for all fields other than ID and EMPID as for the Build Insert parameters. 
            //Ofcourse, depending on the role. The code is similar to the Build_INSERT_Parameters that you created
            param = new SqlParameter("@HotelID", SqlDbType.Int, 15, "HotelID");
            param.SourceVersion = DataRowVersion.Original;
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@contactDetails ", SqlDbType.NVarChar, 15, "contactDetails ");
            daMain.InsertCommand.Parameters.Add(param);

        }

        private void Build_INSERT_Parameters(Invoice invoice)
        {
            SqlParameter param = default(SqlParameter);
            param = new SqlParameter("@PaymentID  ", SqlDbType.NVarChar, 100, "PaymentID");
            param.SourceVersion = DataRowVersion.Current;
            daMain.InsertCommand.Parameters.Add(param);
            // 2.5.1 TO DO: -: Do for all fields other than ID and EMPID as for the Build Insert parameters. 
            //Ofcourse, depending on the role. The code is similar to the Build_INSERT_Parameters that you created
            param = new SqlParameter("@invoiceNumber", SqlDbType.Int, 10, "invoiceNumber");
            param.SourceVersion = DataRowVersion.Original;
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@Description", SqlDbType.NVarChar, 50, "Description");
            daMain.InsertCommand.Parameters.Add(param);

        }


        private void Build_INSERT_Parameters(Payment payment)
        {
            SqlParameter param = default(SqlParameter);
            param = new SqlParameter("@Type", SqlDbType.NVarChar, 100, "Type");
            param.SourceVersion = DataRowVersion.Current;
            daMain.InsertCommand.Parameters.Add(param);
            // 2.5.1 TO DO: -: Do for all fields other than ID and EMPID as for the Build Insert parameters. 
            //Ofcourse, depending on the role. The code is similar to the Build_INSERT_Parameters that you created
            param = new SqlParameter("@PaymentID", SqlDbType.NVarChar, 15, "PaymentID");
            param.SourceVersion = DataRowVersion.Original;
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@Date", SqlDbType.Date, 1, "Date");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@Description", SqlDbType.NVarChar, 50, "Description");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@Amount", SqlDbType.Money, 10, "Amount");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@employeeID ", SqlDbType.Int, 10, "employeeID ");
            daMain.InsertCommand.Parameters.Add(param);


        }


        private void Build_INSERT_Parameters(Room room)
        {
            SqlParameter param = default(SqlParameter);
            param = new SqlParameter("@Type", SqlDbType.NVarChar, 100, "Type");
            param.SourceVersion = DataRowVersion.Current;
            daMain.InsertCommand.Parameters.Add(param);
            // 2.5.1 TO DO: -: Do for all fields other than ID and EMPID as for the Build Insert parameters. 
            //Ofcourse, depending on the role. The code is similar to the Build_INSERT_Parameters that you created
            param = new SqlParameter("@roomNumber", SqlDbType.NVarChar, 15, "roomNumber");
            param.SourceVersion = DataRowVersion.Original;
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@Capacity", SqlDbType.Int, 1, "Capacity");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@Description", SqlDbType.NVarChar, 50, "Description");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@Cost", SqlDbType.Money, 10, "Cost");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@HotelID", SqlDbType.Int, 10, "HotelID");
            daMain.InsertCommand.Parameters.Add(param);


        }

        private void Create_INSERT_Command(Employee anEmp)
        {
            //Create the command that must be used to insert values into the Books table..   
            daMain.InsertCommand = new SqlCommand("INSERT into Runner (ID, EMPID, Name, Phone, Role, DayRate, NoOfShifts) VALUES (@ID, @EmpID, @Name, @Phone, @Role, @DayRate, @NoOfShifts)", cnMain);
            Build_INSERT_Parameters(anEmp);
        }

       
        
        public bool UpdateDataSource(object obj,string table)
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
