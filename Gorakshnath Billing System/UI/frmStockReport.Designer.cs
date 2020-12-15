
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
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.comboProduct = new System.Windows.Forms.ComboBox();
            this.comboBrand = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvStockReport = new System.Windows.Forms.DataGridView();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.btnDate = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockReport)).BeginInit();
            this.SuspendLayout();
            // 
            // comboGroup
            // 
            this.comboGroup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboGroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboGroup.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboGroup.FormattingEnabled = true;
            this.comboGroup.Items.AddRange(new object[] {
            "Product_Group",
            "Product_Brand"});
            this.comboGroup.Location = new System.Drawing.Point(102, 22);
            this.comboGroup.Name = "comboGroup";
            this.comboGroup.Size = new System.Drawing.Size(173, 28);
            this.comboGroup.TabIndex = 0;
            this.comboGroup.SelectedIndexChanged += new System.EventHandler(this.comboSearchBy_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.comboProduct);
            this.panel1.Controls.Add(this.comboBrand);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.comboGroup);
            this.panel1.Location = new System.Drawing.Point(2, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1248, 72);
            this.panel1.TabIndex = 3;
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderSize = 2;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.Teal;
            this.button3.Location = new System.Drawing.Point(635, 17);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(81, 30);
            this.button3.TabIndex = 7;
            this.button3.Text = "Product Name";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 2;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Teal;
            this.button2.Location = new System.Drawing.Point(304, 20);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(78, 30);
            this.button2.TabIndex = 5;
            this.button2.Text = "Brand";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // comboProduct
            // 
            this.comboProduct.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboProduct.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboProduct.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboProduct.FormattingEnabled = true;
            this.comboProduct.Items.AddRange(new object[] {
            "Product_Group",
            "Product_Brand"});
            this.comboProduct.Location = new System.Drawing.Point(738, 17);
            this.comboProduct.Name = "comboProduct";
            this.comboProduct.Size = new System.Drawing.Size(186, 28);
            this.comboProduct.TabIndex = 6;
            this.comboProduct.SelectedIndexChanged += new System.EventHandler(this.comboProduct_SelectedIndexChanged);
            // 
            // comboBrand
            // 
            this.comboBrand.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBrand.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBrand.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBrand.FormattingEnabled = true;
            this.comboBrand.Items.AddRange(new object[] {
            "Product_Group",
            "Product_Brand"});
            this.comboBrand.Location = new System.Drawing.Point(405, 19);
            this.comboBrand.Name = "comboBrand";
            this.comboBrand.Size = new System.Drawing.Size(198, 28);
            this.comboBrand.TabIndex = 4;
            this.comboBrand.SelectedIndexChanged += new System.EventHandler(this.comboBrand_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 2;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Teal;
            this.button1.Location = new System.Drawing.Point(16, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(68, 30);
            this.button1.TabIndex = 3;
            this.button1.Text = "Group";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvStockReport);
            this.panel2.Location = new System.Drawing.Point(2, 117);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1061, 386);
            this.panel2.TabIndex = 4;
            // 
            // dgvStockReport
            // 
            this.dgvStockReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStockReport.Location = new System.Drawing.Point(16, 13);
            this.dgvStockReport.Name = "dgvStockReport";
            this.dgvStockReport.RowHeadersWidth = 51;
            this.dgvStockReport.Size = new System.Drawing.Size(1023, 362);
            this.dgvStockReport.TabIndex = 0;
            // 
            // button4
            // 
            this.button4.FlatAppearance.BorderSize = 2;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.Teal;
            this.button4.Location = new System.Drawing.Point(872, 80);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(93, 30);
            this.button4.TabIndex = 5;
            this.button4.Text = "Search";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.FlatAppearance.BorderSize = 2;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.Teal;
            this.button5.Location = new System.Drawing.Point(970, 80);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(93, 30);
            this.button5.TabIndex = 6;
            this.button5.Text = "Reset";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // btnDate
            // 
            this.btnDate.FlatAppearance.BorderSize = 0;
            this.btnDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDate.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDate.ForeColor = System.Drawing.Color.Teal;
            this.btnDate.Location = new System.Drawing.Point(188, 80);
            this.btnDate.Name = "btnDate";
            this.btnDate.Size = new System.Drawing.Size(219, 30);
            this.btnDate.TabIndex = 8;
            this.btnDate.Text = "btn";
            this.btnDate.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.FlatAppearance.BorderSize = 2;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.Color.Teal;
            this.button6.Location = new System.Drawing.Point(18, 80);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(164, 30);
            this.button6.TabIndex = 9;
            this.button6.Text = "Stock available as on :";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // frmStockReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1150, 563);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.btnDate);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmStockReport";
            this.Text = "Stock Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmStockReport_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockReport)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboGroup;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvStockReport;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboProduct;
        private System.Windows.Forms.ComboBox comboBrand;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button btnDate;
        private System.Windows.Forms.Button button6;
    }
}