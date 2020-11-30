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

        purchaseDAL purchaseDAL = new purchaseDAL();


        purchasedetailsDAL pdetailsDAL = new purchasedetailsDAL();
        productDAL productDAL = new productDAL();
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


            // CHECK PRODUCT IS SELECTED OR NOT 
            if (textItemName.Text != "")
            {
                // get Product name,unit ,Qty, price , Discount ,Tax. Amount to datagrid view

                String ProductName = textItemName.Text;
                String Unit = comboBoxUnit.Text;

                decimal Qty, PurchasePrice, discount, Amount, gst, TotalAmount;
                decimal.TryParse(textQuantity.Text, out Qty);
                decimal.TryParse(textPurchasePrice.Text, out PurchasePrice);
                decimal.TryParse(textDiscount.Text, out discount);
                decimal.TryParse(textGst.Text, out gst);
                decimal.TryParse(textTotalAmount.Text, out TotalAmount);

                Amount = PurchasePrice * Qty;

                int no = 1;
                no = transactionDT.Rows.Count + 1;
                //Add product to datagridview//
                transactionDT.Rows.Add(no,ProductName, Unit, Qty, PurchasePrice, Amount, discount+"%", gst + "%", TotalAmount);
                dgvAddedProducts.DataSource = transactionDT;

                decimal subTotal;
                decimal.TryParse(textSubTotal.Text,out subTotal);
                subTotal = subTotal + Qty * PurchasePrice;
                textSubTotal.Text = subTotal.ToString();

                decimal subDiscount;
                decimal.TryParse(textSubDiscount.Text, out subDiscount);
                subDiscount = subDiscount +((PurchasePrice * Qty)*discount)/100;
                textSubDiscount.Text = subDiscount.ToString();

                decimal gTotal = subTotal - subDiscount;
                textGrandTotal.Text = gTotal.ToString();

                textItemSearch.Text = "";
                textItemName.Text = "";
                comboBoxUnit.Text = "";
                textInventory.Text = "0";
                textQuantity.Text = "0";
                textPurchasePrice.Text = "0";
                textDiscount.Text = "0";
                textQuantity.Text = "0";
                textGst.Text = "0";
            }
            else
            {
                MessageBox.Show("Please Enter Item/Product Details");                
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
                textDiscount.Text = "0";
                textGst.Text = "0";
                return;
            }

            productBLL p = productDAL.GetProductsForTransaction(keyword);
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
            transactionDT.Columns.Add("Sr. No.");
            transactionDT.Columns.Add("ProductName");
            transactionDT.Columns.Add("Unit");
            transactionDT.Columns.Add("Quantity");
            transactionDT.Columns.Add("PurchasePrice");
            transactionDT.Columns.Add("Amount");
            transactionDT.Columns.Add("(-)Discount");
            transactionDT.Columns.Add("(+)Tax%");
            transactionDT.Columns.Add("(=)Total");           
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

                decimal TotalAmount = Math.Round(((100 + gst) / 100) * (((100 - discount) / 100)*(PurchasePrice * Qty)), 2);

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

                decimal TotalAmount = Math.Round(((100 + gst) / 100) * (((100 - discount) / 100) * (PurchasePrice * Qty)), 2);

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

                decimal TotalAmount = Math.Round(((100 + gst) / 100) * (((100 - discount) / 100) * (PurchasePrice * Qty)), 2);

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

                decimal TotalAmount = Math.Round(((100 + gst) / 100) * (((100 - discount) / 100) * (PurchasePrice * Qty)), 2);

                textTotalAmount.Text = TotalAmount.ToString();
            }
        }

        public void save()
        {

            purchaseBLL purchaseBLL = new purchaseBLL();

            string sname = textSupplierName.Text;
            if (sname != "")
            {
                SupplierMasterBLL s = smDAL.getSuplierIdFromName(sname);

                purchaseBLL.purchasedate = dtpBillDate.Value;
                purchaseBLL.supid = s.SupplierID;
                purchaseBLL.grandtotal = decimal.Parse(textGrandTotal.Text);
                purchaseBLL.gst = decimal.Parse(textGst.Text);
                purchaseBLL.discount = decimal.Parse(textSubDiscount.Text);

                purchaseBLL.purchasedetails = transactionDT;
                bool isSuccess = false;

                // using (TransactionScope scope = new TransactionScope())
                {
                    int purchaseid = -1;
                    bool b = purchaseDAL.insertpurchase(purchaseBLL, out purchaseid);
                    for (int i = 0; i < transactionDT.Rows.Count; i++)
                    {
                        purchasedetailsBLL pdBLL = new purchasedetailsBLL();
                        string productName = transactionDT.Rows[i][1].ToString();

                        productBLL p = productDAL.GetProductIDFromName(productName);

                        pdBLL.productid = p.id;
                        pdBLL.rate = decimal.Parse(transactionDT.Rows[i][2].ToString());
                        pdBLL.qty = decimal.Parse(transactionDT.Rows[i][3].ToString());
                        pdBLL.total = Math.Round(decimal.Parse(transactionDT.Rows[i][4].ToString()), 2);
                        pdBLL.supid = s.SupplierID;
                        pdBLL.addeddate = dtpBillDate.Value;
                       

                        bool y = pdetailsDAL.insertpurchasedetails(pdBLL);
                        isSuccess = b && y;
                    }
                    if (isSuccess == true)
                    {
                        //scope.Complete();
                        MessageBox.Show("Transaction Completed");
                        //clear();
                    }
                    else
                    {
                        MessageBox.Show("Transaction Failed");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please Select Customer Details");
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            //check product is already available in stock or not
            //
            //if yes update the quantity if no add new product in stock 

            //also add details in PTransactions and PTransaction Details 

            //save transaction and transaction details
            save();

        }
    }
}
