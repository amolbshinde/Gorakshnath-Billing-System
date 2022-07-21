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
            c.Gst_No = txtCustomerGSTNo.Text;

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
            
            txtCustomerGSTNo.Text = "Customer GST No";
            txtCustomerGSTNo.ForeColor = Color.Gray;

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

        private void dgvCustomer_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            txtCustomerId.Text = dgvCustomer.Rows[rowIndex].Cells[0].Value.ToString();
            txtCustomerId.ForeColor = Color.Black;

            txtCustomerName.Text = dgvCustomer.Rows[rowIndex].Cells[1].Value.ToString();
            txtCustomerName.ForeColor = Color.Black;

            txtCustomerEmail.Text = dgvCustomer.Rows[rowIndex].Cells[2].Value.ToString();
            txtCustomerEmail.ForeColor = Color.Black;

            txtCustomerContact.Text = dgvCustomer.Rows[rowIndex].Cells[3].Value.ToString();
            txtCustomerContact.ForeColor = Color.Black;

            txtCustomerAddress.Text = dgvCustomer.Rows[rowIndex].Cells[4].Value.ToString();
            txtCustomerAddress.ForeColor = Color.Black;

            txtCustomerGSTNo.Text = dgvCustomer.Rows[rowIndex].Cells[6].Value.ToString();
            txtCustomerGSTNo.ForeColor = Color.Black;
        }

        private void frmCustomer_Load_1(object sender, EventArgs e)
        {
            DataTable dt = dal.Select();
            dgvCustomer.DataSource = dt;
        }

        private void txtCustomerEmail_Enter(object sender, EventArgs e)
        {
            if (txtCustomerEmail.Text == "Customer Email Id")
            {
                txtCustomerEmail.Text = "";
                txtCustomerEmail.ForeColor = Color.Black;
            }
        }

        private void txtCustomerEmail_Leave(object sender, EventArgs e)
        {
            if (txtCustomerEmail.Text == "")
            {
                txtCustomerEmail.Text = "Customer Email Id";
                txtCustomerEmail.ForeColor = Color.Gray;
            }
        }

        private void txtCustomerContact_Enter(object sender, EventArgs e)
        {

            if (txtCustomerContact.Text == "Customer Contact")
            {
                txtCustomerContact.Text = "";
                txtCustomerContact.ForeColor = Color.Black;
            }
        }

        private void txtCustomerContact_Leave(object sender, EventArgs e)
        {
            if (txtCustomerContact.Text == "")
            {
                txtCustomerContact.Text = "Customer Contact";
                txtCustomerContact.ForeColor = Color.Gray;
            }
        }

        private void txtCustomerName_Enter(object sender, EventArgs e)
        {

            if (txtCustomerName.Text == "Customer Name")
            {
                txtCustomerName.Text = "";
                txtCustomerName.ForeColor = Color.Black;
            }
        }

        private void txtCustomerName_Leave(object sender, EventArgs e)
        {

            if (txtCustomerName.Text == "")
            {
                txtCustomerName.Text = "Customer Name";
                txtCustomerName.ForeColor = Color.Gray;
            }
        }

        private void btnClearCustomer_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void btnUpdateCustomer_Click(object sender, EventArgs e)
        {
            string custId = txtCustomerId.Text;
            if (custId != "" && custId != "Auto Genrated")
            {
                c.id = Convert.ToInt32(txtCustomerId.Text);
                c.name = txtCustomerName.Text;
                c.contact = txtCustomerContact.Text;
                c.email = txtCustomerEmail.Text;
                c.address = txtCustomerAddress.Text;
                c.Gst_No = txtCustomerGSTNo.Text;

                bool success = dal.Update(c);

                if (success == true)
                {
                    MessageBox.Show("Customer Details Successfully Updated");
                    clear();
                }
                else
                {
                    MessageBox.Show("Failed to Update");
                }
                DataTable dt = dal.Select();
                dgvCustomer.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Please Select Details to Update");
            }
        }

        private void dgvCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BtnDeleteCustomer_Click(object sender, EventArgs e)
        {
            string custId = txtCustomerId.Text;
            if (custId != "" && custId != "Auto Genrated")
            {
               
                

                    c.id = Convert.ToInt32(txtCustomerId.Text);
                    //

                    bool success = dal.Delete(c);

                    if (success == true)
                    {
                        MessageBox.Show("Custermer Details Deleted Succesfully");
                        clear();
                    }
                
                    
                
                DataTable dt = dal.Select();
                dgvCustomer.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Please Selecte Details to Delete");
            }
        }

         private void txtCustomerGSTNo_Enter(object sender, EventArgs e)
        {
            if (txtCustomerGSTNo.Text == "Customer GST No")
            {
                txtCustomerGSTNo.Text = "";
                txtCustomerGSTNo.ForeColor = Color.Black;
            }
        }

        private void txtCustomerGSTNo_Leave(object sender, EventArgs e)
        {
            if (txtCustomerGSTNo.Text == "")
            {
                txtCustomerGSTNo.Text = "Customer GST No";
                txtCustomerGSTNo.ForeColor = Color.Gray;
            }
        }
    }
}
