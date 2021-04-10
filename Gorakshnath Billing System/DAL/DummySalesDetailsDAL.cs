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
    class DummySalesDetailsDAL
        //
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
                string sql = "INSERT INTO DummySales_Transactions_Details (Invoice_No,Product_ID,Cust_ID,Product_Name,Unit,Qty,Rate,Dicount_Per,GST_Type,GST_Per,Total,Challan_date) VALUES(@Invoice_No,@Product_ID,@Cust_ID,@Product_Name,@Unit,@Qty,@Rate,@Discount_Per,@GST_Type,@GST_Per,@Total,@Challan_date)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Invoice_No", ds.Invoice_No);
                MessageBox.Show(ds.Invoice_No.ToString());
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
                cmd.Parameters.AddWithValue("@Challan_date", ds.Challan_date);
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

        #region Delete Data By Invoice NO
        public DataTable DeleteByInvoiceNo(string Invoice_No)
        {
            SqlConnection con = new SqlConnection(myconnstrng);

            DataTable dt = new DataTable();
            try
            {
                String sql = "delete from DummySales_Transactions_Details where Invoice_No ='" + Invoice_No + "';";
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
