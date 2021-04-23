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
            //
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

            productMaster.ShowDialog();


        }

        private void manageCategoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void totalSalesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDummySalesReport dummySalesReport = new frmDummySalesReport();
            dummySalesReport.ShowDialog();
        }

        private void addCustomerClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCustomer customer = new frmCustomer();
            customer.ShowDialog();
        }

        private void newSalesReturnCreditNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChallanReturn challanReturn = new frmChallanReturn();
            challanReturn.ShowDialog();
        }

        private void newInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool found = false;
            try
            {
                for (int i = 0; i < Application.OpenForms.Count; i++)
                {
                    //Checks if the window is already open, and brings it to the front if it is
                    Form n = Application.OpenForms[i];
                    if (n.Name == "frmDummySales")
                    {
                        n.BringToFront();
                        n.Focus();
                        found = true;
                    }
                }
                if (!found)
                {
                    frmDummySales DummySales = new frmDummySales();
                    //DummySales.MdiParent = this;

                    DummySales.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void fgToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void addPurchaseBillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool found = false;
            try
            {
                for (int i = 0; i < Application.OpenForms.Count; i++)
                {
                    //Checks if the window is already open, and brings it to the front if it is
                    Form n = Application.OpenForms[i];
                    if (n.Name == "frmPurchase")
                    {
                        n.BringToFront();
                        n.Focus();
                        found = true;
                    }
                }
                if (!found)
                {
                    frmPurchase purchase = new frmPurchase();
                    purchase.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void addSupplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool found = false;
            try
            {
                for (int i = 0; i < Application.OpenForms.Count; i++)
                {
                    //Checks if the window is already open, and brings it to the front if it is
                    Form n = Application.OpenForms[i];
                    if (n.Name == "frmSupplierMaster")
                    {
                        n.BringToFront();
                        n.Focus();
                        found = true;
                    }
                }
                if (!found)
                {
                    frmSupplierMaster supplierMaster = new frmSupplierMaster();
                    supplierMaster.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void newQuotationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool found = false;
            try
            {
                for (int i = 0; i < Application.OpenForms.Count; i++)
                {
                    //Checks if the window is already open, and brings it to the front if it is
                    Form n = Application.OpenForms[i];
                    if (n.Name == "frmQuotation")
                    {
                        n.BringToFront();
                        n.Focus();
                        found = true;
                    }
                }
                if (!found)
                {
                    frmQuotation Quotation = new frmQuotation();
                    Quotation.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void newDeliveryNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            bool found = false;
            try
            {
                for (int i = 0; i < Application.OpenForms.Count; i++)
                {
                    //Checks if the window is already open, and brings it to the front if it is
                    Form n = Application.OpenForms[i];
                    if (n.Name == "frmChallan")
                    {
                        n.BringToFront();
                        n.Focus();
                        found = true;
                    }
                }
                if (!found)
                {
                    frmChallan challan = new frmChallan();
                    challan.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void totalPurchaseReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
                    frmStockReport StockReport = new frmStockReport();
                    StockReport.ShowDialog();
            

        }

        private void manageBrandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
                    frmProductBrand ProductBrand = new frmProductBrand();
                    ProductBrand.ShowDialog();
            


        }

        private void manageProductGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
              
                    frmProductGroup ProductGroup = new frmProductGroup();
                    ProductGroup.ShowDialog();
            
        }

        private void itemWiseSalesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
                    frmPurchaseReport purchaseReport = new frmPurchaseReport();
                    purchaseReport.ShowDialog();
             

        }

        private void searchAndManageSupplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool found = false;
            try
            {
                for (int i = 0; i < Application.OpenForms.Count; i++)
                {
                    //Checks if the window is already open, and brings it to the front if it is
                    Form n = Application.OpenForms[i];
                    if (n.Name == "frmSupplierMaster")
                    {
                        n.BringToFront();
                        n.Focus();
                        found = true;
                    }
                }
                if (!found)
                {
                    frmSupplierMaster supplierMaster = new frmSupplierMaster();
                    supplierMaster.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void searchAndManageCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool found = false;
            try
            {
                for (int i = 0; i < Application.OpenForms.Count; i++)
                {
                    //Checks if the window is already open, and brings it to the front if it is
                    Form n = Application.OpenForms[i];
                    if (n.Name == "frmCustomer")
                    {
                        n.BringToFront();
                        n.Focus();
                        found = true;
                    }
                }
                if (!found)
                {
                    frmCustomer customer = new frmCustomer();
                    customer.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void searchAndManageProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool found = false;
            try
            {
                for (int i = 0; i < Application.OpenForms.Count; i++)
                {
                    //Checks if the window is already open, and brings it to the front if it is
                    Form n = Application.OpenForms[i];
                    if (n.Name == "frmProductMaster")
                    {
                        n.BringToFront();
                        n.Focus();
                        found = true;
                    }
                }
                if (!found)
                {
                    frmProductMaster productMaster = new frmProductMaster();
                    productMaster.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void addPurchaseReturnDebitNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool found = false;
            try
            {
                for (int i = 0; i < Application.OpenForms.Count; i++)
                {
                    //Checks if the window is already open, and brings it to the front if it is
                    Form n = Application.OpenForms[i];
                    if (n.Name == "frmPurchaseReturn")
                    {
                        n.BringToFront();
                        n.Focus();
                        found = true;
                    }
                }
                if (!found)
                {
                    frmPurchaseReturn purchaseReturn = new frmPurchaseReturn();
                    purchaseReturn.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void searchAndManageInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool found = false;
            try
            {
                for (int i = 0; i < Application.OpenForms.Count; i++)
                {
                    //Checks if the window is already open, and brings it to the front if it is
                    Form n = Application.OpenForms[i];
                    if (n.Name == "frmDummySalesReport")
                    {
                        n.BringToFront();
                        n.Focus();
                        found = true;
                    }
                }
                if (!found)
                {
                    frmDummySalesReport dummySalesReport = new frmDummySalesReport();
                    //dummySalesReport.MdiParent = this;
                    dummySalesReport.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void challanReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool found = false;
            try
            {
                for (int i = 0; i < Application.OpenForms.Count; i++)
                {
                    //Checks if the window is already open, and brings it to the front if it is
                    Form n = Application.OpenForms[i];
                    if (n.Name == "frmChallanReport")
                    {
                        n.BringToFront();
                        n.Focus();
                        found = true;
                    }
                }
                if (!found)
                {
                    frmChallanReport frmChallanReport = new frmChallanReport();
                    frmChallanReport.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        private void searchAndManageDeliveryNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool found = false;
            try
            {
                for (int i = 0; i < Application.OpenForms.Count; i++)
                {
                    //Checks if the window is already open, and brings it to the front if it is
                    Form n = Application.OpenForms[i];
                    if (n.Name == "frmChallanReport")
                    {
                        n.BringToFront();
                        n.Focus();
                        found = true;
                    }
                }
                if (!found)
                {
                    frmChallanReport frmChallanReport = new frmChallanReport();
                    frmChallanReport.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        private void searchAndManagePurchaseBillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool found = false;
            try
            {
                for (int i = 0; i < Application.OpenForms.Count; i++)
                {
                    //Checks if the window is already open, and brings it to the front if it is
                    Form n = Application.OpenForms[i];
                    if (n.Name == "frmPurchaseReport")
                    {
                        n.BringToFront();
                        n.Focus();
                        found = true;
                    }
                }
                if (!found)
                {
                    frmPurchaseReport purchaseReport = new frmPurchaseReport();
                    purchaseReport.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void searchAndManageQuotationToolStripMenuItem_Click(object sender, EventArgs e)
        {

            bool found = false;
            try
            {
                for (int i = 0; i < Application.OpenForms.Count; i++)
                {
                    //Checks if the window is already open, and brings it to the front if it is
                    Form n = Application.OpenForms[i];
                    if (n.Name == "frmEstimateReport")
                    {
                        n.BringToFront();
                        n.Focus();
                        found = true;
                    }
                }
                if (!found)
                {
                    frmEstimateReport estimateReport = new frmEstimateReport();
                    estimateReport.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void manageUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool found = false;
            try
            {
                for (int i = 0; i < Application.OpenForms.Count; i++)
                {
                    //Checks if the window is already open, and brings it to the front if it is
                    Form n = Application.OpenForms[i];
                    if (n.Name == "frmUsers")
                    {
                        n.BringToFront();
                        n.Focus();
                        found = true;
                    }
                }
                if (!found)
                {
                    frmUsers user = new frmUsers();
                    user.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
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

            bool found = false;
            try
            {
                for (int i = 0; i < Application.OpenForms.Count; i++)
                {
                    //Checks if the window is already open, and brings it to the front if it is
                    Form n = Application.OpenForms[i];
                    if (n.Name == "frmChallanReturnReport")
                    {
                        n.BringToFront();
                        n.Focus();
                        found = true;
                    }
                }
                if (!found)
                {
                    frmChallanReturnReport challanReturnReport = new frmChallanReturnReport();
                    challanReturnReport.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
        }

        private void deliveryChallanReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void estimateReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEstimateReport estimateReport = new frmEstimateReport();
            estimateReport.ShowDialog();
        }

        private void salesReturnReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChallanReturnReport challanReturnReport = new frmChallanReturnReport();
            challanReturnReport.ShowDialog();
        }

        private void searchAndManagePurchaseReturnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPurchaseReturnReport purchaseReturnReport = new frmPurchaseReturnReport();
            purchaseReturnReport.ShowDialog();
        }

        private void purchasaaeReturnReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPurchaseReturnReport purchaseReturnReport = new frmPurchaseReturnReport();
            purchaseReturnReport.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //To Display Time
          //  Time.Text = DateTime.Now.ToLongTimeString();
            //For Date
            //Date.Text = DateTime.Now.ToLongDateString();
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
            Debtors_and_Creditors.ShowDialog();
        }

        private void debtorsAndCreditorsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Debtors_and_Creditors Debtors_and_Creditors = new Debtors_and_Creditors();
            Debtors_and_Creditors.ShowDialog();
        }

        private void debtorsAndCreditorsToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmSupDrCr supDrCr = new frmSupDrCr();
            supDrCr.ShowDialog();
        }

        private void purchaseeDebtorsAndCreditorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDebtors_Creditors_Purchase frmpurDrCr = new frmDebtors_Creditors_Purchase();
            frmpurDrCr.ShowDialog();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void transactionsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void customerMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCustomer customer = new frmCustomer();
            customer.ShowDialog();
        }

        private void supplierMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSupplierMaster supplierMaster = new frmSupplierMaster();
            supplierMaster.ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmProductGroup groupMaster = new frmProductGroup();
            groupMaster.ShowDialog();
        }

        private void backupAndRestoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBackup backup = new frmBackup();
            backup.ShowDialog();//
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://swamisoftware.ml/");
        }
    }
}
