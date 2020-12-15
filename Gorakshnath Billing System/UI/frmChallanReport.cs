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
            comboInvoiceNo.ValueMember = "Invoice_No";            
            comboInvoiceNo.DataSource = dtI;
            comboInvoiceNo.Text = "Select By Invoice No";

            comboCustName.DataSource = null;
            DataTable dtC = challanDAL.SelectTD();
            comboCustName.DisplayMember = "Cust_Name";
            comboCustName.DataSource = dtC;
            comboCustName.Text = "Select By Cust Name";

            comboMobileNo.DataSource = null;
            DataTable dtM = challanDAL.SelectTD();
            comboMobileNo.DisplayMember = "Cust_Contact";            
            comboMobileNo.DataSource = dtM;
            comboMobileNo.Text = "Select By Mobile No";

        }

        private void comboInvoiceNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboInvoiceNo.Text != "Select By Invoice No")
            {
                string iNo;
                iNo = comboInvoiceNo.Text.ToString();
                DataTable dt = challanDAL.SelectByInvoiceNo(iNo);
                dgvChallanReport.DataSource = dt;
            }
        }

        private void comboCustName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboCustName.Text != "Select By Cust Name")
            {
                string CName;
                CName = comboCustName.Text.ToString();
                DataTable dt = challanDAL.SelectByCustName(CName);
                dgvChallanReport.DataSource = dt;
            }
        }

        private void comboMobileNo_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboMobileNo.Text != "Select By Mobile No")
            {
                string CName;
                CName = comboCustName.Text.ToString();
                DataTable dt = challanDAL.SelectByMobileNo(CName);
                dgvChallanReport.DataSource = dt;
            }

        }
    }
}
