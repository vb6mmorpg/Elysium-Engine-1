using Lidgren.Network;
using WorldServer.MySQL;
using WorldServer.Common;
using WorldServer.GameGuild;
using WorldServer.Server;

namespace WorldServer.Network {
    public class WorldServerData {
        public static void HandleData(NetConnection connection, NetIncomingMessage data) {
            // Packet Header //
            var MsgType = data.ReadInt32();

            // Check Packet Number
            if (MsgType < 0) { return; }

             switch (MsgType) {
                case (int)PacketList.LoginServer_WorldServer_SendPlayerHexID: Authentication.AddHexID(data); break;
                case (int)PacketList.Client_WorldServer_SendPlayerHexID: Authentication.ReceivedHexID(connection, data.ReadString()); break;
                case (int)PacketList.Client_WorldServer_DeleteCharacter: DeleteCharacter(connection, data.ReadByte()); break;
                case (int)PacketList.Client_WorldServer_CreateCharacter: CreateCharacter(connection, data); break;
                case (int)PacketList.Client_WorldServer_EnterInGame: StartGame(connection, data.ReadByte()); break;
                case (int)PacketList.LoginServer_WorldServer_IsPlayerConnected: IsPlayerConnected(connection, data.ReadString()); break;
                case (int)PacketList.LoginServer_WorldServer_DisconnectPlayer: PlayerDisconnect(data.ReadString()); break;
            }
        }

        public static void CreateCharacter(NetConnection connection, NetIncomingMessage data) {
            // Se a crição de personagem não estiver ativa, envia mensagem de erro
            if (!Settings.CharacterCreation) {
                WorldServerPacket.Message(connection, (int)PacketList.WorldServer_Client_CharacterCreationDisabled);
                return;
            }

            //nome do personagem 
            var charName = data.ReadString();
            //se encontrar nome nao permitido, envia mensagem de erro
            if (!ProhibitedNames.Compare(charName)) {
                WorldServerPacket.Message(connection, (int)PacketList.WorldServer_Client_CharNameInUse);
                return;
            }
            
            // Se o nome existir no banco de dados, envia mensagem de erro
            if (Character_DB.Exist(charName)) {
                WorldServerPacket.Message(connection, (int)PacketList.WorldServer_Client_CharNameInUse);
                return; 
            }

            //encontra o usuário para adicionar as informações
            var pData = Authentication.FindByConnection(connection);

            var slot = data.ReadByte();
            var classe = data.ReadByte();
            var gender = data.ReadByte();
            var sprite = data.ReadInt32();

            // Se não estiver dentro da sequencia correta, envia mensagem de erro
            if (slot >= 5) {
                WorldServerPacket.Message(connection, (int)PacketList.Error);
                return;
            }

            // Insere o personagem no banco de dados
            Character_DB.InsertNewCharacter(pData.HexID, gender, classe, charName, sprite, slot);
            // Insere os items iniciais
            // Character_DB.InsertInitialItems(charName, classe);

            // Carrega os personagens
            for (var n = 0; n < Constant.MAX_CHAR; n++) {
                pData.Character[n] = new Character() { Name = string.Empty } ;

                Character_DB.PreLoad(pData, n);
            }

            // Envia o PreLoad
            WorldServerPacket.PreLoad(pData);

            //game state 3 = seleção de personagem 
            WorldServerPacket.GameState(pData.HexID, 3);
        }

        /// <summary>
        /// Deleta um personagem pelo nome e slot.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="slot"></param>
        public static void DeleteCharacter(NetConnection connection, int slot) {
            // Se a exclusão de personagem não estiver ativa, envia mensagem de erro
            if (!Settings.CharacterDelete) {
                WorldServerPacket.Message(connection, (int)PacketList.WorldServer_Client_CharacterDeleteDisabled);
                return;
            }

            var pData = Authentication.FindByConnection(connection);
            var level = Character_DB.GetLevel(pData.AccountID, slot);

            // Se o ocorrer algum erro, envia mensagem de erro
            // level -1, não encontrou dados do personagem
            if (level <= 0) {
                WorldServerPacket.Message(connection, (int)PacketList.Error);
                return;
            }       

            // Se o level não estiver entre a faixa, envia mensagem de erro
            // não pode ser deletado
            if (level < Settings.CharacterDeleteMinLevel & level > Settings.CharacterDeleteMaxLevel) {
                WorldServerPacket.Message(connection, (int)PacketList.WorldServer_Client_InvalidLevelToDelete);
                return;
            }

            //Pega o nome do personagem e salva no log
            LogConfig.WriteLog($"Character Deleted: From: {pData.AccountID} {pData.Account} Char: {Character_DB.GetName(pData.AccountID, slot)}", System.Drawing.Color.Magenta);

            // Deleta o personagem
            Character_DB.Delete(pData.AccountID, slot);

            for (var n = 0; n < Constant.MAX_CHAR; n++) {
                pData.Character[n] = new Character() { Name = string.Empty };

                //Carrega os personagens (preload)
                Character_DB.PreLoad(pData, n);
            }

            // Envia o PreLoad
            // pré carregamento do personagem, apenas informações básicas sprite, level, nome e classe (exibição na seleção de personagem).
            WorldServerPacket.PreLoad(pData);
            WorldServerPacket.Message(connection, (int)PacketList.WorldServer_Client_CharacterDeleted);
        }

        public static void StartGame(NetConnection connection, byte slot) {
            var pData = Authentication.FindByConnection(connection);

            LogConfig.WriteLog($"GameServer Login Attempt: {pData.Account} {pData.IP}", System.Drawing.Color.Black); 
            
            // limpa a memoria temporaria
            pData.Character = null;

            WorldServerPacket.SendGameServerData(connection, pData.HexID);
   
            // Carrega os dados do personagem
            Character_DB.Load(pData, slot);

            if (pData.GuildID > 0) Guild.UpdatePlayerStatus(pData.GuildID, pData.CharacterID, true);
            if (pData.GuildID > 0) WorldServerPacket.SendGuildInfo(pData);

            //Envia os dados de login para o game server numero 0
            GameServerPacket.Login(pData.HexID, 0);
        }

        /// <summary>
        /// Verifica se o usuário já está conectado.
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public static void IsPlayerConnected(NetConnection connection, string username) {
            WorldServerPacket.SendConnectedResult(connection, Authentication.IsConnected(username), username); 
        }

        /// <summary>
        /// Disconenct
        /// </summary>
        /// <param name="username"></param>
        public static void PlayerDisconnect(string username) {
            if (!Authentication.IsConnected(username)) { return; }
            
            var pData = Authentication.FindByAccount(username);
           
          //  LoginServerPacket.Message(Authentication.FindByAccount(pData.Username).HexID, (int)PacketList.Disconnect);
          
            pData.Connection.Disconnect("-");

            LogConfig.WriteLog($"Disconnected by login server: {username}", System.Drawing.Color.Black);

            ///temporario, precisa salvar o jogador antes
        }
    }
}

