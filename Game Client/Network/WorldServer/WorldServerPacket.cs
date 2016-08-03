using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Elysium_Diamond.Common;
using Elysium_Diamond.DirectX;
using Lidgren.Network;

namespace Elysium_Diamond.Network
{
    public class WorldServerPacket
    {
        /// <summary>
        /// Envia o HexID 
        /// </summary>
        public static void WorldServerHexID()
        {
            NetOutgoingMessage buffer = WorldServerNetwork.Instance.TCPClient.CreateMessage();
            buffer.Write((int)PacketList.Client_WorldServer_SendPlayerHexID);
            buffer.Write(Settings.HexID);
            WorldServerNetwork.Instance.SendData(buffer);
        }

        public static void DeleteCharacter(byte slot)
        {
            NetOutgoingMessage buffer = WorldServerNetwork.Instance.TCPClient.CreateMessage();
            buffer.Write((int)PacketList.Client_WorldServer_DeleteCharacter);
            buffer.Write(slot);
            WorldServerNetwork.Instance.SendData(buffer);
        }

        public static void CreateCharacter(byte gender, byte classe, byte slot, int sprite, string name)
        {
            NetOutgoingMessage buffer = WorldServerNetwork.Instance.TCPClient.CreateMessage();
            buffer.Write((int)PacketList.Client_WorldServer_CreateCharacter);
            buffer.Write(name);
            buffer.Write(slot);
            buffer.Write(classe);
            buffer.Write(gender);
            buffer.Write(sprite);
            WorldServerNetwork.Instance.SendData(buffer);
            
        }

        public static void StartGame(byte slot)
        {
            NetOutgoingMessage buffer = WorldServerNetwork.Instance.TCPClient.CreateMessage();
            buffer.Write((int)PacketList.Client_WorldServer_EnterInGame);
            buffer.Write(slot);
            WorldServerNetwork.Instance.SendData(buffer);
        }
    }
}
