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
    public partial class frmUsers : Form
    {
        public frmUsers()
        {
            InitializeComponent();
        }


        userBLL u = new userBLL();
        userDAL dal = new userDAL();
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Getting userID
            string loggedUser = frmLogin.loggedIn;  
            // Geting data from UI
            u.first_name = textBox1.Text;
            u.last_name = textBox2.Text;
            u.email = textBox3.Text;
            u.username = textBox4.Text;
            u.password = textBox5.Text;
            u.contact = textBox6.Text;
            u.address = textBox7.Text;
            u.gender = comboBox1.Text;
            u.user_type = comboBox2.Text;
            u.added_date = DateTime.Now;

           // String loggedUser = frmLogin.loggedIn;
            userBLL usr = dal.GetIdFromUsername(loggedUser);

            u.added_by = usr.id;

            //Inserting data into database
            bool success = dal.Insert(u);

            if(success==true)
            {
                //data inserted sucesfully
                MessageBox.Show("User Added Succesfully");
                clear();
            }
            else
            {
                //error occured
                MessageBox.Show("Sorry..!! , Failed to add user");
            }
            DataTable dt = dal.Select();
            dgvUsers.DataSource = dt;

        }

        private void frmUsers_Load(object sender, EventArgs e)
        {
            DataTable dt = dal.Select();
            dgvUsers.DataSource = dt;
        }

        private void clear()
        {
           textBox1.Text="";
           textBox2.Text="";
           textBox3.Text="";
           textBox4.Text="";
           textBox5.Text="";
           textBox6.Text="";
           textBox7.Text="";
           comboBox1.Text="";
           comboBox2.Text="";

        }

        private void dgvUsers_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // get index of particular row 
            int rowIndex = e.RowIndex;
            textBox8.Text = dgvUsers.Rows[rowIndex].Cells[0].Value.ToString();
            textBox1.Text = dgvUsers.Rows[rowIndex].Cells[1].Value.ToString();
            textBox2.Text = dgvUsers.Rows[rowIndex].Cells[2].Value.ToString();
            textBox3.Text = dgvUsers.Rows[rowIndex].Cells[3].Value.ToString();
            textBox4.Text = dgvUsers.Rows[rowIndex].Cells[4].Value.ToString();
            textBox5.Text = dgvUsers.Rows[rowIndex].Cells[5].Value.ToString();
            textBox6.Text = dgvUsers.Rows[rowIndex].Cells[6].Value.ToString();
            textBox7.Text = dgvUsers.Rows[rowIndex].Cells[7].Value.ToString();
            comboBox1.Text = dgvUsers.Rows[rowIndex].Cells[8].Value.ToString();
            comboBox2.Text = dgvUsers.Rows[rowIndex].Cells[9].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Get the values from userUI
            u.id = Convert.ToInt32(textBox8.Text);
            u.first_name = textBox1.Text;
            u.last_name = textBox2.Text;
            u.email = textBox3.Text;
            u.username = textBox4.Text;
            u.password = textBox5.Text;
            u.contact = textBox6.Text;
            u.address = textBox7.Text;
            u.gender = comboBox1.Text;
            u.user_type = comboBox2.Text;
            u.added_date = DateTime.Now;
            u.added_by = 1;
            //updating into database
            bool success = dal.Update(u);
            if(success==true)
            {
                MessageBox.Show("User/Admin updated Succesfully !!!");
            }
            else
            {
                MessageBox.Show("Values not got update, please retry..");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            textBox8.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            u.id = Convert.ToInt32(textBox8.Text);
            bool success = dal.Delete(u);
            if(success==true)
            {
                MessageBox.Show("User Deleted Succesfully");
                            }
            else
            {
                MessageBox.Show("Failed to delete user");
            }
            DataTable dt = dal.Select();
            dgvUsers.DataSource = dt;
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            // we need to get keyword from Text box
            string keywords = textBox9.Text;
            if(keywords!=null)
            {
                //show user from database
                DataTable dt = dal.Search(keywords);
                dgvUsers.DataSource = dt;

            }
            else
            {
                // show all users from the database
                DataTable dt = dal.Select();
                dgvUsers.DataSource = dt; 
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
    }
}
