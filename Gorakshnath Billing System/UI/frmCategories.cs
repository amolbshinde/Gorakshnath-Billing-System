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
    public partial class frmCategories : Form
    {
        public frmCategories()
        {
            InitializeComponent();
        }
        categoriesBLL c = new categoriesBLL();
        categoriesDAL dal = new categoriesDAL();
        private void button1_Click(object sender, EventArgs e)
        {
            c.title = textBox2.Text;
            c.description = textBox3.Text;
            c.added_date = DateTime.Now;
            string loggeduser = frmLogin.loggedIn;
            userDAL udal = new userDAL();
            userBLL usr = udal.GetIdFromUsername(loggeduser);
            c.added_by = usr.id;
            bool success = dal.Insert(c);
            if(success==true)
            {
                MessageBox.Show("Categoriy Inserted Succesfully .!!");
                Clear();
                DataTable dt = dal.Select();
                dgvCategories.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Failed to insert category :/ ");
            }

        }
        public void Clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textSearch.Text = ""; 

        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCategories_Load(object sender, EventArgs e)
        {
            // display all cat in datagrid view
            DataTable dt = dal.Select();
            dgvCategories.DataSource = dt;

        }

        private void dgvCategories_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Finding of the row index of row 
            int RowIndex = e.RowIndex;
            textBox1.Text = dgvCategories.Rows[RowIndex].Cells[0].Value.ToString();
            textBox2.Text = dgvCategories.Rows[RowIndex].Cells[1].Value.ToString();
            textBox3.Text = dgvCategories.Rows[RowIndex].Cells[2].Value.ToString();
            //textBox1.Text = dgvCategories.Rows[RowIndex].Cells[0].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            c.id = int.Parse(textBox1.Text);
            c.title = textBox2.Text;
            c.description = textBox3.Text;
            c.added_date = DateTime.Now;
            string loggedUser = frmLogin.loggedIn;
            string loggeduser = frmLogin.loggedIn;
            userDAL udal = new userDAL();
            userBLL usr = udal.GetIdFromUsername(loggeduser);
            c.added_by = usr.id;
            bool success = dal.Update(c);
            if(success==true)
            {
                MessageBox.Show("Cetegory Updated Succesfully ...");
                Clear();
                DataTable dt = dal.Select();
                dgvCategories.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Update Failed :/  ");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            c.id = int.Parse(textBox1.Text);
            bool success = dal.Delete(c);
            if(success==true)
            {
                MessageBox.Show("Record deleted Succesfully");
                Clear();
                DataTable dt = dal.Select();
                dgvCategories.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Error occured..!!");
            }
        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            string keywords = textSearch.Text;
            //filter the categories baser on keywords
            if(keywords!=null)
            {
                //use search method to display categories
                DataTable dt = dal.Search(keywords);
                dgvCategories.DataSource = dt;
            }
            else
            {
                //Select method to display all categories
                DataTable dt = dal.Select();
                dgvCategories.DataSource = dt;
            }
        }
    }
}
