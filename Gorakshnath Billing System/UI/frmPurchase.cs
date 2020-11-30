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
                if (textQuantity.Text != "")
                {
                    if (dgvAddedProducts.Columns.Contains(textItemName.Text) != true)
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
                        no = purchasedt.Rows.Count + 1;
                        //Add product to datagridview//
                        purchasedt.Rows.Add(no, ProductName, Unit, Qty, PurchasePrice, Amount, discount + "%", gst + "%", TotalAmount);
                        dgvAddedProducts.DataSource = purchasedt;

                        decimal subTotal;
                        decimal.TryParse(textSubTotal.Text, out subTotal);
                        subTotal = subTotal + Qty * PurchasePrice;
                        textSubTotal.Text = subTotal.ToString();

                        decimal subDiscount;
                        decimal.TryParse(textSubDiscount.Text, out subDiscount);
                        subDiscount = subDiscount + ((PurchasePrice * Qty) * discount) / 100;
                        textSubDiscount.Text = subDiscount.ToString();

                        decimal gTotal = subTotal - subDiscount;
                        textGrandTotal.Text = gTotal.ToString();

                        if (comboGstType.Text == "SGST/CGST")
                        {
                            decimal sgst, cgst, subGst;
                            decimal.TryParse(textSgst.Text, out sgst);
                            decimal.TryParse(textCgst.Text, out cgst);
                            subGst = sgst + cgst;
                            subGst = subGst + ((PurchasePrice * Qty) * gst) / 100;

                            textSgst.Text = (subGst / 2).ToString();
                            textCgst.Text = (subGst / 2).ToString();
                        }
                        if (comboGstType.Text == "IGST")
                        {
                            decimal igst, subIGst;
                            decimal.TryParse(textIgst.Text, out subIGst);

                            subIGst = subIGst + ((PurchasePrice * Qty) * gst) / 100;

                            textIgst.Text = subIGst.ToString();
                        }

                        textItemSearch.Text = "";
                        textItemName.Text = "";
                        comboBoxUnit.Text = "";
                        textInventory.Text = "0";
                        textQuantity.Text = "0";
                        textPurchasePrice.Text = "0";
                        textDiscount.Text = "0";
                        textQuantity.Text = "0";
                        comboGstType.Text = "";
                        textGst.Text = "0";
                    }
                    else
                    {                        
                        MessageBox.Show("alreday addere product");
                    }
                }
                else
                {
                    MessageBox.Show("Please Enter Product Quantity");
                }
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
            purchasedt.Columns.Add("Sr. No.");
            purchasedt.Columns.Add("ProductName");
            purchasedt.Columns.Add("Unit");
            purchasedt.Columns.Add("Quantity");
            purchasedt.Columns.Add("PurchasePrice");
            purchasedt.Columns.Add("Amount");
            purchasedt.Columns.Add("(-)Discount");
            purchasedt.Columns.Add("(+)Tax%");
            purchasedt.Columns.Add("(=)Total");           
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

                decimal subTotal, totalDiscount, totalSgst, totalCgst, totalIgst, grandTotal;

                string type = comboPurchaseType.Text;
                decimal.TryParse(textSubTotal.Text,out subTotal);
                decimal.TryParse(textSubDiscount.Text,out totalDiscount);
                decimal.TryParse(textSgst.Text,out totalSgst);
                decimal.TryParse(textCgst.Text, out totalCgst);
                decimal.TryParse(textIgst.Text, out totalIgst);
                decimal.TryParse(textGrandTotal.Text,out grandTotal);


                purchaseBLL.type = type;
                purchaseBLL.supid = s.SupplierID;
                purchaseBLL.subTotal = subTotal;
                purchaseBLL.totalDiscount = totalDiscount;
                purchaseBLL.totalSgst = totalSgst;
                purchaseBLL.totalCgst = totalCgst;
                purchaseBLL.totalIgst = totalIgst;
                purchaseBLL.grandTotal = grandTotal;

                

                purchaseBLL.purchasedetails = purchasedt;
                bool isSuccess = false;

                // using (TransactionScope scope = new TransactionScope())
                {
                    int purchaseid = -1;
                    bool b = purchaseDAL.insertpurchase(purchaseBLL, out purchaseid);
                    for (int i = 0; i < purchasedt.Rows.Count; i++)
                    {
                        purchasedetailsBLL pdBLL = new purchasedetailsBLL();
                        string productName = purchasedt.Rows[i][1].ToString();

                        productBLL p = productDAL.GetProductIDFromName(productName);
                        
                        pdBLL.productid = p.id;
                        pdBLL.qty = Math.Round(decimal.Parse(purchasedt.Rows[i][3].ToString()),2);
                        pdBLL.rate = Math.Round(decimal.Parse(purchasedt.Rows[i][4].ToString()),2);                        
                        pdBLL.total = Math.Round(decimal.Parse(purchasedt.Rows[i][5].ToString()), 2);
                        pdBLL.supid = s.SupplierID;
                            
                        
                       

                        bool y = pdetailsDAL.insertpurchasedetails(pdBLL);
                        isSuccess = b && y;
                        
                       
                        isSuccess = true;
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
