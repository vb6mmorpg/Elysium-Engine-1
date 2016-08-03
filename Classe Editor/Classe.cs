using System;

/*      
        CALCULO DE ATRIBUTOS:
        
        # exemplo básico
        var totalStrenght = base + (level * strPerLevel)

        # não somente level, mas todos os atributos podem influenciar os outros. A configuração permite que 1 ponto em carisma
        possa aumentar 1 de ataque, essa escolha, fica responsável no momento da edição da classe.
        Portanto, desse modo, há a possibilidade de várias combinações de classes.

        # quase todos os atributos seguem essa fórmula. O calculo é feito pelo seguinte método: IncrementCalc(int[] var)
        var attack = attackBase + (level * attackPerLevel)
        attack += (strenght * attackPerStr)
        attack += (dexterity * attackPerDex)
        attack += (agility * attackPerAgi)
        attack += (constitution * attackPerCon)
        attack += (intelligence * attackPerInt)
        attack += (wisdom * attackPerWis)
        attack += (will  * attackPerWill)
        attack += (mind * attackPerMin)
        attack += (charisma * attackPerCha)
*/

namespace Classe_Editor {
    public class Classe {
        /// <summary>
        /// Todos os atributos.
        /// </summary>


        /// <summary>
        /// Variáveis de atributos de base.
        /// </summary>
        #region Base Var
        private int[] baseData = new int[(int)Stat.Count];
        private int sim_level, sim_Strenght, sim_Dexterity, sim_Agility, sim_Constitution, sim_Intelligence, sim_Wisdom, sim_Will, sim_Mind, sim_Charisma; 
        #endregion
    
        #region Increment Property
        public int IncrementID { get; set; }
        public string IncrementName { get; set; }
        #endregion

        /// <summary>
        /// Array de incremento.
        /// </summary>
        #region Increment Var
        private int inc_Strenght, inc_Dexterity, inc_Agility, inc_Constitution, inc_Intelligence, inc_Wisdom, inc_Will, inc_Mind, inc_Charisma, inc_Point;
        private int[] inc_MaxHP = new int[10];
        private int[] inc_MaxMP = new int[10];
        private int[] inc_MaxSP = new int[10];
        private int[] inc_RegenHP = new int[10];
        private int[] inc_RegenMP = new int[10];
        private int[] inc_RegenSP = new int[10];
        private int[] inc_DamageSuppression = new int[10];
        private int[] inc_Enmity= new int[10];
        private int[] inc_AdditionalDamage= new int[10];
        private int[] inc_HealingPower= new int[10];
        private int[] inc_Concentration = new int[10];
        private int[] inc_AttackSpeed= new int[10];
        private int[] inc_CastSpeed = new int[10];
        private int[] inc_Attack= new int[10];
        private int[] inc_Accuracy= new int[10];
        private int[] inc_Defense= new int[10];
        private int[] inc_Evasion= new int[10];
        private int[] inc_Block= new int[10];
        private int[] inc_Parry = new int[10];
        private int[] inc_CriticalRate= new int[10];
        private int[] inc_CriticalDamage = new int[10];
        private int[] inc_MagicAttack= new int[10];
        private int[] inc_MagicAccuracy= new int[10];
        private int[] inc_MagicDefense= new int[10];
        private int[] inc_MagicResist= new int[10];
        private int[] inc_SpellCriticalRate= new int[10];      
        private int[] inc_SpellCriticalDamage = new int[10];
        private int[] inc_AttributeFire= new int[10];
        private int[] inc_AttributeWater= new int[10];
        private int[] inc_AttributeEarth= new int[10];
        private int[] inc_AttributeWind = new int[10];
        private int[] inc_ResistStun= new int[10];
        private int[] inc_ResistParalysis= new int[10];
        private int[] inc_ResistSilence= new int[10];
        private int[] inc_ResistBlind = new int[10];
        private int[] inc_ResistCriticalRate= new int[10];
        private int[] inc_ResistCriticalDamage= new int[10];
        private int[] inc_ResistSpellCriticalRate= new int[10];
        private int[] inc_ResistSpellCriticalDamage = new int[10];
        #endregion

