
namespace Gorakshnath_Billing_System.UI
{
    partial class Debtors_and_Creditors
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboInvoiceNo = new System.Windows.Forms.ComboBox();
            this.comboPhoneNo = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textPaymentId = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textPayMode = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textTrDate = new System.Windows.Forms.TextBox();
            this.textRemarks = new System.Windows.Forms.TextBox();
            this.textBalance = new System.Windows.Forms.TextBox();
            this.textAmountRecieved = new System.Windows.Forms.TextBox();
            this.textTrAmount = new System.Windows.Forms.TextBox();
            this.textCustomerName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvDebtorNCreditors = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.comboDrCrType = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDebtorNCreditors)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.MenuText;
            this.label1.Location = new System.Drawing.Point(215, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Invoice No : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.MenuText;
            this.label2.Location = new System.Drawing.Point(446, 66);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Amount Recieved ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.MenuText;
            this.label3.Location = new System.Drawing.Point(446, 8);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "Transaction Amount";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.MenuText;
            this.label4.Location = new System.Drawing.Point(17, 73);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 21);
            this.label4.TabIndex = 3;
            this.label4.Text = "Party Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.MenuText;
            this.label5.Location = new System.Drawing.Point(646, 68);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 21);
            this.label5.TabIndex = 4;
            this.label5.Text = "Balance";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.comboInvoiceNo);
            this.panel1.Controls.Add(this.comboPhoneNo);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.textPaymentId);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textPayMode);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.textTrDate);
            this.panel1.Controls.Add(this.textRemarks);
            this.panel1.Controls.Add(this.textBalance);
            this.panel1.Controls.Add(this.textAmountRecieved);
            this.panel1.Controls.Add(this.textTrAmount);
            this.panel1.Controls.Add(this.textCustomerName);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(9, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1099, 143);
            this.panel1.TabIndex = 5;
            // 
            // comboInvoiceNo
            // 
            this.comboInvoiceNo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboInvoiceNo.FormattingEnabled = true;
            this.comboInvoiceNo.Location = new System.Drawing.Point(219, 39);
            this.comboInvoiceNo.Name = "comboInvoiceNo";
            this.comboInvoiceNo.Size = new System.Drawing.Size(175, 23);
            this.comboInvoiceNo.TabIndex = 23;
            this.comboInvoiceNo.SelectedIndexChanged += new System.EventHandler(this.comboInvoiceNo_SelectedIndexChanged);
            // 
            // comboPhoneNo
            // 
            this.comboPhoneNo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboPhoneNo.FormattingEnabled = true;
            this.comboPhoneNo.Location = new System.Drawing.Point(219, 99);
            this.comboPhoneNo.Name = "comboPhoneNo";
            this.comboPhoneNo.Size = new System.Drawing.Size(175, 23);
            this.comboPhoneNo.TabIndex = 22;
            this.comboPhoneNo.SelectedIndexChanged += new System.EventHandler(this.comboPhoneNo_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.MenuText;
            this.label10.Location = new System.Drawing.Point(215, 73);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 21);
            this.label10.TabIndex = 21;
            this.label10.Text = "Phone No";
            // 
            // textPaymentId
            // 
            this.textPaymentId.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textPaymentId.Location = new System.Drawing.Point(20, 40);
            this.textPaymentId.Margin = new System.Windows.Forms.Padding(2);
            this.textPaymentId.Name = "textPaymentId";
            this.textPaymentId.ReadOnly = true;
            this.textPaymentId.Size = new System.Drawing.Size(176, 23);
            this.textPaymentId.TabIndex = 20;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.MenuText;
            this.label11.Location = new System.Drawing.Point(20, 12);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(98, 21);
            this.label11.TabIndex = 19;
            this.label11.Text = "Payment Id : ";
            // 
            // textPayMode
            // 
            this.textPayMode.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textPayMode.Location = new System.Drawing.Point(643, 30);
            this.textPayMode.Margin = new System.Windows.Forms.Padding(2);
            this.textPayMode.Name = "textPayMode";
            this.textPayMode.ReadOnly = true;
            this.textPayMode.Size = new System.Drawing.Size(138, 23);
            this.textPayMode.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.MenuText;
            this.label9.Location = new System.Drawing.Point(639, 9);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(114, 21);
            this.label9.TabIndex = 14;
            this.label9.Text = "Payment Mode";
            // 
            // textTrDate
            // 
            this.textTrDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textTrDate.Location = new System.Drawing.Point(825, 30);
            this.textTrDate.Margin = new System.Windows.Forms.Padding(2);
            this.textTrDate.Name = "textTrDate";
            this.textTrDate.ReadOnly = true;
            this.textTrDate.Size = new System.Drawing.Size(221, 23);
            this.textTrDate.TabIndex = 13;
            // 
            // textRemarks
            // 
            this.textRemarks.Location = new System.Drawing.Point(829, 77);
            this.textRemarks.Margin = new System.Windows.Forms.Padding(2);
            this.textRemarks.Multiline = true;
            this.textRemarks.Name = "textRemarks";
            this.textRemarks.Size = new System.Drawing.Size(217, 54);
            this.textRemarks.TabIndex = 12;
            // 
            // textBalance
            // 
            this.textBalance.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBalance.Location = new System.Drawing.Point(643, 94);
            this.textBalance.Margin = new System.Windows.Forms.Padding(2);
            this.textBalance.Name = "textBalance";
            this.textBalance.ReadOnly = true;
            this.textBalance.Size = new System.Drawing.Size(138, 23);
            this.textBalance.TabIndex = 11;
            // 
            // textAmountRecieved
            // 
            this.textAmountRecieved.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textAmountRecieved.Location = new System.Drawing.Point(450, 94);
            this.textAmountRecieved.Margin = new System.Windows.Forms.Padding(2);
            this.textAmountRecieved.Name = "textAmountRecieved";
            this.textAmountRecieved.Size = new System.Drawing.Size(176, 23);
            this.textAmountRecieved.TabIndex = 10;
            this.textAmountRecieved.TextChanged += new System.EventHandler(this.textAmountRecieved_TextChanged);
            // 
            // textTrAmount
            // 
            this.textTrAmount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textTrAmount.Location = new System.Drawing.Point(450, 30);
            this.textTrAmount.Margin = new System.Windows.Forms.Padding(2);
            this.textTrAmount.Name = "textTrAmount";
            this.textTrAmount.ReadOnly = true;
            this.textTrAmount.Size = new System.Drawing.Size(145, 23);
            this.textTrAmount.TabIndex = 9;
            // 
            // textCustomerName
            // 
            this.textCustomerName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textCustomerName.Location = new System.Drawing.Point(20, 98);
            this.textCustomerName.Margin = new System.Windows.Forms.Padding(2);
            this.textCustomerName.Name = "textCustomerName";
            this.textCustomerName.ReadOnly = true;
            this.textCustomerName.Size = new System.Drawing.Size(176, 23);
            this.textCustomerName.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.MenuText;
            this.label7.Location = new System.Drawing.Point(833, 49);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 21);
            this.label7.TabIndex = 6;
            this.label7.Text = "Remarks";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.MenuText;
            this.label6.Location = new System.Drawing.Point(825, 7);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 21);
            this.label6.TabIndex = 5;
            this.label6.Text = "Transaction Date";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvDebtorNCreditors);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Location = new System.Drawing.Point(9, 206);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1099, 397);
            this.panel2.TabIndex = 6;
            // 
            // dgvDebtorNCreditors
            // 
            this.dgvDebtorNCreditors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDebtorNCreditors.Location = new System.Drawing.Point(5, 23);
            this.dgvDebtorNCreditors.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDebtorNCreditors.Name = "dgvDebtorNCreditors";
            this.dgvDebtorNCreditors.RowHeadersWidth = 51;
            this.dgvDebtorNCreditors.RowTemplate.Height = 24;
            this.dgvDebtorNCreditors.Size = new System.Drawing.Size(1047, 352);
            this.dgvDebtorNCreditors.TabIndex = 15;
            this.dgvDebtorNCreditors.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvDebtorNCreditors_RowHeaderMouseClick);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(6, 0);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(208, 20);
            this.label8.TabIndex = 14;
            this.label8.Text = "Update Debtors and Creditors";
            // 
            // btnUpdate
            // 
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(317, 25);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(2);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(80, 27);
            this.btnUpdate.TabIndex = 7;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(439, 25);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(80, 27);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(552, 25);
            this.btnClear.Margin = new System.Windows.Forms.Padding(2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(80, 27);
            this.btnClear.TabIndex = 9;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(672, 25);
            this.btnExit.Margin = new System.Windows.Forms.Padding(2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(80, 27);
            this.btnExit.TabIndex = 10;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.button4_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.comboDrCrType);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Location = new System.Drawing.Point(9, 151);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1099, 46);
            this.panel3.TabIndex = 11;
            // 
            // comboDrCrType
            // 
            this.comboDrCrType.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboDrCrType.FormattingEnabled = true;
            this.comboDrCrType.Items.AddRange(new object[] {
            "All",
            "Debtors",
            "Creditors"});
            this.comboDrCrType.Location = new System.Drawing.Point(505, 12);
            this.comboDrCrType.Name = "comboDrCrType";
            this.comboDrCrType.Size = new System.Drawing.Size(175, 23);
            this.comboDrCrType.TabIndex = 25;
            this.comboDrCrType.SelectedIndexChanged += new System.EventHandler(this.comboDrCrType_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.MenuText;
            this.label12.Location = new System.Drawing.Point(321, 10);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(178, 21);
            this.label12.TabIndex = 24;
            this.label12.Text = "Show Debtors/Creditors";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnExit);
            this.panel4.Controls.Add(this.btnUpdate);
            this.panel4.Controls.Add(this.btnDelete);
            this.panel4.Controls.Add(this.btnClear);
            this.panel4.Location = new System.Drawing.Point(10, 606);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1098, 81);
            this.panel4.TabIndex = 12;
            // 
            // Debtors_and_Creditors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1181, 709);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Debtors_and_Creditors";
            this.Text = "Debtors_and_Creditors";
            this.Load += new System.EventHandler(this.Debtors_and_Creditors_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDebtorNCreditors)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textTrDate;
        private System.Windows.Forms.TextBox textRemarks;
        private System.Windows.Forms.TextBox textBalance;
        private System.Windows.Forms.TextBox textAmountRecieved;
        private System.Windows.Forms.TextBox textTrAmount;
        private System.Windows.Forms.TextBox textCustomerName;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvDebtorNCreditors;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TextBox textPayMode;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textPaymentId;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboInvoiceNo;
        private System.Windows.Forms.ComboBox comboPhoneNo;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox comboDrCrType;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel4;
    }
}