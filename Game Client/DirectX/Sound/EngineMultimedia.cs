using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Elysium_Diamond.Common;
using SharpDX.XAudio2;

namespace Elysium_Diamond.DirectX {
    public static class EngineMultimedia {
        private static EngineSoundManager SoundManager { get; set; }
        private static List<EngineMusic> Player { get; set; }
        public static List<EngineSound> Sound { get; set; }

        /// <summary>
        /// Instancia e inicializa os arquivos de audio.
        /// </summary>
        public static void Initialize() {
            SoundManager = new EngineSoundManager();
            Sound = new List<EngineSound>();

            Player = new List<EngineMusic>();
            Player.Add(new EngineMusic("Lineage 2 Ertheia - The Epic Tales of Aden.mp3", "Ertheia"));
            Player.Add(new EngineMusic("scene_1.wav", "Scene"));

            //Carrega os arquivos.
            Sound.Add(new EngineSound(Configuration.GamePath + @"\Data\Sound\0.wav"));
            Sound.Add(new EngineSound(Configuration.GamePath + @"\Data\Sound\1.wav"));
        }

        public static void PlayMusic(int index, bool loop) {
            Player[index].Open();
            Player[index].Play(loop);
        }

        public static void StopMusic(int index) {
            Player[index].Close();
        }

        public static void StopMusic() {
            foreach (EngineMusic music in Player) {
                music.Close();
            }
        }

        /// <summary>
        /// Toca um som com base no índice.
        /// </summary>
        /// <param name="index"></param>
        public static void Play(EngineSoundEnum index) {
            SoundManager.Play(Sound[(int)index]);          
        }


        /// <summary>
        /// Para a 'engine' evitando problemas.
        /// </summary>
        public static void StopEngine() {
            SoundManager.StopEngine();
        }
        
    }
}
