using Elysium_Diamond.Common;

namespace Elysium_Diamond.Network {
    public static class LoginServerPacket {
        /// <summary>
        /// Envia o nome de usuário e senha
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public static void Login(string username, string password) {
            var buffer = LoginServerNetwork.Instance.TCPClient.CreateMessage();
            buffer.Write((int)PacketList.Client_LoginServer_Login);
            buffer.Write(Settings.Version);
            buffer.Write(username);
            buffer.Write(password);
            LoginServerNetwork.Instance.SendData(buffer);
        }

        /// <summary>
        /// Volta para a tela de login
        /// </summary>
        public static void BackToLogin() {
            var buffer = LoginServerNetwork.Instance.TCPClient.CreateMessage();
            buffer.Write((int)PacketList.Client_LoginServer_BackToLogin);
            LoginServerNetwork.Instance.SendData(buffer);
        }

        /// <summary>
        /// Envia o id do servidor para conexão
        /// </summary>
        /// <param name="index"></param>
        public static void ConnectWorldServer(int index) {
            var buffer = LoginServerNetwork.Instance.TCPClient.CreateMessage();
            buffer.Write((int)PacketList.Client_LoginServer_WorldServerConnect);
            buffer.Write(index);
            LoginServerNetwork.Instance.SendData(buffer);
        }
    }
}
