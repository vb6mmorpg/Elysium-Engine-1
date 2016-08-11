using System;
using SharpDX;
using SharpDX.Direct3D9;
using Color = SharpDX.Color;
using Elysium_Diamond.Common;

// Refatorado 2015-08-13

namespace Elysium_Diamond.DirectX
{
    public class EngineButton : IDisposable {
        /// <summary>
        /// Obtem ou altera o índice do controle.
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// Obtem ou altera as coordenadas do controle.
        /// </summary>
        public Point Position { get; set; }

        /// <summary>
        /// Obtem ou altera o tamanho do controle.
        /// </summary>
        public Size2 Size { get; set; }

        /// <summary>
        /// Obtem ou altera a area de borda da intersecção com o mouse.
        /// </summary>
        public Rectangle BorderRect { get; set; }

        /// <summary>
        /// Obtem ou altera a area de cópia da textura.
        /// </summary>
        public Rectangle SourceRect { get; set; }

        /// <summary>
        /// Obtem ou altera o valor indicando a resposta de interação.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// Obtem ou altera a visibilidade do controle.
        /// </summary>
        public bool Visible { get; set; }

        /// <summary>
        /// Obtem ou altera o estado atual do botão.
        /// </summary>
        public byte State {get; set;}

        /// <summary>
        /// Obtem ou altera o nome do controle.
        /// </summary>
        public string Name { get; set;}

        /// <summary>
        /// Obtem ou altera a cor.
        /// </summary>
        public Color Color { get; set; }

        /// <summary>
        /// Obtem ou altera o valor de transparencia.
        /// </summary>
        public byte Transparency { get; set; }

        public SpriteFlags SpriteFlags { get; set; }

        public event EventHandler MouseUp, MouseDown, MouseMove, MouseLeave;

        public Texture[] Texture = new Texture[3];

        #region MouseButtons
        private bool move, click;
        #endregion

        /// <summary>
        /// Carrega um novo arquivo e obtém automaticamente o tamanho.
        /// </summary>
        /// <param name="lang">Idioma</param>
        /// <param name="file">Arquivo</param>
        /// <param name="name">Nome de Botão</param>
        public EngineButton(Language lang, string file, string name) {
            BorderRect = new Rectangle();
            Position = new Point();
            Enabled = true;
            Visible = true;
            Name = string.Empty;
            Color = Color.White;
            SpriteFlags = SpriteFlags.AlphaBlend;
            Transparency = 255;
            Size2 size;

            string lang_path = "English";
            switch(lang) {
                case Language.Japanese:
                    lang_path = "Japanese";
                    break;
                case Language.English:
                    lang_path = "English";
                    break;
                case Language.Portuguese:
                    lang_path = "Portuguese";
                    break;
                case Language.Spanish:
                    lang_path = "Spanish";
                    break;
                case Language.Korean:
                    lang_path = "Korean";
                    break;
            }

            Texture[0] = EngineTexture.TextureFromFile(file + @"\Data\Graphics\" + lang_path + @"\" + name + "_Inactive.png", out size); 
            Texture[1] = EngineTexture.TextureFromFile(file + @"\Data\Graphics\" + lang_path + @"\" + name + "_Hover.png", out size); 
            Texture[2] = EngineTexture.TextureFromFile(file + @"\Data\Graphics\" + lang_path + @"\" + name + "_Active.png", out size);

            Size = size;
            SourceRect = new Rectangle(0, 0, Size.Width, Size.Height);
        }

        /// <summary>
        /// Carrega um novo arquivo com tamanho definido.
        /// </summary>
        /// <param name="lang">Idioma</param>
        /// <param name="file">Arquivo</param>
        /// <param name="name">Nome de Botão</param>
        public EngineButton(Language lang, string file, string name, int width, int height) {
            BorderRect = new Rectangle();
            Position = new Point();
            SourceRect = new Rectangle(0, 0, width, height);
            Enabled = true;
            Visible = true;
            Name = string.Empty;
            Color = Color.White;
            SpriteFlags = SpriteFlags.AlphaBlend;
            Transparency = 255;
            Size = new Size2(width, height);

            string lang_path = "English";
            switch (lang)
            {
                case Language.Japanese:
                    lang_path = "Japanese";
                    break;
                case Language.English:
                    lang_path = "English";
                    break;
                case Language.Portuguese:
                    lang_path = "Portuguese";
                    break;
                case Language.Spanish:
                    lang_path = "Spanish";
                    break;
                case Language.Korean:
                    lang_path = "Korean";
                    break;
            }

            Texture[0] = EngineTexture.TextureFromFile(file + @"\Data\Graphics\" + lang_path + @"\" + name + "_Inactive.png", width, height);
            Texture[1] = EngineTexture.TextureFromFile(file + @"\Data\Graphics\" + lang_path + @"\" + name + "_Hover.png", width, height);
            Texture[2] = EngineTexture.TextureFromFile(file + @"\Data\Graphics\" + lang_path + @"\" + name + "_Active.png", width, height);
        }

        /// <summary>
        /// Destrutor.
        /// </summary>
        ~EngineButton() {
            Dispose(false);
        }

        /// <summary>
        /// Desenha o controle de acordo com as coordenadas.
        /// </summary>
        public void Draw() {
            if (!Visible) { return; }

            State = 0;

            if (Enabled) {
                if (InsideButton()) {
                    if (!move) { 
                        move = true;
                        MouseMove?.Invoke(this, EventArgs.Empty);
                    }

                    State = 1;

                    if (EngineCore.MouseDown) {
                        State = 2;

                        if (!click) {
                            MouseDown?.Invoke(this, EventArgs.Empty); click = true;
                        }
                    }
                    else {
                        if (click) {
                            MouseUp?.Invoke(this, EventArgs.Empty);
                        }
                        click = false;   
                        State = 1;
                    }
                }
                else {
                    if (move) {
                        move = false;
                        MouseLeave?.Invoke(this, EventArgs.Empty);
                    }
                }
            }

            EngineCore.SpriteDevice.Begin(SpriteFlags);
            EngineCore.SpriteDevice.Draw(Texture[State], new Color(Color.R, Color.G, Color.B, Transparency), SourceRect, new Vector3(0, 0, 0), new Vector3(Position.X, Position.Y, 0));
            EngineCore.SpriteDevice.End();
        }

        /// <summary>
        /// Verifica se o mouse faz uma intersecção com o controle.
        /// </summary>
        private bool InsideButton() {
            if (!Enabled) { return false; }
            if (!Visible) { return false; }
            if (!Program.graphicsDisplay.Focused) { return false; }
            if (Program.graphicsDisplay.WindowState == System.Windows.Forms.FormWindowState.Minimized) { return false; }

            if ((EngineCore.MousePosition.X >= (Position.X + BorderRect.X) && (EngineCore.MousePosition.X <= ((Position.X + BorderRect.X) + BorderRect.Width)))) {         
                if ((EngineCore.MousePosition.Y >= (Position.Y + BorderRect.Y) && (EngineCore.MousePosition.Y <= ((Position.Y + BorderRect.Y) + BorderRect.Height)))) { return true; }
            }

            return false;
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
                    Texture = null;
                }

                disposed = true;
            }

        }
        #endregion
    }
}
