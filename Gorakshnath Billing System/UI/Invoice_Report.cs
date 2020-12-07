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
    public partial class Invoice_Report : Form
    {
        
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        SqlConnection conn = new SqlConnection(myconnstrng);
        public Invoice_Report()
        {
            InitializeComponent();
        }

        
        private void crvDataTable_Load(object sender, EventArgs e)
        {
           

        }

        private void Invoice_Report_Load(object sender, EventArgs e)
        {
            Report_Generator.CrystalReport.crptInvoice crpt = new Report_Generator.CrystalReport.crptInvoice();
            crptViewer.ReportSource = null;
            crptViewer.ReportSource = crpt;


            /*
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlDataAdapter da = new SqlDataAdapter("SelectTransaction", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@Invoice_No", 2);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            Report_Generator.CrystalReport.crptInvoice crpt = new Report_Generator.CrystalReport.crptInvoice();
            crpt.Database.Tables["Challan_Transactions"].SetDataSource(dt);
            crpt.Database.Tables["Challan_Transaction_Details"].SetDataSource(dt); //SetDataSource("Challan_Transaction_Details");
            crvViewer.ReportSource = null;
            crvViewer.ReportSource = crpt;
            */

            /* Report_Generator.CrystalReport.crptInvoice crpt = new Report_Generator.CrystalReport.crptInvoice();
             crvViewer.ReportSource = null;
             crvViewer.ReportSource = crpt;*/

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnPrintInvoice_Click(object sender, EventArgs e)
        {
            /* if (conn.State==ConnectionState.Closed)
             conn.Open();
             SqlDataAdapter da = new SqlDataAdapter("SelectTransaction",conn);
             da.SelectCommand.CommandType = CommandType.StoredProcedure;
             da.SelectCommand.Parameters.AddWithValue("@Sales_ID",1);
             DataTable dt = new DataTable();
             da.Fill(dt);
             conn.Close();
             Report_Generator.CrystalReport.crptInvoice crpt = new Report_Generator.CrystalReport.crptInvoice();
             crpt.Database.Tables["Challan_Transaction"].SetDataSource(dt);
             crvViewer.ReportSource = null;
             crvViewer.ReportSource = crpt;

             */
            Report_Generator.CrystalReport.crptInvoice crpt = new Report_Generator.CrystalReport.crptInvoice();
            crptViewer.ReportSource = null;
            crptViewer.ReportSource = crpt;

        }
    }
}
