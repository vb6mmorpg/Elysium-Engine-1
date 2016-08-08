using GameServer.Classe;
using GameServer.Server;

namespace GameServer.GameLogic.Character {
    public static class CharacterLogic {

        public static void UpdateCharacterStats(int playerID) {
            var pData = Authentication.FindByAccountID(playerID);
            var classID = pData.ClasseID;

            //items stat value
            int[] value = new int[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            // before update, check all item stats

            pData.MaxHP = Classes.GetStat(Stats.MaxHP, pData, value);
            pData.MaxMP = Classes.GetStat(Stats.MaxMP, pData, value);
            pData.MaxSP = Classes.GetStat(Stats.MaxSP, pData, value);
            pData.RegenHP = Classes.GetStat(Stats.RegenHP, pData, value);
            pData.RegenMP = Classes.GetStat(Stats.RegenMP, pData, value);
            pData.RegenSP = Classes.GetStat(Stats.RegenSP, pData, value);
            pData.DamageSuppression = Classes.GetStat(Stats.DamageSuppression, pData, value);
            pData.Enmity = Classes.GetStat(Stats.Enmity, pData, value);
            pData.AdditionalDamage = Classes.GetStat(Stats.AdditionalDamage, pData, value);
            pData.HealingPower = Classes.GetStat(Stats.HealingPower, pData, value);
            pData.Concentration = Classes.GetStat(Stats.Concentration, pData, value);
            pData.AttackSpeed = Classes.GetStat(Stats.AttackSpeed, pData, value);
            pData.CastSpeed = Classes.GetStat(Stats.CastSpeed, pData, value);
            pData.Attack = Classes.GetStat(Stats.Attack, pData, value);
            pData.Accuracy = Classes.GetStat(Stats.Accuracy, pData, value);
            pData.Defense = Classes.GetStat(Stats.Defense, pData, value);
            pData.Evasion = Classes.GetStat(Stats.Evasion, pData, value);
            pData.Block = Classes.GetStat(Stats.Block, pData, value);
            pData.Parry = Classes.GetStat(Stats.Parry, pData, value);
            pData.CriticalRate = Classes.GetStat(Stats.CriticalRate, pData, value);
            pData.CriticalDamage = Classes.GetStat(Stats.CriticalDamage, pData, value);
            pData.MagicAttack = Classes.GetStat(Stats.MagicAttack, pData, value);
            pData.MagicAccuracy = Classes.GetStat(Stats.MagicAccuracy, pData, value);
            pData.MagicDefense = Classes.GetStat(Stats.MagicDefense, pData, value);
            pData.MagicResist = Classes.GetStat(Stats.MagicResist, pData, value);
            pData.MagicCriticalRate = Classes.GetStat(Stats.MagicCriticalRate, pData, value);
            pData.MagicCriticalDamage = Classes.GetStat(Stats.MagicCriticalDamage, pData, value);
            pData.AttributeFire = Classes.GetStat(Stats.AttributeFire, pData, value);
            pData.AttributeWater = Classes.GetStat(Stats.AttributeWater, pData, value);
            pData.AttributeEarth = Classes.GetStat(Stats.AttributeEarth, pData, value);
            pData.AttributeWind = Classes.GetStat(Stats.AttributeWind, pData, value);
            pData.MagicCriticalRate = Classes.GetStat(Stats.MagicCriticalRate, pData, value);
            pData.MagicCriticalDamage = Classes.GetStat(Stats.MagicCriticalDamage, pData, value);
            pData.ResistStun = Classes.GetStat(Stats.ResistStun, pData, value);
            pData.ResistParalysis = Classes.GetStat(Stats.ResistParalysis, pData, value);
            pData.ResistSilence = Classes.GetStat(Stats.ResistSilence, pData, value);
            pData.ResistBlind = Classes.GetStat(Stats.ResistBlind, pData, value); 
            pData.ResistCriticalRate = Classes.GetStat(Stats.ResistCriticalRate, pData, value);
            pData.ResistCriticalDamage = Classes.GetStat(Stats.ResistCriticalDamage, pData, value);
            pData.ResistMagicCriticalRate = Classes.GetStat(Stats.ResistMagicCriticalRate, pData, value);
            pData.ResistMagicCriticalDamage = Classes.GetStat(Stats.ResistMagicCriticalDamage, pData, value);
        }
    }
}