        /// <summary>
        /// Retornam o atributo juntamente com o cálculo.
        /// </summary>
        #region Base Property
        public int ID { get; set; }
        public int ClasseIncrementID { get; set; }
        public int ClasseRaceID { get; set; }
        public string ClasseName { get; set; }
        public int Gender { get; set; }
        public int SpriteFemale { get; set; }
        public int SpriteMale { get; set; }
        public int MaxHP {
            get {
                var result = baseData[(int)Stat.MaxHP];
                result += Level * inc_MaxHP[0];
                result += Strenght * inc_MaxHP[1];
                result += Dexterity * inc_MaxHP[2];
                result += Agility * inc_MaxHP[3];
                result += Constitution * inc_MaxHP[4];
                result += Intelligence * inc_MaxHP[5];
                result += Wisdom * inc_MaxHP[6];
                result += Will * inc_MaxMP[7];
                result += Mind * inc_MaxHP[8];
                result += Charisma * inc_MaxHP[9];
                return result;
            }
        }
        public int MaxMP {
            get {
                var result = baseData[(int)Stat.MaxMP];
                result += Level * inc_MaxMP[0];
                result += Strenght * inc_MaxMP[1];
                result += Dexterity * inc_MaxMP[2];
                result += Agility * inc_MaxMP[3];
                result += Constitution * inc_MaxMP[4];
                result += Intelligence * inc_MaxMP[5];
                result += Wisdom * inc_MaxMP[6];
                result += Will * inc_MaxMP[7];
                result += Mind * inc_MaxMP[8];
                result += Charisma * inc_MaxMP[9];
                return result;
            }
        }
        public int MaxSP {
            get {
                var result = baseData[(int)Stat.MaxSP];
                result += Level * inc_MaxSP[0];
                result += Strenght * inc_MaxSP[1];
                result += Dexterity * inc_MaxSP[2];
                result += Agility * inc_MaxSP[3];
                result += Constitution * inc_MaxSP[4];
                result += Intelligence * inc_MaxSP[5];
                result += Wisdom * inc_MaxSP[6];
                result += Will * inc_MaxSP[7];
                result += Mind * inc_MaxSP[8];
                result += Charisma * inc_MaxSP[9];
                return result;
            }
        }
        public int RegenHP {
            get {
                return baseData[(int)Stat.RegenHP] + IncrementCalc(inc_RegenHP);
            }
        }
        public int RegenMP {
            get {
                return baseData[(int)Stat.RegenMP] + IncrementCalc(inc_RegenMP);
            }
        }
        public int RegenSP {
            get {
                return baseData[(int)Stat.RegenSP] + IncrementCalc(inc_RegenSP);
            }
        }
        public int Level {
            get { return baseData[(int)Stat.Level] + sim_level; }
        }
        public int Strenght {
            get { return baseData[(int)Stat.Strenght] + sim_Strenght + (Level * inc_Strenght); }
        }
        public int Dexterity {
            get { return baseData[(int)Stat.Dexterity] + sim_Dexterity + (Level * inc_Dexterity); }
        }
        public int Agility {
            get { return baseData[(int)Stat.Agility] + sim_Agility + (Level * inc_Agility); }
        }
        public int Constitution {
            get { return baseData[(int)Stat.Constitution] + sim_Constitution + (Level * inc_Constitution); }
        }
        public int Intelligence {
            get { return baseData[(int)Stat.Intelligence] + sim_Intelligence + (Level * inc_Intelligence); }
        }
        public int Wisdom {
            get { return baseData[(int)Stat.Wisdom] + sim_Wisdom + (Level * inc_Wisdom); }
        }
        public int Will {
            get { return baseData[(int)Stat.Will] + sim_Will + (Level * inc_Will); }
        }
        public int Mind {
            get { return baseData[(int)Stat.Mind] + sim_Mind + (Level * inc_Mind); }
        }
        public int Charisma {
            get { return baseData[(int)Stat.Charisma] + sim_Charisma + (Level * inc_Charisma); }
        }
        public int Point {
            get { return baseData[(int)Stat.Point] + (Level * inc_Point); }
        }
        public int DamageSuppression {
            get {
                return baseData[(int)Stat.DamageSuppression] + IncrementCalc(inc_DamageSuppression);
            }
        }
        public int Enmity {
            get {
                return baseData[(int)Stat.Enmity] + IncrementCalc(inc_Enmity);
            }
        }
        public int AdditionalDamage {
            get {
                return baseData[(int)Stat.AdditionalDamage] + IncrementCalc(inc_AdditionalDamage);
            }
        }
        public int HealingPower {
            get {
                return baseData[(int)Stat.HealingPower] + IncrementCalc(inc_HealingPower);
            }
        }
        public int Concentration {
            get {
                return baseData[(int)Stat.Concentration] + IncrementCalc(inc_Concentration);
            }
        }
        public int AttackSpeed {
            get {
                return baseData[(int)Stat.AttackSpeed] + IncrementCalc(inc_AttackSpeed);
            }
        }
        public int CastSpeed {
            get {
                return baseData[(int)Stat.CastSpeed] + IncrementCalc(inc_CastSpeed);
            }
        }
        public int Attack {
            get {
                return baseData[(int)Stat.Attack] + IncrementCalc(inc_Attack);
            }
        }
        public int Accuracy {
            get {
                return baseData[(int)Stat.Accuracy] + IncrementCalc(inc_Accuracy);
            }
        }
        public int Defense {
            get {
                return baseData[(int)Stat.Defense] + IncrementCalc(inc_Defense);
            }
        }
        public int Evasion {
            get {
                return baseData[(int)Stat.Evasion] + IncrementCalc(inc_Evasion);
            }
        }
        public int Block {
            get {
                return baseData[(int)Stat.Block] + IncrementCalc(inc_Block);
            }
        }
        public int Parry {
            get {
                return baseData[(int)Stat.Parry] + IncrementCalc(inc_Parry);
            }
        }
        public int CriticalRate {
            get {
                return baseData[(int)Stat.CriticalRate] + IncrementCalc(inc_CriticalRate);
            }
        }
        public int CriticalDamage {
            get {
                return baseData[(int)Stat.CriticalDamage] + IncrementCalc(inc_CriticalDamage);
            }
        }
        public int MagicAttack {
            get {
                return baseData[(int)Stat.MagicAttack] + IncrementCalc(inc_MagicAttack);
            }
        }
        public int MagicAccuracy {
            get {
                return baseData[(int)Stat.MagicAccuracy] + IncrementCalc(inc_MagicAccuracy);
            }
        }
        public int MagicDefense {
            get {
                return baseData[(int)Stat.MagicDefense] + IncrementCalc(inc_MagicDefense);
            }
        }
        public int MagicResist {
            get {
                return baseData[(int)Stat.MagicResist] + IncrementCalc(inc_MagicResist);
            }
        }
        public int MagicCriticalRate {
            get {
                return baseData[(int)Stat.MagicCriticalRate] + IncrementCalc(inc_SpellCriticalRate);
            }
        }
        public int MagicCriticalDamage {
            get {
                return baseData[(int)Stat.MagicCriticalDamage] + IncrementCalc(inc_SpellCriticalDamage);
            }
        }
        public int AttributeFire {
            get {
                return baseData[(int)Stat.AttributeFire] + IncrementCalc(inc_AttributeFire);
            }
        }
        public int AttributeWater {
            get {
                return baseData[(int)Stat.AttributeWater] + IncrementCalc(inc_AttributeWater);
            }
        }
        public int AttributeEarth {
            get {
                return baseData[(int)Stat.AttributeEarth] + IncrementCalc(inc_AttributeEarth);
            }
        }
        public int AttributeWind {
            get {
                return baseData[(int)Stat.AttributeWind] + IncrementCalc(inc_AttributeWind);
            }
        }
        public int ResistStun {
            get {
                return baseData[(int)Stat.ResistStun] + IncrementCalc(inc_ResistStun);
            }
        }
        public int ResistParalysis {
            get {
                return baseData[(int)Stat.ResistParalysis] + IncrementCalc(inc_ResistParalysis);
            }
        }
        public int ResistSilence {
            get {
                return baseData[(int)Stat.ResistSilence] + IncrementCalc(inc_ResistSilence);
            }
        }
        public int ResistBlind {
            get {
                return baseData[(int)Stat.ResistBlind] + IncrementCalc(inc_ResistBlind);
            }
        }
        public int ResistCriticalRate {
            get {
                return baseData[(int)Stat.ResistCriticalRate] + IncrementCalc(inc_ResistCriticalRate);
            }
        }
        public int ResistCriticalDamage {
            get {
                return baseData[(int)Stat.ResistCriticalDamage] + IncrementCalc(inc_ResistCriticalDamage);
            }
        }
        public int ResistMagicCriticalRate {
            get {
                return baseData[(int)Stat.ResistMagicCriticalRate] + IncrementCalc(inc_ResistSpellCriticalRate);
            }
        }
        public int ResistMagicCriticalDamage {
            get {
                return baseData[(int)Stat.ResistMagicCriticalDamage] + IncrementCalc(inc_ResistSpellCriticalDamage);
            }
        }
        #endregion


