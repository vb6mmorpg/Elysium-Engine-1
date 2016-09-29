using System;
using NLua;
using WorldServer.Common;
using WorldServer.Server;

namespace WorldServer.LuaScript {
    public static class LuaConfig {
        private static Lua lua;

        /// <summary>
        /// Inicializa lua e obtem as configurações.
        /// </summary>
        public static void InitializeConfig() {
            lua = new Lua();
            //lua.LoadCLRPackage();

            lua.DoFile("Config.lua");

            Settings.CharacterCreation = (bool)lua["CharacterCreation"];
            Settings.CharacterDelete = (bool)lua["CharacterDelete"];
            Settings.CharacterDeleteMinLevel = Convert.ToInt32(lua["CharacterDeleteMinLevel"]);
            Settings.CharacterDeleteMaxLevel = Convert.ToInt32(lua["CharacterDeleteMaxLevel"]);

            //LuaFunction f = lua["function_name"] as LuaFunction;

            //if (f != null) f.Call(550);

            lua.RegisterFunction("Add", null, typeof(ProhibitedNames).GetMethod("Add"));
            lua.RegisterFunction("AddRange", null, typeof(ProhibitedNames).GetMethod("AddRange"));
  
            lua.DoFile("ProhibitedNames.lua");


        }

    }
}
