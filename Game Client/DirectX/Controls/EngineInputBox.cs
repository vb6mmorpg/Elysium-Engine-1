using System;
using Elysium_Diamond.Network;
using Elysium_Diamond.Common;
using Elysium_Diamond.GameWindow;
using SharpDX;
using SharpDX.Direct3D9;
using Color = SharpDX.Color;

namespace Elysium_Diamond.DirectX
{
    public class EngineInputBox {
        public enum ActionEnum { Delete };
        private static EngineObject MessageImage { get; set; }
        public static EngineTextBox TextBox { get; set; }
        public static Point Position { get; set; }
        public static bool Visible { get; set; }
        public static byte TextTransparency { get; set; }
        public static string Text { get; set; }
        public static ActionEnum Action { get; set; }
        public static bool ButtonEnabled { get; set; }
        public static bool ChangeServer { get; set; }
        public static int Tick { get; set; }

        private static EngineButton[] Button = new EngineButton[2];

        public static void Initialize() {
            Position = new Point(312, 15);
            Visible = false;
            TextTransparency = 255;
            ButtonEnabled = true;
            ChangeServer = false;

            MessageImage = new EngineObject();
            MessageImage.Texture = EngineTexture.TextureFromFile(Settings.GamePath + @"\Data\Graphics\Window_Server_2.png", 400, 140);
            MessageImage.Size = new Size2(400, 140);
            MessageImage.Position = Position;
            MessageImage.SourceRect = new Rectangle(0, 0, 400, 140);
            MessageImage.Visible = true;

            TextBox = new EngineTextBox(Settings.GamePath + @"\Data\Graphics\textbox.png", 256, 32);
            TextBox.Size = new Size2(256, 32);
            TextBox.Position = new Point(Position.X + 90, Position.Y + 50);
            TextBox.SourceRect = new Rectangle(0, 0, 256, 32);
            TextBox.CursorEnabled = true;
            TextBox.TextTransparency = 255;
            TextBox.Enabled = true;
            TextBox.MouseUp += Textbox_MouseUp;
            TextBox.TextFormat = FontDrawFlags.Center;

            Button[0] = new EngineButton(Language.Portuguese, Settings.GamePath, "ok", 128, 32);
            Button[0].Position = new Point(Position.X + 90, Position.Y + 85);
            Button[0].Size = new Size2(128, 32);
            Button[0].SourceRect = new Rectangle(0, 0, 128, 32);
            Button[0].BorderRect = new Rectangle(20, 2, 86, 26);
            Button[0].MouseUp += OK_MouseUp;

            Button[1] = new EngineButton(Language.Portuguese, Settings.GamePath, "Cancel", 128, 32);
            Button[1].Position = new Point(Position.X + 205, Position.Y + 85);
            Button[1].Size = new Size2(128, 32);
            Button[1].SourceRect = new Rectangle(0, 0, 128, 32);
            Button[1].BorderRect = new Rectangle(20, 2, 86, 26);
            Button[1].MouseUp += Cancel_MouseUp;
        }

        public static void Show(string text, ActionEnum action) {
            Text = text;
            Visible = true;
            Action = action;
        }

        public static void Hide() {
            Visible = false;
            Text = string.Empty;
            TextBox.Text = string.Empty;
            TextBox.CursorEnabled = false;
        }


        public static void Draw() {
            if (!Visible) { return; }
            MessageImage.Draw();

            Button[0].Draw();
            Button[1].Draw();

            TextBox.Draw();
            TextBox.DrawTextMesured();

            EngineFont.DrawText(null, Text, new Size2(400, 100), new Point(Position.X, Position.Y - 15), new Color(Color.White.R, Color.White.G, Color.White.B, TextTransparency), EngineFontStyle.Regular, FontDrawFlags.Center, false);
        }

        #region Button
        private static void OK_MouseUp(object sender, EventArgs e) {
            EngineMultimedia.Play(EngineSoundEnum.Click);

            //delete
            if (Action == ActionEnum.Delete) {
                if (TextBox.Text.CompareTo("deletar") == 0) {
                    WorldServerPacket.DeleteCharacter((byte)WindowCharacter.SelectedIndex);
                    Hide();
                }
                else {
                    TextBox.Text = string.Empty;
                }
            }

        }

        private static void Cancel_MouseUp(object sender, EventArgs e) {
            EngineMultimedia.Play(EngineSoundEnum.Click);

            TextBox.CursorEnabled = false;
            Visible = false;
        }

        private static void Textbox_MouseUp(object sender, EventArgs e) {
            TextBox.CursorEnabled = true;
        }
        #endregion

    }
}