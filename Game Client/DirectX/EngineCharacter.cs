using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Elysium_Diamond.Resource;
using Elysium_Diamond.Network;
using SharpDX;
using SharpDX.Direct3D9;
using Color = SharpDX.Color;

namespace Elysium_Diamond.DirectX {
    public class EngineCharacter {
        [DllImport("user32")]
        public static extern Int16 GetAsyncKeyState(Int16 vKey);
        public enum Direction {
            Up = 1,
            Down = 4,
            Left = 7,
            Right = 10
        }

        //temp
        public int ID { get; set; }

        public Direction Dir { get; set; }
        public string Name { get; set; }
        public string GuildName { get; set; }
        public int Sprite { get; set; }
        public Color Color { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public int OffSetY { get; set; }
        public int OffSetX { get; set; }
        public Point Coordinate { get; set; }
        public Size2 Size { get; set; }
        public bool Visible { get; set; }
        public bool Enabled { get; set; }
        public byte Transparency { get; set; }
        public float ShadowAngle { get; set; }
        public Color ShadowColor { get; set; }
        public byte ShadowTransparency { get; set; }
        public SpriteFlags SpriteFlags { get; set; }
        public Rectangle SourceRect { get; set; }

        public bool Move { get; set; }

        public event EventHandler MouseUp, MouseDown, MouseMove, MouseLeave;

        private int anim, animTime, moveTime, step;
        private bool moveButton,  click;

        public EngineCharacter() {
            Visible = true;
            Enabled = true;
            Size = new Size2(32, 32);
            ShadowAngle = 0.7f;
            ShadowTransparency = 120;
            Transparency = 255;
            ShadowColor = Color.Black;
            Name = string.Empty;
            GuildName = string.Empty;
            Color = Color.White;
            SourceRect = new Rectangle(0, 0, Size.Width, Size.Height);
            SpriteFlags = SpriteFlags.AlphaBlend;
        }

        public void Draw() {
            if (!Visible) { return; }
            if (Transparency == 0) { return; }

            MouseButtons();

            KeyState();
            ProcessMovement();
            ProcessAnimation();

            EngineCore.SpriteDevice.Begin(SpriteFlags);
            EngineCore.SpriteDevice.Draw(ResourceSprite.FindByID(Sprite), new Color(Color.R, Color.G, Color.B, Transparency), SourceRect, new Vector3(0, 0, 0), new Vector3(PositionX, PositionY, 0));
            EngineCore.SpriteDevice.End();

            //Shadow
            //EngineCore.SpriteDevice.Begin(SpriteFlags);
            //EngineCore.SpriteDevice.Draw(ResourceSprite.FindByID(Sprite), new Color(ShadowColor.R, ShadowColor.G, ShadowColor.B, ShadowTransparency), SourceRect, new Vector3(-20, 10, 0), new Vector3(PositionX, PositionY, 0));
            //EngineCore.SpriteDevice.End();

            EngineFont.DrawText(null, Name, new Size2(30, 0), new Point(PositionX, PositionY - 5), Color.White, EngineFontStyle.Regular, FontDrawFlags.Center);
            EngineFont.DrawText(null, GuildName, new Size2(30, 0), new Point(PositionX, PositionY - 20), Color.BlueViolet, EngineFontStyle.Bold, FontDrawFlags.Center);
        }

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

            SourceRect = new Rectangle(anim * 32, 0, Size.Width, Size.Height);
        }

        public void ProcessMovement() {
            if (!Move) { return; }

            if (Environment.TickCount >= this.moveTime + 35) {
                moveTime = Environment.TickCount;

                switch (Dir) {
                    case Direction.Up:
                        PositionY -= 4;
                        OffSetY -= 4;
                        if (OffSetY <= 0) {
                           // OffSetY = 0;
                            Move = false;
                            Coordinate = new Point(Coordinate.X, Coordinate.Y - 1);
                        }
                        break;

                    case Direction.Down:
                        PositionY += 4;
                        OffSetY += 4;
                        if (OffSetY >= 0) {
                           // OffSetY = 0;
                            Move = false;
                            Coordinate = new Point(Coordinate.X, Coordinate.Y + 1);
                        }
                        break;

                    case Direction.Left:
                        PositionX -= 4;
                        OffSetX -= 4;
                        if (OffSetX <= 0) {
                           // OffSetX = 0;
                            Move = false;
                            Coordinate = new Point(Coordinate.X - 1, Coordinate.Y);
                        }
                        break;

                    case Direction.Right:
                        PositionX += 4;
                        OffSetX += 4;
                        if (OffSetX >= 0) {
                           // OffSetX = 0;
                            Move = false;
                            Coordinate = new Point(Coordinate.X + 1, Coordinate.Y);
                        }
                        break;
                }
            }
        }

        public void KeyState() {
            if (!Enabled) { return; }
            if (!Program.graphicsDisplay.Focused) { return; }

            if (GetAsyncKeyState((short)Keys.W) < 0) {
                Program.graphicsDisplay.Text = GetAsyncKeyState((int)Keys.W) + "";
                if (Move == false) {
                    OffSetY = 16;
                    Dir = Direction.Up;
                    Move = true;
                    GeneralServerPacket.PlayerMove(Dir);
                }
            }

            if (GetAsyncKeyState((short)Keys.S) < 0) {
                if (Move == false) {
                    OffSetY = -16;
                    Dir = Direction.Down;
                    Move = true;
                    GeneralServerPacket.PlayerMove(Dir);
                }
            }

            if (GetAsyncKeyState((short)Keys.A) < 0) {
                if (Move == false) {
                    OffSetX = 16;
                    Dir = Direction.Left;
                    Move = true;
                    GeneralServerPacket.PlayerMove(Dir);
                }
            }

            if (GetAsyncKeyState((short)Keys.D) < 0) {
                if (Move == false) {
                    OffSetX = -16;
                    Dir = Direction.Right;
                    Move = true;
                    GeneralServerPacket.PlayerMove(Dir);
                }
            }
        }

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
            if (!Program.graphicsDisplay.Focused) { return false; }
            if (Program.graphicsDisplay.WindowState == FormWindowState.Minimized) { return false; }

            if ((EngineCore.MousePosition.X >= PositionX) && (EngineCore.MousePosition.X <= (Size.Width + PositionX))) {
                if ((EngineCore.MousePosition.Y >= PositionY) && (EngineCore.MousePosition.Y <= (PositionY + Size.Height))) { return true; }
            }

            return false;
        }
    }
}
