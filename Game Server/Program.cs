using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GameServer.Common;
using GameServer.Server;

namespace GameServer
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

            LogConfig.mainForm = new frmMain();

            Application.Idle += new EventHandler(LogConfig.mainForm.OnApplicationIdle);

            LogConfig.mainForm.InitializeServer();

            Application.Run(LogConfig.mainForm);
        }
    }
}
