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
        #region Insert Purchase_Transactions Method
        public bool insertpurchase(purchaseBLL p, out int purchaseID)
        {
            bool isSuccess = false;
            purchaseID = -1;
            SqlConnection con = new SqlConnection(myconnstrng);
            try
            {
                String sql = "INSERT INTO Purchase_Transactions (type,Sup_ID,Sub_Total,TDiscount,TSGST,TCGST,TIGST,Grand_Total) VALUES(@type,@sup_id,@subTotal,@totalDiscount,@totalSgst,@totalCgst,@totalIgst,@grandTotal);select @@IDENTITY;";

                SqlCommand cmd = new SqlCommand(sql, con);
                //add parameteres  values 
                cmd.Parameters.AddWithValue("@type", p.Transaction_Type);
                cmd.Parameters.AddWithValue("@sup_id", p.Sup_ID);
                cmd.Parameters.AddWithValue("@subTotal", p.Sub_Total);
                cmd.Parameters.AddWithValue("@totalDiscount", p.TDiscount);
                cmd.Parameters.AddWithValue("@totalSgst", p.TSGST);
                cmd.Parameters.AddWithValue("@totalCgst", p.TCGST);
                cmd.Parameters.AddWithValue("@totalIgst", p.TIGST);
                cmd.Parameters.AddWithValue("@grandTotal", p.Grand_Total);

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
