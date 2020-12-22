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
    class ProductMasterDAL
    {
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;

        #region Select Data From Database
        public DataTable Select()
        {
            SqlConnection con = new SqlConnection(myconnstrng);

            DataTable dt = new DataTable();
            try
            {
                String sql = "SELECT * FROM [dbo].[Product_Master]";
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

        #region Method to Insert Product in database
        public bool Insert(ProductMasterBLL pBLL, out int Product_ID)
        {
            //Creating Boolean Variable and set its default value to false
            bool isSuccess = false;

            Product_ID = -1;
            //Sql Connection for DAtabase
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                //SQL Query to insert product into database
                String sql = "INSERT INTO Product_Master (Product_Group,Brand,Item_Code,Product_Name,HSN_Code,Purchase_Price,Sales_Price,Min_Sales_Price,Unit,Opening_Stock) VALUES (@Product_Group, @Brand, @Item_Code, @Product_Name, @HSN_Code, @Purchase_Price, @Sales_Price,@Min_Sales_Price,@Unit,@Opening_Stock);select @@IDENTITY;";

                //Creating SQL Command to pass the values
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Passign the values through parameters
                cmd.Parameters.AddWithValue("@Product_Group", pBLL.Product_Group);
                cmd.Parameters.AddWithValue("@Brand", pBLL.Brand);
                cmd.Parameters.AddWithValue("@Item_Code", pBLL.Item_Code);
                cmd.Parameters.AddWithValue("@Product_Name", pBLL.Product_Name);
                cmd.Parameters.AddWithValue("@HSN_Code", pBLL.HSN_Code);
                cmd.Parameters.AddWithValue("@Purchase_Price", pBLL.Purchase_Price);
                cmd.Parameters.AddWithValue("@Sales_Price", pBLL.Sales_Price);
                cmd.Parameters.AddWithValue("@Min_Sales_Price", pBLL.Min_Sales_Price);
                cmd.Parameters.AddWithValue("@Unit", pBLL.Unit);
                cmd.Parameters.AddWithValue("@Opening_Stock", pBLL.Opening_Stock);

                //Opening the Database connection
                conn.Open();

                object o = cmd.ExecuteScalar();
                //int rows = cmd.ExecuteNonQuery();

                //If the query is executed successfully then the value of rows will be greater than 0 else it will be less than 0
                if (o != null)
                {
                    //Query Executed Successfully
                    isSuccess = true;
                    Product_ID = int.Parse(o.ToString());
                }
                else
                {
                    //FAiled to Execute Query
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

        #region Method to Update Product in database

        public bool Update(ProductMasterBLL pBLL)
        {
            bool isSuccess = false;
            SqlConnection con = new SqlConnection(myconnstrng);
            try
            {
                String sql = "UPDATE Product_Master SET Product_Group=@Product_Group,Brand=@Brand,Item_Code=@Item_Code,Product_Name=@Product_Name,HSN_Code=@HSN_Code,Purchase_Price=@Purchase_Price,Sales_Price=@Sales_Price,Min_Sales_Price=@Min_Sales_Price,Unit=@Unit,Opening_Stock=@Opening_Stock WHERE Product_ID = @Product_ID";
                SqlCommand cmd = new SqlCommand(sql, con);
                
                cmd.Parameters.AddWithValue("@Product_ID", pBLL.Product_ID);
                cmd.Parameters.AddWithValue("@Product_Group", pBLL.Product_Group);
                cmd.Parameters.AddWithValue("@Brand", pBLL.Brand);
                cmd.Parameters.AddWithValue("@Item_Code", pBLL.Item_Code);
                cmd.Parameters.AddWithValue("@Product_Name", pBLL.Product_Name);
                cmd.Parameters.AddWithValue("@HSN_Code", pBLL.HSN_Code);
                cmd.Parameters.AddWithValue("@Purchase_Price", pBLL.Purchase_Price);
                cmd.Parameters.AddWithValue("@Sales_Price", pBLL.Sales_Price);
                cmd.Parameters.AddWithValue("@Min_Sales_Price", pBLL.Min_Sales_Price);
                cmd.Parameters.AddWithValue("@Unit", pBLL.Unit);
                cmd.Parameters.AddWithValue("@Opening_Stock", pBLL.Opening_Stock);
                

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

        #region Delete Data From Database
        public bool Delete(ProductMasterBLL pBLL)
        {
            bool isSuccess = false;
            SqlConnection con = new SqlConnection(myconnstrng);
            try
            {
                string sql = "DELETE FROM Product_Master WHERE Product_ID =@Product_ID";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Product_ID", pBLL.Product_ID);
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

        #region METHOD TO SEARCH PRODUCT IN TRANSACTION MODULE
        public ProductMasterBLL GetProductsForTransaction(string keyword)
        {
            ProductMasterBLL p = new ProductMasterBLL();
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT Item_Code, Quantity,Purchase_Price, Product_Name, Product_Master.Unit , Sales_Price FROM Product_Master,Stock_Master where Product_Master.Product_Id=Stock_Master.Product_Id AND Product_Name LIKE '%" + keyword + "%'";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);

                conn.Open();

                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {   
                    p.Item_Code= dt.Rows[0]["Item_Code"].ToString();
                    p.Quantity = decimal.Parse(dt.Rows[0]["Quantity"].ToString());
                    p.Product_Name = dt.Rows[0]["Product_Name"].ToString();                    
                    p.Unit = dt.Rows[0]["Unit"].ToString();
                    p.Purchase_Price= decimal.Parse(dt.Rows[0]["Purchase_Price"].ToString());
                    p.Sales_Price = decimal.Parse(dt.Rows[0]["Sales_Price"].ToString());
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

            return p;
        }
        #endregion

        #region METHOD TO GET PRODUCT ID BASED ON PRODUCT NAME
        public ProductMasterBLL GetProductIDFromName(string ProductName)
        {
            ProductMasterBLL p = new ProductMasterBLL();
            SqlConnection con = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                // GETID FROM PRODUCT TABLE
                string sql = "SELECT Product_ID FROM Product_Master WHERE Product_Name='" + ProductName + "'";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                con.Open();

                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    p.Product_ID = int.Parse(dt.Rows[0]["Product_ID"].ToString());
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

        #region Search  On Database Using Keywords
        public DataTable Search(string keywords)
        {
            SqlConnection con = new SqlConnection(myconnstrng);

            DataTable dt = new DataTable();
            try
            {
                String sql = "SELECT * FROM Product_Master WHERE Product_ID LIKE'%" + keywords + "%' OR Product_Name LIKE'%" + keywords + "%' OR Brand LIKE'%" + keywords + "%' OR Item_Code LIKE'%" + keywords + "%'";
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

        #region Method  to check Product is added or not

        public ProductMasterBLL checkProductAvailableOrNot(string keyword)
        {
            ProductMasterBLL p = new ProductMasterBLL();

            SqlConnection con = new SqlConnection(myconnstrng);

            DataTable dt = new DataTable();
            //fdfd
            try
            {
                string sql = "SELECT Product_Name from Product_Master WHERE Product_Name LIKE '%" + keyword + "%'";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, con);

                con.Open();

                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    p.Product_Name = dt.Rows[0]["Product_Name"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
            return p;
        }

        #endregion

        #region Method  to check Product COde is added or not

        public ProductMasterBLL checkProductCodeAvailableOrNot(string keyword)
        {
            ProductMasterBLL p = new ProductMasterBLL();

            SqlConnection con = new SqlConnection(myconnstrng);

            DataTable dt = new DataTable();
            //fdfd
            try
            {
                string sql = "SELECT Item_Code from Product_Master WHERE Item_Code LIKE '%" + keyword + "%'";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, con);

                con.Open();

                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    p.Product_Name = dt.Rows[0]["Item_Code"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
            return p;
        }

        #endregion

        #region Method  to check Product COde is added or not

        public ProductMasterBLL checkProductHSNAvailableOrNot(string keyword)
        {
            ProductMasterBLL p = new ProductMasterBLL();

            SqlConnection con = new SqlConnection(myconnstrng);

            DataTable dt = new DataTable();
            //fdfd
            try
            {
                string sql = "SELECT HSN_Code from Product_Master WHERE HSN_Code LIKE '%" + keyword + "%'";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, con);

                con.Open();

                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    p.Product_Name = dt.Rows[0]["HSN_Code"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
            return p;
        }

        #endregion

        #region Select Data From Database for challan combo
        public DataTable SelectForCombo()
        {
            SqlConnection con = new SqlConnection(myconnstrng);

            DataTable dt = new DataTable();
            try
            {
                String sql = "SELECT Product_Name FROM Product_Master;";
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
