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
    public partial class frmSupplierMaster : Form
    {
        public frmSupplierMaster()
        {
            InitializeComponent();
        }
        //morninn
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            btnAdd.BackColor = Color.LightCyan;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            /// 
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SupplierMasterBLL sm = new SupplierMasterBLL();
            SupplierMasterDAL smd = new SupplierMasterDAL();
            sm.CompanyName = txtCompany_Name.Text;
            sm.Address = textAddress.Text;
            sm.City = textCity.Text;
            sm.State = comboBox1.Text;
            sm.Pincode = textPincode.Text;
            sm.Country = txtCountry.Text;
            sm.Email = textEmail.Text;
            sm.Contact_Person = textContact_Person.Text;
            sm.Contact_No =textContact_No.Text;
            sm.added_date = DateTime.Now;
            bool Success = smd.Insert(sm);
            if(Success==true)
            {
                MessageBox.Show("Supplier inserted Successfull");
                Clear();
            }
            else
            {
                MessageBox.Show("Error Occured while inserting Supplier");
            }



        }
        public void Clear()
        {
            txtCompany_Name.Text="";
           textAddress.Text="";
            textCity.Text = "";
            comboBox1.Text = "";
            textPincode.Text = "";
            txtCountry.Text = "";
            textEmail.Text = "";
            textContact_Person.Text = "";
            textContact_No.Text = "";
        }
    }
}
