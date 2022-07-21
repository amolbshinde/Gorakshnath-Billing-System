using Gorakshnath_Billing_System.BLL;
using Gorakshnath_Billing_System.DAL;
using System;
using System.IO;
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
    public partial class frmPurchaseReport : Form
    {
        public frmPurchaseReport()
        {
            InitializeComponent();
            fillCombo();
        }

        purchaseBLL purchaseBLL = new purchaseBLL();
        purchaseDAL purchaseDAL = new purchaseDAL();
        purchasedetailsDAL purchasedetailsDAL = new purchasedetailsDAL();

        public void fillCombo()
        {

        }
        private void frmPurchaseReport_Load(object sender, EventArgs e)
        {
            DataTable dt = purchaseDAL.SelectPD();
            dgvPurchaseReport.DataSource = dt;

        }

       

        private void dgvPurchaseReport_MouseClick(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                ContextMenuStrip my_menu = new System.Windows.Forms.ContextMenuStrip();
                int position_mouse_click = dgvPurchaseReport.HitTest(e.X, e.Y).RowIndex;
                if (position_mouse_click >= 0)
                {
                    my_menu.Items.Add("Print").Name = "Print";
                    my_menu.Items.Add("Edit").Name = "Edit";
                    my_menu.Items.Add("Delete").Name = "Delete";
                }
                my_menu.Show(dgvPurchaseReport, new Point(e.X, e.Y));
                my_menu.ItemClicked += new ToolStripItemClickedEventHandler(my_menu_ItemClicked);
            }

        }

        private void my_menu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if ("Print" == e.ClickedItem.Name.ToString())
            {
                //get inoice no from datagrid view
                int iNo;
                Int32.TryParse(dgvPurchaseReport.Rows[dgvPurchaseReport.CurrentCell.RowIndex].Cells[0].Value.ToString(), out iNo);
                frmPurchaseCrpt frmcrpt = new frmPurchaseCrpt(iNo);
                frmcrpt.Show();

                //MessageBox.Show(iNo.ToString());

            }

            if ("Edit" == e.ClickedItem.Name.ToString())
            {
                int pId;
                Int32.TryParse(dgvPurchaseReport.Rows[dgvPurchaseReport.CurrentCell.RowIndex].Cells[0].Value.ToString(), out pId);
                frmPurchaseManage frmpmanage = new frmPurchaseManage(pId);
                frmpmanage.Show();
            }

            if ("Delete" == e.ClickedItem.Name.ToString())
            {
                int pId;
                Int32.TryParse(dgvPurchaseReport.Rows[dgvPurchaseReport.CurrentCell.RowIndex].Cells[0].Value.ToString(), out pId);
                PurchasePaymentDetailsDAL PurchasePaymentDetailsDAL = new PurchasePaymentDetailsDAL();
                PurchasePaymentDetailsDAL.DeleteByPurchaseId(pId);
                purchasedetailsDAL.DeleteByPurchaseID(pId.ToString());
                purchaseDAL.DeleteByPurchaseID(pId.ToString());
                DataTable dt = purchaseDAL.SelectPD();
                dgvPurchaseReport.DataSource = dt;
            }


        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textSearch_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {

                if (textSearch.Text != "Enter Supplier Name,Invoice No, Mobile No")
                {
                    string Key = textSearch.Text;
                    DataTable dt = purchaseDAL.SelectPrTrn(Key);
                    dgvPurchaseReport.DataSource = dt;
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

                    textSearch.Text = "Enter Supplier Name,Invoice No, Mobile No";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textSearch_Enter(object sender, EventArgs e)
        {
            if (textSearch.Text == "Enter Supplier Name,Invoice No, Mobile No")
            {
                textSearch.Text = "";
            }
        }
    }
}