        /// <summary>
        /// Altera o valor do atributo base.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        public void SetBaseStat(Stat type, int value) {
            baseData[(int)type] = (int)value; 
        }

        /// <summary>
        /// Obtém o valor do atributo base.
        /// </summary>
        /// <param name="stat"></param>
        /// <returns></returns>
        public int GetBaseStat(Stat stat) {
            return baseData[(int)stat];
        }
        
        /// <summary>
        /// Altera o valor do incremento.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        /// <param name="slot"></param>
        public void SetIncrementStat(Stat type, int value, int slot = 0) {
            switch(type) {
                case Stat.Strenght:
                    inc_Strenght = value;
                    break;
                case Stat.Dexterity:
                    inc_Dexterity = value;
                    break;
                case Stat.Agility:
                    inc_Agility = value;
                    break;
                case Stat.Constitution:
                    inc_Constitution = value;
                    break;
                case Stat.Intelligence:
                    inc_Intelligence = value;
                    break;
                case Stat.Wisdom:
                    inc_Wisdom = value;
                    break;
                case Stat.Will:
                    inc_Will = value;
                    break;
                case Stat.Charisma:
                    inc_Charisma = value;
                    break;
                case Stat.Mind:
                    inc_Mind = value;
                    break;
                case Stat.Point:
                    inc_Point = value;
                    break;
                case Stat.MaxHP:
                    inc_MaxHP[slot] = value;
                    break;
                case Stat.MaxMP:
                    inc_MaxMP[slot] = value;
                    break;
                case Stat.MaxSP:
                    inc_MaxSP[slot] = value;
                    break;
                case Stat.RegenHP:
                    inc_RegenHP[slot] = value;
                    break;
                case Stat.RegenMP:
                    inc_RegenMP[slot] = value;
                    break;
                case Stat.RegenSP:
                    inc_RegenSP[slot] = value;
                    break;
                case Stat.DamageSuppression:
                    inc_DamageSuppression[slot] = value;
                    break;
                case Stat.Enmity:
                    inc_Enmity[slot] = value;
                    break;
                case Stat.AdditionalDamage:
                    inc_AdditionalDamage[slot] = value;
                    break;
                case Stat.HealingPower:
                    inc_HealingPower[slot] = value;
                    break;
                case Stat.Concentration:
                    inc_Concentration[slot] = value;
                    break;
                case Stat.AttackSpeed:
                    inc_AttackSpeed[slot] = value;
                    break;
                case Stat.CastSpeed:
                    inc_CastSpeed[slot] = value;
                    break;
                case Stat.Attack:
                    inc_Attack[slot] = value;
                    break;
                case Stat.Accuracy:
                    inc_Accuracy[slot] = value;
                    break;
                case Stat.Defense:
                    inc_Defense[slot] = value;
                    break;
                case Stat.Evasion:
                    inc_Evasion[slot] = value;
                    break;
                case Stat.Block:
                    inc_Block[slot] = value;
                    break;
                case Stat.Parry:
                    inc_Parry[slot] = value;
                    break;
                case Stat.CriticalRate:
                    inc_CriticalRate[slot] = value;
                    break;
                case Stat.CriticalDamage:
                    inc_CriticalDamage[slot] = value;
                    break;
                case Stat.MagicCriticalRate:
                    inc_SpellCriticalRate[slot] = value;
                    break;
                case Stat.MagicCriticalDamage:
                    inc_SpellCriticalDamage[slot] = value;
                    break;
                case Stat.MagicAttack:
                    inc_MagicAttack[slot] = value;
                    break;
                case Stat.MagicAccuracy:
                    inc_MagicAccuracy[slot] = value;
                    break;
                case Stat.MagicDefense:
                    inc_MagicDefense[slot] = value;
                    break;
                case Stat.MagicResist:
                    inc_MagicResist[slot] = value;
                    break;
                case Stat.AttributeFire:
                    inc_AttributeFire[slot] = value;
                    break;
                case Stat.AttributeWater:
                    inc_AttributeWater[slot] = value;
                    break;
                case Stat.AttributeEarth:
                    inc_AttributeEarth[slot] = value;
                    break;
                case Stat.AttributeWind:
                    inc_AttributeWind[slot] = value;
                    break;
                case Stat.ResistStun:
                    inc_ResistStun[slot] = value;
                    break;
                case Stat.ResistParalysis:
                    inc_ResistParalysis[slot] = value;
                    break;
                case Stat.ResistSilence:
                    inc_ResistSilence[slot] = value;
                    break;
                case Stat.ResistBlind:
                    inc_ResistBlind[slot] = value;
                    break;
                case Stat.ResistCriticalRate:
                    inc_ResistCriticalRate[slot] = value;
                    break;
                case Stat.ResistCriticalDamage:
                    inc_ResistCriticalDamage[slot] = value;
                    break;
                case Stat.ResistMagicCriticalRate:
                    inc_ResistSpellCriticalRate[slot] = value;
                    break;
                case Stat.ResistMagicCriticalDamage:
                    inc_ResistSpellCriticalDamage[slot] = value;
                    break;
            }
        }

