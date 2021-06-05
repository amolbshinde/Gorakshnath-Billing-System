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
    public partial class frmChallanSalesReport : Form
    {
        public frmChallanSalesReport()
        {
            InitializeComponent();
            //FillCombo();
        }
        ProductMasterDAL ProductMasterDAL = new ProductMasterDAL();
        challandetailsDAL ChallandetailsDAL = new challandetailsDAL();

        public void FillCombo()
        {
            DataTable dtI = ProductMasterDAL.SelectForCombo();
            comboBox1.DataSource = dtI;
            comboBox1.Text = "All Products";
            comboBox1.ValueMember = "Product_ID";
            comboBox1.DisplayMember = "Product_Name";
        }
       

        private void frmChallanSalesReport_Load(object sender, EventArgs e)
        {
            
            FillCombo();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            DateTime FromDate = DateTime.Parse(dateTimePicker1.Value.ToString("yyyy-MM-dd"));
            DateTime ToDate = DateTime.Parse(dateTimePicker2.Value.ToString("yyyy-MM-dd"));
            DataTable dt1 = null;
            if (Convert.ToInt32(comboBox1.SelectedValue)>0)
            {
                 dt1= ChallandetailsDAL.GenerateSalesReport(FromDate, ToDate,Convert.ToInt32(comboBox1.SelectedValue));
            }
            else
            {

                dt1 = ChallandetailsDAL.GenerateSalesReport(FromDate, ToDate);
            }
            dataGridView1.DataSource = dt1;
        }
    }
}
