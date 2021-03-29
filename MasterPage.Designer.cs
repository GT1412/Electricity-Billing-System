namespace ElectricityBilling
{
    partial class MasterPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelSide = new System.Windows.Forms.Panel();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.panelFooter = new System.Windows.Forms.Panel();
            this.panelMain = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.customerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createCustomerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewCustomerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.meterConnectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unitChargeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unitChargeDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.billGenerateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.billPrintToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paymentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.payAmountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paymentDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelSide.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSide
            // 
            this.panelSide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.panelSide.Controls.Add(this.panel1);
            this.panelSide.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSide.Location = new System.Drawing.Point(0, 0);
            this.panelSide.Name = "panelSide";
            this.panelSide.Size = new System.Drawing.Size(163, 483);
            this.panelSide.TabIndex = 0;
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(25)))), ((int)(((byte)(62)))));
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(163, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(717, 48);
            this.panelHeader.TabIndex = 1;
            // 
            // panelFooter
            // 
            this.panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooter.Location = new System.Drawing.Point(163, 453);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Size = new System.Drawing.Size(717, 30);
            this.panelFooter.TabIndex = 2;
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(40)))), ((int)(((byte)(65)))));
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(163, 48);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(717, 405);
            this.panelMain.TabIndex = 3;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customerToolStripMenuItem,
            this.connectionToolStripMenuItem,
            this.unitToolStripMenuItem,
            this.billGenerateToolStripMenuItem,
            this.paymentToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(717, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // customerToolStripMenuItem
            // 
            this.customerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createCustomerToolStripMenuItem,
            this.viewCustomerToolStripMenuItem});
            this.customerToolStripMenuItem.Name = "customerToolStripMenuItem";
            this.customerToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.customerToolStripMenuItem.Text = "Customer";
            // 
            // createCustomerToolStripMenuItem
            // 
            this.createCustomerToolStripMenuItem.Name = "createCustomerToolStripMenuItem";
            this.createCustomerToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.createCustomerToolStripMenuItem.Text = "Create Customer";
            this.createCustomerToolStripMenuItem.Click += new System.EventHandler(this.createCustomerToolStripMenuItem_Click);
            // 
            // viewCustomerToolStripMenuItem
            // 
            this.viewCustomerToolStripMenuItem.Name = "viewCustomerToolStripMenuItem";
            this.viewCustomerToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.viewCustomerToolStripMenuItem.Text = "View Customer";
            // 
            // connectionToolStripMenuItem
            // 
            this.connectionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.meterConnectionToolStripMenuItem});
            this.connectionToolStripMenuItem.Name = "connectionToolStripMenuItem";
            this.connectionToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.connectionToolStripMenuItem.Text = "Connection";
            // 
            // meterConnectionToolStripMenuItem
            // 
            this.meterConnectionToolStripMenuItem.Name = "meterConnectionToolStripMenuItem";
            this.meterConnectionToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.meterConnectionToolStripMenuItem.Text = "Meter Connection";
            this.meterConnectionToolStripMenuItem.Click += new System.EventHandler(this.meterConnectionToolStripMenuItem_Click);
            // 
            // unitToolStripMenuItem
            // 
            this.unitToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.unitChargeToolStripMenuItem,
            this.unitChargeDetailsToolStripMenuItem});
            this.unitToolStripMenuItem.Name = "unitToolStripMenuItem";
            this.unitToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.unitToolStripMenuItem.Text = "Unit";
            // 
            // unitChargeToolStripMenuItem
            // 
            this.unitChargeToolStripMenuItem.Name = "unitChargeToolStripMenuItem";
            this.unitChargeToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.unitChargeToolStripMenuItem.Text = "Unit Charge";
            this.unitChargeToolStripMenuItem.Click += new System.EventHandler(this.unitChargeToolStripMenuItem_Click);
            // 
            // unitChargeDetailsToolStripMenuItem
            // 
            this.unitChargeDetailsToolStripMenuItem.Name = "unitChargeDetailsToolStripMenuItem";
            this.unitChargeDetailsToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.unitChargeDetailsToolStripMenuItem.Text = "Unit Charge Details";
            // 
            // billGenerateToolStripMenuItem
            // 
            this.billGenerateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.readingToolStripMenuItem,
            this.billPrintToolStripMenuItem});
            this.billGenerateToolStripMenuItem.Name = "billGenerateToolStripMenuItem";
            this.billGenerateToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
            this.billGenerateToolStripMenuItem.Text = "Bill Generate";
            // 
            // readingToolStripMenuItem
            // 
            this.readingToolStripMenuItem.Name = "readingToolStripMenuItem";
            this.readingToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.readingToolStripMenuItem.Text = "Reading";
            this.readingToolStripMenuItem.Click += new System.EventHandler(this.readingToolStripMenuItem_Click);
            // 
            // billPrintToolStripMenuItem
            // 
            this.billPrintToolStripMenuItem.Name = "billPrintToolStripMenuItem";
            this.billPrintToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.billPrintToolStripMenuItem.Text = "Bill Print";
            this.billPrintToolStripMenuItem.Click += new System.EventHandler(this.billPrintToolStripMenuItem_Click);
            // 
            // paymentToolStripMenuItem
            // 
            this.paymentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.payAmountToolStripMenuItem,
            this.paymentDetailsToolStripMenuItem});
            this.paymentToolStripMenuItem.Name = "paymentToolStripMenuItem";
            this.paymentToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.paymentToolStripMenuItem.Text = "Payment";
            // 
            // payAmountToolStripMenuItem
            // 
            this.payAmountToolStripMenuItem.Name = "payAmountToolStripMenuItem";
            this.payAmountToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.payAmountToolStripMenuItem.Text = "Pay Amount";
            this.payAmountToolStripMenuItem.Click += new System.EventHandler(this.payAmountToolStripMenuItem_Click);
            // 
            // paymentDetailsToolStripMenuItem
            // 
            this.paymentDetailsToolStripMenuItem.Name = "paymentDetailsToolStripMenuItem";
            this.paymentDetailsToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.paymentDetailsToolStripMenuItem.Text = "Payment Details";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(169, 54);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(708, 67);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel2.Controls.Add(this.menuStrip1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(163, 48);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(717, 25);
            this.panel2.TabIndex = 1;
            // 
            // MasterPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 483);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelFooter);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelSide);
            this.Name = "MasterPage";
            this.Text = "MasterPage";
            this.Load += new System.EventHandler(this.MasterPage_Load);
            this.panelSide.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSide;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem customerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createCustomerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewCustomerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem meterConnectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unitChargeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unitChargeDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem billGenerateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem readingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem billPrintToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paymentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem payAmountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paymentDetailsToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}