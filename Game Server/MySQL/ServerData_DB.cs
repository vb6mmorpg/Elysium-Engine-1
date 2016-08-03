using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace GameServer.MySQL {
    public static class ServerData_DB {
        public static List<long> Experience { get; set; }

        public static void LoadExperience() {
            var varQUery = "SELECT level, exp_to_reach_lvl FROM data_exp";
            var cmd = new MySqlCommand(varQUery, Common_DB.Connection);
            var reader = cmd.ExecuteReader();

            Experience = new List<long>();
            Experience.Add(0);

            while (reader.Read()) {
                Experience.Add(Convert.ToInt64(reader["exp_to_reach_lvl"]));
            }

            reader.Close();
        }
        


    }
}
