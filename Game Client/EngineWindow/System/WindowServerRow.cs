using System;
using SharpDX;
using SharpDX.Direct3D9;
using Color = SharpDX.Color;
using Elysium_Diamond.DirectX;
using Elysium_Diamond.Network;

namespace Elysium_Diamond.EngineWindow {
    public class WindowServerRow : IDisposable {
        /// <summary>
        /// Posição do controle.
        /// </summary>
        public Point Position { get; set; }

        /// <summary>
        /// IP de Conexão.
        /// </summary>
        public string IP { get; set; }

        /// <summary>
        /// Porta de conexão.
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// Nome do servidor.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Região.
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        /// Estado atual do servidor.
        /// </summary>
        public string Status { get; set; }
        
        /// <summary>
        /// Quantidade de jogadores conectados.
        /// </summary>
        public int PlayerActive { get; set; }

        /// <summary>
        /// Quantidade máxima de jogadores.
        /// </summary>
        public int PlayerMax { get; set; }

        /// <summary>
        /// Índice do controle.
        /// </summary>
        public int Index { get; set; }
 
        /// <summary>
        /// Controle para o evento.
        /// </summary>
        private EngineObject background { get; set; }

        /// <summary>
        /// Textura de fundo estatica (evitar múltiplos carregamentos)
        /// </summary>
        private static Texture[] texture = new Texture[2];
        private int step = 0;
        private Color color = Color.White;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="position"></param>
        public WindowServerRow(Point position) {
            background = new EngineObject();
            background.Enabled = true;
            background.Transparency = 255;
            background.Size = new Size2(384, 64);
            background.SourceRect = new Rectangle(0, 0, 384, 64);
            background.BorderRect = new Rectangle(14, 8, 360, 35);
            background.Position = position;
            background.MouseUp += Background_MouseUp;
            this.Position = position;

            //carrega a textura apenas uma vez
            if (texture[0] == null) {
                texture[0] = EngineTexture.TextureFromFile(Common.Configuration.GamePath + @"\Data\Graphics\row1.png", 384, 64);  //350, 35
                texture[1] = EngineTexture.TextureFromFile(Common.Configuration.GamePath + @"\Data\Graphics\row2.png", 384, 64);
            }
        }

        /// <summary>
        /// Destrutor
        /// </summary>
        ~WindowServerRow() {
            Dispose();
        }

        /// <summary>
        /// Desenha os controles.
        /// </summary>
        public void Draw() {
            if (String.IsNullOrEmpty(IP)) { return; }

            if (background.InsideButton()) {
                step = 1;
            }
            else {
                step = 0;
            }

            //muda a textura quando selecionado
            background.Draw(texture[step]);

            EngineFont.DrawText(null, Name + " " + Region + " " + Status, new Size2(384, 0), new Point(Position.X, Position.Y + 30), color, EngineFontStyle.Regular, FontDrawFlags.Center, false);
        }

        /// <summary>
        /// Conecta ao world quando clicado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Background_MouseUp(object sender, EventArgs e) {
            if (EngineMessageBox.Visible) { return; }

            EngineMultimedia.Play(EngineSoundEnum.Click);

            NetworkSocket.Disconnect(NetworkSocketEnum.WorldServer);

            Common.Configuration.IPAddress[(int)NetworkSocketEnum.WorldServer] = new IPAddress(IP, Port);

            LoginPacket.ConnectWorldServer(Index);

            EngineMessageBox.Enabled = false;
            EngineMessageBox.Show("Aguardando conexão");
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
                    texture[0].Dispose();
                    texture[1] = null;
                    background = null;
                }

                disposed = true;
            }

        }
        #endregion
    }
}



/* public ServerType Type { get; set; }
public enum ServerType {
    WorldServer,
    GameServer,
    EventServer
} */