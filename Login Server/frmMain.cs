using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using LoginServer.Network;
using LoginServer.Common;
using LoginServer.Server;
using System.Runtime.InteropServices;
using System.Threading;
using LoginServer.MySQL;

namespace LoginServer
{        
    public partial class frmMain : Form {
        #region Peek Message
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool PeekMessage(out Message msg, IntPtr hWnd, uint messageFilterMin, uint messageFilterMax, uint flags);   

        [StructLayout(LayoutKind.Sequential)]
        public struct Message {
            public IntPtr hWnd;
            public IntPtr msg;
            public IntPtr wParam;
            public IntPtr lParam;
            public uint time;
            public System.Drawing.Point p;
        }

        public void OnApplicationIdle(object sender, EventArgs e) {
            while (this.AppStillIdle) {

                Login.Loop();

                if (Settings.Sleep > 0) { Thread.Sleep(Settings.Sleep); }
            }
        }

        private bool AppStillIdle {
            get {
                Message msg;
                return !PeekMessage(out msg, IntPtr.Zero, 0, 0, 0);
            }
        }
        #endregion

        NotifyIcon trayIcon;
        ContextMenu trayMenu;
        
        public frmMain() {
            InitializeComponent();
        }

        private void ShowForm(object sender, EventArgs e) {
            trayIcon.Visible = false;
            Visible = true;
            ShowInTaskbar = true;  
        }

