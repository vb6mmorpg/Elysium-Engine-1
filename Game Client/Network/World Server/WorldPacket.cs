using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Elysium_Diamond.Common;
using Elysium_Diamond.DirectX;
using Lidgren.Network;

namespace Elysium_Diamond.Network {
    public class WorldPacket {
        /// <summary>
        /// Envia o HexID 
        /// </summary>
        public static void WorldServerHexID() {
            var buffer = NetworkSocket.CreateMessage();
            buffer.Write((int)PacketList.Client_WorldServer_SendPlayerHexID);
            buffer.Write(Configuration.HexID);

            NetworkSocket.SendData(NetworkSocketEnum.WorldServer, buffer);
        }

        public static void RequestPreLoad() {
            var buffer = NetworkSocket.CreateMessage(4);
            buffer.Write((int)PacketList.Client_WorldServer_RequestPreLoad);
            NetworkSocket.SendData(NetworkSocketEnum.WorldServer, buffer);
        }

        public static void DeleteCharacter(byte slot) {
            var buffer = NetworkSocket.CreateMessage();
            buffer.Write((int)PacketList.Client_WorldServer_DeleteCharacter);
            buffer.Write(slot);
            NetworkSocket.SendData(NetworkSocketEnum.WorldServer, buffer);
        }

        public static void CreateCharacter(byte gender, int classe, byte slot, int sprite, string name) {
            var buffer = NetworkSocket.CreateMessage();
            buffer.Write((int)PacketList.Client_WorldServer_CreateCharacter);
            buffer.Write(name);
            buffer.Write(slot);
            buffer.Write(classe);
            buffer.Write(gender);
            buffer.Write(sprite);
            NetworkSocket.SendData(NetworkSocketEnum.WorldServer, buffer);

        }

        public static void StartGame(byte slot) {
            var buffer = NetworkSocket.CreateMessage();
            buffer.Write((int)PacketList.Client_WorldServer_EnterInGame);
            buffer.Write(slot);
            NetworkSocket.SendData(NetworkSocketEnum.WorldServer, buffer);
        }
    }
}
