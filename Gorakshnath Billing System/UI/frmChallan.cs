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
    public partial class frmChallan : Form
    {
        public frmChallan()
        {
            InitializeComponent();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "Non GST")
            {
                comboBox3.Enabled = false;
                textGST.Enabled = false;
            }
            else if (comboBox2.Text == "GST")
            {
                comboBox3.Enabled = true;
                textGST.Enabled = true;

            }
                      
                
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
