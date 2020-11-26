using Gorakshnath_Billing_System.BLL;
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
        }
    }
}
