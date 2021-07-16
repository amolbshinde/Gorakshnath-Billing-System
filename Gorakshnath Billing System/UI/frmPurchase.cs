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
            fillCombo();
        }
        int purchaseid = -1;
        int ProductId = -1;
        bool isSuccess = false;
        public void getMaxPurchaseId()
        {
            int maxnum = purchaseDAL.getMaxPurchaseId();
            if (maxnum <0)
            {
                maxnum = 0;
                return;
            }
            maxnum = maxnum + 1;
            purchaseid = maxnum;
        }

        SupplierMasterBLL SupplierMasterBLL = new SupplierMasterBLL();
        SupplierMasterDAL SupplierMasterDAL = new SupplierMasterDAL();
        
        DataTable purchasedt = new DataTable();

        purchaseDAL purchaseDAL = new purchaseDAL();


        purchasedetailsDAL pdetailsDAL = new purchasedetailsDAL();

        ProductMasterDAL ProductMasterDAL = new ProductMasterDAL();
        

        stockDAL stockDAL = new stockDAL();

        PurchasePaymentDetailsBLL PurchasePaymentDetailsBLL = new PurchasePaymentDetailsBLL();
        PurchasePaymentDetailsDAL PurchasePaymentDetailsDAL = new PurchasePaymentDetailsDAL();

        public void fillCombo()
        {
            comboSearchSup.DataSource = null;
            DataTable dtC = SupplierMasterDAL.SelectForCombo();
            comboSearchSup.DisplayMember = "CompanyName";
            comboSearchSup.DataSource = dtC;
            comboSearchSup.Text = "Select Sup";

            comboContact.DataSource = null;
            DataTable dtP = SupplierMasterDAL.SelectForCombo();
            comboContact.DisplayMember = "Phone_No";
            comboContact.DataSource = dtP;
            comboContact.Text = "Select Phone";

            

        }


        //hello this 
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {
         //get search keyword from search text box
            string keyword = comboSearchSup.Text;
            if (keyword == "")//clear all textboex
            {
                comboSearchSup.Text = "Select Sup";
                textAddress.Text = "";
                comboContact.Text = "Select Phone";
                textEmail.Text = "";
                textGSTNo.Text = "";
                return;
            }

            SupplierMasterBLL smBLL = SupplierMasterDAL.SearchSupplierByName(keyword);

            comboSearchSup.Text = smBLL.CompanyName;
            comboContact.Text = smBLL.Phone_No;
            textEmail.Text = smBLL.Email;
            textAddress.Text =smBLL.Address;
            textGSTNo.Text = smBLL.Gst_No;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // CHECK PRODUCT IS SELECTED OR NOT.. 
            
            //if (textItemName.Text != "")
            if (textSearchItems.Text!="Select Product")
                {
                if(textQuantity.Text!="" && textQuantity.Text!="0")
                {

                        String ProductName = textSearchItems.Text;
                        String Unit = comboBoxUnit.Text;
                        string gstType = comboGstType.Text;
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
                        purchasedt.Rows.Add(no,ProductId, ProductName, Unit, Qty, PurchasePrice, Amount, discount,gstType, gst, TotalAmount);
                        dgvAddedProducts.DataSource = purchasedt;
                        dgvAddedProducts.AutoResizeColumns();


                        decimal subTotal;
                        decimal.TryParse(textSubTotal.Text, out subTotal);
                        subTotal = subTotal + Qty * PurchasePrice;
                        textSubTotal.Text = subTotal.ToString();

                        decimal subDiscount;
                        decimal.TryParse(textSubDiscount.Text, out subDiscount);
                        subDiscount = subDiscount + Math.Round(((PurchasePrice * Qty) * discount) / 100,2);
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
                            subGst = subGst + Math.Round((((PurchasePrice * Qty)-((PurchasePrice * Qty) * discount) / 100) * gst) / 100,2);

                            textSgst.Text = Math.Round((subGst / 2),2).ToString();
                            textCgst.Text = Math.Round((subGst / 2),2).ToString();
                        }
                        if (comboGstType.Text == "IGST")
                        {
                            decimal subIGst;
                            decimal.TryParse(textIgst.Text, out subIGst);
                            subIGst = subIGst + Math.Round((((PurchasePrice * Qty) - ((PurchasePrice * Qty) * discount) / 100) * gst) / 100,2);
                            textIgst.Text = subIGst.ToString();
                        }
                        textItemCode.Text = "";
                    textSearchItems.Text = "Select Product";
                        //textItemName.Text = "";
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
                    MessageBox.Show("Please Enter Quantity");
                }
            }
            else
            {
                MessageBox.Show("Please Enter Item/Product Details");                
            }

            if (comboTrMode.SelectedIndex == 0)
            {


                txtTrAmount.Text = textGrandTotal.Text;
                txtPaidAmount.Text = textGrandTotal.Text;                
                txtBalance.Text = "00.00";
               

            }
            else if (comboTrMode.SelectedIndex == 1)
            {
                txtTrAmount.Text = textGrandTotal.Text;
                txtPaidAmount.Text = "00.00";
                txtPaidAmount.ReadOnly=false;
                Decimal TrAmount, PaidAmount;
                decimal.TryParse(textGrandTotal.Text, out TrAmount);
                decimal.TryParse(txtPaidAmount.Text, out PaidAmount);
                txtBalance.Text = Convert.ToString(TrAmount - PaidAmount);

            }

            

        }


        private void textItemSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = textSearchItems.Text;


            if (keyword == "")
            {
                //textItemName.Text = "";
                textInventory.Text = "0";
                textPurchasePrice.Text = "0";
                textQuantity.Text = "0";
                textDiscount.Text = "0";
                textGst.Text = "0";
                return;
            }
            
            ProductMasterBLL p = ProductMasterDAL.GetProductsForTransaction(keyword);
            textItemCode.Text = p.Item_Code;
            //textItemName.Text = p.Product_Name;
            comboBoxUnit.Text = p.Unit;
            textPurchasePrice.Text = p.Purchase_Price.ToString();
            textInventory.Text = p.Quantity.ToString();
        }

        

        private void frmPurchase_Load(object sender, EventArgs e)
        {
            Clear();
            //specify columns to our dataTable 
            purchasedt.Columns.Add("Sr.No.");
            purchasedt.Columns.Add("Product Id");
            purchasedt.Columns.Add("Product Name");
            purchasedt.Columns.Add("Unit");
            purchasedt.Columns.Add("Quantity");
            purchasedt.Columns.Add("Purchase Price");
            purchasedt.Columns.Add("Amount");
            purchasedt.Columns.Add("(-)Discount");
            purchasedt.Columns.Add("Gst Type");
            purchasedt.Columns.Add("(+)Tax%");
            purchasedt.Columns.Add("(=)Total");
            //purchasedt.Columns.Add("Product Id");
            txtTrAmount.ReadOnly = true;
            comboTrMode.SelectedIndex = 0;
            comboTrType.SelectedIndex = 0;
            comboPurchaseType.SelectedIndex = 1;
            comboGstType.SelectedIndex = 0;
            listSearchItems.Hide();
            getMaxPurchaseId();
            textPurchaseBillNo.Text = purchaseid.ToString();
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

            string sname = comboSearchSup.Text;
            if (comboPurchaseType.Text != "")
            {
                if(sname != "" && sname != "Select Sup")
                {

                    string CompanyName1 = comboSearchSup.Text;
                    SupplierMasterBLL sup = SupplierMasterDAL.getSuplierIdFromName(CompanyName1);
                    if (sup.CompanyName!= comboSearchSup.Text)
                    {

                        SupplierMasterBLL.CompanyName = comboSearchSup.Text;
                        SupplierMasterBLL.Phone_No = comboContact.Text;
                        SupplierMasterBLL.Email = textEmail.Text;
                        SupplierMasterBLL.Address = textAddress.Text;
                        SupplierMasterBLL.Gst_No = textGSTNo.Text;

                        bool Success = SupplierMasterDAL.InsertByPurchasebill(SupplierMasterBLL);

                    }
                   
                    if (dgvAddedProducts.Rows.Count!=0)
                    {
                        SupplierMasterBLL s = SupplierMasterDAL.getSuplierIdFromName(CompanyName1);

                        decimal subTotal, totalDiscount, totalSgst, totalCgst, totalIgst, grandTotal;

                        string type = comboPurchaseType.Text;
                        decimal.TryParse(textSubTotal.Text, out subTotal);
                        decimal.TryParse(textSubDiscount.Text, out totalDiscount);
                        decimal.TryParse(textSgst.Text, out totalSgst);
                        decimal.TryParse(textCgst.Text, out totalCgst);
                        decimal.TryParse(textIgst.Text, out totalIgst);
                        decimal.TryParse(textGrandTotal.Text, out grandTotal);

                        purchaseBLL.Transaction_Type = type;
                        purchaseBLL.Sup_ID = s.SupplierID;
                        purchaseBLL.Sub_Total = subTotal;
                        purchaseBLL.TDiscount = totalDiscount;
                        purchaseBLL.TSGST = totalSgst;
                        purchaseBLL.TCGST = totalCgst;
                        purchaseBLL.TIGST = totalIgst;
                        purchaseBLL.Grand_Total = grandTotal;
                        purchaseBLL.Purchase_ID = purchaseid;
                        purchaseBLL.PurchaseDetails = purchasedt;
                        

                        // using (TransactionScope scope = new TransactionScope())
                        
                           //int purchaseid = -1; already declaraed at the top as a global variable.

                            bool b = purchaseDAL.insertpurchase(purchaseBLL);
                            for (int i = 0; i < purchasedt.Rows.Count; i++)
                            {
                                purchasedetailsBLL pdBLL = new purchasedetailsBLL();

                                stockBLL stockBLL = new stockBLL();
                                int pid;
                                Int32.TryParse(purchasedt.Rows[i][1].ToString(),out pid);
                                //string productName = purchasedt.Rows[i][2].ToString();
                                //ProductMasterBLL p = ProductMasterDAL.GetProductIDFromName(productName);
                            //MessageBox.Show(productName);


                                pdBLL.Purchase_ID = purchaseid;
                                pdBLL.Product_ID = pid;
                                pdBLL.Sup_ID = s.SupplierID;
                                pdBLL.Product_Name = purchasedt.Rows[i][2].ToString();
                                pdBLL.Unit = purchasedt.Rows[i][3].ToString();
                                pdBLL.Qty = Math.Round(decimal.Parse(purchasedt.Rows[i][4].ToString()), 2);
            
                                pdBLL.Rate = Math.Round(decimal.Parse(purchasedt.Rows[i][5].ToString()), 2);
                                pdBLL.Discount_Per = Math.Round(decimal.Parse(purchasedt.Rows[i][7].ToString()), 2);
                                pdBLL.GST_Type = purchasedt.Rows[i][8].ToString();
                                pdBLL.GST_Per = Math.Round(decimal.Parse(purchasedt.Rows[i][9].ToString()), 2);
                                pdBLL.Total = Math.Round(decimal.Parse(purchasedt.Rows[i][10].ToString()), 2);
                                

                                int Product_id = pid;
                                stockBLL.Product_Id = Product_id;
                                stockBLL.Quantity= Math.Round(decimal.Parse(purchasedt.Rows[i][4].ToString()), 2);
                                stockBLL.Unit = purchasedt.Rows[i][3].ToString();

                                bool y = pdetailsDAL.insertpurchasedetails(pdBLL);                            
                                
                                if(y==true)
                                {
                                    stockBLL Padded = stockDAL.CheakeProductAddedOrNot(Product_id);
                                    //MessageBox.Show("Product is added",Padded.Product_Id.ToString());
                                    if (Product_id == Padded.Product_Id)
                                    {
                                        bool x = stockDAL.Update(stockBLL);
                                    }
                                    else
                                    {
                                        bool z = stockDAL.InsertStockNewProduct(stockBLL);
                                    }

                                
                            }

                                if(b==true&&y==true)
                            {
                                isSuccess = true;
                            }else
                            {
                                isSuccess = false;
                            }

                            



                                
                            }
                            if (isSuccess == true)
                            {
                            //scope.Complete();
                            //Getting Data from UI                                
                            PurchasePaymentDetailsBLL.TrMode = comboTrMode.SelectedItem.ToString();
                            String S = comboTrType.SelectedItem.ToString();
                            //MessageBox.Show(S);
                            PurchasePaymentDetailsBLL.PaymentMode = comboTrType.SelectedItem.ToString();
                            decimal TransactionAmt, Paid_Amount, balance;

                            decimal.TryParse(txtTrAmount.Text, out TransactionAmt);
                            decimal.TryParse(txtPaidAmount.Text, out Paid_Amount);
                            decimal.TryParse(txtBalance.Text, out balance);

                            PurchasePaymentDetailsBLL.TrAmount = TransactionAmt;
                            PurchasePaymentDetailsBLL.AmountPiad = Paid_Amount;
                            PurchasePaymentDetailsBLL.Balance = balance;
                            PurchasePaymentDetailsBLL.Remarks = "Credit Sales";
                            PurchasePaymentDetailsBLL.Invoice_No = purchaseid;
                            //bool success = 
                            PurchasePaymentDetailsDAL.InsertSalesPayment(PurchasePaymentDetailsBLL);
                            
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

        private void button1_Click(object sender, EventArgs e)
        {
            getMaxPurchaseId();
            save();
           
           

            if (purchaseid != -1 &&  isSuccess != false)
            {
                if (MessageBox.Show("Do you want to print Purchase Bill" + "\n" + "Confirm ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    frmPurchaseCrpt purchaseCrpt = new frmPurchaseCrpt(purchaseid);
                    purchaseCrpt.Show();
                    Clear();
                }else
                {
                    Clear(); 
                }
                    
            }

            
           // getMaxPurchaseId();

        }

        private void dgvAddedProducts_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button==MouseButtons.Left)
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
        private void my_menu_ItemClicked(object sender,ToolStripItemClickedEventArgs e)
        {
            if ("Edit" == e.ClickedItem.Name.ToString())
            {              

                for (int i = 0; i < purchasedt.Rows.Count; i++)
                {
                    //assognto dategrid view values into textboxs

                    textSearchItems.Text = dgvAddedProducts.Rows[dgvAddedProducts.CurrentCell.RowIndex].Cells[2].Value.ToString();
                    comboBoxUnit.Text = dgvAddedProducts.Rows[dgvAddedProducts.CurrentCell.RowIndex].Cells[3].Value.ToString();
                    textQuantity.Text = dgvAddedProducts.Rows[dgvAddedProducts.CurrentCell.RowIndex].Cells[4].Value.ToString();
                    textPurchasePrice.Text = dgvAddedProducts.Rows[dgvAddedProducts.CurrentCell.RowIndex].Cells[5].Value.ToString();
                    textTotalAmount.Text = dgvAddedProducts.Rows[dgvAddedProducts.CurrentCell.RowIndex].Cells[10].Value.ToString();
                    textDiscount.Text = dgvAddedProducts.Rows[dgvAddedProducts.CurrentCell.RowIndex].Cells[7].Value.ToString();
                    comboGstType.Text = dgvAddedProducts.Rows[dgvAddedProducts.CurrentCell.RowIndex].Cells[8].Value.ToString();
                    textGst.Text = dgvAddedProducts.Rows[dgvAddedProducts.CurrentCell.RowIndex].Cells[9].Value.ToString();                   
                }

                decimal Qty, PurchasePrice, discount, Amount, gst, TotalAmount;
                decimal.TryParse(textQuantity.Text, out Qty);
                decimal.TryParse(textPurchasePrice.Text, out PurchasePrice);
                decimal.TryParse(textDiscount.Text, out discount);
                decimal.TryParse(textGst.Text, out gst);
                decimal.TryParse(textTotalAmount.Text, out TotalAmount);

                Amount = PurchasePrice * Qty;                

                decimal subTotal;
                decimal.TryParse(textSubTotal.Text, out subTotal);
                subTotal = subTotal - Qty * PurchasePrice;
                textSubTotal.Text = subTotal.ToString();

                decimal subDiscount;
                decimal.TryParse(textSubDiscount.Text, out subDiscount);
                subDiscount = subDiscount - Math.Round(((PurchasePrice * Qty) * discount) / 100,2);
                textSubDiscount.Text = subDiscount.ToString();
                
                if (comboGstType.Text == "SGST/CGST")
                {
                    decimal subsgst, subcgst, subGst;
                    decimal.TryParse(textSgst.Text, out subsgst);
                    decimal.TryParse(textCgst.Text, out subcgst);
                    subGst = subsgst + subcgst;
                    subGst = subGst - Math.Round((((((100 - discount) / 100) * (PurchasePrice * Qty))) * gst) / 100,2);

                    textSgst.Text = Math.Round((subGst / 2),2).ToString();
                    textCgst.Text = Math.Round((subGst / 2),2).ToString();
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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void comboPurchaseType_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboPurchaseType.SelectedIndex==1)
            {
                comboGstType.Enabled = false;
                textGst.Enabled = false;
                textCgst.Enabled = false;
                textSgst.Enabled = false;
                textIgst.Enabled = false;
                comboGstType.SelectedIndex = 0;
                //comboGstType.Text = "NA"
                textGst.Text = "0";
                textCgst.Text = "0";
                textSgst.Text = "0";
                textIgst.Text = "0";
                label32.Enabled = false;
                label34.Enabled = false;
                label36.Enabled = false;
                label18.Enabled = false;
                label35.Enabled = false;
            }
            else if (comboPurchaseType.SelectedIndex==0)
            {
                comboGstType.Enabled = true;
                textGst.Enabled = true;
                textCgst.Enabled = true;
                textSgst.Enabled = true;
                textIgst.Enabled = true;
               // comboGstType.Text = "";

                label32.Enabled = true;
                label34.Enabled = true;
                label36.Enabled = true;
                label18.Enabled = true;
                label35.Enabled = true;
                comboGstType.SelectedIndex = 0;
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
                    comboContact.Text = "Select Phone";
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
                comboContact.Text = "Select Phone";
                textEmail.Text = "";
                textGSTNo.Text = "";
            }
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

            if (comboPurchaseType.Text != "Non GST")
            {
                comboGstType.Text = "";
                textGst.Text = "0";
            }

            textTotalAmount.Text = "0";

            textSubTotal.Text = "0";
            textSubDiscount.Text = "0";
            textSgst.Text = "0";
            textCgst.Text = "0";
            textIgst.Text = "0";
            textGrandTotal.Text = "0";

            comboTrType.Text = "Cash";
            txtTrAmount.Text = "0";
            txtPaidAmount.Text = "0";
            txtBalance.Text = "0";

            dgvAddedProducts.DataSource = null;
            dgvAddedProducts.Rows.Clear();
            purchasedt.Rows.Clear();
            getMaxPurchaseId();
        }

        private void comboContact_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboContact.Text != "Select Phone")
            {
                string keyword = comboContact.Text;
                if (keyword == "")//clear all textboex
                {
                    comboSearchSup.Text = "Select Sup";
                    textAddress.Text = "";
                    comboContact.Text = "Select Phone";
                    textEmail.Text = "";
                    textGSTNo.Text = "";
                    return;
                }

                SupplierMasterBLL smBLL = SupplierMasterDAL.SearchSupplierByPhone(keyword);

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
                comboContact.Text = "Select Phone";
                textEmail.Text = "";
                textGSTNo.Text = "";
                //---
            }

        }

        private void comboTrMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboTrMode.SelectedIndex == 0)
            {
                txtPaidAmount.Text = txtTrAmount.Text;
                txtPaidAmount.ReadOnly = true;
                txtTrAmount.ReadOnly = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Clear();//
        }

        private void txtPaidAmount_TextChanged(object sender, EventArgs e)
        {
            Decimal TrAmount, PaidAmount;
            decimal.TryParse(textGrandTotal.Text, out TrAmount);
            decimal.TryParse(txtPaidAmount.Text, out PaidAmount);
            txtBalance.Text = Convert.ToString(TrAmount - PaidAmount);
        }

        private void comboGstType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

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
                    if (comboTrMode.Text != "Non GST")
                    {
                        comboGstType.Text = "";
                        textGst.Text = "0";
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
