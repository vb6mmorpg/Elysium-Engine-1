using System;

namespace GameServer.Classe {
    public class ClassesIncrement {
        /// <summary>
        /// ID
        /// </summary>
        public int IncrementID { get; set; }
        public int Strenght { get; set; }
        public int Dexterity { get; set; }
        public int Agility { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Will { get; set; }
        public int Mind { get; set; }
        public int Charisma { get; set; }
        public int Points { get; set; }
        
        private const int MAX_STATS = 10;
        private int[] inc_MaxHP = new int[MAX_STATS];
        private int[] inc_MaxMP = new int[MAX_STATS];
        private int[] inc_MaxSP = new int[MAX_STATS];
        private int[] inc_RegenHP = new int[MAX_STATS];
        private int[] inc_RegenMP = new int[MAX_STATS];
        private int[] inc_RegenSP = new int[MAX_STATS];
        private int[] inc_DamageSuppression = new int[MAX_STATS];
        private int[] inc_Enmity = new int[MAX_STATS];
        private int[] inc_AdditionalDamage = new int[MAX_STATS];
        private int[] inc_HealingPower = new int[MAX_STATS];
        private int[] inc_Concentration = new int[MAX_STATS];
        private int[] inc_AttackSpeed = new int[MAX_STATS];
        private int[] inc_CastSpeed = new int[MAX_STATS];
        private int[] inc_Attack = new int[MAX_STATS];
        private int[] inc_Accuracy = new int[MAX_STATS];
        private int[] inc_Defense = new int[MAX_STATS];
        private int[] inc_Evasion = new int[MAX_STATS];
        private int[] inc_Block = new int[MAX_STATS];
        private int[] inc_Parry = new int[MAX_STATS];
        private int[] inc_CriticalRate = new int[MAX_STATS];
        private int[] inc_CriticalDamage = new int[MAX_STATS];
        private int[] inc_MagicAttack = new int[MAX_STATS];
        private int[] inc_MagicAccuracy = new int[MAX_STATS];
        private int[] inc_MagicDefense = new int[MAX_STATS];
        private int[] inc_MagicResist = new int[MAX_STATS];
        private int[] inc_MagicCriticalRate = new int[MAX_STATS];
        private int[] inc_MagicCriticalDamage = new int[MAX_STATS];
        private int[] inc_AttributeFire = new int[MAX_STATS];
        private int[] inc_AttributeWater = new int[MAX_STATS];
        private int[] inc_AttributeEarth = new int[MAX_STATS];
        private int[] inc_AttributeWind = new int[MAX_STATS];
        private int[] inc_ResistStun = new int[MAX_STATS];
        private int[] inc_ResistBlind = new int[MAX_STATS];
        private int[] inc_ResistParalysis = new int[MAX_STATS];
        private int[] inc_ResistSilence = new int[MAX_STATS];
        private int[] inc_ResistCriticalRate = new int[MAX_STATS];
        private int[] inc_ResistCriticalDamage = new int[MAX_STATS];
        private int[] inc_ResistMagicCriticalRate = new int[MAX_STATS];
        private int[] inc_ResistMagicCriticalDamage = new int[MAX_STATS];

        /// <summary>
        /// Altera determinado 'stat'.
        /// </summary>
        /// <param name="stat"></param>
        /// <param name="data"></param>
        public void SetIncrementStat(Stats stat, string data) {
            switch (stat) {
                case Stats.MaxHP:
                    SetIncrementStat(inc_MaxHP, data);
                    break;
                case Stats.MaxMP:
                    SetIncrementStat(inc_MaxMP, data);
                    break;
                case Stats.MaxSP:
                    SetIncrementStat(inc_MaxSP, data);
                    break;
                case Stats.RegenHP:
                    SetIncrementStat(inc_RegenHP, data);
                    break;
                case Stats.RegenMP:
                    SetIncrementStat(inc_RegenMP, data);
                    break;
                case Stats.RegenSP:
                    SetIncrementStat(inc_RegenSP, data);
                    break;
                case Stats.DamageSuppression:
                    SetIncrementStat(inc_DamageSuppression, data);
                    break;
                case Stats.Enmity:
                    SetIncrementStat(inc_Enmity, data);
                    break;
                case Stats.AdditionalDamage:
                    SetIncrementStat(inc_AdditionalDamage, data);
                    break;
                case Stats.HealingPower:
                    SetIncrementStat(inc_HealingPower, data);
                    break;
                case Stats.Concentration:
                    SetIncrementStat(inc_Concentration, data);
                    break;
                case Stats.AttackSpeed:
                    SetIncrementStat(inc_AttackSpeed, data);
                    break;
                case Stats.CastSpeed:
                    SetIncrementStat(inc_CastSpeed, data);
                    break;
                case Stats.Attack:
                    SetIncrementStat(inc_Attack, data);
                    break;
                case Stats.Accuracy:
                    SetIncrementStat(inc_Accuracy, data);
                    break;
                case Stats.Defense:
                    SetIncrementStat(inc_Defense, data);
                    break;
                case Stats.Evasion:
                    SetIncrementStat(inc_Evasion, data);
                    break;
                case Stats.Block:
                    SetIncrementStat(inc_Block, data);
                    break;
                case Stats.Parry:
                    SetIncrementStat(inc_Parry, data);
                    break;
                case Stats.CriticalRate:
                    SetIncrementStat(inc_CriticalRate, data);
                    break;
                case Stats.CriticalDamage:
                    SetIncrementStat(inc_CriticalDamage, data);
                    break;
                case Stats.MagicAttack:
                    SetIncrementStat(inc_MagicAttack, data);
                    break;
                case Stats.MagicAccuracy:
                    SetIncrementStat(inc_MagicAccuracy, data);
                    break;
                case Stats.MagicDefense:
                    SetIncrementStat(inc_MagicDefense, data);
                    break;
                case Stats.MagicResist:
                    SetIncrementStat(inc_MagicResist, data);
                    break;
                case Stats.MagicCriticalRate:
                    SetIncrementStat(inc_MagicCriticalRate, data);
                    break;
                case Stats.MagicCriticalDamage:
                    SetIncrementStat(inc_MagicCriticalDamage, data);
                    break;
                case Stats.AttributeFire:
                    SetIncrementStat(inc_AttributeFire, data);
                    break;
                case Stats.AttributeWater:
                    SetIncrementStat(inc_AttributeWater, data);
                    break;
                case Stats.AttributeEarth:
                    SetIncrementStat(inc_AttributeEarth, data);
                    break;
                case Stats.AttributeWind:
                    SetIncrementStat(inc_AttributeWind, data);
                    break;
                case Stats.ResistStun:
                    SetIncrementStat(inc_ResistStun, data);
                    break;
                case Stats.ResistParalysis:
                    SetIncrementStat(inc_ResistParalysis, data);
                    break;
                case Stats.ResistSilence:
                    SetIncrementStat(inc_ResistSilence, data);
                    break;
                case Stats.ResistBlind:
                    SetIncrementStat(inc_ResistBlind, data);
                    break;
                case Stats.ResistCriticalRate:
                    SetIncrementStat(inc_ResistCriticalRate, data);
                    break;
                case Stats.ResistCriticalDamage:
                    SetIncrementStat(inc_ResistCriticalDamage, data);
                    break;
                case Stats.ResistMagicCriticalRate:
                    SetIncrementStat(inc_ResistMagicCriticalRate, data);
                    break;
                case Stats.ResistMagicCriticalDamage:
                    SetIncrementStat(inc_ResistMagicCriticalDamage, data);
                    break;  
            }
        }

        /// <summary>
        /// Altera e realiza a conversão.
        /// </summary>
        /// <param name="var"></param>
        /// <param name="data"></param>
        private void SetIncrementStat(int[] var, string data) {
            string[] value = data.Split(';');
            var[0] = Convert.ToInt32(value[0]); // LEVEL
            var[1] = Convert.ToInt32(value[1]); // STRENGHT
            var[2] = Convert.ToInt32(value[2]); // DEXTERITY
            var[3] = Convert.ToInt32(value[3]); // AGILITY
            var[4] = Convert.ToInt32(value[4]); // CONSTITUTION
            var[5] = Convert.ToInt32(value[5]); // INTELLIGENCE
            var[6] = Convert.ToInt32(value[6]); // WISDOM
            var[7] = Convert.ToInt32(value[7]); // WILL
            var[8] = Convert.ToInt32(value[8]); // MIND
            var[9] = Convert.ToInt32(value[9]); // CHARISMA
        }

        /// <summary>
        /// Obtém os dados de incremento de classe.
        /// </summary>
        /// <param name="stat"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public int GetIncrementStat(Stats stat, params int[] value) {
            switch (stat) {
                case Stats.MaxHP: return GetIncrementStat(inc_MaxHP, value);
                case Stats.MaxMP: return GetIncrementStat(inc_MaxMP, value);
                case Stats.MaxSP: return GetIncrementStat(inc_MaxSP, value);
                case Stats.RegenHP: return GetIncrementStat(inc_RegenHP, value);
                case Stats.RegenMP: return GetIncrementStat(inc_RegenMP, value);
                case Stats.RegenSP: return GetIncrementStat(inc_RegenSP, value);
                case Stats.DamageSuppression: return GetIncrementStat(inc_DamageSuppression, value);
                case Stats.Enmity: return GetIncrementStat(inc_Enmity, value);
                case Stats.AdditionalDamage: return GetIncrementStat(inc_AdditionalDamage, value);
                case Stats.HealingPower: return GetIncrementStat(inc_HealingPower, value);
                case Stats.Concentration: return GetIncrementStat(inc_Concentration, value);
                case Stats.AttackSpeed: return GetIncrementStat(inc_AttackSpeed, value);
                case Stats.CastSpeed: return GetIncrementStat(inc_CastSpeed, value);
                case Stats.Attack: return GetIncrementStat(inc_Attack, value);
                case Stats.Accuracy: return GetIncrementStat(inc_Accuracy, value);
                case Stats.Defense: return GetIncrementStat(inc_Defense, value);
                case Stats.Evasion: return GetIncrementStat(inc_Evasion, value);
                case Stats.Block: return GetIncrementStat(inc_Block, value);
                case Stats.Parry: return GetIncrementStat(inc_Parry, value);
                case Stats.CriticalRate: return GetIncrementStat(inc_CriticalRate, value);
                case Stats.CriticalDamage: return GetIncrementStat(inc_CriticalDamage, value);
                case Stats.MagicAttack: return GetIncrementStat(inc_MagicAttack, value);
                case Stats.MagicAccuracy: return GetIncrementStat(inc_MagicAccuracy, value);
                case Stats.MagicDefense: return GetIncrementStat(inc_MagicDefense, value);
                case Stats.MagicResist: return GetIncrementStat(inc_MagicResist, value);
                case Stats.MagicCriticalRate: return GetIncrementStat(inc_MagicCriticalRate, value);
                case Stats.MagicCriticalDamage: return GetIncrementStat(inc_MagicCriticalDamage, value);
                case Stats.AttributeFire: return GetIncrementStat(inc_AttributeFire, value);
                case Stats.AttributeWater: return GetIncrementStat(inc_AttributeWater, value);
                case Stats.AttributeEarth: return GetIncrementStat(inc_AttributeEarth, value);
                case Stats.AttributeWind: return GetIncrementStat(inc_AttributeWind, value);
                case Stats.ResistStun: return GetIncrementStat(inc_ResistStun, value);
                case Stats.ResistParalysis: return GetIncrementStat(inc_ResistParalysis, value);
                case Stats.ResistSilence: return GetIncrementStat(inc_ResistSilence, value);
                case Stats.ResistBlind: return GetIncrementStat(inc_ResistBlind, value);
                case Stats.ResistCriticalRate: return GetIncrementStat(inc_ResistCriticalRate, value);
                case Stats.ResistCriticalDamage: return GetIncrementStat(inc_ResistCriticalDamage, value);
                case Stats.ResistMagicCriticalRate: return GetIncrementStat(inc_ResistMagicCriticalRate, value);
                case Stats.ResistMagicCriticalDamage: return GetIncrementStat(inc_ResistMagicCriticalDamage, value);
            }

            return 0;
        }

