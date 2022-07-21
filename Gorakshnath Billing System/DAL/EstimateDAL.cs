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
    class EstimateDAL
    {

        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;

        #region Insert Data in Database

        public bool insertEstimate(EstimateBLL c)
        {
            bool isSuccess = true;
            //Invoice_No = -1;
            SqlConnection con = new SqlConnection(myconnstrng);
            try
            {
                String sql = "SET IDENTITY_INSERT Estimate_Transactions ON INSERT INTO Estimate_Transactions (Invoice_No,Transaction_Type,Cust_ID,Sub_Total,TDiscount,TSGST,TCGST,TIGST,Grand_Total) VALUES(@Invoice_No,@Transaction_Type,@Cust_ID,@Sub_Total,@TDiscount,@TSGST,@TCGST,@TIGST,@Grand_Total)SET IDENTITY_INSERT Estimate_Transactions OFF;";

                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@Invoice_No", c.Invoice_No);
                cmd.Parameters.AddWithValue("@Transaction_Type", c.Transaction_Type);
                cmd.Parameters.AddWithValue("@Cust_ID", c.Cust_ID);
                cmd.Parameters.AddWithValue("@Sub_Total", c.Sub_Total);
                cmd.Parameters.AddWithValue("@TDiscount", c.TDiscount);
                cmd.Parameters.AddWithValue("@TSGST", c.TSGST);
                cmd.Parameters.AddWithValue("@TCGST", c.TCGST);
                cmd.Parameters.AddWithValue("@TIGST", c.TIGST);
                cmd.Parameters.AddWithValue("@Grand_Total", c.Grand_Total);

                con.Open();

                object o = cmd.ExecuteScalar();

                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                isSuccess = false;
            }
            finally
            {
                con.Close();
            }
            return isSuccess;
        }
        #endregion



        #region Select Data From Database
        public DataTable SelectTD()
        {
            SqlConnection con = new SqlConnection(myconnstrng);

            DataTable dt = new DataTable();
            try
            {
                String sql = "select Invoice_No,Cust_Name,Cust_Contact,Transaction_Type,Sub_Total,TDiscount,TSGST,TCGST,TIGST,Grand_Total,Estimate_date from Estimate_Transactions,Cust_Master where Cust_Master.Cust_ID=Estimate_Transactions.Cust_ID;";
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
        public DataTable SelectByInvoiceNo(string Invoice_No)
        {
            SqlConnection con = new SqlConnection(myconnstrng);

            DataTable dt = new DataTable();
            try
            {
                String sql = "select Invoice_No,Cust_Name,Cust_Contact,Transaction_Type,Sub_Total,TDiscount,TSGST,TCGST,TIGST,Grand_Total,Estimate_date from Estimate_Transactions,Cust_Master where Cust_Master.Cust_ID=Estimate_Transactions.Cust_ID and Estimate_Transactions.Invoice_No LIKE '%" + Invoice_No + "%';";
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


        #region Select Data By Customer Name
        public DataTable SelectByCustName(string Cust_Name)
        {
            SqlConnection con = new SqlConnection(myconnstrng);

            DataTable dt = new DataTable();
            try
            {
                String sql = "select Invoice_No,Cust_Name,Cust_Contact,Transaction_Type,Sub_Total,TDiscount,TSGST,TCGST,TIGST,Grand_Total,Estimate_date from Estimate_Transactions,Cust_Master where Cust_Master.Cust_ID=Estimate_Transactions.Cust_ID and Cust_Master.Cust_Name LIKE '%" + Cust_Name + "%';";
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
        public DataTable SelectByMobileNo(string Cust_Mobile)
        {
            SqlConnection con = new SqlConnection(myconnstrng);

            DataTable dt = new DataTable();
            try
            {
                String sql = "select Invoice_No,Cust_Name,Cust_Contact,Transaction_Type,Sub_Total,TDiscount,TSGST,TCGST,TIGST,Grand_Total,Estimate_date from Estimate_Transactions,Cust_Master where Cust_Master.Cust_ID=Estimate_Transactions.Cust_ID and Cust_Master.Cust_Contact LIKE '%" + Cust_Mobile + "%';";
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


        #region Delete Data By Invoice NO
        public DataTable DeleteByInvoiceNo(string Invoice_No)
        {
            SqlConnection con = new SqlConnection(myconnstrng);

            DataTable dt = new DataTable();
            try
            {
                String sql = "delete from Estimate_Transactions where Invoice_No ='" + Invoice_No + "';";
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

        #region Fetch Max Invoice ID for Quotation 
        public int GetMaxInvoiceIDForQuotation()
        {
            SqlConnection con = new SqlConnection(myconnstrng);
            int maxnum = -1;
            try
            {
                String sql = "SELECT COALESCE (MAX(Invoice_No),0) AS MaxOf FROM  Estimate_Transactions";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                con.Open();
                maxnum = Convert.ToInt32(cmd.ExecuteScalar());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return maxnum;
        }
        #endregion


        #region Fetch Report Details Runtime
        public DataTable FetchRuntime(string keywords)
        {
            SqlConnection con = new SqlConnection(myconnstrng);

            DataTable dt = new DataTable();
            try
            {
                String sql = "select Invoice_No,Cust_Name,Cust_Contact,Transaction_Type,Sub_Total,TDiscount,TSGST,TCGST,TIGST,Grand_Total,Estimate_date from Estimate_Transactions,Cust_Master where Cust_Master.Cust_ID=Estimate_Transactions.Cust_ID AND (Invoice_No LIKE'%" + keywords + "%' OR Cust_Name LIKE'%" + keywords + "%' OR Cust_Contact LIKE'%" + keywords + "%');";
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
