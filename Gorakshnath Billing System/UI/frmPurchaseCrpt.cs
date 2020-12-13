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
    public partial class frmPurchaseCrpt : Form
    {
        int GetPurchaseID;
        public frmPurchaseCrpt(int PurchaseID)
        {
            InitializeComponent();

            int i = 1;
            while (i == 1)
            {
                GetPurchaseID = PurchaseID;
                i++;
            }
        }

        private void frmPurchaseCrpt_Load(object sender, EventArgs e)
        {
            Report_Generator.CrystalReport.crptPurchase crptPurchase = new Report_Generator.CrystalReport.crptPurchase();
            CrptPurchaseViewer.ReportSource = null;
            crptPurchase.SetParameterValue("@Purchase_ID", GetPurchaseID.ToString());
            CrptPurchaseViewer.ReportSource = crptPurchase;
        }
    }
}
