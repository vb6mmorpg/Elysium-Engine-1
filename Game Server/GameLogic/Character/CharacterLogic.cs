using GameServer.ClasseData;
using GameServer.Server;

namespace GameServer.GameLogic.Character {
    public static class CharacterLogic {

        public static void UpdateCharacterStats(int playerID) {
            var pData = Authentication.FindByAccountID(playerID);
            var index = Classe.FindClasseIndexByID(pData.ClasseID);

            //items stat value
            int[] value = new int[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            // before update, check all item StatType
            pData.Strenght = Classe.Classes[index].GetPlayerStat(StatType.Strenght, pData, value);
            pData.Dexterity = Classe.Classes[index].GetPlayerStat(StatType.Dexterity, pData, value);
            pData.Agility = Classe.Classes[index].GetPlayerStat(StatType.Agility, pData, value);
            pData.Constitution = Classe.Classes[index].GetPlayerStat(StatType.Constitution, pData, value);
            pData.Intelligence = Classe.Classes[index].GetPlayerStat(StatType.Intelligence, pData, value);
            pData.Wisdom = Classe.Classes[index].GetPlayerStat(StatType.Wisdom, pData, value);
            pData.Will = Classe.Classes[index].GetPlayerStat(StatType.Will, pData, value);
            pData.Mind = Classe.Classes[index].GetPlayerStat(StatType.Mind, pData, value);
            pData.Charisma = Classe.Classes[index].GetPlayerStat(StatType.Charisma, pData, value);

            pData.MaxHP = Classe.Classes[index].GetPlayerStat(StatType.MaxHP, pData, value); 
            pData.MaxMP = Classe.Classes[index].GetPlayerStat(StatType.MaxMP, pData, value);
            pData.MaxSP = Classe.Classes[index].GetPlayerStat(StatType.MaxSP, pData, value);

            if (pData.HP > pData.MaxHP) pData.HP = pData.MaxHP;
            if (pData.MP > pData.MaxMP) pData.MP = pData.MaxMP;
            if (pData.SP > pData.MaxSP) pData.SP = pData.MaxSP;

            pData.RegenHP = Classe.Classes[index].GetPlayerStat(StatType.RegenHP, pData, value);
            pData.RegenMP = Classe.Classes[index].GetPlayerStat(StatType.RegenMP, pData, value);
            pData.RegenSP = Classe.Classes[index].GetPlayerStat(StatType.RegenSP, pData, value);
            pData.DamageSuppression = Classe.Classes[index].GetPlayerStat(StatType.DamageSuppression, pData, value);
            pData.Enmity = Classe.Classes[index].GetPlayerStat(StatType.Enmity, pData, value);
            pData.AdditionalDamage = Classe.Classes[index].GetPlayerStat(StatType.AdditionalDamage, pData, value);
            pData.HealingPower = Classe.Classes[index].GetPlayerStat(StatType.HealingPower, pData, value);
            pData.Concentration = Classe.Classes[index].GetPlayerStat(StatType.Concentration, pData, value);
            pData.AttackSpeed = Classe.Classes[index].GetPlayerStat(StatType.AttackSpeed, pData, value);
            pData.CastSpeed = Classe.Classes[index].GetPlayerStat(StatType.CastSpeed, pData, value);
            pData.Attack = Classe.Classes[index].GetPlayerStat(StatType.Attack, pData, value);
            pData.Accuracy = Classe.Classes[index].GetPlayerStat(StatType.Accuracy, pData, value);
            pData.Defense = Classe.Classes[index].GetPlayerStat(StatType.Defense, pData, value);
            pData.Evasion = Classe.Classes[index].GetPlayerStat(StatType.Evasion, pData, value);
            pData.Block = Classe.Classes[index].GetPlayerStat(StatType.Block, pData, value);
            pData.Parry = Classe.Classes[index].GetPlayerStat(StatType.Parry, pData, value);
            pData.CriticalRate = Classe.Classes[index].GetPlayerStat(StatType.CriticalRate, pData, value);
            pData.CriticalDamage = Classe.Classes[index].GetPlayerStat(StatType.CriticalDamage, pData, value);
            pData.MagicAttack = Classe.Classes[index].GetPlayerStat(StatType.MagicAttack, pData, value);
            pData.MagicAccuracy = Classe.Classes[index].GetPlayerStat(StatType.MagicAccuracy, pData, value);
            pData.MagicDefense = Classe.Classes[index].GetPlayerStat(StatType.MagicDefense, pData, value);
            pData.MagicResist = Classe.Classes[index].GetPlayerStat(StatType.MagicResist, pData, value);
            pData.MagicCriticalRate = Classe.Classes[index].GetPlayerStat(StatType.MagicCriticalRate, pData, value);
            pData.MagicCriticalDamage = Classe.Classes[index].GetPlayerStat(StatType.MagicCriticalDamage, pData, value);
            pData.AttributeFire = Classe.Classes[index].GetPlayerStat(StatType.AttributeFire, pData, value);
            pData.AttributeWater = Classe.Classes[index].GetPlayerStat(StatType.AttributeWater, pData, value);
            pData.AttributeEarth = Classe.Classes[index].GetPlayerStat(StatType.AttributeEarth, pData, value);
            pData.AttributeWind = Classe.Classes[index].GetPlayerStat(StatType.AttributeWind, pData, value);
            pData.MagicCriticalRate = Classe.Classes[index].GetPlayerStat(StatType.MagicCriticalRate, pData, value);
            pData.MagicCriticalDamage = Classe.Classes[index].GetPlayerStat(StatType.MagicCriticalDamage, pData, value);
            pData.ResistStun = Classe.Classes[index].GetPlayerStat(StatType.ResistStun, pData, value);
            pData.ResistParalysis = Classe.Classes[index].GetPlayerStat(StatType.ResistParalysis, pData, value);
            pData.ResistSilence = Classe.Classes[index].GetPlayerStat(StatType.ResistSilence, pData, value);
            pData.ResistBlind = Classe.Classes[index].GetPlayerStat(StatType.ResistBlind, pData, value); 
            pData.ResistCriticalRate = Classe.Classes[index].GetPlayerStat(StatType.ResistCriticalRate, pData, value);
            pData.ResistCriticalDamage = Classe.Classes[index].GetPlayerStat(StatType.ResistCriticalDamage, pData, value);
            pData.ResistMagicCriticalRate = Classe.Classes[index].GetPlayerStat(StatType.ResistMagicCriticalRate, pData, value);
            pData.ResistMagicCriticalDamage = Classe.Classes[index].GetPlayerStat(StatType.ResistMagicCriticalDamage, pData, value);
        }
    }
}
