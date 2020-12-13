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
    public partial class frmStockReport : Form
    {
        public frmStockReport()
        {
            InitializeComponent();
        }

        stockBLL stockBLL = new stockBLL();
        stockDAL stockDAL = new stockDAL();


        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keywords = textKeyword.Text;

            //Product_Group Product_Brand//
            if (comboSearchBy.Text== "Product_Group")
            {
                DataTable dt = stockDAL.SelectGroupByProductGroupStock(keywords);
                dgvStockReport.DataSource = dt;
            }

            if (comboSearchBy.Text == "Product_Brand")
            {
                DataTable dt = stockDAL.SelectGroupByProductBrandStock(keywords);
                dgvStockReport.DataSource = dt;
            }

        }

        private void frmStockReport_Load(object sender, EventArgs e)
        {
            DataTable dt = stockDAL.SelectAllProductStock();
            dgvStockReport.DataSource = dt;
        }
    }
}
