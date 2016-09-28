using Elysium_Diamond.Common;
using Elysium_Diamond.DirectX;
using Elysium_Diamond.GameWindow;

namespace Elysium_Diamond.Network {
    public static class CommonMessage {
        public static void ShowMessage(PacketList value, int data = 0) {
            switch (value) {
                case PacketList.Disconnect:
                    Settings.Disconnected = true;
                    EngineMessageBox.Enabled = true;
                    EngineMessageBox.Show("Desconectado");     
                    if (LoginServerNetwork.Instance.TCPClient != null)  LoginServerNetwork.Instance.TCPClient.Disconnect("dc"); 
                    if (WorldServerNetwork.Instance.TCPClient != null)  WorldServerNetwork.Instance.TCPClient.Disconnect("dc"); 
                    if (GameServerNetwork.Instance.TCPClient != null) GameServerNetwork.Instance.TCPClient.Disconnect("dc");
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
            }
        }

        public static void ChangeGameState(byte value) {
            EngineCore.GameState = value;
        }
    }
}
