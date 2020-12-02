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
        productDAL productDAL = new productDAL();

        challanBLL challanBLL = new challanBLL();

        challanDAL challanDAL = new challanDAL();

        challandetailsDAL challandetailsDAL = new challandetailsDAL();
        
        DataTable salesDT = new DataTable();
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboTransactionType.Text == "Non GST")
            {
                comboGstType.Enabled = false;
                textGST.Enabled = false;
            }
            else if (comboTransactionType.Text == "GST")
            {
                comboGstType.Enabled = true;
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

            productBLL p = productDAL.GetProductsForTransaction(keyword);
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
                    if (comboGstType.Text != "")
                    {


                        // get Product name ,Qty, price , Discount ,Tax. Amount to datagrid view

                        String ProductName = textItemName.Text;
                        string Unit = comboBoxUnit.Text;
                        string gstType = comboGstType.Text;

                        decimal Qty, rate, GST, Amount, TotalAmount, discount;
                        decimal.TryParse(textQuantity.Text, out Qty);
                        decimal.TryParse(textRate.Text, out rate);
                        decimal.TryParse(textGST.Text, out GST);
                        decimal.TryParse(textDiscount.Text, out discount);
                        decimal.TryParse(textTotalAmount.Text, out TotalAmount);
                        Amount = rate * Qty;
                        // decimal discount = decimal.Parse(textDiscount.Text);
                        // decimal GST = decimal.TryParse(textGST.Text, out GST);
                        //decimal TotalAmount = decimal.Parse(textTotalAmount.Text);
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
                            salesDT.Rows.Add(counter, ProductName, Unit, Qty, rate, Amount, discount, gstType, GST, TotalAmount);
                            dgvAddedProducts.DataSource = salesDT;


                            decimal subTotal;
                            decimal.TryParse(textSubTotal.Text, out subTotal);
                            subTotal = subTotal + Qty * rate;
                            textSubTotal.Text = subTotal.ToString();

                            decimal subDiscount;
                            decimal.TryParse(textSubDiscount.Text, out subDiscount);
                            subDiscount = subDiscount + Math.Round(((rate * Qty) * discount) / 100, 2);
                            textSubDiscount.Text = subDiscount.ToString();

                            decimal gTotal;
                            decimal.TryParse(textGrandTotal.Text, out gTotal);
                            gTotal = gTotal + TotalAmount;
                            textGrandTotal.Text = gTotal.ToString();

                            if (comboGstType.Text == "SGST/CGST")
                            {
                                decimal subsgst, subcgst, subGst;
                                decimal.TryParse(textSgst.Text, out subsgst);
                                decimal.TryParse(textCgst.Text, out subcgst);
                                subGst = subsgst + subcgst;
                                subGst = subGst + Math.Round((((rate * Qty) - ((rate * Qty) * discount) / 100) * GST) / 100, 2);

                                textSgst.Text = Math.Round((subGst / 2), 2).ToString();
                                textCgst.Text = Math.Round((subGst / 2), 2).ToString();
                            }
                            if (comboGstType.Text == "IGST")
                            {
                                decimal subIGst;
                                decimal.TryParse(textIgst.Text, out subIGst);
                                subIGst = subIGst + Math.Round((((rate * Qty) - ((rate * Qty) * discount) / 100) * GST) / 100, 2);
                                textIgst.Text = subIGst.ToString();
                            }


                            textItemSearch.Text = "";
                            textItemName.Text = "";
                            comboBoxUnit.Text = "";
                            textInventory.Text = "0";
                            textQuantity.Text = "0";
                            textRate.Text = "0";
                            textDiscount.Text = "0";
                            textQuantity.Text = "0";
                            comboGstType.Text = "";
                            textGST.Text = "0";

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
            }
            else
            {
                MessageBox.Show("Please Enter Product Name !");
            }
        }

        private void frmChallan_Load(object sender, EventArgs e)
        {
            salesDT.Columns.Add("Sr. No.");
            salesDT.Columns.Add("ProductName");
            salesDT.Columns.Add("Unit");
            salesDT.Columns.Add("Quantity");
            salesDT.Columns.Add("PurchasePrice");
            salesDT.Columns.Add("Amount");
            salesDT.Columns.Add("(-)Discount");
            salesDT.Columns.Add("Gst Type");
            salesDT.Columns.Add("(+)Tax%");
            salesDT.Columns.Add("(=)Total");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Validate Supplier details are there or not 

            if (textCust_Name.Text != "")
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


        public void save()
        {

            string sname = textCust_Name.Text;
            if (comboTransactionType.Text != "")
            {
                if (sname != "")
                {

                    if (dgvAddedProducts.Rows.Count != 0)
                    {
                        customerBLL c = cDAL.getCustomerIdFromName(sname);

                        decimal subTotal, totalDiscount, totalSgst, totalCgst, totalIgst, grandTotal;

                        string type = comboTransactionType.Text;
                        decimal.TryParse(textSubTotal.Text, out subTotal);
                        decimal.TryParse(textSubDiscount.Text, out totalDiscount);
                        decimal.TryParse(textSgst.Text, out totalSgst);
                        decimal.TryParse(textCgst.Text, out totalCgst);
                        decimal.TryParse(textIgst.Text, out totalIgst);
                        decimal.TryParse(textGrandTotal.Text, out grandTotal);

                        challanBLL.Transaction_Type = type;
                        challanBLL.Cust_ID = c.Cust_ID;
                        challanBLL.Sub_Total = subTotal;
                        challanBLL.TDiscount = totalDiscount;
                        challanBLL.TSGST = totalSgst;
                        challanBLL.TCGST = totalCgst;
                        challanBLL.TIGST = totalIgst;
                        challanBLL.Grand_Total = grandTotal;

                        challanBLL.SalesDetails = salesDT;
                        bool isSuccess = false;

                        // using (TransactionScope scope = new TransactionScope())
                        {
                            int salesid = -1;
                            bool b = challanDAL.insertChallan(challanBLL, out salesid);

                             for (int i = 0; i < salesDT.Rows.Count; i++)
                             {
                                challandetailsBLL cdBLL = new challandetailsBLL();
                                 string productName = salesDT.Rows[i][1].ToString();

                                 productBLL p = productDAL.GetProductIDFromName(productName);
                                 cdBLL.Product_ID = p.id;
                                cdBLL.Cust_ID = c.Cust_ID;
                                 cdBLL.Product_Name = salesDT.Rows[i][1].ToString();
                                 cdBLL.Unit = salesDT.Rows[i][2].ToString();
                                 cdBLL.Qty = Math.Round(decimal.Parse(salesDT.Rows[i][3].ToString()), 2);
                                cdBLL.Rate = Math.Round(decimal.Parse(salesDT.Rows[i][4].ToString()), 2);                                
                                cdBLL.Discount_Per = Math.Round(decimal.Parse(salesDT.Rows[i][6].ToString()), 2);
                                cdBLL.GST_Type =salesDT.Rows[i][7].ToString();
                                cdBLL.GST_Per = Math.Round(decimal.Parse(salesDT.Rows[i][8].ToString()), 2);
                                cdBLL.Total = Math.Round(decimal.Parse(salesDT.Rows[i][9].ToString()), 2);
                                bool y = challandetailsDAL.insertchallandetails(cdBLL);
                                 isSuccess = b && y;

                                 isSuccess = true;
                             }
                            isSuccess = b;
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

        private void dgvAddedProducts_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ContextMenuStrip my_menu = new System.Windows.Forms.ContextMenuStrip();
                int position_mouse_click = dgvAddedProducts.HitTest(e.X, e.Y).RowIndex;
                if (position_mouse_click >= 0)
                {
                    my_menu.Items.Add("Edit").Name = "Edit";
                    my_menu.Items.Add("Delete").Name = "Delete";
                }
                my_menu.Show(dgvAddedProducts, new Point(e.X, e.Y));
                my_menu.ItemClicked += new ToolStripItemClickedEventHandler(my_menu_ItemClicked);
            }
        }

        private void my_menu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if ("Edit" == e.ClickedItem.Name.ToString())
            {

                for (int i = 0; i < salesDT.Rows.Count; i++)
                {
                    //assognto dategrid view values into textboxs

                    textItemName.Text = dgvAddedProducts.Rows[dgvAddedProducts.CurrentCell.RowIndex].Cells[1].Value.ToString();
                    comboBoxUnit.Text = dgvAddedProducts.Rows[dgvAddedProducts.CurrentCell.RowIndex].Cells[2].Value.ToString();
                    textQuantity.Text = dgvAddedProducts.Rows[dgvAddedProducts.CurrentCell.RowIndex].Cells[3].Value.ToString();
                    textRate.Text = dgvAddedProducts.Rows[dgvAddedProducts.CurrentCell.RowIndex].Cells[4].Value.ToString();
                    textTotalAmount.Text = dgvAddedProducts.Rows[dgvAddedProducts.CurrentCell.RowIndex].Cells[9].Value.ToString();
                    textDiscount.Text = dgvAddedProducts.Rows[dgvAddedProducts.CurrentCell.RowIndex].Cells[6].Value.ToString();
                    comboGstType.Text = dgvAddedProducts.Rows[dgvAddedProducts.CurrentCell.RowIndex].Cells[7].Value.ToString();
                    textGST.Text = dgvAddedProducts.Rows[dgvAddedProducts.CurrentCell.RowIndex].Cells[8].Value.ToString();
                }

                decimal Qty, PurchasePrice, discount, Amount, gst, TotalAmount;
                decimal.TryParse(textQuantity.Text, out Qty);
                decimal.TryParse(textRate.Text, out PurchasePrice);
                decimal.TryParse(textDiscount.Text, out discount);
                decimal.TryParse(textGST.Text, out gst);
                decimal.TryParse(textTotalAmount.Text, out TotalAmount);

                Amount = PurchasePrice * Qty;

                decimal subTotal;
                decimal.TryParse(textSubTotal.Text, out subTotal);
                subTotal = subTotal - Qty * PurchasePrice;
                textSubTotal.Text = subTotal.ToString();

                decimal subDiscount;
                decimal.TryParse(textSubDiscount.Text, out subDiscount);
                subDiscount = subDiscount - Math.Round(((PurchasePrice * Qty) * discount) / 100, 2);
                textSubDiscount.Text = subDiscount.ToString();

                if (comboGstType.Text == "SGST/CGST")
                {
                    decimal subsgst, subcgst, subGst;
                    decimal.TryParse(textSgst.Text, out subsgst);
                    decimal.TryParse(textCgst.Text, out subcgst);
                    subGst = subsgst + subcgst;
                    subGst = subGst - Math.Round((((((100 - discount) / 100) * (PurchasePrice * Qty))) * gst) / 100, 2);

                    textSgst.Text = Math.Round((subGst / 2), 2).ToString();
                    textCgst.Text = Math.Round((subGst / 2), 2).ToString();
                }
                if (comboGstType.Text == "IGST")
                {
                    decimal subIGst;
                    decimal.TryParse(textIgst.Text, out subIGst);
                    subIGst = subIGst - Math.Round((((((100 - discount) / 100) * (PurchasePrice * Qty))) * gst) / 100, 2);
                    textIgst.Text = subIGst.ToString();
                }
                decimal gTotal;
                decimal.TryParse(textGrandTotal.Text, out gTotal);
                gTotal = gTotal - TotalAmount;
                textGrandTotal.Text = gTotal.ToString();

                dgvAddedProducts.Rows.RemoveAt(dgvAddedProducts.CurrentCell.RowIndex);

            }


            if ("Delete" == e.ClickedItem.Name.ToString())
            {
                decimal Qty, PurchasePrice, discount, Amount, gst, TotalAmount;

                string gstType = dgvAddedProducts.Rows[dgvAddedProducts.CurrentCell.RowIndex].Cells[7].Value.ToString();

                decimal.TryParse(dgvAddedProducts.Rows[dgvAddedProducts.CurrentCell.RowIndex].Cells[3].Value.ToString(), out Qty);
                decimal.TryParse(dgvAddedProducts.Rows[dgvAddedProducts.CurrentCell.RowIndex].Cells[4].Value.ToString(), out PurchasePrice);
                decimal.TryParse(dgvAddedProducts.Rows[dgvAddedProducts.CurrentCell.RowIndex].Cells[6].Value.ToString(), out discount);
                decimal.TryParse(dgvAddedProducts.Rows[dgvAddedProducts.CurrentCell.RowIndex].Cells[8].Value.ToString(), out gst);
                decimal.TryParse(dgvAddedProducts.Rows[dgvAddedProducts.CurrentCell.RowIndex].Cells[9].Value.ToString(), out TotalAmount);

                Amount = PurchasePrice * Qty;

                decimal subTotal;
                decimal.TryParse(textSubTotal.Text, out subTotal);
                subTotal = subTotal - Qty * PurchasePrice;
                textSubTotal.Text = subTotal.ToString();

                decimal subDiscount;
                decimal.TryParse(textSubDiscount.Text, out subDiscount);
                subDiscount = subDiscount - Math.Round(((PurchasePrice * Qty) * discount) / 100, 2);
                textSubDiscount.Text = subDiscount.ToString();

                if (gstType == "SGST/CGST")
                {
                    decimal subsgst, subcgst, subGst;
                    decimal.TryParse(textSgst.Text, out subsgst);
                    decimal.TryParse(textCgst.Text, out subcgst);
                    subGst = subsgst + subcgst;
                    subGst = subGst - Math.Round((((((100 - discount) / 100) * (PurchasePrice * Qty))) * gst) / 100, 2);

                    textSgst.Text = Math.Round((subGst / 2), 2).ToString();
                    textCgst.Text = Math.Round((subGst / 2), 2).ToString();
                }
                if (gstType == "IGST")
                {
                    decimal subIGst;
                    decimal.TryParse(textIgst.Text, out subIGst);
                    subIGst = subIGst - Math.Round((((((100 - discount) / 100) * (PurchasePrice * Qty))) * gst) / 100, 2);
                    textIgst.Text = subIGst.ToString();
                }
                decimal gTotal;
                decimal.TryParse(textGrandTotal.Text, out gTotal);
                gTotal = gTotal - TotalAmount;
                textGrandTotal.Text = gTotal.ToString();

                dgvAddedProducts.Rows.RemoveAt(dgvAddedProducts.CurrentCell.RowIndex);
                MessageBox.Show("Product Successfully Deleted");

            }


        }



    }
}