        /// <summary>
        /// Obtém o valor do incremento.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="slot"></param>
        /// <returns></returns>
        public int GetIncrementStat(Stat type, int slot = 0) {
            if (type == Stat.Strenght) { return inc_Strenght; }
            if (type == Stat.Dexterity) { return inc_Dexterity; }
            if (type == Stat.Agility) { return inc_Agility; }
            if (type == Stat.Constitution) { return inc_Constitution; }
            if (type == Stat.Intelligence) { return inc_Intelligence; }
            if (type == Stat.Wisdom) { return inc_Wisdom; }
            if (type == Stat.Will) { return inc_Will; }
            if (type == Stat.Mind) { return inc_Mind; }
            if (type == Stat.Charisma) { return inc_Charisma; }
            if (type == Stat.Point) { return inc_Point; }
            if (type == Stat.MaxHP) { return inc_MaxHP[slot]; }
            if (type == Stat.MaxMP) { return inc_MaxMP[slot]; }
            if (type == Stat.MaxSP) { return inc_MaxSP[slot]; }
            if (type == Stat.RegenHP) { return inc_RegenHP[slot]; }
            if (type == Stat.RegenMP) { return inc_RegenMP[slot]; }
            if (type == Stat.RegenSP) { return inc_RegenSP[slot]; }
            if (type == Stat.DamageSuppression) { return inc_DamageSuppression[slot]; }
            if (type == Stat.Enmity) { return inc_Enmity[slot]; }
            if (type == Stat.AdditionalDamage) { return inc_AdditionalDamage[slot]; }
            if (type == Stat.HealingPower) { return inc_HealingPower[slot]; }
            if (type == Stat.Concentration) { return inc_Concentration[slot]; }
            if (type == Stat.AttackSpeed) { return inc_AttackSpeed[slot]; }
            if (type == Stat.CastSpeed) { return inc_CastSpeed[slot]; }
            if (type == Stat.Attack) { return inc_Attack[slot]; }
            if (type == Stat.Accuracy) { return inc_Accuracy[slot]; }
            if (type == Stat.Defense) { return inc_Defense[slot]; }
            if (type == Stat.Evasion) { return inc_Evasion[slot]; }
            if (type == Stat.Block) { return inc_Block[slot]; }
            if (type == Stat.Parry) { return inc_Parry[slot]; }
            if (type == Stat.CriticalRate) { return inc_CriticalRate[slot]; }
            if (type == Stat.CriticalDamage) { return inc_CriticalDamage[slot]; }
            if (type == Stat.MagicAttack) { return inc_MagicAttack[slot]; }
            if (type == Stat.MagicAccuracy) { return inc_MagicAccuracy[slot]; }
            if (type == Stat.MagicDefense) { return inc_MagicDefense[slot]; }
            if (type == Stat.MagicResist) { return inc_MagicResist[slot]; }
            if (type == Stat.MagicCriticalRate) { return inc_SpellCriticalRate[slot]; }
            if (type == Stat.MagicCriticalDamage) { return inc_SpellCriticalDamage[slot]; }
            if (type == Stat.AttributeFire) { return inc_AttributeFire[slot]; }
            if (type == Stat.AttributeWater) { return inc_AttributeWater[slot]; }
            if (type == Stat.AttributeEarth) { return inc_AttributeEarth[slot]; }
            if (type == Stat.AttributeWind) { return inc_AttributeWind[slot]; }
            if (type == Stat.ResistStun) { return inc_ResistStun[slot]; }
            if (type == Stat.ResistParalysis) { return inc_ResistParalysis[slot]; }
            if (type == Stat.ResistSilence) { return inc_ResistSilence[slot]; }
            if (type == Stat.ResistBlind) { return inc_ResistBlind[slot]; }
            if (type == Stat.ResistCriticalRate) { return inc_ResistCriticalRate[slot]; }
            if (type == Stat.ResistCriticalDamage) { return inc_ResistCriticalDamage[slot]; }
            if (type == Stat.ResistMagicCriticalRate) { return inc_ResistSpellCriticalRate[slot]; }
            if (type == Stat.ResistMagicCriticalDamage) { return inc_ResistSpellCriticalDamage[slot]; }
 
            return 0;
        }

