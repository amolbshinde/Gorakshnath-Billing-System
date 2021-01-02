using CrystalDecisions.Shared;
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

namespace Gorakshnath_Billing_System.UI
{
    public partial class frmDummySalesCrpt : Form
    {
        int GetInvoice;
        public frmDummySalesCrpt(int InvoiceNo)
        {
            InitializeComponent();

            int i = 1;
            while (i == 1)
            {
                GetInvoice = InvoiceNo;
                i++;
            }

        }

        private void frmDummySalesCrpt_Load(object sender, EventArgs e)
        {
            Report_Generator.CrystalReport.crptNewInvoice newInvoice = new Report_Generator.CrystalReport.crptNewInvoice();
            crptNewInvoiceViewer.ReportSource = null;
            newInvoice.SetParameterValue("@Invoice_No", GetInvoice.ToString());
            crptNewInvoiceViewer.ReportSource = newInvoice;

            try
            {
                System.IO.DirectoryInfo di = new DirectoryInfo("E:\\Reports\\NewInvoice\\");

                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //exporting invoice
            try
            {

                ExportOptions CrExportOptions;
                DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
                PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();
                CrDiskFileDestinationOptions.DiskFileName = "E:\\Reports\\NewInvoice\\" + GetInvoice + ".pdf";
                CrExportOptions = newInvoice.ExportOptions;
                {
                    CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                    CrExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                    CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
                    CrExportOptions.FormatOptions = CrFormatTypeOptions;
                }
                newInvoice.Export();

                // sendMail();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured in export");
                MessageBox.Show(ex.ToString());
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                //sending email
                sendMail();

            }
            else
            {
                MessageBox.Show("Please enter valid email Address");//
            }
        }
        private void sendMail()
        {
            try
            {
                string fromAddress = "shivgorakshnathagrotechnology@gmail.com";
                String toAddress = textBox1.Text;
                string password = "shivtech@7178";
                MailMessage mail = new MailMessage();
                mail.Subject = "Shiv Gorakshnath Billing System :Invoice";
                mail.From = new MailAddress(fromAddress);
                mail.Body = "Hi Sir," + "\n\n" + "Please Find Attached Estimate" + "\n\n\n" + "Regards," + "\n" + "Ghiv Gorakshnath Traders " + "\n" + "Cell-8999150129";
                mail.To.Add(new MailAddress(toAddress));
                System.Net.Mail.Attachment at = new System.Net.Mail.Attachment("E:\\Reports\\NewInvoice\\" + GetInvoice + ".pdf");
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
