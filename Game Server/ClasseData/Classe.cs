using System.Collections.Generic;
using GameServer.Server;
using GameServer.Common;

namespace GameServer.ClasseData {
    public class Classe : StatsBase {
        /// <summary>
        /// ID de classe.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// ID de icnremento
        /// </summary>
        public int IncrementID { get; set; }

        /// <summary>
        /// Lista de classes.
        /// </summary>
        public static List<Classe> Classes { get; set; }

        /// <summary>
        /// Atributos de incremento
        /// </summary>
        public StatsIncrement Increment { get; set; }

        /// <summary>
        /// Construtor
        /// </summary>
        public Classe() {
            Increment = new StatsIncrement();
        }

        /// <summary>
        /// Obtém os stats de classe.
        /// </summary>
        /// <param name="stat"></param>
        /// <param name="cID"></param>
        /// <returns></returns>
        public int GetClasseStat(StatType stat) {
            // Pega os valores para calculo
            int[] value = new int[Constant.MAX_STATS];
            value[0] = Level;
            value[1] = Strenght;
            value[2] = Dexterity;
            value[3] = Agility;
            value[4] = Constitution;
            value[5] = Intelligence;
            value[6] = Wisdom;
            value[7] = Will;
            value[8] = Mind;
            value[9] = Charisma;

            //stats base + level * incremento por level
            switch (stat) {
                case StatType.Strenght: return Strenght + (Level * Increment.Strenght);
                case StatType.Dexterity: return Dexterity + (Level * Increment.Dexterity);
                case StatType.Agility: return Agility + (Level * Increment.Agility);
                case StatType.Constitution: return Constitution + (Level * Increment.Constitution);
                case StatType.Intelligence: return Intelligence + (Level * Increment.Intelligence);
                case StatType.Wisdom: return Wisdom + (Level * Increment.Wisdom);
                case StatType.Will: return Will + (Level * Increment.Will);
                case StatType.Mind: return Mind + (Level * Increment.Mind);
                case StatType.Charisma: return Charisma + (Level * Increment.Charisma);
                case StatType.Point: return Points + (Level * Increment.Points);
                case StatType.Level: return Level;
                case StatType.MaxHP: return HP + Increment.GetIncrementStat(StatType.MaxHP, value);
                case StatType.MaxMP: return MP + Increment.GetIncrementStat(StatType.MaxMP, value);
                case StatType.MaxSP: return SP + Increment.GetIncrementStat(StatType.MaxSP, value);
                case StatType.RegenHP: return RegenHP + Increment.GetIncrementStat(StatType.RegenHP, value);
                case StatType.RegenMP: return RegenMP + Increment.GetIncrementStat(StatType.RegenMP, value);
                case StatType.RegenSP: return RegenSP + Increment.GetIncrementStat(StatType.RegenSP, value);
                case StatType.DamageSuppression: return DamageSuppression + Increment.GetIncrementStat(StatType.DamageSuppression, value);
                case StatType.Enmity: return Enmity + Increment.GetIncrementStat(StatType.Enmity, value);
                case StatType.AdditionalDamage: return AdditionalDamage + Increment.GetIncrementStat(StatType.AdditionalDamage, value);
                case StatType.HealingPower: return HealingPower + Increment.GetIncrementStat(StatType.HealingPower, value);
                case StatType.Concentration: return Concentration + Increment.GetIncrementStat(StatType.Concentration, value);
                case StatType.AttackSpeed: return AttackSpeed + Increment.GetIncrementStat(StatType.AttackSpeed, value);
                case StatType.CastSpeed: return CastSpeed + Increment.GetIncrementStat(StatType.CastSpeed, value);
                case StatType.Attack: return Attack + Increment.GetIncrementStat(StatType.Attack, value);
                case StatType.Accuracy: return Accuracy + Increment.GetIncrementStat(StatType.Accuracy, value);
                case StatType.Defense: return Defense + Increment.GetIncrementStat(StatType.Defense, value);
                case StatType.Evasion: return Evasion + Increment.GetIncrementStat(StatType.Evasion, value);
                case StatType.Block: return Block + Increment.GetIncrementStat(StatType.Block, value);
                case StatType.Parry: return Parry + Increment.GetIncrementStat(StatType.Parry, value);
                case StatType.CriticalRate: return CriticalRate + Increment.GetIncrementStat(StatType.CriticalRate, value);
                case StatType.CriticalDamage: return CriticalDamage + Increment.GetIncrementStat(StatType.CriticalDamage, value);
                case StatType.MagicAttack: return MagicAttack + Increment.GetIncrementStat(StatType.MagicAttack, value);
                case StatType.MagicAccuracy: return MagicAccuracy + Increment.GetIncrementStat(StatType.MagicAccuracy, value);
                case StatType.MagicDefense: return MagicDefense + Increment.GetIncrementStat(StatType.MagicDefense, value);
                case StatType.MagicResist: return MagicResist + Increment.GetIncrementStat(StatType.MagicResist, value);
                case StatType.MagicCriticalRate: return MagicCriticalRate + Increment.GetIncrementStat(StatType.MagicCriticalRate, value);
                case StatType.MagicCriticalDamage: return MagicCriticalDamage + Increment.GetIncrementStat(StatType.MagicCriticalDamage, value);
                case StatType.ResistStun: return ResistStun + Increment.GetIncrementStat(StatType.ResistStun, value);
                case StatType.ResistSilence: return ResistSilence + Increment.GetIncrementStat(StatType.ResistSilence, value);
                case StatType.ResistParalysis: return ResistParalysis + Increment.GetIncrementStat(StatType.ResistParalysis, value);
                case StatType.ResistBlind: return ResistBlind + Increment.GetIncrementStat(StatType.ResistBlind, value);
                case StatType.AttributeFire: return AttributeFire + Increment.GetIncrementStat(StatType.AttributeFire, value);
                case StatType.AttributeWater: return AttributeWater + Increment.GetIncrementStat(StatType.AttributeWater, value);
                case StatType.AttributeEarth: return AttributeEarth + Increment.GetIncrementStat(StatType.AttributeEarth, value);
                case StatType.AttributeWind: return AttributeWind + Increment.GetIncrementStat(StatType.AttributeWind, value);
                case StatType.ResistCriticalRate: return ResistCriticalRate + Increment.GetIncrementStat(StatType.ResistCriticalRate, value);
                case StatType.ResistCriticalDamage: return ResistCriticalDamage + Increment.GetIncrementStat(StatType.ResistCriticalDamage, value);
                case StatType.ResistMagicCriticalRate: return ResistMagicCriticalRate + Increment.GetIncrementStat(StatType.ResistMagicCriticalRate, value);
                case StatType.ResistMagicCriticalDamage: return ResistMagicCriticalDamage + Increment.GetIncrementStat(StatType.ResistMagicCriticalDamage, value);
            }

            return 0;
        }

