using System;
using MySql.Data.MySqlClient;
using GameServer.Server;

namespace GameServer.MySQL {
    public static class ServerData_DB {

        public static void LoadExperience() {
            var varQUery = "SELECT level, exp_to_reach_lvl FROM data_exp";
            var cmd = new MySqlCommand(varQUery, Common_DB.Connection);
            var reader = cmd.ExecuteReader();
            var counter = 1;
 
            while (reader.Read()) {
                Experience.Level.Add(counter, Convert.ToInt64(reader["exp_to_reach_lvl"]));
                counter++;
            }

            Experience.Level.LevelMax = counter - 1;

            reader.Close();
        } 
    }
}
