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
    public partial class frmCustomer : Form
    {
        public frmCustomer()
        {
            InitializeComponent();
        }
        customerBLL c = new customerBLL();
        customerDAL dal = new customerDAL();

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
           c.name = txtCustomerName.Text;
            c.contact = txtCustomerContact.Text;
            c.email = txtCustomerEmail.Text;
            c.address = txtCustomerAddress.Text;

            string cid = txtCustomerId.Text;
            if (dgvCustomer.SelectedRows.Count < 1)
            {
                if (c.name != "" && c.name != "Customer Name")
                {
                    if (c.contact != "" && c.contact != "Customer Contact")
                    {
                        if (c.email != "" && c.email != "Customer Email Id")
                        {
                            if (c.address != "" && c.address != "Customer Address")
                            {
                                bool Success = dal.Insert(c);

                                if (Success == true)
                                {
                                    MessageBox.Show("Customer Details Successfully Added");
                                    clear();
                                }
                                else
                                {
                                    MessageBox.Show("Failed to Added Customer Details");
                                }
                                DataTable dt = dal.Select();
                                dgvCustomer.DataSource = dt;

                            }
                            else
                            {
                                MessageBox.Show("Please Enter customer Address");
                                txtCustomerAddress.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please Enter Customer Email Id");
                            txtCustomerEmail.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Enter Customer Contact Number");
                        txtCustomerContact.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Please Enter Customer Name");
                    txtCustomerName.Focus();
                }
            }
            else
            {
                MessageBox.Show("Please Enter New Customer Details");
            }


        }

        private void clear()
        {
            txtCustomerId.Text = "Auto Genrated";
            txtCustomerId.ForeColor = Color.Gray;

            txtCustomerName.Text = "Customer Name";
            txtCustomerName.ForeColor = Color.Gray;

            txtCustomerContact.Text = "Customer Contact";
            txtCustomerContact.ForeColor = Color.Gray;

            txtCustomerEmail.Text = "Customer Email Id";
            txtCustomerEmail.ForeColor = Color.Gray;

            txtCustomerAddress.Text = "Customer Address";
            txtCustomerAddress.ForeColor = Color.Gray;

            dgvCustomer.ClearSelection();

        }

        private void txtCustomerAddress_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtCustomerAddress_Enter(object sender, EventArgs e)
        {
            if (txtCustomerAddress.Text == "Customer Address")
            {
                txtCustomerAddress.Text = "";
                txtCustomerAddress.ForeColor = Color.Black;
            }
        }

        private void txtCustomerAddress_Leave(object sender, EventArgs e)
        {
            if (txtCustomerAddress.Text == "")
            {
                txtCustomerAddress.Text = "Customer Address";
                txtCustomerAddress.ForeColor = Color.Gray;
            }
        }
    }
}
