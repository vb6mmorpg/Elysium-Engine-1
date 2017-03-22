using Elysium_Diamond.Common;

namespace Elysium_Diamond.Network {
    public static class LoginPacket {
        /// <summary>
        /// Envia o nome de usuário e senha
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public static void Login(string username, string password) {
            var buffer = NetworkSocket.CreateMessage();
            buffer.Write((int)PacketList.Client_LoginServer_Login);
            buffer.Write(Configuration.GAME_VERSION);
            buffer.Write(Configuration.ClientSerial);
            buffer.Write(username);
            buffer.Write(password);
            NetworkSocket.SendData(NetworkSocketEnum.LoginServer, buffer);
        }

        /// <summary>
        /// Volta para a tela de login
        /// </summary>
        public static void BackToLogin() {
            var buffer = NetworkSocket.CreateMessage();
            buffer.Write((int)PacketList.Client_LoginServer_BackToLogin);
            NetworkSocket.SendData(NetworkSocketEnum.LoginServer, buffer);
        }

        /// <summary>
        /// Envia o id do servidor para conexão
        /// </summary>
        /// <param name="index"></param>
        public static void ConnectWorldServer(int index) {
            var buffer = NetworkSocket.CreateMessage();
            buffer.Write((int)PacketList.Client_LoginServer_WorldServerConnect);
            buffer.Write(index);
            NetworkSocket.SendData(NetworkSocketEnum.LoginServer, buffer);
        }
    }
}
