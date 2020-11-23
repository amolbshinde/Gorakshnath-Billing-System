using Gorakshnath_Billing_System.BLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gorakshnath_Billing_System.DAL
{
    class loginDAL
    {
        //static string to connect Databse
        static string myconnstring = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        public bool loginCheck(loginBLL l)
        {
            //create a boolean variable and set it's value to false and return it 

            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstring);
            try
            {
                //sql query to check login 
                string sql = "Select * from tbl_users WHERE username=@username AND password=@password AND user_type=@user_type";

                //Creating sql command to pass the values 
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@username", l.username);
                cmd.Parameters.AddWithValue("@password", l.password);
                cmd.Parameters.AddWithValue("@user_type", l.user_type);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                if(dt.Rows.Count>0)
                {
                    // MessageBox.Show("Login is succesfull");

                    isSuccess = true;

                }
                else
                {
                    //MessageBox.Show("login Failed ..!!! :/");
                    isSuccess = false;

                }

            }
            catch(Exception ex)
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
