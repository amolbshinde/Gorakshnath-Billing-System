using Gorakshnath_Billing_System.BLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gorakshnath_Billing_System.DAL
{
    class DummySalesDetailsDAL
    {
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;

        #region Insert Meathod for Challan Details

        public bool insertDummySalesDetails(DummySalesDetailsBLL ds)
        {
            bool isSuccess = false;

            SqlConnection con = new SqlConnection(myconnstrng);

            try
            {
                //inserting transaction details
                string sql = "INSERT INTO Challan_Transactions_Details (Product_ID,Cust_ID,Product_Name,Unit,Qty,Rate,Dicount_Per,GST_Type,GST_Per,Total) VALUES(@Product_ID,@Cust_ID,@Product_Name,@Unit,@Qty,@Rate,@Discount_Per,@GST_Type,@GST_Per,@Total)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Invoice_No", 1);
                cmd.Parameters.AddWithValue("@Product_ID", ds.Product_ID);
                cmd.Parameters.AddWithValue("@Cust_ID", ds.Cust_ID);
                cmd.Parameters.AddWithValue("@Product_Name", ds.Product_Name);
                cmd.Parameters.AddWithValue("@Unit", ds.Unit);
                cmd.Parameters.AddWithValue("@Qty", ds.Qty);
                cmd.Parameters.AddWithValue("@Rate", ds.Rate);
                cmd.Parameters.AddWithValue("@Discount_Per", ds.Discount_Per);
                cmd.Parameters.AddWithValue("@GST_Type", ds.GST_Type);
                cmd.Parameters.AddWithValue("@GST_Per", ds.GST_Per);
                cmd.Parameters.AddWithValue("@Total", ds.Total);
                //Unit,Qty,Rate,Discount_Per,GST_Type,GST_Per,Total
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

            }
            return isSuccess;
        }
        #endregion
    }
}
