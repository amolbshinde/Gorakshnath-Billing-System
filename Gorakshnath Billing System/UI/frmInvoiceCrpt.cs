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
    public partial class frmInvoiceCrpt : Form
    {
        int GetInvoice;
        public frmInvoiceCrpt(int InvoiceNo)
        {
            InitializeComponent();
            int i = 1;
            while(i==1)
            {
                 GetInvoice = InvoiceNo;
                i++;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmInvoiceCrpt_Load(object sender, EventArgs e)
        {
            MessageBox.Show(GetInvoice.ToString());
            Report_Generator.CrystalReport.crptInvoice crptInvoice = new Report_Generator.CrystalReport.crptInvoice();
            crptInvoiceViewer.ReportSource = null;
            crptInvoice.SetParameterValue("@Invoice_No", GetInvoice.ToString());
            crptInvoiceViewer.ReportSource = crptInvoice;

        }
    }
}
