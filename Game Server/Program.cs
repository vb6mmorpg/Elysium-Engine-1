using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GameServer.Common;
using GameServer.Server;

namespace GameServer {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();

            FileLog.MainForm = new frmMain();

            Application.Idle += new EventHandler(FileLog.MainForm.OnApplicationIdle);

            FileLog.MainForm.InitializeServer();

            Application.Run(FileLog.MainForm);
        }
    }
}
