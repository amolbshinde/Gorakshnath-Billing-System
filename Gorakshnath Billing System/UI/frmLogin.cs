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
            DialogResult dialog = new DialogResult();

            dialog = MessageBox.Show("Do you really want to close?", "Alert!", MessageBoxButtons.YesNo);

            if (dialog == DialogResult.Yes)
            {
              
                System.Environment.Exit(1);
            }
        }
        /// <summary>
        /// //
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            DateTime dt1 = DateTime.Now;
            //DateTime dt2;
            //DateTime.TryParse("25/12/2021", out dt2);
            DateTime dt2 = DateTime.Parse("2021/12/12");
            if (dt1.Date>dt2.Date)
            {
                if (MessageBox.Show(dt2+"Your licence has expired please do renewal of the software"+"\n"+ "OR Contact our Customer Care No.: 8087448384/9561948924"+"\n"+"Do you want to visit Companies Website. ", "Product Activation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start("http://swamisoftware.ml/");
                }
            }
            else
            {
                l.username = textBox1.Text.Trim();
                l.password = textBox2.Text.Trim();
                l.user_type = comboBox1.Text.Trim();
                bool success = dal.loginCheck(l);
                if (success == true)
                {
                    MessageBox.Show(" Login Succesfull..!! ");
                    //need to code what happen when login is sucesffull.
                    loggedIn = l.username;

                    switch (l.user_type)
                    {
                        case "Admin":
                            {

                                
                                frmAdminDashboard admin = new frmAdminDashboard();
                                admin.Show();
                                this.Hide();
                            } break;

                        case "User":
                            {

                                frmUserDashboard user = new frmUserDashboard();
                                user.Show();
                                this.Hide();
                            } break;

                        default:
                            {
                                // display un error message 
                                MessageBox.Show("Invalid user type ");
                            } break;


                    }
                }
                else
                {
                    MessageBox.Show(" Login Failed ..!! ");
                }
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 1;
        }
    }
}
