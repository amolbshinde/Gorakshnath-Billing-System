﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gorakshnath_Billing_System.UI
{
    public partial class frmSalesReport : Form
    {
        public frmSalesReport()
        {
            InitializeComponent();
        }
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(myconnstrng))
            {
                conn.Open();
                string Query = "Select Invoice_No,Cust_Name,Sub_Total,TDiscount,TSGST,TCGST,TIGST,Grand_Total,Challan_date from Challan_Transactions,Cust_Master where Challan_Transactions.Cust_ID=Cust_Master.Cust_Id";
                SqlDataAdapter da = new SqlDataAdapter(Query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                //method 1 is direct method
                dataGridView1.DataSource = dt;

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSalesReport_Load(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(myconnstrng))
            {
                conn.Open();
                string Query = "Select Invoice_No,Cust_Name,Sub_Total,TDiscount,TSGST,TCGST,TIGST,Grand_Total,Challan_date from Challan_Transactions,Cust_Master where Challan_Transactions.Cust_ID=Cust_Master.Cust_Id";
                SqlDataAdapter da = new SqlDataAdapter(Query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                //method 1 is direct method
                dataGridView1.DataSource = dt;

            }
        }
    }
}
