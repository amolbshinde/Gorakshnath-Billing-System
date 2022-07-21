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
    class purchasedetailsDAL
    {
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;

        #region Insert method for Purchase_Transaction_Details
        public bool insertpurchasedetails(purchasedetailsBLL st)
        {
            bool isSuccess = false;

            SqlConnection con = new SqlConnection(myconnstrng);

            try
            {
                //inserting transaction details
                string sql = "INSERT INTO Purchase_Transaction_Details(Purchase_ID,Product_ID,Sup_ID,Product_Name,Unit,Qty,Rate,Discount_Per,GST_Type,GST_Per,Total) VALUES(@Purchase_ID,@Product_ID,@Sup_ID,@Product_Name,@Unit,@Qty,@Purchase_Prise,@Discount_Per,@GST_Type,@GST_Per,@Total)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Purchase_ID", st.Purchase_ID);
                cmd.Parameters.AddWithValue("@Product_ID", st.Product_ID);                
                cmd.Parameters.AddWithValue("@Sup_ID", st.Sup_ID);
                cmd.Parameters.AddWithValue("@Product_Name", st.Product_Name);
                cmd.Parameters.AddWithValue("@Unit", st.Unit);
                cmd.Parameters.AddWithValue("@Qty", st.Qty);
                cmd.Parameters.AddWithValue("@Purchase_Prise", st.Rate);
                cmd.Parameters.AddWithValue("@Discount_Per", st.Discount_Per);
                cmd.Parameters.AddWithValue("@GST_Type", st.GST_Type);
                cmd.Parameters.AddWithValue("@GST_Per", st.GST_Per);
                cmd.Parameters.AddWithValue("@Total", st.Total);



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


        #region Select Data By Purchase Id
        public DataTable SelectByPurchaseId(string Purchase_ID)
        {
            SqlConnection con = new SqlConnection(myconnstrng);

            DataTable dt = new DataTable();
            try
            {
                String sql = " select Product_Name,Unit,Qty,Rate,Discount_Per,GST_Type,GST_Per,Total from Purchase_Transactions,Purchase_Transaction_Details where Purchase_Transactions.Purchase_ID=Purchase_Transaction_Details.Purchase_ID and Purchase_Transactions.Purchase_ID = '" + Purchase_ID + "';";
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
        public DataTable DeleteByPurchaseID(string Purchase_ID)
        {
            SqlConnection con = new SqlConnection(myconnstrng);

            DataTable dt = new DataTable();
            try
            {
                String sql = "delete from Purchase_Transaction_Details where Purchase_ID ='" + Purchase_ID + "';";
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
