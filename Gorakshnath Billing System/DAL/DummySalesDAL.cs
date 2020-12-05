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
    class DummySalesDAL
    {
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        //insert recored into salestransaction
        #region Insert Data in Database

        public bool insertDummySales(DummySalesBLL dsb, out int Cust_ID)
        {
            bool isSuccess = false;
            Cust_ID = -1;
            SqlConnection con = new SqlConnection(myconnstrng);
            try
            {
                String sql = "INSERT INTO DummySales_Transactions (Invoice_No,Cust_ID,Sub_Total,TDiscount,TSGST,TCGST,TIGST,Grand_Total) VALUES(@Invoice_No,@Cust_ID,@Sub_Total,@TDiscount,@TSGST,@TCGST,@TIGST,@Grand_Total);select @@IDENTITY;";

                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@Sales_ID", dsb.Sales_ID);
                cmd.Parameters.AddWithValue("@Invoice_No", dsb.Invoice_No);
                cmd.Parameters.AddWithValue("@Cust_ID", dsb.Cust_ID);
                cmd.Parameters.AddWithValue("@Sub_Total", dsb.Sub_Total);
                cmd.Parameters.AddWithValue("@TDiscount", dsb.TDiscount);
                cmd.Parameters.AddWithValue("@TSGST", dsb.TSGST);
                cmd.Parameters.AddWithValue("@TCGST", dsb.TCGST);
                cmd.Parameters.AddWithValue("@TIGST", dsb.TIGST);
                cmd.Parameters.AddWithValue("@Grand_Total", dsb.Grand_Total);

                con.Open();

                object o = cmd.ExecuteScalar();

                if (o != null)
                {
                    isSuccess = true;
                    Cust_ID = int.Parse(o.ToString());
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
