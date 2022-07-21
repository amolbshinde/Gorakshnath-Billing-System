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
        //connetion string
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

        #region Update Data in Database for Opening_Stock
        public bool Update_Opening_Stock(stockBLL s)
        {
            bool isSuccess = false;
            SqlConnection con = new SqlConnection(myconnstrng);
            try
            {
                String sql = "UPDATE Stock_Master SET Quantity= Quantity+@Quantity,Unit=@Unit WHERE Product_Id = @Product_Id";
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@Quantity", s.Quantity);
                cmd.Parameters.AddWithValue("@Product_Id", s.Product_Id);
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

        #region METHOD TO GET CURRENT QUantity from the Database based on Product ID
        public decimal GetProductQty(int ProductID)
        {
            SqlConnection conn = new SqlConnection(myconnstrng);

            decimal Quantity = 0;


            DataTable dt = new DataTable();

            try
            {
                string sql = "SELECT Quantity FROM Stock_Master WHERE Product_Id = " + ProductID;

                SqlCommand cmd = new SqlCommand(sql, conn);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                conn.Open();

                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    Quantity = decimal.Parse(dt.Rows[0]["Quantity"].ToString());
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

            return Quantity;
        }
        #endregion

        #region Select Data From Database
        public DataTable SelectAllProductStock()
        {
            SqlConnection con = new SqlConnection(myconnstrng);

            DataTable dt = new DataTable();
            try
            {
                String sql = "SELECT Product_Master.Product_Id, Product_Master.Product_Name, Stock_Master.Quantity,Stock_Master.Unit,Product_Master.Brand,Product_Master.Product_Group FROM Stock_Master inner join Product_Master ON Product_Master.Product_ID=Stock_Master.Product_Id "; 
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

        #region SEARCH Method for Stock Module Group By Product_Group
        public DataTable SelectStockByGroup(string keywords)
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT Product_Master.Product_Id,Product_Master.Product_Name, Stock_Master.Quantity,Stock_Master.Unit, Product_Master.Brand,Product_Master.Product_Group FROM Stock_Master inner join Product_Master ON Product_Master.Product_ID=Stock_Master.Product_Id where Product_Master.Product_Group LIKE '" + keywords + "'";

                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                conn.Open();

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

        #region SEARCH Method for Stock Module Group By Product_Group
        public DataTable SelectStockByBrand(string keywords)
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT Product_Master.Product_Id,Product_Master.Product_Name, Stock_Master.Quantity,Stock_Master.Unit,Product_Master.Brand,Product_Master.Product_Group FROM Stock_Master inner join Product_Master ON Product_Master.Product_ID=Stock_Master.Product_Id where Product_Master.Brand LIKE '" + keywords + "'";

                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                conn.Open();

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

        #region SEARCH Method for Stock Module Group By Product_Group
        public DataTable SelectStockByProduct(string keywords)
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT Product_Master.Product_Id,Product_Master.Product_Name, Stock_Master.Quantity,Stock_Master.Unit,Product_Master.Brand,Product_Master.Product_Group FROM Stock_Master inner join Product_Master ON Product_Master.Product_ID=Stock_Master.Product_Id where Product_Master.Product_Name LIKE '" + keywords + "'";

                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                conn.Open();

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
        #region Fetch All Stock 
        public DataTable SelectAllStock()
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT Product_Master.Product_Id, Product_Master.Product_Name, Stock_Master.Quantity,Stock_Master.Unit,Product_Master.Brand,Product_Master.Product_Group FROM Stock_Master inner join Product_Master ON Product_Master.Product_ID=Stock_Master.Product_Id ";

                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                conn.Open();

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




    }
}
