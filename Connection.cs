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
    public partial class Connection : Form
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Dell\Documents\Databases\Electricity.accdb;");
        public Connection()
        {
            InitializeComponent();
        }

        private void Connection_Load(object sender, EventArgs e)
        {
            // when select name combo box then the table all names can displayed on that combo box
            try
            {
                con.Open();
                OleDbCommand com = new OleDbCommand();
                com.Connection = con;
                string query = "Select * from customer";
                com.CommandText = query;
                OleDbDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {
                    cmb_Name.Items.Add(reader["Name"].ToString());
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }

        private void cmb_Name_SelectedIndexChanged(object sender, EventArgs e)
        {
       /*When we select the combo box name then the given text box can be automatically
         fill up the data- like when we select name combo box then cusID, address and city will be automatically
         fill*/
            try
            {

                con.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = con;
                string query = "SELECT * FROM customer WHERE Name='" + cmb_Name.Text + "'";
                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    txt_CusID.Text = reader["Cus_ID"].ToString();
                    string address = reader["Address"].ToString();
                    string city = reader["City"].ToString();

                    // Concatenate the two string address and city in one textbox
                    txt_Address.Text = (address + ", " + city);
                }

        

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error " + ex);
            }
        }

        string b;
        private void btn_generateNo_Click(object sender, EventArgs e)
        {
            //Here we can auto generate Meter No
            string num;
            int a;
            try
            {
                con.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = con;
                string query = "SELECT top 1 * FROM cus_connection order by [Meter_No] desc";
                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    num = reader.GetValue(4).ToString();
                    b = num;
                }
                a = Convert.ToInt32(b);
                a = a + 1;
                txt_Meter.Text = a.ToString();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The custormer already exist"+ex);
            } 
        }
       
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // When select connection comboBox then phase txtbox can autofill into Single or Three phase connection:
            if (comboBox1.SelectedIndex == 0)
            {
                txt_Phase.Text = "Single";
            }
            else
            {
                txt_Phase.Text = "Three";
            }
                
            
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
                {
                    OleDbCommand cmd = con.CreateCommand();
                    con.Open();
                    cmd.CommandText = "Insert into cus_connection(Name,Cus_ID,Address,Meter_No,Con_Type,Phase) Values('" + cmb_Name.Text + "','"  +txt_CusID.Text + "','" + txt_Address.Text + "','" + txt_Meter.Text + "','" + comboBox1.Text + "','" + txt_Phase.Text + "')";
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer Created", "Successfully");
                    

                    //create text box empty process
                    cmb_Name.Text = "";
                    txt_CusID.Clear();
                    txt_Address.Clear();
                    txt_Meter.Clear();
                    comboBox1.Text = "";
                    txt_Phase.Clear();
                  

                    //connection was close from here
                    con.Close();
           
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex);
                }
            }
        }
    }

