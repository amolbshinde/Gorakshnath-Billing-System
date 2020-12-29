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

        private void frmPurchaseManage_Load(object sender, EventArgs e)
        {

            salesDT.Columns.Add("Sr. No.");
            salesDT.Columns.Add("Product Name");
            salesDT.Columns.Add("Unit");
            salesDT.Columns.Add("Quantity");
            salesDT.Columns.Add("PurchasePrice");
            salesDT.Columns.Add("(-)Discount");
            salesDT.Columns.Add("Gst Type");
            salesDT.Columns.Add("(+)GST%");
            salesDT.Columns.Add("(=)Total");

            comboSearchSup.Text = "Select Sup";
            comboContact.Text = "Select Phone";
            comboItemSearch.Text = "Select Product";
            textItemCode.Text = "";
            textItemName.Text = "";
            comboBoxUnit.Text = "";
            textInventory.Text = "0";
            textQuantity.Text = "0";
            textRate.Text = "0";
            textDiscount.Text = "0";

            if (comboTransactionType.Text != "Non GST")
            {
                comboGstType.Text = "";
                textGST.Text = "0";
            }


            //MessageBox.Show(GetInvoice.ToString());
            textInvoiceNo.Text = GetInvoice.ToString();

            DataTable dtc = purchaseDAL.SelectByPurchaseIdManage(GetInvoice.ToString());
            comboSearchSup.Text = dtc.Rows[0][1].ToString();
            comboContact.Text = dtc.Rows[0][2].ToString();
            textEmail.Text = dtc.Rows[0][3].ToString();
            textAddress.Text = dtc.Rows[0][4].ToString();
            comboTransactionType.Text = dtc.Rows[0][5].ToString();
            textSubTotal.Text = dtc.Rows[0][6].ToString();
            textSubDiscount.Text = dtc.Rows[0][7].ToString();
            textSgst.Text = dtc.Rows[0][8].ToString();
            textCgst.Text = dtc.Rows[0][9].ToString();
            textIgst.Text = dtc.Rows[0][10].ToString();
            textGrandTotal.Text = dtc.Rows[0][11].ToString();


            chDT = purchasedetailsDAL.SelectByPurchaseId(GetInvoice.ToString());
            //dgvAddedProducts.DataSource = salesDT;
            for (int i = 0; i < chDT.Rows.Count; i++)
            {
                string ProductName = chDT.Rows[i][0].ToString();
                string Unit = chDT.Rows[i][1].ToString();
                string gstType = chDT.Rows[i][5].ToString();

                decimal Qty, rate, GST, TotalAmount, discount;
                decimal.TryParse(chDT.Rows[i][2].ToString(), out Qty);
                decimal.TryParse(chDT.Rows[i][3].ToString(), out rate);
                decimal.TryParse(chDT.Rows[i][6].ToString(), out GST);
                decimal.TryParse(chDT.Rows[i][4].ToString(), out discount);
                decimal.TryParse(chDT.Rows[i][7].ToString(), out TotalAmount);

                int counter = 1;
                counter = salesDT.Rows.Count + 1;
                salesDT.Rows.Add(counter, ProductName, Unit, Qty, rate, discount, gstType, GST, TotalAmount);
            }
            dgvAddedProducts.DataSource = salesDT;

        }
    }
}
