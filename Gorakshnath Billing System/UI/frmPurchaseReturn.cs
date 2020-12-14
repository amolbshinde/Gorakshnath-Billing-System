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
    public partial class frmPurchaseReturn : Form
    {
        int RInvoice_No = -1;
        public frmPurchaseReturn()
        {
            InitializeComponent();
        }


        PurchaseReturnDAL PurchaseReturnDAL = new PurchaseReturnDAL();
        PurchaseReturnBLL PurchaseReturnBLL = new PurchaseReturnBLL();

        PurchaseReturnDetailsDAL PurchaseReturnDetailsDAL = new PurchaseReturnDetailsDAL();

        SupplierMasterDAL sDAL = new SupplierMasterDAL();
        

        stockDAL stockDAL = new stockDAL();

        ProductMasterDAL ProductMasterDAL = new ProductMasterDAL();

        DataTable PurchaseReturnDT = new DataTable();


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPurchaseReturn_Load(object sender, EventArgs e)
        {
            comboPurchaseID.DataSource = null;
            DataTable dtg = PurchaseReturnDAL.SelectPurchaseId();
            comboPurchaseID.DisplayMember = "Purchase_ID";
            comboPurchaseID.Items.Add("Select Invoice No");
            comboPurchaseID.DataSource = dtg;


            PurchaseReturnDT.Columns.Add("Sr. No.");
            PurchaseReturnDT.Columns.Add("Product Name");
            PurchaseReturnDT.Columns.Add("Unit");
            PurchaseReturnDT.Columns.Add("Quantity");
            PurchaseReturnDT.Columns.Add("PurchasePrice");
            PurchaseReturnDT.Columns.Add("(-)Discount");
            PurchaseReturnDT.Columns.Add("Gst Type");
            PurchaseReturnDT.Columns.Add("(+)GST%");
            PurchaseReturnDT.Columns.Add("(+)GSTAMT");
            PurchaseReturnDT.Columns.Add("(=)Total");



        }

        private void comboPurchaseID_SelectedIndexChanged(object sender, EventArgs e)
        {
            int PurchaseID;
            int.TryParse(comboPurchaseID.Text, out PurchaseID);
            PurchaseReturnBLL crBLL = PurchaseReturnDAL.GetSuplierForPurchaseReturn(PurchaseID);
            comboPurchaseType.Text = crBLL.Transaction_Type;
            textSupplierName.Text = crBLL.Sup_Name;
            textContact.Text = crBLL.Sup_Contact;
            textEmail.Text = crBLL.Sup_Email;
            textAddress.Text = crBLL.Sup_Address;

            comboItemName.DataSource = null;
            DataTable dti = PurchaseReturnDetailsDAL.SelectItemName(PurchaseID);
            comboItemName.DisplayMember = "Product_Name";
            comboItemName.Items.Add("Select Product Name");
            comboItemName.DataSource = dti;


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboItemName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string keyword = comboItemName.Text;
            PurchaseReturnDetailsBLL crBLL = PurchaseReturnDetailsDAL.GetProductForPurchaseReturn(keyword);
            comboBoxUnit.Text = crBLL.Unit;
            textQuantity.Text = crBLL.Qty.ToString();
            textRate.Text = crBLL.Rate.ToString();
            textDiscount.Text = crBLL.Discount_Per.ToString();
            comboGstType.Text = crBLL.GST_Type;
            textTotalAmount.Text = crBLL.Total.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {


            string pname = "";
            //checking product is already present or ot           

            if (comboItemName.Text != "")
            {
                if (textQuantity.Text != "")
                {
                    if (comboGstType.Text != "")
                    {

                        for (int rows = 0; rows < dgvAddedProducts.Rows.Count; rows++)
                        {
                            pname = dgvAddedProducts.Rows[rows].Cells["Product Name"].Value.ToString();
                            break;
                        }
                        if (comboItemName.Text != pname)
                        {
                            // get Product name ,Qty, price , Discount ,Tax. Amount to datagrid view

                            String ProductName = comboItemName.Text;
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
                                counter = PurchaseReturnDT.Rows.Count + 1;
                                decimal gstAmt = Math.Round((((rate * Qty) - ((rate * Qty) * discount) / 100) * GST) / 100, 2);
                                PurchaseReturnDT.Rows.Add(counter, ProductName, Unit, Qty, rate, discount, gstType, GST, gstAmt, TotalAmount);
                                dgvAddedProducts.DataSource = PurchaseReturnDT;

                                decimal subTotal;
                                decimal.TryParse(textSubTotal.Text, out subTotal);
                                subTotal = Math.Round(subTotal + Qty * rate, 2);
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

                                comboBoxUnit.Text = "";
                                textInventory.Text = "0";
                                textQuantity.Text = "0";
                                textRate.Text = "0";
                                textDiscount.Text = "0";
                                textQuantity.Text = "0";
                                comboGstType.Text = "";
                                textGST.Text = "0";
                                textTotalAmount.Text = "0";

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

        private void button1_Click(object sender, EventArgs e)
        {
            save();
        }



        public void save()
        {
            string sname = textSupplierName.Text;
            if (comboPurchaseType.Text != "")
            {
                if (sname != "")
                {

                    if (dgvAddedProducts.Rows.Count != 0)
                    {
                        if (comboReturnReson.Text != "")
                        {
                            SupplierMasterBLL c = sDAL.getSuplierIdFromName(sname);

                            decimal subTotal, totalDiscount, totalSgst, totalCgst, totalIgst, grandTotal;

                            int Purchase_ID;
                            int.TryParse(comboPurchaseID.Text, out Purchase_ID);


                            string type = comboPurchaseType.Text;
                            decimal.TryParse(textSubTotal.Text, out subTotal);
                            decimal.TryParse(textSubDiscount.Text, out totalDiscount);
                            decimal.TryParse(textSgst.Text, out totalSgst);
                            decimal.TryParse(textCgst.Text, out totalCgst);
                            decimal.TryParse(textIgst.Text, out totalIgst);
                            decimal.TryParse(textGrandTotal.Text, out grandTotal);

                            string reson = comboReturnReson.Text;

                            PurchaseReturnBLL.Purchase_ID = Purchase_ID;
                            PurchaseReturnBLL.Transaction_Type = type;
                            PurchaseReturnBLL.Sup_ID = c.SupplierID;
                            PurchaseReturnBLL.Sub_Total = subTotal;
                            PurchaseReturnBLL.TDiscount = totalDiscount;
                            PurchaseReturnBLL.TSGST = totalSgst;
                            PurchaseReturnBLL.TCGST = totalCgst;
                            PurchaseReturnBLL.TIGST = totalIgst;
                            PurchaseReturnBLL.Grand_Total = grandTotal;
                            PurchaseReturnBLL.Reson = reson;

                            PurchaseReturnBLL.PurchaseDetails = PurchaseReturnDT;
                            bool isSuccess = false;

                            // using (TransactionScope scope = new TransactionScope())

                            //int Invoice_No = -1; alredy declared on top 
                            bool b = PurchaseReturnDAL.insertPurchaseReturn(PurchaseReturnBLL,out RInvoice_No );

                            for (int i = 0; i < PurchaseReturnDT.Rows.Count; i++)
                            {
                                PurchaseReturnDetailsBLL prdBLL = new PurchaseReturnDetailsBLL();

                                stockBLL stockBLL = new stockBLL();
                                string productName = PurchaseReturnDT.Rows[i][1].ToString();
                                ProductMasterBLL p = ProductMasterDAL.GetProductIDFromName(productName);

                                prdBLL.Product_ID = p.Product_ID;
                                prdBLL.Invoice_No = RInvoice_No;
                                prdBLL.Sup_ID = c.SupplierID;
                                prdBLL.Product_Name = PurchaseReturnDT.Rows[i][1].ToString();
                                prdBLL.Unit = PurchaseReturnDT.Rows[i][2].ToString();
                                prdBLL.Qty = Math.Round(decimal.Parse(PurchaseReturnDT.Rows[i][3].ToString()), 2);
                                prdBLL.Rate = Math.Round(decimal.Parse(PurchaseReturnDT.Rows[i][4].ToString()), 2);
                                prdBLL.Discount_Per = Math.Round(decimal.Parse(PurchaseReturnDT.Rows[i][5].ToString()), 2);
                                prdBLL.GST_Type = PurchaseReturnDT.Rows[i][6].ToString();
                                prdBLL.GST_Per = Math.Round(decimal.Parse(PurchaseReturnDT.Rows[i][7].ToString()), 2);
                                prdBLL.Total = Math.Round(decimal.Parse(PurchaseReturnDT.Rows[i][9].ToString()), 2);

                                int Product_id = p.Product_ID;
                                stockBLL.Product_Id = Product_id;
                                stockBLL.Quantity = Math.Round(decimal.Parse(PurchaseReturnDT.Rows[i][3].ToString()), 2);
                                stockBLL.Unit = PurchaseReturnDT.Rows[i][2].ToString();

                                bool y = PurchaseReturnDetailsDAL.insertPurchaseReturnDetails(prdBLL);

                                if (y == true)
                                {
                                    //bool x = stockDAL.dereaseUpdate(stockBLL);
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
                            MessageBox.Show("Please Select Retrun Reson");
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






    }
}
