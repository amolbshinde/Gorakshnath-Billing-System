﻿using Gorakshnath_Billing_System.UI;
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
            frmCategories category = new frmCategories();
            category.Show();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsers user = new frmUsers();
            user.Show();
        }

        private void frmAdminDashboard_Load(object sender, EventArgs e)
        {
            ////*
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
            frmCategories category = new frmCategories();
            category.Show();
        }

        private void totalSalesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSalesReport SalesReport = new frmSalesReport();
            SalesReport.Show();
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
            frmEstimate estimate = new frmEstimate();
            estimate.Show();
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

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