        /// <summary>
        /// Usado apenas pelo simulador, incrementa ou decrementa o atributo selecioando.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="increase"></param>
        public void SetIncDecStat(Stat type, bool increase) {
            if (increase) {
                switch (type) {
                    case Stat.Level:
                        if (sim_level == int.MaxValue) { return; }
                        sim_level++;
                        break;
                    case Stat.Strenght:
                        if (sim_Strenght == int.MaxValue) { return; }
                        sim_Strenght++;
                        break;
                    case Stat.Dexterity:
                        if (sim_Dexterity == int.MaxValue) { return; }
                        sim_Dexterity++;
                        break;
                    case Stat.Agility:
                        if (sim_Agility == int.MaxValue) { return; }
                        sim_Agility++;
                        break;
                    case Stat.Constitution:
                        if (sim_Constitution == int.MaxValue) { return; }
                        sim_Constitution++;
                        break;
                    case Stat.Intelligence:
                        if (sim_Intelligence == int.MaxValue) { return; }
                        sim_Intelligence++;
                        break;
                    case Stat.Wisdom:
                        if (sim_Wisdom == int.MaxValue) { return; }
                        sim_Wisdom++;
                        break;
                    case Stat.Will:
                        if (sim_Will == int.MaxValue) { return; }
                        sim_Will++;
                        break;
                    case Stat.Mind:
                        if (sim_Mind >= int.MaxValue) { return; }
                        sim_Mind++;
                        break;
                    case Stat.Charisma:
                        if (sim_Charisma >= int.MaxValue) { return; }
                        sim_Charisma++;
                        break;
                }
            }
            else {
                switch (type) {
                    case Stat.Level:
                        if (sim_level == 0) { return; }
                        sim_level--;
                        break;
                    case Stat.Strenght:
                        if (sim_Strenght == 0) { return; }
                        sim_Strenght--;
                        break;
                    case Stat.Dexterity:
                        if (sim_Dexterity == 0) { return; }
                        sim_Dexterity--;
                        break;
                    case Stat.Agility:
                        if (sim_Agility == 0) { return; }
                        sim_Agility--;
                        break;
                    case Stat.Constitution:
                        if (sim_Constitution == 0) { return; }
                        sim_Constitution--;
                        break;
                    case Stat.Intelligence:
                        if (sim_Intelligence == 0) { return; }
                        sim_Intelligence--;
                        break;
                    case Stat.Wisdom:
                        if (sim_Wisdom == 0) { return; }
                        sim_Wisdom--;
                        break;
                    case Stat.Will:
                        if (sim_Will == 0) { return; }
                        sim_Will--;
                        break;
                    case Stat.Mind:
                        if (sim_Mind == 0) { return; }
                        sim_Mind--;
                        break;
                    case Stat.Charisma:
                        if (sim_Charisma == 0) { return; }
                        sim_Charisma--;
                        break;
                }
            }
        }

