using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Elysium_Diamond.Resource;
using Elysium_Diamond.Common;
using Elysium_Diamond.Network;
using Elysium_Diamond.DirectX;
using SharpDX;
using SharpDX.Direct3D9;
using Color = SharpDX.Color;

namespace Elysium_Diamond.GameWindow
{
    public class WindowCharacter
    {
        /// <summary>
        /// Personagens
        /// </summary>
        public struct Player
        {
            public string Name { get; set; }
            public string Class { get; set; }
            public int Sprite { get; set; }
            public int Level { get; set; }
            public byte Transparency { get; set; }
        }

        /// <summary>
        /// Imagem de (janela) fundo
        /// </summary>
        private static EngineObject backgroundImage;

        /// <summary>
        /// Imagem de fundo de personagem
        /// </summary>
        public static EngineObject[] charBackgroundImage = new EngineObject[4];

        /// <summary>
        /// Botões Usar, Novo, Deletar, Selecionar Servidor e Sair
        /// </summary>
        private static EngineButton[] button = new EngineButton[4];

        /// <summary>
        /// Personagens
        /// </summary>
        public static Player[] PlayerData = new Player[4];

        /// <summary>
        /// Fundo selecionavel
        /// </summary>
        private static EngineObject[] selectedBackground = new EngineObject[4];

        /// <summary>
        /// Posição de todos os elementos
        /// </summary>
        private static Point position;

        /// <summary>
        /// Indice da janela selecionada
        /// </summary>
        public static int SelectedIndex { get; set; }

        //Wind Anim
        private static Texture[] wind = new Texture[23];
        private static int windTick, windFrameIndex;
        private static bool windEnabled;

        //Cast Anim
        private static Texture[] cast = new Texture[20];
        private static int casTick, castFrameIndex;
        private static bool castEnabled = true;
        private static bool letContinue = false;
           
