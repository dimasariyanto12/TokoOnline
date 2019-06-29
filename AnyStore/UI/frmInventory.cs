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
    public partial class frmInventory : Form
    {
        public frmInventory()
        {
            InitializeComponent();
        }
        categoriesDAL cdal = new categoriesDAL();
        productsDAL pdal = new productsDAL();

        private void BtnAll_Click(object sender, EventArgs e)
        {
            //Display all the Product when this button is cliked
            DataTable dt = pdal.Select();
            dgvProducts.DataSource = dt; 
        }

        private void PictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void FrmInventory_Load(object sender, EventArgs e)
        {
            //Display the categories in Combox
            DataTable cdt = cdal.Select();

            cmbCategories.DataSource = cdt;

            //Give the value member  and display member for combobox
            cmbCategories.DisplayMember = "title";
            cmbCategories.ValueMember = "title";

            //Display all the products in Datagrid view then form is load
            DataTable pdt = pdal.Select();
            dgvProducts.DataSource=pdt;
        }

        private void CmbCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Display all the Product Based on selected Category

            string category = cmbCategories.Text;

            DataTable dt = pdal.DisplayProductsByCategory(category);
            dgvProducts.DataSource = dt;
        }
    }
}
