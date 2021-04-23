using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace Gorakshnath_Billing_System.UI
{
    public partial class frmBackup : Form
    {
        public frmBackup()
        {
            InitializeComponent();
        }

        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        SqlConnection con = new SqlConnection(myconnstrng);
        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fd = new FolderBrowserDialog();
            if(fd.ShowDialog()==DialogResult.OK)
            {
                txtPath.Text = fd.SelectedPath;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {                
                con.Open();
                string query = "BACKUP DATABASE ["+con.Database+"] TO  DISK = N'"+ txtPath .Text+ "\\"+con.Database +".bak'";
                //WITH NOFORMAT, NOINIT,  NAME = N'AnyStore-Full Database Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Backup Completed Sucesfully");


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {

            try
            {
                /*con.Open();
                string get_db_offline = "alter database[Anystore] set single_user with rollback immediate";
                SqlCommand cmd1 = new SqlCommand(get_db_offline,con);
                cmd1.ExecuteNonQuery();
                con.Close();*/

                con.Open();
                string query = "RESTORE DATABASE [" + con.Database + "] FROM  DISK = N'"+txtRestore.Text+"' WITH  FILE = 1;";
                //WITH NOFORMAT, NOINIT,  NAME = N'AnyStore-Full Database Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10
                SqlCommand cmd = new SqlCommand(query, con);                               
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Restore Completed Sucesfully");
                /*con.Open();
                string get_db_online = "ALTER DATABASE [Anystore] SET multi_user";
                SqlCommand cmd2 = new SqlCommand(get_db_online, con);
                cmd2.ExecuteNonQuery();
                con.Close();*/


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
               /* con.Open();
                string get_db_online = "ALTER DATABASE [Anystore] SET multi_user";
                SqlCommand cmd2 = new SqlCommand(get_db_online, con);
                cmd2.ExecuteNonQuery();*/
                con.Close();

            }

        }

        private void button4_Click(object sender, EventArgs e)
        {

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter="Backup File(*.bak)|*.bak";
            ofd.Title = "Select Backup file";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtRestore.Text = ofd.FileName;
            }
        }
    }
}
