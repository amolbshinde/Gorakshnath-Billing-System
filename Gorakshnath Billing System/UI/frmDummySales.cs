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
using DotNetKit;

namespace Gorakshnath_Billing_System.UI
{
    public partial class frmDummySales : Form
    {
        public frmDummySales()
        {
            InitializeComponent();
            fillCombo();
        }
        int Invoice_No = -1;
        int ProductId = -1;

        ProductMasterDAL ProductMasterDAL = new ProductMasterDAL();

        DummySalesBLL challanBLL = new DummySalesBLL();

        DummySalesDAL challanDAL = new DummySalesDAL();

        customerBLL customerBLL = new customerBLL();
        customerDAL customerDAL = new customerDAL();



        DummySalesDetailsDAL DummySalesDetailsDAL = new DummySalesDetailsDAL();

        DataTable salesDT = new DataTable();
        public void getMaxinvoiceId()
        {
            DummySalesDAL dm = new DummySalesDAL();
           int Maxnum = dm.GetMaxInvoiceID();
            Maxnum = Maxnum + 1;
            Invoice_No = Maxnum;
            txtInvoice_No.Text = Invoice_No.ToString();
        } 


        public void fillCombo()
        {
            comboSearchCust.DataSource = null;
            DataTable dtC = customerDAL.SelectForCombo();
            comboSearchCust.DisplayMember = "Cust_Name";
            comboSearchCust.ValueMember = "Cust_Contact";
            comboSearchCust.DataSource = dtC;
            comboSearchCust.Text = "Select Cust";

            comboContact.DataSource = null;
            DataTable dtP = customerDAL.SelectForCombo();
            comboContact.DisplayMember = "Cust_Contact";
            comboContact.ValueMember = "Cust_Contact";
            comboContact.DataSource = dtP;
            comboContact.Text = "NA";

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string pname = "";
            String isAdded = "false";
            
            try
            {
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
                                    if (textSearchItems.Text == pname)
                                    {
                                        isAdded = "true";                                                                            
                                        break;
                                    }
                                }
                                if (isAdded == "false")
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
                                        salesDT.Rows.Add(counter, ProductId, ProductName, Unit, Qty, rate, Amount, discount, gstType, GST, TotalAmount);
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


                                        textSearchItems.Text = "Select Item";
                                        //textItemName.Text = "";
                                        comboBoxUnit.Text = "";
                                        textInventory.Text = "0";
                                        textQuantity.Text = "0";
                                        textRate.Text = "0";
                                        textDiscount.Text = "0";
                                        textQuantity.Text = "0";
                                        textItemCode.Text = "";
                                        if (comboTransactionType.Text != "Non GST")
                                        {
                                            comboGstType.Text = "";
                                            textGST.Text = "0";
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Product is already Added !");

                                }


                            }
                            else
                            {
                                MessageBox.Show("Plsease Select GST type");

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
                    MessageBox.Show("Please Enter Customer Details !");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmDummySales_Load(object sender, EventArgs e)
        {
            Clear();
            salesDT.Columns.Add("Sr. No.");
            salesDT.Columns.Add("Product Id");
            salesDT.Columns.Add("Product Name");
            salesDT.Columns.Add("Unit");
            salesDT.Columns.Add("Quantity");
            salesDT.Columns.Add("Rate");
            salesDT.Columns.Add("Amount");
            salesDT.Columns.Add("(-)Discount");
            salesDT.Columns.Add("Gst Type");
            salesDT.Columns.Add("(+)Tax%");
            salesDT.Columns.Add("(=)Total");
            comboTransactionType.SelectedIndex = 1;
            comboBox2.SelectedIndex = 0;
            listBox1.Hide();
            getMaxinvoiceId();



        }



        private void textRate_TextChanged(object sender, EventArgs e)
        {
            string check = textRate.Text;
            if (check == "")
            {

                MessageBox.Show("Please enter Rate of the product");
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

        private void textDiscount_TextChanged(object sender, EventArgs e)
        {
            string check = textDiscount.Text;
            if (check == "")
            {

                MessageBox.Show("Please Enter Discount.");

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
        public void Clear()
        {

            comboSearchCust.Text = "Select Cust";
            textEmail.Text = "";
            textAddress.Text = "";
            comboContact.Text = "NA";
            textGstNo.Text = "";
            textItemCode.Text = "";
            textSearchItems.Text = "Select Item";
            //textItemName.Text = "";
            comboBoxUnit.Text = "";
            textInventory.Text = "0";
            textQuantity.Text = "0";
            textRate.Text = "0";
            textDiscount.Text = "0";
            textTotalAmount.Text = "0";
            textGrandTotal.Text = "0";
            if (comboTransactionType.Text != "Non GST")
            {
                comboGstType.Text = "";
                textGST.Text = "0";
            }

            textSubTotal.Text = "0";
            textSubDiscount.Text = "0";
            textSgst.Text = "0";
            textCgst.Text = "0";
            textIgst.Text = "0";

            dgvAddedProducts.DataSource = null;
            dgvAddedProducts.Rows.Clear();
            salesDT.Rows.Clear();
            getMaxinvoiceId();

        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
        public int save()
        {
            int TransactionStatus = 0;
            try
            {
                /*if(comboContact.Text != "")
                {
                    comboContact.Text = "NA";
                }*/
                string sname = comboSearchCust.Text;
                if (comboTransactionType.Text != "")
                {
                    if (sname != "" && sname != "Select Cust")
                    {
                        string CustName = comboSearchCust.Text;
                        customerBLL cust = customerDAL.getCustomerIdFromName(CustName);
                        if (cust.name != comboSearchCust.Text)
                        {
                            MessageBox.Show(cust.ToString());
                            customerBLL.name = comboSearchCust.Text;
                            customerBLL.contact = comboContact.Text;
                            customerBLL.email = textEmail.Text;
                            customerBLL.address = textAddress.Text;
                            customerBLL.Gst_No = textGstNo.Text;

                            bool Success = customerDAL.Insert(customerBLL);

                        }


                        if (dgvAddedProducts.Rows.Count != 0)
                        {
                            string CustName1 = comboSearchCust.Text;
                            customerBLL c = customerDAL.getCustomerIdFromName(CustName1);

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
                            challanBLL.Invoice_No = Invoice_No;
                            //DateTime Billdate2 = dtpBillDate.Value.Date.Add(dtpBillDate.Value.TimeOfDay);
                            //DateTime.TryParse(dtpBillDate.Value.ToLongDateString(), out Billdate2);
                            challanBLL.Challan_date = dtpBillDate.Value.Date.Add(dtpBillDate.Value.TimeOfDay);

                            challanBLL.DummySalesDetails = salesDT;
                            bool isSuccess = false;

                            {
                                // int salesid = -1; declared at top as a global variable.
                                bool b = challanDAL.insertDummySales(challanBLL);

                                for (int i = 0; i < salesDT.Rows.Count; i++)
                                {
                                    DummySalesDetailsBLL cdBLL = new DummySalesDetailsBLL();
                                    //string productName = salesDT.Rows[i][2].ToString();

                                    int pid;
                                    Int32.TryParse(salesDT.Rows[i][1].ToString(), out pid);



                                    cdBLL.Invoice_No = Invoice_No;
                                    cdBLL.Product_ID = pid;
                                    cdBLL.Cust_ID = c.Cust_ID;
                                    cdBLL.Product_Name = salesDT.Rows[i][2].ToString();
                                    cdBLL.Unit = salesDT.Rows[i][3].ToString();
                                    cdBLL.Qty = Math.Round(decimal.Parse(salesDT.Rows[i][4].ToString()), 2);
                                    cdBLL.Rate = Math.Round(decimal.Parse(salesDT.Rows[i][5].ToString()), 2);
                                    cdBLL.Discount_Per = Math.Round(decimal.Parse(salesDT.Rows[i][7].ToString()), 2);
                                    cdBLL.GST_Type = salesDT.Rows[i][8].ToString();
                                    cdBLL.GST_Per = Math.Round(decimal.Parse(salesDT.Rows[i][9].ToString()), 2);
                                    cdBLL.Total = Math.Round(decimal.Parse(salesDT.Rows[i][10].ToString()), 2);
                                    cdBLL.Challan_date = dtpBillDate.Value.Date.Add(dtpBillDate.Value.TimeOfDay);
                                    bool y = DummySalesDetailsDAL.insertDummySalesDetails(cdBLL);

                                    if (b == true && y == true)
                                    {
                                        isSuccess = true;
                                    }



                                }

                                if (isSuccess == true)
                                {

                                    MessageBox.Show("Transaction Completed");
                                    TransactionStatus = 1;
                                }
                                else
                                {
                                    MessageBox.Show("Transaction Failed");
                                    TransactionStatus = 0;
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return TransactionStatus;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //Validate Supplier details are there or not 

            if (comboSearchCust.Text != "" && comboSearchCust.Text != "Select Cust")
            {
                if (dgvAddedProducts.Rows.Count != 0)
                {
                    //save fun.
                    int _TransactionStatus = save();
                    if (_TransactionStatus != 0 && Invoice_No != -1)
                    {
                        if (MessageBox.Show("Do you want to print Invoice" + "\n" + "Confirm ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

                        {
                            frmDummySalesCrpt frmDummySalesCrpt = new frmDummySalesCrpt(Invoice_No);
                            frmDummySalesCrpt.Show();
                            Clear();
                        }

                        else

                        {
                            Clear();
                        }



                    }

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

                    textSearchItems.Text = dgvAddedProducts.Rows[dgvAddedProducts.CurrentCell.RowIndex].Cells[2].Value.ToString();
                    comboBoxUnit.Text = dgvAddedProducts.Rows[dgvAddedProducts.CurrentCell.RowIndex].Cells[3].Value.ToString();
                    textQuantity.Text = dgvAddedProducts.Rows[dgvAddedProducts.CurrentCell.RowIndex].Cells[4].Value.ToString();
                    textRate.Text = dgvAddedProducts.Rows[dgvAddedProducts.CurrentCell.RowIndex].Cells[5].Value.ToString();
                    textTotalAmount.Text = dgvAddedProducts.Rows[dgvAddedProducts.CurrentCell.RowIndex].Cells[10].Value.ToString();
                    textDiscount.Text = dgvAddedProducts.Rows[dgvAddedProducts.CurrentCell.RowIndex].Cells[7].Value.ToString();
                    comboGstType.Text = dgvAddedProducts.Rows[dgvAddedProducts.CurrentCell.RowIndex].Cells[8].Value.ToString();
                    textGST.Text = dgvAddedProducts.Rows[dgvAddedProducts.CurrentCell.RowIndex].Cells[9].Value.ToString();
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

                string gstType = dgvAddedProducts.Rows[dgvAddedProducts.CurrentCell.RowIndex].Cells[8].Value.ToString();

                decimal.TryParse(dgvAddedProducts.Rows[dgvAddedProducts.CurrentCell.RowIndex].Cells[4].Value.ToString(), out Qty);
                decimal.TryParse(dgvAddedProducts.Rows[dgvAddedProducts.CurrentCell.RowIndex].Cells[5].Value.ToString(), out PurchasePrice);
                decimal.TryParse(dgvAddedProducts.Rows[dgvAddedProducts.CurrentCell.RowIndex].Cells[7].Value.ToString(), out discount);
                decimal.TryParse(dgvAddedProducts.Rows[dgvAddedProducts.CurrentCell.RowIndex].Cells[9].Value.ToString(), out gst);
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


        private void comboTransactionType_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboTransactionType.Text == "Non GST")
            {
                               
                textItemCode.Text = "";
                textSearchItems.Text = "Select Item";
                //textItemName.Text = "";
                comboBoxUnit.Text = "";
                textInventory.Text = "0";
                textQuantity.Text = "0";
                textRate.Text = "0";
                textDiscount.Text = "0";
                textTotalAmount.Text = "0";
                textGrandTotal.Text = "0";
                if (comboTransactionType.Text != "Non GST")
                {
                    comboGstType.Text = "";
                    textGST.Text = "0";
                }

                textSubTotal.Text = "0";
                textSubDiscount.Text = "0";
                textSgst.Text = "0";
                textCgst.Text = "0";
                textIgst.Text = "0";

                dgvAddedProducts.DataSource = null;
                dgvAddedProducts.Rows.Clear();
                salesDT.Rows.Clear();




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
                label35.Enabled = false;
            }
            else if (comboTransactionType.Text == "GST")
            {


                textItemCode.Text = "";
                textSearchItems.Text = "Select Item";
                //textItemName.Text = "";
                comboBoxUnit.Text = "";
                textInventory.Text = "0";
                textQuantity.Text = "0";
                textRate.Text = "0";
                textDiscount.Text = "0";
                textTotalAmount.Text = "0";
                textGrandTotal.Text = "0";
                if (comboTransactionType.Text != "Non GST")
                {
                    comboGstType.Text = "";
                    textGST.Text = "0";
                }

                textSubTotal.Text = "0";
                textSubDiscount.Text = "0";
                textSgst.Text = "0";
                textCgst.Text = "0";
                textIgst.Text = "0";

                dgvAddedProducts.DataSource = null;
                dgvAddedProducts.Rows.Clear();
                salesDT.Rows.Clear();




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
                label35.Enabled = true;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void comboSearchCust_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboSearchCust.Text != "Select Cust" && comboSearchCust.Text != "")
            {
                //get search keyword from search text box.
                string keyword = comboSearchCust.Text;
                if (keyword == "")//clear all textboex
                {
                    comboSearchCust.Text = "Select Cust";
                    textAddress.Text = "";
                    comboContact.Text = "NA";
                    textEmail.Text = "";
                    textGstNo.Text = "";
                    return;
                }
                customerBLL cBLL = customerDAL.searchcustomerByName(keyword);

                //textCust_Name.Text = cBLL.name;
                comboContact.Text = cBLL.contact;
                textEmail.Text = cBLL.email;
                textAddress.Text = cBLL.address;
                textGstNo.Text = cBLL.Gst_No;
            }
            else
            {
                //textCust_Name.Text = "";
                comboSearchCust.Text = "Select Cust";
                textAddress.Text = "";
                comboContact.Text = "NA";
                textEmail.Text = "";
                textGstNo.Text = "";

            }


        }



        private void comboContact_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboContact.Text != "NA" && comboContact.Text != "")
            {

                //get search keyword from search text box
                string keyword = comboSearchCust.Text;
                if (keyword == "")//clear all textboex
                {
                    comboSearchCust.Text = "Select Cust";
                    textAddress.Text = "";
                    comboContact.Text = "NA";
                    textEmail.Text = "";
                    textGstNo.Text = "";
                    return;
                }
                customerBLL cBLL = customerDAL.searchcustomerByName(keyword);

                //textCust_Name.Text = cBLL.name;

                comboSearchCust.Text = cBLL.name;
                textEmail.Text = cBLL.email;
                textAddress.Text = cBLL.address;
                textGstNo.Text = cBLL.Gst_No;

            }
            else
            {
                //textCust_Name.Text = "";
                comboSearchCust.Text = "Select Cust";
                textAddress.Text = "";
                comboContact.Text = "NA";
                textEmail.Text = "";
                textGstNo.Text = "";
            }

        }

        private void textQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textRate_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        public void fetchProductDetails()
        {
            try
            {
                string keyword = listBox1.Text;
                Int32.TryParse(listBox1.SelectedValue.ToString(), out ProductId);
                ProductMasterBLL p = ProductMasterDAL.GetProductsForTransaction(keyword);
                textItemCode.Text = p.Item_Code;
                textSearchItems.Text = p.Product_Name;
                comboBoxUnit.Text = p.Unit;
                textRate.Text = p.Sales_Price.ToString();
                textInventory.Text = p.Quantity.ToString();
                textQuantity.Text = "1";
                listBox1.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void listBox1_KeyUp(object sender, KeyEventArgs e)
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

        private void textSearchItems_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                listBox1.Show();
                string key = textSearchItems.Text;
                DataTable dtI = ProductMasterDAL.ExactSearch(key);
                listBox1.DisplayMember = "Product_Name"; // Just set the correct name of the properties 
                listBox1.ValueMember = "Product_ID";
                listBox1.DataSource = dtI;
                if ((e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Scroll))
                {
                    listBox1.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            fetchProductDetails();
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            fetchProductDetails();
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
                    listBox1.Hide();
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

        private void comboContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }


}
