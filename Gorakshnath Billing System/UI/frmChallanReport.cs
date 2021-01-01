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
    public partial class frmChallanReport : Form
    {        
        public frmChallanReport()
        {
            InitializeComponent();
            fillcombo();
        }

        challanBLL ChallanBLL = new challanBLL();
        challanDAL challanDAL = new challanDAL();

        challandetailsDAL challandetailsDAL = new challandetailsDAL();



        public void fillcombo()
        {
            comboInvoiceNo.DataSource = null;
            DataTable dtI = challanDAL.SelectTD();
            comboInvoiceNo.DisplayMember = "Invoice_No";
            //comboInvoiceNo.ValueMember = "Invoice_No";            
            comboInvoiceNo.DataSource = dtI;
            comboInvoiceNo.Text = "Select By Invoice No";

            comboCustName.DataSource = null;
            DataTable dtC = challanDAL.SelectTD();
            comboCustName.DisplayMember = "Cust_Name";
            comboCustName.DataSource = dtC;
            comboCustName.Text = "Select By Cust Name";

            comboMobileNo.DataSource = null;
            DataTable dtM = challanDAL.SelectTD();
            comboMobileNo.DisplayMember = "Cust_Contact";
            comboMobileNo.DataSource = dtM;
            comboMobileNo.Text = "Select By Mobile No";

            //MessageBox.Show(comboInvoiceNo.Text);
        }

        private void frmChallanReport_Load(object sender, EventArgs e)
        {
            DataTable dt = challanDAL.SelectTD();
            dgvChallanReport.DataSource = dt;
        }

        private void comboInvoiceNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboInvoiceNo.Text != "Select By Invoice No")
            {
                string iNo;
                iNo = comboInvoiceNo.Text.ToString();
                DataTable dt = challanDAL.SelectByInvoiceNo(iNo);
                dgvChallanReport.DataSource = dt;
                //MessageBox.Show(comboInvoiceNo.Text);
            }
            else
            {
                DataTable dt = challanDAL.SelectTD();
                dgvChallanReport.DataSource = dt;
            }
        }

        private void comboCustName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboCustName.Text != "Select By Cust Name")
            {
                string CName;
                CName = comboCustName.Text.ToString();
                DataTable dt = challanDAL.SelectByCustName(CName);
                dgvChallanReport.DataSource = dt;
            }
            else
            {
                DataTable dt = challanDAL.SelectTD();
                dgvChallanReport.DataSource = dt;
            }
        }

        private void comboMobileNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (comboMobileNo.Text != "Select By Mobile No")
            {
                string mobNo;
                mobNo = comboMobileNo.Text.ToString();
                DataTable dt = challanDAL.SelectByMobileNo(mobNo);
                dgvChallanReport.DataSource = dt;
            }
            else
            {
                DataTable dt = challanDAL.SelectTD();
                dgvChallanReport.DataSource = dt;
            }
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
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
                    my_menu.Items.Add("Edit").Name = "Edit";
                    my_menu.Items.Add("Delete").Name = "Delete";
                }
                my_menu.Show(dgvChallanReport, new Point(e.X, e.Y));
                my_menu.ItemClicked += new ToolStripItemClickedEventHandler(my_menu_ItemClicked);
            }
        }



        private void my_menu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if ("Edit" == e.ClickedItem.Name.ToString())
            {
                int iNo;
                Int32.TryParse(dgvChallanReport.Rows[dgvChallanReport.CurrentCell.RowIndex].Cells[0].Value.ToString(), out iNo);
                frmChallanManage frmchmanage = new frmChallanManage(iNo);
                frmchmanage.Show();
            }
                if ("Print" == e.ClickedItem.Name.ToString())
            {
                //get inoice no from datagrid view
                int iNo;
                Int32.TryParse(dgvChallanReport.Rows[dgvChallanReport.CurrentCell.RowIndex].Cells[0].Value.ToString(), out iNo);
                frmInvoiceCrpt frmcrpt = new frmInvoiceCrpt(iNo);
                frmcrpt.Show();

                //MessageBox.Show(iNo.ToString());

            }

            if ("Delete" == e.ClickedItem.Name.ToString())
            {
                int iNo;
                Int32.TryParse(dgvChallanReport.Rows[dgvChallanReport.CurrentCell.RowIndex].Cells[0].Value.ToString(), out iNo);
                challandetailsDAL.DeleteByInvoiceNo(iNo.ToString());
                challanDAL.DeleteByInvoiceNo(iNo.ToString());
                DataTable dt = challanDAL.SelectTD();
                dgvChallanReport.DataSource = dt;
            }
        }

        private void dgvChallanReport_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
