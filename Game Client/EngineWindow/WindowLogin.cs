using System;
using Elysium_Diamond.DirectX;
using Elysium_Diamond.Network;
using SharpDX;
using SharpDX.Direct3D9;
using Color = SharpDX.Color;

namespace Elysium_Diamond.EngineWindow {
    public static class WindowLogin {
        /// <summary>
        /// Botões de Login e End
        /// </summary>
        private static EngineButton[] Button = new EngineButton[2];

        /// <summary>
        /// Textbox de account e password
        /// </summary>
        public static EngineTextBox[] TextBox = new EngineTextBox[2];

        /// <summary>
        /// Imagem de fundo
        /// </summary>
        private static EngineObject BackgroundImage;

        /// <summary>
        /// Posição da Janela
        /// </summary>
        private static Point Position = new Point(342, 270);

        /// <summary>
        /// Inicia e configura os controles
        /// </summary>
        public static void Initialize() {
            BackgroundImage = new EngineObject();
            BackgroundImage.Position = new Point(Position.X - 140, Position.Y);
            BackgroundImage.Size = new Size2(608, 224);
            BackgroundImage.Texture = EngineTexture.TextureFromFile(Common.Configuration.GamePath + @"\Data\Graphics\window_login.png");
            BackgroundImage.SourceRect = new Rectangle(0, 0, 608, 224);
            BackgroundImage.Transparency = 255;

            TextBox[0] = new EngineTextBox("textbox", 256, 32);
            TextBox[0].Size = new Size2(256, 32);
            TextBox[0].SourceRect = new Rectangle(0, 0, 256, 32);
            TextBox[0].BorderRect = new Rectangle(0, 0, 256, 32);
            TextBox[0].Position = new Point(Position.X + 32, Position.Y + 50);
            TextBox[0].CursorEnabled = true;
            TextBox[0].Transparency = 220;
            TextBox[0].TextTransparency = 255;
            TextBox[0].MouseUp += Textbox_1_MouseUp;
            TextBox[0].TextFormat = FontDrawFlags.Center;

            TextBox[1] = new EngineTextBox("textbox", 256, 32);
            TextBox[1].Size = new Size2(256, 32);
            TextBox[1].SourceRect = new Rectangle(0, 0, 256, 32);
            TextBox[1].BorderRect = new Rectangle(0, 0, 256, 32);
            TextBox[1].Position = new Point(Position.X + 32, Position.Y + 80);
            TextBox[1].Password = true;
            TextBox[1].Transparency = 220;
            TextBox[1].TextTransparency = 255;
            TextBox[1].MouseUp += Textbox_2_MouseUp;
            TextBox[1].TextFormat = FontDrawFlags.Center;

            Button[0] = new EngineButton("login", 128, 32);
            Button[0].Position = new Point(Position.X + 42, Position.Y + 120);
            Button[0].BorderRect = new Rectangle(20, 2, 86, 26);
            Button[0].SourceRect = new Rectangle(0, 0, 128, 32);
            Button[0].Size = new Size2(128, 32);
            Button[0].MouseUp += LoginButton_MouseDown;

            Button[1] = new EngineButton("end", 128, 32);
            Button[1].Position = new Point(Position.X + 152, Position.Y + 120);
            Button[1].BorderRect = new Rectangle(20, 2, 86, 26);
            Button[1].SourceRect = new Rectangle(0, 0, 128, 32);
            Button[1].Size = new Size2(128, 32);
            Button[1].MouseUp += ExitButton_MouseDown;
        }

        /// <summary>
        /// Realiza o desenho da janela
        /// </summary>
        public static void Draw() {
            BackgroundImage.Draw();
            TextBox[0].MouseButtons();
            TextBox[0].Draw();
            TextBox[0].DrawTextMesured();
            TextBox[1].MouseButtons();
            TextBox[1].Draw();
            TextBox[1].DrawTextMesured();

            if (TextBox[0].Text.Length == 0) {
                if (TextBox[0].CursorEnabled == false) {
                    EngineFont.DrawText(null, "username", TextBox[0].Size, new Point(TextBox[0].Position.X, TextBox[0].Position.Y + 4), new Color(255, 255, 255, 120), EngineFontStyle.Regular, FontDrawFlags.Center, false);
                }
            }

            if (TextBox[1].Text.Length == 0) {
                if (TextBox[1].CursorEnabled == false) {
                    EngineFont.DrawText(null, "password", TextBox[1].Size, new Point(TextBox[1].Position.X, TextBox[1].Position.Y + 4), new Color(255, 255, 255, 120), EngineFontStyle.Regular, FontDrawFlags.Center, false);
                }
            }

            Button[0].Draw();
            Button[1].Draw();
        }

        /// <summary>
        /// Executa o login.
        /// </summary>
        public static void Login() {
            if (Common.Configuration.Disconnected) { return; }
            if (EngineMessageBox.Visible) { return; }

            EngineMultimedia.Play(EngineSoundEnum.Click);

            if (NetworkSocket.Connected(NetworkSocketEnum.LoginServer) == false) {
                EngineMessageBox.Enabled = true;
                EngineMessageBox.Show("Sem conexão com o servidor");
                return;
            }

            if (TextBox[0].Text.Length <= 4) {
                EngineMessageBox.Enabled = true;
                EngineMessageBox.Show("O nome não pode ser menor que 5 dígitos");
                return;
            }

            if (TextBox[1].Text.Length <= 4) {
                EngineMessageBox.Enabled = true;
                EngineMessageBox.Show("A senha não pode ser menor que 5 dígitos");
                return;
            }

            LoginServerPacket.Login(TextBox[0].Text.Trim(), TextBox[1].Text.Trim());
        }

        #region Button Event
        public static void LoginButton_MouseDown(object sender, EventArgs e) {
            Login();
        }

        public static void ExitButton_MouseDown(object sender, EventArgs e) {
            if (EngineMessageBox.Visible) { return; }

            EngineMultimedia.Play(EngineSoundEnum.Click);

            EngineCore.Exit();
        }
        #endregion

        #region Textbox Event
        public static void Textbox_1_MouseUp(object sender, EventArgs e) {
            if (EngineMessageBox.Visible) { return; }
            TextBox[0].CursorState = 0;
            TextBox[0].CursorEnabled = true;
            TextBox[1].CursorEnabled = false;
        }

        public static void Textbox_2_MouseUp(object sender, EventArgs e) {
            if (EngineMessageBox.Visible) { return; }
            TextBox[1].CursorState = 0;
            TextBox[0].CursorEnabled = false;
            TextBox[1].CursorEnabled = true;
        }


        #endregion
    }
}
