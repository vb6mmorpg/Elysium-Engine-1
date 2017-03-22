using System;
using System.Text;
using System.Runtime.InteropServices;

namespace Elysium_Diamond.DirectX {
    public class EngineMusic {
        [DllImport("winmm.dll")]
        private static extern long mciSendString(string strCommand, StringBuilder strReturn, int iReturnLength, IntPtr hwndCallback);

        private string command;
        private bool isOpen;
        private short _volume;
        private bool alreadyStopped;
        private bool alreadyOpened;

        /// <summary>
        /// Texto de identificação.
        /// </summary>
        public string Alias { get; set; }

        /// <summary>
        /// Arquivo de audio.
        /// </summary>
        public string File { get; set; }

        /// <summary>
        /// Obtem ou altera o volume. (Escala de 0 ~ 1000)
        /// </summary>
        public short Volume {
            get {
                return _volume;
            }
            set {
                _volume = value;

                SetVolume();
            }
        }

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="file"></param>
        /// <param name="alias"></param>
        /// <param name="volume"></param>
        public EngineMusic(string file, string alias, short volume = 1000) {
            File = $@".\Data\Music\{file}";
            Alias = alias;
            _volume = volume;
        }

        /// <summary>
        /// Abre um arquivo e salva os dados.
        /// </summary>
        public void Open() {
            command = $"open \"{File}\" type mpegvideo alias {Alias}";
            mciSendString(command, null, 0, IntPtr.Zero);
            isOpen = true;
        }

        /// <summary>
        /// Interrompe a execução do audio.
        /// </summary>
        public void Close() {
            if (alreadyStopped) { return; }

            command = $"close {Alias}";
            mciSendString(command, null, 0, IntPtr.Zero);

            isOpen = false;
            alreadyStopped = true;
            alreadyOpened = false;
        }

        /// <summary>
        /// Altera o volume.
        /// </summary>
        private void SetVolume() {
            command = $"setaudio {Alias} volume to {_volume}";
            mciSendString(command, null, 0, IntPtr.Zero);
        }

        /// <summary>
        /// Executa o arquivo de audio.
        /// </summary>
        /// <param name="loop"></param>
        public void Play(bool loop) {
            if (alreadyOpened) { return; }

            if (isOpen) {
                command = $"play {Alias}";
                if (loop)
                    command += " REPEAT";

                mciSendString(command, null, 0, IntPtr.Zero);
                alreadyOpened = true;
                alreadyStopped = false;
            }
        }
    }
}