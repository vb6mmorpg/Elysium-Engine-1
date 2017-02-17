using System;
using System.Collections.Generic;
using System.Linq;
using Lidgren.Network;
using Elysium_Diamond.Common;
using Elysium_Diamond.EngineWindow;

namespace Elysium_Diamond.Network {
    public class WorldServerData {
        /// <summary>
        /// Carrega os personagens para exibição.
        /// </summary>
        /// <param name="data"></param>
        public static void PreLoad(NetIncomingMessage data) {
            var classID = 0;

            for (var index = 0; index < Configuration.MAX_CHARACTER; index++) {
                WindowCharacter.PlayerData[index].Name = data.ReadString();

                classID = data.ReadInt32();

                if (classID == 0) { WindowCharacter.PlayerData[index].Class = "Guerreiro"; }
                if (classID == 1) { WindowCharacter.PlayerData[index].Class = "Mago"; }

                WindowCharacter.PlayerData[index].Sprite = data.ReadInt16();
                WindowCharacter.PlayerData[index].Level = data.ReadInt32();
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
