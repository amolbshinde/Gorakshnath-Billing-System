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

        ProductMasterDAL pDAL = new ProductMasterDAL();
        BrandDAL bDAL = new BrandDAL();
        GroupDAL gDAL = new GroupDAL();

        private void btnSearch_Click(object sender, EventArgs e)
        {
            

        }

        private void frmStockReport_Load(object sender, EventArgs e)
        {
            btnDate.Text= DateTime.Now.ToString();
            DataTable dt = stockDAL.SelectAllProductStock();
            dgvStockReport.DataSource = dt;

            DataTable dtp = pDAL.Select();
            comboProduct.DisplayMember = "Product_Name";
            comboProduct.DataSource = dtp;

            DataTable dtg = gDAL.Select();
            comboGroup.DisplayMember = "Group_Name";
            comboGroup.DataSource = dtg;

            DataTable dtb = bDAL.Select();
            comboBrand.DisplayMember = "Brand_Name";
            comboBrand.DataSource = dtb;
        }

        private void comboSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {

            string keywords = comboGroup.Text;
            
            DataTable dt = stockDAL.SelectStockByGroup(keywords);
            dgvStockReport.DataSource = dt;

        }

        private void comboBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            string keywords = comboBrand.Text;

            DataTable dt = stockDAL.SelectStockByBrand(keywords);
            dgvStockReport.DataSource = dt;
        }

        private void comboProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            string keywords = comboProduct.Text;

            DataTable dt = stockDAL.SelectStockByProduct(keywords);
            dgvStockReport.DataSource = dt;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
