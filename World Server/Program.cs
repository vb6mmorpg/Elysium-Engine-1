using System;
using System.Windows.Forms;

namespace WorldServer {
    static class Program{
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static frmMain WorldForm;  

        [STAThread]
        static void Main() {
            WorldForm = new frmMain();

            WorldForm.InitializeServer();

            Application.EnableVisualStyles();
            Application.Idle += new EventHandler(WorldForm.OnApplicationIdle);
            Application.Run(WorldForm);

        }
    }
}
