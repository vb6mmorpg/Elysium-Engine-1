using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lidgren.Network;
using Elysium_Diamond.DirectX;
using Elysium_Diamond.Common;
using Elysium_Diamond.GameWindow;

namespace Elysium_Diamond.Network
{
    public class WorldServerData
    {
        public static void HandleData(NetIncomingMessage data)
        {
            // Packet Header //
            var msgIndex = data.ReadInt32();

            // Check Packet Header Number //
            if (msgIndex < 0) { return; }

            // Handle Incoming Message //
            switch (msgIndex)
            {
                case (int)PacketList.None: break;
                case (int)PacketList.Disconnect: Message(PacketList.Disconnect); break;
                case (int)PacketList.AcceptedConnection: Message(PacketList.AcceptedConnection); break;
                case (int)PacketList.WorldServer_Client_CharacterDeleted: Message(PacketList.WorldServer_Client_CharacterDeleted); break;
                case (int)PacketList.ChangeGameState: CommonMessage.ChangeGameState(data.ReadByte()); break;
                case (int)PacketList.Error: Message(PacketList.Error); break;
                case (int)PacketList.WorldServer_Client_CharNameInUse: Message(PacketList.WorldServer_Client_CharNameInUse); break;
                case (int)PacketList.WorldServer_Client_CharacterCreationDisabled: Message(PacketList.WorldServer_Client_CharacterCreationDisabled); break;
                case (int)PacketList.WorldServer_Client_CharacterDeleteDisabled: Message(PacketList.WorldServer_Client_CharacterDeleteDisabled); break;

                case (int)PacketList.WorldServer_Client_InvalidLevelToDelete: Message(PacketList.WorldServer_Client_InvalidLevelToDelete); break;
                case (int)PacketList.WorldServer_Client_NeedPlayerHexID: WorldServerPacket.WorldServerHexID(); break;
                case (int)PacketList.WorldServer_Client_CharacterPreLoad: PreLoad(data); break;
                case (int)PacketList.WorldServer_Client_GuildInfo: WorldGuildInfo(data); break;
                case (int)PacketList.WorldServer_Client_GameServerData: GameServerData(data); break;
            }
        }

        public static void PreLoad(NetIncomingMessage data)
        {

            for (int n = 0; n < 4; n++)
            {
                int class_id;
                WindowCharacter.PlayerData[n].Name = data.ReadString();
                class_id = data.ReadInt32();

                if (class_id == 0)
                { 
                    WindowCharacter.PlayerData[n].Class = "Guerreiro"; 
                }
                else
                {
                    WindowCharacter.PlayerData[n].Class = "Mago";
                }

                WindowCharacter.PlayerData[n].Sprite = data.ReadInt32();
                WindowCharacter.PlayerData[n].Level = data.ReadInt32();
            }
        }

        public static void Message(PacketList value)
        {
            switch (value)
            {
                case PacketList.Disconnect:
                    Settings.Disconnected = true;
                    EngineMessageBox.Enabled = true;
                    EngineMessageBox.Show("Desconectado");
                    GameServerNetwork.Instance.TCPClient.Disconnect("dc");
                    if (WorldServerNetwork.Instance.TCPClient != null) { WorldServerNetwork.Instance.TCPClient.Disconnect("dc"); }
                    break;

                case PacketList.AcceptedConnection:
                    EngineMessageBox.Enabled = true;
                    EngineMessageBox.Visible = false;
                    break;

                case PacketList.WorldServer_Client_CharacterDeleted:
                    EngineMessageBox.Enabled = true;
                    EngineMessageBox.Show("Personagem deletado");
                    break;

                case PacketList.Error:
                    EngineMessageBox.Enabled = true;
                    EngineMessageBox.Show("Ocorreu um erro");
                    break;

                case PacketList.WorldServer_Client_CharNameInUse:
                    EngineMessageBox.Enabled = true;
                    EngineMessageBox.Show("Nome já está em uso");
                    break;

                case PacketList.WorldServer_Client_CharacterCreationDisabled:
                    EngineMessageBox.Enabled = true;
                    EngineMessageBox.Show("Criação de personagens desativado");
                    break;

                case PacketList.WorldServer_Client_CharacterDeleteDisabled:
                    EngineMessageBox.Enabled = true;
                    EngineMessageBox.Show("Exclusão de personagens desativado");
                    break;

                case PacketList.WorldServer_Client_InvalidLevelToDelete:
                    EngineMessageBox.Enabled = true;
                    EngineMessageBox.Show("Limite de level para exclusão 1 ~ 50");
                    break;
            }
        }

        public static void WorldGuildInfo(NetIncomingMessage data)
        {
            WindowGuild.GuildMaster = data.ReadString();
            WindowGuild.GuildName = data.ReadString();
            WindowGuild.Member = data.ReadInt32();
            WindowGuild.Online = data.ReadInt32();
            WindowGuild.Announcement = data.ReadString();
        }

        public static void GameServerData(NetIncomingMessage data)
        {
            Settings.HexID = data.ReadString();
            Settings.GameServerIP = data.ReadString();
            Settings.GameServerPort = data.ReadInt32();

            GameServerNetwork.Instance.TCPClient.Disconnect("0");
        }
    }
}
