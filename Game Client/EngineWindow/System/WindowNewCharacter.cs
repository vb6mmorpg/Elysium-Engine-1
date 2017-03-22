using System;
using Elysium_Diamond.DirectX;
using Elysium_Diamond.Network;
using Elysium_Diamond.Resource;
using Elysium_Diamond.Classes;
using SharpDX;
using SharpDX.Direct3D9;
using Color = SharpDX.Color;

namespace Elysium_Diamond.EngineWindow {
    public class WindowNewCharacter {
        /// <summary>
        /// Quantidade máxima de sprites na tela para escolha.
        /// </summary>
        private const int MAX_SPRITE = 7;

        /// <summary>
        /// Quantidade máxima de botões (Anterior, Próximo, OK e Cancel).
        /// </summary>
        private const int MAX_BUTTON = 4;

        /// <summary>
        /// Imagem de fundo 
        /// </summary>
        private static EngineObject background;

        /// <summary>
        /// Botões
        /// </summary>
        private static EngineButton[] button = new EngineButton[MAX_BUTTON];

        /// <summary>
        /// Classe selecionada.
        /// </summary>
        private static int selectedClasse = 0;

        /// <summary>
        /// Posição dos controles.
        /// </summary>
        private static Point position { get; set; }

        /// <summary>
        /// Objeto para seleção de sprites.
        /// </summary>
        private static EngineObject[] classe = new EngineObject[MAX_SPRITE];

        /// <summary>
        /// Sprite selecionado.
        /// </summary>
        private static int selectedSprite;

        /// <summary>
        /// Textbox para o nome do personagem.
        /// </summary>
        public static EngineTextBox textbox;

        /// <summary>
        /// Inicializa e define a configuração dos controles.
        /// </summary>
        public static void Initialize() {
            position = new Point(272, 150);

            // Configuração imagem de fundo
            background = new EngineObject($"{Common.Configuration.GamePath}\\Data\\Graphics\\window_select.png", 480, 384);
            background.Position = new Point(position.X - 15, position.Y - 15);
            background.Size = new Size2(480, 384);
            background.SourceRect = new Rectangle(0, 0, 480, 384);

            button[0] = new EngineButton("previous", 128, 32);
            button[0].Position = new Point(position.X + 35, position.Y + 40);
            button[0].BorderRect = new Rectangle(20, 2, 86, 26);
            button[0].Size = new Size2(128, 32);
            button[0].SourceRect = new Rectangle(0, 0, 128, 32);
            button[0].Index = 0;
            button[0].MouseUp += PreviousClass_Click;

            button[1] = new EngineButton("next", 128, 32);
            button[1].Position = new Point(position.X + 290, position.Y + 40);
            button[1].BorderRect = new Rectangle(20, 2, 86, 26);
            button[1].Size = new Size2(128, 32);
            button[1].SourceRect = new Rectangle(0, 0, 128, 32);
            button[1].Index = 1;
            button[1].MouseUp += NextClass_Click;

            button[2] = new EngineButton("ok", 128, 32);
            button[2].Position = new Point(position.X + 100, position.Y + 280);
            button[2].BorderRect = new Rectangle(20, 2, 86, 26);
            button[2].SourceRect = new Rectangle(0, 0, 128, 32);
            button[2].Size = new Size2(128, 32);
            button[2].Index = 2;
            button[2].MouseUp += Confirm_Click;

            button[3] = new EngineButton("back", 128, 32);
            button[3].Position = new Point(position.X + 235, position.Y + 280);
            button[3].BorderRect = new Rectangle(20, 2, 86, 26);
            button[3].SourceRect = new Rectangle(0, 0, 128, 32);
            button[3].Size = new Size2(128, 32);
            button[3].Index = 3;
            button[3].MouseUp += Back_Click;

            textbox = new EngineTextBox("textbox", 190, 25);
            textbox.Size = new Size2(190, 25);
            textbox.SourceRect = new Rectangle(0, 0, 190, 25);
            textbox.Position = new Point(position.X + 125, position.Y + 245);
            textbox.CursorEnabled = true;
            textbox.Enabled = true;
            textbox.Transparency = 200;
            textbox.Text = string.Empty;
            textbox.TextFormat = FontDrawFlags.Center;

            for (int n = 0; n < MAX_SPRITE; n++) {
                classe[n] = new EngineObject();
                classe[n].Enabled = true;
                classe[n].Size = new Size2(32, 32);
                classe[n].Transparency = 150;
                classe[n].SourceRect = new Rectangle(128, 0, 32, 32);
                classe[n].MouseUp += Classe_Click;
            }

            classe[0].Position = new Point(position.X + 70, position.Y + 190);
            classe[0].BorderRect = new Rectangle(0, 0, 32, 32);
            classe[0].Index = 0;

            classe[1].Position = new Point(position.X + 110, position.Y + 190);
            classe[1].BorderRect = new Rectangle(0, 0, 32, 32);
            classe[1].Index = 1;

            classe[2].Position = new Point(position.X + 150, position.Y + 190);
            classe[2].BorderRect = new Rectangle(0, 0, 32, 32);
            classe[2].Index = 2;

            classe[3].Position = new Point(position.X + 210, position.Y + 190);
            classe[3].BorderRect = new Rectangle(0, 0, 32, 32);
            classe[3].Transparency = 255;
            classe[3].Index = 3;

            classe[4].Position = new Point(position.X + 270, position.Y + 190);
            classe[4].BorderRect = new Rectangle(0, 0, 32, 32);
            classe[4].Index = 4;

            classe[5].Position = new Point(position.X + 310, position.Y + 190);
            classe[5].BorderRect = new Rectangle(0, 0, 32, 32);
            classe[5].Index = 5;

            classe[6].Position = new Point(position.X + 350, position.Y + 190);
            classe[6].BorderRect = new Rectangle(0, 0, 32, 32);
            classe[6].Index = 6;

            //Define a sprite da classe selecionada.
            selectedSprite = ClasseManager.Classes[selectedClasse].Sprite[3];
        }

