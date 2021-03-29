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
    public partial class Units : Form
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Dell\Documents\Databases\Electricity.accdb;");
        public Units()
        {
            InitializeComponent();
        }
        float n0_100, n101_300, n301_500, n501_1000, above_1000;
        public void Unit_Charge()
        {
            n0_100 = float.Parse (txt0_100.Text);
            n101_300 = float.Parse(txt101_300.Text);
            n301_500 = float.Parse(txt301_500.Text);
            n501_1000 = float.Parse(txt501_1000.Text);
            above_1000 = float.Parse(txtAbove1000.Text);
        }
        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbCommand cmd = con.CreateCommand();
                con.Open();
                cmd.CommandText = "Insert into units([Date],0_100,101_300,301_500,501_1000,Above_1000) Values('" + dateTimePicker1.Text + "','" + txt0_100.Text + "','" + txt101_300.Text + "','" + txt301_500.Text + "','" + txt501_1000.Text + "','" + txtAbove1000.Text + "')";
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Customer Created", "Successfully");
                //connection was close from here
                //con.Close();

                ////Second Save method
                //con.Open();
                //String Meter_No = cmb_Meter.Text.ToString();
                //String Name = txt_Name.Text.ToString();
                //String Cus_ID = txtCus_ID.Text.ToString();
                //String Date = dateTimePicker1.Text.ToString();
                //String Reading = txtCurr_Reading.Text.ToString();
                //String units = txt_Units.Text.ToString();
                //String my_querry = "INSERT INTO reading(Cus_ID,Name,Meter_No,[Date],Current_Reading,Units)VALUES('" + Cus_ID + "','" + Name + "','" + Meter_No + "','" + Date + "','" + Reading + "','" + units + "')";

                //OleDbCommand cmd = new OleDbCommand(my_querry, con);
                //cmd.ExecuteNonQuery();

                //MessageBox.Show("Data saved successfuly...!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
            finally
            {
                con.Close();
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                string dateTime = dateTimePicker1.Text.ToString();
                con.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = con;
                string query = "SELECT * FROM reading WHERE Date='" + dateTime + "'";
                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                   txt0_100.Text = reader["0_100"].ToString();
                }



                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error " + ex);
            }
        }

        private void Units_Load(object sender, EventArgs e)
        {

        }
    }
}
