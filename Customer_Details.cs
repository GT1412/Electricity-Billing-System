using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace ElectricityBilling
{
    public partial class Customer_Details : Form
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Dell\Documents\Databases\Electricity.accdb;");
        public Customer_Details()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            
        }

        private void btnView_Click(object sender, EventArgs e)
        {
             try
            {
                con.Open();
                OleDbCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from customer";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                 OleDbDataAdapter da= new OleDbDataAdapter(cmd);
                 da.Fill(dt);
                 dataGridView1.DataSource =dt; 
                con.Close();
             
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }

        }
   }
}

