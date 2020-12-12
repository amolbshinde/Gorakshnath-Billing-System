﻿using Gorakshnath_Billing_System.BLL;
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
        public frmChallanReturn()
        {
            InitializeComponent();
        }

        ChallanReturnDAL ChallanReturnDAL = new ChallanReturnDAL();


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

            }
        }

        private void comboInvoiceNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }
    }
}
