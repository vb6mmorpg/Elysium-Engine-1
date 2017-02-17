using Elysium_Diamond.DirectX;
using Elysium_Diamond.Common;
using Elysium_Diamond.GameLogic;
using Elysium_Diamond.Client;
using Lidgren.Network;

namespace Elysium_Diamond.Network {
    public class GameServerData {
        public static void GetPlayerOnMap(NetIncomingMessage data) {
            var pData = new EngineCharacter();
            pData.ID = data.ReadInt32();
            pData.Name = data.ReadString();
            pData.Sprite = data.ReadInt16();
            pData.Dir = (EngineCharacter.Direction)data.ReadInt16();
            pData.PositionX = data.ReadInt16() * 16;
            pData.PositionY = data.ReadInt16() * 16;
            pData.Enabled = false;

            //.Player.Add(pData);
        }

        public static void PlayerMapMove(NetIncomingMessage data) {
           // var pData = PlayerList.FindByID(data.ReadInt32());

           // pData.DirectionList.Enqueue(data.ReadInt16());
        }

        public static void PlayerExp(NetIncomingMessage data) {
            PlayerLocal.Data.Exp = data.ReadInt64();
        }

        public static void PlayerLocation(NetIncomingMessage data) {
            PlayerLocal.Data.WorldID = data.ReadInt32();
            PlayerLocal.Data.RegionID = data.ReadInt32();
            PlayerLocal.Data.Direction = data.ReadInt16();
            PlayerLocal.Data.PosX = data.ReadInt16();
            PlayerLocal.Data.PosY = data.ReadInt16();

            PlayerLocal.Character.PositionX = PlayerLocal.Data.PosX * 16;
            PlayerLocal.Character.PositionY = PlayerLocal.Data.PosY * 16;

            PlayerLocal.Character.Dir = (EngineCharacter.Direction)PlayerLocal.Data.Direction;
            PlayerLocal.Character.Coordinate = new SharpDX.Point(PlayerLocal.Data.PosX, PlayerLocal.Data.PosY);
        }

        public static void PlayerStats(NetIncomingMessage data) {
            PlayerLocal.Data.Strenght = data.ReadInt32();
            PlayerLocal.Data.Dexterity = data.ReadInt32();
            PlayerLocal.Data.Agility = data.ReadInt32();
            PlayerLocal.Data.Constitution = data.ReadInt32();
            PlayerLocal.Data.Intelligence = data.ReadInt32();
            PlayerLocal.Data.Wisdom = data.ReadInt32();
            PlayerLocal.Data.Will = data.ReadInt32();
            PlayerLocal.Data.Mind = data.ReadInt32();
            PlayerLocal.Data.Charisma = data.ReadInt32();
        }

        public static void PlayerVital(NetIncomingMessage data) {
            PlayerLocal.Data.MaxHP = data.ReadInt32();
            PlayerLocal.Data.HP = data.ReadInt32();
            PlayerLocal.Data.MaxMP = data.ReadInt32();
            PlayerLocal.Data.MP = data.ReadInt32();
            PlayerLocal.Data.MaxSP = data.ReadInt32();
            PlayerLocal.Data.SP = data.ReadInt32();
        }

        public static void PlayerVitalRegen(NetIncomingMessage data) {
            PlayerLocal.Data.RegenHP = data.ReadInt32();
            PlayerLocal.Data.RegenMP = data.ReadInt32();
            PlayerLocal.Data.RegenSP = data.ReadInt32();
        }

        public static void PlayerPhysicalStats(NetIncomingMessage data) {
            PlayerLocal.Data.Attack = data.ReadInt32();
            PlayerLocal.Data.Accuracy = data.ReadInt32();
            PlayerLocal.Data.Defense = data.ReadInt32();
            PlayerLocal.Data.Evasion = data.ReadInt32();
            PlayerLocal.Data.Block = data.ReadInt32();
            PlayerLocal.Data.Parry = data.ReadInt32();
            PlayerLocal.Data.CriticalRate = data.ReadInt32();
            PlayerLocal.Data.CriticalDamage = data.ReadInt32();
            PlayerLocal.Data.AttackSpeed = data.ReadInt32();
        }

        public static void PlayerMagicalStats(NetIncomingMessage data) {
            PlayerLocal.Data.MagicAttack = data.ReadInt32();
            PlayerLocal.Data.MagicAccuracy = data.ReadInt32();
            PlayerLocal.Data.MagicDefense = data.ReadInt32();
            PlayerLocal.Data.MagicResist = data.ReadInt32();
            PlayerLocal.Data.MagicCriticalRate = data.ReadInt32();
            PlayerLocal.Data.MagicCriticalDamage = data.ReadInt32();
            PlayerLocal.Data.CastSpeed = data.ReadInt32();
        }

        public static void PlayerUniqueStats(NetIncomingMessage data) {
            PlayerLocal.Data.Concentration = data.ReadInt32();
            PlayerLocal.Data.HealingPower = data.ReadInt32();
            PlayerLocal.Data.Enmity = data.ReadInt32();
            PlayerLocal.Data.DamageSuppression = data.ReadInt32();
        }

        public static void PlayerElementalStats(NetIncomingMessage data) {
            PlayerLocal.Data.AttributeEarth = data.ReadInt32();
            PlayerLocal.Data.AttributeFire = data.ReadInt32();
            PlayerLocal.Data.AttributeWater = data.ReadInt32();
            PlayerLocal.Data.AttributeWind = data.ReadInt32();
        }

        public static void PlayerResistStats(NetIncomingMessage data) {
            PlayerLocal.Data.ResistStun = data.ReadInt32();
            PlayerLocal.Data.ResistParalysis = data.ReadInt32();
            PlayerLocal.Data.ResistBlind = data.ReadInt32();
            PlayerLocal.Data.ResistSilence = data.ReadInt32();
            PlayerLocal.Data.ResistCriticalRate = data.ReadInt32();
            PlayerLocal.Data.ResistCriticalDamage = data.ReadInt32();
            PlayerLocal.Data.ResistMagicCriticalRate = data.ReadInt32();
            PlayerLocal.Data.ResistMagicCriticalDamage = data.ReadInt32();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public static void PlayerData(NetIncomingMessage data) {
            PlayerLocal.Data.CharacterName = data.ReadString();
            PlayerLocal.Data.Sprite = data.ReadInt16();
            PlayerLocal.Data.Level = data.ReadInt32();
            PlayerLocal.Data.Exp = data.ReadInt64();
            PlayerLocal.Data.WorldID = data.ReadInt32();
            PlayerLocal.Data.RegionID = data.ReadInt32();
            PlayerLocal.Data.Points = data.ReadInt32();

            PlayerLocal.Character.Name = PlayerLocal.Data.CharacterName;
            PlayerLocal.Character.GuildName = string.Empty;
            PlayerLocal.Character.Sprite = PlayerLocal.Data.Sprite;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
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
