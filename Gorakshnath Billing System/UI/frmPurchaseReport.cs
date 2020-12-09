using System;
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
    public partial class frmPurchaseReport : Form
    {
        public frmPurchaseReport()
        {
            InitializeComponent();
        }

        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(myconnstrng))
                {
                    conn.Open();
                    string Query = "Select  CompanyName,Grand_Total,Purchase_Date from Supplier_Master,Purchase_Transactions where Purchase_Transactions.Sup_ID=Supplier_Master.SupplierID";
                    SqlDataAdapter da = new SqlDataAdapter(Query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    //method 1 is direct method
                    dataGridView1.DataSource = dt;

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
