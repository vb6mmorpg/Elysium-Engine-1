﻿using System;
using SharpDX;
using SharpDX.Direct3D9;
using Color = SharpDX.Color;
using Elysium_Diamond.DirectX;
using Elysium_Diamond.Network;


namespace Elysium_Diamond.EngineWindow
{
    public class WindowServerRow : IDisposable {
        public Point Position { get; set; }
        public string Serial { get; set; }
        public string IP { get; set; }
        public int Port { get; set; }
        public string Name { get; set; }
        public string Region { get; set; }
        public string Status { get; set; }
        public int PlayerActive { get; set; }
        public int PlayerMax { get; set; }
        public int Index { get; set; }
        public ServerType Type { get; set; }

        public enum ServerType {
            WorldServer,
            GameServer, 
            EventServer
        }

        private EngineObject BackgroundImage { get; set; }
        private static Texture[] texture = new Texture[2];
        private int index = 0;
        private Color color = Color.White;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="position"></param>
        public WindowServerRow(Point position) {
            BackgroundImage = new EngineObject();
            BackgroundImage.Enabled = true;
            BackgroundImage.Transparency = 255;
            BackgroundImage.Size = new Size2(384, 64);
            BackgroundImage.SourceRect = new Rectangle(0, 0, 384, 64);
            BackgroundImage.BorderRect = new Rectangle(14, 8, 360, 35);
            BackgroundImage.Position = position;
            BackgroundImage.MouseUp += BackgroundImage_MouseUp;
            this.Position = position;
        }

        /// <summary>
        /// Destrutor
        /// </summary>
        ~WindowServerRow() {
            Dispose(false);
        }

        public static void Initialize() {
            texture[0] = EngineTexture.TextureFromFile(Common.Configuration.GamePath + @"\Data\Graphics\row1.png", 384, 64);  //350, 35
            texture[1] = EngineTexture.TextureFromFile(Common.Configuration.GamePath + @"\Data\Graphics\row2.png", 384, 64);
        }

        public void BackgroundImage_MouseUp(object sender, EventArgs e) {
            if (EngineMessageBox.Visible) { return; }

            EngineMultimedia.Play(EngineSoundEnum.Click);

            NetworkSocket.Disconnect(NetworkSocketEnum.WorldServer);

            Common.Configuration.IPAddress[(int)NetworkSocketEnum.WorldServer] = new IPAddress(IP, Port);

            LoginServerPacket.ConnectWorldServer(Index);

            EngineMessageBox.Enabled = false;
            EngineMessageBox.Show("Aguardando conexão");
        }

        public void Draw() {
            if (String.IsNullOrEmpty(IP)) { return; }

            if (BackgroundImage.InsideButton()) {
                index = 1;
            }
            else {
                index = 0;
            }

            BackgroundImage.Draw(texture[index]);

            EngineFont.DrawText(null, Name + " " + Region + " " + Status, new Size2(384, 0), new Point(Position.X, Position.Y + 30), color, EngineFontStyle.Regular, FontDrawFlags.Center, false);
        }

        #region "IDisposable"
        bool disposed = false;
        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing) {
            if (!this.disposed) {
                if (disposing) {
                    texture[0].Dispose();
                    texture[1] = null;
                    BackgroundImage = null;
                }

                disposed = true;
            }

        }
        #endregion
    }
}