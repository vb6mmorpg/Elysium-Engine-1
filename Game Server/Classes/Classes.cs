using System.Collections.Generic;
using GameServer.Server;

namespace GameServer.Classe {
    public class Classes {
        /// <summary>
        /// Stats base de cada classe.
        /// </summary>
        public static List<ClassesBase> ClassesBase { get; set; }

        /// <summary>
        /// Incremento de cada classe.
        /// </summary>
        public static List<ClassesIncrement> ClassesIncrement { get; set; }

        /// <summary>
        /// Faz uma busca pelo ID de classe retorna o indice.
        /// </summary>
        /// <param name="cID">ID de classe</param>
        /// <returns></returns>
        private static int FindIndexByClasseID(int classeID) {
            for (int n = 0; n < ClassesBase.Count; n++) { if (ClassesBase[n].ID.CompareTo(classeID) == 0) { return n; } }

            return -1;
        }

        /// <summary>
        /// Faz uma busca pelo ID de incremento e retorna o indice.
        /// </summary>
        /// <param name="incrementID">ID de incremento</param>
        /// <returns></returns>
        private static int FindIndexByIncrementID(int incrementID) {
            for (int n = 0; n < ClassesIncrement.Count; n++) { if (ClassesIncrement[n].IncrementID.CompareTo(incrementID) == 0) { return n; } }

            return -1;
        }

