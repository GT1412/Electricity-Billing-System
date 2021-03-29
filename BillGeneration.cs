using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using DGVPrinterHelper;
using System.Drawing.Printing;

namespace ElectricityBilling
{
    public partial class BillGeneration : Form
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Dell\Documents\Databases\Electricity.accdb;");
        public BillGeneration()
        {
            InitializeComponent();
        }

        private void BillGeneration_Load(object sender, EventArgs e)
        {
            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                string date = Convert.ToDateTime(dateTimePicker1.Value).ToString("yyyy/MM");
                con.Open();
                OleDbCommand com = new OleDbCommand();
                com.Connection = con;
                string query = "Select * from reading where [Current_Date]";
                com.CommandText = query;
                OleDbDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {
                   cmbMeter_No.Items.Add(reader["Meter_No"].ToString());
                }
                con.Close();
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
        int Cus_ID;
        private void cmbMeter_No_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Cus_ID3; int cus_id;
            //try catch method:- 1.    *----READING-------*
            //Data retrived from reading table in ms access
            try
            {
                //int x = 0;
                string b;
                OleDbCommand command = new OleDbCommand();
                string querry = "Select top 3 * from reading Where [Meter_No] = " +cmbMeter_No.Text + " ";
                command = new OleDbCommand(querry, con);
                OleDbDataReader dr = null;
                con.Open();
                dr = command.ExecuteReader();
                while (dr.Read())
                {
                    lblLast_Date.Text = (dr["Last_Date"].ToString());
                   Cus_ID3 = (dr["Cus_ID"].ToString());
                   lblName.Text = (dr["Name"].ToString());
                   lblElectricity_Amount.Text = (dr["Electricity_Amount"].ToString());
                   lblService_Charge.Text = (dr["Service_Charge"].ToString());
                   lblTotal_Amount.Text = (dr["Total_Amount"].ToString());
                   lblTotal.Text = (dr["Total_Amount"].ToString());
                   lblCus_No.Text = Cus_ID3;
                   cus_id = Int32.Parse(Cus_ID3);
                   Cus_ID = cus_id;
                   lblCurrent_Reading.Text = (dr["Current_Reading"].ToString());
                   lblPrevious_Reading.Text = (dr["Previous_Reading"].ToString());
                   lblUnit.Text = (dr["Units"].ToString());
                   lblTotalUnit.Text = (dr["Units"].ToString());
                   lblUnit_Charge.Text = (dr["Unit_Charge"].ToString());
                }
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

            //New try catch method
            //Data retrived from unit table in ms access
            try
            {
                //int x = 0;
                string b;
                OleDbCommand command = new OleDbCommand();
                string query = "SELECT top 1 * FROM units order by [ID] desc ";
                command = new OleDbCommand(query, con);
                OleDbDataReader dr = null;
                con.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {

                    lblUnit_Date.Text = (reader["Date"].ToString());
                    lbl0.Text = (reader["0_100"].ToString());
                    lbl101.Text = (reader["101_300"].ToString());
                    lbl301.Text = (reader["301_500"].ToString());
                    lbl501.Text = (reader["501_1000"].ToString());
                    lbl1000.Text = (reader["Above_1000"].ToString());
                    lblFixed_Charge.Text = (reader["Fixed_Charge"].ToString());
                }
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
            //try catch method:- 3.
            //Data retrived from customer table in ms access
            try
            {
                //int x = 0;
                string b;
                OleDbCommand command = new OleDbCommand();
                string query = "SELECT * FROM customer where [Cus_ID] ="+Cus_ID+" ";
                command = new OleDbCommand(query, con);
                OleDbDataReader dr = null;
                con.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {

                   lblMobile.Text = (reader["Mob_No"].ToString());
                   lblEmail.Text = (reader["Email"].ToString());
                   lblState.Text = (reader["State"].ToString());
                }
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
            //try catch method:- 4.
            //Data retrived from cus_connection table in ms access
            try
            {
                OleDbCommand command = new OleDbCommand();
                string query = "SELECT * FROM cus_connection where [Meter_No] =" + cmbMeter_No.Text + " ";
                command = new OleDbCommand(query, con);
                OleDbDataReader dr = null;
                con.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    lblCon_Type.Text = (reader["Con_Type"].ToString());
                    lblPhase.Text = (reader["Phase"].ToString());
                    lblAddress.Text = (reader["Address"].ToString());
                }
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

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        public OleDbDataReader reader { get; set; }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Panel panel = new Panel();
            this.Controls.Add(panel);
            Graphics grp = panel.CreateGraphics();
            Size formSize = this.ClientSize;
            bitmap = new Bitmap(formSize.Width, formSize.Height, grp);
            grp = Graphics.FromImage(bitmap);
            Point panelLocation = PointToScreen(panel.Location);
            grp.CopyFromScreen(panelLocation.X, panelLocation.Y, 0, 0, formSize);
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.PrintPreviewControl.Zoom = 1;
            printPreviewDialog1.ShowDialog();
        }
        Bitmap bitmap;
        private void CaptureScreen()
        {
            Graphics myGraphics = this.CreateGraphics();
            Size s = this.Size;
            bitmap = new Bitmap(s.Width, s.Height, myGraphics);
            Graphics memoryGraphics = Graphics.FromImage(bitmap);
            memoryGraphics.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, s);
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bitmap, 0, 0); 
        }  
    }
}
