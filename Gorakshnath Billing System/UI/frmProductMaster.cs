using Gorakshnath_Billing_System.BLL;
using Gorakshnath_Billing_System.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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

        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        //hello

        ProductMasterBLL pBLL = new ProductMasterBLL();
        ProductMasterDAL pDAL = new ProductMasterDAL();

        GroupDAL gDAL = new GroupDAL();
        BrandDAL bDAL = new BrandDAL();

        
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
            

            if (comboProduct_Group.Text != "")
            {
                if(comboBrand.Text != "")
                {
                    if(txtItem_Code.Text!="")
                    {
                        pBLL = pDAL.checkProductCodeAvailableOrNot(txtItem_Code.Text);
                        if (txtItem_Code.Text != pBLL.Item_Code)
                        {
                            if (txtProduct_Name.Text != "")
                            {
                                pBLL = pDAL.checkProductAvailableOrNot(txtProduct_Name.Text);
                                if (txtProduct_Name.Text != pBLL.Product_Name)
                                {
                                    if (textHSN_Code.Text != "")
                                    {
                                        pBLL = pDAL.checkProductHSNAvailableOrNot(textHSN_Code.Text);
                                        if (textHSN_Code.Text != pBLL.HSN_Code)
                                        {
                                            if (txtPurchase_Price.Text != "")
                                            {
                                                if (txtPurchase_Price.Text != "0")
                                                {

                                                    if (txtMin_Sales_Price.Text != "")
                                                    {
                                                        if (txtMin_Sales_Price.Text != "0")
                                                        {

                                                            if (comboUnit.Text != "")
                                                            {

                                                                if (txtOpening_Stock.Text != "")
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
                                                                else
                                                                {
                                                                    MessageBox.Show("Please Enter the Product Opening Stock");
                                                                }

                                                            }
                                                            else
                                                            {
                                                                MessageBox.Show("Please Select Product Unit");
                                                            }

                                                        }
                                                        else
                                                        {
                                                            MessageBox.Show("Please Enter the Product Minimum Sales Prise Greater Than 0");
                                                        }

                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("Please Enter the Product Minimum Sales Prise");
                                                    }

                                                }
                                                else
                                                {
                                                    MessageBox.Show("Please Enter the Product Purchase Prise Greater Than 0");
                                                }

                                            }
                                            else
                                            {
                                                MessageBox.Show("Please Enter the Product Purchase Prise");
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("HSN Code is Already Added in Database Please choose another HSN Code");
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Please Enter the Product HSN Code");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Product is Already Added in Database Please choose another Product");
                                }

                            }
                            else
                            {
                                MessageBox.Show("Please Enter the Product Name");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Item Code is Already Added in Database Please choose another Item Code");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Please Enter the Product Code");
                    }                            

                }
                else
                {
                    MessageBox.Show("Please Enter the Product Brand"); 
                }
                
            }
            else
            {
                MessageBox.Show("Please Select Product Group"); 
            }

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
            
            DataTable dtg = gDAL.Select();
            comboBrand.Text = "Select";
            comboProduct_Group.DisplayMember = "Group_Name";
            comboProduct_Group.DataSource = dtg;

            DataTable dtb = bDAL.Select();
            comboBrand.DisplayMember = "Brand_Name";
            comboBrand.DataSource = dtb;          

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

        private void comboProduct_Group_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