        /// <summary>
        /// Obtém os stats de classe.
        /// </summary>
        /// <param name="stat"></param>
        /// <param name="classeID"></param>
        /// <returns></returns>
        public static int GetStat(Stats stat, PlayerData pData, params int[] optValue) {
            // Pega o index da classe
            int classeIndex = FindIndexByClasseID(pData.ClasseID);

            // Se não houver nada, retorna 0
            if (classeIndex <= -1) { return 0; }

            // Pega o index do incremento de classe
            int incrementIndex = FindIndexByIncrementID(ClassesBase[classeIndex].IncrementID);

            // Se não houver nada, retorna 0
            if (incrementIndex <= -1) { return 0; }
            //(input > 0) ? "positive" : "negative";

            // Pega os valores para calculo
            int[] sValue = new int[10];
            sValue[0] = pData.Level + optValue[0];//ClassesBase[classeIndex].Level;
            sValue[1] = pData.Strenght + optValue[1]; //ClassesBase[classeIndex].Strenght;
            sValue[2] = pData.Dexterity + optValue[2]; //lassesBase[classeIndex].Dexterity;
            sValue[3] = pData.Agility + optValue[3]; //ClassesBase[classeIndex].Agility;
            sValue[4] = pData.Constitution + optValue[4]; //ClassesBase[classeIndex].Vitality;
            sValue[5] = pData.Intelligence + optValue[5]; //ClassesBase[classeIndex].Intelligence;
            sValue[6] = pData.Wisdom + optValue[6]; //ClassesBase[classeIndex].Mind;
            sValue[7] = pData.Will + optValue[7];
            sValue[8] = pData.Mind + optValue[8];
            sValue[9] = pData.Charisma + optValue[9];

            switch (stat) {
                case Stats.Strenght: return ClassesBase[classeIndex].Strenght + (pData.Level * ClassesIncrement[incrementIndex].Strenght);
                case Stats.Dexterity: return ClassesBase[classeIndex].Dexterity + (pData.Level * ClassesIncrement[incrementIndex].Dexterity);
                case Stats.Agility: return ClassesBase[classeIndex].Agility + (pData.Level * ClassesIncrement[incrementIndex].Agility);
                case Stats.Constitution: return ClassesBase[classeIndex].Constitution + (pData.Level * ClassesIncrement[incrementIndex].Constitution);
                case Stats.Intelligence: return ClassesBase[classeIndex].Intelligence + (pData.Level * ClassesIncrement[incrementIndex].Intelligence);
                case Stats.Wisdom: return ClassesBase[classeIndex].Wisdom + (pData.Level * ClassesIncrement[incrementIndex].Wisdom);
                case Stats.Will: return ClassesBase[classeIndex].Will + (pData.Level * ClassesIncrement[incrementIndex].Will);
                case Stats.Mind: return ClassesBase[classeIndex].Mind + (pData.Level * ClassesIncrement[incrementIndex].Mind);
                case Stats.Charisma: return ClassesBase[classeIndex].Charisma + (pData.Level * ClassesIncrement[incrementIndex].Charisma);
                case Stats.Point: return ClassesBase[classeIndex].StatPoint + (pData.Level * ClassesIncrement[incrementIndex].Points);
                case Stats.Level: return ClassesBase[classeIndex].Level;
                case Stats.MaxHP: return ClassesBase[classeIndex].HP + ClassesIncrement[incrementIndex].GetIncrementStat(Stats.MaxHP, sValue);
                case Stats.MaxMP: return ClassesBase[classeIndex].MP + ClassesIncrement[incrementIndex].GetIncrementStat(Stats.MaxMP, sValue);
                case Stats.MaxSP: return ClassesBase[classeIndex].SP + ClassesIncrement[incrementIndex].GetIncrementStat(Stats.MaxSP, sValue);
                case Stats.RegenHP: return ClassesBase[classeIndex].RegenHP + ClassesIncrement[incrementIndex].GetIncrementStat(Stats.RegenHP, sValue);
                case Stats.RegenMP: return ClassesBase[classeIndex].RegenMP + ClassesIncrement[incrementIndex].GetIncrementStat(Stats.RegenMP, sValue);
                case Stats.RegenSP: return ClassesBase[classeIndex].RegenSP + ClassesIncrement[incrementIndex].GetIncrementStat(Stats.RegenSP, sValue);
                case Stats.DamageSuppression: return ClassesBase[classeIndex].DamageSuppression + ClassesIncrement[incrementIndex].GetIncrementStat(Stats.DamageSuppression, sValue);
                case Stats.Enmity: return ClassesBase[classeIndex].Enmity + ClassesIncrement[incrementIndex].GetIncrementStat(Stats.Enmity, sValue);
                case Stats.AdditionalDamage: return ClassesBase[classeIndex].AdditionalDamage + ClassesIncrement[incrementIndex].GetIncrementStat(Stats.AdditionalDamage, sValue);
                case Stats.HealingPower: return ClassesBase[classeIndex].HealingPower + ClassesIncrement[incrementIndex].GetIncrementStat(Stats.HealingPower, sValue);
                case Stats.Concentration: return ClassesBase[classeIndex].Concentration + ClassesIncrement[incrementIndex].GetIncrementStat(Stats.Concentration, sValue);
                case Stats.AttackSpeed: return ClassesBase[classeIndex].AttackSpeed + ClassesIncrement[incrementIndex].GetIncrementStat(Stats.AttackSpeed, sValue);
                case Stats.CastSpeed: return ClassesBase[classeIndex].CastSpeed + ClassesIncrement[incrementIndex].GetIncrementStat(Stats.CastSpeed, sValue);
                case Stats.Attack: return ClassesBase[classeIndex].Attack + ClassesIncrement[incrementIndex].GetIncrementStat(Stats.Attack, sValue);
                case Stats.Accuracy: return ClassesBase[classeIndex].Accuracy + ClassesIncrement[incrementIndex].GetIncrementStat(Stats.Accuracy, sValue);
                case Stats.Defense: return ClassesBase[classeIndex].Defense + ClassesIncrement[incrementIndex].GetIncrementStat(Stats.Defense, sValue);
                case Stats.Evasion: return ClassesBase[classeIndex].Evasion + ClassesIncrement[incrementIndex].GetIncrementStat(Stats.Evasion, sValue);
                case Stats.Block: return ClassesBase[classeIndex].Block + ClassesIncrement[incrementIndex].GetIncrementStat(Stats.Block, sValue);
                case Stats.Parry: return ClassesBase[classeIndex].Parry + ClassesIncrement[incrementIndex].GetIncrementStat(Stats.Parry, sValue);
                case Stats.CriticalRate: return ClassesBase[classeIndex].CriticalRate + ClassesIncrement[incrementIndex].GetIncrementStat(Stats.CriticalRate, sValue);
                case Stats.CriticalDamage: return ClassesBase[classeIndex].CriticalDamage + ClassesIncrement[incrementIndex].GetIncrementStat(Stats.CriticalDamage, sValue);
                case Stats.MagicAttack: return ClassesBase[classeIndex].MagicAttack + ClassesIncrement[incrementIndex].GetIncrementStat(Stats.MagicAttack, sValue);
                case Stats.MagicAccuracy: return ClassesBase[classeIndex].MagicAccuracy + ClassesIncrement[incrementIndex].GetIncrementStat(Stats.MagicAccuracy, sValue);
                case Stats.MagicDefense: return ClassesBase[classeIndex].MagicDefense + ClassesIncrement[incrementIndex].GetIncrementStat(Stats.MagicDefense, sValue);
                case Stats.MagicResist: return ClassesBase[classeIndex].MagicResist + ClassesIncrement[incrementIndex].GetIncrementStat(Stats.MagicResist, sValue);
                case Stats.MagicCriticalRate: return ClassesBase[classeIndex].MagicCriticalRate + ClassesIncrement[incrementIndex].GetIncrementStat(Stats.MagicCriticalRate, sValue);
                case Stats.MagicCriticalDamage: return ClassesBase[classeIndex].MagicCriticalDamage + ClassesIncrement[incrementIndex].GetIncrementStat(Stats.MagicCriticalDamage, sValue);
                case Stats.AttributeFire: return ClassesBase[classeIndex].AttributeFire + ClassesIncrement[incrementIndex].GetIncrementStat(Stats.AttributeFire, sValue);
                case Stats.AttributeWater: return ClassesBase[classeIndex].AttributeWater + ClassesIncrement[incrementIndex].GetIncrementStat(Stats.AttributeWater, sValue);
                case Stats.AttributeEarth: return ClassesBase[classeIndex].AttributeEarth + ClassesIncrement[incrementIndex].GetIncrementStat(Stats.AttributeEarth, sValue);
                case Stats.AttributeWind: return ClassesBase[classeIndex].AttributeWind + ClassesIncrement[incrementIndex].GetIncrementStat(Stats.AttributeWind, sValue);
                case Stats.ResistStun: return ClassesBase[classeIndex].ResistStun + ClassesIncrement[incrementIndex].GetIncrementStat(Stats.ResistStun, sValue);
                case Stats.ResistParalysis: return ClassesBase[classeIndex].ResistParalysis + ClassesIncrement[incrementIndex].GetIncrementStat(Stats.ResistParalysis, sValue);
                case Stats.ResistSilence: return ClassesBase[classeIndex].ResistSilence + ClassesIncrement[incrementIndex].GetIncrementStat(Stats.ResistSilence, sValue);
                case Stats.ResistBlind: return ClassesBase[classeIndex].ResistBlind + ClassesIncrement[incrementIndex].GetIncrementStat(Stats.ResistBlind, sValue);
                case Stats.ResistCriticalRate: return ClassesBase[classeIndex].ResistCriticalRate + ClassesIncrement[incrementIndex].GetIncrementStat(Stats.ResistCriticalRate, sValue);
                case Stats.ResistCriticalDamage: return ClassesBase[classeIndex].ResistCriticalDamage + ClassesIncrement[incrementIndex].GetIncrementStat(Stats.ResistCriticalDamage, sValue);
                case Stats.ResistMagicCriticalRate: return ClassesBase[classeIndex].ResistMagicCriticalRate + ClassesIncrement[incrementIndex].GetIncrementStat(Stats.ResistMagicCriticalRate, sValue);
                case Stats.ResistMagicCriticalDamage: return ClassesBase[classeIndex].ResistMagicCriticalDamage + ClassesIncrement[incrementIndex].GetIncrementStat(Stats.ResistMagicCriticalDamage, sValue);
            }

            return 0;
        }
    }
}
