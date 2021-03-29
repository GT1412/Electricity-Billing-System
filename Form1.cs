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
    public partial class Form1 : Form
    {

        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Dell\Documents\Databases\Electricity.accdb;");
       int n;
        public Form1()
        {
            InitializeComponent();
            
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_customerID.Text==""||txtName.Text == "" || txtAddress.Text == "" || cmbState.Text == "" || txtCity.Text == "" || txtEmail.Text == "" || txtMobile.Text == "")
            {
                MessageBox.Show("Fill all Entries");
            }
            else
            {
                try
                {
                    

                    OleDbCommand cmd = con.CreateCommand();
                    con.Open();
                    cmd.CommandText = "Insert into customer(Cus_ID,Name,Address,State,City,Email,Mob_No) Values('" + txt_customerID.Text + "','"  +txtName.Text + "','" + txtAddress.Text + "','" + cmbState.Text + "','" + txtCity.Text + "','" + txtEmail.Text + "','" + txtMobile.Text + "')";
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer Created", "Successfully");
                    

                    //create text box empty process
                    txt_customerID.Clear();
                    txtName.Clear();
                    txtAddress.Clear();
                    cmbState.Text = "";
                    txtCity.Clear();
                    txtEmail.Clear();
                    txtMobile.Clear();

                    //connection was close from here
                    con.Close();
           
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex);
                }
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Customer_Details Customer = new Customer_Details();
            Customer.Show();
        }



        public System.Windows.Forms.DialogResult None { get; set; }

        private void txtMobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            //when we click mobile no text box, It will only accept a number
            char ch = e.KeyChar;

            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

      
        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            //It will only accept character and Space button not any number.
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsSeparator(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        string b;
        private void btn_New_Click(object sender, EventArgs e)
        {
            //Generate customer ID of sequential number 
            //Call this ID into a database of last column of enter data will call.
            string num;
            int a;
            try
            {

                con.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = con;
                string query = "SELECT top 1 * FROM customer order by [Cus_ID] desc";
                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    num = reader.GetValue(0).ToString();
                    b = num;
                }
                a = Convert.ToInt32(b);
                a = a + 1;
                txt_customerID.Text = a.ToString();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error " + ex);
            } 
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // When select State comboBox then city txtbox can autofill:
            if (cmbState.SelectedIndex == 0)
            {
               txtCity.Text = "Chandrapur";
            }
        }
        
    }
}
