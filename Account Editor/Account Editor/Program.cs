using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Account_Editor
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static FormMain EditForm;
        
        [STAThread]
        static void Main()
        {
            // Gerar novo formulário e configurando
            EditForm = new FormMain();
            EditForm.Connect_Mysql();
            EditForm.Width = 375;
            EditForm.Height = 316;
            EditForm.pnlConsole.Top = 56;
            EditForm.pnlConsole.Height = 209;

            // Executar Aplicação
            Application.EnableVisualStyles();
            Application.Run(EditForm);
        }
    }
}
