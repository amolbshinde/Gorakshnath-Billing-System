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
    public partial class frmPurchase : Form
    {
        public frmPurchase()
        {
            InitializeComponent();
        }

        supplierDAL sup_DAL = new supplierDAL();
        DataTable purchasedt = new DataTable();

        purchaseDAL pur_DAL = new purchaseDAL();
        

        salesdetailsDAL sd = new salesdetailsDAL();
        productDAL pDAL = new productDAL();


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text;
            if (keyword == "")
            {
                txtSupplierName.Text = "";
                txtAddress.Text = "";
                txtContact.Text = "";
                txtEmail.Text = "";
                return;
            }

            supplierBLL sup_b = sup_DAL.searchsupplierforpurchase(keyword);



            txtSupplierName.Text = sup_b.name;
            txtContact.Text = sup_b.contact;
            txtEmail.Text = sup_b.email;
            txtAddress.Text = sup_b.address;
        }

        private void txtSearchProduct_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearchProduct.Text;


            if (keyword == "")
            {
                txtProductName.Text = "";
                txtInventory.Text = "0";
                txtRate.Text = "0";
                txtQuntity.Text = "0";
                return;
            }

            productBLL p = pDAL.GetProductsForTransaction(keyword);
            txtProductName.Text = p.name;
            txtInventory.Text = p.qty.ToString();
            txtRate.Text = p.rate.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string pname = "";
            {
                for (int rows = 0; rows < dgvAddedProduct.Rows.Count; rows++)
                {
                    pname = dgvAddedProduct.Rows[rows].Cells["Item Name"].Value.ToString();
                    break;
                }

                if (txtProductName.Text != "")
                {
                    if (txtQuntity.Text != "0")
                    {
                        if (pname != txtProductName.Text)
                        {
                            int no = 1;
                            no = (dgvAddedProduct.Rows.Count - 1) + 1;
                            string productName = txtProductName.Text;
                            decimal Rate = decimal.Parse(txtRate.Text);
                            decimal Qty = decimal.Parse(txtQuntity.Text);
                            decimal Total = Rate * Qty;

                            //decimal total = decimal.Parse(txtTotal.Text);
                            //subTotal = subTotal + Total;
                            if (no == 0)
                            {
                                no = 1;
                            }

                            purchasedt.Rows.Add(no, productName, Rate, Qty, Total);

                            dgvAddedProduct.DataSource = purchasedt;
                            //txtSubtotal.Text = subTotal.ToString();
                            //txtGrandTotal.Text = subTotal.ToString();
                            //txtPaidAmount.Text = subTotal.ToString();

                            txtSearchProduct.Text = "";
                            txtProductName.Text = "";
                            txtInventory.Text = "0.00";
                            txtRate.Text = "0.00";
                            txtQuntity.Text = "0";
                        }
                        else
                        {
                            MessageBox.Show("Product Already Added");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Enter Product Quntity");
                    }
                }
                else
                {
                    MessageBox.Show("Select the product first. Try Again.");
                }
            }
        }

        private void frmPurchase_Load(object sender, EventArgs e)
        {
            purchasedt.Columns.Add("No");
            purchasedt.Columns.Add("Item Name");
            purchasedt.Columns.Add("Rate");
            purchasedt.Columns.Add("Quantity");
            purchasedt.Columns.Add("Total");
        }

        private void txtQuntity_TextChanged(object sender, EventArgs e)
        {

            string check = txtQuntity.Text;
            if (check == "")
            {

                MessageBox.Show("Please entery Quntity.");
            }
            else
            {
                decimal total = decimal.Parse(txtQuntity.Text) * decimal.Parse(txtRate.Text);

                txtTotal.Text = total.ToString();
            }

        }

        private void txtRate_TextChanged(object sender, EventArgs e)
        {
            string check = txtRate.Text;
            if (check == "")
            {

                MessageBox.Show("Please entery Purchase Price.");
            }
            else
            {
                decimal total = decimal.Parse(txtQuntity.Text) * decimal.Parse(txtRate.Text);

                txtRate.Text = total.ToString();
            }
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            string value = txtDiscount.Text;

            if (value == "")
            {
                MessageBox.Show("Please Add Discount First");
            }
            else
            {
                decimal subTotal = decimal.Parse(txtTotal.Text);
                decimal discount = decimal.Parse(txtDiscount.Text);


                decimal disTotal = Math.Round(((100 - discount) / 100) * subTotal, 2);

                txtTotal.Text = disTotal.ToString();
            }
        }

        private void txtGst_TextChanged(object sender, EventArgs e)
        {
            string check = txtGst.Text;
            if (check == "")
            {

                MessageBox.Show("Please Enter the Gst First.");
            }
            else
            {

                decimal previousTotal = decimal.Parse(txtTotal.Text);
                decimal gst = decimal.Parse(txtGst.Text);
                decimal gstTotal = Math.Round(((100 + gst) / 100) * previousTotal, 2);


                txtTotal.Text = gstTotal.ToString();
            }
        }
    }
}
