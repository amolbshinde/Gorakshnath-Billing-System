﻿
namespace Gorakshnath_Billing_System.UI
{
    partial class frmPurchaseManage
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
            this.panel5 = new System.Windows.Forms.Panel();
            this.comboPaymentMode = new System.Windows.Forms.ComboBox();
            this.textBalance = new System.Windows.Forms.TextBox();
            this.textAmountPaid = new System.Windows.Forms.TextBox();
            this.textTransactionId = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.comboContact = new System.Windows.Forms.ComboBox();
            this.comboSearchSup = new System.Windows.Forms.ComboBox();
            this.textInvoiceNo = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.comboTransactionType = new System.Windows.Forms.ComboBox();
            this.label29 = new System.Windows.Forms.Label();
            this.textPurchaseBillNo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpBillDate = new System.Windows.Forms.DateTimePicker();
            this.textAddress = new System.Windows.Forms.TextBox();
            this.textEmail = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.comboItemSearch = new System.Windows.Forms.ComboBox();
            this.label35 = new System.Windows.Forms.Label();
            this.textItemName = new System.Windows.Forms.TextBox();
            this.comboGstType = new System.Windows.Forms.ComboBox();
            this.textGST = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.textItemCode = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.textTotalAmount = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.textDiscount = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.textRate = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.comboBoxUnit = new System.Windows.Forms.ComboBox();
            this.textQuantity = new System.Windows.Forms.TextBox();
            this.textInventory = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.textIgst = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.textCgst = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.textSubDiscount = new System.Windows.Forms.TextBox();
            this.textSgst = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.textSubTotal = new System.Windows.Forms.TextBox();
            this.textGrandTotal = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dgvAddedProducts = new System.Windows.Forms.DataGridView();
            this.label21 = new System.Windows.Forms.Label();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAddedProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel5.Controls.Add(this.comboPaymentMode);
            this.panel5.Controls.Add(this.textBalance);
            this.panel5.Controls.Add(this.textAmountPaid);
            this.panel5.Controls.Add(this.textTransactionId);
            this.panel5.Controls.Add(this.label26);
            this.panel5.Controls.Add(this.label25);
            this.panel5.Controls.Add(this.label24);
            this.panel5.Controls.Add(this.label23);
            this.panel5.Controls.Add(this.label22);
            this.panel5.Location = new System.Drawing.Point(19, 477);
            this.panel5.Margin = new System.Windows.Forms.Padding(2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(578, 238);
            this.panel5.TabIndex = 31;
            // 
            // comboPaymentMode
            // 
            this.comboPaymentMode.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboPaymentMode.FormattingEnabled = true;
            this.comboPaymentMode.Items.AddRange(new object[] {
            "Cash",
            "Cheque",
            "Online"});
            this.comboPaymentMode.Location = new System.Drawing.Point(179, 34);
            this.comboPaymentMode.Margin = new System.Windows.Forms.Padding(2);
            this.comboPaymentMode.Name = "comboPaymentMode";
            this.comboPaymentMode.Size = new System.Drawing.Size(256, 27);
            this.comboPaymentMode.TabIndex = 29;
            // 
            // textBalance
            // 
            this.textBalance.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBalance.Location = new System.Drawing.Point(179, 133);
            this.textBalance.Margin = new System.Windows.Forms.Padding(2);
            this.textBalance.Name = "textBalance";
            this.textBalance.Size = new System.Drawing.Size(256, 26);
            this.textBalance.TabIndex = 28;
            // 
            // textAmountPaid
            // 
            this.textAmountPaid.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textAmountPaid.Location = new System.Drawing.Point(179, 98);
            this.textAmountPaid.Margin = new System.Windows.Forms.Padding(2);
            this.textAmountPaid.Name = "textAmountPaid";
            this.textAmountPaid.Size = new System.Drawing.Size(256, 26);
            this.textAmountPaid.TabIndex = 27;
            // 
            // textTransactionId
            // 
            this.textTransactionId.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textTransactionId.Location = new System.Drawing.Point(179, 64);
            this.textTransactionId.Margin = new System.Windows.Forms.Padding(2);
            this.textTransactionId.Name = "textTransactionId";
            this.textTransactionId.Size = new System.Drawing.Size(256, 26);
            this.textTransactionId.TabIndex = 26;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(70, 64);
            this.label26.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(106, 20);
            this.label26.TabIndex = 25;
            this.label26.Text = "Transaction ID";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(112, 137);
            this.label25.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(62, 20);
            this.label25.TabIndex = 24;
            this.label25.Text = "Balance";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(77, 98);
            this.label24.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(98, 20);
            this.label24.TabIndex = 23;
            this.label24.Text = "Amount Piad";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(64, 34);
            this.label23.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(113, 20);
            this.label23.TabIndex = 22;
            this.label23.Text = "Payment Mode";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(2, -2);
            this.label22.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(78, 20);
            this.label22.TabIndex = 20;
            this.label22.Text = "Payments";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.comboContact);
            this.panel2.Controls.Add(this.comboSearchSup);
            this.panel2.Controls.Add(this.textInvoiceNo);
            this.panel2.Controls.Add(this.label30);
            this.panel2.Controls.Add(this.comboTransactionType);
            this.panel2.Controls.Add(this.label29);
            this.panel2.Controls.Add(this.textPurchaseBillNo);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.dtpBillDate);
            this.panel2.Controls.Add(this.textAddress);
            this.panel2.Controls.Add(this.textEmail);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(19, 20);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1057, 119);
            this.panel2.TabIndex = 27;
            // 
            // comboContact
            // 
            this.comboContact.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboContact.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboContact.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboContact.FormattingEnabled = true;
            this.comboContact.Items.AddRange(new object[] {
            "GST",
            "Non GST"});
            this.comboContact.Location = new System.Drawing.Point(202, 92);
            this.comboContact.Margin = new System.Windows.Forms.Padding(2);
            this.comboContact.Name = "comboContact";
            this.comboContact.Size = new System.Drawing.Size(204, 23);
            this.comboContact.TabIndex = 21;
            // 
            // comboSearchSup
            // 
            this.comboSearchSup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboSearchSup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboSearchSup.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboSearchSup.FormattingEnabled = true;
            this.comboSearchSup.Items.AddRange(new object[] {
            "GST",
            "Non GST"});
            this.comboSearchSup.Location = new System.Drawing.Point(202, 45);
            this.comboSearchSup.Margin = new System.Windows.Forms.Padding(2);
            this.comboSearchSup.Name = "comboSearchSup";
            this.comboSearchSup.Size = new System.Drawing.Size(204, 23);
            this.comboSearchSup.TabIndex = 20;
            // 
            // textInvoiceNo
            // 
            this.textInvoiceNo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textInvoiceNo.Location = new System.Drawing.Point(421, 89);
            this.textInvoiceNo.Margin = new System.Windows.Forms.Padding(2);
            this.textInvoiceNo.Name = "textInvoiceNo";
            this.textInvoiceNo.ReadOnly = true;
            this.textInvoiceNo.Size = new System.Drawing.Size(180, 23);
            this.textInvoiceNo.TabIndex = 19;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Location = new System.Drawing.Point(422, 68);
            this.label30.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(77, 19);
            this.label30.TabIndex = 18;
            this.label30.Text = "Invoice No.";
            // 
            // comboTransactionType
            // 
            this.comboTransactionType.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboTransactionType.FormattingEnabled = true;
            this.comboTransactionType.Items.AddRange(new object[] {
            "GST",
            "Non GST"});
            this.comboTransactionType.Location = new System.Drawing.Point(6, 45);
            this.comboTransactionType.Margin = new System.Windows.Forms.Padding(2);
            this.comboTransactionType.Name = "comboTransactionType";
            this.comboTransactionType.Size = new System.Drawing.Size(180, 23);
            this.comboTransactionType.TabIndex = 17;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(3, 25);
            this.label29.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(71, 19);
            this.label29.TabIndex = 16;
            this.label29.Text = "Sales Type";
            // 
            // textPurchaseBillNo
            // 
            this.textPurchaseBillNo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textPurchaseBillNo.Location = new System.Drawing.Point(842, 90);
            this.textPurchaseBillNo.Margin = new System.Windows.Forms.Padding(2);
            this.textPurchaseBillNo.Name = "textPurchaseBillNo";
            this.textPurchaseBillNo.Size = new System.Drawing.Size(180, 23);
            this.textPurchaseBillNo.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(835, 72);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 15);
            this.label9.TabIndex = 13;
            this.label9.Text = "Transaction ID";
            // 
            // dtpBillDate
            // 
            this.dtpBillDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpBillDate.Location = new System.Drawing.Point(838, 46);
            this.dtpBillDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtpBillDate.Name = "dtpBillDate";
            this.dtpBillDate.Size = new System.Drawing.Size(180, 23);
            this.dtpBillDate.TabIndex = 12;
            // 
            // textAddress
            // 
            this.textAddress.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textAddress.Location = new System.Drawing.Point(618, 46);
            this.textAddress.Margin = new System.Windows.Forms.Padding(2);
            this.textAddress.Multiline = true;
            this.textAddress.Name = "textAddress";
            this.textAddress.ReadOnly = true;
            this.textAddress.Size = new System.Drawing.Size(209, 70);
            this.textAddress.TabIndex = 11;
            // 
            // textEmail
            // 
            this.textEmail.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEmail.Location = new System.Drawing.Point(421, 45);
            this.textEmail.Margin = new System.Windows.Forms.Padding(2);
            this.textEmail.Name = "textEmail";
            this.textEmail.ReadOnly = true;
            this.textEmail.Size = new System.Drawing.Size(180, 23);
            this.textEmail.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(845, 26);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 19);
            this.label7.TabIndex = 6;
            this.label7.Text = "Bill Date";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(615, 24);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 19);
            this.label8.TabIndex = 5;
            this.label8.Text = "Address";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(202, 70);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 19);
            this.label5.TabIndex = 4;
            this.label5.Text = "Contact";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(422, 24);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 19);
            this.label6.TabIndex = 3;
            this.label6.Text = "Email";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(198, 24);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 19);
            this.label4.TabIndex = 2;
            this.label4.Text = "Customer Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(2, 6);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Customer Details";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.comboItemSearch);
            this.panel3.Controls.Add(this.label35);
            this.panel3.Controls.Add(this.textItemName);
            this.panel3.Controls.Add(this.comboGstType);
            this.panel3.Controls.Add(this.textGST);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.label31);
            this.panel3.Controls.Add(this.textItemCode);
            this.panel3.Controls.Add(this.label20);
            this.panel3.Controls.Add(this.btnAdd);
            this.panel3.Controls.Add(this.textTotalAmount);
            this.panel3.Controls.Add(this.label19);
            this.panel3.Controls.Add(this.label18);
            this.panel3.Controls.Add(this.textDiscount);
            this.panel3.Controls.Add(this.label17);
            this.panel3.Controls.Add(this.textRate);
            this.panel3.Controls.Add(this.label16);
            this.panel3.Controls.Add(this.comboBoxUnit);
            this.panel3.Controls.Add(this.textQuantity);
            this.panel3.Controls.Add(this.textInventory);
            this.panel3.Controls.Add(this.label15);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Location = new System.Drawing.Point(19, 139);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1057, 88);
            this.panel3.TabIndex = 28;
            // 
            // comboItemSearch
            // 
            this.comboItemSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboItemSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboItemSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboItemSearch.FormattingEnabled = true;
            this.comboItemSearch.Items.AddRange(new object[] {
            "GST",
            "Non GST"});
            this.comboItemSearch.Location = new System.Drawing.Point(73, 49);
            this.comboItemSearch.Margin = new System.Windows.Forms.Padding(2);
            this.comboItemSearch.Name = "comboItemSearch";
            this.comboItemSearch.Size = new System.Drawing.Size(143, 23);
            this.comboItemSearch.TabIndex = 21;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.Location = new System.Drawing.Point(70, 28);
            this.label35.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(49, 19);
            this.label35.TabIndex = 43;
            this.label35.Text = "Search";
            // 
            // textItemName
            // 
            this.textItemName.BackColor = System.Drawing.SystemColors.Window;
            this.textItemName.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textItemName.Location = new System.Drawing.Point(220, 48);
            this.textItemName.Margin = new System.Windows.Forms.Padding(2);
            this.textItemName.Name = "textItemName";
            this.textItemName.ReadOnly = true;
            this.textItemName.Size = new System.Drawing.Size(172, 26);
            this.textItemName.TabIndex = 41;
            // 
            // comboGstType
            // 
            this.comboGstType.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboGstType.FormattingEnabled = true;
            this.comboGstType.Items.AddRange(new object[] {
            "SGST/CGST",
            "IGST"});
            this.comboGstType.Location = new System.Drawing.Point(739, 47);
            this.comboGstType.Margin = new System.Windows.Forms.Padding(2);
            this.comboGstType.Name = "comboGstType";
            this.comboGstType.Size = new System.Drawing.Size(92, 27);
            this.comboGstType.TabIndex = 40;
            // 
            // textGST
            // 
            this.textGST.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textGST.Location = new System.Drawing.Point(834, 48);
            this.textGST.Margin = new System.Windows.Forms.Padding(2);
            this.textGST.Name = "textGST";
            this.textGST.Size = new System.Drawing.Size(56, 26);
            this.textGST.TabIndex = 39;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(822, 20);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(57, 20);
            this.label12.TabIndex = 38;
            this.label12.Text = "GST(%)";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label31.Location = new System.Drawing.Point(338, 32);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(56, 15);
            this.label31.TabIndex = 37;
            this.label31.Text = "Add Item";
            // 
            // textItemCode
            // 
            this.textItemCode.BackColor = System.Drawing.SystemColors.Window;
            this.textItemCode.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textItemCode.Location = new System.Drawing.Point(3, 48);
            this.textItemCode.Margin = new System.Windows.Forms.Padding(2);
            this.textItemCode.Name = "textItemCode";
            this.textItemCode.ReadOnly = true;
            this.textItemCode.Size = new System.Drawing.Size(66, 26);
            this.textItemCode.TabIndex = 36;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(3, 28);
            this.label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(66, 19);
            this.label20.TabIndex = 35;
            this.label20.Text = "Item  No.";
            // 
            // btnAdd
            // 
            this.btnAdd.FlatAppearance.BorderSize = 2;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.Teal;
            this.btnAdd.Location = new System.Drawing.Point(976, 37);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(70, 35);
            this.btnAdd.TabIndex = 34;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // textTotalAmount
            // 
            this.textTotalAmount.BackColor = System.Drawing.SystemColors.Window;
            this.textTotalAmount.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textTotalAmount.Location = new System.Drawing.Point(896, 48);
            this.textTotalAmount.Margin = new System.Windows.Forms.Padding(2);
            this.textTotalAmount.Name = "textTotalAmount";
            this.textTotalAmount.ReadOnly = true;
            this.textTotalAmount.Size = new System.Drawing.Size(77, 26);
            this.textTotalAmount.TabIndex = 33;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(892, 21);
            this.label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(62, 20);
            this.label19.TabIndex = 32;
            this.label19.Text = "Amount";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(743, 21);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(70, 20);
            this.label18.TabIndex = 30;
            this.label18.Text = "GST Type";
            // 
            // textDiscount
            // 
            this.textDiscount.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textDiscount.Location = new System.Drawing.Point(672, 48);
            this.textDiscount.Margin = new System.Windows.Forms.Padding(2);
            this.textDiscount.Name = "textDiscount";
            this.textDiscount.Size = new System.Drawing.Size(56, 26);
            this.textDiscount.TabIndex = 29;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(668, 25);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(66, 20);
            this.label17.TabIndex = 28;
            this.label17.Text = "Disc.( %)";
            // 
            // textRate
            // 
            this.textRate.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textRate.Location = new System.Drawing.Point(569, 48);
            this.textRate.Margin = new System.Windows.Forms.Padding(2);
            this.textRate.Name = "textRate";
            this.textRate.Size = new System.Drawing.Size(99, 26);
            this.textRate.TabIndex = 27;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(570, 23);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(39, 20);
            this.label16.TabIndex = 26;
            this.label16.Text = "Rate";
            // 
            // comboBoxUnit
            // 
            this.comboBoxUnit.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxUnit.FormattingEnabled = true;
            this.comboBoxUnit.Items.AddRange(new object[] {
            "K.g.",
            "Foot",
            "Nos"});
            this.comboBoxUnit.Location = new System.Drawing.Point(475, 47);
            this.comboBoxUnit.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxUnit.Name = "comboBoxUnit";
            this.comboBoxUnit.Size = new System.Drawing.Size(46, 27);
            this.comboBoxUnit.TabIndex = 25;
            // 
            // textQuantity
            // 
            this.textQuantity.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textQuantity.Location = new System.Drawing.Point(524, 48);
            this.textQuantity.Margin = new System.Windows.Forms.Padding(2);
            this.textQuantity.Name = "textQuantity";
            this.textQuantity.Size = new System.Drawing.Size(33, 26);
            this.textQuantity.TabIndex = 24;
            // 
            // textInventory
            // 
            this.textInventory.BackColor = System.Drawing.SystemColors.Window;
            this.textInventory.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textInventory.Location = new System.Drawing.Point(396, 48);
            this.textInventory.Margin = new System.Windows.Forms.Padding(2);
            this.textInventory.Name = "textInventory";
            this.textInventory.ReadOnly = true;
            this.textInventory.Size = new System.Drawing.Size(75, 26);
            this.textInventory.TabIndex = 22;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(481, 24);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(36, 20);
            this.label15.TabIndex = 21;
            this.label15.Text = "Unit";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(520, 23);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(35, 20);
            this.label14.TabIndex = 20;
            this.label14.Text = "Qty.";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(392, 24);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(70, 20);
            this.label13.TabIndex = 19;
            this.label13.Text = "Inventory";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(227, 24);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(83, 20);
            this.label11.TabIndex = 17;
            this.label11.Text = "Item Name";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(-3, 0);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(111, 19);
            this.label10.TabIndex = 16;
            this.label10.Text = "Product Details";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btnExit);
            this.panel6.Controls.Add(this.btnPrint);
            this.panel6.Controls.Add(this.btnClear);
            this.panel6.Controls.Add(this.textIgst);
            this.panel6.Controls.Add(this.label36);
            this.panel6.Controls.Add(this.textCgst);
            this.panel6.Controls.Add(this.label34);
            this.panel6.Controls.Add(this.textSubDiscount);
            this.panel6.Controls.Add(this.textSgst);
            this.panel6.Controls.Add(this.label33);
            this.panel6.Controls.Add(this.label32);
            this.panel6.Controls.Add(this.textSubTotal);
            this.panel6.Controls.Add(this.textGrandTotal);
            this.panel6.Controls.Add(this.btnSave);
            this.panel6.Controls.Add(this.label27);
            this.panel6.Controls.Add(this.label28);
            this.panel6.Location = new System.Drawing.Point(601, 476);
            this.panel6.Margin = new System.Windows.Forms.Padding(2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(476, 240);
            this.panel6.TabIndex = 30;
            // 
            // btnExit
            // 
            this.btnExit.FlatAppearance.BorderSize = 2;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.btnExit.Location = new System.Drawing.Point(63, 191);
            this.btnExit.Margin = new System.Windows.Forms.Padding(2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(98, 32);
            this.btnExit.TabIndex = 39;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // btnPrint
            // 
            this.btnPrint.FlatAppearance.BorderSize = 2;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ForeColor = System.Drawing.Color.BlueViolet;
            this.btnPrint.Location = new System.Drawing.Point(267, 191);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(2);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(76, 32);
            this.btnPrint.TabIndex = 38;
            this.btnPrint.Text = " Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.FlatAppearance.BorderSize = 2;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.btnClear.Location = new System.Drawing.Point(165, 191);
            this.btnClear.Margin = new System.Windows.Forms.Padding(2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(98, 32);
            this.btnClear.TabIndex = 37;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // textIgst
            // 
            this.textIgst.BackColor = System.Drawing.SystemColors.Window;
            this.textIgst.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textIgst.Location = new System.Drawing.Point(332, 128);
            this.textIgst.Margin = new System.Windows.Forms.Padding(2);
            this.textIgst.Name = "textIgst";
            this.textIgst.ReadOnly = true;
            this.textIgst.Size = new System.Drawing.Size(110, 26);
            this.textIgst.TabIndex = 36;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.Location = new System.Drawing.Point(264, 130);
            this.label36.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(65, 20);
            this.label36.TabIndex = 35;
            this.label36.Text = "IGST(+)";
            // 
            // textCgst
            // 
            this.textCgst.BackColor = System.Drawing.SystemColors.Window;
            this.textCgst.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textCgst.Location = new System.Drawing.Point(332, 100);
            this.textCgst.Margin = new System.Windows.Forms.Padding(2);
            this.textCgst.Name = "textCgst";
            this.textCgst.ReadOnly = true;
            this.textCgst.Size = new System.Drawing.Size(110, 26);
            this.textCgst.TabIndex = 34;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.Location = new System.Drawing.Point(262, 103);
            this.label34.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(69, 20);
            this.label34.TabIndex = 33;
            this.label34.Text = "CGST(+)";
            // 
            // textSubDiscount
            // 
            this.textSubDiscount.BackColor = System.Drawing.SystemColors.Window;
            this.textSubDiscount.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textSubDiscount.Location = new System.Drawing.Point(332, 37);
            this.textSubDiscount.Margin = new System.Windows.Forms.Padding(2);
            this.textSubDiscount.Name = "textSubDiscount";
            this.textSubDiscount.ReadOnly = true;
            this.textSubDiscount.Size = new System.Drawing.Size(110, 26);
            this.textSubDiscount.TabIndex = 32;
            // 
            // textSgst
            // 
            this.textSgst.BackColor = System.Drawing.SystemColors.Window;
            this.textSgst.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textSgst.Location = new System.Drawing.Point(332, 71);
            this.textSgst.Margin = new System.Windows.Forms.Padding(2);
            this.textSgst.Name = "textSgst";
            this.textSgst.ReadOnly = true;
            this.textSgst.Size = new System.Drawing.Size(110, 26);
            this.textSgst.TabIndex = 31;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.Location = new System.Drawing.Point(240, 38);
            this.label33.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(93, 20);
            this.label33.TabIndex = 30;
            this.label33.Text = "Discount (-)";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.Location = new System.Drawing.Point(266, 72);
            this.label32.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(68, 20);
            this.label32.TabIndex = 29;
            this.label32.Text = "SGST(+)";
            // 
            // textSubTotal
            // 
            this.textSubTotal.BackColor = System.Drawing.SystemColors.Window;
            this.textSubTotal.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textSubTotal.Location = new System.Drawing.Point(332, 6);
            this.textSubTotal.Margin = new System.Windows.Forms.Padding(2);
            this.textSubTotal.Name = "textSubTotal";
            this.textSubTotal.ReadOnly = true;
            this.textSubTotal.Size = new System.Drawing.Size(110, 26);
            this.textSubTotal.TabIndex = 28;
            // 
            // textGrandTotal
            // 
            this.textGrandTotal.BackColor = System.Drawing.SystemColors.Window;
            this.textGrandTotal.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textGrandTotal.Location = new System.Drawing.Point(332, 158);
            this.textGrandTotal.Margin = new System.Windows.Forms.Padding(2);
            this.textGrandTotal.Name = "textGrandTotal";
            this.textGrandTotal.ReadOnly = true;
            this.textGrandTotal.Size = new System.Drawing.Size(110, 26);
            this.textGrandTotal.TabIndex = 27;
            // 
            // btnSave
            // 
            this.btnSave.FlatAppearance.BorderSize = 2;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Teal;
            this.btnSave.Location = new System.Drawing.Point(346, 191);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(94, 32);
            this.btnSave.TabIndex = 23;
            this.btnSave.Text = "Save ";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(232, 155);
            this.label27.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(91, 20);
            this.label27.TabIndex = 21;
            this.label27.Text = "Grand Total";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(248, 6);
            this.label28.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(74, 20);
            this.label28.TabIndex = 22;
            this.label28.Text = "Sub Total";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dgvAddedProducts);
            this.panel4.Controls.Add(this.label21);
            this.panel4.Location = new System.Drawing.Point(19, 228);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1057, 247);
            this.panel4.TabIndex = 29;
            // 
            // dgvAddedProducts
            // 
            this.dgvAddedProducts.AllowUserToAddRows = false;
            this.dgvAddedProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAddedProducts.Location = new System.Drawing.Point(8, 22);
            this.dgvAddedProducts.Margin = new System.Windows.Forms.Padding(2);
            this.dgvAddedProducts.Name = "dgvAddedProducts";
            this.dgvAddedProducts.RowHeadersWidth = 51;
            this.dgvAddedProducts.RowTemplate.Height = 24;
            this.dgvAddedProducts.Size = new System.Drawing.Size(1014, 214);
            this.dgvAddedProducts.TabIndex = 20;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(2, 0);
            this.label21.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(99, 20);
            this.label21.TabIndex = 19;
            this.label21.Text = "Added Items";
            // 
            // frmPurchaseManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1097, 736);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel4);
            this.Name = "frmPurchaseManage";
            this.Text = "Purchase Manage";
            this.Load += new System.EventHandler(this.frmPurchaseManage_Load);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAddedProducts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ComboBox comboPaymentMode;
        private System.Windows.Forms.TextBox textBalance;
        private System.Windows.Forms.TextBox textAmountPaid;
        private System.Windows.Forms.TextBox textTransactionId;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox comboContact;
        private System.Windows.Forms.ComboBox comboSearchSup;
        private System.Windows.Forms.TextBox textInvoiceNo;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.ComboBox comboTransactionType;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox textPurchaseBillNo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpBillDate;
        private System.Windows.Forms.TextBox textAddress;
        private System.Windows.Forms.TextBox textEmail;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox comboItemSearch;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.TextBox textItemName;
        private System.Windows.Forms.ComboBox comboGstType;
        private System.Windows.Forms.TextBox textGST;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.TextBox textItemCode;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox textTotalAmount;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox textDiscount;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox textRate;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox comboBoxUnit;
        private System.Windows.Forms.TextBox textQuantity;
        private System.Windows.Forms.TextBox textInventory;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox textIgst;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.TextBox textCgst;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.TextBox textSubDiscount;
        private System.Windows.Forms.TextBox textSgst;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.TextBox textSubTotal;
        private System.Windows.Forms.TextBox textGrandTotal;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dgvAddedProducts;
        private System.Windows.Forms.Label label21;
    }
}