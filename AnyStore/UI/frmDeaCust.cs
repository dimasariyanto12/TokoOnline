using AnyStore.BLL;
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
    public partial class frmDeaCust : Form
    {
        public frmDeaCust()
        {
            InitializeComponent();
        }
        DeaCustBLL d = new DeaCustBLL();
        DeaCustDAL dal = new DeaCustDAL();
        private void LblDescreption_Click(object sender, EventArgs e)
        {

        }

        private void PictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void CmbType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void Clear()
        {
            txtDeaCustID.Text = "";
            txtName.Text = "";
            txtEmail.Text = "";
            txtContact.Text = "";
            txtAddress.Text = "";
            txtSearch.Text = "";
        }

        private void BtnADD_Click(object sender, EventArgs e)
        {
            d.type = cmbType.Text;
            d.name = txtName.Text;
            d.email = txtEmail.Text;
            d.contact = txtContact.Text;
            d.address = txtAddress.Text;
            d.added_date = DateTime.Now;
            //Geting Username of logged in user
            string loggedUser = frmLogin.loggedIn;
            DeaCustBLL usr = dal.GetIDFromUsername(loggedUser);
            d.added_by = usr.id;

            //Creatae boolean to chec if the product is added successflly or not
            bool success = dal.Insert(d);
            if (success == true)
            {
                //Product Inserted successfully
                MessageBox.Show("Data Added Successfully");
                Clear();
                DataTable dt = dal.Select();
                dgvDeaCust.DataSource = dt;
            }
            else
            {
                //Failed to ADD New Product
                MessageBox.Show("Failed to Add new Data");
                Clear();
                DataTable dt = dal.Select();
                dgvDeaCust.DataSource = dt;
            }
        }

        private void FrmDeaCust_Load(object sender, EventArgs e)
        {
            DataTable dt = dal.Select();
            dgvDeaCust.DataSource = dt;
        }

        private void DgvDeaCust_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            txtDeaCustID.Text = dgvDeaCust.Rows[rowIndex].Cells[0].Value.ToString();
            cmbType.Text = dgvDeaCust.Rows[rowIndex].Cells[1].Value.ToString();
            txtName.Text = dgvDeaCust.Rows[rowIndex].Cells[2].Value.ToString();
            txtEmail.Text = dgvDeaCust.Rows[rowIndex].Cells[3].Value.ToString();
            txtContact.Text = dgvDeaCust.Rows[rowIndex].Cells[4].Value.ToString();
            txtAddress.Text = dgvDeaCust.Rows[rowIndex].Cells[5].Value.ToString();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            d.id = Convert.ToInt32(txtDeaCustID.Text);
            d.type = cmbType.Text;
            d.name = txtName.Text;
            d.email = txtEmail.Text;
            d.contact = txtContact.Text;
            d.address = txtAddress.Text;
            d.added_date = DateTime.Now;
            //Geting Username of logged in user
            string loggedUser = frmLogin.loggedIn;
            DeaCustBLL usr = dal.GetIDFromUsername(loggedUser);
            d.added_by = usr.id;


            //Creatae booleaan to chec if the product is added successflly or not
            bool success = dal.Update(d);
            if (success == true)
            {
                //Product Inserted successfully
                MessageBox.Show("Data Update Successfully");
                Clear();
                DataTable dt = dal.Select();
                dgvDeaCust.DataSource = dt;
            }
            else
            {
                //Failed to ADD New Product
                MessageBox.Show("Data to Update Product");
                Clear();
                DataTable dt = dal.Select();
                dgvDeaCust.DataSource = dt;
            }
        }

        private void BtnDELETE_Click(object sender, EventArgs e)
        {
            d.id = Convert.ToInt32(txtDeaCustID.Text);
            bool success = dal.Delete(d);
            //if data is deleted then value of success will be true else it will be false
            if (success == true)
            {
                //User Deleted Successfully
                MessageBox.Show("Data deleted successfully");
                Clear();
            }
            else
            {
                //Failed to Delete User
                MessageBox.Show("Dailed Data to deleted");
            }
            //Refreshing Data Grid View
            DataTable dt = dal.Select();
            dgvDeaCust.DataSource = dt;
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            String keywords = txtSearch.Text;
            if (keywords != null)
            {
                DataTable dt = dal.Search(keywords);
                dgvDeaCust.DataSource = dt;
            }
            else
            {
                DataTable dt = dal.Search(keywords);
                dgvDeaCust.DataSource = dt;
            }
        }
    }
}

