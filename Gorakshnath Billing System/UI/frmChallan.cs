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
                int no = 1;
                no = (transactionDT.Rows.Count) + 1;                

                //Add product to datagridview
                transactionDT.Rows.Add(no,ProductName, Unit, Qty, PurchasePrice, discount, gst, TotalAmount);
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

        private void frmChallan_Load(object sender, EventArgs e)
        {
            transactionDT.Columns.Add("Sr NO.");
            transactionDT.Columns.Add("Product Name");
            transactionDT.Columns.Add("Unit");
            transactionDT.Columns.Add("Quntity");
            transactionDT.Columns.Add("Pruchase Price");
            transactionDT.Columns.Add("Discount");
            transactionDT.Columns.Add("GST");
            transactionDT.Columns.Add("Total");

        }

       /* public void save()
        {
            purchaseBLL pBLL = new purchaseBLL();

            string cname = textSupplierName.Text;
            if (cname != "")
            {
                customerBLL c = cDAL.getCustomerIdFromName(cname);

                sales.salesdate = dtpBillDate.Value;
                sales.custid = c.id;
                sales.grandtotal = decimal.Parse(txtGrandTotal.Text);
                sales.gst = decimal.Parse(txtGst.Text);
                sales.discount = decimal.Parse(txtDiscount.Text);

                sales.salesdetails = salesdt;
                bool isSuccess = false;

                // using (TransactionScope scope = new TransactionScope())
                {
                    int salesid = -1;
                    bool b = s.insertsales(sales, out salesid);
                    for (int i = 0; i < salesdt.Rows.Count; i++)
                    {
                        salesdetailsBLL sdb = new salesdetailsBLL();
                        string productName = salesdt.Rows[i][1].ToString();

                        productBLL p = pDAL.GetProductIDFromName(productName);

                        sdb.productid = p.id;
                        sdb.rate = decimal.Parse(salesdt.Rows[i][2].ToString());
                        sdb.qty = decimal.Parse(salesdt.Rows[i][3].ToString());
                        sdb.total = Math.Round(decimal.Parse(salesdt.Rows[i][4].ToString()), 2);
                        sdb.custid = c.id;
                        sdb.addeddate = dtpBillDate.Value;

                        if (b == true)
                        {
                            bool x = pDAL.DecreaseProduct(sdb.productid, sdb.qty);
                        }

                        bool y = sd.insertsalesdetails(sdb);
                        isSuccess = b && y;
                    }
                    if (isSuccess == true)
                    {
                        //scope.Complete();
                        MessageBox.Show("Transaction Completed");
                        clear();
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
        }*/

                
        private void button1_Click(object sender, EventArgs e)
        {

            //Validate Supplier details are there or not 

            if (textSupplierName.Text != "")
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




            //get data from dataGrid View

            //check product is already available in stock or not

            //
            //if yes update the quantity if no add new product in stock 

            //also add details in PTransactions and PTransaction Detail
        }
    }
}
