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
    public partial class frmDebtors_Creditors_Purchase : Form
    {
        public frmDebtors_Creditors_Purchase()
        {
            InitializeComponent();
            fillCombo();
        }

        PurchasePaymentDetailsBLL PurchasePaymentDetailsBLL = new PurchasePaymentDetailsBLL();
        PurchasePaymentDetailsDAL PurchasePaymentDetailsDAL = new PurchasePaymentDetailsDAL();

        public void fillCombo()
        {
            comboInvoiceNo.DataSource = null;
            DataTable dtC = PurchasePaymentDetailsDAL.Select();
            comboInvoiceNo.DisplayMember = "Invoice_No";
            comboInvoiceNo.DataSource = dtC;
            comboInvoiceNo.Text = "Select Invoice";

            comboPhoneNo.DataSource = null;
            DataTable dtP = PurchasePaymentDetailsDAL.Select();
            comboPhoneNo.DisplayMember = "Phone_No";
            //comboSearchCust.ValueMember = "Column123";
            comboPhoneNo.DataSource = dtP;
            comboPhoneNo.Text = "Select Phone";

        }

        private void frmDebtors_Creditors_Purchase_Load(object sender, EventArgs e)
        {
            Clear();
        }

        private void dgvDebtorNCreditors_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            textPaymentId.Text = dgvDebtorNCreditors.Rows[rowIndex].Cells[0].Value.ToString();
            comboInvoiceNo.Text = dgvDebtorNCreditors.Rows[rowIndex].Cells[1].Value.ToString();
            textCustomerName.Text = dgvDebtorNCreditors.Rows[rowIndex].Cells[2].Value.ToString();
            textPayMode.Text = dgvDebtorNCreditors.Rows[rowIndex].Cells[3].Value.ToString();
            textTrAmount.Text = dgvDebtorNCreditors.Rows[rowIndex].Cells[5].Value.ToString();
            textAmountRecieved.Text = dgvDebtorNCreditors.Rows[rowIndex].Cells[6].Value.ToString();
            textBalance.Text = dgvDebtorNCreditors.Rows[rowIndex].Cells[7].Value.ToString();
            textRemarks.Text = dgvDebtorNCreditors.Rows[rowIndex].Cells[8].Value.ToString();
            textTrDate.Text = dgvDebtorNCreditors.Rows[rowIndex].Cells[9].Value.ToString();
            comboPhoneNo.Text = dgvDebtorNCreditors.Rows[rowIndex].Cells[10].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string PaymentId = textPaymentId.Text;
            if (PaymentId != "")
            {
                PurchasePaymentDetailsBLL.PaymentId = Convert.ToInt32(PaymentId);
                PurchasePaymentDetailsBLL.Invoice_No = Convert.ToInt32(comboInvoiceNo.Text);
                PurchasePaymentDetailsBLL.PaymentMode = textPayMode.Text;
                PurchasePaymentDetailsBLL.Remarks = textRemarks.Text;
                PurchasePaymentDetailsBLL.TrAmount = decimal.Parse(textTrAmount.Text);
                PurchasePaymentDetailsBLL.AmountPiad = decimal.Parse(textAmountRecieved.Text);
                PurchasePaymentDetailsBLL.Balance = decimal.Parse(textBalance.Text);

                bool success = PurchasePaymentDetailsDAL.Update(PurchasePaymentDetailsBLL);

                if (success == true)
                {
                    MessageBox.Show("Payment Details Successfully Updated");
                }
                else
                {
                    MessageBox.Show("Failed to Update");
                }
                Clear();
            }
            else
            {
                MessageBox.Show("Please Select Details to Update");
            }
        }

        public void Clear()
        {
            textPaymentId.Text = "";
            comboInvoiceNo.Text = "Select Invoice";
            comboPhoneNo.Text = "Select Phone";
            textCustomerName.Text = "";
            textPayMode.Text = "";
            textTrAmount.Text = "";
            textAmountRecieved.Text = "";
            textBalance.Text = "";
            textRemarks.Text = "";
            textTrDate.Text = "";

            DataTable dt = PurchasePaymentDetailsDAL.Select();
            dgvDebtorNCreditors.DataSource = dt;
        }
    }
}
