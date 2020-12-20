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
    public partial class frmPurchaseReport : Form
    {
        public frmPurchaseReport()
        {
            InitializeComponent();
        }

        purchaseBLL purchaseBLL = new purchaseBLL();
        purchaseDAL purchaseDAL = new purchaseDAL();

        private void frmPurchaseReport_Load(object sender, EventArgs e)
        {
            DataTable dt = purchaseDAL.SelectPD();
            dgvPurchaseReport.DataSource = dt;

            comboPurchaseId.DataSource = null;
            DataTable dtP = purchaseDAL.SelectPD();
            comboPurchaseId.DisplayMember = "Purchase_ID";
            comboPurchaseId.ValueMember = "Purchase_ID";
            comboPurchaseId.DataSource = dtP;
            comboPurchaseId.Text = "Select By Purchase ID";

            comboSupName.DataSource = null;
            DataTable dtNP = purchaseDAL.SelectPD();
            comboSupName.DisplayMember = "CompanyName";
            comboSupName.ValueMember="CompanyName";
            comboSupName.DataSource = dtNP;
            comboSupName.Text = "Select By Supplier Name";

            comboMobileNo.DataSource = null;
            DataTable dtC = purchaseDAL.SelectPD();
            comboMobileNo.DisplayMember = "Phone_No";
            comboMobileNo.ValueMember = "Phone_No";
            comboMobileNo.DataSource = dtC;
            comboMobileNo.Text = "Select By Mobile No";

        }
    }
}
