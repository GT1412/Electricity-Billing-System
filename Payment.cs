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
    public partial class Payment : Form
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Dell\Documents\Databases\Electricity.accdb;");
        public Payment()
        {
            InitializeComponent();
        }

        private void Payment_Load(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                OleDbCommand com = new OleDbCommand();
                com.Connection = con;
                //com.CommandType = CommandType.Text();
                com.CommandText = "select * from cus_connection";
                //string query = "Select * from cus_connection";
                //com.CommandText = query;
                com.ExecuteNonQuery();
                DataTable dt = new DataTable();
                OleDbDataAdapter da = new OleDbDataAdapter(com);
                //OleDbDataReader reader = com.ExecuteReader();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    cmbMeter_No.Items.Add(dr["Meter_No"].ToString());
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }

        private void cmbMeter_No_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                OleDbCommand command = new OleDbCommand();
                string querry = "Select top 1 * from reading Where [Meter_No] = " + cmbMeter_No.Text + " order by [ID] desc";
                command = new OleDbCommand(querry, con);
                OleDbDataReader dr = null;
                con.Open();
                dr = command.ExecuteReader();
                while (dr.Read())
                {
                    txtPay_Date.Text = (dr["Current_Date"].ToString());
                    txtLast_Date.Text = (dr["Last_Date"].ToString());
                    txtCurr_Reading.Text = (dr["Current_Reading"].ToString());
                    txtUnits.Text = (dr["Units"].ToString());
                    txtElectricity_Amount.Text = (dr["Electricity_Amount"].ToString());
                    txtService_Charge.Text = (dr["Service_Charge"].ToString());
                    txtTotal_Amount.Text = (dr["Total_Amount"].ToString());
                }
                //select_value = cmb_Meter.Text;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error " + ex);
            }
            finally
            {
                con.Close();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0 || comboBox1.SelectedIndex == 1 ||comboBox1.SelectedIndex == 2||comboBox1.SelectedIndex==3||comboBox1.SelectedIndex==4||comboBox1.SelectedIndex==5 )
            {
                txtStatus.Text = "Paid";
            }
            else
            {
                txtStatus.Text = "Not Paid";
            }
        }

        private void txtStatus_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}