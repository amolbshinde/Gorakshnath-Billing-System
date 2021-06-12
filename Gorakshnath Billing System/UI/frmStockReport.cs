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
using Excel = Microsoft.Office.Interop.Excel;
//using Word = Microsoft.Office.Interop.Word;

namespace Gorakshnath_Billing_System.UI
{
    public partial class frmStockReport : Form
    {
        public frmStockReport()
        {
            InitializeComponent();
            fillCombp();
        }

        stockBLL stockBLL = new stockBLL();
        stockDAL stockDAL = new stockDAL();

        ProductMasterDAL pDAL = new ProductMasterDAL();
        BrandDAL bDAL = new BrandDAL();
        GroupDAL gDAL = new GroupDAL();

        public void fillCombp()
        {
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

        

        private void frmStockReport_Load(object sender, EventArgs e)
        {
            btnDate.Text= DateTime.Now.ToString();
            DataTable dt = stockDAL.SelectAllProductStock();
            dgvStockReport.DataSource = dt;
            dgvStockReport.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

        }

        private void comboSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {

            string keywords = comboGroup.Text;
            
            DataTable dt = stockDAL.SelectStockByGroup(keywords);
            dgvStockReport.DataSource = dt;
            dgvStockReport.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

        }

        private void comboBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            string keywords = comboBrand.Text;

            DataTable dt = stockDAL.SelectStockByBrand(keywords);
            dgvStockReport.DataSource = dt;
            dgvStockReport.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void comboProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            string keywords = comboProduct.Text;

            DataTable dt = stockDAL.SelectStockByProduct(keywords);
            dgvStockReport.DataSource = dt;
            dgvStockReport.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DataTable dt = stockDAL.SelectAllStock();
            dgvStockReport.DataSource = dt;
            dgvStockReport.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void copyAlltoClipboard()
        {
            //to remove the first blank column from datagridview
            dgvStockReport.RowHeadersVisible = false;
            dgvStockReport.SelectAll();
            DataObject dataObj = dgvStockReport.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            
            
                copyAlltoClipboard();
                Microsoft.Office.Interop.Excel.Application xlexcel;
                Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
                Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;
                xlexcel = new Excel.Application();
                xlexcel.Visible = true;
                xlWorkBook = xlexcel.Workbooks.Add(misValue);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                Excel.Range CR = (Excel.Range)xlWorkSheet.Cells[1, 1];
                CR.Select();
                xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
            
        }
    }
}
