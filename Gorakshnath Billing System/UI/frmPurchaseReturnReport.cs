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
    public partial class frmPurchaseReturnReport : Form
    {
        public frmPurchaseReturnReport()
        {
            InitializeComponent();
        }

        PurchaseReturnBLL PurchaseReturnBLL = new PurchaseReturnBLL();
        PurchaseReturnDAL PurchaseReturnDAL = new PurchaseReturnDAL();

        private void frmPurchaseReturnReport_Load(object sender, EventArgs e)
        {

            DataTable dt = PurchaseReturnDAL.SelectPRD();
            dgvPurchaseReturnReport.DataSource = dt;

            comboInvoiceNo.DataSource = null;
            DataTable dtP = PurchaseReturnDAL.SelectPRD();
            comboInvoiceNo.DisplayMember = "Invoice_No";
            comboInvoiceNo.ValueMember = "Invoice_No";
            comboInvoiceNo.DataSource = dtP;
            comboInvoiceNo.Text = "Select By Invoice No";

            comboSupName.DataSource = null;
            DataTable dtNP = PurchaseReturnDAL.SelectPRD();
            comboSupName.DisplayMember = "CompanyName";
            comboSupName.ValueMember = "CompanyName";
            comboSupName.DataSource = dtNP;
            comboSupName.Text = "Select By Supplier Name";

            comboMobileNo.DataSource = null;
            DataTable dtC = PurchaseReturnDAL.SelectPRD();
            comboMobileNo.DisplayMember = "Phone_No";
            comboMobileNo.ValueMember = "Phone_No";
            comboMobileNo.DataSource = dtC;
            comboMobileNo.Text = "Select By Mobile No";

        }

        private void comboInvoiceNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboInvoiceNo.Text != "Select By Invoice No")
            {
                string iNo;
                iNo = comboInvoiceNo.Text.ToString();
                DataTable dt = PurchaseReturnDAL.SelectByPurchaseReturnId(iNo);
                dgvPurchaseReturnReport.DataSource = dt;
                //MessageBox.Show(comboInvoiceNo.Text);
            }
            else
            {
                DataTable dt = PurchaseReturnDAL.SelectPRD();
                dgvPurchaseReturnReport.DataSource = dt;
            }
        }

        private void comboSupName_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboSupName.Text != "Select By Cust Name")
            {
                string CName;
                CName = comboSupName.Text.ToString();
                DataTable dt = PurchaseReturnDAL.SelectBySupName(CName);
                dgvPurchaseReturnReport.DataSource = dt;
            }
            else
            {
                DataTable dt = PurchaseReturnDAL.SelectPRD();
                dgvPurchaseReturnReport.DataSource = dt;
            }

        }

        private void comboMobileNo_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboMobileNo.Text != "Select By Mobile No")
            {
                string mobNo;
                mobNo = comboMobileNo.Text.ToString();
                DataTable dt = PurchaseReturnDAL.SelectByMobileNo(mobNo);
                dgvPurchaseReturnReport.DataSource = dt;
            }
            else
            {
                DataTable dt = PurchaseReturnDAL.SelectPRD();
                dgvPurchaseReturnReport.DataSource = dt;
            }

        }

        private void dgvPurchaseReturnReport_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ContextMenuStrip my_menu = new System.Windows.Forms.ContextMenuStrip();
                int position_mouse_click = dgvPurchaseReturnReport.HitTest(e.X, e.Y).RowIndex;
                if (position_mouse_click >= 0)
                {
                    my_menu.Items.Add("Print").Name = "Print";
                }
                my_menu.Show(dgvPurchaseReturnReport, new Point(e.X, e.Y));
                my_menu.ItemClicked += new ToolStripItemClickedEventHandler(my_menu_ItemClicked);
            }
        }

        private void my_menu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if ("Print" == e.ClickedItem.Name.ToString())
            {
                //get inoice no from datagrid view
                int iNo;
                Int32.TryParse(dgvPurchaseReturnReport.Rows[dgvPurchaseReturnReport.CurrentCell.RowIndex].Cells[0].Value.ToString(), out iNo);
                frmInvoiceCrpt frmcrpt = new frmInvoiceCrpt(iNo);
                frmcrpt.Show();

                //MessageBox.Show(iNo.ToString());

            }

        }
    }
}