        /// <summary>
        /// Obtém os stats do personagem.
        /// </summary>
        /// <param name="stat"></param>
        /// <param name="pData"></param>
        /// <param name="itemStats"></param>
        /// <returns></returns>
        public int GetPlayerStat(StatType stat, PlayerData pData, params int[] itemStats) {
            // Pega os valores para calculo
            int[] value = new int[Constant.MAX_STATS];
            value[0] = pData.Level + itemStats[0];
            value[1] = pData.Strenght + itemStats[1];
            value[2] = pData.Dexterity + itemStats[2];
            value[3] = pData.Agility + itemStats[3];
            value[4] = pData.Constitution + itemStats[4];
            value[5] = pData.Intelligence + itemStats[5];
            value[6] = pData.Wisdom + itemStats[6];
            value[7] = pData.Will + itemStats[7];
            value[8] = pData.Mind + itemStats[8];
            value[9] = pData.Charisma + itemStats[9];

            //stats base + level * incremento por level
            switch (stat) {
                case StatType.Strenght: return pData.BaseStrenght + (pData.Level * Increment.Strenght);
                case StatType.Dexterity: return pData.BaseDexterity + (pData.Level * Increment.Dexterity);
                case StatType.Agility: return pData.BaseAgility + (pData.Level * Increment.Agility);
                case StatType.Constitution: return pData.BaseConstitution + (pData.Level * Increment.Constitution);
                case StatType.Intelligence: return pData.BaseIntelligence + (pData.Level * Increment.Intelligence);
                case StatType.Wisdom: return pData.BaseWisdom + (pData.Level * Increment.Wisdom);
                case StatType.Will: return pData.BaseWill + (pData.Level * Increment.Will);
                case StatType.Mind: return pData.BaseMind + (pData.Level * Increment.Mind);
                case StatType.Charisma: return pData.BaseCharisma + (pData.Level * Increment.Charisma);
                case StatType.MaxHP: return HP + Increment.GetIncrementStat(StatType.MaxHP, value);
                case StatType.MaxMP: return MP + Increment.GetIncrementStat(StatType.MaxMP, value);
                case StatType.MaxSP: return SP + Increment.GetIncrementStat(StatType.MaxSP, value);
                case StatType.RegenHP: return RegenHP + Increment.GetIncrementStat(StatType.RegenHP, value);
                case StatType.RegenMP: return RegenMP + Increment.GetIncrementStat(StatType.RegenMP, value);
                case StatType.RegenSP: return RegenSP + Increment.GetIncrementStat(StatType.RegenSP, value);
                case StatType.DamageSuppression: return DamageSuppression + Increment.GetIncrementStat(StatType.DamageSuppression, value);
                case StatType.Enmity: return Enmity + Increment.GetIncrementStat(StatType.Enmity, value);
                case StatType.AdditionalDamage: return AdditionalDamage + Increment.GetIncrementStat(StatType.AdditionalDamage, value);
                case StatType.HealingPower: return HealingPower + Increment.GetIncrementStat(StatType.HealingPower, value);
                case StatType.Concentration: return Concentration + Increment.GetIncrementStat(StatType.Concentration, value);
                case StatType.AttackSpeed: return AttackSpeed + Increment.GetIncrementStat(StatType.AttackSpeed, value);
                case StatType.CastSpeed: return CastSpeed + Increment.GetIncrementStat(StatType.CastSpeed, value);
                case StatType.Attack: return Attack + Increment.GetIncrementStat(StatType.Attack, value);
                case StatType.Accuracy: return Accuracy + Increment.GetIncrementStat(StatType.Accuracy, value);
                case StatType.Defense: return Defense + Increment.GetIncrementStat(StatType.Defense, value);
                case StatType.Evasion: return Evasion + Increment.GetIncrementStat(StatType.Evasion, value);
                case StatType.Block: return Block + Increment.GetIncrementStat(StatType.Block, value);
                case StatType.Parry: return Parry + Increment.GetIncrementStat(StatType.Parry, value);
                case StatType.CriticalRate: return CriticalRate + Increment.GetIncrementStat(StatType.CriticalRate, value);
                case StatType.CriticalDamage: return CriticalDamage + Increment.GetIncrementStat(StatType.CriticalDamage, value);
                case StatType.MagicAttack: return MagicAttack + Increment.GetIncrementStat(StatType.MagicAttack, value);
                case StatType.MagicAccuracy: return MagicAccuracy + Increment.GetIncrementStat(StatType.MagicAccuracy, value);
                case StatType.MagicDefense: return MagicDefense + Increment.GetIncrementStat(StatType.MagicDefense, value);
                case StatType.MagicResist: return MagicResist + Increment.GetIncrementStat(StatType.MagicResist, value);
                case StatType.MagicCriticalRate: return MagicCriticalRate + Increment.GetIncrementStat(StatType.MagicCriticalRate, value);
                case StatType.MagicCriticalDamage: return MagicCriticalDamage + Increment.GetIncrementStat(StatType.MagicCriticalDamage, value);
                case StatType.ResistStun: return ResistStun + Increment.GetIncrementStat(StatType.ResistStun, value);
                case StatType.ResistSilence: return ResistSilence + Increment.GetIncrementStat(StatType.ResistSilence, value);
                case StatType.ResistParalysis: return ResistParalysis + Increment.GetIncrementStat(StatType.ResistParalysis, value);
                case StatType.ResistBlind: return ResistBlind + Increment.GetIncrementStat(StatType.ResistBlind, value);
                case StatType.AttributeFire: return AttributeFire + Increment.GetIncrementStat(StatType.AttributeFire, value);
                case StatType.AttributeWater: return AttributeWater + Increment.GetIncrementStat(StatType.AttributeWater, value);
                case StatType.AttributeEarth: return AttributeEarth + Increment.GetIncrementStat(StatType.AttributeEarth, value);
                case StatType.AttributeWind: return AttributeWind + Increment.GetIncrementStat(StatType.AttributeWind, value);
                case StatType.ResistCriticalRate: return ResistCriticalRate + Increment.GetIncrementStat(StatType.ResistCriticalRate, value);
                case StatType.ResistCriticalDamage: return ResistCriticalDamage + Increment.GetIncrementStat(StatType.ResistCriticalDamage, value);
                case StatType.ResistMagicCriticalRate: return ResistMagicCriticalRate + Increment.GetIncrementStat(StatType.ResistMagicCriticalRate, value);
                case StatType.ResistMagicCriticalDamage: return ResistMagicCriticalDamage + Increment.GetIncrementStat(StatType.ResistMagicCriticalDamage, value);
            }

            return 0;
        }

        /// <summary>
        /// Procura pelo indice da classe na lista.
        /// </summary>
        /// <param name="classeID"></param>
        /// <returns></returns>
        public static int FindClasseIndexByID(int classeID) {
            for (var index = 0; index < Classes.Count; index++) {
                if (Classes[index].ID == classeID) return index;
            }

            return -1;
        }
    }
}