
namespace Gorakshnath_Billing_System.UI
{
    partial class frmInvoiceCrpt
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
            this.crptInvoiceViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crptInvoiceViewer
            // 
            this.crptInvoiceViewer.ActiveViewIndex = -1;
            this.crptInvoiceViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crptInvoiceViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.crptInvoiceViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crptInvoiceViewer.Location = new System.Drawing.Point(0, 0);
            this.crptInvoiceViewer.Name = "crptInvoiceViewer";
            this.crptInvoiceViewer.Size = new System.Drawing.Size(1467, 781);
            this.crptInvoiceViewer.TabIndex = 0;
            this.crptInvoiceViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // frmInvoiceCrpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1467, 781);
            this.Controls.Add(this.crptInvoiceViewer);
            this.Name = "frmInvoiceCrpt";
            this.Text = "frmInvoiceCrpt";
            this.Load += new System.EventHandler(this.frmInvoiceCrpt_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crptInvoiceViewer;
    }
}