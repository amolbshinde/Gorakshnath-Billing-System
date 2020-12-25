
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
            this.btnSendMail = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // crptEstimateViewer
            // 
            this.crptEstimateViewer.ActiveViewIndex = -1;
            this.crptEstimateViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crptEstimateViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.crptEstimateViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crptEstimateViewer.Location = new System.Drawing.Point(0, 0);
            this.crptEstimateViewer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.crptEstimateViewer.Name = "crptEstimateViewer";
            this.crptEstimateViewer.Size = new System.Drawing.Size(1284, 750);
            this.crptEstimateViewer.TabIndex = 0;
            this.crptEstimateViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // btnSendMail
            // 
            this.btnSendMail.FlatAppearance.BorderSize = 2;
            this.btnSendMail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendMail.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendMail.ForeColor = System.Drawing.Color.BlueViolet;
            this.btnSendMail.Location = new System.Drawing.Point(804, 4);
            this.btnSendMail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSendMail.Name = "btnSendMail";
            this.btnSendMail.Size = new System.Drawing.Size(163, 39);
            this.btnSendMail.TabIndex = 40;
            this.btnSendMail.Text = "Send Mail";
            this.btnSendMail.UseVisualStyleBackColor = true;
            this.btnSendMail.Click += new System.EventHandler(this.btnSendMail_Click);
            // 
            // frmEstimateCrpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 750);
            this.Controls.Add(this.btnSendMail);
            this.Controls.Add(this.crptEstimateViewer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmEstimateCrpt";
            this.Text = "frmEstimateCrpt";
            this.Load += new System.EventHandler(this.frmEstimateCrpt_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crptEstimateViewer;
        private System.Windows.Forms.Button btnSendMail;
    }
}