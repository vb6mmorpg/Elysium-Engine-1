using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using GameServer.Npcs;

namespace GameServer.MySQL {
    public static class Npc_DB {

        /// <summary>
        /// Carrega todos os NPC.
        /// </summary>
        public static void InitializeNpc() {
            var varQuery = "SELECT * FROM data_npc";
            var cmd = new MySqlCommand(varQuery, Common_DB.Connection);
            var reader = cmd.ExecuteReader();
            NpcData npc;

            while (reader.Read()) {
                npc = new NpcData();
                npc.ID = (int)reader["id"];
                npc.Sprite = (int)reader["sprite"];
                npc.Elit = (int)reader["elit_level"];
                npc.Type = (int)reader["type"];
                npc.Level = (int)reader["level"];
                npc.HP = npc.MaxHP = (int)reader["hp"];
                npc.RegenHP = (int)reader["regen_hp"];
                npc.Attack = (int)reader["attack"];
                npc.Accuracy = (int)reader["accuracy"];
                npc.Defense = (int)reader["defense"];
                npc.Evasion = (int)reader["evasion"];
                npc.Block = (int)reader["block"];
                npc.Parry = (int)reader["parry"];
                npc.Experience = (int)reader["experience"];
                npc.AttackSpeed = (int)reader["attack_speed"];
                npc.MagicAttack = (int)reader["magic_attack"];
                npc.MagicAccuracy = (int)reader["magic_accuracy"];
                npc.MagicDefense = (int)reader["magic_defense"];
                npc.MagicResist = (int)reader["magic_resist"];
                npc.AttributeFire = (int)reader["attribute_fire"];
                npc.AttributeWater = (int)reader["attribute_water"];
                npc.AttributeEarth = (int)reader["attribute_earth"];
                npc.AttributeWind = (int)reader["attribute_wind"];
                npc.ResistStun = (int)reader["resist_stun"];
                npc.ResistParalysis = (int)reader["resist_paralysis"];
                npc.ResistSilence = (int)reader["resist_silence"];
                npc.ResistBlind = (int)reader["resist_blind"];
                npc.ResistCriticalRate = (int)reader["resist_critical_rate"];
                npc.ResistCriticalDamage = (int)reader["resist_critical_damage"];
                npc.ResistMagicCriticalRate = (int)reader["resist_magic_critical_rate"];
                npc.ResistMagicCriticalDamage = (int)reader["resist_magic_critical_damage"];

                NpcManager.Npc.Add(npc);
            }

            reader.Close();
        }
    }
}
