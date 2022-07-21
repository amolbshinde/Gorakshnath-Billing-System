
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
            this.btnSendMail = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // crptInvoiceViewer
            // 
            this.crptInvoiceViewer.ActiveViewIndex = -1;
            this.crptInvoiceViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crptInvoiceViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.crptInvoiceViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crptInvoiceViewer.Location = new System.Drawing.Point(0, 0);
            this.crptInvoiceViewer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.crptInvoiceViewer.Name = "crptInvoiceViewer";
            this.crptInvoiceViewer.Size = new System.Drawing.Size(1407, 750);
            this.crptInvoiceViewer.TabIndex = 0;
            this.crptInvoiceViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.crptInvoiceViewer.Load += new System.EventHandler(this.crptInvoiceViewer_Load);
            // 
            // btnSendMail
            // 
            this.btnSendMail.FlatAppearance.BorderSize = 2;
            this.btnSendMail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendMail.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendMail.ForeColor = System.Drawing.Color.BlueViolet;
            this.btnSendMail.Location = new System.Drawing.Point(1053, 7);
            this.btnSendMail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSendMail.Name = "btnSendMail";
            this.btnSendMail.Size = new System.Drawing.Size(107, 32);
            this.btnSendMail.TabIndex = 2;
            this.btnSendMail.Text = "Send Mail";
            this.btnSendMail.UseVisualStyleBackColor = true;
            this.btnSendMail.Click += new System.EventHandler(this.btnSendMail_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkViolet;
            this.label1.Location = new System.Drawing.Point(651, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Enter Email Id";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(785, 7);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(262, 30);
            this.textBox1.TabIndex = 1;
            // 
            // frmInvoiceCrpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1407, 750);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSendMail);
            this.Controls.Add(this.crptInvoiceViewer);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmInvoiceCrpt";
            this.Text = "frmInvoiceCrpt";
            this.Load += new System.EventHandler(this.frmInvoiceCrpt_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crptInvoiceViewer;
        private System.Windows.Forms.Button btnSendMail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
    }
}