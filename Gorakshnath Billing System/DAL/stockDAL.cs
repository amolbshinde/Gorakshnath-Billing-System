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
    class stockDAL
    {

        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;

        #region METHOD TO GET PRODUCT ID BASED ON PRODUCT NAME
        public stockBLL CheakeProductAddedOrNot(int Product_Id)
        {
            stockBLL p = new stockBLL();
            SqlConnection con = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                // GETID FROM PRODUCT TABLE
                string sql = "SELECT Product_Id FROM Stock_Master WHERE Product_Id='" + Product_Id + "'";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                con.Open();

                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    p.Product_Id = int.Parse(dt.Rows[0]["Product_Id"].ToString());
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

            return p;
        }
        #endregion

        #region Insert Data in Database
        public bool InsertStockNewProduct(stockBLL s)
        {
            bool isSuccess = false;
            SqlConnection con = new SqlConnection(myconnstrng);
            try
            {
                String sql = "INSERT INTO Stock_Master (Product_Id, Quantity, Unit) VALUES(@Product_Id, @Quantity, @Unit)";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Product_Id", s.Product_Id);
                cmd.Parameters.AddWithValue("@Quantity", s.Quantity);
                cmd.Parameters.AddWithValue("@Unit", s.Unit);                

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

        #region Update Data in Database
        public bool Update(stockBLL s)
        {
            bool isSuccess = false;
            SqlConnection con = new SqlConnection(myconnstrng);
            try
            {
                String sql = "UPDATE Stock_Master SET Quantity= Quantity+@Quantity WHERE Product_Id = @Product_Id";
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@Quantity", s.Quantity);
                cmd.Parameters.AddWithValue("@Product_Id", s.Product_Id);

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

        #region Decrease Data in Database from Stock
        public bool dereaseUpdate(stockBLL s)
        {
            bool isSuccess = false;
            SqlConnection con = new SqlConnection(myconnstrng);
            try
            {
                String sql = "UPDATE Stock_Master SET Quantity= Quantity-@Quantity WHERE Product_Id = @Product_Id";
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@Quantity", s.Quantity);
                cmd.Parameters.AddWithValue("@Product_Id", s.Product_Id);

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



        #region Select Data From Database
        public DataTable SelectAllProductStock()
        {
            SqlConnection con = new SqlConnection(myconnstrng);

            DataTable dt = new DataTable();
            try
            {
                String sql = "SELECT * FROM Stock_Master";
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
