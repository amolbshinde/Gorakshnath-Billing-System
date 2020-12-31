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
    class PurchasePaymentDetailsDAL
    {

        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;

        #region Select Method
        public DataTable Select()
        {
            //Creating Database Connection
            SqlConnection conn = new SqlConnection(myconnstrng);

            DataTable dt = new DataTable();

            try
            {
                //Wrting SQL Query to get all the data from DAtabase
                string sql = "SELECT PaymentId,PurchasePaymentDetails.Invoice_No, CompanyName,PaymentMode,TrMode ,TrAmount ,AmountPiad ,Balance, Remarks, Purchase_Transactions.Purchase_Date, Phone_No FROM PurchasePaymentDetails,Purchase_Transactions,Supplier_Master Where PurchasePaymentDetails.Invoice_No=Purchase_Transactions.Purchase_ID and Supplier_Master.SupplierID=Purchase_Transactions.Sup_ID;";

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

        #region Select Method For Debtors
        public DataTable SelectDebtors()
        {
            //Creating Database Connection
            SqlConnection conn = new SqlConnection(myconnstrng);

            DataTable dt = new DataTable();

            try
            {
                //Wrting SQL Query to get all the data from DAtabase
                string sql = "SELECT PaymentId,PurchasePaymentDetails.Invoice_No, CompanyName,PaymentMode,TrMode ,TrAmount ,AmountPiad ,Balance, Remarks, Purchase_Transactions.Purchase_Date, Phone_No FROM PurchasePaymentDetails,Purchase_Transactions,Supplier_Master Where PurchasePaymentDetails.Invoice_No=Purchase_Transactions.Purchase_ID and Supplier_Master.SupplierID=Purchase_Transactions.Sup_ID and Balance<0;";

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

        #region Select Method By Creditors
        public DataTable SelectCreditors()
        {
            //Creating Database Connection
            SqlConnection conn = new SqlConnection(myconnstrng);

            DataTable dt = new DataTable();

            try
            {
                //Wrting SQL Query to get all the data from DAtabase
                string sql = "SELECT PaymentId,PurchasePaymentDetails.Invoice_No, CompanyName,PaymentMode,TrMode ,TrAmount ,AmountPiad ,Balance, Remarks, Purchase_Transactions.Purchase_Date, Phone_No FROM PurchasePaymentDetails,Purchase_Transactions,Supplier_Master Where PurchasePaymentDetails.Invoice_No=Purchase_Transactions.Purchase_ID and Supplier_Master.SupplierID=Purchase_Transactions.Sup_ID and Balance>0;";

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


        #region Select Method By Purchase_Id
        public DataTable SelectByPurchaseId(string Purchase_Id)
        {
            //Creating Database Connection
            SqlConnection conn = new SqlConnection(myconnstrng);

            DataTable dt = new DataTable();

            try
            {
                //Wrting SQL Query to get all the data from DAtabase
                string sql = "SELECT PaymentId,PurchasePaymentDetails.Invoice_No, CompanyName,PaymentMode,TrMode ,TrAmount ,AmountPiad ,Balance, Remarks, Purchase_Transactions.Purchase_Date, Phone_No FROM PurchasePaymentDetails,Purchase_Transactions,Supplier_Master Where PurchasePaymentDetails.Invoice_No=Purchase_Transactions.Purchase_ID and Supplier_Master.SupplierID=Purchase_Transactions.Sup_ID and Invoice_No='"+ Purchase_Id +"';";

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

        #region Select Method By Phone_No
        public DataTable SelectByPhone_No(string Phone_No)
        {
            //Creating Database Connection
            SqlConnection conn = new SqlConnection(myconnstrng);

            DataTable dt = new DataTable();

            try
            {
                //Wrting SQL Query to get all the data from DAtabase
                string sql = "SELECT PaymentId,PurchasePaymentDetails.Invoice_No, CompanyName,PaymentMode,TrMode ,TrAmount ,AmountPiad ,Balance, Remarks, Purchase_Transactions.Purchase_Date, Phone_No FROM PurchasePaymentDetails,Purchase_Transactions,Supplier_Master Where PurchasePaymentDetails.Invoice_No=Purchase_Transactions.Purchase_ID and Supplier_Master.SupplierID=Purchase_Transactions.Sup_ID and Phone_No='" + Phone_No + "';";

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



        #region Update Method
        public bool Update(PurchasePaymentDetailsBLL b)
        {
            //Creating Boolean variable and set its default value to false
            bool isSuccess = false;

            //Creating SQL Connection
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                //Query to Update Category
                string sql = "UPDATE PurchasePaymentDetails SET Invoice_No=@Invoice_No, PaymentMode=@PaymentMode, TrAmount =@TrAmount, AmountPiad=@AmountPiad, Balance=@Balance,Remarks=@Remarks WHERE PaymentId=@PaymentId;";

                //SQl Command to Pass the Value on Sql Query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Passing Value using cmd
                cmd.Parameters.AddWithValue("@Invoice_No", b.Invoice_No);
                cmd.Parameters.AddWithValue("@PaymentMode", b.PaymentMode);
                cmd.Parameters.AddWithValue("@TrAmount", b.TrAmount);
                cmd.Parameters.AddWithValue("@AmountPiad", b.AmountPiad);
                cmd.Parameters.AddWithValue("@Balance", b.Balance);
                cmd.Parameters.AddWithValue("@PaymentId", b.PaymentId);
                cmd.Parameters.AddWithValue("@Remarks", b.Remarks);


                //Open DAtabase Connection
                conn.Open();

                //Create Int Variable to execute query
                int rows = cmd.ExecuteNonQuery();

                //if the query is successfully executed then the value will be grater than zero 
                if (rows > 0)
                {
                    //Query Executed Successfully
                    isSuccess = true;
                }
                else
                {
                    //Failed to Execute Query
                    isSuccess = false;
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

            return isSuccess;
        }
        #endregion

        #region Insert Data into SalesPayment Details 
        public bool InsertSalesPayment(SalesPaymentDetailsBLL sp)
        {
            //Creating Boolean variable and set its default value to false
            bool isSuccess = false;

            //Creating SQL Connection
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                //Query to Update Category
                string sql = "Insert into PurchasePaymentDetails (Invoice_No,PaymentMode,TrMode,TrAmount,AmountPiad,Balance,Remarks)VALUES(@Invoice_No,@PaymentMode,@TrMode,@TrAmount,@AmountPiad,@Balance,@Remarks)select @@IDENTITY;";

                //SQl Command to Pass the Value on Sql Query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Passing Value using cmd
                cmd.Parameters.AddWithValue("@Invoice_No", sp.Invoice_No);
                cmd.Parameters.AddWithValue("@PaymentMode", sp.PaymentMode);
                cmd.Parameters.AddWithValue("@TrMode", sp.TrMode);
                cmd.Parameters.AddWithValue("@TrAmount", sp.TrAmount);
                cmd.Parameters.AddWithValue("@AmountPiad", sp.AmountPiad);
                cmd.Parameters.AddWithValue("@Balance", sp.Balance);
                cmd.Parameters.AddWithValue("@PaymentId", sp.PaymentId);
                cmd.Parameters.AddWithValue("@Remarks", sp.Remarks);


                //Open DAtabase Connection
                conn.Open();

                //Create Int Variable to execute query
                int rows = cmd.ExecuteNonQuery();

                //if the query is successfully executed then the value will be grater than zero 
                if (rows > 0)
                {
                    //Query Executed Successfully
                    isSuccess = true;
                }
                else
                {
                    //Failed to Execute Query
                    isSuccess = false;
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

            return isSuccess;
        }
        #endregion


    }
}
