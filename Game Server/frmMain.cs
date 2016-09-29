using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using GameServer.Common;
using GameServer.MySQL;
using GameServer.Server;
using GameServer.Network;
using GameServer.Classe;
using GameServer.GameGuild;
using GameServer.Npcs;

namespace GameServer
{
    public partial class frmMain : Form  {
        public bool GameRunning = true;

        #region Peek Message
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool PeekMessage(out Message msg, IntPtr hWnd, uint messageFilterMin, uint messageFilterMax, uint flags);

        /// <summary>Windows Message</summary>
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
                ServerLoop.Loop();
            }

            if (!GameRunning) { Application.Exit(); }
        }

        private bool AppStillIdle
        {
            get {
                Message msg;
                return !PeekMessage(out msg, IntPtr.Zero, 0, 0, 0);
            }
        }
        #endregion

        public frmMain() {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e) {
            
        }

        private void exitItem_Click(object sender, EventArgs e) {
            Exit();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            LogConfig.CloseFileLog();
        }

        private void clearScreenItem_Click(object sender, EventArgs e) {
            general_textbox.Text = string.Empty;
        }

        public void InitializeServer() {
            var error = string.Empty;

            LogConfig.OpenFileLog();
            Configuration.ParseConfigFile(Constant.FILE_CONFIG);

            Settings.Name = Configuration.GetString("Name");
            LogConfig.WriteLog($"Game Server Name: {Settings.Name}", Color.CornflowerBlue);
            this.Text = $"Game Server @ {Settings.Name}";

            Settings.Discovery = Configuration.GetString("Discovery");
            LogConfig.WriteLog($"Discovery: {Settings.Discovery}", Color.Black);

            Settings.Port = Configuration.GetInt32("Port");
            LogConfig.WriteLog($"Port: {Settings.Port}", Color.Black);

            Settings.MaxConnection = Configuration.GetInt32("MaximumConnections");
            LogConfig.WriteLog($"MaximumConnections: {Settings.MaxConnection}", Color.Black);

            Settings.ConnectionTimeOut = Configuration.GetInt32("ConnectionTimeOut");
            LogConfig.WriteLog($"ConnectionTimeOut: {Settings.ConnectionTimeOut}", Color.Black);

            Settings.Logs = Convert.ToBoolean(Configuration.GetInt32("LogSystem"));
            LogConfig.WriteLog($"Logs: {Settings.Logs}", Color.Black);

            Settings.Sleep = Configuration.GetInt32("Sleep");
            LogConfig.WriteLog($"Sleep: {Settings.Sleep}", Color.Black);

            Settings.ID = Configuration.GetString("ID");
            LogConfig.WriteLog($"Game Server ID: {Settings.ID}", Color.Black);

            Settings.WorldServerID = new string[Constant.MAX_SERVER];

            LogConfig.WriteLog("Carregando config mysql", Color.Black);

            Common_DB.Server = Configuration.GetString("MySQL_IP");
            Common_DB.Port = Configuration.GetInt32("MySQL_Port");
            Common_DB.Username = Configuration.GetString("MySQL_User");
            Common_DB.Password = Configuration.GetString("MySQL_Pass");
            Common_DB.Database = Configuration.GetString("MySQL_DB");

            // Tenta se conectar ao banco de dados
            if (!Common_DB.Connect(out error)) {
                LogConfig.WriteLog(error, Color.Red);
            }
            else {
                LogConfig.WriteLog("Connectado ao banco de dados", Color.Green);
            }

            if (!string.IsNullOrEmpty(error)) { LogConfig.WriteLog(error, Color.Red); }

            for (int n = 0; n < Constant.MAX_SERVER; n++) {
                Settings.WorldServerID[n] = Configuration.GetString($"{n + 1}_WorldID");
                LogConfig.WriteLog($"WorldServer {n + 1}  ID: {Settings.WorldServerID[n]}", Color.Coral);
            }

            LogConfig.WriteLog("Carregando experiência", Color.Black);
            ServerData_DB.LoadExperience();
            LogConfig.WriteLog($"Level Max: {GameData.Level.LevelMax}", Color.BlueViolet);
            LogConfig.WriteLog($"Exp Max: {GameData.Level[GameData.Level.LevelMax]}", Color.BlueViolet);

            Guild.Guilds = null;
            // Prepara as classes para receber dados
            Guild.Guilds = new HashSet<Guild>();

            // Carrega todos os dados de guild
            LogConfig.WriteLog("Carregando guilds", Color.Black);
            Guild_DB.GuildInfo();

            Guild_DB.MemberInfo();
            LogConfig.WriteLog("Carregando membros", Color.Black);

            // Classes
            Classes.ClassesBase = new List<ClassesBase>();
            Classes.ClassesIncrement = new List<ClassesIncrement>();

            LogConfig.WriteLog("Carregando classe(s) base", Color.MediumVioletRed);
            Classes_DB.GetClasseBase();
            LogConfig.WriteLog("Carregando classe(s) incremento", Color.MediumVioletRed);
            Classes_DB.GetClasseIncrement();

            ///npc
            LogConfig.WriteLog("Carregando NPC", Color.Black);
            NpcGeneral.Npc = new HashSet<NpcData>();
            Npc_DB.InitializeNpc();

            //mapa de teste
            //Maps.MapGeneral.Map.InitializeMap();

            Authentication.HexID = new HashSet<HexaID>();
            Authentication.Player = new HashSet<PlayerData>();

            GameServerNetwork.initServerTCP();
            LogConfig.WriteLog("Game Server Start", Color.Green);
        }

        public void Exit() {
            LogConfig.CloseFileLog();
            Application.Exit();
        }
    }
}
