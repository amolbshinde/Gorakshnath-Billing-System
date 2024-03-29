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
    public partial class frmPurchaseManage : Form
    {
        int GetPurchase_Id;
        int ProductId = -1;
        public frmPurchaseManage(int Purchase_Id)
        {
            InitializeComponent();
            fillCombo();
            int i = 1;

            while (i == 1)
            {
                GetPurchase_Id = Purchase_Id;
                i++;
            }
        }

        SupplierMasterBLL SupplierMasterBLL = new SupplierMasterBLL();
        SupplierMasterDAL SupplierMasterDAL = new SupplierMasterDAL();

        ProductMasterDAL ProductMasterDAL = new ProductMasterDAL();

        purchaseBLL purchaseBLL = new purchaseBLL();

        purchaseDAL purchaseDAL = new purchaseDAL();

        purchasedetailsDAL purchasedetailsDAL = new purchasedetailsDAL();

        stockDAL stockDAL = new stockDAL();

        DataTable salesDT = new DataTable();
        DataTable chDT = new DataTable();

        public void fillCombo()
        {
            comboSearchSup.DataSource = null;
            DataTable dtC = SupplierMasterDAL.SelectForCombo();
            comboSearchSup.DisplayMember = "CompanyName";
            comboSearchSup.DataSource = dtC;
            comboSearchSup.Text = "Select Sup";

        }

        private void frmPurchaseManage_Load(object sender, EventArgs e)
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

            comboSearchSup.Text = "Select Sup";
            
            //comboItemSearch.Text = "Select Product";
            comboContact.Text = "";
            textItemCode.Text = "";
            textSearchItems.Text = "Select Product";
            comboBoxUnit.Text = "";
            textInventory.Text = "0";
            textQuantity.Text = "0";
            textPurchasePrice.Text = "0";
            textDiscount.Text = "0";

            if (comboTransactionType.Text != "Non GST")
            {
                comboGstType.Text = "";
                textGST.Text = "0";
            }


            //MessageBox.Show(GetInvoice.ToString());
            textInvoiceNo.Text = GetPurchase_Id.ToString();

            DataTable dtc = purchaseDAL.SelectByPurchaseIdManage(GetPurchase_Id.ToString());
            comboSearchSup.Text = dtc.Rows[0][1].ToString();
            comboContact.Text = dtc.Rows[0][2].ToString();
            textEmail.Text = dtc.Rows[0][3].ToString();
            textAddress.Text = dtc.Rows[0][4].ToString();
            comboTransactionType.Text = dtc.Rows[0][5].ToString();
            textSubTotal.Text = dtc.Rows[0][6].ToString();
            textSubDiscount.Text = dtc.Rows[0][7].ToString();
            textSgst.Text = dtc.Rows[0][8].ToString();
            textCgst.Text = dtc.Rows[0][9].ToString();
            textIgst.Text = dtc.Rows[0][10].ToString();
            textGrandTotal.Text = dtc.Rows[0][11].ToString();
            textGSTNo.Text= dtc.Rows[0][12].ToString();


            chDT = purchasedetailsDAL.SelectByPurchaseId(GetPurchase_Id.ToString());
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
                    textPurchasePrice.Text = dgvAddedProducts.Rows[dgvAddedProducts.CurrentCell.RowIndex].Cells[4].Value.ToString();
                    textDiscount.Text = dgvAddedProducts.Rows[dgvAddedProducts.CurrentCell.RowIndex].Cells[5].Value.ToString();
                    comboGstType.Text = dgvAddedProducts.Rows[dgvAddedProducts.CurrentCell.RowIndex].Cells[6].Value.ToString();
                    textGST.Text = dgvAddedProducts.Rows[dgvAddedProducts.CurrentCell.RowIndex].Cells[7].Value.ToString();
                    textTotalAmount.Text = dgvAddedProducts.Rows[dgvAddedProducts.CurrentCell.RowIndex].Cells[8].Value.ToString();

                }


                decimal Qty, PurchasePrice, discount, Amount, gst, TotalAmount;
                decimal.TryParse(textQuantity.Text, out Qty);
                decimal.TryParse(textPurchasePrice.Text, out PurchasePrice);
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
                if (comboSearchSup.Text != "Select Cust" && comboSearchSup.Text != "")
                {
                    if (textSearchItems.Text != "Select Product" && textSearchItems.Text!="")
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
                                    decimal.TryParse(textPurchasePrice.Text, out rate);
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


                                        //comboItemSearch.Text = "Select Product";
                                        textSearchItems.Text = "Select Product";
                                        comboBoxUnit.Text = "";
                                        textInventory.Text = "0";
                                        textQuantity.Text = "0";
                                        textPurchasePrice.Text = "0";
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

        private void comboSearchSup_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboSearchSup.Text != "Select Sup")
            {
                string keyword = comboSearchSup.Text;
                if (keyword == "")//clear all textboex
                {
                    comboSearchSup.Text = "Select Sup";
                    textAddress.Text = "";
                    comboContact.Text = "";
                    textEmail.Text = "";
                    textGSTNo.Text = "";
                    return;
                }

                SupplierMasterBLL smBLL = SupplierMasterDAL.SearchSupplierByName(keyword);

                comboSearchSup.Text = smBLL.CompanyName;
                comboContact.Text = smBLL.Phone_No;
                textEmail.Text = smBLL.Email;
                textAddress.Text = smBLL.Address;
                textGSTNo.Text = smBLL.Gst_No;
            }
            else
            {
                comboSearchSup.Text = "Select Sup";
                textAddress.Text = "";
                comboContact.Text = "";
                textEmail.Text = "";
                textGSTNo.Text = "";
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
            if (textQuantity.Text == "" && textQuantity.Text == "0")
            {
                textTotalAmount.Text = "0";
            }
            else
            {
                decimal Qty, Rate, discount, gst;
                decimal.TryParse(textQuantity.Text, out Qty);
                decimal.TryParse(textPurchasePrice.Text, out Rate);
                decimal.TryParse(textDiscount.Text, out discount);
                decimal.TryParse(textGST.Text, out gst);

                decimal TotalAmount = Math.Round(((100 + gst) / 100) * (((100 - discount) / 100) * (Rate * Qty)), 2);

                textTotalAmount.Text = TotalAmount.ToString();

            }
        }

        private void textPurchasePrice_TextChanged(object sender, EventArgs e)
        {
            string check = textPurchasePrice.Text;
            if (check == "" && check == "0")
            {
                MessageBox.Show("Please entery Purchase Price.");
                textTotalAmount.Text = "0";
            }


            else
            {
                decimal Qty, Rate, discount, gst;
                decimal.TryParse(textQuantity.Text, out Qty);
                decimal.TryParse(textPurchasePrice.Text, out Rate);
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
                decimal.TryParse(textPurchasePrice.Text, out Rate);
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
                decimal.TryParse(textPurchasePrice.Text, out Rate);
                decimal.TryParse(textDiscount.Text, out discount);
                decimal.TryParse(textGST.Text, out gst);

                decimal TotalAmount = Math.Round(((100 + gst) / 100) * (((100 - discount) / 100) * (Rate * Qty)), 2);

                textTotalAmount.Text = TotalAmount.ToString();

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (comboSearchSup.Text != "Select Cust" && comboSearchSup.Text != "")
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

            string sname = comboSearchSup.Text;
            if (comboTransactionType.Text != "")
            {
                if (sname != "" && sname != "Select Cust")
                {

                    if (dgvAddedProducts.Rows.Count != 0)
                    {
                        string Contact = comboContact.Text;
                        SupplierMasterBLL s = SupplierMasterDAL.getSuplierIdFromPhone(Contact);

                        decimal subTotal, totalDiscount, totalSgst, totalCgst, totalIgst, grandTotal;

                        string type = comboTransactionType.Text;
                        decimal.TryParse(textSubTotal.Text, out subTotal);
                        decimal.TryParse(textSubDiscount.Text, out totalDiscount);
                        decimal.TryParse(textSgst.Text, out totalSgst);
                        decimal.TryParse(textCgst.Text, out totalCgst);
                        decimal.TryParse(textIgst.Text, out totalIgst);
                        decimal.TryParse(textGrandTotal.Text, out grandTotal);

                        purchaseBLL.Purchase_ID = GetPurchase_Id;
                        purchaseBLL.Transaction_Type = type;
                        purchaseBLL.Sup_ID = s.SupplierID;
                        purchaseBLL.Sub_Total = subTotal;
                        purchaseBLL.TDiscount = totalDiscount;
                        purchaseBLL.TSGST = totalSgst;
                        purchaseBLL.TCGST = totalCgst;
                        purchaseBLL.TIGST = totalIgst;
                        purchaseBLL.Grand_Total = grandTotal;

                        purchaseBLL.PurchaseDetails = salesDT;
                        bool isSuccess = false;

                        // using (TransactionScope scope = new TransactionScope())

                        //int Invoice_No = -1; alredy declared on top 
                        bool b = purchaseDAL.Update(purchaseBLL);
                        purchasedetailsBLL cddBLL = new purchasedetailsBLL();
                        cddBLL.Purchase_ID = GetPurchase_Id;

                        purchasedetailsDAL.DeleteByPurchaseID(GetPurchase_Id.ToString());

                        for (int i = 0; i < chDT.Rows.Count; i++)
                        {
                            stockBLL stockBLL = new stockBLL();
                            string productName = chDT.Rows[i][0].ToString();
                            ProductMasterBLL p = ProductMasterDAL.GetProductIDFromName(productName);
                            int Product_id = p.Product_ID;
                            stockBLL.Product_Id = Product_id;
                            stockBLL.Quantity = Math.Round(decimal.Parse(chDT.Rows[i][2].ToString()), 2);
                            bool x = stockDAL.dereaseUpdate(stockBLL);
                        }

                        for (int i = 0; i < salesDT.Rows.Count; i++)
                        {
                            purchasedetailsBLL cdBLL = new purchasedetailsBLL();

                            stockBLL stockBLL = new stockBLL();
                            string productName = salesDT.Rows[i][1].ToString();

                            ProductMasterBLL p = ProductMasterDAL.GetProductIDFromName(productName);
                            cdBLL.Product_ID = p.Product_ID;
                            cdBLL.Purchase_ID = GetPurchase_Id;
                            cdBLL.Sup_ID = s.SupplierID;
                            cdBLL.Product_Name = salesDT.Rows[i][1].ToString();
                            cdBLL.Unit = salesDT.Rows[i][2].ToString();
                            cdBLL.Qty = Math.Round(decimal.Parse(salesDT.Rows[i][3].ToString()), 2);
                            cdBLL.Rate = Math.Round(decimal.Parse(salesDT.Rows[i][4].ToString()), 2);
                            cdBLL.Discount_Per = Math.Round(decimal.Parse(salesDT.Rows[i][5].ToString()), 2);
                            cdBLL.GST_Type = salesDT.Rows[i][6].ToString();
                            cdBLL.GST_Per = Math.Round(decimal.Parse(salesDT.Rows[i][7].ToString()), 2);
                            cdBLL.Total = Math.Round(decimal.Parse(salesDT.Rows[i][8].ToString()), 2);

                            int Product_id = p.Product_ID;
                            stockBLL.Product_Id = Product_id;
                            stockBLL.Quantity = Math.Round(decimal.Parse(salesDT.Rows[i][3].ToString()), 2);
                            stockBLL.Unit = salesDT.Rows[i][2].ToString();

                            bool y = purchasedetailsDAL.insertpurchasedetails(cdBLL);                            

                            if (y == true)
                            {
                                bool x = stockDAL.Update(stockBLL);
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
                textPurchasePrice.Text = p.Sales_Price.ToString();
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
                    textPurchasePrice.Text = "0";
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Clear()
        {

            comboSearchSup.Text = "Select Sup";
            textSearchItems.Text = "Select Product";
            textEmail.Text = "";
            textAddress.Text = "";
            comboContact.Text = "Select Phone";
            textGSTNo.Text = "";

            textItemCode.Text = "";

            //textItemName.Text = "";
            comboBoxUnit.Text = "";
            textInventory.Text = "0";
            textQuantity.Text = "0";
            textPurchasePrice.Text = "0";
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
            dgvAddedProducts.Rows.Clear();            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}
