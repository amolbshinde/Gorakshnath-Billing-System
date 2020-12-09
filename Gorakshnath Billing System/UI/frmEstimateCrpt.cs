using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gorakshnath_Billing_System.UI
{
    public partial class frmEstimateCrpt : Form
    {
        int GetInvoice;
        public frmEstimateCrpt(int InvoiceNo)
        {
            InitializeComponent();
            int i = 1;
            while (i == 1)
            {
                GetInvoice = InvoiceNo;
                i++;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void frmEstimateCrpt_Load(object sender, EventArgs e)
        {
            Report_Generator.CrystalReport.crptEstimate Estimate = new Report_Generator.CrystalReport.crptEstimate();
            crptEstimateViewer.ReportSource = null;
            Estimate.SetParameterValue("@Invoice_No", GetInvoice.ToString());
            crptEstimateViewer.ReportSource = Estimate;
        }
    }
}
