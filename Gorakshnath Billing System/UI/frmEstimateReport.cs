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
            DataTable dt = EstimateDAL.SelectTD();
            dgvEstimateReport.DataSource = dt;
            dgvEstimateReport.AutoResizeColumns();

        }

        private void frmEstimateReport_Load(object sender, EventArgs e)
        {

            DataTable dt = EstimateDAL.SelectTD();
            dgvEstimateReport.DataSource = dt;
            dgvEstimateReport.AutoResizeColumns();

        }

        

       
        private void dgvChallanReport_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ContextMenuStrip my_menu = new System.Windows.Forms.ContextMenuStrip();
                int position_mouse_click = dgvEstimateReport.HitTest(e.X, e.Y).RowIndex;
                if (position_mouse_click >= 0)
                {
                    my_menu.Items.Add("Print").Name = "Print";
                    my_menu.Items.Add("Delete").Name = "Delete";
                }
                my_menu.Show(dgvEstimateReport, new Point(e.X, e.Y));
                my_menu.ItemClicked += new ToolStripItemClickedEventHandler(my_menu_ItemClicked);
            }
        }

        private void my_menu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if ("Print" == e.ClickedItem.Name.ToString())
            {
                //get inoice no from datagrid view
                int iNo;
                Int32.TryParse(dgvEstimateReport.Rows[dgvEstimateReport.CurrentCell.RowIndex].Cells[0].Value.ToString(), out iNo);

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
                Int32.TryParse(dgvEstimateReport.Rows[dgvEstimateReport.CurrentCell.RowIndex].Cells[0].Value.ToString(), out iNo);
                EstimateDetailsDAL.DeleteByInvoiceNo(iNo.ToString());
                EstimateDAL.DeleteByInvoiceNo(iNo.ToString());
                DataTable dt = EstimateDAL.SelectTD();
                dgvEstimateReport.DataSource = dt;
            }
        }

      

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable dt = EstimateDAL.SelectTD();
            dgvEstimateReport.DataSource = dt;
            dgvEstimateReport.AutoResizeColumns();
        }

        private void textSearch_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {

                if (textSearch.Text != "Enter Customer name,Invoice No, Mobile No")
                {
                    string Key = textSearch.Text;
                    DataTable dt = EstimateDAL.FetchRuntime(Key);
                    dgvEstimateReport.DataSource = dt;
                    dgvEstimateReport.AutoResizeColumns();
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
