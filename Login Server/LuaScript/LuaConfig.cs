using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLua;
using LoginServer.Server;

namespace LoginServer.LuaScript {
    public static class LuaConfig {
        /// <summary>
        /// Inicializa as configurações de script.
        /// </summary>
        public static void InitializeConfig() {
            using(var lua = new Lua()) {
                //lua.LoadCLRPackage();
                lua.RegisterFunction("AddChecksum", null, typeof(CheckSum).GetMethod("Add"));
                lua.RegisterFunction("AddCountry", null, typeof(GeoIp).GetMethod("AddCountry"));

                lua.DoFile("checksum.lua");
                lua.DoFile("geoip.lua");
            }       
        }
    }
}
