using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using PumlaKamnandi_Project.Business;
using System.Collections.ObjectModel;


namespace PumlaKamnandi_Project
{
    public partial class Form3 : Form
    {
        private CustomerController controller;
        private Booking booking;
        private Collection<Booking> bookings;
        public Form3()
        {
            InitializeComponent();
            Thread current = Thread.CurrentThread;
            Thread setUp = new Thread(setUpViewList);
            
;        }

        private void Form3_Load(object sender, EventArgs e)
        {
            
        }

        public void setUpViewList()
        {
            controller = new CustomerController();
            ReslistView.Clear();
            ReslistView.View = View.Details;
            ReslistView.Columns.Insert(0,"Reservation ID",30,HorizontalAlignment.Left);
            ReslistView.Columns.Insert(1, "Room number", 5, HorizontalAlignment.Left);
            ReslistView.Columns.Insert(2, "Check In Date", 30, HorizontalAlignment.Left);
            ReslistView.Columns.Insert(3, "Check out Date", 30, HorizontalAlignment.Left);
            ReslistView.Columns.Insert(4, "Description", 150, HorizontalAlignment.Left);
            ReslistView.Columns.Insert(5, "Total cost", 15, HorizontalAlignment.Left);
            ReslistView.Columns.Insert(6, "Employee ID", 15, HorizontalAlignment.Left);
            bookings = controller.Bookings;
            ListViewItem bookingList = new ListViewItem();
            foreach (Booking booking1 in bookings)
            {
                bookingList = new ListViewItem();
                bookingList.Text = Convert.ToString(booking.ReservationID);
                bookingList.SubItems.Add(Convert.ToString(booking1.RoomNumber));
                bookingList.SubItems.Add(booking1.CheckInDate);
                bookingList.SubItems.Add(booking1.CheckOutDate);
                bookingList.SubItems.Add(booking1.Description);
                bookingList.SubItems.Add(Convert.ToString(booking1.TotalCost));
                bookingList.SubItems.Add(Convert.ToString(booking1.EmployeeID));
                ReslistView.Items.Add(bookingList);
            }
            /*//listView.Items.Add(learnerDetails);
            searchTextBox.Clear();
            displayTextBox.Clear();*/
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ReslistPanel.Visible = false;
        }

        private void FillForm(Booking bkng)
        {
            ResnumtextBox.Text = Convert.ToString(bkng.ReservationID);
            CustomerIDtextBox.Text = Convert.ToString(bkng.CustomerID);//Forgot to add to database and Booking class
            roomNumtextBox.Text = Convert.ToString(bkng.RoomNumber);
            checkIncomboBox.Text = bkng.CheckInDate;
            checkoutcomboBox.Text = bkng.CheckOutDate;
            PricetextBox.Text = Convert.ToString(bkng.TotalCost);
        }
        private void ClearAll()
        {
            ResnumtextBox.Clear();
            CustomerIDtextBox.Clear();//Forgot to add to database and Booking class
            roomNumtextBox.Clear();
            checkIncomboBox.Text="";
            checkoutcomboBox.Text ="";
            PricetextBox.Clear(); ;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var exit = MessageBox.Show("Are sure you want to close this window?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (exit == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void clear_Click(object sender, EventArgs e)
        {

            var exit = MessageBox.Show("Are sure you want to clear form?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (exit == DialogResult.Yes)
            {
                ClearAll();
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            if (ReslistView.SelectedItems.Count > 0)
            {
                //MessageBox.Show("Selected: " + listView1.SelectedItems[0].Text);
                booking = controller.Find(Convert.ToInt32(ReslistView.SelectedItems[0].Text.Trim()), "Booking");
                if (booking != null)
                {
                    FillForm(booking);
                }
                else
                {
                    MessageBox.Show("Failed to get details!");
                }
            }
        }

        private void Cancelbutton_Click(object sender, EventArgs e)
        {
            var exit = MessageBox.Show("Are sure you want to cancel changes?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (exit == DialogResult.Yes)
            {
                ClearAll();
            }
        }

        private void Submitbutton_Click(object sender, EventArgs e)
        {
            var exit = MessageBox.Show("Are sure you want to close this window?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (exit == DialogResult.Yes)
            {
                booking = new Booking();
                booking.ReservationID = Convert.ToInt32(ResnumtextBox.Text);
                booking.CustomerID = CustomerIDtextBox.Text;
                booking.RoomNumber = Convert.ToInt32(roomNumtextBox.Text);
                booking.CheckInDate = checkIncomboBox.Text;
                booking.CheckOutDate = checkoutcomboBox.Text;
                booking.TotalCost = Convert.ToInt32(PricetextBox.Text);
                controller.DataMaintenance(booking, DataBase.DBOperation.Add);
                controller.FinalizeChanges(booking);
            }
            
            
        }
    }
}
