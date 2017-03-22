using System;
using System.Collections.Generic;
using SharpDX;
using Elysium_Diamond.DirectX;
using Elysium_Diamond.Network;

namespace Elysium_Diamond.EngineWindow {
    public static class WindowServer {
        /// <summary>
        /// Lista de Servidores
        /// </summary>
        public static List<WindowServerRow> Server { get; set; }

        /// <summary>
        /// Posição da lista
        /// </summary>
        private static Point position { get; set; }

        /// <summary>
        /// Imagem de fundo
        /// </summary>
        private static EngineObject background { get; set; }

        /// <summary>
        /// Boto
        /// </summary>
        private static EngineButton button { get; set; }

        /// <summary>
        /// Inicia e configura os controles
        /// </summary>
        public static void Initialize() {
            position = new Point(272, 150);

            background = new EngineObject($"{Common.Configuration.GamePath}\\Data\\Graphics\\window_select.png", 480, 384);
            background.Position = position;
            background.Transparency = 230;
            background.Size = new Size2(480, 384);
            background.SourceRect = new Rectangle(0, 0, 480, 384);

            button = new EngineButton("back", 128, 32);
            button.Position = new Point(position.X + 175, position.Y + 300);
            button.SourceRect = new Rectangle(0, 0, 128, 32);
            button.BorderRect = new Rectangle(20, 2, 86, 26);
            button.Size = new Size2(128, 32);
            button.MouseUp += Button_MouseUp;

            //inicia a lista de servidores
            Server = new List<WindowServerRow>();
            Server.Add(new WindowServerRow(new Point(position.X + 50, position.Y + 50)));
            Server[0].Index = 0;
            Server.Add(new WindowServerRow(new Point(position.X + 50, position.Y + 99)));
            Server[1].Index = 1;
            Server.Add(new WindowServerRow(new Point(position.X + 50, position.Y + 148)));
            Server[2].Index = 2;
            Server.Add(new WindowServerRow(new Point(position.X + 50, position.Y + 197)));
            Server[3].Index = 3;
            Server.Add(new WindowServerRow(new Point(position.X + 50, position.Y + 246)));
            Server[4].Index = 4;
        }

        /// <summary>
        /// Desenha os controles
        /// </summary>
        public static void Draw() {
            background.Draw();

            for (int n = 0; n < Server.Count; n++) { Server[n].Draw(); }             
   
            button.Draw();
        }

        /// <summary>
        /// Volta para a tela de login.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void Button_MouseUp(object sender, EventArgs e) {
            if (EngineMessageBox.Visible || Common.Configuration.Disconnected) { return; }

            EngineMultimedia.Play(EngineSoundEnum.Click);

            LoginPacket.BackToLogin();
            NetworkSocket.DiscoverServer(NetworkSocketEnum.GameServer);

            WindowLogin.textbox[0].CursorEnabled = true;
            WindowLogin.textbox[1].CursorEnabled = false;
            WindowLogin.textbox[0].Clear();
            WindowLogin.textbox[1].Clear();

            Common.Configuration.HexID = string.Empty;

            EngineCore.GameState = 1;
        }
    }
}
