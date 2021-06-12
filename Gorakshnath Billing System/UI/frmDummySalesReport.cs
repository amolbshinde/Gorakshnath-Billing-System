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
    public partial class frmDummySalesReport : Form
    {
        public frmDummySalesReport()
        {
            InitializeComponent();
            fillCombo();
        }

        DummySalesBLL DummySalesBLL = new DummySalesBLL();
        DummySalesDAL DummySalesDAL = new DummySalesDAL();

        public void fillCombo()
        {


        }

        private void frmDummySalesReport_Load(object sender, EventArgs e)
        {
            //
            DataTable dt = DummySalesDAL.SelectTD();
            dgvChallanReport.DataSource = dt;


        }

        private void comboInvoiceNo_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void comboCustName_SelectedIndexChanged(object sender, EventArgs e)
        {

            

        }

        private void comboMobileNo_SelectedIndexChanged(object sender, EventArgs e)
        {

            

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
            if ("Print" == e.ClickedItem.Name.ToString())
            {
                //get inoice no from datagrid view
                int iNo;
                Int32.TryParse(dgvChallanReport.Rows[dgvChallanReport.CurrentCell.RowIndex].Cells[0].Value.ToString(), out iNo);

               MessageBox.Show(iNo.ToString());
                                   ////Invoice_No = 7;
                    frmDummySalesCrpt frmDummySalesCrpt = new frmDummySalesCrpt(iNo);
                    frmDummySalesCrpt.Show();
               
            }

            if ("Delete" == e.ClickedItem.Name.ToString())
            {
                DummySalesDetailsDAL DummySalesDetailsDAL = new DummySalesDetailsDAL();
                int iNo;
                Int32.TryParse(dgvChallanReport.Rows[dgvChallanReport.CurrentCell.RowIndex].Cells[0].Value.ToString(), out iNo);                
                DummySalesDetailsDAL.DeleteByInvoiceNo(iNo.ToString());
                DummySalesDAL.DeleteByInvoiceNo(iNo.ToString());
                DataTable dt = DummySalesDAL.SelectTD();
                dgvChallanReport.DataSource = dt;
            }

        }


    }
}
