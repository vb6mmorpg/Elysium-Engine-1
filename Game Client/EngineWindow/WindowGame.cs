using System;
using System.Collections.Generic;
using System.Linq;
using Elysium_Diamond.DirectX;
using Elysium_Diamond.GameClient;
using Elysium_Diamond.Resource;
using System.Text;
using SharpDX;
using SharpDX.Direct3D9;

namespace Elysium_Diamond.EngineWindow {
    public static class WindowGame {
        /// <summary>
        /// Barra de experiência.
        /// </summary>
        public static EngineExperienceBar ExperienceBar { get; set; }
        private static EngineShortCut ShortCut;
    
        public static void Initialize() {
            ExperienceBar = new EngineExperienceBar(519, 36);
            ExperienceBar.Position = new Point(245, 639);

            WindowShortCut.Initialize();
            WindowCharacterStatus.Initialize();
            WindowOption.Initialize();
            //WindowGuild.Initialize();
        }

        public static void Draw() {
            ExperienceBar.Percentage = Convert.ToInt32(((double)Client.PlayerLocal.Exp / (double)ExperienceManager.Experience[Client.PlayerLocal.Level + 1]) * 100);
            ExperienceBar.Draw(Client.PlayerLocal.Exp + "/" + ExperienceManager.Experience[Client.PlayerLocal.Level]);
            ExperienceBar.Draw();

            Client.PlayerLocal.Character.Draw();

            foreach (var character in Client.Player) {
                character.Draw();
            }

            WindowOption.Draw();

            WindowShortCut.Draw();
        ////  ShortCut.Draw(285, 521);
       //     ShortCut.Draw(285, 560);
        //    ShortCut.Draw(285, 600);

            WindowCharacterStatus.Draw();
        }
    }
}




/*
 * 
                //    foreach (EngineCharacter playerData in GameLogic.PlayerList.Player) {
                ///         playerData.Draw();
                //}

                // for (var n = 0; n < 3; n++) {
                //      Maps.npc[n].Draw();
                //  }

    */
