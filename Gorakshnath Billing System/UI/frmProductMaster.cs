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
    public partial class frmProductMaster : Form
    {
        public frmProductMaster()
        {
            InitializeComponent();
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtProduct_ID.Text = "";
            txtProduct_Name.Text = "";
            comboProduct_Group.Text = "";
            comboBrand.Text = "";
            txtItem_Code.Text = "";
            textHSN_Code.Text = "";
            txtPurchase_Price.Text = "";
            txtSales_Price.Text = "";
            txtMin_Sales_Price.Text = "";
            comboUnit.Text = "";
            txtOpening_Stock.Text = "";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();///////
        }
    }
}
