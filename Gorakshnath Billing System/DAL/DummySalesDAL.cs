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
    class DummySalesDAL
    {
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        //insert recored into salestransaction
        #region Insert Data in Database

        public bool insertDummySales(DummySalesBLL dsb)
        {
            bool isSuccess = false;
            
           
            
            SqlConnection con = new SqlConnection(myconnstrng);
            try
            {
                String sql = " SET IDENTITY_INSERT DummySales_Transactions ON INSERT INTO DummySales_Transactions (Invoice_No,Transaction_Type,Cust_ID,Sub_Total,TDiscount,TSGST,TCGST,TIGST,Grand_Total,Challan_date) VALUES(@Invoice_No,@Transaction_Type,@Cust_ID,@Sub_Total,@TDiscount,@TSGST,@TCGST,@TIGST,@Grand_Total,@Challan_date);SET IDENTITY_INSERT DummySales_Transactions OFF";

                SqlCommand cmd = new SqlCommand(sql, con);
                //cmd.Parameters.AddWithValue("@Invoice_No", dsb.Invoice_No);
                cmd.Parameters.AddWithValue("@Invoice_No", dsb.Invoice_No);
                cmd.Parameters.AddWithValue("@Transaction_Type", dsb.Transaction_Type);
                cmd.Parameters.AddWithValue("@Cust_ID", dsb.Cust_ID);
                cmd.Parameters.AddWithValue("@Sub_Total", dsb.Sub_Total);
                cmd.Parameters.AddWithValue("@TDiscount", dsb.TDiscount);
                cmd.Parameters.AddWithValue("@TSGST", dsb.TSGST);
                cmd.Parameters.AddWithValue("@TCGST", dsb.TCGST);
                cmd.Parameters.AddWithValue("@TIGST", dsb.TIGST);
                cmd.Parameters.AddWithValue("@Grand_Total", dsb.Grand_Total);
                cmd.Parameters.AddWithValue("@Challan_date", dsb.Challan_date);

                con.Open();

                int a = cmd.ExecuteNonQuery();
               


                if (a!= 0)
                {
                    isSuccess = true;
                   // Invoice_No = int.Parse(Convert.ToString(o));
                  
                    
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


        #region Select Data From Database
        public DataTable SelectTD()
        {
            SqlConnection con = new SqlConnection(myconnstrng);

            DataTable dt = new DataTable();
            try
            {
                String sql = "select Invoice_No,Cust_Name,Cust_Contact,Transaction_Type,Sub_Total,TDiscount,TSGST,TCGST,TIGST,Grand_Total,Transaction_Type from DummySales_Transactions,Cust_Master where Cust_Master.Cust_ID=DummySales_Transactions.Cust_ID;";
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
                String sql = "select Invoice_No,Cust_Name,Cust_Contact,Transaction_Type,Sub_Total,TDiscount,TSGST,TCGST,TIGST,Grand_Total,Transaction_Type from DummySales_Transactions,Cust_Master where Cust_Master.Cust_ID=DummySales_Transactions.Cust_ID and DummySales_Transactions.Invoice_No LIKE '%" + Invoice_No + "%';";
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
                String sql = "select Invoice_No,Cust_Name,Cust_Contact,Transaction_Type,Sub_Total,TDiscount,TSGST,TCGST,TIGST,Grand_Total,Transaction_Type from DummySales_Transactions,Cust_Master where Cust_Master.Cust_ID=DummySales_Transactions.Cust_ID and Cust_Master.Cust_Name LIKE '%" + Cust_Name + "%';";
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
                String sql = "select Invoice_No,Cust_Name,Cust_Contact,Transaction_Type,Sub_Total,TDiscount,TSGST,TCGST,TIGST,Grand_Total,Transaction_Type from DummySales_Transactions,Cust_Master where Cust_Master.Cust_ID=DummySales_Transactions.Cust_ID and Cust_Master.Cust_Contact LIKE '%" + Cust_Mobile + "%';";
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
                String sql = "delete from DummySales_Transactions where Invoice_No ='" + Invoice_No + "';";
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

        #region Method to get Maxproduct -GetMaxProductId() Id From Database

        public int GetMaxInvoiceID()
        {
            SqlConnection con = new SqlConnection(myconnstrng);
            int maxnum = 0;

            //DataTable dt = new DataTable();
            try
            {
                String sql = "SELECT COALESCE (MAX(Invoice_No),0) AS MaxOf FROM DummySales_Transactions";
                SqlCommand cmd = new SqlCommand(sql, con);
                //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                con.Open();
                //
                //adapter.Fill(dt);
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

    }
}
