using Lidgren.Network;
using WorldServer.MySQL;
using WorldServer.Common;
using WorldServer.Server;

namespace WorldServer.Network {
    public class WorldData {
        public static void HandleData(NetConnection connection, NetIncomingMessage msg) {
            if (msg.LengthBytes < 4) { return; }

            //packet Header 
            var msgType = msg.ReadInt32();

            if (msgType < 0) { return; }

             switch (msgType) {
                case (int)PacketList.LoginServer_WorldServer_SendPlayerHexID: Authentication.AddHexID(msg); break;
                case (int)PacketList.Client_WorldServer_SendPlayerHexID: Authentication.ReceivedHexID(connection, msg.ReadString()); break;
                case (int)PacketList.Client_WorldServer_DeleteCharacter: DeleteCharacter(connection, msg.ReadByte()); break;
                case (int)PacketList.Client_WorldServer_CreateCharacter: CreateCharacter(connection, msg); break;
                case (int)PacketList.Client_WorldServer_RequestPreLoad: RequestPreLoad(connection); break;
                case (int)PacketList.Client_WorldServer_EnterInGame: StartGame(connection, msg.ReadByte()); break;
                case (int)PacketList.LoginServer_WorldServer_IsPlayerConnected: IsPlayerConnected(connection, msg.ReadString()); break;
                case (int)PacketList.LoginServer_WorldServer_DisconnectPlayer: PlayerDisconnect(msg.ReadString()); break;
            }
        }

        public static void CreateCharacter(NetConnection connection, NetIncomingMessage data) {
            // Se a crição de personagem não estiver ativa, envia mensagem de erro
            if (!GameSettings.CharacterCreation) {
                WorldPacket.Message(connection, (int)PacketList.WorldServer_Client_CharacterCreationDisabled);
                return;
            }
                   
            //nome do personagem 
            var charactername = data.ReadString();
            //se encontrar nome nao permitido, envia mensagem de erro
            if (!ProhibitedNames.Compare(charactername)) {
                WorldPacket.Message(connection, (int)PacketList.WorldServer_Client_CharNameInUse);
                return;
            }
            
            // Se o nome existir no banco de dados, envia mensagem de erro
            if (Character_DB.Exist(charactername)) {
                WorldPacket.Message(connection, (int)PacketList.WorldServer_Client_CharNameInUse);
                return; 
            }

            //encontra o usuário para adicionar as informações
            var pData = Authentication.FindByConnection(connection);

            var slot = data.ReadByte();
            var classe = data.ReadInt32();
            var gender = data.ReadByte();
            var sprite = data.ReadInt32();

            // Se não estiver dentro da sequencia correta, envia mensagem de erro
            if (slot >= 5) {
                WorldPacket.Message(connection, (int)PacketList.Error);
                return;
            }

            // Insere o personagem no banco de dados
            Character_DB.InsertNewCharacter(pData.HexID, gender, classe, charactername, sprite, slot);
            // Insere os items iniciais
            //Character_DB.InsertInitialItems(charactername, classe);

            // Carrega os personagens
            Character_DB.PreLoad(pData);

            // Envia o PreLoad
            WorldPacket.PreLoad(pData);

            //game state 3 = seleção de personagem 
            WorldPacket.GameState(pData.HexID, 3);
        }

        /// <summary>
        /// Envia o pré carregamento dos personagens.
        /// </summary>
        /// <param name="connection"></param>
        public static void RequestPreLoad(NetConnection connection) {
            var pData = Authentication.FindByConnection(connection);

            pData.Character = new Character[Settings.MAX_CHAR];

            //Carrega os personagens (preload)
            Character_DB.PreLoad(pData);

            //Envia o preload
            WorldPacket.PreLoad(pData);
        }

        /// <summary>
        /// Deleta um personagem pelo nome e slot.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="slot"></param>
        public static void DeleteCharacter(NetConnection connection, int slot) {
            // Se a exclusão de personagem não estiver ativa, envia mensagem de erro
            if (!GameSettings.CharacterDelete) {
                WorldPacket.Message(connection, (int)PacketList.WorldServer_Client_CharacterDeleteDisabled);
                return;
            }

            var pData = Authentication.FindByConnection(connection);
            var level = Character_DB.GetLevel(pData.AccountID, slot);

            // Se o ocorrer algum erro, envia mensagem de erro
            // level -1, não encontrou dados do personagem
            if (level <= 0) {
                WorldPacket.Message(connection, (int)PacketList.Error);
                return;
            }       

            // Se o level não estiver entre a faixa, envia mensagem de erro
            // não pode ser deletado
            if (level < GameSettings.CharacterDeleteMinLevel & level > GameSettings.CharacterDeleteMaxLevel) {
                WorldPacket.Message(connection, (int)PacketList.WorldServer_Client_InvalidLevelToDelete);
                return;
            }

            //Pega o nome do personagem e salva no log
            FileLog.WriteLog($"Character Deleted: From: {pData.AccountID} {pData.Account} Char: {Character_DB.GetName(pData.AccountID, slot)}", System.Drawing.Color.Magenta);

            // Deleta o personagem
            if (!Character_DB.Delete(pData.AccountID, slot)) {
                WorldPacket.Message(connection, (int)PacketList.Error);
                return;
            }

            //Carrega os personagens (preload)
            Character_DB.PreLoad(pData);

            // Envia o PreLoad
            // pré carregamento do personagem, apenas informações básicas sprite, level, nome e classe (exibição na seleção de personagem).
            WorldPacket.PreLoad(pData);
            WorldPacket.Message(connection, (int)PacketList.WorldServer_Client_CharacterDeleted);
        }

        /// <summary>
        /// Inicia a operação de transferencia de dados para o gameserver.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="slot"></param>
        public static void StartGame(NetConnection connection, byte slot) {
            var pData = Authentication.FindByConnection(connection);

            FileLog.WriteLog($"GameServer Login Attempt: {pData.Account} {pData.IP}", System.Drawing.Color.Black); 
            
            // limpa a memoria temporaria
            pData.Character = null;

            WorldPacket.GameServerData(connection, pData.HexID);
   
            // Carrega os dados do personagem
            Character_DB.Load(pData, slot);

        //   if (pData.GuildID > 0) Guild.UpdatePlayerStatus(pData.GuildID, pData.CharacterID, true);
       //     if (pData.GuildID > 0) WorldServerPacket.SendGuildInfo(pData);

            //Envia os dados de login para o game server numero 0
            GamePacket.Login(pData.HexID, 0);
        }

        /// <summary>
        /// Verifica se o usuário já está conectado.
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public static void IsPlayerConnected(NetConnection connection, string username) {
            WorldPacket.ConnectedResult(connection, Authentication.IsConnected(username), username); 
        }

        /// <summary>
        /// Desconecta o usuário antigo para o novo entrar.
        /// </summary>
        /// <param name="username"></param>
        public static void PlayerDisconnect(string username) {
            if (!Authentication.IsConnected(username)) { return; }
            
            var pData = Authentication.FindByAccount(username);

            WorldPacket.Message(pData?.HexID, (int)PacketList.Disconnect);
          
            pData?.Connection.Disconnect("");

            FileLog.WriteLog($"Disconnected by login server: {username}", System.Drawing.Color.Black);

            ///temporario, precisa salvar o jogador antes
        }
    }
}

