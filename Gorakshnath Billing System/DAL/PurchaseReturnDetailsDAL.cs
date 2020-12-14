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
    class PurchaseReturnDetailsDAL
    {
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;



        #region Select Method For combo box ItemName
        public DataTable SelectItemName(int keyword)
        {
            //Creating Database Connection 
            SqlConnection conn = new SqlConnection(myconnstrng);

            DataTable dt = new DataTable();

            try
            {
                //Wrting SQL Query to get all the data from DAtabase
                string sql = "SELECT Product_Name FROM Purchase_Transaction_Details WHERE Purchase_ID=" + keyword;

                SqlCommand cmd = new SqlCommand(sql, conn);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                //Open DAtabase Connection
                conn.Open();
                //Adding the value from adapter to Data TAble dt
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

        #region Insert Method for Purchase Return Details

        public bool insertPurchaseReturnDetails(PurchaseReturnDetailsBLL prdBLL)
        {
            bool isSuccess = false;

            SqlConnection con = new SqlConnection(myconnstrng);

            try
            {
                //inserting transaction details
                string sql = "INSERT INTO SalesReturn_Transactions_Details (Invoice_No,Product_ID,Sup_ID,Product_Name,Unit,Qty,Rate,Discount_Per,GST_Type,GST_Per,Total) VALUES(@Invoice_No,@Product_ID,@Sup_ID,@Product_Name,@Unit,@Qty,@Rate,@Discount_Per,@GST_Type,@GST_Per,@Total)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Invoice_No", prdBLL.Invoice_No);
                cmd.Parameters.AddWithValue("@Product_ID", prdBLL.Product_ID);
                cmd.Parameters.AddWithValue("@Sup_ID", prdBLL.Sup_ID);
                cmd.Parameters.AddWithValue("@Product_Name", prdBLL.Product_Name);
                cmd.Parameters.AddWithValue("@Unit", prdBLL.Unit);
                cmd.Parameters.AddWithValue("@Qty", prdBLL.Qty);
                cmd.Parameters.AddWithValue("@Rate", prdBLL.Rate);
                cmd.Parameters.AddWithValue("@Discount_Per", prdBLL.Discount_Per);
                cmd.Parameters.AddWithValue("@GST_Type", prdBLL.GST_Type);
                cmd.Parameters.AddWithValue("@GST_Per", prdBLL.GST_Per);
                cmd.Parameters.AddWithValue("@Total", prdBLL.Total);
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


        #region METHOD TO Get Product Details for challan return
        public PurchaseReturnDetailsBLL GetProductForPurchaseReturn(string keyword)
        {
            PurchaseReturnDetailsBLL prBLL  = new PurchaseReturnDetailsBLL();
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                string sql = "select * from Purchase_Transaction_Details where Product_Name LIKE'%" + keyword + "%' ";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);

                conn.Open();

                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    prBLL.Unit = dt.Rows[0]["Unit"].ToString();
                    prBLL.Qty = decimal.Parse(dt.Rows[0]["Qty"].ToString());
                    prBLL.Rate = decimal.Parse(dt.Rows[0]["Rate"].ToString());
                    prBLL.Discount_Per = decimal.Parse(dt.Rows[0]["Discount_Per"].ToString());
                    prBLL.GST_Type = dt.Rows[0]["GST_Type"].ToString();
                    prBLL.GST_Per = decimal.Parse(dt.Rows[0]["GST_Per"].ToString());
                    prBLL.Total = decimal.Parse(dt.Rows[0]["Total"].ToString());
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

            return prBLL;
        }
        #endregion


    }
}
