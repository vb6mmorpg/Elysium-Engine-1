using System;
using System.Collections.Generic;
using SharpDX;
using Elysium_Diamond.DirectX;
using Elysium_Diamond.Network;

// Refatorado 2015-08-13

namespace Elysium_Diamond.EngineWindow 
{
    public static class WindowServer {
        /// <summary>
        /// Lista de Servidores
        /// </summary>
        public static List<WindowServerRow> Server { get; set; }

        /// <summary>
        /// Posição da lista
        /// </summary>
        private static Point Position { get; set; }

        /// <summary>
        /// Imagem de fundo
        /// </summary>
        private static EngineObject BackgroundImage { get; set; }

        /// <summary>
        /// Boto
        /// </summary>
        private static EngineButton Button { get; set; }

        /// <summary>
        /// Inicia e configura os controles
        /// </summary>
        static public void Initialize() {
            Position = new Point(272, 150);

            BackgroundImage = new EngineObject(Common.Configuration.GamePath + @"\Data\Graphics\window_select.png", 480, 384);
            BackgroundImage.Position = Position;
            BackgroundImage.Transparency = 230;
            BackgroundImage.Size = new Size2(480, 384);
            BackgroundImage.SourceRect = new Rectangle(0, 0, 480, 384);

            Button = new EngineButton("back", 128, 32);
            Button.Position = new Point(Position.X + 175, Position.Y + 300);
            Button.SourceRect = new Rectangle(0, 0, 128, 32);
            Button.BorderRect = new Rectangle(20, 2, 86, 26);
            Button.Size = new Size2(128, 32);
            Button.MouseUp += BackButton_MouseUp;

            WindowServerRow.Initialize();

            Server = new List<WindowServerRow>();
            Server.Add(new WindowServerRow(new Point(Position.X + 50, Position.Y + 50)));
            Server[0].Index = 0;
            Server.Add(new WindowServerRow(new Point(Position.X + 50, Position.Y + 99)));
            Server[1].Index = 1;
            Server.Add(new WindowServerRow(new Point(Position.X + 50, Position.Y + 148)));
            Server[2].Index = 2;
            Server.Add(new WindowServerRow(new Point(Position.X + 50, Position.Y + 197)));
            Server[3].Index = 3;
            Server.Add(new WindowServerRow(new Point(Position.X + 50, Position.Y + 246)));
            Server[4].Index = 4;
        }

        /// <summary>
        /// Realiza o desenho da janela
        /// </summary>
        static public void Draw() {
            BackgroundImage.Draw();

            for (int n = 0; n < Server.Count; n++) {
                Server[n].Draw();
            }

            Button.Draw();
        }

        public static void BackButton_MouseUp(object sender, EventArgs e) {
            if (EngineMessageBox.Visible || Common.Configuration.Disconnected) { return; }

            EngineMultimedia.Play(EngineSoundEnum.Click);

            LoginServerPacket.BackToLogin();
            NetworkSocket.DiscoverServer(NetworkSocketEnum.GameServer);

            WindowLogin.TextBox[0].CursorEnabled = true;
            WindowLogin.TextBox[1].CursorEnabled = false;
            WindowLogin.TextBox[0].Clear();
            WindowLogin.TextBox[1].Clear();

            Common.Configuration.HexID = string.Empty;

            EngineCore.GameState = 1;
        }
    }
}
