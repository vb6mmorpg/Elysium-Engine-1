using System;
using System.Collections.Generic;
using System.Linq;
using GameServer.Common;
using GameServer.Network;
using GameServer.MySQL;
using GameServer.GameLogic.Character;
using GameServer.Maps;
using Lidgren.Network;

namespace GameServer.Server {
    public static class Authentication {
        /// <summary>
        /// HexID recebido pelo login server.
        /// </summary>
        public static HashSet<HexaID> HexID { get; set; }

        /// <summary>
        /// Conexões e jogadores.
        /// </summary>
        public static HashSet<PlayerData> Player { get; set; }

        /// <summary>
        /// Adiciona os dados recebido do login server.
        /// </summary>
        /// <param name="data"></param>
        public static void AddHexID(NetIncomingMessage data) {
            HexaID hexID = new HexaID();

            hexID.HexID = data.ReadString();
            hexID.Account = data.ReadString();
            hexID.AccountID = data.ReadInt32();
            hexID.LanguageID = data.ReadByte();
            hexID.AccessLevel = data.ReadInt16();
            hexID.CharacterID = data.ReadInt32();
            hexID.CharSlot = data.ReadInt32();
            var service = data.ReadInt32();

            for (var n = 0; n < service; n++) hexID.Service.Add(data.ReadString());

            hexID.Time = Environment.TickCount;

            HexID.Add(hexID);

            LogConfig.WriteLog($"Data From World Server ID: {hexID.AccountID} Account: {hexID.Account} Char ID: {hexID.CharacterID} Slot: {hexID.CharSlot} {hexID.HexID}", System.Drawing.Color.Black);
        }

        /// <summary>
        /// Recebe do cliente e altera o hexID.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="hexID"></param>
        public static void ReceiveHexID(NetConnection connection, string hexID) {
            PlayerData pData = FindByConnection(connection);
            pData.HexID = hexID;

            LogConfig.WriteLog($"Received From Client: {hexID}", System.Drawing.Color.Black);
        }

        /// <summary>
        /// Copia a estrutura para a Player e remove da lista de HexID.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="hexIndex"></param>
        public static void AcceptHexID(NetConnection connection, HexaID hexID) {
            PlayerData pData = FindByConnection(connection);

            pData.HexID = hexID.HexID;
            pData.AccountID = hexID.AccountID;
            pData.Account = hexID.Account;
            pData.LanguageID = hexID.LanguageID;
            pData.AccessLevel = hexID.AccessLevel;
            pData.CharacterID = hexID.CharacterID;
            pData.CharSlot = hexID.CharSlot;
            pData.Service = hexID.Service;

            HexID.Remove(hexID);
        }

