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
    public partial class frmProductMaster : Form
    {
        public frmProductMaster()
        {
            InitializeComponent();
        }
        ProductMasterBLL pBLL = new ProductMasterBLL();
        ProductMasterDAL pDAL = new ProductMasterDAL();

        
        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void clear()
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            pBLL.Product_Group = comboProduct_Group.Text;
            pBLL.Brand = comboBrand.Text;
            pBLL.Item_Code = txtItem_Code.Text;
            pBLL.Product_Name = txtProduct_Name.Text;
            pBLL.HSN_Code = textHSN_Code.Text;
            pBLL.Purchase_Price = decimal.Parse(txtPurchase_Price.Text);
            pBLL.Sales_Price = decimal.Parse(txtSales_Price.Text);
            pBLL.Min_Sales_Price = decimal.Parse(txtMin_Sales_Price.Text);
            pBLL.Unit = comboUnit.Text;
            pBLL.Opening_Stock = decimal.Parse(txtOpening_Stock.Text);

            bool Success = pDAL.Insert(pBLL);

            if (Success == true)
            {
                MessageBox.Show("Product Details Successfully Added");
                clear();
            }
            else
            {
                MessageBox.Show("Failed to Added Product Details");
            }


        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            ///
    }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
