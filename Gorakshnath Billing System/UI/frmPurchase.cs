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
        }
        int purchaseid = -1;

        SupplierMasterDAL smDAL = new SupplierMasterDAL();
        
        DataTable purchasedt = new DataTable();

        purchaseDAL purchaseDAL = new purchaseDAL();


        purchasedetailsDAL pdetailsDAL = new purchasedetailsDAL();

        ProductMasterDAL ProductMasterDAL = new ProductMasterDAL();
        

        stockDAL stockDAL = new stockDAL();


        //hello
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
            textAddress.Text =smBLL.Address;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // CHECK PRODUCT IS SELECTED OR NOT.. 
            if (textItemName.Text != "")
            {
                if(textQuantity.Text!="" && textQuantity.Text!="0")
                {
                    if(comboGstType.Text!="")
                    {
                        // get Product name,unit ,Qty, price , Discount ,Tax. Amount to datagrid view

                        String ProductName = textItemName.Text;
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
                        purchasedt.Rows.Add(no, ProductName, Unit, Qty, PurchasePrice, Amount, discount,gstType, gst, TotalAmount);
                        dgvAddedProducts.DataSource = purchasedt;

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
                        textItemSearch.Text = "";
                        textItemName.Text = "";
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
                        MessageBox.Show("Plsease Select GST type");
                    }
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

        }


        private void textItemSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = textItemSearch.Text;


            if (keyword == "")
            {
                textItemName.Text = "";
                textInventory.Text = "0";
                textPurchasePrice.Text = "0";
                textQuantity.Text = "0";
                textDiscount.Text = "0";
                textGst.Text = "0";
                return;
            }

            ProductMasterBLL p = ProductMasterDAL.GetProductsForTransaction(keyword);
            textItemCode.Text = p.Item_Code;
            textItemName.Text = p.Product_Name;
            comboBoxUnit.Text = p.Unit;
            textPurchasePrice.Text = p.Purchase_Price.ToString();
            textInventory.Text = p.Quantity.ToString();
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmPurchase_Load(object sender, EventArgs e)
        {
            //specify columns to our dataTable 
            purchasedt.Columns.Add("Sr. No.");
            purchasedt.Columns.Add("ProductName");
            purchasedt.Columns.Add("Unit");
            purchasedt.Columns.Add("Quantity");
            purchasedt.Columns.Add("PurchasePrice");
            purchasedt.Columns.Add("Amount");
            purchasedt.Columns.Add("(-)Discount");
            purchasedt.Columns.Add("Gst Type");
            purchasedt.Columns.Add("(+)Tax%");
            purchasedt.Columns.Add("(=)Total");           
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

            string sname = textSupplierName.Text;
            if (comboPurchaseType.Text != "")
            {
                if(sname != "")
                {

                    if(dgvAddedProducts.Rows.Count!=0)
                    {
                        SupplierMasterBLL s = smDAL.getSuplierIdFromName(sname);

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

                        purchaseBLL.PurchaseDetails = purchasedt;
                        bool isSuccess = false;

                        // using (TransactionScope scope = new TransactionScope())
                        
                           //  int purchaseid = -1; already declaraed at the top as a global variable
                            bool b = purchaseDAL.insertpurchase(purchaseBLL, out purchaseid);
                            for (int i = 0; i < purchasedt.Rows.Count; i++)
                            {
                                purchasedetailsBLL pdBLL = new purchasedetailsBLL();

                                stockBLL stockBLL = new stockBLL();

                                string productName = purchasedt.Rows[i][1].ToString();
                                ProductMasterBLL p = ProductMasterDAL.GetProductIDFromName(productName);


                                pdBLL.Purchase_ID = purchaseid;
                                pdBLL.Product_ID = p.Product_ID;
                                pdBLL.Sup_ID = s.SupplierID;
                                pdBLL.Product_Name = purchasedt.Rows[i][1].ToString();
                                pdBLL.Unit = purchasedt.Rows[i][2].ToString();
                                pdBLL.Qty = Math.Round(decimal.Parse(purchasedt.Rows[i][3].ToString()), 2);
                                pdBLL.Rate = Math.Round(decimal.Parse(purchasedt.Rows[i][4].ToString()), 2);
                                pdBLL.Discount_Per = Math.Round(decimal.Parse(purchasedt.Rows[i][6].ToString()), 2);
                                pdBLL.GST_Type = purchasedt.Rows[i][7].ToString();
                                pdBLL.GST_Per = Math.Round(decimal.Parse(purchasedt.Rows[i][8].ToString()), 2);
                                pdBLL.Total = Math.Round(decimal.Parse(purchasedt.Rows[i][5].ToString()), 2);
                                



                                int Product_id = p.Product_ID;
                                stockBLL.Product_Id = Product_id;
                                stockBLL.Quantity= Math.Round(decimal.Parse(purchasedt.Rows[i][3].ToString()), 2);
                                stockBLL.Unit = purchasedt.Rows[i][2].ToString();

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
            //check product is already available in stock or not
            //
            //if yes update the quantity if no add new product in stock 

            //also add details in PTransactions and PTransaction Details 

            //save transaction and transaction details
            save();
            textPurchaseBillNo.Text = purchaseid.ToString();

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

                    textItemName.Text = dgvAddedProducts.Rows[dgvAddedProducts.CurrentCell.RowIndex].Cells[1].Value.ToString();
                    comboBoxUnit.Text = dgvAddedProducts.Rows[dgvAddedProducts.CurrentCell.RowIndex].Cells[2].Value.ToString();
                    textQuantity.Text = dgvAddedProducts.Rows[dgvAddedProducts.CurrentCell.RowIndex].Cells[3].Value.ToString();
                    textPurchasePrice.Text = dgvAddedProducts.Rows[dgvAddedProducts.CurrentCell.RowIndex].Cells[4].Value.ToString();
                    textTotalAmount.Text = dgvAddedProducts.Rows[dgvAddedProducts.CurrentCell.RowIndex].Cells[9].Value.ToString();
                    textDiscount.Text = dgvAddedProducts.Rows[dgvAddedProducts.CurrentCell.RowIndex].Cells[6].Value.ToString();
                    comboGstType.Text = dgvAddedProducts.Rows[dgvAddedProducts.CurrentCell.RowIndex].Cells[7].Value.ToString();
                    textGst.Text = dgvAddedProducts.Rows[dgvAddedProducts.CurrentCell.RowIndex].Cells[8].Value.ToString();                   
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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (purchaseid != -1)
            {
                //Invoice_No = 2005;
                frmPurchaseCrpt purchaseCrpt = new frmPurchaseCrpt(purchaseid);
                purchaseCrpt.Show();
            }
            else
            {
                MessageBox.Show("Please Save details first");
            }
        }
    }   
}
