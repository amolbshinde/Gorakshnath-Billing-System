﻿
namespace Gorakshnath_Billing_System.UI
{
    partial class frmPurchaseReturnReport
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvPurchaseReturnReport = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.comboMobileNo = new System.Windows.Forms.ComboBox();
            this.comboSupName = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.comboInvoiceNo = new System.Windows.Forms.ComboBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchaseReturnReport)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvPurchaseReturnReport);
            this.panel2.Location = new System.Drawing.Point(62, 146);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1009, 449);
            this.panel2.TabIndex = 22;
            // 
            // dgvPurchaseReturnReport
            // 
            this.dgvPurchaseReturnReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPurchaseReturnReport.Location = new System.Drawing.Point(9, 8);
            this.dgvPurchaseReturnReport.Name = "dgvPurchaseReturnReport";
            this.dgvPurchaseReturnReport.RowHeadersWidth = 51;
            this.dgvPurchaseReturnReport.Size = new System.Drawing.Size(982, 428);
            this.dgvPurchaseReturnReport.TabIndex = 0;
            this.dgvPurchaseReturnReport.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvPurchaseReturnReport_MouseClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.comboMobileNo);
            this.panel1.Controls.Add(this.comboSupName);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.comboInvoiceNo);
            this.panel1.Location = new System.Drawing.Point(63, 22);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1008, 121);
            this.panel1.TabIndex = 21;
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderSize = 2;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.Teal;
            this.button3.Location = new System.Drawing.Point(679, 43);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(127, 30);
            this.button3.TabIndex = 13;
            this.button3.Text = "Mobile No";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 2;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Teal;
            this.button2.Location = new System.Drawing.Point(321, 46);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(128, 30);
            this.button2.TabIndex = 11;
            this.button2.Text = "Supplier Name";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // comboMobileNo
            // 
            this.comboMobileNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboMobileNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboMobileNo.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboMobileNo.FormattingEnabled = true;
            this.comboMobileNo.Items.AddRange(new object[] {
            "Product_Group",
            "Product_Brand"});
            this.comboMobileNo.Location = new System.Drawing.Point(831, 43);
            this.comboMobileNo.Name = "comboMobileNo";
            this.comboMobileNo.Size = new System.Drawing.Size(159, 28);
            this.comboMobileNo.TabIndex = 12;
            this.comboMobileNo.SelectedIndexChanged += new System.EventHandler(this.comboMobileNo_SelectedIndexChanged);
            // 
            // comboSupName
            // 
            this.comboSupName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboSupName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboSupName.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboSupName.FormattingEnabled = true;
            this.comboSupName.Items.AddRange(new object[] {
            "Product_Group",
            "Product_Brand"});
            this.comboSupName.Location = new System.Drawing.Point(467, 45);
            this.comboSupName.Name = "comboSupName";
            this.comboSupName.Size = new System.Drawing.Size(171, 28);
            this.comboSupName.TabIndex = 10;
            this.comboSupName.SelectedIndexChanged += new System.EventHandler(this.comboSupName_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 2;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Teal;
            this.button1.Location = new System.Drawing.Point(13, 48);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 30);
            this.button1.TabIndex = 9;
            this.button1.Text = "Invoice No";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // comboInvoiceNo
            // 
            this.comboInvoiceNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboInvoiceNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboInvoiceNo.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboInvoiceNo.FormattingEnabled = true;
            this.comboInvoiceNo.Items.AddRange(new object[] {
            "Product_Group",
            "Product_Brand"});
            this.comboInvoiceNo.Location = new System.Drawing.Point(134, 48);
            this.comboInvoiceNo.Name = "comboInvoiceNo";
            this.comboInvoiceNo.Size = new System.Drawing.Size(146, 28);
            this.comboInvoiceNo.TabIndex = 8;
            this.comboInvoiceNo.SelectedIndexChanged += new System.EventHandler(this.comboInvoiceNo_SelectedIndexChanged);
            // 
            // frmPurchaseReturnReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1133, 616);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmPurchaseReturnReport";
            this.Text = "Purchase Return Report";
            this.Load += new System.EventHandler(this.frmPurchaseReturnReport_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchaseReturnReport)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvPurchaseReturnReport;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboMobileNo;
        private System.Windows.Forms.ComboBox comboSupName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboInvoiceNo;
    }
}