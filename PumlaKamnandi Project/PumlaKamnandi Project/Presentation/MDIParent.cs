using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PumlaKamnandi_Project.Business; 

namespace PumlaKamnandi_Project
{
    public partial class MDIParent : Form
    {
        private int childFormNumber = 0;

        customerForm cusForm;
        ReservationsForm reservationsForm;
        customerRegForm customerReg;
        CustomerController customerController;




        public MDIParent()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            customerController = new CustomerController();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ReservationsForm();
        }

        private void viewCustomersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new customerForm();
        }

        #region Create a New ChildForm  

        private void CreateNewReservationForm()
        {
            reservationsForm = new ReservationsForm();
            reservationsForm.MdiParent = this;
            reservationsForm.StartPosition = FormStartPosition.CenterParent;
        }

        private void CreateNewCustomerRegForm()
        {

            customerReg = new customerRegForm();
            customerReg.MdiParent = this;
            customerReg.StartPosition = FormStartPosition.CenterParent;
        }

        private void CreateNewCustomerForm()
        {

            cusForm = new customerForm();
            cusForm.MdiParent = this;
            cusForm.StartPosition = FormStartPosition.CenterParent;
        }
        #endregion



        private void addCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new customerRegForm();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (employeeListForm == null)
            {
                CreateNewReservationForm();
            }
            if (employeeListForm.listFormClosed)
            {
                CreateNewEmployeeListForm();
            }
          
            //7.3 write the code to call the setUpEmployeeListView method
            employeeListForm.setUpEmployeeListView();
            //7.4 write the code to show the employeeListForm form
            employeeListForm.Show();

        }

        private void resevationsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
