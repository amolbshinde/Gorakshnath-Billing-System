using Gorakshnath_Billing_System.BLL;
using Gorakshnath_Billing_System.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gorakshnath_Billing_System.UI
{
    public partial class frmChallanManage : Form
    {
        int GetInvoice;
        public frmChallanManage(int InvoiceNo)
        {
            InitializeComponent();
            int i = 1;
            while (i == 1)
            {
                GetInvoice = InvoiceNo;
                i++;
            }
        }

        customerBLL customerBLL = new customerBLL();
        customerDAL customerDAL = new customerDAL();

        ProductMasterDAL ProductMasterDAL = new ProductMasterDAL();

        challanBLL challanBLL = new challanBLL();

        challanDAL challanDAL = new challanDAL();

        challandetailsDAL challandetailsDAL = new challandetailsDAL();

        stockDAL stockDAL = new stockDAL();

        DataTable salesDT = new DataTable();

        private void frmChallanManage_Load(object sender, EventArgs e)
        {
            MessageBox.Show(GetInvoice.ToString());
        }
    }
}
