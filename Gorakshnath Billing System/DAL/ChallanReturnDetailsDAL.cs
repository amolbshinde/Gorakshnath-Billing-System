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
    class ChallanReturnDetailsDAL
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
                string sql = "SELECT Product_Name,Product_ID FROM Challan_Transactions_Details WHERE Invoice_No=" + keyword;

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

        #region Insert Meathod for Sales Return Details

        public bool insertSalesReturndetails(ChallanReturnDetailsBLL crdBLL)
        {
            bool isSuccess = false;

            SqlConnection con = new SqlConnection(myconnstrng);

            try
            {
                //inserting transaction details
                string sql = "INSERT INTO SalesReturn_Transactions_Details (Invoice_No,Product_ID,Cust_ID,Product_Name,Unit,Qty,Rate,Dicount_Per,GST_Type,GST_Per,Total) VALUES(@Invoice_No,@Product_ID,@Cust_ID,@Product_Name,@Unit,@Qty,@Rate,@Discount_Per,@GST_Type,@GST_Per,@Total)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Invoice_No", crdBLL.Invoice_No);
                cmd.Parameters.AddWithValue("@Product_ID", crdBLL.Product_ID);
                cmd.Parameters.AddWithValue("@Cust_ID", crdBLL.Cust_ID);
                cmd.Parameters.AddWithValue("@Product_Name", crdBLL.Product_Name);
                cmd.Parameters.AddWithValue("@Unit", crdBLL.Unit);
                cmd.Parameters.AddWithValue("@Qty", crdBLL.Qty);
                cmd.Parameters.AddWithValue("@Rate", crdBLL.Rate);
                cmd.Parameters.AddWithValue("@Discount_Per", crdBLL.Discount_Per);
                cmd.Parameters.AddWithValue("@GST_Type", crdBLL.GST_Type);
                cmd.Parameters.AddWithValue("@GST_Per", crdBLL.GST_Per);
                cmd.Parameters.AddWithValue("@Total", crdBLL.Total);
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
        public ChallanReturnDetailsBLL GetProductForChallanReturn(string keyword)
        {
            ChallanReturnDetailsBLL crBLL = new ChallanReturnDetailsBLL();
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                string sql = "select * from Challan_Transactions_Details where Product_Name LIKE'%" + keyword + "%' ";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);

                conn.Open();

                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    crBLL.Unit = dt.Rows[0]["Unit"].ToString();
                    crBLL.Qty = decimal.Parse(dt.Rows[0]["Qty"].ToString());
                    crBLL.Rate = decimal.Parse(dt.Rows[0]["Rate"].ToString());
                    crBLL.Discount_Per = decimal.Parse(dt.Rows[0]["Dicount_Per"].ToString());
                    crBLL.GST_Type = dt.Rows[0]["GST_Type"].ToString();
                    crBLL.GST_Per = decimal.Parse(dt.Rows[0]["GST_Per"].ToString());
                    crBLL.Total = decimal.Parse(dt.Rows[0]["Total"].ToString());
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

            return crBLL;
        }
        #endregion


    }
}
