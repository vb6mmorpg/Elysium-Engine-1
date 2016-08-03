using System;
using Elysium_Diamond.Network;
using Elysium_Diamond.Common;
using SharpDX;
using SharpDX.Direct3D9;
using Color = SharpDX.Color;

// Refatorado 2015-08-13

namespace Elysium_Diamond.DirectX
{
    public static class EngineMessageBox {
        /// <summary>
        /// Imagem de fundo.
        /// </summary>
        private static EngineObject MessageImage { get; set; }

        /// <summary>
        /// Botão de confirmação (OK).
        /// </summary>
        private static EngineButton Button { get; set; }

        /// <summary>
        /// Obtem ou altera o valor de transparência do controle.
        /// </summary>
        public static byte Transparency { get; set; }

        /// <summary>
        /// Otem ou altera a visibilidade do controle.
        /// </summary>
        public static bool Visible { get; set; }

        /// <summary>
        /// Obtem ou altera a cor.
        /// </summary>
        public static Color color { get; set; }

        /// <summary>
        /// Obtem ou altera a mensagem de texto.
        /// </summary>
        public static string Text { get; set; }

        /// <summary>
        /// Obtem ou altera a posição do controle.
        /// </summary>
        public static Point Position { get; set; }

        /// <summary>
        /// Obtem ou altera o valor de interação.
        /// </summary>
        public static bool Enabled { get; set; }

        /// <summary>
        /// Obtem ou altera o 'tick'.
        /// </summary>
        public static int Tick { get; set; }

        /// <summary>
        /// Inicializa a caixa de mensagem carregando as texturas.
        /// </summary>
        public static void Initialize() {
            Visible = false;
            Text = string.Empty;
            Transparency = 255;
            Position = new Point(294, 15);
            Enabled = true;

            MessageImage = new EngineObject();
            MessageImage.Texture = EngineTexture.TextureFromFile(Settings.GamePath + @"\Data\Graphics\Window_Server_2.png", 450, 90);
            MessageImage.Size = new Size2(450, 90);
            MessageImage.SourceRect = new Rectangle(0, 0, 450, 90);
            MessageImage.Position = Position;
            MessageImage.Visible = true;

            Button = new EngineButton(Language.Portuguese, Settings.GamePath, "OK", 103, 30);
            Button.Position = new Point(Position.X + 173, Position.Y + 45);
            Button.Size = new Size2(103, 30);
            Button.BorderRect = new Rectangle(9, 2, 86, 26);
            Button.SourceRect = new Rectangle(0, 0, 103, 30);
            Button.MouseUp += Button_MouseUp;
        }

        /// <summary>
        /// Abre a caixa de mensagem.
        /// </summary>
        /// <param name="text">Texto</param>
        public static void Show(string text) {
            Text = text;
            Visible = true;
        }

        /// <summary>
        /// Desenha a caixa de mensagem.
        /// </summary>
        public static void Draw() {
            if (!Visible) { return; }

            if (Enabled == false)
            {
                if (Environment.TickCount >= Tick + 10000)
                {
                    Text = "Sem conexão";
                    Enabled = true;
                    Settings.HexID = "";
                    Settings.GameServerIP = string.Empty;
                    Settings.GameServerPort = 0;
                }
            }

            MessageImage.Transparency = Transparency;
            Button.Transparency = Transparency;

            MessageImage.Draw();

            EngineFont.DrawText(null, Text, new Size2(450, 80), new Point(Position.X, Position.Y - 10), new SharpDX.Color(Color.White.R, Color.White.G, Color.White.B, Transparency), EngineFontStyle.Regular, FontDrawFlags.Left);
            Button.Draw();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Button_MouseUp(object sender, EventArgs e) {
            if (Enabled == false) { return; }

            EngineMultimedia.Play(EngineSoundEnum.Click);
            Visible = false;

            if (Settings.Disconnected) { Environment.Exit(0); }
        }
    }
}
