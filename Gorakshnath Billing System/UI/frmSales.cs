using Gorakshnath_Billing_System.BLL;
using Gorakshnath_Billing_System.DAL;
using DGVPrinterHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Transactions;

namespace Gorakshnath_Billing_System.UI
{
    public partial class frmSales : Form
    {
        public frmSales()
        {
            InitializeComponent();
        }
        customerDAL cDAL = new customerDAL();
        DataTable salesdt = new DataTable();
        salesDAL s = new salesDAL();

        salesdetailsDAL sd = new salesdetailsDAL();
        productDAL pDAL = new productDAL();
        private void clear()
        {
            //Clear all details
            dgvAddedProduct.DataSource = null;
            dgvAddedProduct.Rows.Clear();
            salesdt.Rows.Clear();

            txtSearch.Text = "";
            txtName.Text = "";
            txtEmail.Text = "";
            txtContact.Text = "";
            txtAddress.Text = "";
            txtSearchProduct.Text = "";
            txtProductName.Text = "";
            txtInventory.Text = "0";
            txtRate.Text = "0";
            txtQuntity.Text = "0";
            txtSubtotal.Text = "00.00";
            txtDiscount.Text = "0";
            txtGst.Text = "0";
            txtGrandTotal.Text = "00.00";
            txtPaidAmount.Text = "00.00";
            txtReturnAmount.Text = "00.00";
            
        }

