using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLua;
using LoginServer.Server;

namespace LoginServer.LuaScript {
    public static class LuaConfig {
        static Lua lua;

        /// <summary>
        /// Inicializa as configurações de script.
        /// </summary>
        public static void InitializeConfig() {
            lua = new Lua();
            //lua.LoadCLRPackage();
            lua.RegisterFunction("AddChecksum", null, typeof(CheckSum).GetMethod("Add"));

            lua.DoFile("checksum.lua");

            CheckSum.Enabled = (bool)lua["enabled"];

            lua.Dispose();
            lua = null;           
        }

    }
}
