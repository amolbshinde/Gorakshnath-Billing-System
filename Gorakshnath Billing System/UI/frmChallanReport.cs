using Gorakshnath_Billing_System.BLL;
using Gorakshnath_Billing_System.DAL;
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
    public partial class frmChallanReport : Form
    {
        public frmChallanReport()
        {
            InitializeComponent();
        }

        challanBLL ChallanBLL = new challanBLL();
        challanDAL challanDAL = new challanDAL();
        

        private void frmChallanReport_Load(object sender, EventArgs e)
        {
            DataTable dt = challanDAL.SelectTD();
            dgvChallanReport.DataSource = dt;

            comboInvoiceNo.DataSource = null;
            DataTable dtI = challanDAL.SelectTD();
            comboInvoiceNo.DisplayMember = "Invoice_No";
            comboInvoiceNo.Items.Add("Select Invoice No");
            comboInvoiceNo.DataSource = dtI;

            comboCustName.DataSource = null;
            DataTable dtC = challanDAL.SelectTD();
            comboCustName.DisplayMember = "Cust_Name";
            comboCustName.Items.Add("Select Invoice No");
            comboCustName.DataSource = dtC;

            comboMobileNo.DataSource = null;
            DataTable dtM = challanDAL.SelectTD();
            comboMobileNo.DisplayMember = "Cust_Contact";
            comboMobileNo.Items.Add("Select Invoice No");
            comboMobileNo.DataSource = dtM;                       

        }
    }
}
