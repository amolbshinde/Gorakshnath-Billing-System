﻿using Gorakshnath_Billing_System.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gorakshnath_Billing_System
{
    static class Program
    {
        /// <summary>////
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogin()); 
            //Application.Run(new frmAdminDashboard());
        }
    }
}
