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
    public partial class frmEstimateCrpt : Form
    {
        ReportDocument cryRpt;

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
        }

        private void btnSendMail_Click(object sender, EventArgs e)
        {


            try
            {
                cryRpt = new ReportDocument();
                //cryRpt.Load(".\\crptEstimate.rpt");
                cryRpt.Load("C:\\Users\\sopan\\source\\repos\\amolbshinde\\Gorakshnath-Billing-System\\Gorakshnath Billing System\\Report_Generator\\CrystalReport\\crptEstimate.rpt");


                crptEstimateViewer.ReportSource = cryRpt;
                crptEstimateViewer.Refresh();

                ExportOptions CrExportOptions;
                DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
                PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();
                CrDiskFileDestinationOptions.DiskFileName = "E:\\EstimateSampleReport.pdf";
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
    }
}
