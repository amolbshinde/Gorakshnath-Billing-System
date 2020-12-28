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
    class BrandDAL
    {
        //Static String Method for Database Connection String.
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
                string sql = "SELECT * FROM Brand_Master";

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

        #region Select Method For combo box
        public DataTable SelectBrandName()
        {
            //Creating Database Connection 
            SqlConnection conn = new SqlConnection(myconnstrng);

            DataTable dt = new DataTable();

            try
            {
                //Wrting SQL Query to get all the data from DAtabase
                string sql = "SELECT Brand_Name FROM Brand_Master";

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

        #region Insert New CAtegory
        public bool Insert(BrandBLL b)
        {
            //Creating A Boolean VAriable and set its default value to false
            bool isSucces = false;

            //Connecting to Database
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                //Writing Query to Add New Category
                string sql = "INSERT INTO Brand_Master (Brand_Name,Description) VALUES (@Brand_Name, @Description)";

                //Creating SQL Command to pass values in our query
                SqlCommand cmd = new SqlCommand(sql, conn);
                //Passing Values through parameter
                cmd.Parameters.AddWithValue("@Brand_Name", b.Brand_Name);
                cmd.Parameters.AddWithValue("@Description", b.Description);
                

                //Open Database Connection
                conn.Open();

                //Creating the int variable to execute query
                int rows = cmd.ExecuteNonQuery();

                //If the query is executed successfully then its value will be greater than 0 else it will be less than 0

                if (rows > 0)
                {
                    //Query Executed Succesfully
                    isSucces = true;
                }
                else
                {
                    //Failed to Execute Query
                    isSucces = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //Closing Database Connection
                conn.Close();
            }

            return isSucces;
        }
        #endregion

        #region Update Method
        public bool Update(BrandBLL b)
        {
            //Creating Boolean variable and set its default value to false
            bool isSuccess = false;

            //Creating SQL Connection
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                //Query to Update Category
                string sql = "UPDATE Brand_Master SET Brand_Name=@Brand_Name, Description=@Description WHERE Brand_ID=@Brand_ID";

                //SQl Command to Pass the Value on Sql Query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Passing Value using cmd
                cmd.Parameters.AddWithValue("@Brand_Name", b.Brand_Name);
                cmd.Parameters.AddWithValue("@Description", b.Description);
                cmd.Parameters.AddWithValue("@Brand_ID", b.Brand_ID);
                

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

        #region Delete Category Method
        public bool Delete(BrandBLL b)
        {
            //Create a Boolean variable and set its value to false
            bool isSuccess = false;

            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                //SQL Query to Delete from Database
                string sql = "DELETE FROM Brand_Master WHERE Brand_ID=@Brand_ID";

                SqlCommand cmd = new SqlCommand(sql, conn);
                //Passing the value using cmd
                cmd.Parameters.AddWithValue("@Brand_ID", b.Brand_ID);

                //Open SqlConnection
                conn.Open();

                int rows = cmd.ExecuteNonQuery();

                //If the query is executd successfully then the value of rows will be greater than zero else it will be less than 0
                if (rows > 0)
                {
                    //Query Executed Successfully
                    isSuccess = true;
                }
                else
                {
                    //Faied to Execute Query
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

        #region Method for Searh Funtionality
        public DataTable Search(string keywords)
        {
            //SQL Connection For Database Connection
            SqlConnection conn = new SqlConnection(myconnstrng);

            //Creating Data TAble to hold the data from database temporarily
            DataTable dt = new DataTable();

            try
            {
                //SQL Query To Search Categories from DAtabase
                String sql = "SELECT * FROM Brand_Master WHERE Brand_ID LIKE '%" + keywords + "%' OR Brand_Name LIKE '%" + keywords + "%' OR Description LIKE '%" + keywords + "%'";
                //Creating SQL Command to Execute the Query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Getting DAta From DAtabase
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //Open DatabaseConnection
                conn.Open();
                //Passing values from adapter to Data Table dt
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

        #region Method  to check brand is added or not

        public BrandBLL checkBrandAvailableOrNot(string keyword)
        {
            BrandBLL b = new BrandBLL();

            SqlConnection con = new SqlConnection(myconnstrng);

            DataTable dt = new DataTable();
            //fdfd
            try
            {
                string sql = "SELECT Brand_Name from Brand_Master WHERE Brand_Name LIKE '%" + keyword + "%'";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, con);

                con.Open();

                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    b.Brand_Name = dt.Rows[0]["Brand_Name"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
            return b;
        }

        #endregion

    }
}