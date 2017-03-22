using LoginServer.Common;
using Lidgren.Network;

namespace LoginServer.Network {
    public class LoginPacket {
        /// <summary>
        /// Envia o HexID para o cliente.
        /// </summary>
        /// <param name="hexID"></param>
        /// <param name="hexid"></param>
        public static void HexID(string hexID, string hexid) {
            var buffer = LoginNetwork.CreateMessage();
            buffer.Write((int)PacketList.LoginServer_Client_SendPlayerHexID);
            buffer.Write(hexid);
            LoginNetwork.SendDataTo(hexID, buffer, NetDeliveryMethod.ReliableOrdered);
        }

        /// <summary>
        /// Envia a alteração do 'GameState'.
        /// </summary>
        /// <param name="hexID"></param>
        /// <param name="value"></param>
        public static void GameState(string hexID, byte value) {
            var buffer = LoginNetwork.CreateMessage(5);
            buffer.Write((int)PacketList.ChangeGameState);
            buffer.Write(value);
            LoginNetwork.SendDataTo(hexID, buffer, NetDeliveryMethod.ReliableOrdered);
        }

        /// <summary>
        /// Envia mensagens (cabeçalho) que são ativadas no cliente.
        /// </summary>
        /// <param name="hexID"></param>
        /// <param name="value"></param>
        public static void Message(string hexID, int value) {
            var buffer = LoginNetwork.CreateMessage(4);
            buffer.Write(value);
            LoginNetwork.SendDataTo(hexID, buffer, NetDeliveryMethod.ReliableUnordered);
        }

        /// <summary>
        /// Envia a lista de servidores.
        /// </summary>
        /// <param name="hexID"></param>
        public static void ServerList(string hexID) {
            var buffer = LoginNetwork.CreateMessage();
            buffer.Write((int)PacketList.LoginServer_Client_ServerList);

            for (var n = 0; n < Settings.MAX_SERVER; n++) {
                buffer.Write(Settings.Server[n].Name);
                buffer.Write(Settings.Server[n].WorldServerIP);
                buffer.Write(Settings.Server[n].WorldServerPort);
                buffer.Write(Settings.Server[n].Region);
                buffer.Write(Settings.Server[n].Status);
            }

            LoginNetwork.SendDataTo(hexID, buffer, NetDeliveryMethod.ReliableOrdered);
        }
    }
}
