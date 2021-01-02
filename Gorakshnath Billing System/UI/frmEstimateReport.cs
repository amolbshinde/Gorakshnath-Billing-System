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
    public partial class frmEstimateReport : Form
    {
        public frmEstimateReport()
        {
            InitializeComponent();
            fillCombo();
        }

        EstimateBLL EstimateBLL = new EstimateBLL();
        EstimateDAL EstimateDAL = new EstimateDAL();

        public void fillCombo()
        {
            comboInvoiceNo.DataSource = null;
            DataTable dtI = EstimateDAL.SelectTD();
            comboInvoiceNo.DisplayMember = "Invoice_No";
            comboInvoiceNo.ValueMember = "Invoice_No";
            comboInvoiceNo.DataSource = dtI;
            comboInvoiceNo.Text = "Select By Invoice No";

            comboCustName.DataSource = null;
            DataTable dtC = EstimateDAL.SelectTD();
            comboCustName.DisplayMember = "Cust_Name";
            comboCustName.DataSource = dtC;
            comboCustName.Text = "Select By Cust Name";

            comboMobileNo.DataSource = null;
            DataTable dtM = EstimateDAL.SelectTD();
            comboMobileNo.DisplayMember = "Cust_Contact";
            comboMobileNo.DataSource = dtM;
            comboMobileNo.Text = "Select By Mobile No";
        }

        private void frmEstimateReport_Load(object sender, EventArgs e)
        {

            DataTable dt = EstimateDAL.SelectTD();
            dgvChallanReport.DataSource = dt;

        }

        private void comboInvoiceNo_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboInvoiceNo.Text != "Select By Invoice No")
            {
                string iNo;
                iNo = comboInvoiceNo.Text.ToString();
                DataTable dt = EstimateDAL.SelectByInvoiceNo(iNo);
                dgvChallanReport.DataSource = dt;
            }
            else
            {
                DataTable dt = EstimateDAL.SelectTD();
                dgvChallanReport.DataSource = dt;
            }

        }

        private void comboCustName_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboCustName.Text != "Select By Cust Name")
            {
                string CName;
                CName = comboCustName.Text.ToString();
                DataTable dt = EstimateDAL.SelectByCustName(CName);
                dgvChallanReport.DataSource = dt;
            }
            else
            {
                DataTable dt = EstimateDAL.SelectTD();
                dgvChallanReport.DataSource = dt;
            }

        }

        private void comboMobileNo_SelectedIndexChanged(object sender, EventArgs e)
        {


            if (comboMobileNo.Text != "Select By Mobile No")
            {
                string mobNo;
                mobNo = comboMobileNo.Text.ToString();
                DataTable dt = EstimateDAL.SelectByMobileNo(mobNo);
                dgvChallanReport.DataSource = dt;
            }
            else
            {
                DataTable dt = EstimateDAL.SelectTD();
                dgvChallanReport.DataSource = dt;
            }

        }

        private void dgvChallanReport_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ContextMenuStrip my_menu = new System.Windows.Forms.ContextMenuStrip();
                int position_mouse_click = dgvChallanReport.HitTest(e.X, e.Y).RowIndex;
                if (position_mouse_click >= 0)
                {
                    my_menu.Items.Add("Print").Name = "Print";
                    my_menu.Items.Add("Delete").Name = "Delete";
                }
                my_menu.Show(dgvChallanReport, new Point(e.X, e.Y));
                my_menu.ItemClicked += new ToolStripItemClickedEventHandler(my_menu_ItemClicked);
            }
        }

        private void my_menu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if ("Print" == e.ClickedItem.Name.ToString())
            {
                //get inoice no from datagrid view
                int iNo;
                Int32.TryParse(dgvChallanReport.Rows[dgvChallanReport.CurrentCell.RowIndex].Cells[0].Value.ToString(), out iNo);

                if (iNo != -1)
                {
                    frmEstimateCrpt Estimate = new frmEstimateCrpt(iNo);
                    Estimate.Show();
                }
                else
                {
                    MessageBox.Show("Something went wrong");
                }

            }
            if ("Delete" == e.ClickedItem.Name.ToString())
            {
                EstimateDetailsDAL EstimateDetailsDAL = new EstimateDetailsDAL();
                int iNo;
                Int32.TryParse(dgvChallanReport.Rows[dgvChallanReport.CurrentCell.RowIndex].Cells[0].Value.ToString(), out iNo);
                EstimateDetailsDAL.DeleteByInvoiceNo(iNo.ToString());
                EstimateDAL.DeleteByInvoiceNo(iNo.ToString());
                DataTable dt = EstimateDAL.SelectTD();
                dgvChallanReport.DataSource = dt;
            }
        }

    }
}
