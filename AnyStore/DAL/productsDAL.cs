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
    class productsDAL
    {
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;

        #region Methdod for  Product Module
        public DataTable Select()
        {
            //Creating sql Connection to connect Databases
            SqlConnection conn = new SqlConnection(myconnstrng);

            //Data Table to hold the data from databse
            DataTable dt = new DataTable();

            try
            {
                //Write the Query to Select all the Product from Database
                String sql = "select * from tbl_products";

                //Creating SQL commadn to execute QUery
                SqlCommand cmd = new SqlCommand(sql, conn);

                //SQL Data Adpter to hold the value from database temporaliy
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //Open Databse Connection
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

        #region Method to Insert Product in Database
        public bool Insert(productsBLL p)
        {
            //Crating Boolean Variable and set its default value to false

            bool isSuccess = false;

            //SqlConnection for Databse
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                //Querry to insert Product into database
               String sql = "Insert into tbl_products (name,category,description,rate,qty,added_date,added_by) values (@name,@category,@description,@rate,@qty,@added_date,@added_by)";

                //Create SQL command to pass the value
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Passiggn the Value through parameters
                cmd.Parameters.AddWithValue("@name", p.name);
                cmd.Parameters.AddWithValue("@category", p.category);
                cmd.Parameters.AddWithValue("@description", p.description);
                cmd.Parameters.AddWithValue("@rate", p.rate);
                cmd.Parameters.AddWithValue("@qty", p.qty);
                cmd.Parameters.AddWithValue("@added_date", p.added_date);
                cmd.Parameters.AddWithValue("@added_by", p.added_by);

                //Open the Database Connection
                conn.Open();

                int rows = cmd.ExecuteNonQuery();
                //if the query executed successfuly then the value of rows will be greater than 0 wlse it be less than 0
                if (rows>0)
                {
                    //Queryy Executed Success
                    isSuccess = true;
                  
                }
                else
                {
                    //Query Executed failed
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

        #region Method to Update Product in Database
        public bool Update(productsBLL p)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                //Sql Query to update data product where id
                String sql = "Update tbl_products set name=@name ,category=@category, description=@description, rate=@rate, qty=@qty, added_date=@added_date, added_by=@added_by where id=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                //Passiggn the Value through parameters
                cmd.Parameters.AddWithValue("@name", p.name);
                cmd.Parameters.AddWithValue("@category", p.category);
                cmd.Parameters.AddWithValue("@description", p.description);
                cmd.Parameters.AddWithValue("@rate", p.rate);
                cmd.Parameters.AddWithValue("@qty", p.qty);
                cmd.Parameters.AddWithValue("@added_date", p.added_date);
                cmd.Parameters.AddWithValue("@added_by", p.added_by);
                cmd.Parameters.AddWithValue("@id", p.id);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows>0)
                {
                    //Success Update Data
                    isSuccess = true;
                }
                else
                {
                    //failed Update Data
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

        #region Method to Delete Data Product in Database
        public bool Delete(productsBLL p)
        {
           bool isSuccess = false;
           SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                String sql = "DELETE from tbl_products where id=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", p.id);
                conn.Open();

                int rows = cmd.ExecuteNonQuery();
                if (rows>0)
                {
                    //Delete Success
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

        #region Method to Search Product from Databse using keyword 
        public DataTable Search(string keywords)
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();

            try
            {
                //Query to Search Data
                String sql = "select * from tbl_products where id LIKE '%"+keywords+"%' OR name LIKE '%"+ keywords + "%' OR category LIKE'%"+keywords+"%' OR description LIKE '%"+keywords+"%' OR rate LIKE '%"+keywords+"%' ";
                SqlCommand cmd = new SqlCommand(sql, conn);
                //Getting Data From Database
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                //Open Connection
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

        #region Getting User Id from Usernaeme

        public productsBLL GetIDFromUsername(string username)
        {
            productsBLL p = new productsBLL();
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
                    p.id = int.Parse(dt.Rows[0]["id"].ToString());
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
            return p;
        }
        #endregion

        #region METHOD TO SEARCH PRODUCT IN TRANSACTION MODULE
        public productsBLL GetProductForTransaction(string keyword)
        {
            productsBLL p = new productsBLL();
            SqlConnection conn = new SqlConnection(myconnstrng);

            DataTable dt = new DataTable();
            try
            {
                string sql ="select name,rate,qty from tbl_products where id like '%"+keyword+"%' OR name like '%"+keyword+"'";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);

                conn.Open();
                adapter.Fill(dt);


                if (dt.Rows.Count>0)
                {
                    p.name = dt.Rows[0]["name"].ToString();
                    p.rate= decimal.Parse(dt.Rows[0]["rate"].ToString());
                    p.qty =decimal.Parse (dt.Rows[0]["qty"].ToString());
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
            return p;
        }
        #endregion

        #region Method  TO GET PRODUCT ID  BASED ON PRODUCT NAME
        public productsBLL GetProductIDFromName(string ProductName)
        {
            //First create an object of Deacust BLL and retrurn it 
            productsBLL p = new productsBLL();

            //SQL
            SqlConnection conn = new SqlConnection(myconnstrng);

            DataTable dt = new DataTable();

            try
            {

                string sql = "select id from tbl_products where name='" + ProductName + "' ";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                conn.Open();

                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    p.id = int.Parse(dt.Rows[0]["id"].ToString());
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
            return p;
        }

        #endregion

        #region METHOD TO GET CURENCY QUANTITIY FROMTHE DATABASE BASED OON PRODUCT ID

        public decimal GetProductQty(int ProductID)
        {
            //SQL Connection sql
            SqlConnection conn = new SqlConnection(myconnstrng);

            //Create a Decimal Variable and set int default value to 0
            decimal qty = 0;

            //create datatable  to save the data from database temporaly 
            DataTable dt = new DataTable();

            try
            {
                //write sql query to get quantity from database 
                string sql = "select qty from tbl_products where id = " + ProductID ;

                //Create SQL Command
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Create a sql data adapter to execute the query
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //Open Connection
                conn.Open();

                //Pass the valur from data Adapter to DataTable
                adapter.Fill(dt);

                //Lets check if the datatable value or not 
                if (dt.Rows.Count>0)
                {
                    qty = decimal.Parse(dt.Rows[0]["qty"].ToString());
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
            return qty;
        }


        #endregion

        #region MEthod to update quantitiy
        public bool UpdateQuantitiy(int ProductID, decimal Qty)
        {
            //Create a boolean variable and Set it value to false
            bool success = false;
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                //Write Sql to Update Qty
                string sql = "UPDATE tbl_products set qty=@qty where id=@id ";

                //Write Sql Command to pass the value into Query
                SqlCommand cmd = new SqlCommand(sql, conn);
                //Passing the value throungh parameters
                cmd.Parameters.AddWithValue("@qty", Qty);
                cmd.Parameters.AddWithValue("@id", ProductID);

                //Open Connection
                conn.Open();

                //Create int variable and check whether the query is executed successfully or not
                int rows = cmd.ExecuteNonQuery();
                //Lets check uf the query is executed succesfully or not
                if (rows>0)
                {
                    //Quewry Executed SuccessFully
                    success = true;
                }
                else
                {
                    //Failed to Execute Query
                    success = false;
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
            return success;
        }
        #endregion

        #region METHOD TO INCREASE PRODUCT
        public bool IncreaseProduct(int ProductID, decimal IncreaseQty)
        {
            //Creata a boolean variable and set it value to false
            bool success = false;

            //Write Sql ConnectionTo connect Data
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                //Get the currency QTY From database based on id
                decimal currentQty = GetProductQty(ProductID);

                //Increase the Current Quantity by the qty purchased from Dealer
                decimal NewQty = currentQty + IncreaseQty;
              
                //Update the Product Quantity Now
                success = UpdateQuantitiy(ProductID, NewQty);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                //Close Connection
                conn.Close();
            }
            return success;
        }

        #endregion

        #region  METHOD TO DECREASE PRODUCT

        public bool DecreaseProduct(int ProductID, decimal Qty)
        {
            bool success = false;
            //Create Sql Connection
            SqlConnection conn = new SqlConnection(myconnstrng);


            try
            {
                //Get the Current Product Quantity
                decimal currentQty = GetProductQty(ProductID);

                //Decrease the Product Quantity based on product sales
                decimal NewQty = currentQty - Qty;

                //Update Product In database
                success = UpdateQuantitiy(ProductID, NewQty);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return success;
        }
        #endregion

        #region METHOD DISPLAY PRODUCT BASED ON CATEGORIES
        public DataTable DisplayProductsByCategory(string category)
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();

            try
            {
                //Sql Query to Display Product Based on Category
                string sql = "SELECT * FROM tbl_products where category ='" + category + "' ";
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
    }
}
