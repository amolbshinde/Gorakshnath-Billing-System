using Gorakshnath_Billing_System.BLL;
using Gorakshnath_Billing_System.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gorakshnath_Billing_System.UI
{
    public partial class frmChallanReturn : Form
    {
        int Invoice_No = -1;
        public frmChallanReturn()
        {
            InitializeComponent();
        }

        ChallanReturnDAL ChallanReturnDAL = new ChallanReturnDAL();
        ChallanReturnBLL ChallanReturnBLL = new ChallanReturnBLL();
        customerDAL cDAL = new customerDAL();
        stockDAL stockDAL = new stockDAL();

        ProductMasterDAL ProductMasterDAL = new ProductMasterDAL();

        DataTable salesReturnDT = new DataTable();


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmChallanReturn_Load(object sender, EventArgs e)
        {
            comboInvoiceNo.DataSource = null;
            DataTable dtg = ChallanReturnDAL.SelectInvoiceNo();
            comboInvoiceNo.DisplayMember = "Invoice_No";
            comboInvoiceNo.Items.Add("Select Invoice No");
            comboInvoiceNo.DataSource = dtg;


            salesReturnDT.Columns.Add("Sr. No.");
            salesReturnDT.Columns.Add("Product Name");
            salesReturnDT.Columns.Add("Unit");
            salesReturnDT.Columns.Add("Quantity");
            salesReturnDT.Columns.Add("PurchasePrice");
            salesReturnDT.Columns.Add("(-)Discount");
            salesReturnDT.Columns.Add("Gst Type");
            salesReturnDT.Columns.Add("(+)GST%");
            salesReturnDT.Columns.Add("(+)GSTAMT");
            salesReturnDT.Columns.Add("(=)Total");


        }

        private void comboInvoiceNo_SelectedIndexChanged(object sender, EventArgs e)
        {
           if(comboInvoiceNo.Text != "Select Invoice No")
            {

                int invoceNo;
                int.TryParse(comboInvoiceNo.Text, out invoceNo);
                ChallanReturnBLL crBLL = ChallanReturnDAL.GetCustomerForChallanReturn(invoceNo);
                comboTransactionType.Text = crBLL.Transaction_Type;
                textCust_Name.Text = crBLL.Cust_Name;
                textContact.Text = crBLL.Cust_Contact;
                textEmail.Text = crBLL.Cust_Email;
                textAddress.Text = crBLL.Cust_Address;

                comboItemName.DataSource = null;
                DataTable dti = ChallanReturnDAL.SelectItemName(invoceNo);
                comboItemName.DisplayMember = "Product_Name";
                comboItemName.Items.Add("Select Product Name");
                comboItemName.DataSource = dti;

                Clear();
            }
        }

        private void comboInvoiceNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void comboItemName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string keyword = comboItemName.Text;
            ChallanReturnBLL crBLL = ChallanReturnDAL.GetProductForChallanReturn(keyword);
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
                                counter = salesReturnDT.Rows.Count + 1;
                                decimal gstAmt = Math.Round((((rate * Qty) - ((rate * Qty) * discount) / 100) * GST) / 100, 2);
                                salesReturnDT.Rows.Add(counter, ProductName, Unit, Qty, rate, discount, gstType, GST, gstAmt, TotalAmount);
                                dgvAddedProducts.DataSource = salesReturnDT;

                                decimal subTotal;
                                decimal.TryParse(textSubTotal.Text, out subTotal);
                                subTotal = Math.Round(subTotal + Qty * rate,2);
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

        public void Clear()
        {
            /*
            comboGstType.Text = "";            
            textCust_Name.Text = "";
            textEmail.Text = "";
            textAddress.Text = "";
            textContact.Text = "";            
            */
            comboBoxUnit.Text = "";
            textInventory.Text = "0";
            textQuantity.Text = "0";
            textRate.Text = "0";
            textDiscount.Text = "0";
            comboGstType.Text = "";
            textGST.Text = "0";
            textTotalAmount.Text = "0";

            textSubTotal.Text = "";
            textSubDiscount.Text = "";
            textSgst.Text = "";
            textCgst.Text = "";
            textIgst.Text = "";
            textGrandTotal.Text = "";

            dgvAddedProducts.DataSource = null;
            dgvAddedProducts.Rows.Clear();
            salesReturnDT.Rows.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            save();
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
                      
                        int invoceNo;
                        int.TryParse(comboInvoiceNo.Text, out invoceNo);


                        string type = comboTransactionType.Text;
                        decimal.TryParse(textSubTotal.Text, out subTotal);
                        decimal.TryParse(textSubDiscount.Text, out totalDiscount);
                        decimal.TryParse(textSgst.Text, out totalSgst);
                        decimal.TryParse(textCgst.Text, out totalCgst);
                        decimal.TryParse(textIgst.Text, out totalIgst);
                        decimal.TryParse(textGrandTotal.Text, out grandTotal);

                        ChallanReturnBLL.SalesID = invoceNo;
                        ChallanReturnBLL.Transaction_Type = type;
                        ChallanReturnBLL.Cust_ID = c.Cust_ID;
                        ChallanReturnBLL.Sub_Total = subTotal;
                        ChallanReturnBLL.TDiscount = totalDiscount;
                        ChallanReturnBLL.TSGST = totalSgst;
                        ChallanReturnBLL.TCGST = totalCgst;
                        ChallanReturnBLL.TIGST = totalIgst;
                        ChallanReturnBLL.Grand_Total = grandTotal;

                        ChallanReturnBLL.SalesDetails = salesReturnDT;
                        bool isSuccess = false;

                        // using (TransactionScope scope = new TransactionScope())

                        //int Invoice_No = -1; alredy declared on top 
                        bool b = ChallanReturnDAL.insertSalesReturn(ChallanReturnBLL, out Invoice_No);

                        for (int i = 0; i < salesReturnDT.Rows.Count; i++)
                        {
                            ChallanReturnBLL cdBLL = new ChallanReturnBLL();

                            stockBLL stockBLL = new stockBLL();
                            string productName = salesReturnDT.Rows[i][1].ToString();
                            ProductMasterBLL p = ProductMasterDAL.GetProductIDFromName(productName);
                            
                            cdBLL.Product_ID = p.Product_ID;
                            cdBLL.Invoice_No = Invoice_No;
                            cdBLL.Cust_ID = c.Cust_ID;
                            cdBLL.Product_Name = salesReturnDT.Rows[i][1].ToString();
                            cdBLL.Unit = salesReturnDT.Rows[i][2].ToString();
                            cdBLL.Qty = Math.Round(decimal.Parse(salesReturnDT.Rows[i][3].ToString()), 2);
                            cdBLL.Rate = Math.Round(decimal.Parse(salesReturnDT.Rows[i][4].ToString()), 2);
                            cdBLL.Discount_Per = Math.Round(decimal.Parse(salesReturnDT.Rows[i][5].ToString()), 2);
                            cdBLL.GST_Type = salesReturnDT.Rows[i][6].ToString();
                            cdBLL.GST_Per = Math.Round(decimal.Parse(salesReturnDT.Rows[i][7].ToString()), 2);
                            cdBLL.Total = Math.Round(decimal.Parse(salesReturnDT.Rows[i][9].ToString()), 2);

                            int Product_id = p.Product_ID;
                            stockBLL.Product_Id = Product_id;
                            stockBLL.Quantity = Math.Round(decimal.Parse(salesReturnDT.Rows[i][3].ToString()), 2);
                            stockBLL.Unit = salesReturnDT.Rows[i][2].ToString();

                            bool y = ChallanReturnDAL.insertSalesReturndetails(cdBLL);

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
