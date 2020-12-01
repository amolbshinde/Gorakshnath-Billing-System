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

            customerBLL cBLL = cDAL.searchcustomerforsales(keyword);



            textSupplierName.Text = cBLL.name;
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

        }


                
        private void button1_Click(object sender, EventArgs e)
        {

            //Validate Supplier details are there or not 

            if (textSupplierName.Text != "")
            {
                if (dgvAddedProducts.Rows.Count != 0)
                {
                    //save fun
                    save();
                   
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
