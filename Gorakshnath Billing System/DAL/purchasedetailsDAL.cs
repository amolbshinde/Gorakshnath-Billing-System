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
    class purchasedetailsDAL
    {
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;

        #region Insert method for SalesDetails
        public bool insertpurchasedetails(purchasedetailsBLL st)
        {
            bool isSuccess = false;

            SqlConnection con = new SqlConnection(myconnstrng);

            try
            {
                //inserting transaction details
                string sql = "INSERT INTO tbl_purchase_transaction_detail(product_id,rate,qty,total,sup_id) VALUES(@product_id,@rate,@qty,@total,@sup_id)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@product_id", st.productid);
                cmd.Parameters.AddWithValue("@rate", st.rate);
                cmd.Parameters.AddWithValue("@qty", st.qty);
                cmd.Parameters.AddWithValue("@total", st.total);
                cmd.Parameters.AddWithValue("@sup_id", st.supid);                

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
