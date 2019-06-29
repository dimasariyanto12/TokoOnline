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
    public partial class frmCategories : Form
    {
        public frmCategories()
        {
            InitializeComponent();
        }
        categoriesBLL c= new categoriesBLL();
        categoriesDAL dal = new categoriesDAL();

        private void BtnADD_Click(object sender, EventArgs e)
        {
            //Getting Data From UI
            c.title = txtTitle.Text;
            c.description = txtDescription.Text;
            c.added_date = DateTime.Now;
         

            //Getting Username of the logged in user
            string loggedUser = frmLogin.loggedIn;

            categoriesBLL usr = dal.GetIDFromUsername(loggedUser);
            c.added_by = usr.id;

            //Inserting Data Into Database
            bool success = dal.Insert(c);
            //if the Data is Successfully Inserted then the value of success will be true else it will be false
            if (success == true)
            {
                //Datta Successfully Inserted
                MessageBox.Show("Category successfully created");
                Clear();
            }
            else
            {
                //Data Failed Inserted
                MessageBox.Show("Category to add new user");
            }
            //Refreshing Data Grid View
            DataTable dt = dal.Select();
            dgvCategories.DataSource = dt;

        
    }

        private void PictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void FrmCategories_Load(object sender, EventArgs e)
        {
            DataTable dt = dal.Select();
            dgvCategories.DataSource = dt;
        }
        private void Clear()
        {
            txtCategoryID.Text = "";
            txtTitle.Text = "";
            txtDescription.Text = "";
            

        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            //Delete Data From Database where id
            c.id = Convert.ToInt32(txtCategoryID.Text);
            bool success = dal.Delete(c);
            //if data is deleted then value of success will be true else it will be false
            if (success == true)
            {
                //User Deleted Successfully
                MessageBox.Show("Category deleted successfully");
                Clear();
            }
            else
            {
                //Failed to Delete User
                MessageBox.Show("Failed to delete Category");
            }
            //Refreshing Data Grid View
            DataTable dt = dal.Select();
            dgvCategories.DataSource = dt;
        }


        private void DgvCategories_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Get the index of particular row
            int rowIndex = e.RowIndex;
            txtCategoryID.Text = dgvCategories.Rows[rowIndex].Cells[0].Value.ToString();
            txtTitle.Text = dgvCategories.Rows[rowIndex].Cells[1].Value.ToString();
            txtDescription.Text = dgvCategories.Rows[rowIndex].Cells[2].Value.ToString();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            //Get the values from User UI
            c.id = Convert.ToInt32(txtCategoryID.Text);
            c.title = txtTitle.Text;
            c.description = txtDescription.Text;
            c.added_date = DateTime.Now;

            //Getting Username of the logged in user
            string loggedUser = frmLogin.loggedIn;

            categoriesBLL usr = dal.GetIDFromUsername(loggedUser);
            c.added_by = usr.id;

            //Updatinf Data in Database
            bool success = dal.Update(c);
            //if data is update successfully the value of success will be true else it will be false
            if (success == true)
            {
                //Data Update Successfully
                MessageBox.Show("Category success updated");
                Clear();
            }
            else
            {
                //Failed to Update user
                MessageBox.Show("Failed to Update Category");
            }
            //Refreshing Data Grid View
            DataTable dt = dal.Select();
            dgvCategories.DataSource = dt;
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            //Get keywords from textbox
            string keywords = txtSearch.Text;

            //Check if the keywords has value or not
            if (keywords != null)
            {
                //show user based on keywords
                DataTable dt = dal.Search(keywords);
                dgvCategories.DataSource = dt;

            }
            else
            {
                //show all user fro databse
                DataTable dt = dal.Select();
                dgvCategories.DataSource = dt;
            }
        }
    }
}
