using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace Account_Editor.MySQL
{
    public class Characters_DB
    {
        /// <summary>
        /// Estrutura dos Personagens
        /// </summary>
        public int ID; // Não modificavel
        public int Account_ID; // Não modificavel
        public int Class_ID;
        public int Guild_ID;
        public int Slot; // Não modificavel
        public string Name;
        public int Gender;
        public int Sprite;
        public int HP;
        public int MP;
        public int SP;
        public int Level;
        public long EXP;
        public int Strenght;
        public int Dexterity;
        public int Agility;
        public int Vitality;
        public int Intelligence;
        public int Mind;
        public int Points;

        // Localização
        public int World, Region, X, Y;

        /// <summary>
        /// Carregar Personagem
        /// </summary>
        /// <param name="pAccount">Id da Conta do Personagem</param>
        /// <param name="pSlot">Numero do Slot do Jogador</param>
        /// <returns></returns>
        public bool Load(int pAccount, int pSlot)
        {
            // Checar se está conectado com o MySQL
            if (Program.EditForm.GS_Database.mysql_connection == null) return false;

            // Procurar dados apartir do pAccount - Id da conta/pSlot - Slot do personagem
            string varQuery = "SELECT * FROM characters WHERE account_id='" + pAccount + "' and char_slot='" + pSlot + "'";
            MySqlCommand cmd = new MySqlCommand(varQuery, Program.EditForm.GS_Database.mysql_connection);
            MySqlDataReader reader = cmd.ExecuteReader(); // Abrir Conexão

            // Checar se a conta realmente existe
            if (reader.Read() == false)
            {
                reader.Close();
                return false;
            }

            ID = (int)reader["id"]; // Id na Database
            Account_ID = (int)reader["account_id"]; // Id da conta
            Class_ID = (int)reader["class_id"]; // Id da classe
            Guild_ID = (int)reader["guild_id"]; // Id da guild
            Slot = (int)reader["char_slot"]; // Slot do Personagem
            Name = (string)reader["name"]; // Nome do Personagem
            Gender = Convert.ToByte(reader["gender"]); // Genêro do Personagem
            Sprite = (int)reader["sprite"]; // Gráfico do Personagem
            HP = (int)reader["hp"]; // HP-Vida do Personagem
            MP = (int)reader["mp"]; // MP-Magia do Personagem
            SP = (int)reader["sp"]; // SP-Super Poder do Personagem
            Level = (int)reader["level"]; // Level do Personagem
            EXP = (long)reader["exp"]; // Experiêcia do Personagem

            Strenght = (int)reader["strenght"]; // Força do personagem
            Dexterity = (int)reader["dexterity"]; // Dextreza do personagem
            Agility = (int)reader["agility"]; // Agilidade do personagem
            Vitality = (int)reader["vitality"]; // Vitalidade do personagem
            Intelligence = (int)reader["intelligence"]; // Inteligencia do personagem
            Mind = (int)reader["mind"]; // Mind do personagem
            Points = (int)reader["statpoints"]; // Pontos do personagem

            World = (int)reader["world_id"]; // Mundo em que o personagem está
            Region = (int)reader["region_id"]; // Região do mundo em que o personagem está
            X = (int)reader["posx"]; // Posição do personagem no eixo X
            Y = (int)reader["posy"]; // Posição do personagem no eixo Y

            reader.Close();
            return true;
        }

        /// <summary>
        /// Carregar dados do DB
        /// <param name="pID">Id da conta</param>
        /// </summary>
        public bool Save()
        {
            // Checar se está conectado com o MySQL
            if (Program.EditForm.GS_Database.mysql_connection == null) return false;

            try
            {
                // Definir quais dados serão salvos e seus novos valores.
                StringBuilder varQuery = new StringBuilder();
                varQuery.Append("UPDATE characters SET " +
                    "account_id='" + Account_ID + "', " +
                    "class_id='" + Class_ID + "', " +
                    "guild_id='" + Guild_ID + "', " +
                    "name='" + Name + "', " +
                    "gender='" + Gender + "', " +
                    "sprite='" + Sprite + "', " +
                    "hp='" + HP + "', " +
                    "mp='" + MP + "', " +
                    "sp='" + SP + "', " +
                    "level='" + Level + "', " +
                    "exp='" + EXP + "', " +
                    "strenght='" + Strenght + "', " +
                    "dexterity='" + Dexterity + "', " +
                    "agility='" + Agility + "', " +
                    "vitality='" + Vitality + "', " +
                    "intelligence='" + Intelligence + "', " +
                    "mind='" + Mind + "', " +
                    "statpoints='" + Points + "', " +
                    "world_id='" + World + "', " +
                    "region_id='" + Region + "', " +
                    "posx='" + X + "', " +
                    "posy='" + Y + "' " +
                    "WHERE id='" + ID + "'"); // Id em que os dados serão salvos

                // Executar comando para salvar
                MySqlCommand cmd = new MySqlCommand(varQuery.ToString(), Program.EditForm.GS_Database.mysql_connection);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