        /// <summary>
        /// Desenha os controles.
        /// </summary>
        public static void Draw() {
            background.Draw();

            //Nome da classe
            EngineFont.DrawText(null, ClasseManager.Classes[selectedClasse].Name, new Size2(450, 0), new Point(position.X, position.Y + 80), Color.DarkViolet, EngineFontStyle.Regular, FontDrawFlags.Center, false);
            //Descrição
            EngineFont.DrawText(null, ClasseManager.Classes[selectedClasse].Description, new Rectangle(position.X + 30, position.Y + 90, 390, 250), Color.White, EngineFontStyle.Regular, FontDrawFlags.WordBreak);

            //Desenha os botões
            for (int n = 0; n < button.Length; n++) { button[n].Draw(); }

            textbox.Draw();
            textbox.DrawTextMesured();

            //Desenha as 7 sprites na tela para escolha.
            classe[0].Draw(SpriteManager.FindByID(ClasseManager.Classes[selectedClasse].Sprite[0]));
            classe[1].Draw(SpriteManager.FindByID(ClasseManager.Classes[selectedClasse].Sprite[1]));
            classe[2].Draw(SpriteManager.FindByID(ClasseManager.Classes[selectedClasse].Sprite[2]));
            classe[3].Draw(SpriteManager.FindByID(ClasseManager.Classes[selectedClasse].Sprite[3]));
            classe[4].Draw(SpriteManager.FindByID(ClasseManager.Classes[selectedClasse].Sprite[4]));
            classe[5].Draw(SpriteManager.FindByID(ClasseManager.Classes[selectedClasse].Sprite[5]));
            classe[6].Draw(SpriteManager.FindByID(ClasseManager.Classes[selectedClasse].Sprite[6]));
        }

        /// <summary>
        /// Seleciona o sprite diminuindo a transparencia e aumentando o dos restantes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void Classe_Click(object sender, EventArgs e) {
            if (Common.Configuration.Disconnected) { return; }
            if (EngineMessageBox.Visible) { return; }

            EngineMultimedia.Play(EngineSoundEnum.Click);

            var TButton = (EngineObject)sender;
           
            TButton.Transparency = 255;

            selectedSprite = ClasseManager.Classes[selectedClasse].Sprite[TButton.Index];

            for (int n = 0; n < MAX_SPRITE; n++) {
                if (classe[n].Index != TButton.Index) { classe[n].Transparency = 150; }
            }
        }

        /// <summary>
        /// Avança para a próxima classe.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void NextClass_Click(object sender, EventArgs e) {
            if (Common.Configuration.Disconnected) { return; }
            if (EngineMessageBox.Visible) { return; }

            EngineMultimedia.Play(EngineSoundEnum.Click);

            if (selectedClasse < ClasseManager.Classes.Count - 1) {
                selectedClasse++;
            }     
        }

        /// <summary>
        /// Retorna para a classe anterior.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void PreviousClass_Click(object sender, EventArgs e) {
            if (Common.Configuration.Disconnected) { return; }
            if (EngineMessageBox.Visible) { return; }

            EngineMultimedia.Play(EngineSoundEnum.Click);

            if (selectedClasse >= 1) { selectedClasse--; }

        }

        /// <summary>
        /// Envia a confirmação para o servidor da criação do personagem.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void Confirm_Click(object sender, EventArgs e) {
            if (Common.Configuration.Disconnected) { return; }
            if (EngineMessageBox.Visible) { return; }

            EngineMultimedia.Play(EngineSoundEnum.Click);

            if (textbox.Text.Length <= 1) { return; }

            WorldPacket.CreateCharacter(0, ClasseManager.Classes[selectedClasse].ID, (byte)WindowCharacter.SelectedIndex, selectedSprite, textbox.Text);

            textbox.Clear();
        }

        /// <summary>
        /// Volta para a tela de seleção de personagem.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void Back_Click(object sender, EventArgs e) {
            if (Common.Configuration.Disconnected) { return; }
            if (EngineMessageBox.Visible) { return; }

            EngineMultimedia.Play(EngineSoundEnum.Click);

            textbox.Clear();
            EngineCore.GameState = 3;
        }
    }
}
