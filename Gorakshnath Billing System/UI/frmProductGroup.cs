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
            GroupBLL.Group_Name = textGroupName.Text;
            GroupBLL.Description = textDescription.Text;



            if (textGroupName.Text == "")
            {
                MessageBox.Show("Please enter Group Name");

            }
            else
            {
                GroupBLL = GroupDAL.checkGroupAvailableOrNot(textGroupName.Text);

                if (textGroupName.Text == GroupBLL.Group_Name)
                {
                    MessageBox.Show("Group is Already Added in Database Please choose another Group");

                }
                else
                {
                    GroupBLL.Group_Name = textGroupName.Text;
                    GroupBLL.Description = textDescription.Text;

                    bool success = GroupDAL.Insert(GroupBLL);
                    if (success == true)
                    {
                        MessageBox.Show("Categoriy Inserted Succesfully .!!");
                        //Clear();
                        DataTable dt = GroupDAL.Select();
                        dgvGroup.DataSource = dt;
                    }
                    else
                    {
                        MessageBox.Show("Failed to insert category :/ ");
                    }
                }
            }

            


        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            if (textGroupId.Text == "")
            {
                MessageBox.Show("Please Select The Group");
            }
            else
            {

                GroupBLL.Group_ID = int.Parse(textGroupId.Text);
                GroupBLL.Group_Name = textGroupName.Text;
                GroupBLL.Description = textDescription.Text;

                bool success = GroupDAL.Update(GroupBLL);
                if (success == true)
                {
                    MessageBox.Show("Cetegory Updated Succesfully ...");
                    //Clear();
                    DataTable dt = GroupDAL.Select();
                    dgvGroup.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Update Failed :/  ");
                }


            }


            


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            if(textGroupId.Text=="")
            {
                MessageBox.Show("Please Select The Group");
            }
            else
            {

                GroupBLL.Group_ID = int.Parse(textGroupId.Text);
                bool success = GroupDAL.Delete(GroupBLL);
                if (success == true)
                {
                    MessageBox.Show("Record deleted Succesfully");
                    //Clear();
                    DataTable dt = GroupDAL.Select();
                    dgvGroup.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Error occured..!!");
                }

            }

        }

        private void frmProductGroup_Load(object sender, EventArgs e)
        {
            DataTable dt = GroupDAL.Select();
            dgvGroup.DataSource = dt;
        }

        private void dgvGroup_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int RowIndex = e.RowIndex;
            textGroupId.Text = dgvGroup.Rows[RowIndex].Cells[0].Value.ToString();
            textGroupName.Text = dgvGroup.Rows[RowIndex].Cells[1].Value.ToString();
            textDescription.Text = dgvGroup.Rows[RowIndex].Cells[2].Value.ToString();
        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            string keywords = textSearch.Text;
            //filter the categories baser on keywords
            if (keywords != null)
            {
                //use search method to display categories
                DataTable dt = GroupDAL.Search(keywords);
                dgvGroup.DataSource = dt;
            }
            else
            {
                //Select method to display all categories
                DataTable dt = GroupDAL.Select();
                dgvGroup.DataSource = dt;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        public void clear()
        {
            textGroupName.Text = "";
            textDescription.Text = "";
            textSearch.Text = "";
        }
    }
}