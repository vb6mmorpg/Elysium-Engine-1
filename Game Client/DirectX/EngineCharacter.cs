using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using Elysium_Diamond.GameClient;
using Elysium_Diamond.Resource;
using Elysium_Diamond.Network;
using SharpDX;
using SharpDX.Direct3D9;

namespace Elysium_Diamond.DirectX {
    public class EngineCharacter {
        [DllImport("user32")]
        private static extern Int16 GetAsyncKeyState(Int16 vKey);

        public enum Direction : byte {
            Up = 1,
            Down = 4,
            Left = 7,
            Right = 10
        }

        public EventHandler MouseUp { get; set; }
        public EventHandler MouseDown { get; set; }
        public EventHandler MouseMove { get; set; }
        public EventHandler MouseLeave { get; set; }

        public int ID { get; set; }
        public Queue<byte> DirectionQueue { get; set; } = new Queue<byte>();
        public short Sprite { get; set; }
        public string Name { get; set; }
        public string Guild { get; set; }


        /// <summary>
        /// Ativa ou desativa o controle do jogador.
        /// </summary>
        public bool CanPlayerControl { get; set; }

        /// <summary>
        /// Direção da sprite.
        /// </summary>
        public Direction Dir { get; set; }

        /// <summary>
        /// Cor da sprite.
        /// </summary>
        public Color Color { get; set; }

        /// <summary>
        /// Transparencia do controle.
        /// </summary>
        public byte Transparency { get; set; }

        /// <summary>
        /// Ativa ou desativa o controle.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// Altera ou obtem a visibilidade.
        /// </summary>
        public bool Visible { get; set; }

        /// <summary>
        /// Coordenadas do jogador.
        /// </summary>
        public Point Coordinate { get; set; }

        /// <summary>
        /// Area de recorte da sprite.
        /// </summary>
        private Rectangle source_rect;

        /// <summary>
        /// posição x.
        /// </summary>
        public int X { get; set; }
        
        /// <summary>
        /// posição y.
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// comprimento sprite.
        /// </summary>
        private int Width { get; set; }

        /// <summary>
        /// altura sprite.
        /// </summary>
        private int Height { get; set; } 

        private int OffSetY { get; set; }
        private int OffSetX { get; set; }

        /// <summary>
        /// Define se o jogador pode mover-se ou não.
        /// </summary>
        private bool Move { get; set; }

        /// <summary>
        /// Tempo de cada passo do personagem.
        /// </summary>
        private int moveTime;

        /// <summary>
        /// Número da animação.
        /// </summary>
        private int anim;

        /// <summary>
        /// Tick de animação.
        /// </summary>
        private int animTime;

        /// <summary>
        /// Etapa da animação.
        /// </summary>
        private int step;

        /// <summary>
        /// Controle dos botões que permite apenas uma ação.
        /// </summary>
        private bool moveButton, click;
        
        /// <summary>
        /// Construtor.
        /// </summary>
        public EngineCharacter() {
            CanPlayerControl = true;
            Visible = true;
            Enabled = true;
            Width = 32;
            Height = 32;
            Transparency = 255;
            Name = string.Empty;
            Guild = string.Empty;
            Color = Color.White;
            source_rect = new Rectangle(0, 0, 32, 32);
        }

        /// <summary>
        /// Desenha os controles.
        /// </summary>
        public void Draw() {
            if (!Visible) { return; }
            if (Transparency == 0) { return; }

            MouseButtons();

            KeyState();
            ProcessMovement();
            ProcessAnimation();

            EngineCore.SpriteDevice.Begin(SpriteFlags.AlphaBlend);
            EngineCore.SpriteDevice.Draw(SpriteManager.FindByID(Sprite), new Color(Color.R, Color.G, Color.B, Transparency), source_rect, new Vector3(0, 0, 0), new Vector3(X, Y, 0));
            EngineCore.SpriteDevice.End();

            EngineFont.DrawText(null, Name, new Size2(30, 0), new Point(X, Y - 5), Color.White, EngineFontStyle.Regular, FontDrawFlags.Center);
            EngineFont.DrawText(null, Guild, new Size2(30, 0), new Point(X, Y - 20), Color.BlueViolet, EngineFontStyle.Bold, FontDrawFlags.Center);
        }

        /// <summary>
        /// Realiza o processo de animação da sprite.
        /// </summary>
        public void ProcessAnimation() {
            anim = (int)Dir;

            if (Move) {
                if (step == 0) {
                    if (Environment.TickCount >= animTime + 200) {
                        step = 1;
                        animTime = Environment.TickCount;
                    }

                    anim -= 1;
                }
                else {
                    if (Environment.TickCount >= animTime + 200) {
                        step = 0;
                        animTime = Environment.TickCount;
                    }

                    anim += 1;
                }
            }

            source_rect = new Rectangle(anim * 32, 0, Width, Height);
        }

