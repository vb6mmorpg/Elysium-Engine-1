using System;
using System.Windows.Forms;
using Elysium_Diamond.DirectX;
using Elysium_Diamond.Common;

namespace Elysium_Diamond {
    static class Program {
        public static CreateDevice GraphicsDisplay;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args) {
            if (!Configuration.Open()) {
                MessageBox.Show("Arquivo de configuração não encontrado. O programa será fechado.");
                return;
            }

            Application.EnableVisualStyles();

            GraphicsDisplay = new CreateDevice();

            if (!EngineCore.InitializeDirectX()) {
                MessageBox.Show("Não foi possível inicializar o Direct3D. O programa será fechado.");
                return;
            }

            if (!EngineCore.InitializeEngine()) {
                MessageBox.Show("Não foi possível inicializar os recursos. O programa será fechado.");
                return;
            }

            GraphicsDisplay.Show();

            Application.Idle += new EventHandler(GraphicsDisplay.OnApplicationIdle);
            Application.Run(GraphicsDisplay);
        }
    }
}
