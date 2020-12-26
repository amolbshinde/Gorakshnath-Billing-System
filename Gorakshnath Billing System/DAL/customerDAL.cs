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
                String sql = "SELECT * FROM Cust_Master";
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
                String sql = "INSERT INTO Cust_Master (Cust_Name, Cust_Contact, Cust_Email, Cust_Address) VALUES(@name, @contact, @email, @address)";

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
                String sql = "UPDATE Cust_Master SET Cust_Name=@name, Cust_Contact=@contact, Cust_Email=@email, Cust_Address=@address WHERE Cust_Id = @id";
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
                string sql = "DELETE FROM Cust_Master WHERE Cust_Id =@id";
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
                String sql = "SELECT * FROM Cust_Master WHERE Cust_Id LIKE'%" + keywords + "%' OR Cust_Name LIKE'%" + keywords + "%' OR Cust_Address LIKE'%" + keywords + "%' OR Cust_Contact LIKE'%" + keywords + "%'";
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
            //
            try
            {
                string sql = "SELECT Cust_Name, Cust_Contact, Cust_Email,Cust_Address from Cust_Master WHERE Cust_Id LIKE '%" + keyword + "%' OR Cust_Name LIKE '%" + keyword + "%' OR Cust_Contact LIKE '%" + keyword + "%'";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, con);

                con.Open();

                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    c.name = dt.Rows[0]["Cust_Name"].ToString();
                    c.contact = dt.Rows[0]["Cust_Contact"].ToString();
                    c.email = dt.Rows[0]["Cust_Email"].ToString();
                    c.address = dt.Rows[0]["Cust_Address"].ToString();

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


        #region Method  to search customer By Name
        public customerBLL searchcustomerByName(string keyword)
        {
            customerBLL c = new customerBLL();

            SqlConnection con = new SqlConnection(myconnstrng);

            DataTable dt = new DataTable();
            //
            try
            {
                string sql = "SELECT Cust_Name, Cust_Contact, Cust_Email,Cust_Address from Cust_Master WHERE Cust_Name='" + keyword + "'";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, con);

                con.Open();

                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    c.name = dt.Rows[0]["Cust_Name"].ToString();
                    c.contact = dt.Rows[0]["Cust_Contact"].ToString();
                    c.email = dt.Rows[0]["Cust_Email"].ToString();
                    c.address = dt.Rows[0]["Cust_Address"].ToString();

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


        #region Method  to search customer By Phone
        public customerBLL searchcustomerByPhone(string keyword)
        {
            customerBLL c = new customerBLL();

            SqlConnection con = new SqlConnection(myconnstrng);

            DataTable dt = new DataTable();
            //
            try
            {
                string sql = "SELECT Cust_Name, Cust_Contact, Cust_Email,Cust_Address from Cust_Master WHERE Cust_Contact='" + keyword + "'";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, con);

                con.Open();

                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    c.name = dt.Rows[0]["Cust_Name"].ToString();
                    c.contact = dt.Rows[0]["Cust_Contact"].ToString();
                    c.email = dt.Rows[0]["Cust_Email"].ToString();
                    c.address = dt.Rows[0]["Cust_Address"].ToString();

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
            customerBLL  c = new customerBLL();
            SqlConnection con = new SqlConnection(myconnstrng);

            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT Cust_Id FROM Cust_Master WHERE Cust_Name='" + Name + "'";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                con.Open();
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    c.Cust_ID = int.Parse(dt.Rows[0]["Cust_Id"].ToString());
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


        #region Select Data From Database for  combo
        public DataTable SelectForCombo()
        {
            SqlConnection con = new SqlConnection(myconnstrng);

            DataTable dt = new DataTable();
            try
            {
                String sql = "SELECT Cust_Name, Cust_Contact FROM Cust_Master;";
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


        #region Method to customer already available or not Customer based on Phone
        public customerBLL getCustomerIdFromContact(string contact)
        {
            customerBLL c = new customerBLL();
            SqlConnection con = new SqlConnection(myconnstrng);

            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT Cust_Contact FROM Cust_Master WHERE Cust_Contact='" + contact + "'";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                con.Open();
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    c.contact = dt.Rows[0]["Cust_Contact"].ToString();
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

