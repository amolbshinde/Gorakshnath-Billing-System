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
    class supplierDAL
    {
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        
        #region Method  to search supplier for purchase module

        public supplierBLL searchsupplierforpurchase(string keyword)
        {
            supplierBLL sup_BLL = new supplierBLL();

            SqlConnection con = new SqlConnection(myconnstrng);

            DataTable dt = new DataTable();

            try
            {
                string sql = "SELECT name, contact, email,address from tbl_supplier WHERE id LIKE '%" + keyword + "%' OR name LIKE '%" + keyword + "%'";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, con);

                con.Open();

                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    sup_BLL.name = dt.Rows[0]["name"].ToString();
                    sup_BLL.contact = dt.Rows[0]["contact"].ToString();
                    sup_BLL.email = dt.Rows[0]["email"].ToString();
                    sup_BLL.address = dt.Rows[0]["address"].ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
            return sup_BLL;
        }

        #endregion
        #region Method to get id of the Customer based on Name
        public customerBLL getCustomerIdFromName(string Name)
        {
            customerBLL c = new customerBLL();
            SqlConnection con = new SqlConnection(myconnstrng);

            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT id FROM tbl_supplier WHERE name='" + Name + "'";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                con.Open();
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    c.id = int.Parse(dt.Rows[0]["id"].ToString());
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

            return c;
        }
        #endregion
    }
}

