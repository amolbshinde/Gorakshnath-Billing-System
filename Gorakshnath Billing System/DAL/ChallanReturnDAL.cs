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
    class ChallanReturnDAL
    {

        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;

        #region Select Method For combo box Invoice NO
        public DataTable SelectInvoiceNo()
        {
            //Creating Database Connection 
            SqlConnection conn = new SqlConnection(myconnstrng);

            DataTable dt = new DataTable();

            try
            {
                //Wrting SQL Query to get all the data from DAtabase
                string sql = "SELECT Invoice_No FROM Challan_Transactions";

                SqlCommand cmd = new SqlCommand(sql, conn);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                //Open DAtabase Connection
                conn.Open();
                //Adding the value from adapter to Data TAble dt
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return dt;
        }
        #endregion



        #region METHOD TO SEARCH PRODUCT IN TRANSACTION MODULE
        public ChallanReturnBLL GetProductsForTransaction(string keyword)
        {
            ChallanReturnBLL crBLL = new ChallanReturnBLL();
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {                
                string sql = "select * from Challan_Transactions,Cust_Master where Challan_Transactions.Cust_ID = Cust_Master.Cust_Id and Challan_Transactions.Invoice_No = '%" + keyword + "%';";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);

                conn.Open();

                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    //p.Item_Code = dt.Rows[0]["Item_Code"].ToString();                    
                    crBLL.Cust_Name = dt.Rows[0]["Cust_Name"].ToString();
                    crBLL.Cust_Contact = dt.Rows[0]["Cust_Contact"].ToString();
                    crBLL.Cust_Address = dt.Rows[0]["Cust_Name"].ToString();
                    crBLL.Cust_Email = dt.Rows[0]["Cust_Name"].ToString();
                    crBLL.Transaction_Type = dt.Rows[0]["Cust_Name"].ToString();                    

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return crBLL;
        }
        #endregion



    }
}
