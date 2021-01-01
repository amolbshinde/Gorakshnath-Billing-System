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
    public partial class frmPurchaseCrpt : Form
    {
        int GetPurchaseID;
        Report_Generator.CrystalReport.crptPurchase crptPurchase = new Report_Generator.CrystalReport.crptPurchase();
        public frmPurchaseCrpt(int PurchaseID)
        {
            InitializeComponent();

            int i = 1;
            while (i == 1)
            {
                GetPurchaseID = PurchaseID;
                i++;
            }
        }

        private void frmPurchaseCrpt_Load(object sender, EventArgs e)
        {
            //Report_Generator.CrystalReport.crptPurchase crptPurchase = new Report_Generator.CrystalReport.crptPurchase();
            CrptPurchaseViewer.ReportSource = null;
            MessageBox.Show(GetPurchaseID.ToString());
            crptPurchase.SetParameterValue("@Purchase_ID", GetPurchaseID.ToString());
            CrptPurchaseViewer.ReportSource = crptPurchase;
            try
            {
                System.IO.DirectoryInfo di = new DirectoryInfo("E:\\Reports\\Purchase\\");

                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {

                ExportOptions CrExportOptions;
                DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
                PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();
                CrDiskFileDestinationOptions.DiskFileName = "E:\\Reports\\Purchase\\" + GetPurchaseID + ".pdf";
                CrExportOptions = crptPurchase.ExportOptions;
                {
                    CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                    CrExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                    CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
                    CrExportOptions.FormatOptions = CrFormatTypeOptions;
                }
                crptPurchase.Export();

                //sendMail();
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
                
                //calling send mail 
                sendMail();


            }
            else
            {
                MessageBox.Show("Please enter valid email Address");
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
                mail.Subject = "Shiv Gorakshnath Traders Purchase Bill";
                mail.From = new MailAddress(fromAddress);
                mail.Body = "Hi Sir," + "\n\n" + "Please Find Attached Estimate" + "\n\n\n" + "Regards," + "\n" + "Ghiv Gorakshnath Traders " + "\n" + "Cell-8999150129";
                mail.To.Add(new MailAddress(toAddress));
                System.Net.Mail.Attachment at = new System.Net.Mail.Attachment("E:\\Reports\\Purchase\\" + GetPurchaseID + ".pdf");
                mail.Attachments.Add(at);
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.EnableSsl = true;
                NetworkCredential nec = new NetworkCredential(fromAddress, password);
                smtp.Credentials = nec;
                smtp.Send(mail);
                MessageBox.Show("Mail Sent Succesfully..!!");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured while sending");
                MessageBox.Show(ex.ToString());
            }

        }


    }
}
