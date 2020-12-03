using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gorakshnath_Billing_System.DAL
{
    class DummySalesDAL
    {
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
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

                cmd.Parameters.AddWithValue("@Sales_ID", c.Sales_ID);
                cmd.Parameters.AddWithValue("@Invoice_No", c.Invoice_No);
                cmd.Parameters.AddWithValue("@Cust_ID", c.Cust_ID);
                cmd.Parameters.AddWithValue("@Sub_Total", c.Sub_Total);
                cmd.Parameters.AddWithValue("@TDiscount", c.TDiscount);
                cmd.Parameters.AddWithValue("@TSGST", c.TSGST);
                cmd.Parameters.AddWithValue("@TCGST", c.TCGST);
                cmd.Parameters.AddWithValue("@TIGST", c.TIGST);
                cmd.Parameters.AddWithValue("@Grand_Total", c.Grand_Total);

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
