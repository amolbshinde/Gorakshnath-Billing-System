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
    class SupplierMasterDAL
    {
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;

        #region select Method for SupplierMaster
        public DataTable Select()
        {

            // Sql Command for Databasae Connection 
            SqlConnection conn = new SqlConnection(myconnstrng);

            // Datatable to hold value from database andreturn it 
            DataTable dt = new DataTable();

            try
            {
                // Sql quesry to select all data from databse
                String sql = "Select * from Supplier_Master";

                // Creating SQL Command to execute Query 
                SqlCommand cmd = new SqlCommand(sql, conn);

                // Creating SQL data Adaptor for storing data From Query Temporary 
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
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
        #region Insert Method to add data in database
        public bool Insert(SupplierMasterBLL sm)
        {
            // Creating Sql Connection First
            SqlConnection conn = new SqlConnection(myconnstrng);
            //Creating Default value for isSccuess
            bool isSuccess = false;
            try
            {
                string sql = "insert into Supplier_Master(CompanyName,Address,City,State,Pincode,Country,Email,Phone_No,Contact_Person,Contact_No) Values(@CompanyName,@Address,@City,@State,@Pincode,@Country,@Email,@Phone_No,@Contact_Person,@Contact_No)";
                //Passing values to query and execute
                SqlCommand cmd = new SqlCommand(sql, conn);
                //
                cmd.Parameters.AddWithValue("@CompanyName", sm.CompanyName);
                cmd.Parameters.AddWithValue("@Address", sm.Address);
                cmd.Parameters.AddWithValue("@City", sm.City);
                cmd.Parameters.AddWithValue("@State", sm.State);
                cmd.Parameters.AddWithValue("@Pincode", sm.Pincode);
                cmd.Parameters.AddWithValue("@Country", sm.Country);
                cmd.Parameters.AddWithValue("@Email", sm.Email);
                cmd.Parameters.AddWithValue("@Phone_No", sm.Phone_No);
                cmd.Parameters.AddWithValue("@Contact_Person", sm.Contact_Person);
                cmd.Parameters.AddWithValue("@Contact_No", sm.Contact_No);                
                conn.Open();
                
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
                conn.Close();
            }
            return isSuccess;

        }

        #endregion
        #region Update Supplier Details 
        public bool Update(SupplierMasterBLL sm)
        {
            // Creating Sql Connection First
            SqlConnection conn = new SqlConnection(myconnstrng);
            //Creating Default value for isSccuess
            bool isSuccess = false;
            try
            {
                string sql = "UPDATE  Supplier_Master set CompanyName=@CompanyName,Address=@Address,City=@City,State=@State,Pincode=@Pincode,Country=@Country,Email=@Email,Phone_No=@Phone_No,Contact_Person=@Contact_Person,Contact_No=@Contact_No where SupplierID=@id";
                //Passing values to query and execute
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@CompanyName", sm.CompanyName);
                cmd.Parameters.AddWithValue("@Address", sm.Address);
                cmd.Parameters.AddWithValue("@City", sm.City);
                cmd.Parameters.AddWithValue("@State", sm.State);
                cmd.Parameters.AddWithValue("@Pincode", sm.Pincode);
                cmd.Parameters.AddWithValue("@Country", sm.Country);
                cmd.Parameters.AddWithValue("@Email", sm.Email);
                cmd.Parameters.AddWithValue("@Phone_No", sm.Phone_No);
                cmd.Parameters.AddWithValue("@Contact_Person", sm.Contact_Person);
                cmd.Parameters.AddWithValue("@Contact_No", sm.Contact_No);
                cmd.Parameters.AddWithValue("@id",sm.SupplierID);
                conn.Open();

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
                conn.Close();
            }
            return isSuccess;
        }

        #endregion
        #region Delete Supplier Details or Dealer Detais from Table 
        public bool Delete(SupplierMasterBLL sm)
        {
            // Creating Sql connection First
            SqlConnection conn = new SqlConnection(myconnstrng);

            //Seeting Default for isSuccess
            bool isSuccess = false;
            try
            {
                string sql = "Delete from Supplier_Master where SupplierID=@SupplierID";
                //passing query sqlcommand
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@SupplierID", sm.SupplierID);
                conn.Open();
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

        #region Search Customer On Database Using Keywords
        public DataTable Search(string keywords)
        {
            SqlConnection con = new SqlConnection(myconnstrng);

            DataTable dt = new DataTable();
            try
            {
                String sql = "SELECT * FROM Supplier_Master WHERE SupplierID LIKE'%" + keywords + "%' OR CompanyName LIKE'%" + keywords + "%' OR City LIKE'%" + keywords + "%' OR Phone_No LIKE'%" + keywords + "%'";
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


    }





}
