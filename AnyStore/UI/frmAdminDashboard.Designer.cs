namespace AnyStore
{
    partial class frmAdminDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdminDashboard));
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStripTop = new System.Windows.Forms.MenuStrip();
            this.userToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.categoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dealerAndCustomerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inventoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transactionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblLoggedInUser = new System.Windows.Forms.Label();
            this.lblAppFName = new System.Windows.Forms.Label();
            this.lblLName = new System.Windows.Forms.Label();
            this.lblSHead = new System.Windows.Forms.Label();
            this.pnlFooter.SuspendLayout();
            this.menuStripTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.Teal;
            this.pnlFooter.Controls.Add(this.label1);
            resources.ApplyResources(this.pnlFooter, "pnlFooter");
            this.pnlFooter.ForeColor = System.Drawing.SystemColors.ControlText;
            this.pnlFooter.Name = "pnlFooter";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label1.Name = "label1";
            // 
            // menuStripTop
            // 
            this.menuStripTop.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStripTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userToolStripMenuItem,
            this.categoryToolStripMenuItem,
            this.productToolStripMenuItem,
            this.dealerAndCustomerToolStripMenuItem,
            this.inventoryToolStripMenuItem,
            this.transactionsToolStripMenuItem});
            resources.ApplyResources(this.menuStripTop, "menuStripTop");
            this.menuStripTop.Name = "menuStripTop";
            // 
            // userToolStripMenuItem
            // 
            this.userToolStripMenuItem.Name = "userToolStripMenuItem";
            resources.ApplyResources(this.userToolStripMenuItem, "userToolStripMenuItem");
            this.userToolStripMenuItem.Click += new System.EventHandler(this.UserToolStripMenuItem_Click);
            // 
            // categoryToolStripMenuItem
            // 
            this.categoryToolStripMenuItem.Name = "categoryToolStripMenuItem";
            resources.ApplyResources(this.categoryToolStripMenuItem, "categoryToolStripMenuItem");
            this.categoryToolStripMenuItem.Click += new System.EventHandler(this.CategoryToolStripMenuItem_Click);
            // 
            // productToolStripMenuItem
            // 
            this.productToolStripMenuItem.Name = "productToolStripMenuItem";
            resources.ApplyResources(this.productToolStripMenuItem, "productToolStripMenuItem");
            this.productToolStripMenuItem.Click += new System.EventHandler(this.ProductToolStripMenuItem_Click);
            // 
            // dealerAndCustomerToolStripMenuItem
            // 
            this.dealerAndCustomerToolStripMenuItem.Name = "dealerAndCustomerToolStripMenuItem";
            resources.ApplyResources(this.dealerAndCustomerToolStripMenuItem, "dealerAndCustomerToolStripMenuItem");
            this.dealerAndCustomerToolStripMenuItem.Click += new System.EventHandler(this.DealerAndCustomerToolStripMenuItem_Click);
            // 
            // inventoryToolStripMenuItem
            // 
            this.inventoryToolStripMenuItem.Name = "inventoryToolStripMenuItem";
            resources.ApplyResources(this.inventoryToolStripMenuItem, "inventoryToolStripMenuItem");
            this.inventoryToolStripMenuItem.Click += new System.EventHandler(this.InventoryToolStripMenuItem_Click);
            // 
            // transactionsToolStripMenuItem
            // 
            this.transactionsToolStripMenuItem.Name = "transactionsToolStripMenuItem";
            resources.ApplyResources(this.transactionsToolStripMenuItem, "transactionsToolStripMenuItem");
            this.transactionsToolStripMenuItem.Click += new System.EventHandler(this.TransactionsToolStripMenuItem_Click);
            // 
            // lblUser
            // 
            resources.ApplyResources(this.lblUser, "lblUser");
            this.lblUser.Name = "lblUser";
            this.lblUser.Click += new System.EventHandler(this.LblUser_Click);
            // 
            // lblLoggedInUser
            // 
            resources.ApplyResources(this.lblLoggedInUser, "lblLoggedInUser");
            this.lblLoggedInUser.ForeColor = System.Drawing.Color.Lime;
            this.lblLoggedInUser.Name = "lblLoggedInUser";
            // 
            // lblAppFName
            // 
            resources.ApplyResources(this.lblAppFName, "lblAppFName");
            this.lblAppFName.Name = "lblAppFName";
            // 
            // lblLName
            // 
            resources.ApplyResources(this.lblLName, "lblLName");
            this.lblLName.Name = "lblLName";
            // 
            // lblSHead
            // 
            resources.ApplyResources(this.lblSHead, "lblSHead");
            this.lblSHead.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.lblSHead.Name = "lblSHead";
            // 
            // frmAdminDashboard
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblSHead);
            this.Controls.Add(this.lblLName);
            this.Controls.Add(this.lblAppFName);
            this.Controls.Add(this.lblLoggedInUser);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.menuStripTop);
            this.MainMenuStrip = this.menuStripTop;
            this.Name = "frmAdminDashboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmAdminDashboard_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.menuStripTop.ResumeLayout(false);
            this.menuStripTop.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStripTop;
        private System.Windows.Forms.ToolStripMenuItem userToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem categoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inventoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transactionsToolStripMenuItem;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblLoggedInUser;
        private System.Windows.Forms.Label lblAppFName;
        private System.Windows.Forms.Label lblLName;
        private System.Windows.Forms.Label lblSHead;
        private System.Windows.Forms.ToolStripMenuItem dealerAndCustomerToolStripMenuItem;
    }
}

