﻿
namespace Gorakshnath_Billing_System
{
    partial class frmAdminDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnllFooter = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.usersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageUsersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newInvoiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchAndManageInvoiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newSalesReturnCreditNoteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchAndManageSalesReturnCreditNoteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newDeliveryNoteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchAndManageDeliveryNoteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newQuotationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchAndManageQuotationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addCustomerClientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchAndManageCustomerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inverntoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addPurchaseBillToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchAndManagePurchaseBillToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addPurchaseReturnDebitNoteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchAndManagePurchaseReturnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addSupplierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchAndManageSupplierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transactionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewProductToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchAndManageProductToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageBrandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageProductGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.totalSalesReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemWiseSalesReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.estimateReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.totalPurchaseReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.challanReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salesReturnReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.purchasaaeReturnReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Time = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Date = new System.Windows.Forms.Label();
            this.debtorsAndCreditorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnllFooter.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnllFooter
            // 
            this.pnllFooter.BackColor = System.Drawing.Color.Teal;
            this.pnllFooter.Controls.Add(this.label1);
            this.pnllFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnllFooter.Location = new System.Drawing.Point(0, 563);
            this.pnllFooter.Margin = new System.Windows.Forms.Padding(2);
            this.pnllFooter.Name = "pnllFooter";
            this.pnllFooter.Size = new System.Drawing.Size(1284, 26);
            this.pnllFooter.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(648, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Devoloped By: Swami Software";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Menu;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usersToolStripMenuItem,
            this.productToolStripMenuItem,
            this.inverntoryToolStripMenuItem,
            this.transactionsToolStripMenuItem,
            this.reportsToolStripMenuItem});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(1284, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // usersToolStripMenuItem
            // 
            this.usersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageUsersToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.usersToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usersToolStripMenuItem.Image = global::Gorakshnath_Billing_System.Properties.Resources._3fe2835;
            this.usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            this.usersToolStripMenuItem.Size = new System.Drawing.Size(76, 24);
            this.usersToolStripMenuItem.Text = "Users";
            this.usersToolStripMenuItem.Click += new System.EventHandler(this.usersToolStripMenuItem_Click);
            // 
            // manageUsersToolStripMenuItem
            // 
            this.manageUsersToolStripMenuItem.Name = "manageUsersToolStripMenuItem";
            this.manageUsersToolStripMenuItem.Size = new System.Drawing.Size(171, 24);
            this.manageUsersToolStripMenuItem.Text = "Manage Users";
            this.manageUsersToolStripMenuItem.Click += new System.EventHandler(this.manageUsersToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(171, 24);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click_1);
            // 
            // productToolStripMenuItem
            // 
            this.productToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newInvoiceToolStripMenuItem,
            this.searchAndManageInvoiceToolStripMenuItem,
            this.newSalesReturnCreditNoteToolStripMenuItem,
            this.searchAndManageSalesReturnCreditNoteToolStripMenuItem,
            this.newDeliveryNoteToolStripMenuItem,
            this.searchAndManageDeliveryNoteToolStripMenuItem,
            this.newQuotationToolStripMenuItem,
            this.searchAndManageQuotationToolStripMenuItem,
            this.addCustomerClientToolStripMenuItem,
            this.searchAndManageCustomerToolStripMenuItem});
            this.productToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.productToolStripMenuItem.Image = global::Gorakshnath_Billing_System.Properties.Resources.Geeren_Background_18_512;
            this.productToolStripMenuItem.Name = "productToolStripMenuItem";
            this.productToolStripMenuItem.Size = new System.Drawing.Size(75, 24);
            this.productToolStripMenuItem.Text = "Sales";
            this.productToolStripMenuItem.Click += new System.EventHandler(this.productToolStripMenuItem_Click);
            // 
            // newInvoiceToolStripMenuItem
            // 
            this.newInvoiceToolStripMenuItem.Name = "newInvoiceToolStripMenuItem";
            this.newInvoiceToolStripMenuItem.Size = new System.Drawing.Size(304, 24);
            this.newInvoiceToolStripMenuItem.Text = "New Invoice";
            this.newInvoiceToolStripMenuItem.Click += new System.EventHandler(this.newInvoiceToolStripMenuItem_Click);
            // 
            // searchAndManageInvoiceToolStripMenuItem
            // 
            this.searchAndManageInvoiceToolStripMenuItem.Name = "searchAndManageInvoiceToolStripMenuItem";
            this.searchAndManageInvoiceToolStripMenuItem.Size = new System.Drawing.Size(304, 24);
            this.searchAndManageInvoiceToolStripMenuItem.Text = "Search and Manage Invoice";
            this.searchAndManageInvoiceToolStripMenuItem.Click += new System.EventHandler(this.searchAndManageInvoiceToolStripMenuItem_Click);
            // 
            // newSalesReturnCreditNoteToolStripMenuItem
            // 
            this.newSalesReturnCreditNoteToolStripMenuItem.Name = "newSalesReturnCreditNoteToolStripMenuItem";
            this.newSalesReturnCreditNoteToolStripMenuItem.Size = new System.Drawing.Size(304, 24);
            this.newSalesReturnCreditNoteToolStripMenuItem.Text = "New Sales Return(Credit Note)";
            this.newSalesReturnCreditNoteToolStripMenuItem.Click += new System.EventHandler(this.newSalesReturnCreditNoteToolStripMenuItem_Click);
            // 
            // searchAndManageSalesReturnCreditNoteToolStripMenuItem
            // 
            this.searchAndManageSalesReturnCreditNoteToolStripMenuItem.Name = "searchAndManageSalesReturnCreditNoteToolStripMenuItem";
            this.searchAndManageSalesReturnCreditNoteToolStripMenuItem.Size = new System.Drawing.Size(304, 24);
            this.searchAndManageSalesReturnCreditNoteToolStripMenuItem.Text = "Search and Manage Sales Return";
            this.searchAndManageSalesReturnCreditNoteToolStripMenuItem.Click += new System.EventHandler(this.searchAndManageSalesReturnCreditNoteToolStripMenuItem_Click);
            // 
            // newDeliveryNoteToolStripMenuItem
            // 
            this.newDeliveryNoteToolStripMenuItem.Name = "newDeliveryNoteToolStripMenuItem";
            this.newDeliveryNoteToolStripMenuItem.Size = new System.Drawing.Size(304, 24);
            this.newDeliveryNoteToolStripMenuItem.Text = "New Delivery Note(Challan)";
            this.newDeliveryNoteToolStripMenuItem.Click += new System.EventHandler(this.newDeliveryNoteToolStripMenuItem_Click);
            // 
            // searchAndManageDeliveryNoteToolStripMenuItem
            // 
            this.searchAndManageDeliveryNoteToolStripMenuItem.Name = "searchAndManageDeliveryNoteToolStripMenuItem";
            this.searchAndManageDeliveryNoteToolStripMenuItem.Size = new System.Drawing.Size(304, 24);
            this.searchAndManageDeliveryNoteToolStripMenuItem.Text = "Search and Manage Delivery Note";
            this.searchAndManageDeliveryNoteToolStripMenuItem.Click += new System.EventHandler(this.searchAndManageDeliveryNoteToolStripMenuItem_Click);
            // 
            // newQuotationToolStripMenuItem
            // 
            this.newQuotationToolStripMenuItem.Name = "newQuotationToolStripMenuItem";
            this.newQuotationToolStripMenuItem.Size = new System.Drawing.Size(304, 24);
            this.newQuotationToolStripMenuItem.Text = "New Quotation /Estimate";
            this.newQuotationToolStripMenuItem.Click += new System.EventHandler(this.newQuotationToolStripMenuItem_Click);
            // 
            // searchAndManageQuotationToolStripMenuItem
            // 
            this.searchAndManageQuotationToolStripMenuItem.Name = "searchAndManageQuotationToolStripMenuItem";
            this.searchAndManageQuotationToolStripMenuItem.Size = new System.Drawing.Size(304, 24);
            this.searchAndManageQuotationToolStripMenuItem.Text = "Search and Manage Quotation";
            this.searchAndManageQuotationToolStripMenuItem.Click += new System.EventHandler(this.searchAndManageQuotationToolStripMenuItem_Click);
            // 
            // addCustomerClientToolStripMenuItem
            // 
            this.addCustomerClientToolStripMenuItem.Name = "addCustomerClientToolStripMenuItem";
            this.addCustomerClientToolStripMenuItem.Size = new System.Drawing.Size(304, 24);
            this.addCustomerClientToolStripMenuItem.Text = "Add/Manage Customer";
            this.addCustomerClientToolStripMenuItem.Click += new System.EventHandler(this.addCustomerClientToolStripMenuItem_Click);
            // 
            // searchAndManageCustomerToolStripMenuItem
            // 
            this.searchAndManageCustomerToolStripMenuItem.Name = "searchAndManageCustomerToolStripMenuItem";
            this.searchAndManageCustomerToolStripMenuItem.Size = new System.Drawing.Size(304, 24);
            this.searchAndManageCustomerToolStripMenuItem.Text = "Search and Manage Customer";
            this.searchAndManageCustomerToolStripMenuItem.Click += new System.EventHandler(this.searchAndManageCustomerToolStripMenuItem_Click);
            // 
            // inverntoryToolStripMenuItem
            // 
            this.inverntoryToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addPurchaseBillToolStripMenuItem,
            this.searchAndManagePurchaseBillToolStripMenuItem,
            this.addPurchaseReturnDebitNoteToolStripMenuItem,
            this.searchAndManagePurchaseReturnToolStripMenuItem,
            this.addSupplierToolStripMenuItem,
            this.searchAndManageSupplierToolStripMenuItem});
            this.inverntoryToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inverntoryToolStripMenuItem.Image = global::Gorakshnath_Billing_System.Properties.Resources.images;
            this.inverntoryToolStripMenuItem.Name = "inverntoryToolStripMenuItem";
            this.inverntoryToolStripMenuItem.Size = new System.Drawing.Size(99, 24);
            this.inverntoryToolStripMenuItem.Text = "Purchase";
            this.inverntoryToolStripMenuItem.Click += new System.EventHandler(this.inverntoryToolStripMenuItem_Click);
            // 
            // addPurchaseBillToolStripMenuItem
            // 
            this.addPurchaseBillToolStripMenuItem.Name = "addPurchaseBillToolStripMenuItem";
            this.addPurchaseBillToolStripMenuItem.Size = new System.Drawing.Size(318, 24);
            this.addPurchaseBillToolStripMenuItem.Text = "Add Purchase Bill";
            this.addPurchaseBillToolStripMenuItem.Click += new System.EventHandler(this.addPurchaseBillToolStripMenuItem_Click);
            // 
            // searchAndManagePurchaseBillToolStripMenuItem
            // 
            this.searchAndManagePurchaseBillToolStripMenuItem.Name = "searchAndManagePurchaseBillToolStripMenuItem";
            this.searchAndManagePurchaseBillToolStripMenuItem.Size = new System.Drawing.Size(318, 24);
            this.searchAndManagePurchaseBillToolStripMenuItem.Text = "Search and Manage Purchase Bill";
            this.searchAndManagePurchaseBillToolStripMenuItem.Click += new System.EventHandler(this.searchAndManagePurchaseBillToolStripMenuItem_Click);
            // 
            // addPurchaseReturnDebitNoteToolStripMenuItem
            // 
            this.addPurchaseReturnDebitNoteToolStripMenuItem.Name = "addPurchaseReturnDebitNoteToolStripMenuItem";
            this.addPurchaseReturnDebitNoteToolStripMenuItem.Size = new System.Drawing.Size(318, 24);
            this.addPurchaseReturnDebitNoteToolStripMenuItem.Text = "Add Purchase Return (Debit Note)";
            this.addPurchaseReturnDebitNoteToolStripMenuItem.Click += new System.EventHandler(this.addPurchaseReturnDebitNoteToolStripMenuItem_Click);
            // 
            // searchAndManagePurchaseReturnToolStripMenuItem
            // 
            this.searchAndManagePurchaseReturnToolStripMenuItem.Name = "searchAndManagePurchaseReturnToolStripMenuItem";
            this.searchAndManagePurchaseReturnToolStripMenuItem.Size = new System.Drawing.Size(318, 24);
            this.searchAndManagePurchaseReturnToolStripMenuItem.Text = "Search and Manage Purchase Return";
            this.searchAndManagePurchaseReturnToolStripMenuItem.Click += new System.EventHandler(this.searchAndManagePurchaseReturnToolStripMenuItem_Click);
            // 
            // addSupplierToolStripMenuItem
            // 
            this.addSupplierToolStripMenuItem.Name = "addSupplierToolStripMenuItem";
            this.addSupplierToolStripMenuItem.Size = new System.Drawing.Size(318, 24);
            this.addSupplierToolStripMenuItem.Text = "Add Supplier";
            this.addSupplierToolStripMenuItem.Click += new System.EventHandler(this.addSupplierToolStripMenuItem_Click);
            // 
            // searchAndManageSupplierToolStripMenuItem
            // 
            this.searchAndManageSupplierToolStripMenuItem.Name = "searchAndManageSupplierToolStripMenuItem";
            this.searchAndManageSupplierToolStripMenuItem.Size = new System.Drawing.Size(318, 24);
            this.searchAndManageSupplierToolStripMenuItem.Text = "Search and Manage Supplier";
            this.searchAndManageSupplierToolStripMenuItem.Click += new System.EventHandler(this.searchAndManageSupplierToolStripMenuItem_Click);
            // 
            // transactionsToolStripMenuItem
            // 
            this.transactionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewProductToolStripMenuItem,
            this.searchAndManageProductToolStripMenuItem,
            this.manageBrandToolStripMenuItem,
            this.manageProductGroupToolStripMenuItem});
            this.transactionsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transactionsToolStripMenuItem.Image = global::Gorakshnath_Billing_System.Properties.Resources.images__1_;
            this.transactionsToolStripMenuItem.Name = "transactionsToolStripMenuItem";
            this.transactionsToolStripMenuItem.Size = new System.Drawing.Size(86, 24);
            this.transactionsToolStripMenuItem.Text = "Master";
            // 
            // addNewProductToolStripMenuItem
            // 
            this.addNewProductToolStripMenuItem.Name = "addNewProductToolStripMenuItem";
            this.addNewProductToolStripMenuItem.Size = new System.Drawing.Size(195, 24);
            this.addNewProductToolStripMenuItem.Text = "Add New Product";
            this.addNewProductToolStripMenuItem.Click += new System.EventHandler(this.addNewProductToolStripMenuItem_Click);
            // 
            // searchAndManageProductToolStripMenuItem
            // 
            this.searchAndManageProductToolStripMenuItem.Name = "searchAndManageProductToolStripMenuItem";
            this.searchAndManageProductToolStripMenuItem.Size = new System.Drawing.Size(195, 24);
            this.searchAndManageProductToolStripMenuItem.Text = "Manage Product";
            this.searchAndManageProductToolStripMenuItem.Click += new System.EventHandler(this.searchAndManageProductToolStripMenuItem_Click);
            // 
            // manageBrandToolStripMenuItem
            // 
            this.manageBrandToolStripMenuItem.Name = "manageBrandToolStripMenuItem";
            this.manageBrandToolStripMenuItem.Size = new System.Drawing.Size(195, 24);
            this.manageBrandToolStripMenuItem.Text = "Brand Master";
            this.manageBrandToolStripMenuItem.Click += new System.EventHandler(this.manageBrandToolStripMenuItem_Click);
            // 
            // manageProductGroupToolStripMenuItem
            // 
            this.manageProductGroupToolStripMenuItem.Name = "manageProductGroupToolStripMenuItem";
            this.manageProductGroupToolStripMenuItem.Size = new System.Drawing.Size(195, 24);
            this.manageProductGroupToolStripMenuItem.Text = "Group Master";
            this.manageProductGroupToolStripMenuItem.Click += new System.EventHandler(this.manageProductGroupToolStripMenuItem_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.totalSalesReportToolStripMenuItem,
            this.itemWiseSalesReportToolStripMenuItem,
            this.estimateReportToolStripMenuItem,
            this.totalPurchaseReportToolStripMenuItem,
            this.challanReportToolStripMenuItem,
            this.salesReturnReportToolStripMenuItem,
            this.purchasaaeReturnReportToolStripMenuItem,
            this.debtorsAndCreditorsToolStripMenuItem});
            this.reportsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reportsToolStripMenuItem.Image = global::Gorakshnath_Billing_System.Properties.Resources.images__1_1;
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(92, 24);
            this.reportsToolStripMenuItem.Text = "Reports";
            // 
            // totalSalesReportToolStripMenuItem
            // 
            this.totalSalesReportToolStripMenuItem.Name = "totalSalesReportToolStripMenuItem";
            this.totalSalesReportToolStripMenuItem.Size = new System.Drawing.Size(261, 24);
            this.totalSalesReportToolStripMenuItem.Text = "Sales Report";
            this.totalSalesReportToolStripMenuItem.Click += new System.EventHandler(this.totalSalesReportToolStripMenuItem_Click);
            // 
            // itemWiseSalesReportToolStripMenuItem
            // 
            this.itemWiseSalesReportToolStripMenuItem.Name = "itemWiseSalesReportToolStripMenuItem";
            this.itemWiseSalesReportToolStripMenuItem.Size = new System.Drawing.Size(261, 24);
            this.itemWiseSalesReportToolStripMenuItem.Text = "Purchase Report";
            this.itemWiseSalesReportToolStripMenuItem.Click += new System.EventHandler(this.itemWiseSalesReportToolStripMenuItem_Click);
            // 
            // estimateReportToolStripMenuItem
            // 
            this.estimateReportToolStripMenuItem.Name = "estimateReportToolStripMenuItem";
            this.estimateReportToolStripMenuItem.Size = new System.Drawing.Size(261, 24);
            this.estimateReportToolStripMenuItem.Text = "Estimate/Quotation  Report";
            this.estimateReportToolStripMenuItem.Click += new System.EventHandler(this.estimateReportToolStripMenuItem_Click);
            // 
            // totalPurchaseReportToolStripMenuItem
            // 
            this.totalPurchaseReportToolStripMenuItem.Name = "totalPurchaseReportToolStripMenuItem";
            this.totalPurchaseReportToolStripMenuItem.Size = new System.Drawing.Size(261, 24);
            this.totalPurchaseReportToolStripMenuItem.Text = "Stock Report";
            this.totalPurchaseReportToolStripMenuItem.Click += new System.EventHandler(this.totalPurchaseReportToolStripMenuItem_Click);
            // 
            // challanReportToolStripMenuItem
            // 
            this.challanReportToolStripMenuItem.Name = "challanReportToolStripMenuItem";
            this.challanReportToolStripMenuItem.Size = new System.Drawing.Size(261, 24);
            this.challanReportToolStripMenuItem.Text = "Delivery Challan Report";
            this.challanReportToolStripMenuItem.Click += new System.EventHandler(this.challanReportToolStripMenuItem_Click);
            // 
            // salesReturnReportToolStripMenuItem
            // 
            this.salesReturnReportToolStripMenuItem.Name = "salesReturnReportToolStripMenuItem";
            this.salesReturnReportToolStripMenuItem.Size = new System.Drawing.Size(261, 24);
            this.salesReturnReportToolStripMenuItem.Text = "Sales Return Report";
            this.salesReturnReportToolStripMenuItem.Click += new System.EventHandler(this.salesReturnReportToolStripMenuItem_Click);
            // 
            // purchasaaeReturnReportToolStripMenuItem
            // 
            this.purchasaaeReturnReportToolStripMenuItem.Name = "purchasaaeReturnReportToolStripMenuItem";
            this.purchasaaeReturnReportToolStripMenuItem.Size = new System.Drawing.Size(261, 24);
            this.purchasaaeReturnReportToolStripMenuItem.Text = "Purchase Return Report";
            this.purchasaaeReturnReportToolStripMenuItem.Click += new System.EventHandler(this.purchasaaeReturnReportToolStripMenuItem_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.LimeGreen;
            this.label3.Location = new System.Drawing.Point(66, 35);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 18);
            this.label3.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.label4.Location = new System.Drawing.Point(549, 497);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(455, 32);
            this.label4.TabIndex = 4;
            this.label4.Text = "Shiv Gorakshnath Traders Billing System";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Gorakshnath_Billing_System.Properties.Resources._try;
            this.pictureBox1.Location = new System.Drawing.Point(553, 197);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(451, 298);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // Time
            // 
            this.Time.AutoSize = true;
            this.Time.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Time.ForeColor = System.Drawing.Color.DarkCyan;
            this.Time.Location = new System.Drawing.Point(1277, 21);
            this.Time.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Time.Name = "Time";
            this.Time.Size = new System.Drawing.Size(64, 25);
            this.Time.TabIndex = 6;
            this.Time.Text = "label2";
            this.Time.Click += new System.EventHandler(this.Time_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Date
            // 
            this.Date.AutoSize = true;
            this.Date.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Date.ForeColor = System.Drawing.Color.DarkCyan;
            this.Date.Location = new System.Drawing.Point(1277, 50);
            this.Date.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Date.Name = "Date";
            this.Date.Size = new System.Drawing.Size(64, 25);
            this.Date.TabIndex = 7;
            this.Date.Text = "label5";
            this.Date.Click += new System.EventHandler(this.Date_Click);
            // 
            // debtorsAndCreditorsToolStripMenuItem
            // 
            this.debtorsAndCreditorsToolStripMenuItem.Name = "debtorsAndCreditorsToolStripMenuItem";
            this.debtorsAndCreditorsToolStripMenuItem.Size = new System.Drawing.Size(261, 24);
            this.debtorsAndCreditorsToolStripMenuItem.Text = "Debtors And Creditors";
            this.debtorsAndCreditorsToolStripMenuItem.Click += new System.EventHandler(this.debtorsAndCreditorsToolStripMenuItem_Click);
            // 
            // frmAdminDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 589);
            this.Controls.Add(this.Date);
            this.Controls.Add(this.Time);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pnllFooter);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmAdminDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin Dashboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmAdminDashboard_FormClosed);
            this.Load += new System.EventHandler(this.frmAdminDashboard_Load);
            this.pnllFooter.ResumeLayout(false);
            this.pnllFooter.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnllFooter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem usersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inverntoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transactionsToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripMenuItem newInvoiceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchAndManageInvoiceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newSalesReturnCreditNoteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newDeliveryNoteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newQuotationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchAndManageQuotationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addPurchaseBillToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchAndManagePurchaseBillToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addPurchaseReturnDebitNoteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchAndManagePurchaseReturnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addSupplierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchAndManageSupplierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addCustomerClientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewProductToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchAndManageProductToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem totalSalesReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemWiseSalesReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem totalPurchaseReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageBrandToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageProductGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchAndManageCustomerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem challanReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchAndManageSalesReturnCreditNoteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchAndManageDeliveryNoteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salesReturnReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem purchasaaeReturnReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem estimateReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageUsersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label Time;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label Date;
        private System.Windows.Forms.ToolStripMenuItem debtorsAndCreditorsToolStripMenuItem;
    }
}

