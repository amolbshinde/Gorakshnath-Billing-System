
namespace Gorakshnath_Billing_System.UI
{
    partial class frmPurchaseCrpt
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
            this.CrptPurchaseViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // CrptPurchaseViewer
            // 
            this.CrptPurchaseViewer.ActiveViewIndex = -1;
            this.CrptPurchaseViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CrptPurchaseViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.CrptPurchaseViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CrptPurchaseViewer.Location = new System.Drawing.Point(0, 0);
            this.CrptPurchaseViewer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CrptPurchaseViewer.Name = "CrptPurchaseViewer";
            this.CrptPurchaseViewer.Size = new System.Drawing.Size(1373, 804);
            this.CrptPurchaseViewer.TabIndex = 0;
            this.CrptPurchaseViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // frmPurchaseCrpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1373, 804);
            this.Controls.Add(this.CrptPurchaseViewer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmPurchaseCrpt";
            this.Text = "Purchase Report";
            this.Load += new System.EventHandler(this.frmPurchaseCrpt_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer CrptPurchaseViewer;
    }
}