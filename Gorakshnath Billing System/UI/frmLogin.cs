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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        loginBLL l = new loginBLL();
        loginDAL dal = new loginDAL();
        public static string loggedIn;
       

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        //
        private void button1_Click(object sender, EventArgs e)
        {
            l.username = textBox1.Text.Trim();
            l.password = textBox2.Text.Trim();
            l.user_type = comboBox1.Text.Trim();
            bool success = dal.loginCheck(l);
            if(success==true)
            {
                MessageBox.Show(" Login Succesfull..!! ");
                //need to code what happen when login is sucesffull
                loggedIn = l.username;

                switch(l.user_type)
                {
                    case "Admin":
                        {

                            //show admin dashboard 
                            frmAdminDashboard admin = new frmAdminDashboard();
                            admin.Show();
                            this.Hide();
                        }break;

                    case "User":
                        {

                            frmUserDashboard user = new frmUserDashboard();
                            user.Show();
                            this.Hide();
                        }break;

                    default:
                        {
                            // display un error message 
                            MessageBox.Show("Invalid user type ");
                        }break;


                }
            }
            else
            {
                MessageBox.Show(" Login Failed ..!! ");
            }
        }
    }
}
