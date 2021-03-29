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
    public partial class Reading : Form
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Dell\Documents\Databases\Electricity.accdb;");
        public Reading()
        {
            InitializeComponent();
        }

        private void Reading_Load(object sender, EventArgs e)
        {
            // when select name combo box then the table all names can displayed on that combo box
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
                    cmb_Meter.Items.Add(dr["Meter_No"].ToString());
                }
                con.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }
        int Pre_Reading1,Cus1;
        private void cmb_Meter_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Pre_Reading,Cus;

            //First Exception:
            //When we select Meter No then it will fill the Name and cus-ID textbox
            try
            {
                //int x = 0;
                string b;
                OleDbCommand command = new OleDbCommand();
                string querry = "Select * from cus_connection Where [Meter_No] = " + cmb_Meter.Text + " ";
                command = new OleDbCommand(querry, con);
                OleDbDataReader dr = null;
                con.Open();
                dr = command.ExecuteReader();
                while (dr.Read())
                {
                    txt_Name.Text = (dr["Name"].ToString());
                    b = (dr["Cus_ID"].ToString());
                    txtCus_ID.Text = b;
                    Cus = Convert.ToInt32(b);
                    Cus1 = Cus;
                    //select_value = (dr["Cus_ID"].ToString());
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
            //Second Exception:
            try
            {
                OleDbCommand command1 = new OleDbCommand();
                //query for retriving a last second data from meter no by ID
                    string querry1 = "SELECT top 1 * FROM reading where [Meter_No]=" + cmb_Meter.Text + " Order By [ID] desc";
                    command1 = new OleDbCommand(querry1, con);
                    OleDbDataReader dr1 = null;
                    con.Open();
                    dr1 = command1.ExecuteReader();
                    while (dr1.Read())
                    {
                         txtPre_Reading.Text = (dr1["Current_Reading"].ToString());
                         //dateTimePicker1.CustomFormat = (dr1["Current_Date"].ToString());
                    }
                    con.Close();
                }
            catch (Exception ex1)
            {
                MessageBox.Show("Error" + ex1);
            }
            finally
            {
                con.Close();
            }
            //retrive date by extending value
           try
           {

               con.Open();
               OleDbCommand command = new OleDbCommand();
               command.Connection = con;
               string query = "SELECT top 1 * FROM reading order by [ID] desc";
               command.CommandText = query;
               OleDbDataReader reader = command.ExecuteReader();
               if (reader.Read())
               {
                   txtsample.Text = (reader["Current_Date"].ToString());
                   //b = num;
               }
               //a = Convert.ToInt32(b);
               //a = a + 1;
               //txt_customerID.Text = a.ToString();
               con.Close();
           }
           catch (Exception ex)
           {
               MessageBox.Show("error " + ex);
           } 
        }
        
        // Save the data
      
        private void btn_Save_Click(object sender, EventArgs e)
        {
            
            try
            {
                con.Open();
                String Meter_No = cmb_Meter.Text.ToString();
                String Name = txt_Name.Text.ToString();
                String Cus_ID = txtCus_ID.Text.ToString();
                String Current_Date = dateTimePicker1.Text.ToString();
                String Last_Date = dateTimePicker2.Text.ToString();
                string Previous_Reading = txtPre_Reading.Text.ToString();
                String Curr_Reading = txtCurr_Reading.Text.ToString();
                String units = txt_Units.Text.ToString();
                String Consumption = txt_Consumption.Text.ToString();
                String Unit_Charge = txt_PerUnitCharge.Text.ToString();
                String Electricity_Amount = txt_ElectricityAmount.Text.ToString();
                String Service_Charge = txt_ServiceCharge.Text.ToString();
                String Total_Amount = txtTotal_Amount.Text.ToString();
                String my_querry = "INSERT INTO reading(Cus_ID,Name,Meter_No,[Current_Date],[Last_Date],Previous_Reading,Current_Reading,Units,Consumption,Unit_Charge,Electricity_Amount,Service_Charge,Total_Amount)VALUES('" + Cus_ID + "','" + Name + "','" + Meter_No + "','" + Current_Date + "','" + Last_Date + "','" + Previous_Reading + "','" + Curr_Reading + "','" + units + "','" + Consumption + "','" + Unit_Charge + "','" + Electricity_Amount + "','" + Service_Charge + "','" + Total_Amount + "')";

                OleDbCommand cmd = new OleDbCommand(my_querry, con);
                cmd.ExecuteNonQuery();

               
                MessageBox.Show("Data saved successfuly...!");
                cmb_Meter.Text = "";
                txt_Name.Clear();
                txtCus_ID.Clear();
                txtPre_Reading.Clear();
                txtCurr_Reading.Clear();
                txt_Units.Clear();
                txt_Consumption.Clear();
                txt_PerUnitCharge.Clear();
                txt_ElectricityAmount.Clear();
                txt_ServiceCharge.Clear();
                txtTotal_Amount.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed due to" + ex.Message);
            }
            finally
            {
                con.Close();
            }

        }
        //In this button All the calculation activity can performed in Button1

        //1. calculate Unit
        int unit,  Cur_Reading1,Fixed_Charge;
        float n0_100, n101_300, n301_500, n501_1000, above_1000;//Global veriable of units charges for calculation.
        private void button1_Click(object sender, EventArgs e)
        {
            int Fixed_Charge1;
            string n1, n2, n3, n4, n5,n6;
            float f1, f2, f3, f4, f5;
            double SurCharge,Total_Amount;
            float grandTotal,UnitCharge;
            Cur_Reading1 = int.Parse(txtCurr_Reading.Text);//assign textbox string value into Current Reading integer type
             int previous_reading = int.Parse(txtPre_Reading.Text);
            //............Calculation of Units................
            unit = Cur_Reading1 - previous_reading;
            txt_Units.Text =Convert.ToString (unit);
            txt_Consumption.Text = Convert.ToString(unit);
            try
            {
                //Retrive data from Units database
                con.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = con;
                string query = "SELECT top 1 * FROM units order by [ID] desc ";
                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    n6 = (reader["Fixed_Charge"].ToString());
                    n1 = (reader["0_100"].ToString());
                    n2 = (reader["101_300"].ToString());
                    n3 = (reader["301_500"].ToString());
                    n4 = (reader["501_1000"].ToString());
                    n5 = (reader["Above_1000"].ToString());
                    // Convert string value into float
                    f1 = float.Parse(n1);
                    f2 = float.Parse(n2);
                    f3 = float.Parse(n3);
                    f4 = float.Parse(n4);
                    f5 = float.Parse(n5);
                    Fixed_Charge1 = Int32.Parse(n6);
                    //Assign local veriable into Global veriable.
                    n0_100 = f1;
                    n101_300 = f2;
                    n301_500 = f3;
                    n501_1000 = f4;
                    above_1000 = f5;
                    Fixed_Charge = Fixed_Charge1;
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
            //.......Calculate Total Amount............
            if (unit > 0 && unit <= 100)
            {
                grandTotal = unit * n0_100;
                UnitCharge = n0_100;
            }
            else if (unit > 101 && unit <= 300)
            {
                grandTotal = unit * n101_300;
                UnitCharge = n101_300;
            }
            else if (unit > 301 && unit <= 500)
            {
                grandTotal = unit * n301_500;
                UnitCharge = n301_500;
            }
            else if (unit > 501 && unit <= 1000)
            {
                grandTotal = unit * n501_1000;
                UnitCharge = n501_1000;
            }
            else
            {
                grandTotal = unit * above_1000;
                UnitCharge = above_1000;
            }
            //.............Apply Surcharge............
            if (grandTotal > 0 && grandTotal < 300)
            {
                SurCharge =grandTotal * 2.7 / 100;
            }
            if (grandTotal > 301 && grandTotal < 1000)
            {
                SurCharge = grandTotal * 4.5  / 100;
            }
            if (grandTotal > 1001 && grandTotal < 3000)
            {
                SurCharge = grandTotal * 6.55 / 100;
            }
            if (grandTotal > 3001 && grandTotal < 7000)
            {
                SurCharge = grandTotal * 7.45 / 100;
            }
            if (grandTotal > 7001 && grandTotal < 15000)
            {
                SurCharge = grandTotal * 8.62 / 100;
            }
            if (grandTotal > 15001 && grandTotal < 25000)
            {
                SurCharge = grandTotal * 9.65 / 100;
            }
            if (grandTotal > 25001 && grandTotal < 50000)
            {
                SurCharge = grandTotal * 10.4 / 100;
            }
            if (grandTotal > 50001 && grandTotal < 150000)
            {
                SurCharge = grandTotal * 11.5 / 100;
            }
            else
            {
                SurCharge = grandTotal * 12.01 / 100;
            }
           Total_Amount =Fixed_Charge + grandTotal + SurCharge;
           double total = Math.Ceiling(Total_Amount);
           txt_ElectricityAmount.Text =Convert.ToString (grandTotal);
           double SurviceCharge = Math.Round(SurCharge,2);//convert double fractional value into two values only
           txt_ServiceCharge.Text = Convert.ToString (SurviceCharge);
           txtTotal_Amount.Text = Convert.ToString(total);
           txt_PerUnitCharge.Text = Convert.ToString(UnitCharge);
        }
       
        private void button2_Click(object sender, EventArgs e)
        {
           ////print the textbox contain
           // //if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
           // //{
           // //    printDocument1.Print();
           // //}
           // Panel panel = new Panel();
           // this.Controls.Add(panel);
           // Graphics grp = panel.CreateGraphics();
           // Size formSize = this.ClientSize;
           // bitmap = new Bitmap(formSize.Width, formSize.Height, grp);
           // grp = Graphics.FromImage(bitmap);
           // Point panelLocation = PointToScreen(panel.Location);
           // grp.CopyFromScreen(panelLocation.X, panelLocation.Y, 0, 0, formSize);
           // printPreviewDialog1.Document = printDocument1;
           // printPreviewDialog1.PrintPreviewControl.Zoom = 1;
           // printPreviewDialog1.ShowDialog();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime sdt = dateTimePicker1.Value.Date;
            DateTime edt = dateTimePicker2.Value.Date;
            TimeSpan ts = sdt - edt;
            int days = ts.Days;
            txtsample.Text = days.ToString();
        }

        //private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        //{
        //    //e.Graphics.DrawString(txt_Consumption.Text,new Font("Time new Romans",14, FontStyle.Bold),Brushes.Black, new PointF(100,100));
        //    //e.Graphics.DrawString("\n\t\t"+txt_ElectricityAmount.Text, new Font("Time new Romans", 15, FontStyle.Bold),Brushes.Gold,new PointF(100, 100));
        //    //e.Graphics.DrawString("\n\n" + txtCus_ID.Text, new Font("Time new Romans", 12, FontStyle.Bold), Brushes.YellowGreen, new PointF(100, 100));
        //    //e.Graphics.DrawString("\n\n" + txtCurr_Reading.Text, new Font("Time new Romans", 12, FontStyle.Bold), Brushes.ForestGreen, new PointF(100, 100));
        //    //e.Graphics.DrawString("\n\n" + txt_Name.Text, new Font("Time new Romans", 18, FontStyle.Bold), Brushes.GhostWhite, new PointF(100, 100));
        //    //e.Graphics.DrawString("\n\n" + txtPre_Reading.Text, new Font("Time new Romans", 14, FontStyle.Bold), Brushes.Gray, new PointF(100, 100));
        //    e.Graphics.DrawImage(bitmap, 0, 0);  
        ////}
        //Bitmap bitmap;
        //private void CaptureScreen()
        //{
        //    Graphics myGraphics = this.CreateGraphics();
        //    Size s = this.Size;
        //    bitmap = new Bitmap(s.Width, s.Height, myGraphics);
        //    Graphics memoryGraphics = Graphics.FromImage(bitmap);
        //    memoryGraphics.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, s);
        //}  
    }
}
