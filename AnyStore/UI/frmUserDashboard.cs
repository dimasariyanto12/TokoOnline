using AnyStore.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnyStore
{
    public partial class frmUserDashboard : Form
    {
        public frmUserDashboard()
        {
            InitializeComponent();
        }
        //Set a Public static methdod to spesify wheter the form is purchase or sales
        public static string transactionType;
        private void PnlFooter_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmUserDashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmLogin login = new frmLogin();
            login.Show();
            this.Hide();
        }

        private void FrmUserDashboard_Load(object sender, EventArgs e)
        {
            lblLoggedUser.Text = frmLogin.loggedIn;
        }

        private void DealerAndCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDeaCust DeaCust = new frmDeaCust();
            DeaCust.Show();
        }

        private void PurchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Set value on transactionType static method
            transactionType = "Purchase";
            frmPurchaseAndSales purchase = new frmPurchaseAndSales();
            purchase.Show();


        }

        private void SalesFormsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            transactionType = "Sales";
            frmPurchaseAndSales sales = new frmPurchaseAndSales();
            sales.Show();
       
        }

        private void InventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInventory inventory = new frmInventory();
            inventory.Show();
        }
    }
}
