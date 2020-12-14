﻿using Gorakshnath_Billing_System.BLL;
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
    class PurchaseReturnDAL
    {
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;

        #region Select Method For combo box Invoice NO
        public DataTable SelectPurchaseId()
        {
            //Creating Database Connection 
            SqlConnection conn = new SqlConnection(myconnstrng);

            DataTable dt = new DataTable();

            try
            {
                //Wrting SQL Query to get all the data from DAtabase
                string sql = "SELECT Purchase_ID FROM Purchase_Transactions";

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
        //get suplier details
        #region METHOD TO Get Suplier Details for Purchase return
        public PurchaseReturnBLL GetSuplierForPurchaseReturn(int keyword)
        {
            PurchaseReturnBLL prBLL = new PurchaseReturnBLL();
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                string sql = "select * from tbl_purchase_transactions,Supplier_Master where tbl_purchase_transactions.id = Supplier_Master.SupplierID and tbl_purchase_transactions.id = " + keyword;
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);

                conn.Open();

                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    //p.Item_Code = dt.Rows[0]["Item_Code"].ToString();                    
                    prBLL.Sup_Name = dt.Rows[0]["CompanyName"].ToString();
                    prBLL.Sup_Contact = dt.Rows[0]["Phone_No"].ToString();
                    prBLL.Sup_Address = dt.Rows[0]["Address"].ToString();
                    prBLL.Sup_Email = dt.Rows[0]["Email"].ToString();
                    prBLL.Transaction_Type = dt.Rows[0]["Transaction_Type"].ToString();
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

            return prBLL;
        }
        #endregion     

        #region Insert Data in Purchase Return

        public bool insertPurchaseReturn(PurchaseReturnBLL br, out int Invoice_No)
        {
            bool isSuccess = false;
            Invoice_No = -1;
            SqlConnection con = new SqlConnection(myconnstrng);
            try
            {
                String sql = "INSERT INTO SalesReturn_Transactions(Purchase_ID,Transaction_Type,Sup_ID,Sub_Total,TDiscount,TSGST,TCGST,TIGST,Grand_Total,Reson) VALUES(@Purchase_ID,@Transaction_Type,@Sup_ID,@Sub_Total,@TDiscount,@TSGST,@TCGST,@TIGST,@Grand_Total,@Reson);select @@IDENTITY;";

                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@Purchase_ID", br.Purchase_ID);
                cmd.Parameters.AddWithValue("@Invoice_No", br.Invoice_No);
                cmd.Parameters.AddWithValue("@Transaction_Type", br.Transaction_Type);
                cmd.Parameters.AddWithValue("@Sup_ID", br.Sup_ID);
                cmd.Parameters.AddWithValue("@Sub_Total", br.Sub_Total);
                cmd.Parameters.AddWithValue("@TDiscount", br.TDiscount);
                cmd.Parameters.AddWithValue("@TSGST", br.TSGST);
                cmd.Parameters.AddWithValue("@TCGST", br.TCGST);
                cmd.Parameters.AddWithValue("@TIGST", br.TIGST);
                cmd.Parameters.AddWithValue("@Grand_Total", br.Grand_Total);
                cmd.Parameters.AddWithValue("@Reson", br.Reson);

                con.Open();

                object o = cmd.ExecuteScalar();

                if (o != null)
                {
                    isSuccess = true;
                    Invoice_No = int.Parse(o.ToString());
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
