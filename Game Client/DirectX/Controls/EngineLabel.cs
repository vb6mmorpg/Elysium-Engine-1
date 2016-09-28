using SharpDX;
using SharpDX.Direct3D9;
using Color = SharpDX.Color;

// Refatorado 2015-08-13

namespace Elysium_Diamond.DirectX
{
    public class EngineLabel : EngineObject { 
        /// <summary>
        /// Obtem ou altera o texto.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Obtem ou altera a cor.
        /// </summary>
        public Color TextColor { get; set; }

        /// <summary>
        /// Obtem ou altera a visibilidade do texto.
        /// </summary>
        public bool TextVisible { get; set; }

        /// <summary>
        /// Obtem ou altera a transparência da cor de texto.
        /// </summary>
        public byte TextTransparency { get; set; }

        /// <summary>
        /// Obtem ou altera o estilo de fonte.
        /// </summary>
        public EngineFontStyle TextFontStyle { get; set; }

        /// <summary>
        /// Instancia a classe.
        /// </summary>
        public EngineLabel() {
            Text = string.Empty;
            TextColor = Color.White;
            TextVisible = true;
            TextTransparency = 255;
            TextFontStyle = EngineFontStyle.Regular;
        }

        /// <summary>
        /// Carrega um novo arquivo com tamanho definido.
        /// </summary>
        /// <param name="file">Arquivo</param>
        /// <param name="width">Comprimento</param>
        /// <param name="height">Altura</param>
        public EngineLabel(string file, int width, int height)
        {
            Text = string.Empty;
            TextColor = Color.White;
            TextVisible = true;
            TextTransparency = 255;
            TextFontStyle = EngineFontStyle.Regular;
            Texture = EngineTexture.TextureFromFile(file, width, height);
            Size = new Size2(width, height);
            SourceRect = new Rectangle(0, 0, width, height);
        }

        /// <summary>
        /// Destrutor
        /// </summary>
        ~EngineLabel() {
            Dispose(false);
        }

        /// <summary>
        /// Desenha o texto no centro do controle.
        /// </summary>
        public void DrawTextCenter() {
            if (!TextVisible) { return; }
            EngineFont.DrawText(null, Text, Size, new Point(Position.X, Position.Y + 4), new Color(TextColor.R, TextColor.R, TextColor.B, TextTransparency), TextFontStyle, FontDrawFlags.Left, false);
        }

        /// <summary>
        /// Desenha o texto.
        /// </summary>
        public void DrawText() {
            if (!TextVisible) { return; }
            EngineFont.DrawText(null, Text, Position.X, Position.Y, new Color(TextColor.R, TextColor.R, TextColor.B, TextTransparency), TextFontStyle);
        }
     }
}
