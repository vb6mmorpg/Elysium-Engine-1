using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Classe_Editor
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Static.frmMain = new Form1();
            Application.EnableVisualStyles();
            Application.Run(Static.frmMain);
        }
    }
}
