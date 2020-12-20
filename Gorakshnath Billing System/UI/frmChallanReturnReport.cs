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
    public partial class frmChallanReturnReport : Form
    {
        public frmChallanReturnReport()
        {
            InitializeComponent();
        }

        ChallanReturnBLL ChallanReturnBLL = new ChallanReturnBLL();
        ChallanReturnDAL ChallanReturnDAL = new ChallanReturnDAL();



        private void frmChallanReturnReport_Load(object sender, EventArgs e)
        {

            DataTable dt = ChallanReturnDAL.SelectSRR();
            dgvChallanReturnReport.DataSource = dt;

            comboInvoiceNo.DataSource = null;
            DataTable dtI = ChallanReturnDAL.SelectSRR();
            comboInvoiceNo.DisplayMember = "Invoice_No";
            //comboInvoiceNo.ValueMember = "Invoice_No";            
            comboInvoiceNo.DataSource = dtI;
            comboInvoiceNo.Text = "Select By Invoice No";

            comboCustName.DataSource = null;
            DataTable dtC = ChallanReturnDAL.SelectSRR();
            comboCustName.DisplayMember = "Cust_Name";
            comboCustName.DataSource = dtC;
            comboCustName.Text = "Select By Cust Name";

            comboMobileNo.DataSource = null;
            DataTable dtM = ChallanReturnDAL.SelectSRR();
            comboMobileNo.DisplayMember = "Cust_Contact";
            comboMobileNo.DataSource = dtM;
            comboMobileNo.Text = "Select By Mobile No";

        }

        private void comboInvoiceNo_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboInvoiceNo.Text != "Select By Invoice No")
            {
                string iNo;
                iNo = comboInvoiceNo.Text.ToString();
                DataTable dt = ChallanReturnDAL.SelectByInvoiceNo(iNo);
                dgvChallanReturnReport.DataSource = dt;
                //MessageBox.Show(comboInvoiceNo.Text);
            }
            else
            {
                DataTable dt = ChallanReturnDAL.SelectSRR();
                dgvChallanReturnReport.DataSource = dt;
            }

        }

        private void comboCustName_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboCustName.Text != "Select By Cust Name")
            {
                string CName;
                CName = comboCustName.Text.ToString();
                DataTable dt = ChallanReturnDAL.SelectByCustName(CName);
                dgvChallanReturnReport.DataSource = dt;
            }
            else
            {
                DataTable dt = ChallanReturnDAL.SelectSRR();
                dgvChallanReturnReport.DataSource = dt;
            }

        }

        private void comboMobileNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboMobileNo.Text != "Select By Mobile No")
            {
                string mobNo;
                mobNo = comboMobileNo.Text.ToString();
                DataTable dt = ChallanReturnDAL.SelectByMobileNo(mobNo);
                dgvChallanReturnReport.DataSource = dt;
            }
            else
            {
                DataTable dt = ChallanReturnDAL.SelectSRR();
                dgvChallanReturnReport.DataSource = dt;
            }
        }

        private void dgvChallanReport_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ContextMenuStrip my_menu = new System.Windows.Forms.ContextMenuStrip();
                int position_mouse_click = dgvChallanReturnReport.HitTest(e.X, e.Y).RowIndex;
                if (position_mouse_click >= 0)
                {
                    my_menu.Items.Add("Print").Name = "Print";
                }
                my_menu.Show(dgvChallanReturnReport, new Point(e.X, e.Y));
                my_menu.ItemClicked += new ToolStripItemClickedEventHandler(my_menu_ItemClicked);
            }
        }

        private void my_menu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if ("Print" == e.ClickedItem.Name.ToString())
            {
                //get inoice no from datagrid view
                int iNo;
                Int32.TryParse(dgvChallanReturnReport.Rows[dgvChallanReturnReport.CurrentCell.RowIndex].Cells[0].Value.ToString(), out iNo);
                frmInvoiceCrpt frmcrpt = new frmInvoiceCrpt(iNo);
                frmcrpt.Show();

                //MessageBox.Show(iNo.ToString());

            }

        }

    }
}