        public static void Initialize()
        {
            position = new Point(208, 220);

            // Configuração imagem de fundo
            backgroundImage = new EngineObject();
            backgroundImage.Position = position;
            backgroundImage.Texture = EngineTexture.TextureFromFile(Settings.GamePath + @"\Data\Graphics\win_char.png", 608, 288);
            backgroundImage.Size = new Size2(608, 288);
            backgroundImage.SourceRect = new Rectangle(0, 0, 608, 288);

            // Configuração imagem de fundo personagem
            for (int n = 0; n < charBackgroundImage.Length; n++)
            {
                charBackgroundImage[n] = new EngineObject();
                charBackgroundImage[n].Index = n;
                charBackgroundImage[n].Enabled = true;
                charBackgroundImage[n].Texture = EngineTexture.TextureFromFile(Settings.GamePath + @"\Data\Graphics\selectchar_charback.png", 127, 134);
                charBackgroundImage[n].Size = new Size2(127, 134);
                charBackgroundImage[n].SourceRect = new Rectangle(0, 0, 127, 134);
                charBackgroundImage[n].MouseUp += Select_MouseUp;
                charBackgroundImage[n].BorderRect = new Rectangle(0, 0, 127, 134);

                selectedBackground[n] = new EngineObject();
                selectedBackground[n].Texture = EngineTexture.TextureFromFile(Settings.GamePath + @"\Data\Graphics\selectchar_selected.png", 127, 134);
                selectedBackground[n].Size = new Size2(127, 134);
                selectedBackground[n].SourceRect = new Rectangle(0, 0, 127, 134);

                charBackgroundImage[n].Position = new Point((position.X + 49) + (n * 127), position.Y + 70);
                selectedBackground[n].Position = new Point((position.X + 49) + (n * 127), position.Y + 70);
            }

            // Configuração botões
            button[0] = new EngineButton(Settings.lang, Settings.GamePath, "start", 128, 32);
            button[0].Position = new Point(position.X + 135, position.Y + 215);
            button[0].BorderRect = new Rectangle(20, 2, 86, 26);
            button[0].Size = new Size2(128, 32);
            button[0].SourceRect = new Rectangle(0, 0, 128, 32);
            button[0].MouseUp += Start_MouseUp;

            button[1] = new EngineButton(Settings.lang, Settings.GamePath, "create", 128, 32);
            button[1].Position = new Point(position.X + 242, position.Y + 215);
            button[1].BorderRect = new Rectangle(20, 2, 86, 26);
            button[1].Size = new Size2(128, 32);
            button[1].SourceRect = new Rectangle(0, 0, 128, 32);
            button[1].MouseUp += Create_MouseUp;

            button[2] = new EngineButton(Settings.lang, Settings.GamePath, "delete", 128, 32);
            button[2].Position = new Point(position.X + 349, position.Y + 215);
            button[2].BorderRect = new Rectangle(20, 2, 86, 26);
            button[2].Size = new Size2(128, 32);
            button[2].SourceRect = new Rectangle(0, 0, 128, 32);
            button[2].MouseUp += Delete_MouseUp;

            button[3] = new EngineButton(Settings.lang, Settings.GamePath, "server", 128, 32);
            button[3].Position = new Point(position.X + 240, position.Y + 30);
            button[3].BorderRect = new Rectangle(20, 2, 86, 26);
            button[3].Size = new Size2(128, 32);
            button[3].SourceRect = new Rectangle(0, 0, 128, 32);
            button[3].MouseUp += Server_MouseUp;
            
            //Configuração personagens
            for (int n = 0; n < 4; n++)
            {
                PlayerData[n] = new Player();
                PlayerData[n].Name = "";
                PlayerData[n].Class = "";
                PlayerData[n].Sprite = 0;
                PlayerData[n].Level = 0;
                PlayerData[n].Transparency = 255;
            }

            // Carrega o Wind
            for (int n = 0; n < 23; n++)
            {
                wind[n] = EngineTexture.TextureFromFile(Settings.GamePath + @"\Data\Wind\" + (n + 1) + ".png", 196, 196);
            }

            // Carrega o Cast
            for (int n = 0; n < 20; n++)
            {
                cast[n] = EngineTexture.TextureFromFile(Settings.GamePath + @"\Data\Cast_2\" + (n + 1) + ".png", 196, 196);
            }
        }
           
        public static void Draw()
        {
            // Imagem de (janela) fundo
            backgroundImage.Draw();

            //  Imagem de (janela) fundo personagem
            for (int n = 0; n < charBackgroundImage.Length; n++)
            {
                //Desenha a janela de fundo do personagem
                charBackgroundImage[n].Draw();
            }

            // Desenha o objeto selecionado
            selectedBackground[SelectedIndex].Draw();

            // Desenha a animação de fundo do personagem
            DrawCastAnim(SelectedIndex * 127);

            // Personagem
            for (int n = 0; n < PlayerData.Length; n++)
            {
                //Desenha a janela de fundo do personagem
                DrawPlayer(n, n * 127);
            }
       
            // Botoões
            for (int n = 0; n < button.Length; n++)
            {
                button[n].Draw();
            }

            // Desenha a animação para entrar no jogo
            DrawWind(SelectedIndex * 125);
        }

        private static void DrawPlayer(int index, int x)
        {  
            if (string.IsNullOrEmpty(PlayerData[index].Name)) { return; }
            if (PlayerData[index].Sprite <= 0) { return; }
             
            EngineCore.SpriteDevice.Begin(SpriteFlags.AlphaBlend);
            EngineCore.SpriteDevice.Draw(ResourceSprite.FindByID(PlayerData[index].Sprite), new ColorBGRA(255, 255, 255, PlayerData[index].Transparency), new Rectangle(128, 0, 32, 32), new Vector3(0, 0, 0), new Vector3(position.X + 94 + x, position.Y + 110, 0));
            EngineCore.SpriteDevice.End();

            EngineFont.DrawText(null, PlayerData[index].Name, new Size2(127, 134), new Point(position.X + 49 + x, position.Y + 30), Color.DarkViolet, EngineFontStyle.Regular, FontDrawFlags.Center);
            EngineFont.DrawText(null, PlayerData[index].Class, new Size2(127, 134), new Point(position.X + 49 + x, position.Y + 100), Color.Coral, EngineFontStyle.Regular, FontDrawFlags.Center);
            EngineFont.DrawText(null, "Lv. " + PlayerData[index].Level, new Size2(127, 134), new Point(position.X + 49 + x, position.Y + 120), Color.RoyalBlue, EngineFontStyle.Regular, FontDrawFlags.Center); 
        }

        private static void DrawWind(int x)
        {
            if (windEnabled == false) { return; }
            if (Environment.TickCount >= windTick + 60)
            {
                windTick = Environment.TickCount;
                windFrameIndex++;

                if (windFrameIndex > 22) { 
                    windFrameIndex = 0;
                    windEnabled = false;
                }
            }

            EngineCore.SpriteDevice.Begin(SpriteFlags.AlphaBlend);
            EngineCore.SpriteDevice.Draw(wind[windFrameIndex], Color.White, new Rectangle(0, 0, 192, 192), new Vector3(0, 0, 0), new Vector3(position.X  + x, position.Y, 0));
            EngineCore.SpriteDevice.End();
        }

        private static void DrawCastAnim(int x)
        {
            if (castEnabled == false) { return; }
            if (Environment.TickCount >= casTick + 50)
            {
                casTick = Environment.TickCount;
                castFrameIndex++;

                if (castFrameIndex > 13)
                {
                    if (letContinue == false) { castFrameIndex = 8; }
                    else
                    {
                        if (castFrameIndex > 19)
                        {
                            castFrameIndex = 0;
                            castEnabled = false;
                        }
                    }
                }
            }

            EngineCore.SpriteDevice.Begin(SpriteFlags.AlphaBlend);
            EngineCore.SpriteDevice.Draw(cast[castFrameIndex], Color.White, new Rectangle(0, 0, 192, 192), new Vector3(0, 0, 0), new Vector3(position.X + 14 + x, position.Y + 30, 0));
            EngineCore.SpriteDevice.End();
        }

        private static void Select_MouseUp(object sender, EventArgs e)
        {
            if (EngineMessageBox.Visible) { return; }
            if (EngineInputBox.Visible) { return; }

            SelectedIndex = ((EngineObject)sender).Index;
            castFrameIndex = 0;
        }

        public static void Start_MouseUp(object sender, EventArgs e)
        {
            if (EngineMessageBox.Visible) { return; }
            if (EngineInputBox.Visible) { return; }

            EngineMultimedia.Play(EngineSoundEnum.Click);

            if (PlayerData[SelectedIndex].Name.Length <= 0) { return; }

            EngineMessageBox.Tick = Environment.TickCount;
            EngineMessageBox.Enabled = false;
            EngineMessageBox.Show("Aguardando conexão");

            WorldServerPacket.StartGame((byte)SelectedIndex);
        }

        public static void Create_MouseUp(object sender, EventArgs e)
        {
            if (EngineMessageBox.Visible) { return; }
            if (EngineInputBox.Visible) { return; }

            if (!string.IsNullOrEmpty(PlayerData[SelectedIndex].Name)) { return; }
            if (PlayerData[SelectedIndex].Sprite > 0) { return; }

            EngineMultimedia.Play(EngineSoundEnum.Click);
            EngineCore.GameState = 4;
        }

        public static void Delete_MouseUp(object sender, EventArgs e)
        {
            if (EngineMessageBox.Visible) { return; }
            if (EngineInputBox.Visible) { return; }

            EngineMultimedia.Play(EngineSoundEnum.Click);

            if (string.IsNullOrEmpty(PlayerData[SelectedIndex].Name)) { return; }

            EngineInputBox.Show("Digite deletar para continuar com a exclusão", EngineInputBox.ActionEnum.Delete);
        }
           
        public static void Server_MouseUp(object sender, EventArgs e)
        {
            if (EngineMessageBox.Visible) { return; }
            if (EngineInputBox.Visible) { return; }

            EngineMultimedia.Play(EngineSoundEnum.Click);

            //Configuração personagens
            for (int n = 0; n < 4; n++)
            {
                PlayerData[n].Name = "";
                PlayerData[n].Class = "";
                PlayerData[n].Sprite = 0;
                PlayerData[n].Level = 0;
                PlayerData[n].Transparency = 255;
            }

      //      WorldServerNetwork.Instance.TCPClient.Disconnect("0");

            EngineCore.GameState = 2;
        }

       

    }
}
