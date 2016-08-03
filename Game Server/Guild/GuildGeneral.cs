using System;
using System.Collections.Generic;
using System.Linq;
using GameServer.MySQL;
using GameServer.Server;

namespace GameServer.GameGuild {
    public partial class Guild {
        public static HashSet<Guild> Guilds { get; set; }

        /// <summary>
        /// Realiza uma busca pelo ID de guild.
        /// </summary>
        /// <param name="gID"></param>
        /// <returns></returns>
        public static Guild FindGuildByID(int gID) {
            if (gID == 0) { return null; }

            var find_value = from gData in Guilds
                             where gData.ID.CompareTo(gID) == 0
                             select gData;

            return find_value.FirstOrDefault();
        }

        /// <summary>
        /// Realiza uma busca pelo nome de guild.
        /// </summary>
        /// <param name="gName"></param>
        /// <returns></returns>
        public static Guild FindGuildByName(string gName) {
            if (string.IsNullOrEmpty(gName)) { return null; }

            var find_value = from gData in Guilds
                             where gData.Name.CompareTo(gName) == 0
                             select gData;

            return find_value.FirstOrDefault();
        }

        /// <summary>
        /// Realiza uma busca pelo ID do dono de guild.
        /// </summary>
        /// <param name="pID"></param>
        /// <returns></returns>
        public static Guild FindGuildByOwnerID(int pID) {
            if (pID == 0) { return null; }

            var find_value = from gData in Guilds
                             where gData.OwnerID.CompareTo(pID) == 0
                             select gData;

            return find_value.FirstOrDefault();
        }

        /// <summary>
        /// Realiza uma busca pelo nome do dono de guild.
        /// </summary>
        /// <param name="pName"></param>
        /// <returns></returns>
        public static Guild FindGuildByOwnerName(string pName) {
            if (string.IsNullOrEmpty(pName)) { return null; }

            var find_value = from gData in Guilds
                             where gData.OwnerName.CompareTo(pName) == 0
                             select gData;

            return find_value.FirstOrDefault();
        }

        public static void CreateGuild(string hexID, string gName) {
            // Verificar se o personagem já está em uma guild ...
            // Se verdadeiro, enviar mensagem de erro
            if (Authentication.FindByHexID(hexID).GuildID >= 1) {
                //WorldServerPacket.Message(hexID, (int)PacketList.WorldServer_UserAlreadyInGuild);
                return;
            }

            // Verificar se o nome já existe no banco de dados ...
            // Se verdadeiro, enviar mensagem ...
            if (Guild_DB.ExistGuild(gName)) {
                //WorldServerPacket.Message(hexID, (int)PacketList.WorldServer_GuildNameInUse);
                return;
            }

            var pData = Authentication.FindByHexID(hexID);

            // Instancia a lista de membro e historico
            var gData = new Guild(true);

            gData.OwnerID = pData.CharacterID;
            gData.OwnerName = pData.CharacterName;
            gData.Name = gName;
            gData.Level = 1;
            gData.Announcement = " ";

            // Insere a guild no banco de dados
            Guild_DB.InsertGuild(pData.CharacterID, pData.CharacterName, gName);

            // Pega o ID da guild e altera os valores
            gData.ID = Guild_DB.GuildID(gName);
            pData.GuildID = gData.ID;

            // Salva o ID de guild do personagem
            Guild_DB.UpdatePlayerGuildID(pData.CharacterID, pData.GuildID);

            // Adiciona novo membro
            GuildMember mData = new GuildMember();
            mData.ID = pData.CharacterID;
            mData.Name = pData.CharacterName;
            mData.Access = 1;
            mData.Permission = "1, 1, 1, 1";
            mData.Status = true;
            mData.SelfIntro = " ";

            // Adiciona membro a guild
            gData.Member.Add(mData);

            // Insere novo membro no banco de dados
            Guild_DB.InsertMember(pData.GuildID, pData.CharacterID, pData.CharacterName, "1, 1, 1, 1,");

            // Adiciona novo historico
            var hData = new GuildHistory();
            hData.Date = DateTime.Now + "";
            hData.PlayerName = pData.CharacterName;
            hData.Description = pData.CharacterName + " criou a guild.";

            // Adiciona historico a guild
            gData.History.Add(hData);

            // Insere novo historico no banco de dados
            Guild_DB.InsertHistory(pData.GuildID, pData.CharacterName, pData.CharacterName + " criou a guild.");

            // Adiciona a nova guild
            Guild.Guilds.Add(gData);

            // Envia guild para o jogador
            //WorldServerPacket.SendGuild(index);

            // Envia membros para o jogador
            //WorldServerPacket.SendMember(index);

            // Envia historico para o jogador
            // WorldServerPacket.SendHistory(index);
        }
    }
}
