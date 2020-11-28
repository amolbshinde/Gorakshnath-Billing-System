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
        DataTable transactionDT = new DataTable();

        SupplierMasterDAL smDAL = new SupplierMasterDAL();
        DataTable purchasedt = new DataTable();

        purchaseDAL pur_DAL = new purchaseDAL();


        salesdetailsDAL sd = new salesdetailsDAL();
        productDAL pDAL = new productDAL();
        //hello
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
            textAddress.Text =smBLL.Address;


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
            decimal.TryParse(textGst.Text, out gst);
            decimal.TryParse(textTotalAmount.Text, out TotalAmount);


            // CHECK PRODUCT IS SELECTED OR NOT 
            if (ProductName=="")
            {
                MessageBox.Show("Please Enter Item/Product Details");
            }
            else
            {
                //Add product to datagridview
                transactionDT.Rows.Add(ProductName,Unit, Qty, PurchasePrice, discount, gst, TotalAmount);
                dgvAddedProducts.DataSource = transactionDT;

                textItemName.Text = "";
                comboBoxUnit.Text="";
                textInventory.Text = "0";
                textQuantity.Text = "";
                textPurchasePrice.Text = "0";
                textDiscount.Text = "";
                textQuantity.Text = "0";

            }

        }


        private void textItemSearch_TextChanged(object sender, EventArgs e)
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

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmPurchase_Load(object sender, EventArgs e)
        {
            //specify columns to our dataTable 
            transactionDT.Columns.Add("ProductName");
            transactionDT.Columns.Add("Unit");
            transactionDT.Columns.Add("Quantity");
            transactionDT.Columns.Add("PurchasePrice");
            transactionDT.Columns.Add("Discount");
            transactionDT.Columns.Add("Tax%");
            transactionDT.Columns.Add("Total");
           
        }

        private void textQuantity_TextChanged(object sender, EventArgs e)
        {
            if (textQuantity.Text == "")
            {
                textTotalAmount.Text = "";
            }
            else
            {
                decimal Qty, PurchasePrice, discount, gst;
                decimal.TryParse(textQuantity.Text, out Qty);
                decimal.TryParse(textPurchasePrice.Text, out PurchasePrice);
                decimal.TryParse(textDiscount.Text, out discount);
                decimal.TryParse(textGst.Text, out gst);

                decimal TotalAmount = Math.Round(((100 - discount) / 100) * ((100 + gst) / 100) * (PurchasePrice * Qty), 2);

                textTotalAmount.Text = TotalAmount.ToString();

            }

        }

        private void textPurchasePrice_TextChanged(object sender, EventArgs e)
        {
            string check = textPurchasePrice.Text;
            if (check == "")
            {

                MessageBox.Show("Please entery Purchase Price.");
            }
            else
            {
                decimal Qty, PurchasePrice, discount, gst;
                decimal.TryParse(textQuantity.Text, out Qty);
                decimal.TryParse(textPurchasePrice.Text, out PurchasePrice);
                decimal.TryParse(textDiscount.Text, out discount);
                decimal.TryParse(textGst.Text, out gst);

                decimal TotalAmount = Math.Round(((100 - discount) / 100) * ((100 + gst) / 100) * (PurchasePrice * Qty), 2);

                textTotalAmount.Text = TotalAmount.ToString();
            }
        }

        private void textDiscount_TextChanged(object sender, EventArgs e)
        {
            string value = textDiscount.Text;

            if (value == "")
            {
                MessageBox.Show("Please Add Discount First");
            }
            else
            {

                decimal Qty, PurchasePrice, discount, gst;
                decimal.TryParse(textQuantity.Text, out Qty);
                decimal.TryParse(textPurchasePrice.Text, out PurchasePrice);
                decimal.TryParse(textDiscount.Text, out discount);
                decimal.TryParse(textGst.Text, out gst);

                decimal TotalAmount = Math.Round(((100 - discount) / 100) * ((100 + gst) / 100) * (PurchasePrice * Qty), 2);

                textTotalAmount.Text = TotalAmount.ToString();

            }
        }

        private void textGst_TextChanged(object sender, EventArgs e)
        {
            string check = textGst.Text;
            if (check == "")
            {

                MessageBox.Show("Please Enter the Gst First.");
            }
            else
            {
                decimal Qty, PurchasePrice, discount, gst;
                decimal.TryParse(textQuantity.Text, out Qty);
                decimal.TryParse(textPurchasePrice.Text, out PurchasePrice);
                decimal.TryParse(textDiscount.Text, out discount);
                decimal.TryParse(textGst.Text, out gst);

                decimal TotalAmount = Math.Round(((100 - discount) / 100) * ((100 + gst) / 100) * (PurchasePrice * Qty), 2);

                textTotalAmount.Text = TotalAmount.ToString();
            }
        }
    }
}
