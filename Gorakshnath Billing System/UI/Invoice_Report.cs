using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gorakshnath_Billing_System.UI
{
    public partial class Invoice_Report : Form
    {
        int j;
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        public Invoice_Report()
        {
            InitializeComponent();
        }

        public void GetValue(int i)
        {
            j = i;
        }
        private void crvDataTable_Load(object sender, EventArgs e)
        {
           

        }

        private void Invoice_Report_Load(object sender, EventArgs e)
        {
            Report_Generator.CrystalReport.crptInvoice crpt = new Report_Generator.CrystalReport.crptInvoice();
            crvViewer.ReportSource = null;
            crvViewer.ReportSource = crpt;

        }
    }
}
