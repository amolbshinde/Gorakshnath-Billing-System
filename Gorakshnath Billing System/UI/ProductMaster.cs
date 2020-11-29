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
    public partial class ProductMaster : Form
    {
        public ProductMaster()
        {
            InitializeComponent();            
        }

        ProductMasterBLL pBLL = new ProductMasterBLL();
        ProductMasterDAL pDAL =new ProductMasterDAL();

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
        }
    }
}
