
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvChallanReport)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvChallanReport
            // 
            this.dgvChallanReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChallanReport.Location = new System.Drawing.Point(12, 166);
            this.dgvChallanReport.Name = "dgvChallanReport";
            this.dgvChallanReport.Size = new System.Drawing.Size(1185, 411);
            this.dgvChallanReport.TabIndex = 0;
            // 
            // frmChallanReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1245, 663);
            this.Controls.Add(this.dgvChallanReport);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmChallanReport";
            this.Text = "frmChallanReport";
            this.Load += new System.EventHandler(this.frmChallanReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChallanReport)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvChallanReport;
    }
}