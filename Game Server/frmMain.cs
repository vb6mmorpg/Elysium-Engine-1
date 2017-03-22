using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;
using GameServer.Common;
using GameServer.MySQL;
using GameServer.Server;
using GameServer.Network;
using GameServer.ClasseData;
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
            public Point p;
        }

        public void OnApplicationIdle(object sender, EventArgs e) {
            while (this.AppStillIdle) {
                ServerLoop.Loop();

                if (Settings.Sleep > 0) { Thread.Sleep(Settings.Sleep); }
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
            FileLog.CloseFileLog();
        }

        private void clearScreenItem_Click(object sender, EventArgs e) {
            general_textbox.Text = string.Empty;
        }

        public void InitializeServer() {
            var error = string.Empty;

            FileLog.OpenFileLog();
            Configuration.ParseConfigFile(Constant.FILE_CONFIG);

            Settings.Name = Configuration.GetString("Name");
            FileLog.WriteLog($"Game Server Name: {Settings.Name}", Color.CornflowerBlue);
            this.Text = $"Game Server @ {Settings.Name}";

            Settings.Discovery = Configuration.GetString("Discovery");
            FileLog.WriteLog($"Discovery: {Settings.Discovery}", Color.Black);

            Settings.Port = Configuration.GetInt32("Port");
            FileLog.WriteLog($"Port: {Settings.Port}", Color.Black);

            Settings.MaxConnection = Configuration.GetInt32("MaximumConnections");
            FileLog.WriteLog($"MaximumConnections: {Settings.MaxConnection}", Color.Black);

            Settings.ConnectionTimeOut = Configuration.GetInt32("ConnectionTimeOut");
            FileLog.WriteLog($"ConnectionTimeOut: {Settings.ConnectionTimeOut}", Color.Black);

            Settings.Logs = Convert.ToBoolean(Configuration.GetInt32("LogSystem"));
            FileLog.WriteLog($"Logs: {Settings.Logs}", Color.Black);

            Settings.Sleep = Configuration.GetInt32("Sleep");
            FileLog.WriteLog($"Sleep: {Settings.Sleep}", Color.Black);

            Settings.ID = Configuration.GetString("ID");
            FileLog.WriteLog($"Game Server ID: {Settings.ID}", Color.Black);

            Settings.WorldServerID = new string[Constant.MAX_SERVER];

            FileLog.WriteLog("Carregando config mysql", Color.Black);

            Common_DB.Server = Configuration.GetString("MySQL_IP");
            Common_DB.Port = Configuration.GetInt32("MySQL_Port");
            Common_DB.Username = Configuration.GetString("MySQL_User");
            Common_DB.Password = Configuration.GetString("MySQL_Pass");
            Common_DB.Database = Configuration.GetString("MySQL_DB");

            // Tenta se conectar ao banco de dados
            if (!Common_DB.Connect(out error)) {
                FileLog.WriteLog(error, Color.Red);
            }
            else {
                FileLog.WriteLog("Connectado ao banco de dados", Color.Green);
            }

            if (!string.IsNullOrEmpty(error)) { FileLog.WriteLog(error, Color.Red); }

            for (int n = 0; n < Constant.MAX_SERVER; n++) {
                Settings.WorldServerID[n] = Configuration.GetString($"{n + 1}_WorldID");
                FileLog.WriteLog($"WorldServer {n + 1}  ID: {Settings.WorldServerID[n]}", Color.Coral);
            }

            FileLog.WriteLog("Carregando experiência", Color.Black);
            ServerData_DB.LoadExperience();

            FileLog.WriteLog($"Level Max: {Experience.Level.LevelMax}", Color.BlueViolet);
            FileLog.WriteLog($"Exp Max: {Experience.Level.GetMaxExp()}", Color.BlueViolet);

            Guild.Guilds = null;
            // Prepara as classes para receber dados
            Guild.Guilds = new HashSet<Guild>();

            // Carrega todos os dados de guild
            FileLog.WriteLog("Carregando guilds", Color.Black);
            Guild_DB.GuildInfo();

            Guild_DB.MemberInfo();
            FileLog.WriteLog("Carregando membros", Color.Black);

            // Classes
            InitializeClasse();

            ///npc
            FileLog.WriteLog("Carregando NPC", Color.Black);
            NpcManager.Npc = new HashSet<NpcData>();
            Npc_DB.InitializeNpc();

            //Inicia mapas de teste
            //Maps.MapGeneral.Map.InitializeMap();
            Maps.MapManager.Add(1);
            Maps.MapManager.Add(2);
            Maps.MapManager.Add(3);

            Authentication.HexID = new HashSet<HexaID>();
            Authentication.Player = new HashSet<PlayerData>();

            

            GameNetwork.InitializeServer();
            FileLog.WriteLog("Game Server Start", Color.Green);
        }

        public void InitializeClasse() {
            Classe.Classes = new List<Classe>();

            FileLog.WriteLog("Carregando classe(s) base", Color.MediumVioletRed);
            Classes_DB.GetClasseStatsBase();

            FileLog.WriteLog("Carregando classe(s) incremento", Color.MediumVioletRed);

            for (var index = 0; index < Classe.Classes.Count; index++) {
                Classes_DB.GetClasseStatsIncrement(index, Classe.Classes[index].IncrementID);
            }
        }

        public void Exit() {
            FileLog.CloseFileLog();
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e) {

           
        }
    }
}
