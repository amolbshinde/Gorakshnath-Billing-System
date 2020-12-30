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
    }
}
