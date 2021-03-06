﻿using Lidgren.Network;
using LoginServer.Common;

namespace LoginServer.Server {
    public class PlayerData {
        /// <summary>
        /// 'Socket' de conexão.
        /// </summary>
        public NetConnection Connection { get; set; } = null;

        /// <summary>
        /// IP de usuário.
        /// </summary>
        public string IP { get; set; }

        /// <summary>
        /// ID de conexão em Hexadecimal.
        /// </summary>
        public string HexID { get; set; }

        /// <summary>
        /// ID de usuário.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Nome de usuário.
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// Nome de usuário temporario.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Senha de usuário.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Quantidade de tentativas de login.
        /// </summary>
        public byte LoginAttempt { get; set; }

        /// <summary>
        /// ID de idioma.
        /// </summary>
        public byte LanguageID { get; set; }

        /// <summary>
        /// Nível de acesso ao sistema.
        /// </summary>
        public short AccessLevel { get; set; }

        /// <summary>
        /// Quantidade de cash.
        /// </summary>
        public int Cash { get; set; }

        /// <summary>
        /// Senha de personagens.
        /// </summary>
        public string Pin { get; set; }
      
        /// <summary>
        /// Pacote de serviços de usuário.
        /// </summary>
        public PlayerService Service { get; set; }

        /// <summary>
        /// Resultado de busca em cada world server.
        /// </summary>
        public bool[] WorldResult { get; set; } = new bool[Settings.MAX_SERVER];

        /// <summary>
        /// Quantidade de resultados.
        /// </summary>
        public byte WorldResultCount { get; set; } 

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="hexID"></param>
        /// <param name="ip"></param>
        public PlayerData(NetConnection connection, string hexID, string ip) {
            Connection = connection;
            HexID = hexID;
            IP = ip;
            Account = string.Empty;
            Password = string.Empty;
            Username = string.Empty;
            Service = new PlayerService();
        }

        /// <summary>
        /// Destrutor
        /// </summary>
        ~PlayerData() {
            Service.Clear();
            Service = null;
            Connection.Disconnect("");
            Connection = null;
        }

        /// <summary>
        /// Limpa os dados para permitir um novo login.
        /// </summary>  
        public void Clear() {
            //não deve limpar o hexid, pois ainda é necessário na conexão.
            ID = 0;
            LoginAttempt = 0;
            Password = string.Empty;
            Account = string.Empty;
            Username = string.Empty;
            IP = string.Empty;
            Service.Clear();
        }
    }
}
