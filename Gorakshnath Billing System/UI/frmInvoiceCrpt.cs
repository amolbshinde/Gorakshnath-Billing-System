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

namespace Gorakshnath_Billing_System.UI
{
    public partial class frmInvoiceCrpt : Form
    {
        ReportDocument cryRpt;

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
            //MessageBox.Show(GetInvoice.ToString());
            Report_Generator.CrystalReport.crptInvoice crptInvoice = new Report_Generator.CrystalReport.crptInvoice();
            crptInvoiceViewer.ReportSource = null;
            crptInvoice.SetParameterValue("@Invoice_No", GetInvoice.ToString());
            crptInvoiceViewer.ReportSource = crptInvoice;
            /*
            cryRpt = new ReportDocument();
            cryRpt.Load("C:\\Users\\sopan\\Documents\\CrystalReport1.rpt");
            crptInvoiceViewer.ReportSource = cryRpt;
            crptInvoiceViewer.Refresh();
            */
            

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
                cryRpt = new ReportDocument();
                //cryRpt.Load(".\\crptInvoice.rpt");
                cryRpt.Load("C:\\Users\\sopan\\source\\repos\\amolbshinde\\Gorakshnath-Billing-System\\Gorakshnath Billing System\\Report_Generator\\CrystalReport\\crptInvoice.rpt");


                crptInvoiceViewer.ReportSource = cryRpt;
                crptInvoiceViewer.Refresh();


                ExportOptions CrExportOptions;
                DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
                PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();
                CrDiskFileDestinationOptions.DiskFileName = "C:\\SampleReport.pdf";
                CrExportOptions = cryRpt.ExportOptions;
                {
                    CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                    CrExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                    CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
                    CrExportOptions.FormatOptions = CrFormatTypeOptions;
                }
                cryRpt.Export();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }

        //for storing crestal report






    }
}
