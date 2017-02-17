using SharpDX;
using SharpDX.Direct3D9;
using Color = SharpDX.Color;

namespace Elysium_Diamond.DirectX {
    public class EngineExperienceBar : EngineObject {

        /// <summary>
        /// Texturas de fundo e progressão da barra.
        /// </summary>
        private Texture textureColor,textureBack;

        /// <summary>
        /// Porcentagem da barra.
        /// </summary>
        public int Percentage { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool DrawText { get; set; }

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public EngineExperienceBar(int width, int height) {
            Name = string.Empty;
            Size = new Size2(width, height);
            SourceRect = new Rectangle(0, 0, width, height);
            Transparency = 255;
            Position = new Point(0, 0);
            Color = Color.White;
            Visible = true;
            Enabled = true;
            DrawTexture = true;

            DrawText = true;
            SpriteFlags = SpriteFlags.AlphaBlend;

            textureBack = EngineTexture.TextureFromFile(Common.Configuration.GamePath + @"\Data\Graphics\bar_back.png", width, height);
            textureColor = EngineTexture.TextureFromFile(Common.Configuration.GamePath + @"\Data\Graphics\bar_color.png", width, height);
            Texture = EngineTexture.TextureFromFile(Common.Configuration.GamePath + @"\Data\Graphics\bar_border.png", width, height);                
        }

        /// <summary>
        /// Desenha o controle na tela.
        /// </summary>
        /// <param name="text"></param>
        public void Draw(string text) {
            if (!Visible) { return; }
            if (Transparency == 0) { return; }

            MouseButtons();

            if (DrawTexture == false) { return; }
       
            EngineCore.SpriteDevice.Begin(SpriteFlags);
            //Desenha o fundo
            EngineCore.SpriteDevice.Draw(textureBack, new Color(Color.R, Color.G, Color.B, Transparency), SourceRect, new Vector3(0, 0, 0), new Vector3(Position.X, Position.Y, 0));
            //Desenha o progresso
            EngineCore.SpriteDevice.Draw(textureColor, new Color(Color.R, Color.G, Color.B, Transparency), new Rectangle(0, 0, Size.Width * Percentage / 100, Size.Height), new Vector3(0, 0, 0), new Vector3(Position.X, Position.Y, 0));
            //Desenha o restante
            EngineCore.SpriteDevice.Draw(Texture, new Color(Color.R, Color.G, Color.B, Transparency), SourceRect, new Vector3(0, 0, 0), new Vector3(Position.X, Position.Y, 0));
            EngineCore.SpriteDevice.End();

            if (DrawText == false) { return; }

            EngineFont.DrawText(null, text, new Size2(519, 0), new Point(Position.X, Position.Y + 21), Color.White, EngineFontStyle.Regular, FontDrawFlags.Center);
        }
    }
}
