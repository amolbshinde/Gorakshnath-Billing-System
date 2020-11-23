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
    class userDAL
    {
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        #region select data from database
        public DataTable Select()
        {
            //Static Meathod to connect database
            SqlConnection conn = new SqlConnection(myconnstrng);
            // to hold data from databse
            DataTable dt = new DataTable();
            try
            {
                // Sql query to get data from database

                string sql = "select * from tbl_users";
                // For Executing the Command 
                SqlCommand cmd = new SqlCommand(sql, conn);
                // Getting data from database
                SqlDataAdapter adapter = new  SqlDataAdapter(cmd);
                conn.Open();
                //To fill data to DataTable
                adapter.Fill(dt);


            }
                        
            catch(Exception ex)
            {            
                //Through Message id any error occurs 
                    MessageBox.Show(ex.Message);
            }
            finally 
            {
                //closing connection
                conn.Close();
            }
            // return value to datatable
            return dt;

        }
        #endregion
        #region insert Data in Database
        public bool Insert(userBLL u)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                string sql = "insert into tbl_users(first_name,last_name,email,username,password,contact,address,gender,user_type,added_date,added_by) values(@first_name, @last_name, @email,@username,@password,@contact,@address,@gender,@user_type,@added_date,@added_by)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@first_name",u.first_name);
                cmd.Parameters.AddWithValue("@last_name", u.last_name);
                cmd.Parameters.AddWithValue("@email", u.email);
                cmd.Parameters.AddWithValue("@username", u.username);
                cmd.Parameters.AddWithValue("@password", u.password);
                cmd.Parameters.AddWithValue("@contact", u.contact);
                cmd.Parameters.AddWithValue("@address", u.address);
                cmd.Parameters.AddWithValue("@gender", u.gender);
                cmd.Parameters.AddWithValue("@user_type", u.user_type);
                cmd.Parameters.AddWithValue("@added_date", u.added_date);
                cmd.Parameters.AddWithValue("@added_by", u.added_by);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();

                if(rows>0)
                {
                    isSuccess = true;
                   
                }
                else
                { isSuccess = false; }
                    
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


        #endregion
        #region Update Data in database
        public bool Update(userBLL u)
        {

            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                string sql="Update tbl_users set first_name= @first_name,last_name= @last_name,email= @email,username= @username,password= @password,contact= @contact,address= @address,gender= @gender,user_type= @user_type,added_date= @added_date,added_by = @added_by where id=@id";
                SqlCommand cmd = new SqlCommand(sql,conn);
                cmd.Parameters.AddWithValue("@first_name", u.first_name);
                cmd.Parameters.AddWithValue("@last_name", u.last_name);
                cmd.Parameters.AddWithValue("@email", u.email);
                cmd.Parameters.AddWithValue("@username", u.username);
                cmd.Parameters.AddWithValue("@password", u.password);
                cmd.Parameters.AddWithValue("@contact", u.contact);
                cmd.Parameters.AddWithValue("@address", u.address);
                cmd.Parameters.AddWithValue("@gender", u.gender);
                cmd.Parameters.AddWithValue("@user_type", u.user_type);
                cmd.Parameters.AddWithValue("@added_date", u.added_date);
                cmd.Parameters.AddWithValue("@added_by", u.added_by);
               cmd.Parameters.AddWithValue("@id", u.id);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if(rows>0)
                {
                    isSuccess = true;
                }
                else
                {
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

        #endregion
        #region Delete Data From database
        public bool Delete(userBLL u)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                string sql = "DELETE from tbl_users where id=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id",u.id);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if(rows>0)
                {
                    isSuccess = true;
                }
                else
                {
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


        #endregion
        #region Serach User on database using keyword
        public DataTable Search(string keywords )
        {
            //Static Meathod to connect database
            SqlConnection conn = new SqlConnection(myconnstrng);
            // to hold data from databse
            DataTable dt = new DataTable();
            try
            {
                // Sql query to get data from database

                string sql = "select * from tbl_users WHERE id LIKE'%"+keywords+"%' OR first_name LIKE '%"+keywords+"%' OR username LIKE '%"+keywords+"%' OR last_name LIKE '%"+keywords+"%'";
                // For Executing the Command ;
                // For Executing the Command 
                SqlCommand cmd = new SqlCommand(sql, conn);
                // Getting data from database
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                //To fill data to DataTable
                adapter.Fill(dt);


            }

            catch (Exception ex)
            {
                //Through Message id any error occurs 
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //closing connection
                conn.Close();
            }
            // return value to datatable
            return dt;

        }

        #endregion
        #region Getting userid from username
        public userBLL GetIdFromUsername(string username)
        {
            userBLL u = new userBLL();
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                string sql = "select id from tbl_users WHERE username='" + username + "'";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                conn.Open();
                adapter.Fill(dt);
                if(dt.Rows.Count>0)
                {
                    u.id = int.Parse(dt.Rows[0]["id"].ToString());

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
            return u;
        }
#endregion
    }
}
