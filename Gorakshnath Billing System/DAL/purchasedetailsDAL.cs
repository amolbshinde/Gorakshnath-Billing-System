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
        public bool insertsalesdetails(salesdetailsBLL st)
        {
            bool isSuccess = false;

            SqlConnection con = new SqlConnection(myconnstrng);

            try
            {
                string sql = "INSERT INTO tbl_purchase_transaction_detail(product_id,rate,qty,total,sup_id,added_date,added_by) VALUES(@productid,@rate,@qty,@total,@custid,@addeddate,@added_by)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@productid", st.productid);
                cmd.Parameters.AddWithValue("@rate", st.rate);
                cmd.Parameters.AddWithValue("@qty", st.qty);
                cmd.Parameters.AddWithValue("@total", st.total);
                cmd.Parameters.AddWithValue("@custid", st.custid);
                cmd.Parameters.AddWithValue("@addeddate", st.addeddate);
                cmd.Parameters.AddWithValue("@added_by", 8);

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
