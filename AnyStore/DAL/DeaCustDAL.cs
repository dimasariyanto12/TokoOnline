using AnyStore.BLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnyStore.DAL
{
    class DeaCustDAL
    {
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        #region Method Select 
        public DataTable Select()
        {
          
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();

            try
            {
                String sql = "select * from tbl_dea_cust";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }
        #endregion

        #region Insert New Dealer and Customer
        public bool Insert(DeaCustBLL d)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                String sql = "INSERT INTO tbl_dea_cust (type,name,email,contact,address,added_date,added_by) values (@type,@name,@email,@contact,@address,@added_date,@added_by) ";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@type", d.type);
                cmd.Parameters.AddWithValue("@name", d.name);
                cmd.Parameters.AddWithValue("@email", d.email);
                cmd.Parameters.AddWithValue("@contact", d.contact);
                cmd.Parameters.AddWithValue("@address", d.address);
                cmd.Parameters.AddWithValue("@added_date", d.added_date);
                cmd.Parameters.AddWithValue("@added_by", d.added_by);

                conn.Open();

                int rows = cmd.ExecuteNonQuery();

                //if the  query is execute Successfully then ethe value to rows will be greater than 0 else it will be less than 0
                if (rows > 0)
                {
                    //Query Successfuly
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }

        #endregion

        #region Update Data Dealer and Customer in Database

        public bool Update(DeaCustBLL d)
        {
            bool isSucces = false;
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                String sql = "update tbl_dea_cust set type=@type,name=@name, email=@email, contact=@contact, address=@address, added_date=@added_date, added_by=@added_by where id=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@type", d.type);
                cmd.Parameters.AddWithValue("@name", d.name);
                cmd.Parameters.AddWithValue("@email", d.email);
                cmd.Parameters.AddWithValue("@contact", d.contact);
                cmd.Parameters.AddWithValue("@address", d.address);
                cmd.Parameters.AddWithValue("@added_date", d.added_date);
                cmd.Parameters.AddWithValue("@added_by", d.added_by);
                cmd.Parameters.AddWithValue("@id", d.id);

                conn.Open();

                int rows = cmd.ExecuteNonQuery();
                if (rows>0)
                {
                    isSucces = true;
                }
                else
                {
                    isSucces = false;
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return isSucces;
        }
        #endregion

        #region Delete Data Deaker and Customer in Database
         public bool Delete(DeaCustBLL d)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                String sql = "Delete from tbl_dea_cust where id=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@id", d.id);
                
                conn.Open();

                int rows = cmd.ExecuteNonQuery();
                if (rows>0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }
        #endregion

        #region search Data from Database Using Keyboard
        public DataTable Search(string keywords)
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();

            try
            {
                String sql = "select * from tbl_dea_cust where id LIKE '%"+keywords+ "%' OR type LIKE  '%" + keywords+ "%'  OR name LIKE  '%" + keywords + "%'  OR email LIKE  '%" + keywords + "%'  ";
                SqlCommand cmd = new SqlCommand(sql,conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }
        #endregion

        #region Getting Id USername from tbl _users
        public DeaCustBLL GetIDFromUsername(string username)
        {
            DeaCustBLL d = new DeaCustBLL();
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();

            try
            {
                string sql = "select id from tbl_users where username='" + username + "'";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                conn.Open();
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    d.id = int.Parse(dt.Rows[0]["id"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                conn.Close();
            }
            return d;
        }
        #endregion

        #region METHOD TO SEARCH DEALER OR CUSTOMER FOR TRANSACTION MODULE
        public DeaCustBLL SearchDealerCustomerForTransaction(string keyword)
        {
            DeaCustBLL dc = new DeaCustBLL();

            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();

            try
            {
                string sql = "select name, email, contact, address from tbl_dea_cust where id LIKE '%"+keyword+"%' OR name LIKE '%"+keyword+"%'  ";
                SqlDataAdapter adpater = new SqlDataAdapter(sql, conn);
                conn.Open();

                adpater.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    dc.name = dt.Rows[0]["name"].ToString();
                    dc.email = dt.Rows[0]["email"].ToString();
                    dc.contact = dt.Rows[0]["contact"].ToString();
                    dc.address = dt.Rows[0]["address"].ToString();
                    
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return dc;
        }
        #endregion

        #region METHOD GET ID OF THE DEALER OR CUSTOMER BASED ON NAME 
        public DeaCustBLL GetDeaCustIDFromName(string Name)
        {
            //First create an object of Deacust BLL and retrurn it 
            DeaCustBLL dc = new DeaCustBLL();

            //SQL
            SqlConnection conn = new SqlConnection(myconnstrng);

            DataTable dt = new DataTable();

            try
            {

                string sql = "select id from tbl_dea_cust where name='"+Name+"' ";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                conn.Open();

                adapter.Fill(dt);

                if (dt.Rows.Count>0)
                {
                    dc.id = int.Parse(dt.Rows[0]["id"].ToString());
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return dc;
        }
        #endregion
    }

}
