using System;
using SharpDX;
using SharpDX.Direct3D9;
using Color = SharpDX.Color;

// Refatorado 2015-08-13

namespace Elysium_Diamond.DirectX
{
    public class EngineObject : IDisposable {
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
        /// Obtem ou altera a visibilidade da textura.
        /// </summary>
        public bool DrawTexture { get; set; }

        /// <summary>
        /// Obtem ou altera o valor indicando a resposta de interação.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// Obtem ou altera a visibilidade do controle.
        /// </summary>
        public bool Visible { get; set; }

        /// <summary>
        /// Obtem ou altera a area de cópia da textura.
        /// </summary>
        public Rectangle SourceRect { get; set; }

        /// <summary>
        /// Obtem ou altera a area de borda da intersecção com o mouse.
        /// </summary>
        public Rectangle BorderRect { get; set; } = new Rectangle(0, 0, 0, 0);

        /// <summary>
        /// Obtem ou altera o nome do controle.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Obtem ou altera a cor.
        /// </summary>
        public Color Color { get; set; }

        /// <summary>
        /// Obtem ou altera o valor de transparencia.
        /// </summary>
        public byte Transparency { get; set; }

        /// <summary>
        /// Obtem ou altera a textura do controle.
        /// </summary>
        public Texture Texture { get; set; }

        public SpriteFlags SpriteFlags { get; set; }

        public event EventHandler MouseUp, MouseDown, MouseMove, MouseLeave;

        #region MouseButtons
        private bool move, click;
        #endregion

        /// <summary>
        /// Instancia a classe.
        /// </summary>
        public EngineObject() {
            Name = string.Empty;
            Transparency = 255;
            Visible = true;
            Enabled = true;
            DrawTexture = true;
            SourceRect = new Rectangle();
            Position = new Point();
            Color = Color.White;
            SpriteFlags = SpriteFlags.AlphaBlend;
        }

        /// <summary>
        /// Carrega um novo arquivo e obtém automaticamente o tamanho.
        /// </summary>
        /// <param name="file">Arquivo</param>
        public EngineObject(string file) {
            Name = string.Empty;
            Transparency = 255;
            Visible = true;
            Enabled = true;
            DrawTexture = true;
            Position = new Point();
            Color = Color.White;
            SpriteFlags = SpriteFlags.AlphaBlend;

            Size2 size;
            Texture = EngineTexture.TextureFromFile(file, out size);

            Size = size;
            SourceRect = new Rectangle(0, 0, Size.Width, Size.Height);
        }

        /// <summary>
        /// Carrega um novo arquivo com tamanho definido.
        /// </summary>
        /// <param name="file">Arquivo</param>
        public EngineObject(string file, int width, int height) {
            Name = string.Empty;
            Transparency = 255;
            Visible = true;
            Enabled = true;
            DrawTexture = true;
            Position = new Point();
            Color = Color.White;
            SpriteFlags = SpriteFlags.AlphaBlend;
            Size = new Size2(width, height);
            SourceRect = new Rectangle(0, 0, width, height);

            Texture = EngineTexture.TextureFromFile(file, width, height);
        }

        /// <summary>
        /// Destrutor.
        /// </summary>
        ~EngineObject() {
            Dispose(false);
        }

        /// <summary>
        /// Desenha o controle de acordo com as coordenadas.
        /// </summary>
        public virtual void Draw() {
            if (!Visible) { return; }
            if (Transparency == 0) { return; }

            MouseButtons();

            if (DrawTexture == false) { return; }

            EngineCore.SpriteDevice.Begin(SpriteFlags);
            EngineCore.SpriteDevice.Draw(Texture, new Color(Color.R, Color.G, Color.B, Transparency), SourceRect, new Vector3(0, 0, 0), new Vector3(Position.X, Position.Y, 0));
           // EngineCore.SpriteDevice.Draw(Texture, Color.White, null, null, new Vector3(Position.X, Position.Y, 0));
            EngineCore.SpriteDevice.End();
        }

        /// <summary>
        /// Desenha o controle de acordo com as coordenadas usando outra textura.
        /// </summary>
        /// <param name="texture">Textura</param>
        public virtual void Draw(Texture texture) {
            if (!Visible) {
                return;
            }

            if (Transparency == 0) {
                return;
            }

            MouseButtons();

            if (DrawTexture == false) {
                return;
            }

            EngineCore.SpriteDevice.Begin(SpriteFlags);
            EngineCore.SpriteDevice.Draw(texture, new Color(Color.R, Color.G, Color.B, Transparency), SourceRect, new Vector3(0, 0, 0), new Vector3(Position.X, Position.Y, 0));
            EngineCore.SpriteDevice.End();
        }

        /// <summary>
        /// Executa os eventos do mouse.
        /// </summary>
        public virtual void MouseButtons() {    
            if (Enabled) { 
                if (InsideButton()) {
                    if (!move) { 
                        move = true;
                        if (MouseMove != null) { MouseMove(this, EventArgs.Empty); }
                    }

                    if (EngineCore.MouseDown) {
                        if (!click) { 
                            if (MouseDown != null) { MouseDown(this, EventArgs.Empty); }
                            click = true;
                        }
                    }
                    else {       
                        if (click) {                      
                            if (MouseUp != null) { MouseUp(this, EventArgs.Empty); }
                        }

                        click = false;   
                    }
                }
                else {
                    if (move) {    
                        move = false;
                        if (MouseLeave != null) { MouseLeave(this, EventArgs.Empty); }
                    }
                }
            }
        }

        /// <summary>
        /// Verifica se o mouse faz uma intersecção com o controle.
        /// </summary>
        public bool InsideButton() {
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

        public void Dispose(bool disposing)
        {
            if (!this.disposed) { 
                if (disposing) { 
                    Texture = null;
                    Name = null;
                }

                disposed = true;
            }

        }
        #endregion

    }
}