        /// <summary>
        /// Usado apenas pelo simulador, reseta os atributos.
        /// </summary>
        public void ResetSimulatorIncrementDecrementStat() {
            sim_level = sim_Strenght = sim_Dexterity = sim_Agility = sim_Constitution = sim_Intelligence = sim_Wisdom = sim_Will = sim_Mind = sim_Charisma = 0;
        }

        /// <summary>
        /// Calcula um incremento e retorna o valor de acordo com os atributos passados.
        /// </summary>
        /// <param name="var">Atributos</param>
        /// <returns></returns>
        public int IncrementCalc(int[] var) {
            var result = Level * var[0];
            result += Strenght * var[1];
            result += Dexterity * var[2];
            result += Agility * var[3];
            result += Constitution * var[4];
            result += Intelligence * var[5];
            result += Wisdom * var[6];
            result += Will * var[7];
            result += Mind * var[8];
            result += Charisma * var[9];
            return result;
        }

        /// <summary>
        /// Limpa todos os dados de incremento.
        /// </summary>
        public void ClearIncrementData() {
            const int lenght = 10;
            inc_Strenght = inc_Dexterity = inc_Agility = inc_Constitution = inc_Intelligence = inc_Wisdom = inc_Will = inc_Mind = inc_Charisma = inc_Point = 0;
            Array.Clear(inc_MaxHP, 0, lenght);
            Array.Clear(inc_MaxMP, 0, lenght);
            Array.Clear(inc_MaxSP, 0, lenght);
            Array.Clear(inc_RegenHP, 0, lenght);
            Array.Clear(inc_RegenMP, 0, lenght);
            Array.Clear(inc_RegenSP, 0, lenght);
            Array.Clear(inc_DamageSuppression, 0, lenght);
            Array.Clear(inc_Enmity, 0, lenght);
            Array.Clear(inc_AdditionalDamage, 0, lenght);
            Array.Clear(inc_HealingPower, 0, lenght);
            Array.Clear(inc_Concentration, 0, lenght);
            Array.Clear(inc_AttackSpeed, 0, lenght);
            Array.Clear(inc_CastSpeed, 0, lenght);
            Array.Clear(inc_Attack, 0, lenght);
            Array.Clear(inc_Accuracy, 0, lenght);
            Array.Clear(inc_Defense, 0, lenght);
            Array.Clear(inc_Evasion, 0, lenght);
            Array.Clear(inc_Block, 0, lenght);
            Array.Clear(inc_Parry, 0, lenght);
            Array.Clear(inc_CriticalRate, 0, lenght);
            Array.Clear(inc_CriticalDamage, 0, lenght);
            Array.Clear(inc_MagicAttack, 0, lenght);
            Array.Clear(inc_MagicAccuracy, 0, lenght);
            Array.Clear(inc_MagicDefense, 0, lenght);
            Array.Clear(inc_MagicResist, 0, lenght);
            Array.Clear(inc_SpellCriticalRate, 0, lenght);
            Array.Clear(inc_SpellCriticalDamage, 0, lenght);
            Array.Clear(inc_AttributeFire, 0, lenght);
            Array.Clear(inc_AttributeWater, 0, lenght);
            Array.Clear(inc_AttributeEarth, 0, lenght);
            Array.Clear(inc_AttributeWind, 0, lenght);
            Array.Clear(inc_ResistStun, 0, lenght);
            Array.Clear(inc_ResistParalysis, 0, lenght);
            Array.Clear(inc_ResistSilence, 0, lenght);
            Array.Clear(inc_ResistBlind, 0, lenght);
            Array.Clear(inc_ResistCriticalRate, 0, lenght);
            Array.Clear(inc_ResistCriticalDamage, 0, lenght);
            Array.Clear(inc_ResistSpellCriticalRate, 0, lenght);
            Array.Clear(inc_ResistSpellCriticalDamage, 0, lenght);
        }
    }
}
