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
            DataRow row = dtI.NewRow();
            row[0] = 0;
            row[1] = "All Products";
            dtI.Rows.InsertAt(row, 0);
            comboBox1.DisplayMember = "Product_Name";
            comboBox1.ValueMember = "Product_ID";
            comboBox1.DataSource = dtI;

        }
       

        private void frmChallanSalesReport_Load(object sender, EventArgs e)
        {
            
            FillCombo();
            dataGridView1.AutoResizeColumns();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void btnFetch_Click(object sender, EventArgs e)
        {

            DateTime FromDate = DateTime.Parse(dateTimePicker1.Value.ToString("yyyy-MM-dd"));
            DateTime ToDate = DateTime.Parse(dateTimePicker2.Value.ToString("yyyy-MM-dd"));
            DataTable dt1 = null;
            if (comboBox1.Text== "All Products")
            {
                dt1 = ChallandetailsDAL.GenerateSalesReport(FromDate, ToDate,0);
                dataGridView1.DataSource = dt1;
            }
            else
            {

                dt1 = ChallandetailsDAL.GenerateSalesReport(FromDate, ToDate, Convert.ToInt32(comboBox1.SelectedValue));
                dataGridView1.DataSource = dt1;
            }
            
        }

        
    }
}
