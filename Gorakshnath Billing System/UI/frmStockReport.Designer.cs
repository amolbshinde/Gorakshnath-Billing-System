
namespace Gorakshnath_Billing_System.UI
{
    partial class frmStockReport
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
            this.comboGroup = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.comboProduct = new System.Windows.Forms.ComboBox();
            this.comboBrand = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvStockReport = new System.Windows.Forms.DataGridView();
            this.button6 = new System.Windows.Forms.Button();
            this.btnDate = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockReport)).BeginInit();
            this.SuspendLayout();
            // 
            // comboGroup
            // 
            this.comboGroup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboGroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboGroup.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboGroup.FormattingEnabled = true;
            this.comboGroup.Items.AddRange(new object[] {
            "Product_Group",
            "Product_Brand"});
            this.comboGroup.Location = new System.Drawing.Point(79, 35);
            this.comboGroup.Margin = new System.Windows.Forms.Padding(4);
            this.comboGroup.Name = "comboGroup";
            this.comboGroup.Size = new System.Drawing.Size(285, 29);
            this.comboGroup.TabIndex = 0;
            this.comboGroup.SelectedIndexChanged += new System.EventHandler(this.comboSearchBy_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.comboProduct);
            this.panel1.Controls.Add(this.comboBrand);
            this.panel1.Controls.Add(this.comboGroup);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1218, 102);
            this.panel1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(23, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 23);
            this.label4.TabIndex = 12;
            this.label4.Text = "Filter";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(679, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 23);
            this.label3.TabIndex = 11;
            this.label3.Text = "Product Wise";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(367, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 23);
            this.label2.TabIndex = 10;
            this.label2.Text = "Brand Wise";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(75, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 23);
            this.label1.TabIndex = 9;
            this.label1.Text = "Group Wise ";
            // 
            // button5
            // 
            this.button5.FlatAppearance.BorderSize = 2;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.SystemColors.WindowText;
            this.button5.Location = new System.Drawing.Point(998, 35);
            this.button5.Margin = new System.Windows.Forms.Padding(4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(145, 32);
            this.button5.TabIndex = 1;
            this.button5.Text = "Fetch All";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // comboProduct
            // 
            this.comboProduct.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboProduct.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboProduct.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboProduct.FormattingEnabled = true;
            this.comboProduct.Items.AddRange(new object[] {
            "Product_Group",
            "Product_Brand"});
            this.comboProduct.Location = new System.Drawing.Point(683, 35);
            this.comboProduct.Margin = new System.Windows.Forms.Padding(4);
            this.comboProduct.Name = "comboProduct";
            this.comboProduct.Size = new System.Drawing.Size(285, 29);
            this.comboProduct.TabIndex = 2;
            this.comboProduct.SelectedIndexChanged += new System.EventHandler(this.comboProduct_SelectedIndexChanged);
            // 
            // comboBrand
            // 
            this.comboBrand.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBrand.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBrand.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBrand.FormattingEnabled = true;
            this.comboBrand.Items.AddRange(new object[] {
            "Product_Group",
            "Product_Brand"});
            this.comboBrand.Location = new System.Drawing.Point(371, 35);
            this.comboBrand.Margin = new System.Windows.Forms.Padding(4);
            this.comboBrand.Name = "comboBrand";
            this.comboBrand.Size = new System.Drawing.Size(285, 29);
            this.comboBrand.TabIndex = 1;
            this.comboBrand.SelectedIndexChanged += new System.EventHandler(this.comboBrand_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvStockReport);
            this.panel2.Controls.Add(this.button6);
            this.panel2.Controls.Add(this.btnDate);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 102);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1218, 631);
            this.panel2.TabIndex = 3;
            // 
            // dgvStockReport
            // 
            this.dgvStockReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStockReport.Location = new System.Drawing.Point(13, 64);
            this.dgvStockReport.Margin = new System.Windows.Forms.Padding(4);
            this.dgvStockReport.Name = "dgvStockReport";
            this.dgvStockReport.RowHeadersWidth = 51;
            this.dgvStockReport.Size = new System.Drawing.Size(1126, 509);
            this.dgvStockReport.TabIndex = 0;
            // 
            // button6
            // 
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.Color.Teal;
            this.button6.Location = new System.Drawing.Point(1, 14);
            this.button6.Margin = new System.Windows.Forms.Padding(4);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(219, 31);
            this.button6.TabIndex = 9;
            this.button6.Text = "Stock available as on :";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // btnDate
            // 
            this.btnDate.FlatAppearance.BorderSize = 0;
            this.btnDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDate.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDate.ForeColor = System.Drawing.Color.Teal;
            this.btnDate.Location = new System.Drawing.Point(228, 14);
            this.btnDate.Margin = new System.Windows.Forms.Padding(4);
            this.btnDate.Name = "btnDate";
            this.btnDate.Size = new System.Drawing.Size(292, 31);
            this.btnDate.TabIndex = 8;
            this.btnDate.Text = "--";
            this.btnDate.UseVisualStyleBackColor = true;
            // 
            // frmStockReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1218, 733);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmStockReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stock Report";
            this.Load += new System.EventHandler(this.frmStockReport_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockReport)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboGroup;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvStockReport;
        private System.Windows.Forms.ComboBox comboProduct;
        private System.Windows.Forms.ComboBox comboBrand;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button btnDate;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}