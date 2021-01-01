using Gorakshnath_Billing_System.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gorakshnath_Billing_System
{
    public partial class frmAdminDashboard : Form
    {
        public frmAdminDashboard()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void catageoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void frmAdminDashboard_Load(object sender, EventArgs e)
        {
            ////*//
            label3.Text = frmLogin.loggedIn;
        }

        private void frmAdminDashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmLogin login = new frmLogin();
            login.Show();
            this.Hide();
        }

        private void productToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void inverntoryToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void addNewProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProductMaster productMaster = new frmProductMaster();
            productMaster.Show();
        }

        private void manageCategoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void totalSalesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDummySalesReport dummySalesReport = new frmDummySalesReport();
            dummySalesReport.Show();
        }

        private void addCustomerClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCustomer customer = new frmCustomer();
            customer.Show();
        }

        private void newSalesReturnCreditNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChallanReturn challanReturn = new frmChallanReturn();
            challanReturn.Show();
        }

        private void newInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDummySales DummySales = new frmDummySales();
            DummySales.Show();
        }

        private void fgToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void addPurchaseBillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPurchase purchase = new frmPurchase();
            purchase.Show();
        }

        private void addSupplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSupplierMaster supplierMaster = new frmSupplierMaster();
            supplierMaster.Show();
        }

        private void newQuotationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQuotation Quotation = new frmQuotation();
            Quotation.Show();
            //frmEstimate estimate = new frmEstimate();
            //estimate.Show();
        }

        private void newDeliveryNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChallan challan = new frmChallan();
            challan.Show();
        }

        private void totalPurchaseReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmStockReport StockReport = new frmStockReport();
            StockReport.Show();

        }

        private void manageBrandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProductBrand ProductBrand = new frmProductBrand();
            ProductBrand.Show();
        }

        private void manageProductGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProductGroup ProductGroup = new frmProductGroup();
            ProductGroup.Show();
        }

        private void itemWiseSalesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPurchaseReport purchaseReport = new frmPurchaseReport();
            purchaseReport.Show();
        }

        private void searchAndManageSupplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSupplierMaster supplierMaster = new frmSupplierMaster();
            supplierMaster.Show();
        }

        private void searchAndManageCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCustomer customer = new frmCustomer();
            customer.Show();
        }

        private void searchAndManageProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProductMaster productMaster = new frmProductMaster();
            productMaster.Show();
        }

        private void addPurchaseReturnDebitNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPurchaseReturn purchaseReturn = new frmPurchaseReturn();
            purchaseReturn.Show();
        }

        private void searchAndManageInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDummySalesReport dummySalesReport = new frmDummySalesReport();
            dummySalesReport.Show();
        }

        private void challanReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChallanReport frmChallanReport = new frmChallanReport();
            frmChallanReport.Show();
        }

        private void searchAndManageDeliveryNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmChallanReport frmChallanReport = new frmChallanReport();
            frmChallanReport.Show();
        }

        private void searchAndManagePurchaseBillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPurchaseReport purchaseReport = new frmPurchaseReport();
            purchaseReport.Show();
        }

        private void searchAndManageQuotationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEstimateReport estimateReport = new frmEstimateReport();
            estimateReport.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void manageUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsers user = new frmUsers();
            user.Show();
        }

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            DialogResult dialog = new DialogResult();

            dialog = MessageBox.Show("Do you really want to close?", "Alert!", MessageBoxButtons.YesNo);

            if (dialog == DialogResult.Yes)
            {
                MessageBox.Show("Goodbye !!!");
                System.Environment.Exit(1);
            }
        }

        private void searchAndManageSalesReturnCreditNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChallanReturnReport challanReturnReport = new frmChallanReturnReport();
            challanReturnReport.Show();
        }

        private void deliveryChallanReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void estimateReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEstimateReport estimateReport = new frmEstimateReport();
            estimateReport.Show();
        }

        private void salesReturnReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChallanReturnReport challanReturnReport = new frmChallanReturnReport();
            challanReturnReport.Show();
        }

        private void searchAndManagePurchaseReturnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPurchaseReturnReport purchaseReturnReport = new frmPurchaseReturnReport();
            purchaseReturnReport.Show();
        }

        private void purchasaaeReturnReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPurchaseReturnReport purchaseReturnReport = new frmPurchaseReturnReport();
            purchaseReturnReport.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //To Display Time
            Time.Text = DateTime.Now.ToLongTimeString();
            //For Date
            Date.Text = DateTime.Now.ToLongDateString();
        }

        private void Date_Click(object sender, EventArgs e)
        {

        }

        private void Time_Click(object sender, EventArgs e)
        {

        }

        private void debtorsAndCreditorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Debtors_and_Creditors Debtors_and_Creditors = new Debtors_and_Creditors();
            Debtors_and_Creditors.Show();
        }

        private void debtorsAndCreditorsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Debtors_and_Creditors Debtors_and_Creditors = new Debtors_and_Creditors();
            Debtors_and_Creditors.Show();
        }

        private void debtorsAndCreditorsToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmSupDrCr supDrCr = new frmSupDrCr();
            supDrCr.Show();
        }
    }
}
