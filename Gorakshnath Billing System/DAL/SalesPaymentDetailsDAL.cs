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
    class SalesPaymentDetailsDAL
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
                string sql = "SELECT PaymentId,SalesPaymentDetails.Invoice_No, Cust_Name,PaymentMode,TrMode ,TrAmount ,AmountPiad ,Balance, Remarks, Challan_Transactions.Challan_date, Cust_Contact FROM SalesPaymentDetails,Challan_Transactions,Cust_Master Where SalesPaymentDetails.Invoice_No=Challan_Transactions.Invoice_No and Cust_Master.Cust_Id=Challan_Transactions.Cust_ID;";

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
                string sql = "SELECT PaymentId,SalesPaymentDetails.Invoice_No, Cust_Name,PaymentMode,TrMode ,TrAmount ,AmountPiad ,Balance, Remarks, Challan_Transactions.Challan_date, Cust_Contact FROM SalesPaymentDetails,Challan_Transactions,Cust_Master Where SalesPaymentDetails.Invoice_No=Challan_Transactions.Invoice_No and Cust_Master.Cust_Id=Challan_Transactions.Cust_ID and Balance>0;";

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

        #region Select Method for Creditros
        public DataTable SelectCreditors()
        {
            //Creating Database Connection
            SqlConnection conn = new SqlConnection(myconnstrng);

            DataTable dt = new DataTable();

            try
            {
                //Wrting SQL Query to get all the data from DAtabase
                string sql = "SELECT PaymentId,SalesPaymentDetails.Invoice_No, Cust_Name,PaymentMode,TrMode ,TrAmount ,AmountPiad ,Balance, Remarks, Challan_Transactions.Challan_date, Cust_Contact FROM SalesPaymentDetails,Challan_Transactions,Cust_Master Where SalesPaymentDetails.Invoice_No=Challan_Transactions.Invoice_No and Cust_Master.Cust_Id=Challan_Transactions.Cust_ID and Balance<0;";

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
        public bool Update(SalesPaymentDetailsBLL b)
        {
            //Creating Boolean variable and set its default value to false
            bool isSuccess = false;

            //Creating SQL Connection
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                //Query to Update Category
                string sql = "UPDATE SalesPaymentDetails SET Invoice_No=@Invoice_No, PaymentMode=@PaymentMode, TrAmount =@TrAmount, AmountPiad=@AmountPiad, Balance=@Balance,Remarks=@Remarks WHERE PaymentId=@PaymentId;";

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
                string sql = "Insert into SalesPaymentDetails (Invoice_No,PaymentMode,TrMode,TrAmount,AmountPiad,Balance,Remarks)VALUES(@Invoice_No,@PaymentMode,@TrMode,@TrAmount,@AmountPiad,@Balance,@Remarks)select @@IDENTITY;";
                
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
