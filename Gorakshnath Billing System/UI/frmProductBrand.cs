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
    public partial class frmProductBrand : Form
    {
        public frmProductBrand()
        {
            InitializeComponent();
        }

        BrandBLL BrandBLL = new BrandBLL();
        BrandDAL BrandDAL = new BrandDAL();

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //add brand into table 

            if(textBrandName.Text!="")
            {
              
                    BrandBLL = BrandDAL.checkBrandAvailableOrNot(textBrandName.Text);

                    if (textBrandName.Text != BrandBLL.Brand_Name)
                    {
                        BrandBLL.Brand_Name = textBrandName.Text;
                        BrandBLL.Description = textDescription.Text;

                        bool success = BrandDAL.Insert(BrandBLL);
                        if (success == true)
                        {
                            MessageBox.Show("Brand Inserted Succesfully .!!");
                            clear();
                            DataTable dt = BrandDAL.Select();
                            dgvBrand.DataSource = dt;
                        }
                        else
                        {
                            MessageBox.Show("Failed to insert category :/ ");
                        }                        
                    }
                    else
                    {
                        MessageBox.Show("Brand is Already Added in Database Please choose another Brand");
                    }
                             
            }
            else
            {
                MessageBox.Show("Please Enter Brnad Name");
            }


        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            if (textBrandId.Text == "")
            {
                MessageBox.Show("Please Select The Brand");
            }
            else
            {
                BrandBLL.Brand_ID = int.Parse(textBrandId.Text);
                BrandBLL.Brand_Name = textBrandName.Text;
                BrandBLL.Description = textDescription.Text;

                bool success = BrandDAL.Update(BrandBLL);
                if (success == true)
                {
                    MessageBox.Show("Brand Updated Succesfully ...");
                    clear();
                    DataTable dt = BrandDAL.Select();
                    dgvBrand.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Update Failed :/  ");
                }
            }

            

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(textBrandId.Text=="")
            {
                MessageBox.Show("Please Select The Brand");
            }
            else
            {
                BrandBLL.Brand_ID = int.Parse(textBrandId.Text);
                bool success = BrandDAL.Delete(BrandBLL);
                if (success == true)
                {
                    MessageBox.Show("Record deleted Succesfully");
                    clear();
                    DataTable dt = BrandDAL.Select();
                    dgvBrand.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Error occured..!!");
                }
            }
        }

        private void frmProductBrand_Load(object sender, EventArgs e)
        {
            DataTable dt = BrandDAL.Select();
            dgvBrand.DataSource = dt;
        }

        private void dgvBrand_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int RowIndex = e.RowIndex;
            textBrandId.Text = dgvBrand.Rows[RowIndex].Cells[0].Value.ToString();
            textBrandName.Text = dgvBrand.Rows[RowIndex].Cells[1].Value.ToString();
            textDescription.Text = dgvBrand.Rows[RowIndex].Cells[2].Value.ToString();
        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {

            string keywords = textSearch.Text;
            //filter the categories baser on keywords
            if (keywords != null)
            {
                //use search method to display Brand
                DataTable dt = BrandDAL.Search(keywords);
                dgvBrand.DataSource = dt;
            }
            else
            {
                //Select method to display all categories
                DataTable dt = BrandDAL.Select();
                dgvBrand.DataSource = dt;
            }


        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        public void clear()
        {
            textBrandId.Text = "";
            textBrandName.Text = "";
            textDescription.Text = "";
            textSearch.Text = "";
        }
    }
}