        public void save()
        {
            salesBLL sales = new salesBLL();

            string cname = txtName.Text;
            if (cname != "")
            {
                customerBLL c = cDAL.getCustomerIdFromName(cname);

                sales.salesdate = dtpBillDate.Value;
                sales.custid = c.id;
                sales.grandtotal = decimal.Parse(txtGrandTotal.Text);
                sales.gst = decimal.Parse(txtGst.Text);
                sales.discount = decimal.Parse(txtDiscount.Text);

                sales.salesdetails = salesdt;
                bool isSuccess = false;

                // using (TransactionScope scope = new TransactionScope())
                {
                    int salesid = -1;
                    bool b = s.insertsales(sales, out salesid);
                    for (int i = 0; i < salesdt.Rows.Count; i++)
                    {
                        salesdetailsBLL sdb = new salesdetailsBLL();
                        string productName = salesdt.Rows[i][1].ToString();

                        productBLL p = pDAL.GetProductIDFromName(productName);

                        sdb.productid = p.id;
                        sdb.rate = decimal.Parse(salesdt.Rows[i][2].ToString());
                        sdb.qty = decimal.Parse(salesdt.Rows[i][3].ToString());
                        sdb.total = Math.Round(decimal.Parse(salesdt.Rows[i][4].ToString()), 2);
                        sdb.custid = c.id;
                        sdb.addeddate = dtpBillDate.Value;

                        if (b == true)
                        {
                            bool x = pDAL.DecreaseProduct(sdb.productid, sdb.qty);
                        }

                        bool y = sd.insertsalesdetails(sdb);
                        isSuccess = b && y;
                    }
                    if (isSuccess == true)
                    {
                        //scope.Complete();
                        MessageBox.Show("Transaction Completed");
                        clear();
                    }
                    else
                    {
                        MessageBox.Show("Transaction Failed");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please Select Customer Details");
            }
        }
        //

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtName.Text!="")
            {
                if(dgvAddedProduct.Rows.Count!=0)
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text;
            if (keyword == "")
            {
                txtName.Text = "";
                txtAddress.Text = "";
                txtContact.Text = "";
                txtEmail.Text = "";
                return;
            }

            customerBLL cb = cDAL.searchcustomerforsales(keyword);



            txtName.Text = cb.name;
            txtContact.Text = cb.contact;
            txtEmail.Text = cb.email;
            txtAddress.Text = cb.address;

        }

        private void txtSearchProduct_TextChanged(object sender, EventArgs e)
        {                        
            string keyword = txtSearchProduct.Text;           
            
         
            if (keyword == "")
            {
                txtProductName.Text = "";
                txtInventory.Text = "0";
                txtRate.Text = "0";
                txtQuntity.Text = "0";
                return;
            }         
            
            productBLL p = pDAL.GetProductsForTransaction(keyword);            
            txtProductName.Text = p.name;
            txtInventory.Text = p.qty.ToString();
            txtRate.Text = p.rate.ToString();                       
           
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string pname = "";
            {
              //  int productCount ii;
                //productCount = dgvAddedProduct.Rows.Count;
                for (int rows = 0; rows < dgvAddedProduct.Rows.Count; rows++)
                {
                    pname = dgvAddedProduct.Rows[rows].Cells["Product Name"].Value.ToString();
                    break;
                }

                if (txtProductName.Text != "")
                {
                    if (txtQuntity.Text != "0")
                    {
                        if (pname!=txtProductName.Text)
                        {
                            int no = 1;
                            no = (dgvAddedProduct.Rows.Count - 1) + 1;
                            string productName = txtProductName.Text;
                            decimal Rate = decimal.Parse(txtRate.Text);
                            decimal Qty = decimal.Parse(txtQuntity.Text);
                            decimal Total = Rate * Qty;

                            decimal subTotal = decimal.Parse(txtSubtotal.Text);
                            subTotal = subTotal + Total;
                            if (no == 0)
                            {
                                no = 1;
                            }

                            salesdt.Rows.Add(no, productName, Rate, Qty, Total);

                            dgvAddedProduct.DataSource = salesdt;
                            txtSubtotal.Text = subTotal.ToString();
                            txtGrandTotal.Text = subTotal.ToString();
                            txtPaidAmount.Text = subTotal.ToString();

                            txtSearchProduct.Text = "";
                            txtProductName.Text = "";
                            txtInventory.Text = "0.00";
                            txtRate.Text = "0.00";
                            txtQuntity.Text = "0";
                        }
                        else
                        {
                            MessageBox.Show("Product Already Added");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Enter Product Quntity");
                    }
                }
                else
                {
                    MessageBox.Show("Select the product first. Try Again.");
                }
            }
        }

        private void frmSales_Load(object sender, EventArgs e)
        {
            salesdt.Columns.Add("No");
            salesdt.Columns.Add("Product Name");
            salesdt.Columns.Add("Rate");
            salesdt.Columns.Add("Quantity");
            salesdt.Columns.Add("Total");
        }

        private void txtQuntity_TextChanged(object sender, EventArgs e)
        {
            string pname = txtSearchProduct.Text;
            productBLL p = pDAL.GetProductsForTransaction(pname);
            decimal inv;
            decimal.TryParse(txtQuntity.Text, out inv);
            decimal qunt = p.qty - inv;
            if (qunt<0)
            {
                MessageBox.Show("No Inventory Please add Inventory First");                
            }
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {            
            string value = txtDiscount.Text;

            if (value == "")
            {         
                MessageBox.Show("Please Add Discount First");
            }
            else
            {             
                decimal subTotal = decimal.Parse(txtSubtotal.Text);
                decimal discount = decimal.Parse(txtDiscount.Text);

             
                decimal grandTotal = Math.Round(((100 - discount) / 100) * subTotal,2);
             
                txtGrandTotal.Text = grandTotal.ToString();
            }
        }

        private void txtGst_TextChanged(object sender, EventArgs e)
        {            
            string check = txtGrandTotal.Text;
            if (check == "")
            {
         
                MessageBox.Show("Calculate the discount and set the Grand Total First.");
            }
            else
            {         
         
                decimal previousGT = decimal.Parse(txtGrandTotal.Text);
                decimal vat = decimal.Parse(txtGst.Text);
                decimal grandTotalWithVAT = Math.Round(((100 + vat) / 100) * previousGT,2);

         
                txtGrandTotal.Text = grandTotalWithVAT.ToString();
            }
        }

        private void txtQuntity_Enter(object sender, EventArgs e)
        {
            txtQuntity.Text = "";
        }

        private void btnsaveandprint_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "")
            {
                if (dgvAddedProduct.Rows.Count != 0)
                {
                    save();

                    DGVPrinter printer = new DGVPrinter();
                    printer.Title = "Billing Management System\r\n";
                    printer.SubTitle = "Pune, Wagholi \r\n Contact: 123654\r\n\r\n";
                    printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                    printer.PageNumbers = true;
                    printer.PageNumberInHeader = false;
                    printer.PorportionalColumns = true;
                    printer.HeaderCellAlignment = StringAlignment.Center;
                    printer.Footer = "Discount : " + txtDiscount.Text + "%\r\n" + "GST : " + txtGst.Text + "%\r\n" + "Grand Total : " + txtGrandTotal.Text + "\r\n\r\n" + "Thank You for Doing Business with us";
                    printer.FooterSpacing = 15;
                    printer.PrintDataGridView(dgvAddedProduct);
                    MessageBox.Show("Print successfully");
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

        private void btnclear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void txtQuntity_Leave(object sender, EventArgs e)
        {
            if(txtQuntity.Text=="" || txtQuntity.Text==" ")
            {
                txtQuntity.Text = "0";
            }
        }
    }
}
