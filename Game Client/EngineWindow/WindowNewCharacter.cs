using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Elysium_Diamond.Common;
using Elysium_Diamond.DirectX;
using Elysium_Diamond.Network;
using Elysium_Diamond.Resource;
using SharpDX;
using SharpDX.Direct3D9;
using Color = SharpDX.Color;

namespace Elysium_Diamond.GameWindow
{
    public class WindowNewCharacter
    {
        /// <summary>
        /// Imagem de fundo 
        /// </summary>
        private static EngineObject backgroundImage;

        /// <summary>
        /// Botoões
        /// </summary>
        private static EngineButton[] button = new EngineButton[4];

        /// <summary>
        /// Nome de cada classe
        /// </summary>
        private static string[] Classe = new string[2];
        private static string[] Texto = new string[2];

        /// <summary>
        /// Descrição de cada classe
        /// </summary>
        private static StringBuilder[] description = new StringBuilder[10];

        /// <summary>
        /// Classe Selecionada
        /// </summary>
        private static int SelectedClasse = 0;
        private static int SelectedSprite = 15;

        private static EngineObject[] person = new EngineObject[7];

        public static EngineTextBox textbox;

        private static Point Position { get; set; }
        public static void Initialize()
        {
            Position = new Point(270, 150);

            // Configuração imagem de fundo
            backgroundImage = new EngineObject(Settings.GamePath + @"\Data\Graphics\Window_5.png", 450, 340);
            backgroundImage.Position = Position;
            backgroundImage.Size = new Size2(450, 340);
            backgroundImage.SourceRect = new Rectangle(0, 0, 450, 340);

            button[0] = new EngineButton(Settings.lang, Settings.GamePath, "Previous", 128, 32);
            button[0].Position = new Point(Position.X + 60, Position.Y + 40);
            button[0].BorderRect = new Rectangle(20, 2, 86, 26);
            button[0].Size = new Size2(128, 32);
            button[0].SourceRect = new Rectangle(0, 0, 128, 32);
            button[0].Index = 0;
            button[0].MouseUp += PreviousClass_Click;

            button[1] = new EngineButton(Settings.lang, Settings.GamePath, "next", 128, 32);
            button[1].Position = new Point(Position.X + 290, Position.Y + 40);
            button[1].BorderRect = new Rectangle(20, 2, 86, 26);
            button[1].Size = new Size2(128, 32);
            button[1].SourceRect = new Rectangle(0, 0, 128, 32);
            button[1].Index = 1;
            button[1].MouseUp += NextClass_Click;

            button[2] = new EngineButton(Settings.lang, Settings.GamePath, "ok", 128, 32);
            button[2].Position = new Point(Position.X + 110, Position.Y + 280);
            button[2].BorderRect = new Rectangle(20, 2, 86, 26);
            button[2].SourceRect = new Rectangle(0, 0, 128, 32);
            button[2].Size = new Size2(128, 32);
            button[2].Index = 2;
            button[2].MouseUp += OK_Click;

            button[3] = new EngineButton(Settings.lang, Settings.GamePath, "back", 128, 32);
            button[3].Position = new Point(Position.X + 235, Position.Y + 280);
            button[3].BorderRect = new Rectangle(20, 2, 86, 26);
            button[3].SourceRect = new Rectangle(0, 0, 128, 32);
            button[3].Size = new Size2(128, 32);
            button[3].Index = 3;
            button[3].MouseUp += Back_Click;

            textbox = new EngineTextBox(Settings.GamePath + @"\Data\Graphics\textbox.png", 190, 25);
            textbox.Size = new Size2(190, 25);
            textbox.SourceRect = new Rectangle(0, 0, 190, 25);
            textbox.Position = new Point(Position.X + 130, Position.Y + 245);
            textbox.CursorEnabled = true;
            textbox.Enabled = true;
            textbox.Transparency = 200;
            textbox.Text = "";
            //textbox.MouseUp += Textbox_1_MouseUp;
            textbox.TextFormat = FontDrawFlags.Center;

            for (int n = 0; n < 7; n++)
            {
                person[n] = new EngineObject();
                person[n].Enabled = true;
                person[n].Size = new Size2(32, 32);
                person[n].Transparency = 150;
                person[n].SourceRect = new Rectangle(128, 0, 32, 32);
                person[n].MouseUp += Person_Click;
            }

            person[3].Transparency = 255;

            person[0].Position = new Point(Position.X + 70, Position.Y + 190);
            person[0].Index = 6;

            person[1].Position = new Point(Position.X + 110, Position.Y + 190);
            person[1].Index = 7;

            person[2].Position = new Point(Position.X + 150, Position.Y + 190);
            person[2].Index = 9;

            person[3].Position = new Point(Position.X + 210, Position.Y + 190);
            person[3].Index = 15;

            person[4].Position = new Point(Position.X + 270, Position.Y + 190);
            person[4].Index = 10;

            person[5].Position = new Point(Position.X + 310, Position.Y + 190);
            person[5].Index = 11;

            person[6].Position = new Point(Position.X + 350, Position.Y + 190);
            person[6].Index = 12;

            Classe[0] = "Guerreiro";
            Classe[1] = "Mago";
            Texto[0] = "Guerreiros, uma classe bastante clássica portando sua espada escudo montado em um belíssimo corcel branco em busca de uma fera ou de uma donzela em perigo.";
            Texto[1] = "Os Magos têm o poder de utilizar os poderes naturais e elementais como terra, fogo, aguá, ar e os poderes da natureza. Além de poderem causar pequenas Ilusões em seus adversários de menor level.";
        }

