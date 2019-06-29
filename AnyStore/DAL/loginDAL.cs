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
    class loginDAL
    {
        //static string to connect Database
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;

        public bool loginCheck(loginBLL l)
        {
            //Create a boolean and set its value to false and retrunt it

            bool isSuccess = false;

            //Connection to Database
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                //SQL Query to check login
                string sql = "select *from tbl_users where username=@username AND password=@password AND user_type=@user_type";

                //Creatng Command to pass value
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@username", l.username);
                cmd.Parameters.AddWithValue("@password", l.password);
                cmd.Parameters.AddWithValue("@user_type", l.user_type);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                adapter.Fill(dt);
                //Checkng the rows in DataTable
                if (dt.Rows.Count>0)
                {
                    //Login Successfully
                    isSuccess = true;
                }
                else
                {
                    //login Failed
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
    }
}
