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
            DataTable dt = pDAL.Select();
            dgvProductMaster.DataSource = dt;


        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
            DataTable dt = pDAL.Select();
            dgvProductMaster.DataSource = dt;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            ///
    }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string Product_ID = txtProduct_ID.Text;
            if (Product_ID != "" && Product_ID != "Auto Genrated")
            {
                pBLL.Product_ID = Convert.ToInt32(txtProduct_ID.Text);
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

                bool Success = pDAL.Update(pBLL);

                if (Success == true)
                {
                    MessageBox.Show("Product Details Successfully Updated");
                    clear();
                }
                else
                {
                    MessageBox.Show("Failed to Update Product Details");
                }
                DataTable dt = pDAL.Select();
                dgvProductMaster.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Please Select Details to Update");
            }
        }

        private void frmProductMaster_Load(object sender, EventArgs e)
        {
            DataTable dt = pDAL.Select();
            dgvProductMaster.DataSource = dt;
        }

        private void dgvProductMaster_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;

            txtProduct_ID.Text = dgvProductMaster.Rows[rowIndex].Cells[0].Value.ToString();

            comboProduct_Group.Text = dgvProductMaster.Rows[rowIndex].Cells[1].Value.ToString();

            comboBrand.Text = dgvProductMaster.Rows[rowIndex].Cells[2].Value.ToString();

            txtItem_Code.Text = dgvProductMaster.Rows[rowIndex].Cells[3].Value.ToString();

            txtProduct_Name.Text = dgvProductMaster.Rows[rowIndex].Cells[4].Value.ToString();

            textHSN_Code.Text = dgvProductMaster.Rows[rowIndex].Cells[5].Value.ToString();

            txtPurchase_Price.Text = dgvProductMaster.Rows[rowIndex].Cells[6].Value.ToString();

            txtSales_Price.Text = dgvProductMaster.Rows[rowIndex].Cells[7].Value.ToString();

            txtMin_Sales_Price.Text = dgvProductMaster.Rows[rowIndex].Cells[8].Value.ToString();

            comboUnit.Text = dgvProductMaster.Rows[rowIndex].Cells[9].Value.ToString();

            txtOpening_Stock.Text = dgvProductMaster.Rows[rowIndex].Cells[10].Value.ToString();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string Product_ID = txtProduct_ID.Text;
            if (Product_ID != "" && Product_ID != "Auto Genrated")
            {
                pBLL.Product_ID = Convert.ToInt32(txtProduct_ID.Text);
                //

                bool success = pDAL.Delete(pBLL);

                if (success == true)
                {
                    MessageBox.Show("Custermer Details Successfully Deleted");
                    clear();
                }
                else
                {
                    MessageBox.Show("Failed To Delete");
                }
                DataTable dt = pDAL.Select();
                dgvProductMaster.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Please Selecte Details to Delete");
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keywords = txtSearch.Text;

            if (keywords != null)
            {
                DataTable dt = pDAL.Search(keywords);
                dgvProductMaster.DataSource = dt;
            }
            else
            {
                DataTable dt = pDAL.Select();
                dgvProductMaster.DataSource = dt;
            }
        }
    }
}
