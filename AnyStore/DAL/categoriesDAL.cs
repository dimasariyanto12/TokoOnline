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
    class categoriesDAL
    {
        //Staic String Method for Database Connection String
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;

        #region Select Method
        public DataTable Select()
        {
            //Creating Database Connection
            SqlConnection conn = new SqlConnection(myconnstrng);

            DataTable dt = new DataTable();
            try
            {
                ///SQL Query to Get Data From Database
                String sql = "select * from tbl_categories";
                SqlCommand cmd = new SqlCommand(sql, conn);
                //Getting Data From Database
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                //Database COnnection Open
                conn.Open();
                //Fill Data in our Datatable
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

        #region Insert New Category
        public bool Insert(categoriesBLL c)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                String sql = "INSERT INTO tbl_categories (title,description,added_date,added_by) values (@title,@description,@added_date,@added_by) ";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@title", c.title);
                cmd.Parameters.AddWithValue("@description", c.description);
                cmd.Parameters.AddWithValue("@added_date", c.added_date);
                cmd.Parameters.AddWithValue("@added_by", c.added_by);
    
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

        #region Update Data Category from Database where id

        public bool Update(categoriesBLL c)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                string sql = "UPDATE tbl_categories SET title=@title, description=@description,added_date=@added_date,added_by=@added_by  where id=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@title", c.title);
                cmd.Parameters.AddWithValue("@description", c.description);
                cmd.Parameters.AddWithValue("@added_date", c.added_date);
                cmd.Parameters.AddWithValue("@added_by", c.added_by);
                cmd.Parameters.AddWithValue("@id", c.id);


                conn.Open();

                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    //Query Successfuly
                    isSuccess = true;
                }
                else
                {
                    //Querry Falied
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

        #region Delete Data Category from Database where id
        public bool Delete(categoriesBLL c)
        {
            bool isSuccess = false;

            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                string sql = "Delete from tbl_categories where id=@id";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", c.id);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    //Query Successfuly
                    isSuccess = true;
                }
                else
                {
                    //Query Failed
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

        #region Search Data From Database using keyword
        public DataTable Search(string keywords)
        {
            //Static Method connect Database
            SqlConnection conn = new SqlConnection(myconnstrng);
            //TO hold the Data From Database
            DataTable dt = new DataTable();
            try
            {
                //SQL Query to Get Data From Database
                String sql = "select * from tbl_categories where id LIKE '%" + keywords + "%' OR title LIKE '%" + keywords + "%' OR description LIKE '%" + keywords + "%'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                //Getting Data From Database
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                //Database COnnection Open
                conn.Open();
                //Fill Data in our Datatable
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                //Throw Message if any error occurs
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //Clossing Connection
                conn.Close();
            }
            //Return the value in DataTable
            return dt;
        }
        #endregion

        #region Getting User Id from Usernaeme

        public categoriesBLL GetIDFromUsername(string username)
        {
            categoriesBLL c = new categoriesBLL();
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
                    c.id = int.Parse(dt.Rows[0]["id"].ToString());
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
            return c;
        }
        #endregion
    }
}
