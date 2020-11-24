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
    class customerDAL
    {
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        #region Select Data From Database
        public DataTable Select()
        {
           SqlConnection con = new SqlConnection(myconnstrng);

            DataTable dt = new DataTable();
            try
            {
                String sql = "SELECT * FROM tbl_dea_cust";
                SqlCommand cmd = new SqlCommand(sql, con);
               SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                con.Open();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return dt;
        }
        #endregion
        #region Insert Data in Database
        public bool Insert(customerBLL c)
        {
            bool isSuccess = false;
           SqlConnection con = new SqlConnection(myconnstrng);
            try
            {
                String sql = "INSERT INTO tbl_dea_cust (name, contact, email, address) VALUES(@name, @contact, @email, @address)";

               SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@name", c.name);
                cmd.Parameters.AddWithValue("@contact", c.contact);
                cmd.Parameters.AddWithValue("@email", c.email);
                cmd.Parameters.AddWithValue("@address", c.address);

                con.Open();

                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
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
                con.Close();
            }
            return isSuccess;
        }
        #endregion
        #region Update Data in Database
        public bool Update(customerBLL c)
        {
            bool isSuccess = false;
           SqlConnection con = new SqlConnection(myconnstrng);
            try
            {
                String sql = "UPDATE tbl_dea_cust SET name=@name, contact=@contact, email=@email, address=@address WHERE id = @id";
               SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@name", c.name);
                cmd.Parameters.AddWithValue("@contact", c.contact);
                cmd.Parameters.AddWithValue("@email", c.email);
                cmd.Parameters.AddWithValue("@address", c.address);
                cmd.Parameters.AddWithValue("@id", c.id);

                con.Open();
                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
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
                con.Close();
            }

            return isSuccess;

        }
        #endregion
        #region Delete Data From Database
        public bool Delete(customerBLL c)
        {
            bool isSuccess = false;
           SqlConnection con = new SqlConnection(myconnstrng);
            try
            {
                string sql = "DELETE FROM tbl_dea_cust WHERE id =@id";
               SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", c.id);
                con.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
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
                con.Close();
            }

            return isSuccess;
        }

        #endregion
        #region Search Customer On Database Using Keywords
        public DataTable Search(string keywords)
        {
           SqlConnection con = new SqlConnection(myconnstrng);

            DataTable dt = new DataTable();
            try
            {
                String sql = "SELECT * FROM tbl_dea_cust WHERE id LIKE'%" + keywords + "%' OR name LIKE'%" + keywords + "%' OR address LIKE'%" + keywords + "%' OR contact LIKE'%" + keywords + "%'";
               SqlCommand cmd = new SqlCommand(sql, con);
               SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                con.Open();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return dt;
        }
        #endregion
        #region Method  to search customer for sales module

        public customerBLL searchcustomerforsales(string keyword)
        {
            customerBLL c = new customerBLL();

           SqlConnection con = new SqlConnection(myconnstrng);

            DataTable dt = new DataTable();

            try
            {
                string sql = "SELECT name, contact, email,address from tbl_dea_cust WHERE id LIKE '%" + keyword + "%' OR name LIKE '%" + keyword + "%'";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, con);

                con.Open();

                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    c.name = dt.Rows[0]["name"].ToString();
                    c.contact = dt.Rows[0]["contact"].ToString();
                    c.email = dt.Rows[0]["email"].ToString();
                    c.address = dt.Rows[0]["address"].ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
            return c;
        }

        #endregion
        #region Method to get id of the Customer based on Name
        public customerBLL getCustomerIdFromName(string Name)
        {
            customerBLL c = new customerBLL();
           SqlConnection con = new SqlConnection(myconnstrng);

            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT id FROM tbl_dea_cust WHERE name='" + Name + "'";
               SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                con.Open();
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
                con.Close();
            }

            return c;
        }
        #endregion
    }
}

