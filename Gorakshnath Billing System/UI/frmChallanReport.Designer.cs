﻿
namespace Gorakshnath_Billing_System.UI
{
    partial class frmChallanReport
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
            this.dgvChallanReport = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.comboMobileNo = new System.Windows.Forms.ComboBox();
            this.comboCustName = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.comboInvoiceNo = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChallanReport)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvChallanReport
            // 
            this.dgvChallanReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChallanReport.Location = new System.Drawing.Point(9, 8);
            this.dgvChallanReport.Name = "dgvChallanReport";
            this.dgvChallanReport.Size = new System.Drawing.Size(1168, 465);
            this.dgvChallanReport.TabIndex = 0;
            this.dgvChallanReport.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvChallanReport_MouseClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.comboMobileNo);
            this.panel1.Controls.Add(this.comboCustName);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.comboInvoiceNo);
            this.panel1.Location = new System.Drawing.Point(13, 54);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1185, 121);
            this.panel1.TabIndex = 1;
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderSize = 2;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.Teal;
            this.button3.Location = new System.Drawing.Point(790, 43);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(154, 30);
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
            this.button2.Location = new System.Drawing.Point(379, 46);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(155, 30);
            this.button2.TabIndex = 11;
            this.button2.Text = "Customer Name";
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
            this.comboMobileNo.Location = new System.Drawing.Point(959, 43);
            this.comboMobileNo.Name = "comboMobileNo";
            this.comboMobileNo.Size = new System.Drawing.Size(186, 28);
            this.comboMobileNo.TabIndex = 12;
            this.comboMobileNo.SelectedIndexChanged += new System.EventHandler(this.comboMobileNo_SelectedIndexChanged);
            // 
            // comboCustName
            // 
            this.comboCustName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboCustName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboCustName.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboCustName.FormattingEnabled = true;
            this.comboCustName.Items.AddRange(new object[] {
            "Product_Group",
            "Product_Brand"});
            this.comboCustName.Location = new System.Drawing.Point(553, 45);
            this.comboCustName.Name = "comboCustName";
            this.comboCustName.Size = new System.Drawing.Size(198, 28);
            this.comboCustName.TabIndex = 10;
            this.comboCustName.SelectedIndexChanged += new System.EventHandler(this.comboCustName_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 2;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Teal;
            this.button1.Location = new System.Drawing.Point(13, 48);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 30);
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
            this.comboInvoiceNo.Location = new System.Drawing.Point(162, 48);
            this.comboInvoiceNo.Name = "comboInvoiceNo";
            this.comboInvoiceNo.Size = new System.Drawing.Size(173, 28);
            this.comboInvoiceNo.TabIndex = 8;
            this.comboInvoiceNo.SelectedIndexChanged += new System.EventHandler(this.comboInvoiceNo_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvChallanReport);
            this.panel2.Location = new System.Drawing.Point(12, 178);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1186, 488);
            this.panel2.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightSeaGreen;
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1260, 31);
            this.panel3.TabIndex = 17;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Gorakshnath_Billing_System.Properties.Resources._07_512;
            this.pictureBox1.Location = new System.Drawing.Point(1160, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(29, 28);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(499, 4);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "New Challan";
            // 
            // frmChallanReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1260, 756);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmChallanReport";
            this.Text = "frmChallanReport";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmChallanReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChallanReport)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvChallanReport;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboMobileNo;
        private System.Windows.Forms.ComboBox comboCustName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboInvoiceNo;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
    }
}