        /// <summary>
        /// Obtém os dados de incremento de classe.
        /// </summary>
        /// <param name="var"></param>
        /// <param name="stat"></param>
        /// <returns></returns>
        private int GetIncrementStat(int[] var, int[] stat) {
            var result = 0;
            result += stat[0] * var[0]; // LEVEL
            result += stat[1] * var[1]; // STRENGHT
            result += stat[2] * var[2]; // DEXTERITY
            result += stat[3] * var[3]; // AGILITY
            result += stat[4] * var[4]; // CONSTITUTION
            result += stat[5] * var[5]; // INTELLIGENCE
            result += stat[6] * var[6]; // WISDOM
            result += stat[7] * var[7]; // WILL
            result += stat[8] * var[8]; // MIND
            result += stat[9] * var[9]; // CHARISMA
            return result;
        }
 
        /// <summary>
        /// Limpa todos os dados
        /// </summary>
        public void Clear()  {
            Strenght = Dexterity = Agility = Constitution = Intelligence = Wisdom = Will = Mind = Charisma = Points = 0;
            Array.Clear(inc_MaxHP, 0, MAX_STATS);
            Array.Clear(inc_MaxMP, 0, MAX_STATS);
            Array.Clear(inc_MaxSP, 0, MAX_STATS);
            Array.Clear(inc_RegenHP, 0, MAX_STATS);
            Array.Clear(inc_RegenMP, 0, MAX_STATS);
            Array.Clear(inc_RegenSP, 0, MAX_STATS);
            Array.Clear(inc_DamageSuppression, 0, MAX_STATS);
            Array.Clear(inc_Enmity, 0, MAX_STATS);
            Array.Clear(inc_AdditionalDamage, 0, MAX_STATS);
            Array.Clear(inc_HealingPower, 0, MAX_STATS);
            Array.Clear(inc_Concentration, 0, MAX_STATS);
            Array.Clear(inc_AttackSpeed, 0, MAX_STATS);
            Array.Clear(inc_CastSpeed, 0, MAX_STATS);
            Array.Clear(inc_Attack, 0, MAX_STATS);
            Array.Clear(inc_Accuracy, 0, MAX_STATS);
            Array.Clear(inc_Defense, 0, MAX_STATS);
            Array.Clear(inc_Evasion, 0, MAX_STATS);
            Array.Clear(inc_Block, 0, MAX_STATS);
            Array.Clear(inc_Parry, 0, MAX_STATS);
            Array.Clear(inc_CriticalRate, 0, MAX_STATS);
            Array.Clear(inc_CriticalDamage, 0, MAX_STATS);
            Array.Clear(inc_MagicAttack, 0, MAX_STATS);
            Array.Clear(inc_MagicAccuracy, 0, MAX_STATS);
            Array.Clear(inc_MagicDefense, 0, MAX_STATS);
            Array.Clear(inc_MagicResist, 0, MAX_STATS);
            Array.Clear(inc_MagicCriticalRate, 0, MAX_STATS);
            Array.Clear(inc_MagicCriticalDamage, 0, MAX_STATS);
            Array.Clear(inc_AttributeFire, 0, MAX_STATS);
            Array.Clear(inc_AttributeWater, 0, MAX_STATS);
            Array.Clear(inc_AttributeEarth, 0, MAX_STATS);
            Array.Clear(inc_AttributeWind, 0, MAX_STATS);
            Array.Clear(inc_ResistStun, 0, MAX_STATS);
            Array.Clear(inc_ResistParalysis, 0, MAX_STATS);
            Array.Clear(inc_ResistSilence, 0, MAX_STATS);
            Array.Clear(inc_ResistBlind, 0, MAX_STATS);
            Array.Clear(inc_ResistCriticalRate, 0, MAX_STATS);
            Array.Clear(inc_ResistCriticalDamage, 0, MAX_STATS);
            Array.Clear(inc_ResistMagicCriticalRate, 0, MAX_STATS);
            Array.Clear(inc_ResistMagicCriticalDamage, 0, MAX_STATS);
        }
    }
}
