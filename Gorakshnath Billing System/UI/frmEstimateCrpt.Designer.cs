
namespace Gorakshnath_Billing_System.UI
{
    partial class frmEstimateCrpt
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
            this.crptEstimateViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crptEstimateViewer
            // 
            this.crptEstimateViewer.ActiveViewIndex = -1;
            this.crptEstimateViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crptEstimateViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.crptEstimateViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crptEstimateViewer.Location = new System.Drawing.Point(0, 0);
            this.crptEstimateViewer.Name = "crptEstimateViewer";
            this.crptEstimateViewer.Size = new System.Drawing.Size(1404, 764);
            this.crptEstimateViewer.TabIndex = 0;
            this.crptEstimateViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // frmEstimateCrpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1404, 764);
            this.Controls.Add(this.crptEstimateViewer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmEstimateCrpt";
            this.Text = "frmEstimateCrpt";
            this.Load += new System.EventHandler(this.frmEstimateCrpt_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crptEstimateViewer;
    }
}