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
    public partial class frmChallan : Form
    {
        public frmChallan()
        {
            InitializeComponent();
        }

        SupplierMasterDAL smDAL = new SupplierMasterDAL();
        productDAL pDAL = new productDAL();
        DataTable transactionDT = new DataTable();
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "Non GST")
            {
                comboBox3.Enabled = false;
                textGST.Enabled = false;
            }
            else if (comboBox2.Text == "GST")
            {
                comboBox3.Enabled = true;
                textGST.Enabled = true;

            }


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            //get search keyword from search text box
            string keyword = textSearch.Text;
            if (keyword == "")//clear all textboex
            {
                textSupplierName.Text = "";
                textAddress.Text = "";
                textContact.Text = "";
                textEmail.Text = "";
                return;
            }

            SupplierMasterBLL smBLL = smDAL.SearchSupplier(keyword);



            textSupplierName.Text = smBLL.CompanyName;
            textContact.Text = smBLL.Phone_No;
            textEmail.Text = smBLL.Email;
            textAddress.Text = smBLL.Address;

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            string keyword = textItemSearch.Text;


            if (keyword == "")
            {
                textItemName.Text = "";
                textInventory.Text = "0";
                textPurchasePrice.Text = "0";
                textQuantity.Text = "0";
                return;
            }

            productBLL p = pDAL.GetProductsForTransaction(keyword);
            textItemName.Text = p.name;
            textInventory.Text = p.qty.ToString();
            textPurchasePrice.Text = p.rate.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // get Product name ,Qty, price , Discount ,Tax. Amount to datagrid view

            String ProductName = textItemName.Text;
            String Unit = comboBoxUnit.Text;

            decimal Qty, PurchasePrice, discount, gst, TotalAmount;
            decimal.TryParse(textQuantity.Text, out Qty);
            decimal.TryParse(textPurchasePrice.Text, out PurchasePrice);
            decimal.TryParse(textDiscount.Text, out discount);
            decimal.TryParse(textGST.Text, out gst);
            decimal.TryParse(textTotalAmount.Text, out TotalAmount);


            // CHECK PRODUCT IS SELECTED OR NOT 
            if (ProductName == "")
            {
                MessageBox.Show("Please Enter Item/Product Details");
            }
            else
            {
                //Add product to datagridview
                transactionDT.Rows.Add(ProductName, Unit, Qty, PurchasePrice, discount, gst, TotalAmount);
                dgvAddedProducts.DataSource = transactionDT;

                textItemName.Text = "";
                comboBoxUnit.Text = "";
                textInventory.Text = "0";
                textQuantity.Text = "";
                textPurchasePrice.Text = "0";
                textDiscount.Text = "";
                textQuantity.Text = "0";
            }
        }
    }
}