        /// <summary>
        /// Inicializa o servidor
        /// </summary>
        public void InitializeServer() {
            trayIcon = new NotifyIcon();
            trayMenu = new ContextMenu();

            Configuration.ParseConfigFile(Environment.CurrentDirectory + @"\"+ Settings.FileConfig);

            Settings.Discovery = Configuration.GetString("Discovery");
            WriteLog("Discovery: " + Settings.Discovery, Color.Black);

            Settings.IP = Configuration.GetString("IP");
            WriteLog("IP: " + Settings.IP, Color.Black);

            Settings.Port = Configuration.GetInt32("Port");
            WriteLog("Port: " + Settings.Port, Color.Black);

            Settings.MaxConnection = Configuration.GetInt32("MaximumConnections");
            WriteLog("MaxConnection: " + Settings.MaxConnection, Color.Black);

            Settings.LogSystem = Configuration.GetByte("LogSystem");
            WriteLog("LogSystem: " + Settings.LogSystem, Color.Black);

            Settings.Sleep = Configuration.GetInt32("Sleep");
            WriteLog("Sleep: " + Settings.Sleep, Color.Black);

            Settings.Version = Configuration.GetString("CheckVersion");
            WriteLog("Version: " + Settings.Version, Color.Black);

            if (Settings.LogSystem == 1) {
                WriteLog("LogSystem - Ativado.", Color.Green);
                LogConfig.OpenFileLog();
            }
            else {
                WriteLog("LogSystem - Desativado.", Color.Black);
            }

            Settings.Server = new List<ServerData>();
            Authentication.Player = new HashSet<PlayerData>();

            InitializeServerConfig();
            InitializeDatabaseConfig();

            var tempError = string.Empty;
            if (!Common_DB.Connect(out tempError)) {
                WriteLog(tempError, Color.Red);
            }
            else {
                WriteLog("Connectado ao banco de dados", Color.Green);
            }

            WriteLog("Conectando World Server.", Color.Green);

            WorldServerNetwork.InitializeWorldServer();

            WriteLog("Login Server Start.", Color.Green);

            LoginServerNetwork.InitializeServer();

            #region Tray System
            trayMenu.MenuItems.Add("Mostrar", ShowForm);
            trayMenu.MenuItems.Add("Sair", quit_MenuItem_Click);

            trayIcon.Text = "Connect Server @";
            trayIcon.Icon = this.Icon;

            trayIcon.ContextMenu = trayMenu;
            #endregion
        }

        public void WriteLog(string log, Color color) {
            general_textbox.SelectionStart = general_textbox.TextLength;
            general_textbox.SelectionLength = 0;

            general_textbox.SelectionColor = color;
            general_textbox.AppendText(DateTime.Now + ": " + log + Environment.NewLine);
            general_textbox.SelectionColor = color;

            general_textbox.ScrollToCaret();
        }

        #region Menu Item
        //File -> Minimize
        private void min_MenuItem_Click(object sender, EventArgs e) {
            trayIcon.Visible = true;
            Visible = false;
            ShowInTaskbar = false;
        }

        //File -> Quit
        private void quit_MenuItem_Click(object sender, EventArgs e) {
            Login.Close();

            trayIcon.Visible = false;
            trayIcon.Dispose();

            Application.Exit();
        }

        //Config -> Clear
        private void clear_MenuItem_Click(object sender, EventArgs e) {
            general_textbox.Clear();
        }
        
        //Config -> Reload Server List
        private void reload_MenuItem_Click(object sender, EventArgs e) {
            InitializeServerConfig();
        }

        private void reloadVersion_MenuItem_Click(object sender, EventArgs e) {
            Configuration.ParseConfigFile(Environment.CurrentDirectory + @"\" + Settings.FileConfig);
            Settings.Version = Configuration.GetString("CheckVersion");
            WriteLog("Version: " + Settings.Version, Color.Black);
        }

        private void disableLogin_MenuItem_Click(object sender, EventArgs e) {
            if (disableLogin_MenuItem.Checked) 
                Settings.CantConnectNow = true;
            else 
                Settings.CantConnectNow = false;                    
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e) {
            e.Cancel = true;

            Login.Close();

            trayIcon.Visible = false;
            trayIcon.Dispose();

            e.Cancel = false;
        }
        #endregion

        private void frmMain_Load(object sender, EventArgs e) {
            this.Show();
        }

        private void checkLog_Click(object sender, EventArgs e) {
            Settings.LogSystemScreen = checkLog.Checked;
        }

        /// <summary>
        /// Carrega as configurações de servidores
        /// </summary>
        public static void InitializeServerConfig() {
            var enabled = 0;
            for (var i = 0; i < 5; i++) {
                Settings.Server.Add(new ServerData());

                enabled = Configuration.GetInt32((i + 1) + "_Enabled");

                if (enabled == 0) {
                    Settings.Server[i].Name = string.Empty;
                    Settings.Server[i].WorldServerIP = string.Empty;
                    Settings.Server[i].WorldServerLocalIP = string.Empty;
                    Settings.Server[i].Region = string.Empty;
                    Settings.Server[i].Status = string.Empty;
                }
                else {
                    Settings.Server[i].Name = Configuration.GetString((i + 1) + "_Name");
                    Settings.Server[i].Region = Configuration.GetString((i + 1) + "_Region");
                    Settings.Server[i].WorldServerIP = Configuration.GetString((i + 1) + "_WorldServerIP");
                    Settings.Server[i].WorldServerLocalIP = Configuration.GetString((i + 1) + "_WorldServerLocalIP");
                    Settings.Server[i].WorldServerPort = Configuration.GetInt32((i + 1) + "_WorldServerPort");
                    Settings.Server[i].Status = Configuration.GetString((i + 1) + "_Status");

                    LogConfig.WriteLog("Servidor adicionado: " + Settings.Server[i].Name + " " + Settings.Server[i].Region + " " + Settings.Server[i].Status, System.Drawing.Color.Coral);
                }
            }
        }

        /// <summary>
        /// Obtém todas as configurações de arquivo.
        /// </summary>
        public static void InitializeDatabaseConfig() {
            Common_DB.Server = Configuration.GetString("MySQL_IP");
            Common_DB.Port = Configuration.GetInt32("MySQL_Port");
            Common_DB.Username = Configuration.GetString("MySQL_User");
            Common_DB.Password = Configuration.GetString("MySQL_Pass");
            Common_DB.Database = Configuration.GetString("MySQL_DB");
        }

        /// <summary>
        /// Limpa todo o registro de log na tela.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerClear_Tick(object sender, EventArgs e) {
            general_textbox.Clear();
        }

        /// <summary>
        /// Ativa o timer para limpar o registro na tela.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearScreenSeconds_Click(object sender, EventArgs e) { 
            if (ClearScreenSeconds.Checked) {
                ClearScreenSeconds.Checked = false;
                timerClear.Stop();
            }
            else {
                ClearScreenSeconds.Checked = true;
                timerClear.Start();
            }
        }
    }
}
