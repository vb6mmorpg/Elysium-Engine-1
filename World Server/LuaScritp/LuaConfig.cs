using System;
using NLua;
using WorldServer.Common;
using WorldServer.Server;

namespace WorldServer.LuaScript {
    public static class LuaConfig {
        /// <summary>
        /// Inicializa lua e obtem as configurações.
        /// </summary>
        public static void InitializeConfig() {

            using (var lua = new Lua()) {
                //lua.LoadCLRPackage();

                lua.DoFile("Config.lua");

                GameSettings.CharacterCreation = (bool)lua["CharacterCreation"];
                GameSettings.CharacterDelete = (bool)lua["CharacterDelete"];
                GameSettings.CharacterDeleteMinLevel = Convert.ToInt32(lua["CharacterDeleteMinLevel"]);
                GameSettings.CharacterDeleteMaxLevel = Convert.ToInt32(lua["CharacterDeleteMaxLevel"]);

                //LuaFunction f = lua["function_name"] as LuaFunction;

                //if (f != null) f.Call(550);

                lua.RegisterFunction("Add", null, typeof(ProhibitedNames).GetMethod("Add"));
                lua.RegisterFunction("AddRange", null, typeof(ProhibitedNames).GetMethod("AddRange"));

                lua.DoFile("ProhibitedNames.lua");
            }
        }
    }
}