        /// <summary>
        /// Processa o movimento da sprite.
        /// </summary>
        public void ProcessMovement() {
            if (DirectionQueue.Count > 0) {
                if (!Move) {
                    Dir = (Direction)DirectionQueue.Dequeue();

                    if (Dir == Direction.Up) {
                        OffSetY = 16;
                    }

                    if (Dir == Direction.Down) {
                        OffSetY = -16;
                    }

                    if (Dir == Direction.Left) {
                        OffSetX = 16;
                    }

                    if (Dir == Direction.Right) {
                        OffSetX = -16;
                    }

                    Move = true;
                }
            }

            if (!Move) { return; }

            if (Environment.TickCount >= this.moveTime + 35) {
                moveTime = Environment.TickCount;

                switch (Dir) {
                    case Direction.Up:
                    Y -= 4;
                    OffSetY -= 4;
                    if (OffSetY <= 0) {
                        Move = false;
                        Coordinate = new Point(Coordinate.X, Coordinate.Y - 1);
                    }
                    break;

                    case Direction.Down:
                    Y += 4;
                    OffSetY += 4;
                    if (OffSetY >= 0) {
                        Move = false;
                        Coordinate = new Point(Coordinate.X, Coordinate.Y + 1);
                    }
                    break;

                    case Direction.Left:
                    X -= 4;
                    OffSetX -= 4;
                    if (OffSetX <= 0) {
                        Move = false;
                        Coordinate = new Point(Coordinate.X - 1, Coordinate.Y);
                    }
                    break;

                    case Direction.Right:
                    X += 4;
                    OffSetX += 4;
                    if (OffSetX >= 0) {
                        Move = false;
                        Coordinate = new Point(Coordinate.X + 1, Coordinate.Y);
                    }
                    break;
                }
            }
        }

        /// <summary>
        /// Realiza a verificação das teclas de movimento.
        /// </summary>
        public void KeyState() {
            if (!Enabled) { return; }
            if (!Program.GraphicsDisplay.Focused) { return; }

            if (!CanPlayerControl) { return; }

            if (GetAsyncKeyState((short)Keys.W) < 0) {
                if (Move == false) {
                    OffSetY = 16;
                    Dir = Direction.Up;
                    Move = true;
                    GamePacket.PlayerMove(Dir);
                }
            }

            if (GetAsyncKeyState((short)Keys.S) < 0) {
                if (Move == false) {
                    OffSetY = -16;
                    Dir = Direction.Down;
                    Move = true;
                   GamePacket.PlayerMove(Dir);
                }
            }

            if (GetAsyncKeyState((short)Keys.A) < 0) {
                if (Move == false) {
                    OffSetX = 16;
                    Dir = Direction.Left;
                    Move = true;
                    GamePacket.PlayerMove(Dir);
                }
            }

            if (GetAsyncKeyState((short)Keys.D) < 0) {
                if (Move == false) {
                    OffSetX = -16;
                    Dir = Direction.Right;
                    Move = true;
                    GamePacket.PlayerMove(Dir);
                }
            }
        }

        /// <summary>
        /// Executa os eventos de mouse.
        /// </summary>
        public void MouseButtons() {
            if (Enabled) {
                if (InsideButton()) {
                    if (!moveButton) {
                        moveButton = true;
                        MouseMove?.Invoke(this, EventArgs.Empty);
                    }

                    if (EngineCore.MouseDown) {
                        if (!click) {
                            MouseDown?.Invoke(this, EventArgs.Empty); click = true;
                        }
                    }
                    else {
                        if (click) {
                            MouseUp?.Invoke(this, EventArgs.Empty);
                        }

                        click = false;
                    }
                }
                else {
                    if (moveButton) {
                        moveButton = false;
                        MouseLeave?.Invoke(this, EventArgs.Empty);
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
            if (!Program.GraphicsDisplay.Focused) { return false; }
            if (Program.GraphicsDisplay.WindowState == FormWindowState.Minimized) { return false; }

            if ((EngineCore.MousePosition.X >= X) && (EngineCore.MousePosition.X <= (Width + X))) {
                if ((EngineCore.MousePosition.Y >= Y) && (EngineCore.MousePosition.Y <= (Y + Height))) { return true; }
            }

            return false;
        }

        public void Clear() {
            ID = 0;
            DirectionQueue.Clear();
            Sprite = 0;
            Name = string.Empty;
            Guild = string.Empty;
        }
    }
}
