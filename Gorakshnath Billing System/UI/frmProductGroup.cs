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
    public partial class frmProductGroup : Form
    {
        public frmProductGroup()
        {
            InitializeComponent();
        }

        GroupBLL GroupBLL = new GroupBLL();
        GroupDAL GroupDAL = new GroupDAL();

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }
    }
}
