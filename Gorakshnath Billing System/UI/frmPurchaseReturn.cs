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
    public partial class frmPurchaseReturn : Form
    {
        public frmPurchaseReturn()
        {
            InitializeComponent();
        }


        PurchaseReturnDAL PurchaseReturnDAL = new PurchaseReturnDAL();
        PurchaseReturnBLL PurchaseReturnBLL = new PurchaseReturnBLL();

        ChallanReturnDetailsDAL ChallanReturnDetailsDAL = new ChallanReturnDetailsDAL();

        customerDAL cDAL = new customerDAL();
        stockDAL stockDAL = new stockDAL();

        ProductMasterDAL ProductMasterDAL = new ProductMasterDAL();

        DataTable salesReturnDT = new DataTable();


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPurchaseReturn_Load(object sender, EventArgs e)
        {
            comboPurchaseID.DataSource = null;
            DataTable dtg = PurchaseReturnDAL.SelectPurchaseId();
            comboPurchaseID.DisplayMember = "Purchase_ID";
            comboPurchaseID.Items.Add("Select Invoice No");
            comboPurchaseID.DataSource = dtg;
        }

        private void comboPurchaseID_SelectedIndexChanged(object sender, EventArgs e)
        {
            int PurchaseID;
            int.TryParse(comboPurchaseID.Text, out PurchaseID);
            PurchaseReturnBLL crBLL = PurchaseReturnDAL.GetSuplierForPurchaseReturn(PurchaseID);
            comboPurchaseType.Text = crBLL.Transaction_Type;
            textSupplierName.Text = crBLL.Sup_Name;
            textContact.Text = crBLL.Sup_Contact;
            textEmail.Text = crBLL.Sup_Email;
            textAddress.Text = crBLL.Sup_Address;

            comboItemName.DataSource = null;
            DataTable dti = ChallanReturnDetailsDAL.SelectItemName(PurchaseID);
            comboItemName.DisplayMember = "Product_Name";
            comboItemName.Items.Add("Select Product Name");
            comboItemName.DataSource = dti;


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
