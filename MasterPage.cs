using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;

namespace ElectricityBilling
{
    public partial class MasterPage : Form
    {
        public MasterPage()
        {
            //Thread trd = new Thread(new ThreadStart(formRun));

            //trd.Start();
            //Thread.Sleep(5000);
            InitializeComponent();
            //trd.Abort();
        }
        //It can calling the Splash Form
        //private void formRun()
        //{
        //    Application.Run(new SplashForm());
        //}

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void MasterPage_Load(object sender, EventArgs e)
        {

        }

        private void createCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
               panelMain.Controls.Clear();
                Form1 f1 = new Form1();
                f1.TopLevel = false;
                panelMain.Controls.Add(f1);
                f1.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error"+ex);
            }
        }

        private void meterConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            Connection con = new Connection();
            con.TopLevel = false;
            panelMain.Controls.Add(con);
            con.Show();
           
           
        }

        private void unitChargeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            Units unit = new Units();
            unit.TopLevel = false;
            panelMain.Controls.Add(unit);
            unit.Show();
        }

        private void readingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            Reading reading = new Reading();
            reading.TopLevel = false;
            panelMain.Controls.Add(reading);
            reading.Show();
        }

        private void billPrintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            BillGeneration BillPrint = new BillGeneration();
            BillPrint.TopLevel = false;
            panelMain.Controls.Add(BillPrint);
            BillPrint.Show();
        }

        private void payAmountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            Payment pay = new Payment();
            pay.TopLevel = false;
            panelMain.Controls.Add(pay);
            pay.Show();
        }
    }
}
