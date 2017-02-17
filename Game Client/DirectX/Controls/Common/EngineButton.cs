using System;
using SharpDX;
using SharpDX.Direct3D9;
using Color = SharpDX.Color;

namespace Elysium_Diamond.DirectX {
    public class EngineButton : EngineObject, IDisposable {
        const int TOTAL_FILE = 3;   //Quantidade de texturas.

        /// <summary>
        /// Obtem ou altera o estado atual do botão.
        /// </summary>
        public EngineButtonStyle State { get; set; }

        /// <summary>
        /// texturas dos botões
        /// </summary>
        private Texture[] texture = new Texture[TOTAL_FILE];

        /// <summary>
        /// Carrega um novo arquivo com tamanho definido.
        /// </summary>
        /// <param name="lang">Idioma</param>
        /// <param name="file">Arquivo</param>
        /// <param name="name">Nome de Botão</param>
        public EngineButton(string name, int width, int height) : base() {
            Size = new Size2(width, height);

            string language = Enum.GetName(typeof(Language), Common.Configuration.Language);

            texture[(int)EngineButtonStyle.Inactive] = EngineTexture.TextureFromFile($"{Common.Configuration.GamePath}\\Data\\Graphics\\{language}\\{name}_inactive.png", width, height);
            texture[(int)EngineButtonStyle.Hover] = EngineTexture.TextureFromFile($"{Common.Configuration.GamePath}\\Data\\Graphics\\{language}\\{name}_hover.png", width, height);
            texture[(int)EngineButtonStyle.Active] = EngineTexture.TextureFromFile($"{Common.Configuration.GamePath}\\Data\\Graphics\\{language}\\{name}_active.png", width, height);
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
        public override void Draw() {
            if (!Visible) { return; }
            if (!Enabled) { return; }

            State = EngineButtonStyle.Inactive;

            if (Enabled) {
                if (InsideButton()) {
                    if (!move) {
                        move = true;
                        OnMouseMove(EventArgs.Empty);
                    }

                    State = EngineButtonStyle.Hover;

                    if (EngineCore.MouseDown) {
                        State = EngineButtonStyle.Active;

                        if (!click) {
                            OnMouseDown(EventArgs.Empty);
                            click = true;
                        }
                    }
                    else {
                        if (click) {
                            OnMouseUp(EventArgs.Empty);
                        }

                        click = false;
                        State = EngineButtonStyle.Hover;
                    }
                }
                else {
                    if (move) {
                        move = false;
                        OnMouseLeave(EventArgs.Empty);
                    }
                }
            }

            EngineCore.SpriteDevice.Begin(SpriteFlags);
            EngineCore.SpriteDevice.Draw(texture[(int)State], new Color(Color.R, Color.G, Color.B, Transparency), SourceRect, new Vector3(0, 0, 0), new Vector3(Position.X, Position.Y, 0));
            EngineCore.SpriteDevice.End();
        }
    }
}