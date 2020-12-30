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
    public partial class Debtors_and_Creditors : Form
    {
        public Debtors_and_Creditors()
        {
            InitializeComponent();
        }

        SalesPaymentDetailsBLL SalesPaymentDetailsBLL = new SalesPaymentDetailsBLL();
        SalesPaymentDetailsDAL SalesPaymentDetailsDAL = new SalesPaymentDetailsDAL();


        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Debtors_and_Creditors_Load(object sender, EventArgs e)
        {
            DataTable dt = SalesPaymentDetailsDAL.Select();
            dgvDebtorNCreditors.DataSource = dt;
        }

        private void dgvDebtorNCreditors_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            textPaymentId.Text = dgvDebtorNCreditors.Rows[rowIndex].Cells[0].Value.ToString();
            textInvoiceNo.Text = dgvDebtorNCreditors.Rows[rowIndex].Cells[1].Value.ToString();
            textCustomerName.Text = dgvDebtorNCreditors.Rows[rowIndex].Cells[2].Value.ToString();
            textPayMode.Text = dgvDebtorNCreditors.Rows[rowIndex].Cells[3].Value.ToString();            
            textTrAmount.Text = dgvDebtorNCreditors.Rows[rowIndex].Cells[5].Value.ToString();
            textAmountRecieved.Text = dgvDebtorNCreditors.Rows[rowIndex].Cells[6].Value.ToString();
            textBalance.Text = dgvDebtorNCreditors.Rows[rowIndex].Cells[7].Value.ToString();
            textRemarks.Text = dgvDebtorNCreditors.Rows[rowIndex].Cells[8].Value.ToString();
            textTrDate.Text = dgvDebtorNCreditors.Rows[rowIndex].Cells[9].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string PaymentId = textPaymentId.Text;
            if (PaymentId != "")
            {
                SalesPaymentDetailsBLL.PaymentId= Convert.ToInt32(PaymentId);
                SalesPaymentDetailsBLL.Invoice_No = Convert.ToInt32(textInvoiceNo.Text);
                SalesPaymentDetailsBLL.PaymentMode = textPayMode.Text;
                SalesPaymentDetailsBLL.Remarks = textRemarks.Text;
                SalesPaymentDetailsBLL.TrAmount = decimal.Parse(textTrAmount.Text);
                SalesPaymentDetailsBLL.AmountPiad = decimal.Parse(textAmountRecieved.Text);
                SalesPaymentDetailsBLL.Balance = decimal.Parse(textBalance.Text);

                bool success = SalesPaymentDetailsDAL.Update(SalesPaymentDetailsBLL);

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
            textInvoiceNo.Text = "";
            textCustomerName.Text = "";
            textPayMode.Text = "";
            textTrAmount.Text = "";
            textAmountRecieved.Text = "";
            textBalance.Text = "";
            textRemarks.Text = "";
            textTrDate.Text = "";

            DataTable dt = SalesPaymentDetailsDAL.Select();
            dgvDebtorNCreditors.DataSource = dt;
        }

        private void textAmountRecieved_TextChanged(object sender, EventArgs e)
        {
            if (textAmountRecieved.Text != "")
            {
                Decimal TrAmount, PaidAmount;
                TrAmount = Convert.ToDecimal(textTrAmount.Text);
                PaidAmount = Convert.ToDecimal(textAmountRecieved.Text);
                textBalance.Text = Convert.ToString(TrAmount - PaidAmount);
            }
        }
    }
}