        public static void Draw()
        {
            backgroundImage.Draw();

            EngineFont.DrawText(null, Classe[SelectedClasse], new Size2(450, 0), new Point(Position.X, Position.Y + 80), Color.DarkViolet, EngineFontStyle.Regular, FontDrawFlags.Center, false);

            EngineFont.DrawText(null, Texto[SelectedClasse], new Rectangle(Position.X + 30, Position.Y + 90, 390, 250), Color.White, EngineFontStyle.Regular, FontDrawFlags.WordBreak);

            // Desenha os botões
            for (int n = 0; n < button.Length; n++)
            {
                button[n].Draw();
            }

            textbox.Draw();
            textbox.DrawTextMesured();

            person[0].Draw(ResourceSprite.FindByID(6));
            person[1].Draw(ResourceSprite.FindByID(7));
            person[2].Draw(ResourceSprite.FindByID(9));

            person[3].Draw(ResourceSprite.FindByID(15));

            person[4].Draw(ResourceSprite.FindByID(10));
            person[5].Draw(ResourceSprite.FindByID(11));
            person[6].Draw(ResourceSprite.FindByID(12));
        }

        public static void Person_Click(object sender, EventArgs e)
        {
            if (Settings.Disconnected) { return; }
            if (EngineMessageBox.Visible) { return; }

            EngineMultimedia.Play(EngineSoundEnum.Click);

            EngineObject temp = (EngineObject)sender;

            temp.Transparency = 255;
            SelectedSprite = temp.Index;

            for (int n = 0; n < 7; n++)
            {
                if (person[n].Index != temp.Index) { person[n].Transparency = 150; }
            }
        }

        public static void NextClass_Click(object sender, EventArgs e)
        {
            if (Settings.Disconnected) { return; }
            if (EngineMessageBox.Visible) { return; }

            EngineMultimedia.Play(EngineSoundEnum.Click);

            SelectedClasse = 1;
        }

        public static void PreviousClass_Click(object sender, EventArgs e)
        {
            if (Settings.Disconnected) { return; }
            if (EngineMessageBox.Visible) { return; }

            EngineMultimedia.Play(EngineSoundEnum.Click);

            SelectedClasse = 0;
        }

        public static void OK_Click(object sender, EventArgs e)
        {
            if (Settings.Disconnected) { return; }
            if (EngineMessageBox.Visible) { return; }

            EngineMultimedia.Play(EngineSoundEnum.Click);

            if (textbox.Text.Length <= 1) { return; }

            WorldServerPacket.CreateCharacter(0, (byte)SelectedClasse, (byte)WindowCharacter.SelectedIndex, SelectedSprite, textbox.Text);

            textbox.Clear();
        }

        public static void Back_Click(object sender, EventArgs e)
        {
            if (Settings.Disconnected) { return; }
            if (EngineMessageBox.Visible) { return; }

            EngineMultimedia.Play(EngineSoundEnum.Click);
           
            textbox.Clear();
            EngineCore.GameState = 3;
        }
    }
}
