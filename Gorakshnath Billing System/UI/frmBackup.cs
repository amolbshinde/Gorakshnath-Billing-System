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


namespace Gorakshnath_Billing_System.UI
{
    public partial class frmBackup : Form
    {
        public frmBackup()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        /* private void btnBackup_Click(object sender, EventArgs e)
         {
             progressBar.Value = 0;
             try
             {
                 Server dbServer = new Server(new ServerConnection(txtServer.Text, txtUsername.Text, TxtPassword.Text));
                 Backup dbBackup = new Backup() { Action = BackupActionType.Database, Database = txtDatabase.Text };
                 dbBackup.Devices.AddDevice(@"C:\Data\AnyStore.bak", DeviceType.File);
                 dbBackup.Initialize = true;
                 dbBackup.PercentComplete += DbBackup_PercentComplete;
                 dbBackup.Complete += DbBackup_Complete;
                 dbBackup.SqlBackupAsync(dbServer);
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
         }

         private void DbBackup_PercentComplete(object sender, PercentCompleteEventArgs e)
         {
             progressBar.Invoke((MethodInvoker)delegate
             {
                 progressBar.Value = e.Percent;
                 progressBar.Update();
             });
             lblPercent.Invoke((MethodInvoker)delegate
             {
                 lblPercent.Text = $"{e.Percent}";
             });

         }

         private void DbBackup_Complete(object sender, ServerMessageEventArgs e)
         {
             if (e.Error != null)
                 lblStatus.Invoke((MethodInvoker)delegate
             {
                 lblStatus.Text = e.Error.Message;
             });
         }*/
    }
}
