using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lidgren.Network;
using Elysium_Diamond.DirectX;
using Elysium_Diamond.Resource;
using Elysium_Diamond.Common;

namespace Elysium_Diamond.Network
{
    public static class GeneralServerData
    {
        public static void PlayerData(NetIncomingMessage data) {
            CurrentPlayerData.Name = data.ReadString();
            CurrentPlayerData.Guild = data.ReadString();
            CurrentPlayerData.Sprite = data.ReadInt32();
            CurrentPlayerData.Level = data.ReadInt32();
            CurrentPlayerData.Exp = data.ReadInt64();
            EngineCore.Personagem.Dir = (EngineCharacter.Direction)data.ReadInt32();
            CurrentPlayerData.PosX = data.ReadInt16();
            CurrentPlayerData.PosY = data.ReadInt16();
        
            EngineCore.Personagem.Name = CurrentPlayerData.Name;
            EngineCore.Personagem.GuildName = CurrentPlayerData.Guild;
            EngineCore.Personagem.Sprite = CurrentPlayerData.Sprite;
            EngineCore.Personagem.PositionX = CurrentPlayerData.PosX * 16;
            EngineCore.Personagem.PositionY = CurrentPlayerData.PosY * 16;

            System.Windows.Forms.MessageBox.Show(EngineCore.Personagem.PositionX + "");

            EngineCore.Personagem.Coordinate = new SharpDX.Point(CurrentPlayerData.PosX, CurrentPlayerData.PosY);

            EngineCore.EngineBar.Percentage = Convert.ToInt32(CurrentPlayerData.Exp * 100 / Experience.Data[CurrentPlayerData.Level + 1]);
        }

        public static void ReceiveNpc(NetIncomingMessage data) {
            var lenght = data.ReadInt32();

            for (var n = 0; n < lenght; n++) {
                Maps.npc[n] = new EngineNpc();
                Maps.npc[n].Sprite = data.ReadInt32();
                Maps.npc[n].Level = data.ReadInt32();
                Maps.npc[n].HP = data.ReadInt32();
                Maps.npc[n].PositionX = data.ReadInt32();
                Maps.npc[n].PositionY = data.ReadInt32();
                Maps.npc[n].Name = "Saci " + n;
                Maps.npc[n].Dir = EngineNpc.Direction.Down;
            }
        }
    }
}
