﻿using System;
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
using System.Net;
using System.IO;

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

            try
            {
                {
                    System.IO.DirectoryInfo di = new DirectoryInfo("E:\\Reports\\Challan\\");

                    foreach (FileInfo file in di.GetFiles())
                    {
                        file.Delete();

                    }

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
                CrDiskFileDestinationOptions.DiskFileName = "E:\\Reports\\Challan\\" + GetInvoice + ".pdf";
                CrExportOptions = crptInvoice.ExportOptions;
                {
                    CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                    CrExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                    CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
                    CrExportOptions.FormatOptions = CrFormatTypeOptions;
                }
                crptInvoice.Export();

               // sendmail();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void crptInvoiceViewer_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnSendMail_Click(object sender, EventArgs e)
        {
            

            if (textBox1.Text != "")
            {

                sendmail();

            }
            else
            {
                MessageBox.Show("Please enter valid Email Address!!");
            }
        }

        private void sendmail()
        {
            try
            {
               string fromAddress = "shivgorakshnathtraders@gmail.com";
               String toAddress = textBox1.Text;
                string password = "Kishor@7178";
                MailMessage mail = new MailMessage();
                mail.Subject = "Shiv Gorakshnath Billing System :Invoice";
                mail.From = new MailAddress(fromAddress);
                mail.Body = "Hi Sir,"+"\n\n"+"Please Find Attached Invoice" + "\n\n\n" +"Regards," + "\n" + "Shiv Gorakshnath Traders" + "\n" +" Cell-8999150129";
                mail.To.Add(new MailAddress(toAddress));
                System.Net.Mail.Attachment at = new System.Net.Mail.Attachment("E:\\Reports\\Challan\\" + GetInvoice + ".pdf");
                mail.Attachments.Add(at);
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.EnableSsl = true;
                NetworkCredential nec = new NetworkCredential(fromAddress, password);
                smtp.Credentials = nec;
                smtp.Send(mail);
                MessageBox.Show("Mail Sent successfully .!!");
                return;
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }

    }
}
