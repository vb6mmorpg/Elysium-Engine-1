using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLua;
using WorldServer.Common;

namespace WorldServer.LUA {
    public static class LuaConfig {
        private static Lua lua;

        /// <summary>
        /// Inicializa lua e obtem as configurações.
        /// </summary>
        public static void InitializeConfig() {
            lua = new Lua();
            lua.DoFile(@"Script\Character.lua");

            Settings.CharacterCreation = (bool)lua["CharacterCreation"];
            Settings.CharacterDelete = (bool)lua["CharacterDelete"];
            Settings.CharacterDeleteMinLevel = Convert.ToInt32(lua["CharacterDeleteMinLevel"]);
            Settings.CharacterDeleteMaxLevel = Convert.ToInt32(lua["CharacterDeleteMaxLevel"]);

            LuaFunction f = lua["function_name"] as LuaFunction;

            if (f != null) f.Call(550);

            Settings.CharacterDeleteMaxLevel = Convert.ToInt32(lua["CharacterDeleteMaxLevel"]);
            //  System.Windows.Forms.MessageBox.Show(Settings.CharacterDeleteMaxLevel + "");
            //      lua.RegisterFunction("Mensagem", this, this.GetType().GetMethod("Mensagem"));
        }

    }
}
