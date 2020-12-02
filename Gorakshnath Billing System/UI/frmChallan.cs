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

        customerDAL cDAL = new customerDAL();
       // customerBLL cBLL = new customerBLL();
        productDAL pDAL = new productDAL();
        DataTable transactionDT = new DataTable();
        DataTable salesDT = new DataTable();
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboTransactionType.Text == "Non GST")
            {
                comboBox3.Enabled = false;
                textGST.Enabled = false;
            }
            else if (comboTransactionType.Text == "GST")
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
                textCust_Name.Text = "";
                textAddress.Text = "";
                textContact.Text = "";
                textEmail.Text = "";
                return;
            }

            customerBLL cBLL = cDAL.searchcustomerforsales(keyword);



            textCust_Name.Text = cBLL.name;
            textContact.Text = cBLL.contact;
            textEmail.Text = cBLL.email;
            textAddress.Text = cBLL.address;

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            string keyword = textItemSearch.Text;


            if (keyword == "")
            {
                textItemName.Text = "";
                textInventory.Text = "0";
                textRate.Text = "0";
                textQuantity.Text = "0";
                return;
            }

            productBLL p = pDAL.GetProductsForTransaction(keyword);
            textItemName.Text = p.name;
            textInventory.Text = p.qty.ToString();
            textRate.Text = p.rate.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //checking product is already present or ot
            if (textItemName.Text != "")
            {
                if (textQuantity.Text != "")
                {
                    if (dgvAddedProducts.Columns.Contains(textItemName.Text) != true)
                    {


                        // get Product name ,Qty, price , Discount ,Tax. Amount to datagrid view

                        String ProductName = textItemName.Text;
                        string Unit = comboBoxUnit.Text;

                        decimal Qty,rate,GST,Total,discount;
                        decimal.TryParse(textQuantity.Text,out Qty);
                        decimal.TryParse(textRate.Text, out rate);
                        decimal.TryParse(textGST.Text, out GST);
                        decimal.TryParse(textDiscount.Text, out discount);
                        decimal.TryParse(textTotalAmount.Text, out Total);

                        // decimal discount = decimal.Parse(textDiscount.Text);
                       // decimal GST = decimal.TryParse(textGST.Text, out GST);
                       // decimal Total = decimal.Parse(textTotalAmount.Text);
                        //decimal discount = decimal.Parse(textDiscount.Text);

                        //          


                        // CHECK PRODUCT IS SELECTED OR NOT 
                        if (ProductName == "")
                        {
                            MessageBox.Show("Please Enter Item/Product Details First");
                        }
                        else
                        {
                            int counter = 1;
                            transactionDT.Rows.Add(counter, ProductName, Unit, Qty, rate, discount, GST, Total);

                            dgvAddedProducts.DataSource = transactionDT;

                            textItemName.Text = "";
                            comboBoxUnit.Text = "";
                            textInventory.Text = "0";
                            textQuantity.Text = "0";
                            textRate.Text = "0";
                            textDiscount.Text = "0";
                            textQuantity.Text = "0";
                        }
                    }
                    else
                    {
                        MessageBox.Show("Product is already Added !");//,"Warning",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Warning);

                    }

                }
                else
                {
                    MessageBox.Show("Please enter Quantity !");
                }
            }else
            {
                MessageBox.Show("Please Enter Product Name !");
            }
        }

        private void frmChallan_Load(object sender, EventArgs e)
        {
            transactionDT.Columns.Add("Sr NO.");
            transactionDT.Columns.Add("Product Name");
            transactionDT.Columns.Add("Unit");
            transactionDT.Columns.Add("Quntity");
            transactionDT.Columns.Add("Rate");
            transactionDT.Columns.Add("Discount");
            transactionDT.Columns.Add("GST");
            transactionDT.Columns.Add("Total");

        }//
        /*
        public void save()
        {
            challanBLL  challanBLL = new challanBLL();

            string cname = textCust_Name.Text;
            if (comboTransactionType.Text != "")
            {
                if (cname != "")
                {

                    if (dgvAddedProducts.Rows.Count != 0)
                    {
                        customerBLL c = cDAL.searchcustomerforsales(cname);

                        //Sales_ID,Invoice_No,Cust_ID,Sub_Total,TDiscount,TSGST,TCGST,TIGST,Grand_Total,Transaction_Date

                        int Sales_ID=1, Invoice_No=1, Cust_ID;
                        decimal Sub_Total, TDiscount, TSGST, TCGST, TIGST, Grand_Total;
;

                       // string TrnType = comboTransactionType.Text;
                        decimal.TryParse(textSubTotal.Text, out Sub_Total);
                        decimal.TryParse(textSubDiscount.Text, out TDiscount);
                        decimal.TryParse(textSgst.Text, out TSGST);
                        decimal.TryParse(textCgst.Text, out TCGST);
                        decimal.TryParse(textIgst.Text, out TIGST);
                        decimal.TryParse(textGrandTotal.Text, out Grand_Total);

                        challanBLL.Sales_ID = Sales_ID;
                        challanBLL.Invoice_No = Invoice_No;
                        challanBLL.Cust_ID = c.Cust_ID;
                        challanBLL.Sub_Total = Sub_Total;
                        challanBLL.TDiscount = TDiscount;
                        challanBLL.TSGST = TSGST;
                        challanBLL.TCGST = TCGST;
                        challanBLL.TIGST = TIGST;
                        challanBLL.Grand_Total = Grand_Total;
                        challanBLL.Transaction_Date = DateTime.Now;


                        challanBLL.SalesDetails = salesDT;
                        bool isSuccess = false;

                        // using (TransactionScope scope = new TransactionScope())
                        {
                            int SalesID = -1;
                            bool c = challanDAL.insertChallan(challanBLL, out SalesID);
                            for (int i = 0; i < salesDT.Rows.Count; i++)
                            {
                                challandetailsBLL cdBLL = new challandetailsBLL();
                                string Cust_Name = salesDT.Rows[i][1].ToString();

                                customerBLL c = customerDAL.searchcustomerforsales(Cust_Name);

                                pdBLL.productid = p.id;
                                pdBLL.qty = Math.Round(decimal.Parse(purchasedt.Rows[i][3].ToString()), 2);
                                pdBLL.rate = Math.Round(decimal.Parse(purchasedt.Rows[i][4].ToString()), 2);
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
                        MessageBox.Show("Please Add product Details");
                    }

                }
                else
                {
                    MessageBox.Show("Please Select Customer Details");
                }
            }
            else
            {
                MessageBox.Show("Please Select Purchase Type GST OR NOGST");
            }
        }*/

        private void button1_Click(object sender, EventArgs e)
        {

            //Validate Supplier details are there or not 

            if (textCust_Name.Text != "")
            {
                if (dgvAddedProducts.Rows.Count != 0)
                {
                    //save fun
                    //save();
                   
                }
                else
                {
                    MessageBox.Show("Please Add Product Details");
                }
            }
            else
            {
                MessageBox.Show("Please enter Supplier Details");
            }




        }

        private void textQuantity_TextChanged(object sender, EventArgs e)
        {
            if (textQuantity.Text == "")
            {
                textTotalAmount.Text = "";
            }
            else
            {
                decimal Qty, Rate, discount, gst;
                decimal.TryParse(textQuantity.Text, out Qty);
                decimal.TryParse(textRate.Text, out Rate);
                decimal.TryParse(textDiscount.Text, out discount);
                decimal.TryParse(textGST.Text, out gst);

                decimal TotalAmount = Math.Round(((100 + gst) / 100) * (((100 - discount) / 100) * (Rate * Qty)), 2);

                textTotalAmount.Text = TotalAmount.ToString();

            }

        }

        private void textRate_TextChanged(object sender, EventArgs e)
        {


            string check = textRate.Text;
            if (check == "")
            {

                MessageBox.Show("Please entery Purchase Price.");
                textTotalAmount.Text = "";
            }

            
            else
            {
                decimal Qty, Rate, discount, gst;
                decimal.TryParse(textQuantity.Text, out Qty);
                decimal.TryParse(textRate.Text, out Rate);
                decimal.TryParse(textDiscount.Text, out discount);
                decimal.TryParse(textGST.Text, out gst);

                decimal TotalAmount = Math.Round(((100 + gst) / 100) * (((100 - discount) / 100) * (Rate * Qty)), 2);

                textTotalAmount.Text = TotalAmount.ToString();

            }

        }

        private void textDiscount_TextChanged(object sender, EventArgs e)
        {
            string check = textDiscount.Text;
            if (check == "")
            {

              //  MessageBox.Show("Please Enter Discount.");
                
            }


            else
            {
                decimal Qty, Rate, discount, gst;
                decimal.TryParse(textQuantity.Text, out Qty);
                decimal.TryParse(textRate.Text, out Rate);
                decimal.TryParse(textDiscount.Text, out discount);
                decimal.TryParse(textGST.Text, out gst);

                decimal TotalAmount = Math.Round(((100 + gst) / 100) * (((100 - discount) / 100) * (Rate * Qty)), 2);

                textTotalAmount.Text = TotalAmount.ToString();

            }
        }

        private void textGST_TextChanged(object sender, EventArgs e)
        {
            string check = textGST.Text;
            if (check == "")
            {

                MessageBox.Show("Please Enter GST %.");

            }


            else
            {
                decimal Qty, Rate, discount, gst;
                decimal.TryParse(textQuantity.Text, out Qty);
                decimal.TryParse(textRate.Text, out Rate);
                decimal.TryParse(textDiscount.Text, out discount);
                decimal.TryParse(textGST.Text, out gst);

                decimal TotalAmount = Math.Round(((100 + gst) / 100) * (((100 - discount) / 100) * (Rate * Qty)), 2);

                textTotalAmount.Text = TotalAmount.ToString();

            }
        }
    }
}
