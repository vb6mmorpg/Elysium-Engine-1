using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using LoginServer.Common;

namespace LoginServer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
                Application.EnableVisualStyles();

                Settings.ConnectForm = new frmMain();

                Application.Idle += new EventHandler(Settings.ConnectForm.OnApplicationIdle);

                Settings.ConnectForm.InitializeServer();

                Application.Run(Settings.ConnectForm);
        }
    }
}
