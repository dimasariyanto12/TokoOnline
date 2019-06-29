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
    public partial class frmProuducts : Form
    {
        public frmProuducts()
        {
            InitializeComponent();
        }
        productsBLL p = new productsBLL();
        productsDAL dal = new productsDAL();

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            String keywords = txtSearchl.Text;
            if (keywords != null)
            {
                DataTable dt = dal.Search(keywords);
                dgvProducts.DataSource = dt;
            }
            else
            {
                DataTable dt = dal.Search(keywords);
                dgvProducts.DataSource = dt;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //Getiing Data from UI
            p.id = Convert.ToInt32(txtProductID.Text);
            p.name = txtName.Text;
            p.category = cmbCategory.Text;
            p.description = txtDescription.Text;
            p.rate = decimal.Parse(txtRate.Text);
            p.qty = 0;
            p.added_date = DateTime.Now;

            //Geting Username of logged in user
            string loggedUser = frmLogin.loggedIn;
            productsBLL usr = dal.GetIDFromUsername(loggedUser);
            p.added_by = usr.id;
          


            //Creatae booleaan to chec if the product is added successflly or not
            bool success = dal.Update(p);
            if (success == true)
            {
                //Product Inserted successfully
                MessageBox.Show("Product Update Successfully");
                Clear();
                DataTable dt = dal.Select();
                dgvProducts.DataSource = dt;
            }
            else
            {
                //Failed to ADD New Product
                MessageBox.Show("Failed to Update Product");
                Clear();
                DataTable dt = dal.Select();
                dgvProducts.DataSource = dt;
            }
        }

        private void PictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void BtnADD_Click(object sender, EventArgs e)
        {
            //Getiing Data from UI
            p.name = txtName.Text;
            p.category = cmbCategory.Text;
            p.description = txtDescription.Text;
            p.rate = decimal.Parse(txtRate.Text);
            p.qty = 0;
            p.added_date = DateTime.Now;

            //Geting Username of logged in user
            string loggedUser = frmLogin.loggedIn;
            productsBLL usr = dal.GetIDFromUsername(loggedUser);
            p.added_by = usr.id;


            //Creatae booleaan to chec if the product is added successflly or not
            bool success = dal.Insert(p);
            if (success == true)
            {
                //Product Inserted successfully
                MessageBox.Show("Product Added Successfully");
                Clear();
                DataTable dt = dal.Select();
                dgvProducts.DataSource = dt;
            }
            else
            {
                //Failed to ADD New Product
                MessageBox.Show("Failed to Add new Product");
                Clear();
                DataTable dt = dal.Select();
                dgvProducts.DataSource = dt;
            }
        }
        public void Clear()
        {
            txtProductID.Text = "";
            txtName.Text = "";
            txtDescription.Text = "";
            txtRate.Text = "";
            txtSearchl.Text = "";
        }

        private void DgvProducts_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Get the index of particular row
            int rowIndex = e.RowIndex;
            txtProductID.Text = dgvProducts.Rows[rowIndex].Cells[0].Value.ToString();
            txtName.Text = dgvProducts.Rows[rowIndex].Cells[1].Value.ToString();
            cmbCategory.Text = dgvProducts.Rows[rowIndex].Cells[2].Value.ToString();
            txtDescription.Text = dgvProducts.Rows[rowIndex].Cells[3].Value.ToString();
            txtRate.Text = dgvProducts.Rows[rowIndex].Cells[4].Value.ToString();

        }

        categoriesDAL cdal = new categoriesDAL();

        private void FrmProuducts_Load(object sender, EventArgs e)
        {
            DataTable dt = dal.Select();
            dgvProducts.DataSource = dt;
            //create data table to hold the categories from database
            DataTable categoriesDT = cdal.Select();
            //spesify DataSource for Category ComboBox
            cmbCategory.DataSource = categoriesDT;
            //Specifi  Display Member adn Value Member for combobox
            cmbCategory.DisplayMember = "title";
            cmbCategory.ValueMember = "title";

        }

        private void BtnDELETE_Click(object sender, EventArgs e)
        {
            //Delete Data From Database where id
            p.id = Convert.ToInt32(txtProductID.Text);
            bool success = dal.Delete(p);
            //if data is deleted then value of success will be true else it will be false
            if (success == true)
            {
                //User Deleted Successfully
                MessageBox.Show("Product deleted successfully");
                Clear();
            }
            else
            {
                //Failed to Delete User
                MessageBox.Show("Product to delete user");
            }
            //Refreshing Data Grid View
            DataTable dt = dal.Select();
            dgvProducts.DataSource = dt;
        }

    }
}

