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

        private void btnSave_Click(object sender, EventArgs e)
        {
            salesBLL sales = new salesBLL();

            string cname = txtName.Text;
            if (cname != "")
            {
                customerBLL c = cDAL.getCustomerIdFromName(cname);

                sales.custid = c.id;
                sales.grandtotal = decimal.Parse(txtGrandTotal.Text);
                sales.gst = decimal.Parse(txtGst.Text);
                sales.discount = decimal.Parse(txtDiscount.Text);

                sales.salesdetails = salesdt;
                bool isSuccess = false;

                using (TransactionScope scope = new TransactionScope())
                {
                    int salesid = -1;
                    bool b = s.insertsales(sales, out salesid);
                    for (int i = 0; i < salesdt.Rows.Count; i++)
                    {
                        salesdetailsBLL sdb = new salesdetailsBLL();
                        string productName = salesdt.Rows[i][0].ToString();

                        productBLL p = pDAL.GetProductIDFromName(productName);

                        sdb.productid = p.id;
                        sdb.rate = decimal.Parse(salesdt.Rows[i][1].ToString());
                        sdb.qty = decimal.Parse(salesdt.Rows[i][2].ToString());
                        sdb.total = Math.Round(decimal.Parse(salesdt.Rows[i][3].ToString()), 2);
                        sdb.custid = c.id;

                        if (b == true)
                        {
                            bool x = pDAL.DecreaseProduct(sdb.productid, sdb.qty);
                        }

                        bool y = sd.insertsalesdetails(sdb);
                        isSuccess = b && y;
                    }
                    if (isSuccess == true)
                    {
                        scope.Complete();
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
    }
}
