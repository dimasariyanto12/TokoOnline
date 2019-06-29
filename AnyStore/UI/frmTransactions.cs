using AnyStore.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnyStore.UI
{
    public partial class frmTransactions : Form
    {
        public frmTransactions()
        {
            InitializeComponent();
        }
        transactionDAL tdal = new transactionDAL();
        private void LblTop_Click(object sender, EventArgs e)
        {

        }

        private void PictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void FrmTransactions_Load(object sender, EventArgs e)
        {
            //Display all the transactions 
            DataTable dt = tdal.DisplayAllTransaction();
            dgvTransactions.DataSource = dt;
        }

        private void CmbTransactionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Get the value from combobox
            string type = cmbTransactionType.Text;

            DataTable dt = tdal.DisplayTransactionByType(type);
            dgvTransactions.DataSource = dt;
        }

        private void BtnAll_Click(object sender, EventArgs e)
        {
            //Display all the transactions
            DataTable dt = tdal.DisplayAllTransaction();
            dgvTransactions.DataSource = dt;
        }
    }
}
