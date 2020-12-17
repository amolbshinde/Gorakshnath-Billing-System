using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Net.Mail;


namespace Gorakshnath_Billing_System.UI
{
    public partial class frmInvoiceCrpt : Form
    {        
        Report_Generator.CrystalReport.crptInvoice crptInvoice = new Report_Generator.CrystalReport.crptInvoice();

        int GetInvoice;
        

        public frmInvoiceCrpt(int InvoiceNo)
        {
            InitializeComponent();
            int i = 1;
            while(i==1)
            {
                 GetInvoice = InvoiceNo;
                i++;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmInvoiceCrpt_Load(object sender, EventArgs e)
        {            
            crptInvoiceViewer.ReportSource = null;
            crptInvoice.SetParameterValue("@Invoice_No", GetInvoice.ToString());
            crptInvoiceViewer.ReportSource = crptInvoice;   
        }

        private void crptInvoiceViewer_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnSendMail_Click(object sender, EventArgs e)
        {

            try
            {                

                ExportOptions CrExportOptions;
                DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
                PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();
                CrDiskFileDestinationOptions.DiskFileName = "E:\\"+ GetInvoice + ".pdf";                
                CrExportOptions = crptInvoice.ExportOptions;
                {
                    CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                    CrExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                    CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
                    CrExportOptions.FormatOptions = CrFormatTypeOptions;
                }
                crptInvoice.Export();

                sendmail();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }

        private void sendmail()
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("sopanpit@gmail.com");
                mail.To.Add("amols693@gmail.com");
                mail.Subject = "Test Mail";
                mail.Body = "This is for testing SMTP mail from GMAIL";

                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment("E:\\" + GetInvoice + ".pdf");
                mail.Attachments.Add(attachment);

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("sopanpit@gmail.com", "Pooja@123");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                MessageBox.Show("mail Send");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }


    }
}
