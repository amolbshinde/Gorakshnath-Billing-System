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
    class purchaseDAL   
    {
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        #region Insert Sales Method
        public bool insertpurchase(purchaseBLL s, out int purchaseID)
        {
            bool isSuccess = false;
            purchaseID = -1;
            SqlConnection con = new SqlConnection(myconnstrng);
            try
            {
                String sql = "INSERT INTO tbl_purchase_transactions (sup_id,grandTotal,transaction_date,tax,discount) VALUES(@dea_cust_id,@grandTotal,@transaction_date,@tax,@discount);select @@IDENTITY;";

                SqlCommand cmd = new SqlCommand(sql, con);
                
                cmd.Parameters.AddWithValue("@dea_cust_id", s.supid);
                cmd.Parameters.AddWithValue("@grandtotal", s.grandtotal);
                cmd.Parameters.AddWithValue("@transaction_date", s.purchasedate);
                cmd.Parameters.AddWithValue("@tax", s.gst);
                cmd.Parameters.AddWithValue("@discount", s.discount);
                

                con.Open();

                object o = cmd.ExecuteScalar();

                if (o != null)
                {
                    isSuccess = true;
                    purchaseID = int.Parse(o.ToString());
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
                con.Close();
            }
            return isSuccess;
        }

        #endregion
    }
}
