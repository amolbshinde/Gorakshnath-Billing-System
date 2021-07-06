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
            
        }

        challanBLL ChallanBLL = new challanBLL();
        challanDAL challanDAL = new challanDAL();

        challandetailsDAL challandetailsDAL = new challandetailsDAL();



        public void fillcombo()
        {
            //MessageBox.Show(comboInvoiceNo.Text);
        }

        private void frmChallanReport_Load(object sender, EventArgs e)

        {
            fillcombo();
            DataTable dt = challanDAL.SelectTD("");
            dgvChallanReport.DataSource = dt;
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
                    my_menu.Items.Add("Edit").Name = "Edit";                    
                    my_menu.Items.Add("Print").Name = "Print";                    
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
                SalesPaymentDetailsDAL SalesPaymentDetailsDAL = new SalesPaymentDetailsDAL();
                SalesPaymentDetailsDAL.DeleteByInvoice_No(iNo);
                challandetailsDAL.DeleteByInvoiceNo(iNo.ToString());
                challanDAL.DeleteByInvoiceNo(iNo.ToString());
                DataTable dt = challanDAL.SelectTD("");
                dgvChallanReport.DataSource = dt;
            }
        }

        private void dgvChallanReport_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       

        

        private void button5_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            frmChallanSalesReport SalesReport = new frmChallanSalesReport();
            SalesReport.Show();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                        
        }

        private void textSearch_Enter(object sender, EventArgs e)
        {
            if (textSearch.Text == "Enter Customer name,Invoice No, Mobile No")
            {
                textSearch.Text = "";
            }
        }

      

      

        private void textSearch_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {

                if (textSearch.Text != "Enter Customer name,Invoice No, Mobile No")
                {
                    string Key = textSearch.Text;
                    DataTable dt = challanDAL.SelectTD(Key);
                    dgvChallanReport.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Please Enter Keywords To Search Report  !");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textSearch_Leave(object sender, EventArgs e)
        {

            try
            {
                bool valiDa = textSearch.Text.All(c => Char.IsLetterOrDigit(c) || c.Equals('_'));
                if (valiDa == false || textSearch.Text == "")
                {

                    textSearch.Text = "Enter Customer name,Invoice No, Mobile No";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
