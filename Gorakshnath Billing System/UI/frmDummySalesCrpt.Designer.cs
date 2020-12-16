
namespace Gorakshnath_Billing_System.UI
{
    partial class frmDummySalesCrpt
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
            this.crptNewInvoiceViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crptNewInvoiceViewer
            // 
            this.crptNewInvoiceViewer.ActiveViewIndex = -1;
            this.crptNewInvoiceViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crptNewInvoiceViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.crptNewInvoiceViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crptNewInvoiceViewer.Location = new System.Drawing.Point(0, 0);
            this.crptNewInvoiceViewer.Name = "crptNewInvoiceViewer";
            this.crptNewInvoiceViewer.Size = new System.Drawing.Size(983, 678);
            this.crptNewInvoiceViewer.TabIndex = 0;
            this.crptNewInvoiceViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // frmDummySalesCrpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(983, 678);
            this.Controls.Add(this.crptNewInvoiceViewer);
            this.Name = "frmDummySalesCrpt";
            this.Text = "frmDummySalesCrpt";
            this.Load += new System.EventHandler(this.frmDummySalesCrpt_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crptNewInvoiceViewer;
    }
}