using System;
using System.IO;
using SharpDX.XAudio2;
using SharpDX.Multimedia;
using SharpDX.IO;

// Retirado de "SharpDX.org"

namespace Elysium_Diamond.DirectX {
    public class EngineSound : IDisposable {
        public SoundStream SoundStream;
        public AudioBuffer AudioBuffer;

        public EngineSound(string filename) {
            Stream fileStream = new NativeFileStream(filename, NativeFileMode.Open, NativeFileAccess.Read, NativeFileShare.Read);
            SoundStream = new SoundStream(fileStream);
            AudioBuffer = new AudioBuffer(SoundStream.ToDataStream());
            fileStream.Dispose();
        }

        public void Dispose() {
            SoundStream.Dispose();
        }
    }
}
