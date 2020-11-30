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
        public bool insertpurchase(purchaseBLL p, out int purchaseID)
        {
            bool isSuccess = false;
            purchaseID = -1;
            SqlConnection con = new SqlConnection(myconnstrng);
            try
            {
                String sql = "INSERT INTO tbl_purchase_transactions (type,sup_id,subTotal,totalDiscount,totalSgst,totalCgst,totalIgst,grandTotal) VALUES(@type,@sup_id,@subTotal,@totalDiscount,@totalSgst,@totalCgst,@totalIgst,@grandTotal);select @@IDENTITY;";

                SqlCommand cmd = new SqlCommand(sql, con);
                
                cmd.Parameters.AddWithValue("@type", p.type);
                cmd.Parameters.AddWithValue("@sup_id", p.supid);
                cmd.Parameters.AddWithValue("@subTotal", p.subTotal);
                cmd.Parameters.AddWithValue("@totalDiscount", p.totalDiscount);
                cmd.Parameters.AddWithValue("@totalSgst", p.totalSgst);
                cmd.Parameters.AddWithValue("@totalCgst", p.totalCgst);
                cmd.Parameters.AddWithValue("@totalIgst", p.totalIgst);
                cmd.Parameters.AddWithValue("@grandTotal", p.grandTotal);

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
