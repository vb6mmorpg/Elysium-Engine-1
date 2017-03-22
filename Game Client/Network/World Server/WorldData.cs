using System;
using System.Collections.Generic;
using System.Linq;
using Lidgren.Network;
using Elysium_Diamond.Common;
using Elysium_Diamond.EngineWindow;

namespace Elysium_Diamond.Network {
    public class WorldData {
        /// <summary>
        /// Carrega os personagens para exibição.
        /// </summary>
        /// <param name="data"></param>
        public static void PreLoad(NetIncomingMessage data) {
            var classeIndex = 0;

            //limpa os dados dos personagens
            WindowCharacter.Clear();

            for (var index = 0; index < Configuration.MAX_CHARACTER; index++) {
                WindowCharacter.Player[index].Name = data.ReadString();

                classeIndex = Classes.ClasseManager.GetIndexByID(data.ReadInt32());

                WindowCharacter.Player[index].Class = Classes.ClasseManager.Classes[classeIndex].Name;
                WindowCharacter.Player[index].Sprite = data.ReadInt16();
                WindowCharacter.Player[index].Level = data.ReadInt32();
            }
        }

        /// <summary>
        /// Recebe os dados do game server.
        /// </summary>
        /// <param name="data"></param>
        public static void GameServerData(NetIncomingMessage data) {
            Configuration.HexID = data.ReadString();
            Configuration.IPAddress[(int)NetworkSocketEnum.GameServer] = new IPAddress(data.ReadString(), data.ReadInt32());      
            NetworkSocket.Disconnect(NetworkSocketEnum.GameServer);
        }
    }
}
