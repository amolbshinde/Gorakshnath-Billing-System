using Gorakshnath_Billing_System.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gorakshnath_Billing_System
{
    public partial class frmAdminDashboard : Form
    {
        public frmAdminDashboard()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void catageoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCategories category = new frmCategories();
            category.Show();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsers user = new frmUsers();
            user.Show();
        }

        private void frmAdminDashboard_Load(object sender, EventArgs e)
        {

            label3.Text = frmLogin.loggedIn;
        }

        private void frmAdminDashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmLogin login = new frmLogin();
            login.Show();
            this.Hide();
        }

        private void productToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void inverntoryToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void addNewProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void manageCategoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCategories category = new frmCategories();
            category.Show();
        }

        private void totalSalesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void addCustomerClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCustomer customer = new frmCustomer();
            customer.Show();
        }

        private void newSalesReturnCreditNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSalesReturn salesReturn = new frmSalesReturn();
            salesReturn.Show();
        }

        private void newInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSales sales = new frmSales();
            sales.Show();
        }

        private void fgToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
