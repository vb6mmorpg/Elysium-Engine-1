using System;
using System.Windows.Forms;
using Elysium_Diamond.Resource;
using Elysium_Diamond.GameWindow;
using Elysium_Diamond.Network;
using Elysium_Diamond.Common;
using SharpDX;
using SharpDX.Direct3D9;
using Color = SharpDX.Color;

namespace Elysium_Diamond.DirectX
{
    public class EngineCore 
    {
        public static Device DirectXDevice { get; set; }
        public static Sprite SpriteDevice { get; set; }
        public static int FPS { get; set; }
        public static byte GameState { get; set; }
        public static Point MousePosition { get; set; }
        public static bool MouseDown { get; set; }

        private static int pingTick, pFPS, TickFPS, tcpTick;

        public static Form Target; // Form Target

        /// <summary>
        /// Imagem de fundo para testes com transparência.
        /// </summary>
        private static EngineObject BackGround { get; set; }
        public static EngineCharacter Personagem { get; set; }
        public static EngineExpBar EngineBar { get; set; }

        public static EngineCharacter otherPlayer;
         
        public static bool Initialize()
        {
            try
            {
                PresentParameters presentParams = new PresentParameters();
                presentParams.Windowed = true;
                presentParams.BackBufferCount = 1;
                presentParams.SwapEffect = SwapEffect.Discard;
                presentParams.PresentationInterval = PresentInterval.Immediate;

                DirectXDevice = new Device(new Direct3D(), 0, DeviceType.Hardware, Program.graphicsDisplay.Handle, CreateFlags.SoftwareVertexProcessing, presentParams);
                SpriteDevice = new Sprite(DirectXDevice);

                DirectXDevice.SetRenderState(RenderState.SourceBlendAlpha, true);
                DirectXDevice.SetRenderState(RenderState.DestinationBlendAlpha, true);
                

                BackGround = new EngineObject(Environment.CurrentDirectory + @"\Data\background.png", 1024, 768);
                BackGround.Size = new Size2(1024, 768);
                BackGround.SourceRect = new Rectangle(0, 0, 1024, 768);

                EngineBar = new EngineExpBar(519, 36);
                EngineBar.Position = new Point(245, 639);

                Personagem = new EngineCharacter();
                Personagem.Name = "DragonicK";
                Personagem.GuildName = "B地区";
                Personagem.Sprite = 5;
                Personagem.Enabled = true;

                otherPlayer = new EngineCharacter();
                
                CurrentPlayerData.Level = 1;

                Experience.LoadExperience();

                EngineFont.Initialize();
                EngineMessageBox.Initialize();
                EngineInputBox.Initialize();
                EngineMultimedia.Initialize();

                WindowLogin.Initialize();
                WindowServer.Initialize();
                WindowCharacter.Initialize();
                WindowNewCharacter.Initialize();
                WindowGuild.Initialize();

                ResourceSprite.Initialize();

                EngineMultimedia.PlayMusic(0, true);

                GameState = 1;

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public static void Render()
        {
            if (DirectXDevice == null) { return; }

            DirectXDevice.Clear(ClearFlags.Target, Color.Black, 1.0f, 0);
            DirectXDevice.BeginScene();

            if (GameState >= 1 && GameState <= 4) 
                BackGround.Draw();

            if (GameState == 1) { WindowLogin.Draw(); }
            if (GameState == 2) { WindowServer.Draw(); }
            if (GameState == 3) { WindowCharacter.Draw(); }
            if (GameState == 4) { WindowNewCharacter.Draw(); }
            if (GameState == 6) {
                Personagem.Draw();

                foreach (EngineCharacter playerData in GameLogic.PlayerList.Player) {
                    playerData.Draw();
                 }
                 
               // for (var n = 0; n < 3; n++) {
              //      Maps.npc[n].Draw();
              //  }

                EngineBar.Draw(CurrentPlayerData.Exp + "/" + Experience.Data[CurrentPlayerData.Level + 1]);
                EngineFont.DrawText(null, "X: " + Personagem.Coordinate.X + " Y: " + Personagem.Coordinate.Y, 900, 32, Color.Coral, EngineFontStyle.Bold);
                EngineFont.DrawText(null, "X: " + Personagem.PositionX + " Y: " + Personagem.PositionY, 850, 75, Color.Coral, EngineFontStyle.Bold);
                EngineFont.DrawText(null, "X: " + Personagem.OffSetX + " Y: " + Personagem.OffSetY, 850, 115, Color.Coral, EngineFontStyle.Bold);
                WindowGuild.Draw();
            }

            EngineInputBox.Draw();
            EngineMessageBox.Draw();

            EngineFont.DrawText(null, "FPS: " + FPS, 925, 0, Color.Coral, EngineFontStyle.Bold);
            EngineFont.DrawText(null, "Ping: " + Settings.ping, 5, 0, Color.Coral, EngineFontStyle.Bold);

            DirectXDevice.EndScene();
            DirectXDevice.Present();
        }
        static public void Update()
        {
            LoginServerNetwork.Instance.ReceiveData();
            GameServerNetwork.Instance.ReceiveData();
            WorldServerNetwork.Instance.ReceiveData();

            if (Environment.TickCount >= tcpTick + 3000) {
                if (!Settings.Disconnected) {
                    LoginServerNetwork.Instance.initTCP();
                    GameServerNetwork.Instance.initTCP();
                    WorldServerNetwork.Instance.initTCP();
                }

                tcpTick = Environment.TickCount;
            }

            //ping
            if (GameState == 6) {
                if (Environment.TickCount >= pingTick + 1000) {
                    GeneralServerPacket.SendRequestPing();
                    pingTick = Environment.TickCount;
                }
            }

            if (Environment.TickCount >= TickFPS + 1000) {
                FPS = pFPS;
                pFPS = 0;

                TickFPS = Environment.TickCount;
            }
            else {
                pFPS++;
            }
        }

        public static void Exit() {
            EngineMultimedia.StopEngine();
            EngineMultimedia.StopMusic();

            Application.Exit();
        }
                
    }
}