        /// <summary>
        /// Percorre todos os jogadores e verifica o estado atual do HexID.
        /// </summary>
        public static void VerifyPlayerHexID() {
            HexaID hexID = null;

            foreach (PlayerData pData in Player) {
                if (!string.IsNullOrEmpty(pData.Account)) { continue; }

                if (string.IsNullOrEmpty(pData.HexID)) { continue; }

                //Aceita o hexID e permite a conexão do world server
                for (int i = 0; i < Constant.MAX_SERVER; i++) {
                    if (pData.HexID.CompareTo(Settings.WorldServerID[i]) == 0) {
                        hexID = new HexaID();
                        hexID.Account = pData.HexID;
                        hexID.HexID = pData.HexID;

                        AcceptHexID(pData.Connection, hexID);
                    }
                }

                hexID = FindHexID(pData.HexID);

                // Se não encontrar o hexid, desconecta o usuário pelo cliente
                if (hexID == null) {
                    GameServerPacket.Message(pData.Connection, (int)PacketList.Disconnect);
                    continue;
                }

                AcceptHexID(pData.Connection, hexID);

                // Carrega dados do personagem
                Character_DB.Load(pData.HexID, pData.CharSlot);
                LogConfig.WriteLog($"Player Found ID: {pData.CharacterID} Name: {pData.CharacterName}", System.Drawing.Color.Black);

                //Realiza o calculo dos stats
                CharacterLogic.UpdateCharacterStats(pData.AccountID);

                //Aceita a conexão
                GameServerPacket.Message(pData.Connection, (int)PacketList.AcceptedConnection);

                //Envia dados para o jogador
                pData.SendPlayerBasicData();
                pData.SendPlayerElementalStats();
                pData.SendPlayerLocation();
                pData.SendPlayerMagicStats();
                pData.SendPlayerPhysicalStats();
                pData.SendPlayerResistStats();
                pData.SendPlayerStats();
                pData.SendPlayerUniqueStats();
                pData.SendPlayerVital();
                pData.SendPlayerVitalRegen();
                pData.SendPlayerExp();
                      
                // adiciona o jogador ao mapa
                MapGeneral.Map.PlayerID.Add(pData.AccountID);

                //envia outros jogadores do mapa
                MapGeneral.Map.GetPlayerOnMap(pData);

                //envia jogador para outros jogadores do mapa
                MapGeneral.Map.SendPlayerToMap(pData);

                //########################
                //####  GET MAP DATA  ####
                //########################

                // Maps.MapPacket.SendNpc(pData.Connection, 0);

                // Muda de janela
                GameServerPacket.GameState(pData.HexID, 6);
            }
        }

        /// <summary>
        /// Percorre todos os hexid e verifica o estado atual.
        /// </summary>
        public static void VerifyHexID() {
            foreach (HexaID hexID in HexID) {
                if (Environment.TickCount > hexID.Time + 45000) {
                    LogConfig.WriteLog($"Removed HexID: {hexID.HexID} {hexID.Account}", System.Drawing.Color.Coral);
                    HexID.Remove(hexID); 
                }
            }
        }

        /// <summary>
        /// Procura o HexID, se não encontrar, retorna -1.
        /// </summary>
        /// <param name="hexid"></param>
        /// <returns></returns>
        public static HexaID FindHexID(string hexID) {
            if (string.IsNullOrEmpty(hexID)) { return null; }

            var find_hexid = from hData in HexID
                             where hData.HexID.CompareTo(hexID) == 0
                             select hData;

            return find_hexid.FirstOrDefault();
        }

        /// <summary>
        /// Realiza uma busca pelo ID de usuário.
        /// </summary>
        /// <param name="pID"></param>
        /// <returns></returns>
        public static PlayerData FindByAccountID(int pID) {
            var find_id = from pData in Player
                          where pData.AccountID.CompareTo(pID) == 0
                          select pData;

            return find_id.FirstOrDefault();
        }

        /// <summary>
        /// Realiza uma busca pelo ID de conexão.
        /// </summary>
        /// <param name="hexID"></param>
        /// <returns></returns>
        public static PlayerData FindByHexID(string hexID) {
            var find_hexID = from pData in Player
                             where pData.HexID.CompareTo(hexID) == 0
                             select pData;

            return find_hexID.FirstOrDefault();
        }

        /// <summary>
        /// Realiza uma busca pelo nome de usuário.
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public static PlayerData FindByAccount(string account) {
            var find_account = from pData in Player
                               where pData.Account.CompareTo(account) == 0
                               select pData;

            return find_account.FirstOrDefault();
        }

        /// <summary>
        /// Realiza uma busca pela conexão.
        /// </summary>
        /// <param name="connection"></param>
        /// <returns></returns>
        public static PlayerData FindByConnection(NetConnection connection) {
            if (Equals(null, connection)) { return null; }

            var find_connection = from pData in Player
                                  where pData.Connection.Equals(connection)
                                  select pData;

            return find_connection.FirstOrDefault();
        }

        /// <summary>
        /// Verifica se o usuário já está conectado.
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public static bool IsConnected(string account) {
            var find_account = from pData in Player
                               where pData.Account.CompareTo(account) == 0
                               select pData;

            return find_account.FirstOrDefault() == null ? true : false;
        }

    }
}
