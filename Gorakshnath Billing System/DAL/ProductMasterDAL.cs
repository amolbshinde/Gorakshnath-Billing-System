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
    class ProductMasterDAL
    {
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;


        #region Method to Insert Product in database
        public bool Insert(ProductMasterBLL pBLL)
        {
            //Creating Boolean Variable and set its default value to false
            bool isSuccess = false;

            //Sql Connection for DAtabase
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                //SQL Query to insert product into database
                String sql = "INSERT INTO Product_Master (Product_Group,Brand,Item_Code,Product_Name,HSN_Code,Purchase_Price,Sales_Price,Min_Sales_Price,Unit,Opening_Stock) VALUES (@Product_Group, @Brand, @Item_Code, @Product_Name, @HSN_Code, @Purchase_Price, @Sales_Price,@Min_Sales_Price,@Unit,@Opening_Stock)";

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

                int rows = cmd.ExecuteNonQuery();

                //If the query is executed successfully then the value of rows will be greater than 0 else it will be less than 0
                if (rows > 0)
                {
                    //Query Executed Successfully
                    isSuccess = true;
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

    }
}
