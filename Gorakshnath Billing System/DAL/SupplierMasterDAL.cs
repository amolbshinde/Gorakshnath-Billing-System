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
            SqlConnection conn = new SqlConnection();

            // Datatable to hold value from database andreturn it 
            DataTable dt = new DataTable();

            try
            {
                // Sql quesry to select all data from databse
                String sql = "Select 3 from SupplierMaster";

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
        public bool Insert(SupplierMasterBLL dc)
        {
            // Creating Sql Connection First
            SqlConnection conn = new SqlConnection(myconnstrng);
            //Creating Default value for isSccuess
            bool isSuccess = false;
            try
            {
                string sql = "insert into SupplierMster(CompanyName,Address,City,State,Pincode,Country,Email,Phone_No,Contact_Person,Contact_No) Values(@CompanyName,@Address,@City,@State,@Pincode,@Country,@Email,@Phone_No,@Contact_Person,@Contact_No)";
                //Passing values to query and execute
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@CompanyName", dc.CompanyName);
                cmd.Parameters.AddWithValue("@Address", dc.Address);
                cmd.Parameters.AddWithValue("@City", dc.City);
                cmd.Parameters.AddWithValue("@State", dc.State);
                cmd.Parameters.AddWithValue("@Pincode", dc.Pincode);
                cmd.Parameters.AddWithValue("@Country", dc.Country);
                cmd.Parameters.AddWithValue("@Email", dc.Email);
                cmd.Parameters.AddWithValue("@Phone_No", dc.Phone_No);
                cmd.Parameters.AddWithValue("@Contact_Person", dc.Contact_Person);
                cmd.Parameters.AddWithValue("@Contact_No", dc.Contact_No);
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
                string sql = "UPDATE  SupplierMster set CompanyName=@CompanyName,Address=@Address,City=@City,State=@State,Pincode=@Pincode,Country=@Country,Email=@Email,Phone_No=@Phone_No,Contact_Person=@Contact_Person,Contact_No=@Contact_No whereid=@id";
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
    }





}
