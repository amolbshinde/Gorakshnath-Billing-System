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

        public void getChallanDetails()
        {

        }
          
        private void frmChallanManage_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(GetInvoice.ToString());
            textInvoiceNo.Text = GetInvoice.ToString();

            DataTable dtc = challanDAL.SelectByInvoiceNoManage(GetInvoice.ToString());
            comboSearchCust.Text = dtc.Rows[0][1].ToString();
            comboContact.Text= dtc.Rows[0][2].ToString();
            textEmail.Text = dtc.Rows[0][3].ToString();
            textAddress.Text = dtc.Rows[0][4].ToString();            
            comboTransactionType.Text= dtc.Rows[0][5].ToString();
            textSubTotal.Text= dtc.Rows[0][6].ToString();
            textSubDiscount.Text= dtc.Rows[0][9].ToString();
            textSgst.Text= dtc.Rows[0][8].ToString();
            textCgst.Text = dtc.Rows[0][9].ToString();
            textIgst.Text = dtc.Rows[0][10].ToString();
            textGrandTotal.Text = dtc.Rows[0][11].ToString();

            DataTable dtcd = challandetailsDAL.SelectByInvoiceNo(GetInvoice.ToString());
            dgvAddedProducts.DataSource = dtcd;
        }
    }
}
