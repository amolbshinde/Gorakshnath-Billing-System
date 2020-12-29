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
    public partial class frmPurchaseManage : Form
    {
        int GetInvoice;
        public frmPurchaseManage()
        {
            InitializeComponent();
            fillCombo();
        }

        SupplierMasterBLL SupplierMasterBLL = new SupplierMasterBLL();
        SupplierMasterDAL SupplierMasterDAL = new SupplierMasterDAL();

        ProductMasterDAL ProductMasterDAL = new ProductMasterDAL();

        purchaseBLL purchaseBLL = new purchaseBLL();

        purchaseDAL purchaseDAL = new purchaseDAL();

        purchasedetailsDAL purchasedetailsDAL = new purchasedetailsDAL();

        stockDAL stockDAL = new stockDAL();

        DataTable salesDT = new DataTable();
        DataTable chDT = new DataTable();

        public void fillCombo()
        {
            comboSearchSup.DataSource = null;
            DataTable dtC = SupplierMasterDAL.SelectForCombo();
            comboSearchSup.DisplayMember = "CompanyName";
            comboSearchSup.DataSource = dtC;
            comboSearchSup.Text = "Select Sup";

            comboContact.DataSource = null;
            DataTable dtP = SupplierMasterDAL.SelectForCombo();
            comboContact.DisplayMember = "Phone_No";
            comboContact.DataSource = dtP;
            comboContact.Text = "Select Phone";

            comboItemSearch.DataSource = null;
            DataTable dtI = ProductMasterDAL.SelectForCombo();
            comboItemSearch.DisplayMember = "Product_Name";
            comboItemSearch.DataSource = dtI;
            comboItemSearch.Text = "Select Product";

        }


    }
}
