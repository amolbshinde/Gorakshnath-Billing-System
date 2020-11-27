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

        supplierDAL sup_DAL = new supplierDAL();
        DataTable purchasedt = new DataTable();

        purchaseDAL pur_DAL = new purchaseDAL();


        salesdetailsDAL sd = new salesdetailsDAL();
        productDAL pDAL = new productDAL();
        //hello
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = textSearch.Text;
            if (keyword == "")
            {
                textSupplierName.Text = "";
                textAddress.Text = "";
                textContact.Text = "";
                textEmail.Text = "";
                return;
            }

            supplierBLL sup_b = sup_DAL.searchsupplierforpurchase(keyword);



            textSupplierName.Text = sup_b.name;
            textContact.Text = sup_b.contact;
            textEmail.Text = sup_b.email;
            textAddress.Text = sup_b.address;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
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
                return;
            }

            productBLL p = pDAL.GetProductsForTransaction(keyword);
            textItemName.Text = p.name;
            textInventory.Text = p.qty.ToString();
            textPurchasePrice.Text = p.rate.ToString();
        }
    }
}
