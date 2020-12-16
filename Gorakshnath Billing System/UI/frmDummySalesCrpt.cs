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
    public partial class frmDummySalesCrpt : Form
    {
        int GetInvoice;
        public frmDummySalesCrpt(int InvoiceNo)
        {
            InitializeComponent();

            int i = 1;
            while (i == 1)
            {
                GetInvoice = InvoiceNo;
                i++;
            }

        }

        private void frmDummySalesCrpt_Load(object sender, EventArgs e)
        {
            Report_Generator.CrystalReport.crptNewInvoice newInvoice = new Report_Generator.CrystalReport.crptNewInvoice();
            crptNewInvoiceViewer.ReportSource = null;
            newInvoice.SetParameterValue("@Invoice_No", GetInvoice.ToString());
            crptNewInvoiceViewer.ReportSource = newInvoice;
        }
    }
}
