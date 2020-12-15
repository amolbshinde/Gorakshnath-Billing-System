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
    public partial class frmChallanReport : Form
    {
        public frmChallanReport()
        {
            InitializeComponent();
        }

        challanBLL ChallanBLL = new challanBLL();
        challanDAL challanDAL = new challanDAL();
        

        private void frmChallanReport_Load(object sender, EventArgs e)
        {
            DataTable dt = challanDAL.SelectTD();
            dgvChallanReport.DataSource = dt;
        }
    }
}
