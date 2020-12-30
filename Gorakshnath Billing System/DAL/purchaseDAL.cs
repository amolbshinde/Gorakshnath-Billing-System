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
    class purchaseDAL   
    {
        //jhdff
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        #region Insert Purchase_Transactions Method
        public bool insertpurchase(purchaseBLL p, out int purchaseID)
        {
            bool isSuccess = false;
            purchaseID = -1;
            SqlConnection con = new SqlConnection(myconnstrng);
            try
            {
                String sql = "INSERT INTO Purchase_Transactions (Transaction_Type,Sup_ID,Sub_Total,TDiscount,TSGST,TCGST,TIGST,Grand_Total) VALUES(@Transaction_Type,@sup_id,@subTotal,@totalDiscount,@totalSgst,@totalCgst,@totalIgst,@grandTotal);select @@IDENTITY;";

                SqlCommand cmd = new SqlCommand(sql, con);
                //add parameteres  values 
                cmd.Parameters.AddWithValue("@Transaction_Type", p.Transaction_Type);
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

        #region Update Data in Database challan
        public bool Update(purchaseBLL c)
        {
            bool isSuccess = false;
            SqlConnection con = new SqlConnection(myconnstrng);
            try
            {
                String sql = "UPDATE Purchase_Transactions SET Transaction_Type=@Transaction_Type, Sup_ID=@Sup_ID, Sub_Total=@Sub_Total, TDiscount=@TDiscount, TSGST=@TSGST, TCGST=@TCGST, TIGST=@TIGST, Grand_Total=@Grand_Total WHERE Purchase_ID = @Purchase_ID";
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@Purchase_ID", c.Purchase_ID);
                cmd.Parameters.AddWithValue("@Transaction_Type", c.Transaction_Type);
                cmd.Parameters.AddWithValue("@Sup_ID", c.Sup_ID);
                cmd.Parameters.AddWithValue("@Sub_Total", c.Sub_Total);
                cmd.Parameters.AddWithValue("@TDiscount", c.TDiscount);
                cmd.Parameters.AddWithValue("@TSGST", c.TSGST);
                cmd.Parameters.AddWithValue("@TCGST", c.TCGST);
                cmd.Parameters.AddWithValue("@TIGST", c.TIGST);
                cmd.Parameters.AddWithValue("@Grand_Total", c.Grand_Total);

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
                con.Close();
            }

            return isSuccess;

        }
        #endregion



        #region Delete Data By Invoice NO
        public DataTable DeleteByPurchaseID(string Purchase_ID)
        {
            SqlConnection con = new SqlConnection(myconnstrng);

            DataTable dt = new DataTable();
            try
            {
                String sql = "delete from Purchase_Transactions where Purchase_ID ='" + Purchase_ID + "';";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                con.Open();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return dt;
        }
        #endregion



        #region Select Data From Database
        public DataTable SelectPD()
        {
            SqlConnection con = new SqlConnection(myconnstrng);

            DataTable dt = new DataTable();
            try
            {
                String sql = "select Purchase_ID,CompanyName,Phone_No,Transaction_Type,Sub_Total,TDiscount,TSGST,TCGST,TIGST,Grand_Total,Purchase_Date from Purchase_Transactions,Supplier_Master where Supplier_Master.SupplierID=Purchase_Transactions.Sup_ID;";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                con.Open();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return dt;
        }
        #endregion


        #region Select Data By Purchase Id
        public DataTable SelectByPurchaseId(string Purchase_ID)
        {
            SqlConnection con = new SqlConnection(myconnstrng);

            DataTable dt = new DataTable();
            try
            {
                String sql = "select Purchase_ID,CompanyName,Phone_No,Transaction_Type,Sub_Total,TDiscount,TSGST,TCGST,TIGST,Grand_Total,Purchase_Date from Purchase_Transactions,Supplier_Master where Supplier_Master.SupplierID=Purchase_Transactions.Sup_ID and Purchase_Transactions.Purchase_ID LIKE '%" + Purchase_ID + "%';";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                con.Open();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return dt;
        }
        #endregion


        #region Select Data By Supplier Name
        public DataTable SelectBySupName(string CompanyName)
        {
            SqlConnection con = new SqlConnection(myconnstrng);

            DataTable dt = new DataTable();
            try
            {
                String sql = "select Purchase_ID,CompanyName,Phone_No,Transaction_Type,Sub_Total,TDiscount,TSGST,TCGST,TIGST,Grand_Total,Purchase_Date from Purchase_Transactions,Supplier_Master where Supplier_Master.SupplierID=Purchase_Transactions.Sup_ID and Supplier_Master.CompanyName LIKE '%" + CompanyName + "%';";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                con.Open();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return dt;
        }
        #endregion


        #region Select Data By Mobile NO
        public DataTable SelectByMobileNo(string Phone_No)
        {
            SqlConnection con = new SqlConnection(myconnstrng);

            DataTable dt = new DataTable();
            try
            {
                String sql = "select Purchase_ID,CompanyName,Phone_No,Transaction_Type,Sub_Total,TDiscount,TSGST,TCGST,TIGST,Grand_Total,Purchase_Date from Purchase_Transactions,Supplier_Master where Supplier_Master.SupplierID=Purchase_Transactions.Sup_ID and Supplier_Master.Phone_No LIKE '%" + Phone_No + "%';";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                con.Open();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return dt;
        }
        #endregion


        #region Select Data By Invoice NO
        public DataTable SelectByPurchaseIdManage(string Purchase_ID)
        {
            SqlConnection con = new SqlConnection(myconnstrng);

            DataTable dt = new DataTable();
            try
            {
                String sql = "select Purchase_ID,CompanyName,Phone_No,Email,Address,Transaction_Type,Sub_Total,TDiscount,TSGST,TCGST,TIGST,Grand_Total,Purchase_Date from Purchase_Transactions,Supplier_Master where Supplier_Master.SupplierID=Purchase_Transactions.Sup_ID and Purchase_Transactions.Purchase_ID = '" + Purchase_ID + "';";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                con.Open();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return dt;
        }
        #endregion


    }
}
