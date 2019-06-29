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
    class transactionDAL
    {
        //Create connection srtring variable
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;



        #region #region Insert Transaction Method

        public bool Insert_Transaction(transactionBLL t, out int transactionID)
        {
            //Create Boolean value and set default value t false
           bool isSucces = false;
            //Set the transactionID value to negative 1 i.e -1

            transactionID = -1;
            //Create Sql Connection
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                //Sql query to insert transaction
                string sql = "insert into tbl_transaction (type,dea_cust_id,grandTotal,transaction_date,tax,discount,added_by)values(@type,@dea_cust_id,@grandTotal,@transaction_date,@tax,@discount,@added_by);SELECT @@IDENTITY;";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@type", t.type);
                cmd.Parameters.AddWithValue("@dea_cust_id", t.dea_cust_id);
                cmd.Parameters.AddWithValue("@grandTotal", t.grandTotal);
                cmd.Parameters.AddWithValue("@transaction_date", t.transaction_date);
                cmd.Parameters.AddWithValue("@tax", t.tax);
                cmd.Parameters.AddWithValue("@discount", t.discount);
                cmd.Parameters.AddWithValue("@added_by", t.added_by);
                //Open Connection
                conn.Open();
                object o = cmd.ExecuteScalar();
                if (o!=null)
                {
                    transactionID = int.Parse(o.ToString());
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

        #region#region METHOD TO DISPLAY ALL THE TRANSACTION
        public DataTable DisplayAllTransaction()
        {
            //SqlConnection
            SqlConnection conn = new SqlConnection(myconnstrng);

            //create a datatable  to hold the dataform database temporaly
            DataTable dt = new DataTable();
            try
            {
                //Write Sql to dispaly all transactionn
                string sql = "SELECT * FROM tbl_transaction";

                //SqlCommand to  Execute Query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Sql Data  ADapter to Hold the adta from database
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //Open Database Connecction
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

        #region METHOD TO DISPLAY TRANSACTION BASED ON TRANSACTION TYPE
        public DataTable DisplayTransactionByType(string type)
        {
            //Create Sql Connection 
            SqlConnection conn = new SqlConnection(myconnstrng);

            //Creaate a DataTable
            DataTable dt = new DataTable();


            try
            {
                //Write SQL Query
                string sql = "SELECT * FROM tbl_transaction where type='"+type+"' ";

                //Sql Command to execute query
                SqlCommand cmd = new SqlCommand(sql,conn);

                //SQL DATA adapter to hold the data from database
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //Open Connection 
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
