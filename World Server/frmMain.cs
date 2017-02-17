using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WorldServer.Common;
using WorldServer.Network;
using WorldServer.MySQL;
using WorldServer.Server;
using WorldServer.ClasseData;
using WorldServer.GameGuild;
using System.Runtime.InteropServices;
using System.Threading;
using WorldServer.LuaScript;

namespace WorldServer {        
    public partial class frmMain : Form {
        #region Peek Message
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool PeekMessage(out Message msg, IntPtr hWnd, uint messageFilterMin, uint messageFilterMax, uint flags);

        /// <summary>Windows Message</summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct Message
        {
            public IntPtr hWnd;
            public IntPtr msg;
            public IntPtr wParam;
            public IntPtr lParam;
            public uint time;
            public System.Drawing.Point p;
        }
        public void OnApplicationIdle(object sender, EventArgs e)
        {
            while (this.AppStillIdle)
            {
                World.Loop();

                if (Settings.Sleep > 0) { Thread.Sleep(Settings.Sleep); }
            }
        }
        private bool AppStillIdle
        {
            get
            {
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

        private void quit_MenuItem_Click(object sender, EventArgs e) {
            FileLog.Close();
            Application.Exit();
        }
        private void ShowForm(object sender, EventArgs e) {
            trayIcon.Visible = false;
            Visible = true;
            ShowInTaskbar = true;  
        }
  
        public void InitializeServer() {
            trayIcon = new NotifyIcon();
            trayMenu = new ContextMenu();

            Configuration.ParseConfigFile(Constant.FILE_CONFIG);

            // CARREGA TODAS AS INFORMAÇÕES DE CONFIURAÇÃO 
            Settings.WorldServerName = Configuration.GetString("WorldServerName");
            WriteLog($"World Server Name: {Settings.WorldServerName}", Color.CornflowerBlue);
            this.Text = $"World Server @ {Settings.WorldServerName}";
            
            Settings.Discovery = Configuration.GetString("Discovery");
            WriteLog($"Discovery: {Settings.Discovery}", Color.Black);

            Settings.Port = Configuration.GetInt32("Port");
            WriteLog($"Port: {Settings.Port}", Color.Black);

            Settings.MaxConnection = Configuration.GetInt32("MaximumConnections");
            WriteLog($"MaxConnection: {Settings.MaxConnection}", Color.Black);

            Settings.ConnectionTimeOut = Configuration.GetInt32("ConnectionTimeOut");
            WriteLog($"ConnectionTimeOut: {Settings.ConnectionTimeOut}", Color.Black);

            Settings.LogSystem = Configuration.GetBoolean("LogSystem");
            WriteLog($"LogSystem: {Settings.LogSystem}", Color.Black);

            Settings.Sleep = Configuration.GetInt32("Sleep");
            WriteLog($"Sleep: {Settings.Sleep}", Color.Black);

            LuaConfig.InitializeConfig();

            WriteLog($"Create Character: {GameSettings.CharacterCreation}", Color.MediumVioletRed);
            WriteLog($"Delete Character: {GameSettings.CharacterDelete}", Color.MediumVioletRed);

            InitializeServerConfig();

            if (Settings.LogSystem == true) {
                WriteLog("LogSystem - Ativado.", Color.Green);
                FileLog.Open();
            }
            else 
                WriteLog("LogSystem - Desativado.", Color.Black); 

            WriteLog("Carregando config do mysql", Color.Black);

            string tempError = string.Empty;

            Common_DB.Server = Configuration.GetString("MySQL_IP");
            Common_DB.Port = Configuration.GetInt32("MySQL_Port");
            Common_DB.Username = Configuration.GetString("MySQL_User");
            Common_DB.Password = Configuration.GetString("MySQL_Pass");
            Common_DB.Database = Configuration.GetString("MySQL_DB");

            // Tenta fazer a conexão com o banco de dados
            if (!Common_DB.Open(out tempError)) 
                WriteLog(tempError, Color.Red);
            else 
                WriteLog("Connectado ao banco de dados", Color.Green);
          

            Authentication.HexID = new HashSet<HexaID>();
            Authentication.Player = new HashSet<PlayerData>();

            InitializeGuild();
            InitializeClasse();
        
            WorldNetwork.InitializeServer();
            GameNetwork.InitializeGameServer();

            WriteLog("World Server Start.", Color.Green);

            //################# sysTray ########################
            trayMenu.MenuItems.Add("Mostrar", ShowForm);
            trayMenu.MenuItems.Add("Sair", quit_MenuItem_Click);

            trayIcon.Text = "World Server @";
            trayIcon.Icon = this.Icon;

            trayIcon.ContextMenu = trayMenu;
        }

        public void WriteLog(string log, Color color) {
            general_textbox.SelectionStart = general_textbox.TextLength;
            general_textbox.SelectionLength = 0;

            general_textbox.SelectionColor = color;
            general_textbox.AppendText($"{DateTime.Now}: {log}{Environment.NewLine}");
            general_textbox.SelectionColor = color;

            general_textbox.ScrollToCaret();
        }

        public void InitializeGuild() {
            Guild.Guilds = null;

            // Prepara as classes para receber dados
            Guild.Guilds = new HashSet<Guild>();

            // Carrega todos os dados de guild
            WriteLog("Carregando guilds.", Color.Black);
            Guild_DB.GuildInfo();

            WriteLog("Carregando membros.", Color.Black);
            Guild_DB.MemberInfo();

        }

        public void InitializeClasse() {
            Classe.Classes = new List<Classe>();
            
            WriteLog("Carregando classe(s) base.", Color.BlueViolet);
            Classes_DB.GetClasseStatsBase();

            WriteLog("Carregando classe(s) incremento.", Color.BlueViolet);

            for(var index = 0; index < Classe.Classes.Count; index++) {
                Classes_DB.GetClasseStatsIncrement(index, Classe.Classes[index].IncrementID);
            }
                
            WriteLog("Carregando classe(s) items.", Color.BlueViolet);
            for (var index = 0; index < Classe.Classes.Count; index++) {
                Classes_DB.GetClasseItem(index, Classe.Classes[index].ID);
            }
        }

        private void InitializeServerConfig() {
            Settings.GameServer = new List<ServerData>();
            var enabled = 0;

            for (var i = 0; i < Constant.MAX_SERVER; i++) {
                Settings.GameServer.Add(new ServerData());              

                enabled = Configuration.GetInt32((i + 1) + "_Enabled");

                if (enabled == 0) {
                    Settings.GameServer[i].Clear();
                }
                else {
                    Settings.GameServer[i].Name = Configuration.GetString((i + 1) + "_Name");
                    Settings.GameServer[i].Region = Configuration.GetString((i + 1) + "_Region");
                    Settings.GameServer[i].GameServerIP = Configuration.GetString((i + 1) + "_GameServerIP");
                    Settings.GameServer[i].GameServerLocalIP = Configuration.GetString((i + 1) + "_GameServerLocalIP");
                    Settings.GameServer[i].GameServerPort = Configuration.GetInt32((i + 1) + "_GameServerPort");
                    Settings.GameServer[i].Status = Configuration.GetString((i + 1) + "_Status");

                    WriteLog($"Game Server: {Settings.GameServer[i].Name} {Settings.GameServer[i].Region} {Settings.GameServer[i].Status}", Color.Coral);
                }
            }
        }

        #region Menu
        private void min_MenuItem_Click(object sender, EventArgs e) {
            trayIcon.Visible = true;
            Visible = false;
            ShowInTaskbar = false;  
        }
        private void clear_MenuItem_Click(object sender, EventArgs e) {
            general_textbox.Clear();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e) {
            e.Cancel = true;

            FileLog.Close();

            e.Cancel = false;
        }

        /// <summary>
        /// Recarrega guilds e config
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void reloadGuild_MenuItem_Click(object sender, EventArgs e) {
            InitializeGuild();
        }


        /// <summary>
        /// Recarrega config de personagens
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void reloadChar_MenuItem_Click(object sender, EventArgs e) {
            //InitializeCharacter();
        }

        /// <summary>
        /// Recarrega classes e config
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void reloadClasse_MenuItem_Click(object sender, EventArgs e) {
            InitializeClasse();
        }
        #endregion

        private void reloadServerData_MenuItem_Click(object sender, EventArgs e) {
            InitializeServerConfig();
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
