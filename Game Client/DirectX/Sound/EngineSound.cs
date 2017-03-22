using System;
using System.IO;
using SharpDX.XAudio2;
using SharpDX.Multimedia;
using SharpDX.IO;

namespace Elysium_Diamond.DirectX {
    public class EngineSound : IDisposable {
        public AudioBuffer AudioBuffer { get; set; }
        public SoundStream SoundStream { get; set; }
        /// <summary>
        /// Abre o arquivo de carrega para o stream.
        /// </summary>
        /// <param name="filename"></param>
        public EngineSound(string filename) {
            Stream fileStream = new NativeFileStream(filename, NativeFileMode.Open, NativeFileAccess.Read, NativeFileShare.Read);
            SoundStream = new SoundStream(fileStream);
            AudioBuffer = new AudioBuffer(SoundStream.ToDataStream());
            fileStream.Dispose();
        }

        /// <summary>
        /// Libera os recursos.
        /// </summary>
        public void Dispose() {
            AudioBuffer = null;
            SoundStream.Dispose();
            SoundStream = null;
        }
    }
}
