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
    public partial class frmChallanManage : Form
    {
        int GetInvoice;
        int ProductId;
        public frmChallanManage(int InvoiceNo)
        {
            InitializeComponent();
            fillCombo();
            int i = 1;
            while (i == 1)
            {
                GetInvoice = InvoiceNo;
                i++;
            }
        }

        customerBLL customerBLL = new customerBLL();
        customerDAL customerDAL = new customerDAL();

        ProductMasterDAL ProductMasterDAL = new ProductMasterDAL();

        challanBLL challanBLL = new challanBLL();

        challanDAL challanDAL = new challanDAL();

        challandetailsDAL challandetailsDAL = new challandetailsDAL();

        stockDAL stockDAL = new stockDAL();

        DataTable salesDT = new DataTable();
        DataTable chDT = new DataTable();

        public void fillCombo()
        {
            comboSearchCust.DataSource = null;
            DataTable dtC = customerDAL.SelectForCombo();
            comboSearchCust.DisplayMember = "Cust_Name";
            comboSearchCust.DataSource = dtC;
            comboSearchCust.Text = "Select Cust";        

           

        }



        public void getChallanDetails()
        {

        }
          
        private void frmChallanManage_Load(object sender, EventArgs e)
        {
            listSearchItems.Hide();
            salesDT.Columns.Add("Sr. No.");
            salesDT.Columns.Add("Product Name");
            salesDT.Columns.Add("Unit");
            salesDT.Columns.Add("Quantity");
            salesDT.Columns.Add("PurchasePrice");            
            salesDT.Columns.Add("(-)Discount");
            salesDT.Columns.Add("Gst Type");
            salesDT.Columns.Add("(+)GST%");         
            salesDT.Columns.Add("(=)Total");

            comboSearchCust.Text = "Select Cust";
            comboContact.Text = "Select Phone";            
            textItemCode.Text = "";
            textSearchItems.Text = "Select Product";
            comboBoxUnit.Text = "";
            textInventory.Text = "0";
            textQuantity.Text = "0";
            textRate.Text = "0";
            textDiscount.Text = "0";
            textGstNo.Text = "";

            if (comboTransactionType.Text != "Non GST")
            {
                comboGstType.Text = "";
                textGST.Text = "0";
            }


            //MessageBox.Show(GetInvoice.ToString());
            textInvoiceNo.Text = GetInvoice.ToString();

            DataTable dtc = challanDAL.SelectByInvoiceNoManage(GetInvoice.ToString());
            comboSearchCust.Text = dtc.Rows[0][1].ToString();
            comboContact.Text= dtc.Rows[0][2].ToString();
            textEmail.Text = dtc.Rows[0][3].ToString();
            textAddress.Text = dtc.Rows[0][4].ToString();            
            comboTransactionType.Text= dtc.Rows[0][5].ToString();
            textSubTotal.Text= dtc.Rows[0][6].ToString();
            textSubDiscount.Text = dtc.Rows[0][7].ToString();
            textSgst.Text= dtc.Rows[0][8].ToString();
            textCgst.Text = dtc.Rows[0][9].ToString();
            textIgst.Text = dtc.Rows[0][10].ToString();
            textGrandTotal.Text = dtc.Rows[0][11].ToString();
            textGstNo.Text = dtc.Rows[0][12].ToString();
                        

            chDT = challandetailsDAL.SelectByInvoiceNo(GetInvoice.ToString());
            //dgvAddedProducts.DataSource = salesDT;
            for (int i = 0; i < chDT.Rows.Count; i++)
            {
                string ProductName = chDT.Rows[i][0].ToString();
                string Unit = chDT.Rows[i][1].ToString();
                string gstType = chDT.Rows[i][5].ToString();

                decimal Qty, rate, GST, TotalAmount, discount;
                decimal.TryParse(chDT.Rows[i][2].ToString(), out Qty);
                decimal.TryParse(chDT.Rows[i][3].ToString(), out rate);
                decimal.TryParse(chDT.Rows[i][6].ToString(), out GST);
                decimal.TryParse(chDT.Rows[i][4].ToString(), out discount);
                decimal.TryParse(chDT.Rows[i][7].ToString(), out TotalAmount);

                int counter = 1;
                counter = salesDT.Rows.Count + 1;
                salesDT.Rows.Add(counter, ProductName, Unit, Qty, rate, discount, gstType, GST, TotalAmount);                
            }
            dgvAddedProducts.DataSource = salesDT;

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
                    //assognto dategrid view values into textboxs.

                    textSearchItems.Text = dgvAddedProducts.Rows[dgvAddedProducts.CurrentCell.RowIndex].Cells[1].Value.ToString();
                    comboBoxUnit.Text = dgvAddedProducts.Rows[dgvAddedProducts.CurrentCell.RowIndex].Cells[2].Value.ToString();
                    textQuantity.Text = dgvAddedProducts.Rows[dgvAddedProducts.CurrentCell.RowIndex].Cells[3].Value.ToString();
                    textRate.Text = dgvAddedProducts.Rows[dgvAddedProducts.CurrentCell.RowIndex].Cells[4].Value.ToString();
                    textDiscount.Text = dgvAddedProducts.Rows[dgvAddedProducts.CurrentCell.RowIndex].Cells[5].Value.ToString();
                    comboGstType.Text = dgvAddedProducts.Rows[dgvAddedProducts.CurrentCell.RowIndex].Cells[6].Value.ToString();
                    textGST.Text = dgvAddedProducts.Rows[dgvAddedProducts.CurrentCell.RowIndex].Cells[7].Value.ToString();
                    textTotalAmount.Text = dgvAddedProducts.Rows[dgvAddedProducts.CurrentCell.RowIndex].Cells[8].Value.ToString();

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

                string gstType = dgvAddedProducts.Rows[dgvAddedProducts.CurrentCell.RowIndex].Cells[6].Value.ToString();

                decimal.TryParse(dgvAddedProducts.Rows[dgvAddedProducts.CurrentCell.RowIndex].Cells[3].Value.ToString(), out Qty);
                decimal.TryParse(dgvAddedProducts.Rows[dgvAddedProducts.CurrentCell.RowIndex].Cells[4].Value.ToString(), out PurchasePrice);
                decimal.TryParse(dgvAddedProducts.Rows[dgvAddedProducts.CurrentCell.RowIndex].Cells[5].Value.ToString(), out discount);
                decimal.TryParse(dgvAddedProducts.Rows[dgvAddedProducts.CurrentCell.RowIndex].Cells[7].Value.ToString(), out gst);
                decimal.TryParse(dgvAddedProducts.Rows[dgvAddedProducts.CurrentCell.RowIndex].Cells[8].Value.ToString(), out TotalAmount);

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

        private void btnAdd_Click(object sender, EventArgs e)
        {


            string pname = "";
            if (comboTransactionType.Text != "")
            {
                //checking product is already present or ot           
                if (comboSearchCust.Text != "Select Cust" && comboSearchCust.Text != "")
                {
                    if (textSearchItems.Text != "")
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
                                if (textSearchItems.Text != pname)
                                {
                                    // get Product name ,Qty, price , Discount ,Tax. Amount to datagrid view

                                    String ProductName = textSearchItems.Text;
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
                                        counter = salesDT.Rows.Count + 1;
                                        decimal gstAmt = Math.Round((((rate * Qty) - ((rate * Qty) * discount) / 100) * GST) / 100, 2);
                                        salesDT.Rows.Add(counter, ProductName, Unit, Qty, rate, discount, gstType, GST, TotalAmount);
                                        //salesDT.Rows.Add(counter, ProductName, Unit, Qty, rate, discount, gstType, GST, TotalAmount);
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


                                        
                                        textSearchItems.Text = "Select Product";
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
            else
            {
                MessageBox.Show("Please Select The Transaction Type First, You Cannot Change the Transaction type during this Transaction");
            }

        }

       

        
        private void comboSearchCust_SelectedIndexChanged(object sender, EventArgs e)
        {


            if (comboSearchCust.Text != "Select Cust")
            {

                //get search keyword from search text box
                string keyword = comboSearchCust.Text;
                if (keyword == "")//clear all textboex
                {
                    comboSearchCust.Text = "Select Cust";
                    textAddress.Text = "";
                    comboContact.Text = "Select Phone";
                    textEmail.Text = "";
                    textGstNo.Text = "";
                    return;
                }
                customerBLL cBLL = customerDAL.searchcustomerByName(keyword);

                comboSearchCust.Text = cBLL.name;
                comboContact.Text = cBLL.contact;
                textEmail.Text = cBLL.email;
                textAddress.Text = cBLL.address;
                textGstNo.Text = cBLL.Gst_No;

            }
            else
            {
                comboSearchCust.Text = "Select Cust";
                textAddress.Text = "";
                comboContact.Text = "Select Phone";
                textEmail.Text = "";
                textGstNo.Text = "";
            }

        }

        private void comboContact_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboContact.Text != "Select Phone")
            {

                //get search keyword from search text box
                string keyword = comboContact.Text;
                if (keyword == "")//clear all textboex
                {
                    comboSearchCust.Text = "Select Cust";
                    textAddress.Text = "";
                    comboContact.Text = "Select Phone";
                    textEmail.Text = "";
                    textGstNo.Text = "";
                    return;
                }
                customerBLL cBLL = customerDAL.searchcustomerByPhone(keyword);

                comboSearchCust.Text = cBLL.name;
                comboContact.Text = cBLL.contact;
                textEmail.Text = cBLL.email;
                textAddress.Text = cBLL.address;
                textGstNo.Text = cBLL.Gst_No;
            }
            else
            {
                comboSearchCust.Text = "Select Cust";
                textAddress.Text = "";
                comboContact.Text = "Select Phone";
                textEmail.Text = "";
                textGstNo.Text = "";
            }

        }

       

        private void comboTransactionType_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboTransactionType.Text == "Non GST")
            {             
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

        private void textQuantity_TextChanged(object sender, EventArgs e)
        {
            string pname = textSearchItems.Text;
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

        private void btnSave_Click(object sender, EventArgs e)
        {

            //Validate Supplier details are there or not 

            if (comboSearchCust.Text != "Select Cust" && comboSearchCust.Text != "")
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
        }


        public void save()
        {

            string sname = comboSearchCust.Text;
            if (comboTransactionType.Text != "")
            {
                if (sname != "" && sname != "Select Cust")
                {
                    string Contact = comboContact.Text;
                    customerBLL cust = customerDAL.getCustomerIdFromContact(Contact);
                    if (cust.contact != comboContact.Text)
                    {

                        customerBLL.name = comboSearchCust.Text;
                        customerBLL.contact = comboContact.Text;
                        customerBLL.email = textEmail.Text;
                        customerBLL.address = textAddress.Text;
                        customerBLL.Gst_No = textGstNo.Text;

                        bool Success = customerDAL.Insert(customerBLL);

                    }

                    if (dgvAddedProducts.Rows.Count != 0)
                    {
                        
                        string CustName = comboSearchCust.Text;
                        customerBLL c = customerDAL.getCustomerIdFromName(CustName);                        

                        decimal subTotal, totalDiscount, totalSgst, totalCgst, totalIgst, grandTotal;

                        string type = comboTransactionType.Text;
                        decimal.TryParse(textSubTotal.Text, out subTotal);
                        decimal.TryParse(textSubDiscount.Text, out totalDiscount);
                        decimal.TryParse(textSgst.Text, out totalSgst);
                        decimal.TryParse(textCgst.Text, out totalCgst);
                        decimal.TryParse(textIgst.Text, out totalIgst);
                        decimal.TryParse(textGrandTotal.Text, out grandTotal);

                        challanBLL.Invoice_No = GetInvoice;
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

                        //int Invoice_No = -1; alredy declared on top 
                        bool b = challanDAL.Update(challanBLL);
                        challandetailsBLL cddBLL = new challandetailsBLL();
                        cddBLL.Invoice_No = GetInvoice;

                        challandetailsDAL.DeleteByInvoiceNo(GetInvoice.ToString());

                        for (int i = 0; i < chDT.Rows.Count; i++)
                        {                          
                            stockBLL stockBLL = new stockBLL();
                            string productName = chDT.Rows[i][0].ToString();
                            ProductMasterBLL p = ProductMasterDAL.GetProductIDFromName(productName);
                            int Product_id = p.Product_ID;
                            stockBLL.Product_Id = Product_id;
                            stockBLL.Quantity = Math.Round(decimal.Parse(chDT.Rows[i][2].ToString()), 2);                            
                            bool x = stockDAL.Update(stockBLL);
                        }

                        for (int i = 0; i < salesDT.Rows.Count; i++)
                        {
                            challandetailsBLL cdBLL = new challandetailsBLL();

                            stockBLL stockBLL = new stockBLL();
                            string productName = salesDT.Rows[i][1].ToString();

                            ProductMasterBLL p = ProductMasterDAL.GetProductIDFromName(productName);
                            cdBLL.Product_ID = p.Product_ID;
                            cdBLL.Invoice_No = GetInvoice;
                            cdBLL.Cust_ID = c.Cust_ID;
                            cdBLL.Product_Name = salesDT.Rows[i][1].ToString();
                            cdBLL.Unit = salesDT.Rows[i][2].ToString();
                            cdBLL.Qty = Math.Round(decimal.Parse(salesDT.Rows[i][3].ToString()), 2);
                            cdBLL.Rate = Math.Round(decimal.Parse(salesDT.Rows[i][4].ToString()), 2);
                            cdBLL.Discount_Per = Math.Round(decimal.Parse(salesDT.Rows[i][5].ToString()), 2);
                            cdBLL.GST_Type = salesDT.Rows[i][6].ToString();
                            cdBLL.GST_Per = Math.Round(decimal.Parse(salesDT.Rows[i][7].ToString()), 2);
                            cdBLL.Total = Math.Round(decimal.Parse(salesDT.Rows[i][8].ToString()), 2);
                            cdBLL.Challan_date = dtpBillDate.Value.Date.Add(dtpBillDate.Value.TimeOfDay);

                            int Product_id = p.Product_ID;
                            stockBLL.Product_Id = Product_id;
                            stockBLL.Quantity = Math.Round(decimal.Parse(salesDT.Rows[i][3].ToString()), 2);
                            stockBLL.Unit = salesDT.Rows[i][2].ToString();

                            bool y = challandetailsDAL.insertchallandetails(cdBLL);

                            if (y == true)
                            {
                                bool x = stockDAL.dereaseUpdate(stockBLL);
                            }

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

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textSearchItems_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                listSearchItems.Show();
                string key = textSearchItems.Text;

                DataTable dtI = ProductMasterDAL.ExactSearch(key);
                //listSearchItems.Items.Clear();
                listSearchItems.DisplayMember = "Product_Name"; // Just set the correct name of the properties 
                listSearchItems.ValueMember = "Product_ID";
                listSearchItems.DataSource = dtI;
                // comboSearchItem.DataSource = dtI;

                if ((e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Scroll))
                {
                    listSearchItems.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void fetchProductDetails()
        {
            try
            {
                string keyword = listSearchItems.Text;
                Int32.TryParse(listSearchItems.SelectedValue.ToString(), out ProductId);
                ProductMasterBLL p = ProductMasterDAL.GetProductsForTransaction(keyword);
                textItemCode.Text = p.Item_Code;
                textSearchItems.Text = p.Product_Name;
                comboBoxUnit.Text = p.Unit;
                textRate.Text = p.Sales_Price.ToString();
                textInventory.Text = p.Quantity.ToString();
                textQuantity.Text = "1";
                listSearchItems.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listSearchItems_MouseClick(object sender, MouseEventArgs e)
        {
            fetchProductDetails();
        }

        private void listSearchItems_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            fetchProductDetails();
        }

        private void listSearchItems_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if ((e.KeyCode == Keys.Enter))
                {
                    fetchProductDetails();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textSearchItems_Enter(object sender, EventArgs e)
        {
            textSearchItems.Text = "";
        }

        private void textSearchItems_Leave(object sender, EventArgs e)
        {
            try
            {
                bool valiDa = textSearchItems.Text.All(c => Char.IsLetterOrDigit(c) || c.Equals('_'));
                if (valiDa == false || textSearchItems.Text == "")
                {
                    textSearchItems.Text = "Select Product";
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
                    listSearchItems.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
    }
}
