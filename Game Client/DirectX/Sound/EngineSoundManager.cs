using System;
using System.Collections.Generic;
using SharpDX.XAudio2;

namespace Elysium_Diamond.DirectX {
    public class EngineSoundManager {

        private struct SoundCompleteCallback {
            public EngineSoundManager Manager;
            public SourceVoice Voice;

            public SoundCompleteCallback(EngineSoundManager manager, SourceVoice voice) {
                Manager = manager;
                Voice = voice;
            }

            public void OnSoundFinished(IntPtr arg) {
                Manager.ReuseVoice(Voice);
            }
        }

        private XAudio2 XAudio2;
        private MasteringVoice MasteringVoice;
        private List<SourceVoice> FreeVoices = new List<SourceVoice>();

        /// <summary>
        /// Construtor
        /// </summary>
        public EngineSoundManager() {
            XAudio2 = new XAudio2();
            MasteringVoice = new MasteringVoice(XAudio2);
        }

        /// <summary>
        /// 
        /// </summary>
        public void StopEngine() {
            XAudio2.StopEngine();
        }

        /// <summary>
        /// Altera o volume.
        /// </summary>
        /// <param name="volume"></param>
        public void SetVolume(float volume) {
            MasteringVoice.SetVolume(volume);
        }

        /// <summary>
        /// Otem o volume 1.0f (máximo).
        /// </summary>
        /// <returns></returns>
        public float GetVolume() {
            return MasteringVoice.Volume;
        }

        /// <summary>
        /// Executa o stream de som.
        /// </summary>
        /// <param name="sound"></param>
        public void Play(EngineSound sound) {
            SourceVoice voice;

            lock (FreeVoices) {
                if (FreeVoices.Count == 0) {
                    voice = new SourceVoice(XAudio2, sound.SoundStream.Format, true);
                    voice.BufferEnd += (new SoundCompleteCallback(this, voice)).OnSoundFinished;
                } else {
                    voice = FreeVoices[FreeVoices.Count - 1];
                    FreeVoices.RemoveAt(FreeVoices.Count - 1);
                }
            }

            voice.SubmitSourceBuffer(sound.AudioBuffer, sound.SoundStream.DecodedPacketsInfo);
            voice.Start();
        }

        private void ReuseVoice(SourceVoice voice) {
            lock (FreeVoices) {
                FreeVoices.Add(voice);
            }
        }

        /// <summary>
        /// Não necessariamente um dispose.
        /// </summary>
        public void Dispose() {
            StopEngine();
            XAudio2.Dispose();

            XAudio2 = null;
            MasteringVoice = null;
        }
    }
}