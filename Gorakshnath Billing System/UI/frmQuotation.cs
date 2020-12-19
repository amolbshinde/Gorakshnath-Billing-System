﻿using Gorakshnath_Billing_System.BLL;
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
    public partial class frmQuotation : Form
    {
        int Invoice_No = -1;
        public frmQuotation()
        {
            InitializeComponent();
        }

        customerDAL cDAL = new customerDAL();
        // customerBLL cBLL = new customerBLL();
        ProductMasterDAL ProductMasterDAL = new ProductMasterDAL();

        EstimateBLL EstimateBLL = new EstimateBLL();

        EstimateDAL EstimateDAL = new EstimateDAL();

        EstimateDetailsDAL EstimateDetailsDAL = new EstimateDetailsDAL();

        stockDAL stockDAL = new stockDAL();

        DataTable estimateDT = new DataTable();

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void picBoxExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboTransactionType_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboTransactionType.Text == "Non GST")
            {
                //Clear();
                comboGstType.Enabled = false;
                textGST.Enabled = false;
                textCgst.Enabled = false;
                textSgst.Enabled = false;
                textIgst.Enabled = false;
                comboGstType.Text = "NA";
                textGST.Text = "0";
                textCgst.Text = "0";
                textSgst.Text = "0";
                textIgst.Text = "0";
                label32.Enabled = false;
                label34.Enabled = false;
                label36.Enabled = false;
                label18.Enabled = false;
                label12.Enabled = false;

            }
            if (comboTransactionType.Text == "GST")
            {
                //Clear();
                comboGstType.Enabled = true;
                textGST.Enabled = true;
                textCgst.Enabled = true;
                textSgst.Enabled = true;
                textIgst.Enabled = true;
                comboGstType.Text = "";

                label32.Enabled = true;
                label34.Enabled = true;
                label36.Enabled = true;
                label18.Enabled = true;
                label12.Enabled = true;
            }

        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {

            if (comboTransactionType.Text != "")
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
            else
            {
                MessageBox.Show("Please Select The Transaction Type First, You Cannot Change the Transaction type during this Transaction");
            }

        }

        private void textItemSearch_TextChanged(object sender, EventArgs e)
        {

            string keyword = textItemSearch.Text;

            if (keyword == "")
            {
                textItemCode.Text = "";
                textItemName.Text = "";
                comboBoxUnit.Text = "";
                textInventory.Text = "0";
                textRate.Text = "0";
                textDiscount.Text = "0";
                textQuantity.Text = "0";
                textGST.Text = "0";
                textTotalAmount.Text = "0";
                return;
            }

            ProductMasterBLL p = ProductMasterDAL.GetProductsForTransaction(keyword);
            textItemCode.Text = p.Item_Code;
            textItemName.Text = p.Product_Name;
            comboBoxUnit.Text = p.Unit;
            textRate.Text = p.Sales_Price.ToString();
            textInventory.Text = p.Quantity.ToString();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            string pname = "";
            //checking product is already present or ot           
            if (textCust_Name.Text != "")
            {
                if (textItemName.Text != "")
                {
                    if (textQuantity.Text != "" && textQuantity.Text != "0")
                    {
                        if (comboGstType.Text != "")
                        {

                            for (int rows = 0; rows < dgvAddedProducts.Rows.Count; rows++)
                            {
                                pname = dgvAddedProducts.Rows[rows].Cells["Product Name"].Value.ToString();
                                break;
                            }
                            if (textItemName.Text != pname)
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

                                // CHECK PRODUCT IS SELECTED OR NOT 
                                if (ProductName == "")
                                {
                                    MessageBox.Show("Please Enter Item/Product Details First");
                                }
                                else
                                {
                                    int counter = 1;
                                    counter = estimateDT.Rows.Count + 1;
                                    decimal gstAmt = Math.Round((((rate * Qty) - ((rate * Qty) * discount) / 100) * GST) / 100, 2);
                                    estimateDT.Rows.Add(counter, ProductName, Unit, Qty, rate, discount, gstType, GST, gstAmt, TotalAmount);
                                    dgvAddedProducts.DataSource = estimateDT;

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
                                    if (comboTransactionType.Text != "Non GST")
                                    {
                                        comboGstType.Text = "";
                                        textGST.Text = "0";
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Product is already added please edit it Or Delete it");
                            }


                        }
                        else
                        {
                            MessageBox.Show("Plsease Select GST type");
                            //"Warning",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Warning);
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
            else
            {
                MessageBox.Show("Please Find The Customer Details First");
            }

        }

        private void frmQuotation_Load(object sender, EventArgs e)
        {

            estimateDT.Columns.Add("Sr. No.");
            estimateDT.Columns.Add("Product Name");
            estimateDT.Columns.Add("Unit");
            estimateDT.Columns.Add("Quantity");
            estimateDT.Columns.Add("PurchasePrice");
            //salesDT.Columns.Add("Amount");
            estimateDT.Columns.Add("(-)Discount");
            estimateDT.Columns.Add("Gst Type");
            estimateDT.Columns.Add("(+)GST%");
            estimateDT.Columns.Add("(+)GSTAMT");
            estimateDT.Columns.Add("(=)Total");

        }

        private void textQuantity_TextChanged(object sender, EventArgs e)
        {


            string pname = textItemSearch.Text;
            ProductMasterBLL p = ProductMasterDAL.GetProductsForTransaction(pname);
            decimal inv;
            decimal.TryParse(textQuantity.Text, out inv);
            decimal qunt = p.Quantity - inv;
            if (qunt < 0)
            {
                MessageBox.Show("No Inventory Please add Inventory First");
                textQuantity.Text = "0";
            }
            else
            {

                if (textQuantity.Text == "" && textQuantity.Text == "0")
                {
                    textTotalAmount.Text = "0";
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

        private void textRate_TextChanged(object sender, EventArgs e)
        {


            string check = textRate.Text;
            if (check == "" && check == "0")
            {
                MessageBox.Show("Please entery Purchase Price.");
                textTotalAmount.Text = "0";
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
            if (check == "" && check == "0")
            {

                textDiscount.Text = "0";

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
            if (check == "" && check == "0")
            {

                textGST.Text = "0";
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

                for (int i = 0; i < estimateDT.Rows.Count; i++)
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

        private void btnSave_Click(object sender, EventArgs e)
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
                MessageBox.Show("Please enter Customer Details");
            }
            //set Invoice No.
            textInvoiceNo.Text = Invoice_No.ToString();

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

                        EstimateBLL.Transaction_Type = type;
                        EstimateBLL.Cust_ID = c.Cust_ID;
                        EstimateBLL.Sub_Total = subTotal;
                        EstimateBLL.TDiscount = totalDiscount;
                        EstimateBLL.TSGST = totalSgst;
                        EstimateBLL.TCGST = totalCgst;
                        EstimateBLL.TIGST = totalIgst;
                        EstimateBLL.Grand_Total = grandTotal;

                        EstimateBLL.SalesDetails = estimateDT;
                        bool isSuccess = false;

                        // using (TransactionScope scope = new TransactionScope())

                        //int Invoice_No = -1; alredy declared on top 
                        bool b = EstimateDAL.insertEstimate(EstimateBLL, out Invoice_No);



                        for (int i = 0; i < estimateDT.Rows.Count; i++)
                        {
                            EstimateDetailsBLL edBLL = new EstimateDetailsBLL();

                            stockBLL stockBLL = new stockBLL();
                            string productName = estimateDT.Rows[i][1].ToString();

                            ProductMasterBLL p = ProductMasterDAL.GetProductIDFromName(productName);
                            edBLL.Product_ID = p.Product_ID;
                            edBLL.Invoice_No = Invoice_No;
                            edBLL.Cust_ID = c.Cust_ID;
                            edBLL.Product_Name = estimateDT.Rows[i][1].ToString();
                            edBLL.Unit = estimateDT.Rows[i][2].ToString();
                            edBLL.Qty = Math.Round(decimal.Parse(estimateDT.Rows[i][3].ToString()), 2);
                            edBLL.Rate = Math.Round(decimal.Parse(estimateDT.Rows[i][4].ToString()), 2);
                            edBLL.Discount_Per = Math.Round(decimal.Parse(estimateDT.Rows[i][5].ToString()), 2);
                            edBLL.GST_Type = estimateDT.Rows[i][6].ToString();
                            edBLL.GST_Per = Math.Round(decimal.Parse(estimateDT.Rows[i][7].ToString()), 2);
                            edBLL.Total = Math.Round(decimal.Parse(estimateDT.Rows[i][9].ToString()), 2);
                           

                            bool y = EstimateDetailsDAL.insertchallandetails(edBLL);
                            

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

        public void Clear()
        {

            textSearch.Text = "";
            textCust_Name.Text = "";
            textEmail.Text = "";
            textAddress.Text = "";
            textContact.Text = "";
            textInvoiceNo.Text = "";

            textItemCode.Text = "";
            textItemSearch.Text = "";
            textItemName.Text = "";
            comboBoxUnit.Text = "";
            textInventory.Text = "0";
            textQuantity.Text = "0";
            textRate.Text = "0";
            textDiscount.Text = "0";

            if (comboTransactionType.Text != "Non GST")
            {
                comboGstType.Text = "";
                textGST.Text = "0";
            }

            textTotalAmount.Text = "0";

            textSubTotal.Text = "0";
            textSubDiscount.Text = "0";
            textSgst.Text = "0";
            textCgst.Text = "0";
            textIgst.Text = "0";
            textGrandTotal.Text = "0";

            dgvAddedProducts.DataSource = null;
            dgvAddedProducts.Rows.Clear();
            estimateDT.Rows.Clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (Invoice_No != -1)
            {
                ////Invoice_No = 7;
                frmEstimateCrpt frmcrpt = new frmEstimateCrpt(Invoice_No);
                frmcrpt.Show();
            }
            else
            {
                MessageBox.Show("Please Save details first");
            }
        }
    }
}
