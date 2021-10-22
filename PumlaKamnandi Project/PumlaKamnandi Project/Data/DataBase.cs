using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using PumlaKamnandi_Project.Properties;
using System.Data;

namespace PumlaKamnandi_Project
{
    class DataBase
    {
        #region field declaration
        //private string strConn = Settings.Default.PhumlaKamnandiDatabaseConnectionString;
        private string strConn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\Lukhaya\source\repos\EliSih\Hotel_System-\PumlaKamnandi Project\PumlaKamnandi Project\PhumlaKamnandiDatabase.mdf';Integrated Security=True";
        protected SqlConnection cnMain;
        protected DataSet dsMain;
        protected SqlDataAdapter daMain;
        #endregion

        #region Constructor
        public DataBase()
        {
            try
            {
                cnMain = new SqlConnection(strConn);
                dsMain = new DataSet();
            }
            catch (SystemException e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message, "Error");
                return;
            }
        }

        #endregion
        public enum DBOperation
        {
            Add = 0,
            Edit = 1,
            Delete = 2
        }
        #region Update the DateSet
        public void FillDataSet(string aSQLstring, string aTable)
        {
         
            try
            {
                daMain = new SqlDataAdapter(aSQLstring, cnMain);
                cnMain.Open();
                //dsMain.Clear();
                daMain.Fill(dsMain, aTable);
                cnMain.Close();
            }
            catch (Exception errObj)
            {
                MessageBox.Show(errObj.Message + "  " + errObj.StackTrace);
            }
        }

        #endregion

        #region Update the data source 
        protected bool UpdateDataSource(string sqlLocal, string table)
        {
            bool success;
            try
            {
                //open the connection
                cnMain.Open();
                //update the database table via the data adapter
                daMain.Update(dsMain, table);
                //close the connection
                cnMain.Close();
                //refresh the dataset
                FillDataSet(sqlLocal, table);
                success = true;
            }
            catch (Exception errObj)
            {
                MessageBox.Show(errObj.Message + "  " + errObj.StackTrace);
                success = false;
            }
            finally
            {
            }
            return success;
        }
        #endregion
    }
}
