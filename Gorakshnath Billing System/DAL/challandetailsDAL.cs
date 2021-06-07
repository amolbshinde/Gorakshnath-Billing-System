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
    //
{
    class challandetailsDAL
    {
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;

        #region Insert Meathod for Challan Details

        public bool insertchallandetails(challandetailsBLL cb)
        {
            bool isSuccess = false;

            SqlConnection con = new SqlConnection(myconnstrng);

            try
            {
                //inserting transaction details
                string sql = "INSERT INTO Challan_Transactions_Details (Invoice_No,Product_ID,Cust_ID,Product_Name,Unit,Qty,Rate,Dicount_Per,GST_Type,GST_Per,Total,Challan_date) VALUES(@Invoice_No,@Product_ID,@Cust_ID,@Product_Name,@Unit,@Qty,@Rate,@Discount_Per,@GST_Type,@GST_Per,@Total,@Challan_date)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Invoice_No", cb.Invoice_No);
                cmd.Parameters.AddWithValue("@Product_ID", cb.Product_ID);
                cmd.Parameters.AddWithValue("@Cust_ID", cb.Cust_ID);
                cmd.Parameters.AddWithValue("@Product_Name", cb.Product_Name);
                cmd.Parameters.AddWithValue("@Unit", cb.Unit);
                cmd.Parameters.AddWithValue("@Qty", cb.Qty);
                cmd.Parameters.AddWithValue("@Rate", cb.Rate);
                cmd.Parameters.AddWithValue("@Discount_Per", cb.Discount_Per);
                cmd.Parameters.AddWithValue("@GST_Type", cb.GST_Type);
                cmd.Parameters.AddWithValue("@GST_Per", cb.GST_Per);
                cmd.Parameters.AddWithValue("@Total", cb.Total); 
                cmd.Parameters.AddWithValue("@Challan_date", cb.Challan_date); 
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

        #region Select Data By Invoice NO
        public DataTable SelectByInvoiceNo(string Invoice_No)
        {
            SqlConnection con = new SqlConnection(myconnstrng);

            DataTable dt = new DataTable();
            try
            {
                String sql = "select Product_Name,Unit,Qty,Rate,Dicount_Per,GST_Type,GST_Per,Total from Challan_Transactions,Challan_Transactions_Details where Challan_Transactions_Details.Invoice_No=Challan_Transactions.Invoice_No and Challan_Transactions.Invoice_No ='" + Invoice_No + "';";
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

        #region Delete Data By Invoice NO
        public DataTable DeleteByInvoiceNo(string Invoice_No)
        {
            SqlConnection con = new SqlConnection(myconnstrng);

            DataTable dt = new DataTable();
            try
            {
                String sql = "delete from Challan_Transactions_Details where Invoice_No ='" + Invoice_No + "';";
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

        #region
       /* public DataTable GenerateSalesReport(DateTime FromDate, DateTime ToDate)
        {
            SqlConnection con = new SqlConnection(myconnstrng);

            DataTable dt = new DataTable();
            try
            {
                String sql = "Select Product_Name,SUM(Qty),SUM(Total) from Challan_Transactions_Details where Convert(Date,Challan_date) >=  Convert(Date,'" + FromDate.ToString("yyyy-MM-dd") + "') AND  Convert(Date,Challan_date)<=Convert(Date,'" + ToDate.ToString("yyyy-MM-dd") + "') group by Product_Name ORDER BY SUM(Qty) DESC;";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                con.Open();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kindly Select Proper Date !");
                MessageBox.Show(ex.Message);
                
            }
            finally
            {
                con.Close();
            }
            return dt;
        }*/


        public DataTable GenerateSalesReport(DateTime FromDate, DateTime ToDate, Int32 ProductId)
        {
            SqlConnection con = new SqlConnection(myconnstrng);

            DataTable dt = new DataTable();
            try
            {
                if(ProductId==0)
                {
                    String sql = "Select Product_ID,Product_Name,SUM(Qty),SUM(Total),Unit from Challan_Transactions_Details where Convert(Date,Challan_date) >=  Convert(Date,'" + FromDate.ToString("yyyy-MM-dd") + "') AND  Convert(Date,Challan_date)<=Convert(Date,'" + ToDate.ToString("yyyy-MM-dd") + "')  group by Product_Name ORDER BY SUM(Qty) DESC;";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    con.Open();
                    adapter.Fill(dt);
                }
                else
                {
                    String sql = "Select Product_ID,Product_Name,SUM(Qty),SUM(Total),Unit from Challan_Transactions_Details where Convert(Date,Challan_date) >=  Convert(Date,'" + FromDate.ToString("yyyy-MM-dd") + "') AND  Convert(Date,Challan_date)<=Convert(Date,'" + ToDate.ToString("yyyy-MM-dd") + "') AND Product_ID=" + ProductId + " group by Product_Name ORDER BY SUM(Qty) DESC;";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    con.Open();
                    adapter.Fill(dt);

                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kindly Select Proper Date !");
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
