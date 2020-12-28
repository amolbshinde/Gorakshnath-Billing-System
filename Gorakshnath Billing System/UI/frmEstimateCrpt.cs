using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace Gorakshnath_Billing_System.UI
{
    public partial class frmEstimateCrpt : Form
    {
        
        Report_Generator.CrystalReport.crptEstimate crptEstimate = new Report_Generator.CrystalReport.crptEstimate();

        int GetInvoice;
        public frmEstimateCrpt(int InvoiceNo)
        {
            InitializeComponent();
            int i = 1;
            while (i == 1)
            {
                GetInvoice = InvoiceNo;
                i++;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void frmEstimateCrpt_Load(object sender, EventArgs e)
        {
            Report_Generator.CrystalReport.crptEstimate Estimate = new Report_Generator.CrystalReport.crptEstimate();
            crptEstimateViewer.ReportSource = null;
            Estimate.SetParameterValue("@Invoice_No", GetInvoice.ToString());
            crptEstimateViewer.ReportSource = Estimate;
            //btnSendMail.Enabled = false;
        }

        private void btnSendMail_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                System.IO.DirectoryInfo di = new DirectoryInfo("E:\\Estimate\\");

                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }


                try
                {

                    ExportOptions CrExportOptions;
                    DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
                    PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();
                    CrDiskFileDestinationOptions.DiskFileName = "E:\\Estimate\\" + GetInvoice + ".pdf";
                    CrExportOptions = crptEstimate.ExportOptions;
                    {
                        CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                        CrExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                        CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
                        CrExportOptions.FormatOptions = CrFormatTypeOptions;
                    }
                    crptEstimate.Export();

                    sendMail();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Occured in export");
                    MessageBox.Show(ex.ToString());
                }


            }else
            {
                MessageBox.Show("Please enter valid email Address");
            }
                        
        }
        private void sendMail()
        {
            try
            {
                string fromAddress = "amols693@gmail.com";
                String toAddress = textBox1.Text;
                string password = "Sambhaji$0346";
                MailMessage mail = new MailMessage();
                mail.Subject = "Ghiv Gorakshnath Billing System Invoice";
                mail.From = new MailAddress(fromAddress);
                mail.Body = "Hi Sir," + "\n\n" + "Please Find Attached Estimate" + "\n\n\n" + "Regards," + "\n" + "Ghiv Gorakshnath Traders " + "\n" + "Cell-8999150129";
                mail.To.Add(new MailAddress(toAddress));
                System.Net.Mail.Attachment at = new System.Net.Mail.Attachment("E:\\Estimate\\" + GetInvoice + ".pdf");
                mail.Attachments.Add(at);
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.EnableSsl = true;
                NetworkCredential nec = new NetworkCredential(fromAddress, password);
                smtp.Credentials = nec;
                smtp.Send(mail);
                MessageBox.Show("Sucesfully Sent");
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured while sending");
                MessageBox.Show(ex.ToString());
            }

        }
    }
}
