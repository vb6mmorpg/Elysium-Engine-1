using System;
using System.Windows.Forms;
using Elysium_Diamond.Resource;
using Elysium_Diamond.EngineWindow;
using Elysium_Diamond.Network;
using Elysium_Diamond.Common;
using Elysium_Diamond.Client;
using SharpDX;
using SharpDX.Direct3D9;
using Color = SharpDX.Color;

namespace Elysium_Diamond.DirectX {
    public class EngineCore {
        /// <summary>
        /// Dispostivo de directx.
        /// </summary>
        public static Device Device { get; set; }

        /// <summary>
        /// Dispositivo de sprite.
        /// </summary>
        public static Sprite SpriteDevice { get; set; }

        /// <summary>
        /// Etapa de desenho??
        /// </summary>
        public static byte GameState { get; set; }

        /// <summary>
        /// Checa se o mouse foi pressionado.
        /// </summary>
        public static bool MouseDown { get; set; }

        /// <summary>
        /// Coordenadas de mouse.
        /// </summary>
        public static Point MousePosition { get; set; }

        public static int FPS { get; set; }

        /// <summary>
        /// Controle de FPS.
        /// </summary>
        private static int pingTick, pFPS, tickFPS, tcpTick;

        /// <summary>
        /// Imagem de fundo para testes com transparência.
        /// </summary>
        private static EngineObject background;

        public static bool InitializeDirectX() {
            try {
                PresentParameters presentParams = new PresentParameters();
                presentParams.Windowed = true;
                presentParams.BackBufferCount = 1;
                presentParams.SwapEffect = SwapEffect.Discard;
                presentParams.PresentationInterval = PresentInterval.Default;

                Device = new Device(new Direct3D(), 0, DeviceType.Hardware, Program.GraphicsDisplay.Handle, CreateFlags.SoftwareVertexProcessing, presentParams);
                SpriteDevice = new Sprite(Device);

                Device.SetRenderState(RenderState.SourceBlendAlpha, true);
                Device.SetRenderState(RenderState.DestinationBlendAlpha, true);

                return true;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public static bool InitializeEngine() {
            NetworkSocket.Initialize();
            try {
                background = new EngineObject($"{Environment.CurrentDirectory}\\Data\\background.png", 1024, 768);
                background.Size = new Size2(1024, 768);
                background.SourceRect = new Rectangle(0, 0, 1024, 768);

                //Carrega os dados de experiencia
                ExperienceManage.Experience.Initialize("experience");            

                EngineFont.Initialize();
                EngineMessageBox.Initialize();
                EngineInputBox.Initialize();
                EngineMultimedia.Initialize();
  
                WindowLogin.Initialize();
                WindowServer.Initialize();
                WindowCharacter.Initialize();
                WindowNewCharacter.Initialize();

                WindowGame.Initialize();

                SpriteManage.Initialize();

                EngineMultimedia.PlayMusic(0, true);

                GameState = 1;
                return true;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public static void Render() {
            if (Device == null) { return; }

            Device.Clear(ClearFlags.Target, Color.Black, 1.0f, 0);
            Device.BeginScene();

            background.Draw(); 
                       
            if (GameState == 1) { WindowLogin.Draw(); }
            if (GameState == 2) { WindowServer.Draw(); }
            if (GameState == 3) { WindowCharacter.Draw(); }
            if (GameState == 4) { WindowNewCharacter.Draw(); }
            if (GameState == 6) { WindowGame.Draw(); }
        
            EngineInputBox.Draw();
            EngineMessageBox.Draw();

            EngineFont.DrawText(null, "FPS: " + FPS, 925, 0, Color.Coral, EngineFontStyle.Bold);
            EngineFont.DrawText(null, "Ping: " + Common.Configuration.Latency, 5, 0, Color.Coral, EngineFontStyle.Bold);

            Device.EndScene();
            Device.Present();
        }

        static public void Update() {
            NetworkSocket.ReceiveData();
  
            if (Environment.TickCount >= tcpTick + 1000) {
                if (!Common.Configuration.Disconnected) {
                    NetworkSocket.DiscoverServer(NetworkSocketEnum.LoginServer);
                    NetworkSocket.DiscoverServer(NetworkSocketEnum.WorldServer);
                    NetworkSocket.DiscoverServer(NetworkSocketEnum.GameServer);
                }

                tcpTick = Environment.TickCount;
            }

            //ping
            if (GameState == 6) {
                if (Environment.TickCount >= pingTick + 1000) {
                    CommonPacket.RequestPing();
                    pingTick = Environment.TickCount;
                }
            }

            if (Environment.TickCount >= tickFPS + 1000) {
                FPS = pFPS;
                pFPS = 0;

                tickFPS = Environment.TickCount;
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
    