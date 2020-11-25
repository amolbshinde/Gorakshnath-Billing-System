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
    class salesDAL
    {
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        #region Insert Sales Method
        public bool insertsales(salesBLL s, out int salesID)
        {
            bool isSuccess = false;
            salesID = -1;
            SqlConnection con = new SqlConnection(myconnstrng);
            try
            {
                String sql = "INSERT INTO tblsales (custid,grandTotal,gst,discount) VALUES(@custid,@grandTotal,@gst,@discount);select @@IDENTITY;";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@custid", s.custid);
                cmd.Parameters.AddWithValue("@grandtotal", s.grandtotal);
                cmd.Parameters.AddWithValue("@gst", s.gst);
                cmd.Parameters.AddWithValue("@discount", s.discount);

                con.Open();

                object o = cmd.ExecuteScalar();

                if (o != null)
                {
                    isSuccess = true;
                    salesID = int.Parse(o.ToString());
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
