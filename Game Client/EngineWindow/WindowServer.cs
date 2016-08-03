﻿using System;
using System.Collections.Generic;
using SharpDX;
using SharpDX.Direct3D9;
using Color = SharpDX.Color;
using Elysium_Diamond.DirectX;
using Elysium_Diamond.Common;
using Elysium_Diamond.Network;

// Refatorado 2015-08-13

namespace Elysium_Diamond.GameWindow 
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
            Position = new Point(287, 150);

            BackgroundImage = new EngineObject(Settings.GamePath + @"\Data\Graphics\Window_Server_1.png", 455, 360);
            BackgroundImage.Position = Position;
            BackgroundImage.Transparency = 230;
            BackgroundImage.Size = new Size2(455, 360);
            BackgroundImage.SourceRect = new Rectangle(0, 0, 455, 360);

            Button = new EngineButton(Language.Portuguese, Settings.GamePath, "Back", 103, 30);
            Button.Size = new Size2(103, 30);
            Button.Position = new Point(Position.X + 175, Position.Y + 300);
            Button.SourceRect = new Rectangle(0, 0, 103, 30);
            Button.BorderRect = new Rectangle(9, 2, 86, 26);
            Button.Size = new Size2(103, 30);
            Button.MouseUp += BackButton_MouseUp;

            WindowServerRow.Initialize();

            Server = new List<WindowServerRow>();
            Server.Add(new WindowServerRow(new Point(Position.X + 52, Position.Y + 50)));
            Server[0].Index = 0;
            Server.Add(new WindowServerRow(new Point(Position.X + 52, Position.Y + 99)));
            Server[1].Index = 1;
            Server.Add(new WindowServerRow(new Point(Position.X + 52, Position.Y + 148)));
            Server[2].Index = 2;
            Server.Add(new WindowServerRow(new Point(Position.X + 52, Position.Y + 197)));
            Server[3].Index = 3;
            Server.Add(new WindowServerRow(new Point(Position.X + 52, Position.Y + 246)));
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
            if (EngineMessageBox.Visible || Settings.Disconnected) { return; }

            EngineMultimedia.Play(EngineSoundEnum.Click);

            LoginServerPacket.BackToLogin();
            GameServerNetwork.Instance.DiscoverServer();

            WindowLogin.TextBox[0].CursorEnabled = true;
            WindowLogin.TextBox[1].CursorEnabled = false;
            WindowLogin.TextBox[0].Clear();
            WindowLogin.TextBox[1].Clear();

            Settings.HexID = string.Empty;

            EngineCore.GameState = 1;
        }
    }
}
