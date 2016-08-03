using System;
using System.Collections.Generic;
using System.IO;
using SharpDX.XAudio2;
using SharpDX.Multimedia;
using SharpDX.IO;

// Retirado de "SharpDX.org"
//http://neareal.net/index.php?ComputerGraphics%2FSharpDX%2FSoundEffectWithToolkit

namespace Elysium_Diamond.DirectX {
    public class EngineSoundManager {
        public EngineSoundManager() {
            XAudio2 = new XAudio2();
            MasteringVoice = new MasteringVoice(XAudio2);
        }

        public void StopEngine() {
            XAudio2.StopEngine();
        }

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

        public void ReuseVoice(SourceVoice voice) {
            lock (FreeVoices) {
                FreeVoices.Add(voice);
            }
        }

        protected struct SoundCompleteCallback {
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

        protected XAudio2 XAudio2;
        protected MasteringVoice MasteringVoice;
        protected List<SourceVoice> FreeVoices = new List<SourceVoice>();
    }
}