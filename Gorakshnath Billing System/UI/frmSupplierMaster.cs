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
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }

        private const int cGrip = 16;
        private const int cCaption = 32;
        protected override void WndProc(ref Message m)
        {
            if(m.Msg==0x84)
            {
                Point pos = new Point(m.LParam.ToInt32());
                pos = this.PointToClient(pos);
                if(pos.Y<cCaption)
                {
                    m.Result = (IntPtr)2;
                    return;
                }
                if(pos.X >=this.ClientSize.Width - cGrip && pos.Y >= this.ClientSize.Height - cGrip)
                {
                    m.Result = (IntPtr)17;
                    return;
                }
            }
            base.WndProc(ref m);
        }




        SupplierMasterBLL sm = new SupplierMasterBLL();
        SupplierMasterDAL smd = new SupplierMasterDAL();

        DataTable supplierDT = new DataTable();
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string supId = textSupplier_Id.Text;
            if (supId != "")
            {
                sm.SupplierID = Convert.ToInt32(textSupplier_Id.Text);

                bool success = smd.Delete(sm);

                if (success == true)
                {
                    MessageBox.Show("Supplier Details Successfully Deleted");
                    Clear();
                }
                else
                {
                    MessageBox.Show("Failed To Delete");
                }

                DataTable dt = smd.Select();
                dgvSupplier.DataSource = dt;

            }
            else
            {
                MessageBox.Show("Please Selecte Details to Delete");
            }
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            btnAdd.BackColor = Color.LightCyan;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string supId = textSupplier_Id.Text;
            if (supId != "")
            {
                sm.SupplierID = Convert.ToInt32(textSupplier_Id.Text);
                sm.CompanyName = txtCompany_Name.Text;
                sm.Address = textAddress.Text;
                sm.City = textCity.Text;
                sm.State = comboBoxState.Text;
                sm.Pincode = textPincode.Text;
                sm.Country = comboBoxCountry.Text;
                sm.Email = textEmail.Text;
                sm.Phone_No = textPhone_No.Text;
                sm.Contact_Person = textContact_Person.Text;
                sm.Contact_No = textContact_No.Text; 

                bool success = smd.Update(sm);

                if (success == true)
                {
                    MessageBox.Show("Supllier Details Successfully Updated");
                    Clear();
                }
                else
                {
                    MessageBox.Show("Failed to Update");
                }

                DataTable dt = smd.Select();
                dgvSupplier.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Please Select Details to Update");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {            
            sm.CompanyName = txtCompany_Name.Text;
            sm.Address = textAddress.Text;
            sm.City = textCity.Text;
            sm.State = comboBoxState.Text;
            sm.Pincode = textPincode.Text;
            sm.Country = comboBoxCountry.Text;
            sm.Email = textEmail.Text;
            sm.Phone_No = textPhone_No.Text;
            sm.Contact_Person = textContact_Person.Text;
            sm.Contact_No =textContact_No.Text;            
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

            DataTable dt = smd.Select();
            dgvSupplier.DataSource = dt;

        }
        public void Clear()
        {
            textSupplier_Id.Text = "";
            txtCompany_Name.Text="";
           textAddress.Text="";
            textCity.Text = "";
            comboBoxState.Text = "";
            textPincode.Text = "";
            comboBoxCountry.Text = "";
            textEmail.Text = "";
            textPhone_No.Text = "";
            textContact_Person.Text = "";
            textContact_No.Text = "";
        }

        private void frmSupplierMaster_Load(object sender, EventArgs e)
        {
            DataTable dt = smd.Select();
            dgvSupplier.DataSource = dt;
        }

        private void dgvSupplier_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            textSupplier_Id.Text = dgvSupplier.Rows[rowIndex].Cells[0].Value.ToString();
            textSupplier_Id.ForeColor = Color.Black;

            txtCompany_Name.Text = dgvSupplier.Rows[rowIndex].Cells[1].Value.ToString();
            txtCompany_Name.ForeColor = Color.Black;

            textAddress.Text = dgvSupplier.Rows[rowIndex].Cells[2].Value.ToString();
            textAddress.ForeColor = Color.Black;

            textCity.Text = dgvSupplier.Rows[rowIndex].Cells[3].Value.ToString();
            textCity.ForeColor = Color.Black;

            comboBoxState.Text = dgvSupplier.Rows[rowIndex].Cells[4].Value.ToString();
            textContact_No.ForeColor = Color.Black;

            textPincode.Text = dgvSupplier.Rows[rowIndex].Cells[5].Value.ToString();
            textPincode.ForeColor = Color.Black;

            comboBoxCountry.Text = dgvSupplier.Rows[rowIndex].Cells[6].Value.ToString();
            comboBoxCountry.ForeColor = Color.Black;


            textEmail.Text = dgvSupplier.Rows[rowIndex].Cells[7].Value.ToString();
            textEmail.ForeColor = Color.Black;

            textPhone_No.Text = dgvSupplier.Rows[rowIndex].Cells[8].Value.ToString();
            textPhone_No.ForeColor = Color.Black;
            
            textContact_Person.Text = dgvSupplier.Rows[rowIndex].Cells[9].Value.ToString();
            textContact_Person.ForeColor = Color.Black;

            textContact_No.Text = dgvSupplier.Rows[rowIndex].Cells[10].Value.ToString();
            textContact_No.ForeColor = Color.Black;


        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            string keywords = textSearch.Text;

            if (keywords != null)
            {
                DataTable dt = smd.Search(keywords);
                dgvSupplier.DataSource = dt;
            }
            else
            {
                DataTable dt = smd.Select();
                dgvSupplier.DataSource = dt;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
            //clear all details.
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
