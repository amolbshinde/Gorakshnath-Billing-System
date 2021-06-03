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
    public partial class frmChallan : Form
    {
        int Invoice_No = -1;
        int ProductId = -1;      
        

        public frmChallan()
        {
            InitializeComponent();
            fillCombo();
        }
        
        customerBLL customerBLL = new customerBLL();
        customerDAL customerDAL = new customerDAL();

        ProductMasterDAL ProductMasterDAL = new ProductMasterDAL();

        challanBLL challanBLL = new challanBLL();

        challanDAL challanDAL = new challanDAL();

        challandetailsDAL challandetailsDAL = new challandetailsDAL();

        stockDAL stockDAL = new stockDAL();

        DataTable salesDT = new DataTable();

        public void fillCombo()
        {
            comboSearchCust.DataSource = null;
            DataTable dtC = customerDAL.SelectForCombo();
            comboSearchCust.DisplayMember = "Cust_Name";            
            comboSearchCust.DataSource = dtC;
            comboSearchCust.Text = "Select Cust";

            comboContact.DataSource = null;
            DataTable dtP = customerDAL.SelectForCombo();
            comboContact.DisplayMember = "Cust_Contact";
            //comboSearchCust.ValueMember = "Column123";
            comboContact.DataSource = dtP;
            comboContact.Text = "Select Phone";  
        }


        private void getDataComboBox()
        {

            comboItemSearch.DataSource = null;
            DataTable dtI = ProductMasterDAL.ExactSearch("");
            comboItemSearch.DisplayMember = "Product_Name";
            comboItemSearch.ValueMember = "Product_ID";
            comboItemSearch.DataSource = dtI;
            comboItemSearch.Text = "Select Product";
            comboItemSearch.SelectedIndex = -1;

        }

       


        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboTransactionType.Text == "Non GST")
            {
                Clear();
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
                Clear();
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string pname = "";
            if (comboTransactionType.Text != "")
            {
                //checking product is already present or ot           
                if (comboSearchCust.Text != "Select Cust" && comboSearchCust.Text != "")
                {
                    if (comboItemSearch.Text != "")
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
                                if (comboItemSearch.Text != pname)
                                {
                                    // get Product name ,Qty, price , Discount ,Tax. Amount to datagrid view

                                    String ProductName = comboItemSearch.Text;
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
                                        salesDT.Rows.Add(counter, ProductId, ProductName, Unit, Qty, rate, discount, gstType, GST, gstAmt, TotalAmount);
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


                                        comboItemSearch.Text = "Select Product";
                                        //textItemName.Text = "";
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
            txtTrAmount.Text = textGrandTotal.Text;
            if(comboTrType.Text=="CASH")
            {
                txtPaidAmount.Text = textGrandTotal.Text;
                Decimal TrAmount, PaidAmount;
                TrAmount = Convert.ToDecimal(textGrandTotal.Text);
                PaidAmount = Convert.ToDecimal(txtPaidAmount.Text);
                txtBalance.Text = Convert.ToString(TrAmount - PaidAmount);

            }
            else if (comboTrType.SelectedIndex==1)
            {
                txtPaidAmount.Text="00.00";
                Decimal TrAmount, PaidAmount;
                TrAmount = Convert.ToDecimal(textGrandTotal.Text);
                PaidAmount = Convert.ToDecimal(txtPaidAmount.Text);
                txtBalance.Text = Convert.ToString(TrAmount - PaidAmount);

            }

        }

        private void frmChallan_Load(object sender, EventArgs e)
        {
            Clear();
            salesDT.Columns.Add("Sr. No.");
            salesDT.Columns.Add("Product Id");
            salesDT.Columns.Add("Product Name");
            salesDT.Columns.Add("Unit");
            salesDT.Columns.Add("Quantity");
            salesDT.Columns.Add("PurchasePrice");            
            salesDT.Columns.Add("(-)Discount");
            salesDT.Columns.Add("Gst Type");
            salesDT.Columns.Add("(+)GST%");
            salesDT.Columns.Add("(+)GSTAMT");
            salesDT.Columns.Add("(=)Total");
            comboTrType.SelectedIndex=0;
            comboPaymentMode.SelectedIndex = 0;
            comboTransactionType.SelectedIndex = 1;

            getDataComboBox();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Validate Supplier details are there or not 
            if (txtPaidAmount.Text == "")
            {
                MessageBox.Show("Please Enter Paid Amount by Customer");
            }
            else
            {

                if (comboSearchCust.Text != "Select Cust" && comboSearchCust.Text != "")
                {
                    if (dgvAddedProducts.Rows.Count != 0)
                    { 
                        save();
                        //Getting Data from UI
                        SalesPaymentDetailsBLL sp = new SalesPaymentDetailsBLL();
                        sp.TrMode = comboTrType.SelectedItem.ToString();
                        String S = comboTrType.SelectedItem.ToString();
                        //MessageBox.Show(S);
                        sp.PaymentMode = comboPaymentMode.SelectedItem.ToString();
                        decimal TransactionAmt, Paid_Amount, balance;

                        decimal.TryParse(txtTrAmount.Text, out TransactionAmt);
                        decimal.TryParse(txtPaidAmount.Text, out Paid_Amount);
                        decimal.TryParse(txtBalance.Text, out balance);

                        sp.TrAmount = TransactionAmt;
                        sp.AmountPiad = Paid_Amount;
                        sp.Balance = balance;
                        sp.Remarks = "Credit Sales";
                        sp.Invoice_No = Invoice_No;
                        SalesPaymentDetailsDAL dal = new SalesPaymentDetailsDAL();
                        bool success = dal.InsertSalesPayment(sp);
                        /*
                        if (success == true)
                        {
                            //data inserted sucesfully
                            MessageBox.Show("Payment Added Succesfully");

                        }
                        else
                        {
                            //error occured
                            MessageBox.Show("Sorry..!! , Failed to add user");
                        }
                        */
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
                textBox6.Text = Invoice_No.ToString();
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
                        string phone = comboContact.Text;
                        customerBLL c = customerDAL.getCustomerIdFromPhone(phone);

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
                        challanBLL.Challan_date= dtpBillDate.Value.Date.Add(dtpBillDate.Value.TimeOfDay);

                        challanBLL.SalesDetails = salesDT;
                        bool isSuccess = false;

                        // using (TransactionScope scope = new TransactionScope())

                        //int Invoice_No = -1; alredy declared on top 
                        bool b = challanDAL.insertChallan(challanBLL, out Invoice_No);

                                             

                        for (int i = 0; i < salesDT.Rows.Count; i++)
                             {
                                challandetailsBLL cdBLL = new challandetailsBLL();

                                stockBLL stockBLL = new stockBLL();
                                string productName = salesDT.Rows[i][2].ToString();

                                 ProductMasterBLL p = ProductMasterDAL.GetProductIDFromName(productName);
                                 cdBLL.Product_ID = p.Product_ID;
                                cdBLL.Invoice_No = Invoice_No;
                                cdBLL.Cust_ID = c.Cust_ID;
                                 cdBLL.Product_Name = salesDT.Rows[i][2].ToString();
                                 cdBLL.Unit = salesDT.Rows[i][3].ToString();
                                 cdBLL.Qty = Math.Round(decimal.Parse(salesDT.Rows[i][4].ToString()), 2);
                                cdBLL.Rate = Math.Round(decimal.Parse(salesDT.Rows[i][5].ToString()), 2);                                
                                cdBLL.Discount_Per = Math.Round(decimal.Parse(salesDT.Rows[i][6].ToString()), 2);
                                cdBLL.GST_Type =salesDT.Rows[i][7].ToString();
                                cdBLL.GST_Per = Math.Round(decimal.Parse(salesDT.Rows[i][8].ToString()), 2);
                                cdBLL.Total = Math.Round(decimal.Parse(salesDT.Rows[i][10].ToString()), 2);
                            cdBLL.Challan_date= dtpBillDate.Value.Date.Add(dtpBillDate.Value.TimeOfDay);


                            int Product_id = p.Product_ID;
                                stockBLL.Product_Id = Product_id;
                                stockBLL.Quantity = Math.Round(decimal.Parse(salesDT.Rows[i][4].ToString()), 2);
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

        public void Clear()
        {

            comboSearchCust.Text = "Select Cust";
            comboContact.Text = "Select Phone";
            comboItemSearch.Text = "Select Product";            
            textEmail.Text = "";
            textAddress.Text = "";
            textGstNo.Text = "";

            textBox6.Text = "";

            textItemCode.Text = "";            
            //textItemName.Text = "";
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

            comboPaymentMode.Text = "Cash";
            txtTrAmount.Text = "0";
            txtPaidAmount.Text = "0";
            txtBalance.Text = "0";
            

            dgvAddedProducts.DataSource = null;
            dgvAddedProducts.Rows.Clear();
            salesDT.Rows.Clear();
        }

        private void textQuantity_TextChanged(object sender, EventArgs e)
        {
            string pname = comboItemSearch.Text;
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

                if (textQuantity.Text == "" && textQuantity.Text=="0")
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

                for (int i = 0; i < salesDT.Rows.Count; i++)
                {
                    //assognto dategrid view values into textboxs.
                    
                    comboItemSearch.Text = dgvAddedProducts.Rows[dgvAddedProducts.CurrentCell.RowIndex].Cells[2].Value.ToString();
                    comboBoxUnit.Text = dgvAddedProducts.Rows[dgvAddedProducts.CurrentCell.RowIndex].Cells[3].Value.ToString();
                    textQuantity.Text = dgvAddedProducts.Rows[dgvAddedProducts.CurrentCell.RowIndex].Cells[4].Value.ToString();
                    textRate.Text = dgvAddedProducts.Rows[dgvAddedProducts.CurrentCell.RowIndex].Cells[5].Value.ToString();                    
                    textDiscount.Text = dgvAddedProducts.Rows[dgvAddedProducts.CurrentCell.RowIndex].Cells[6].Value.ToString();
                    comboGstType.Text = dgvAddedProducts.Rows[dgvAddedProducts.CurrentCell.RowIndex].Cells[7].Value.ToString();
                    textGST.Text = dgvAddedProducts.Rows[dgvAddedProducts.CurrentCell.RowIndex].Cells[8].Value.ToString();
                    textTotalAmount.Text = dgvAddedProducts.Rows[dgvAddedProducts.CurrentCell.RowIndex].Cells[10].Value.ToString();

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

                decimal.TryParse(dgvAddedProducts.Rows[dgvAddedProducts.CurrentCell.RowIndex].Cells[4].Value.ToString(), out Qty);
                decimal.TryParse(dgvAddedProducts.Rows[dgvAddedProducts.CurrentCell.RowIndex].Cells[5].Value.ToString(), out PurchasePrice);
                decimal.TryParse(dgvAddedProducts.Rows[dgvAddedProducts.CurrentCell.RowIndex].Cells[6].Value.ToString(), out discount);
                decimal.TryParse(dgvAddedProducts.Rows[dgvAddedProducts.CurrentCell.RowIndex].Cells[8].Value.ToString(), out gst);
                decimal.TryParse(dgvAddedProducts.Rows[dgvAddedProducts.CurrentCell.RowIndex].Cells[10].Value.ToString(), out TotalAmount);

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






        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Invoice_No != -1)
            {
                ////Invoice_No = 7;
                frmInvoiceCrpt frmcrpt = new frmInvoiceCrpt(Invoice_No);
                frmcrpt.Show();
            }
            else
            {
                MessageBox.Show("Please Save details first");
            }
        }

        private void label31_MouseClick(object sender, MouseEventArgs e)
        {
            frmProductMaster productMaster = new frmProductMaster();
            productMaster.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label31_Click(object sender, EventArgs e)
        {
            frmProductMaster productMaster = new frmProductMaster();
            productMaster.Show();

        }

        private void label31_Click_1(object sender, EventArgs e)
        {

        }

        private void comboItemSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboItemSearch.Text == "Select Product")
            {

                comboItemSearch.Text = "Select Product";
                textItemCode.Text = "";
                // textItemName.Text = "";
                comboBoxUnit.Text = "";
                textInventory.Text = "0";
                textRate.Text = "0";
                textDiscount.Text = "0";
                textQuantity.Text = "0";
                textGST.Text = "0";
                textTotalAmount.Text = "0";

            }
            else
            {
                string keyword = comboItemSearch.Text;
                if (keyword == "")
                {
                    comboItemSearch.Text = "Select Product";
                    textItemCode.Text = "";
                    //textItemName.Text = "";
                    comboBoxUnit.Text = "";
                    textInventory.Text = "0";
                    textRate.Text = "0";
                    textDiscount.Text = "0";
                    textQuantity.Text = "0";
                    textGST.Text = "0";
                    textTotalAmount.Text = "0";
                    return;
                }
                Int32.TryParse(comboItemSearch.SelectedValue.ToString(), out ProductId);
                ProductMasterBLL p = ProductMasterDAL.GetProductsForTransaction(keyword);
                textItemCode.Text = p.Item_Code;
                comboItemSearch.Text = p.Product_Name;
                comboBoxUnit.Text = p.Unit;
                textRate.Text = p.Sales_Price.ToString();
                textInventory.Text = p.Quantity.ToString();
                //textQuantity.Text = "1";

            }
        }

        private void comboSearchCust_SelectedIndexChanged(object sender, EventArgs e)
        {

            if(comboSearchCust.Text != "Select Cust")
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

        

        private void comboTrType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboTrType.SelectedIndex == 0)
            {
                txtPaidAmount.Text = textGrandTotal.Text;
                Decimal TrAmount, PaidAmount;
                decimal.TryParse(textGrandTotal.Text, out TrAmount);
                decimal.TryParse(txtPaidAmount.Text, out PaidAmount);
                txtBalance.Text = Convert.ToString(TrAmount - PaidAmount);
                txtPaidAmount.ReadOnly = true;

            }
            else if (comboTrType.SelectedIndex == 1)
            {
                txtPaidAmount.Text = "0.00";
                txtPaidAmount.ReadOnly = false;


            }

        }

        private void txtPaidAmount_TextChanged(object sender, EventArgs e)
        {
            if (txtPaidAmount.Text != "")
            {
                Decimal TrAmount, PaidAmount;
                decimal.TryParse(textGrandTotal.Text, out TrAmount);
                decimal.TryParse(txtPaidAmount.Text, out PaidAmount);
                txtBalance.Text = Convert.ToString(TrAmount - PaidAmount);
            }
        }

        private void textItemName_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboItemSearch_TextChanged(object sender, EventArgs e)
        {           

            


        }
    }
}
