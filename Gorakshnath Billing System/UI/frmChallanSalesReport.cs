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

        public void FillCombo()
        {

            comboBox1.DataSource = null;
            DataTable dtI = ProductMasterDAL.SelectForCombo();
            comboBox1.DisplayMember = "All Product";

            comboBox1.Text = "All Product";
            foreach (DataRow row in dtI.Rows)
                comboBox1.Items.Add(row["Product_Name"]);


        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmChallanSalesReport_Load(object sender, EventArgs e)
        {
            
            FillCombo();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
