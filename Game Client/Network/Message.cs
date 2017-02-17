using Elysium_Diamond.Common;
using Elysium_Diamond.DirectX;

namespace Elysium_Diamond.Network {
    public class Message {

        public static void Show(PacketList packet, int value = 0) {
            switch (packet) {
                case PacketList.Disconnect:
                    Configuration.Disconnected = true;
                    EngineMessageBox.Enabled = true;
                    EngineMessageBox.Show("Desconectado");

                    NetworkSocket.Disconnect(NetworkSocketEnum.LoginServer);
                    NetworkSocket.Disconnect(NetworkSocketEnum.WorldServer);
                    NetworkSocket.Disconnect(NetworkSocketEnum.GameServer);
                    break;

                case PacketList.LoginServer_Client_AccountDisabled:
                    EngineMessageBox.Enabled = true;
                    EngineMessageBox.Show("Email não verificado");
                    break;

                case PacketList.LoginServer_Client_InvalidNamePass:
                    EngineMessageBox.Enabled = true;
                    EngineMessageBox.Show("Nome ou senha incorretos");
                    break;

                case PacketList.LoginServer_Client_Maintenance:
                    EngineMessageBox.Enabled = true;
                    EngineMessageBox.Show("Servidor em manutenção");
                    break;

                case PacketList.Error:
                    EngineMessageBox.Enabled = true;
                    EngineMessageBox.Show("Ocorreu um erro");
                    break;

                case PacketList.LoginServer_Client_AccountBanned:
                    EngineMessageBox.Enabled = true;
                    EngineMessageBox.Show("Este usuário está banido");
                    break;

                case PacketList.LoginServer_Client_AlreadyLoggedIn:
                    EngineMessageBox.Enabled = true;
                    EngineMessageBox.Show("Este usuário já está conectado");
                    break;

                case PacketList.AcceptedConnection:
                    EngineMessageBox.Enabled = true;
                    EngineMessageBox.Visible = false;
                    break;

                case PacketList.CantConnectNow:
                    EngineMessageBox.Enabled = true;
                    EngineMessageBox.Show("Você não pode conectar-se no momento");
                    break;

                case PacketList.InvalidVersion:
                    EngineMessageBox.Enabled = true;
                    EngineMessageBox.Show("Versão invalida");
                    break;

                case PacketList.WorldServer_Client_CharacterDeleted:
                    EngineMessageBox.Enabled = true;
                    EngineMessageBox.Show("Personagem deletado");
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
    }

}

