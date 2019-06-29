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
    public partial class frmUsers : Form
    {
        public frmUsers()
        {
            InitializeComponent();
        }
        userBLL u = new userBLL();
        userDAL dal = new userDAL();
       

        private void PictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void LblSearch_Click(object sender, EventArgs e)
        {

        }

        private void FrmUsers_Load(object sender, EventArgs e)
        {
            DataTable dt = dal.Select();
            dgvUsers.DataSource = dt;

        }
        private void Clear()
        {
            txtUserID.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtContact.Text = "";
            txtAddress.Text = "";
            cmbGender.Text = "";
            cmbUserType.Text = "";
            
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
           
            //Getting Data From UI
            u.first_name = txtFirstName.Text;
            u.last_name = txtLastName.Text;
            u.email = txtEmail.Text;
            u.username = txtUsername.Text;
            u.password = txtPassword.Text;
            u.contact = txtContact.Text;
            u.address = txtAddress.Text;
            u.gender = cmbGender.Text;
            u.user_type = cmbUserType.Text;
            u.added_date = DateTime.Now;

            //Getting Username of the logged in user
            string loggedUser = frmLogin.loggedIn;

            userBLL usr = dal.GetIDFromUsername(loggedUser);
            u.added_by =usr.id;

            //Inserting Data Into Database
            bool success = dal.Insert(u);
            //if the Data is Successfully Inserted then the value of success will be true else it will be false
            if (success==true)
            {
                //Datta Successfully Inserted
                MessageBox.Show("User successfully created");
                Clear();
            }
            else
            {
                //Data Failed Inserted
                MessageBox.Show("Failed to add new user");
            }
            //Refreshing Data Grid View
            DataTable dt = dal.Select();
            dgvUsers.DataSource = dt;

        }

        private void DgvUsers_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Get the index of particular row
            int rowIndex = e.RowIndex;
            txtUserID.Text = dgvUsers.Rows[rowIndex].Cells[0].Value.ToString();
            txtFirstName.Text = dgvUsers.Rows[rowIndex].Cells[1].Value.ToString();
            txtLastName.Text = dgvUsers.Rows[rowIndex].Cells[2].Value.ToString();
            txtEmail.Text = dgvUsers.Rows[rowIndex].Cells[3].Value.ToString();
            txtUsername.Text = dgvUsers.Rows[rowIndex].Cells[4].Value.ToString();
            txtPassword.Text = dgvUsers.Rows[rowIndex].Cells[5].Value.ToString();
            txtContact.Text = dgvUsers.Rows[rowIndex].Cells[6].Value.ToString();
            txtAddress.Text = dgvUsers.Rows[rowIndex].Cells[7].Value.ToString();
            cmbGender.Text = dgvUsers.Rows[rowIndex].Cells[8].Value.ToString();
            cmbUserType.Text = dgvUsers.Rows[rowIndex].Cells[9].Value.ToString();

        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            //Get the values from User UI
            u.id = Convert.ToInt32(txtUserID.Text);
            u.first_name = txtFirstName.Text;
            u.last_name = txtLastName.Text;
            u.username = txtUsername.Text;
            u.email = txtEmail.Text;
            u.username = txtUsername.Text;
            u.password = txtPassword.Text;
            u.contact = txtContact.Text;
            u.address = txtAddress.Text;
            u.gender = cmbGender.Text;
            u.user_type = cmbUserType.Text;
            u.added_date = DateTime.Now;
            
            //Getting Username of the logged in user
            string loggedUser = frmLogin.loggedIn;

            userBLL usr = dal.GetIDFromUsername(loggedUser);
            u.added_by = usr.id;


            //Updatinf Data in Database
            bool success = dal.Update(u);
            //if data is update successfully the value of success will be true else it will be false
            if (success==true)
            {
                //Data Update Successfully
                MessageBox.Show("User success updated");
                Clear();
            }
            else
            {
                //Failed to Update user
                MessageBox.Show("Failed to Update User");
            }
            //Refreshing Data Grid View
            DataTable dt = dal.Select();
            dgvUsers.DataSource = dt;
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            //Delete Data From Database where id
            u.id = Convert.ToInt32(txtUserID.Text);
            bool success = dal.Delete(u);
            //if data is deleted then value of success will be true else it will be false
            if (success==true)
            {
                //User Deleted Successfully
                MessageBox.Show("User deleted successfully");
                Clear();
            }
            else
            {
                //Failed to Delete User
                MessageBox.Show("Failed to delete user");
            }
            //Refreshing Data Grid View
            DataTable dt = dal.Select();
            dgvUsers.DataSource = dt;
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            //Get keywords from textbox
            string keywords = txtSearch.Text;

            //Check if the keywords has value or not
            if (keywords!=null)
            {
                //show user based on keywords
                DataTable dt = dal.Search(keywords);
                dgvUsers.DataSource = dt;

            }
            else
            {
                //show all user fro databse
                DataTable dt = dal.Select();
                dgvUsers.DataSource = dt;
            }
        }

        private void DgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
