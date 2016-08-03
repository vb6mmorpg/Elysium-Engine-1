using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Elysium_Diamond.DirectX;
using Elysium_Diamond.Common;

namespace Elysium_Diamond
{
    static class Program
    {
        public static CreateDevice graphicsDisplay;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Settings.LoginServerIP = ConfigGet.ConfigGetString(Environment.CurrentDirectory + @"\Config.txt", "IP");
            Settings.LoginServerPort = (int)ConfigGet.ConfigGetLong(Environment.CurrentDirectory + @"\Config.txt", "PORT");

            Application.EnableVisualStyles();

            graphicsDisplay = new CreateDevice();

            EngineCore.Target = graphicsDisplay;

            if (!EngineCore.Initialize())
            {
                MessageBox.Show("Não foi possível inicializar o Direct3D. O programa será fechado.");
                return;
            }

            graphicsDisplay.Show();

            Application.Idle += new EventHandler(graphicsDisplay.OnApplicationIdle);
            Application.Run(graphicsDisplay);
        }
    }
}
