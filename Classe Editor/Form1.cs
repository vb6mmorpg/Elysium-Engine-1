using System;
using System.Windows.Forms;

namespace Classe_Editor {
    public partial class Form1 : Form {
        string SelectedButton { get; set; } = string.Empty;

        public Form1() {
            InitializeComponent();
        }

        /// <summary>
        /// Obtem as informaçãoes iniciais e distrbui para o combobox.
        /// </summary>
        private void InitialClasseBase() {
            base_attribute.Items.Clear();
            base_increment.Items.Clear();
            inc_increment.Items.Clear();
            Static.ListClasseBase.Clear();
            //limpa todos os dados (refresh) e prepara para novas informações

            var data = MySQL.InitialClasseBase();

            foreach(var item in data) {
                Static.ListClasseBase.Add(item.ID);
                base_attribute.Items.Add(item.Description);
            }

            base_refresh.Enabled = true;
            inc_refresh.Enabled = true;
        }

        /// <summary>
        /// Obtem as informações iniciais e distribui para o combobox.
        /// </summary>
        private void InitialClasseIncrement() {
            inc_increment.Items.Clear();
            base_increment.Items.Clear();
            Static.ListClasseIncrement.Clear();
            //limpa todos os dados (refresh) e prepara para novas informações

            var data = MySQL.InitialClasseIncrement();

            foreach (var item in data) {
                Static.ListClasseIncrement.Add(item.ID);
                base_increment.Items.Add(item.Description);
                inc_increment.Items.Add(item.Description);
            }

            base_refresh.Enabled = true;
            inc_refresh.Enabled = true;
        }

        #region Menu Item - New Base, New Increment, App Exit
        /// <summary>
        /// Insere uma nova classe ao banco.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param> 
        private void NewBase_MenuItem_Click(object sender, EventArgs e) {
            if (MySQL.ExistClasseID(Static.Classes.ID)) {
                MessageBox.Show("A atual ID já está sendo usada por outra classe.", "Erro");
                return;
            }

            MySQL.InsertClasseBase();

            ClarBaseTextBox();
            RefreshSimulator();

            InitialClasseBase();
            InitialClasseIncrement();
        }
 
        /// <summary>
        /// Insere um novo incremento ao banco.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewInc_MenuItem_Click(object sender, EventArgs e) {
            if (MySQL.ExistIncrementID(Static.Classes.IncrementID)) {
                MessageBox.Show("A atual ID já está sendo usada por outra classe.", "Erro");
                return;
            }

            MySQL.InsertClasseIncrement();

            ClearIncrementTextBox();
            RefreshIncrement(true);
            RefreshSimulator();

            InitialClasseBase();
            InitialClasseIncrement();
        }

        /// <summary>
        /// Fecha o programa.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Quit_MenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }
        #endregion

        #region TextBox & Info Update
        public void RefreshIncrement(bool clear = false) {
            if (clear) { inc_increment.SelectedIndex = -1; }

            inc_name.Text = Static.Classes.IncrementName;
            inc_id.Text = Static.Classes.IncrementID.ToString();

            inc_str.Text = Static.Classes.GetIncrementStat(Stat.Strenght).ToString();
            inc_dex.Text = Static.Classes.GetIncrementStat(Stat.Dexterity).ToString();
            inc_agi.Text = Static.Classes.GetIncrementStat(Stat.Agility).ToString();
            inc_const.Text = Static.Classes.GetIncrementStat(Stat.Constitution).ToString();
            inc_int.Text = Static.Classes.GetIncrementStat(Stat.Intelligence).ToString();
            inc_wis.Text = Static.Classes.GetIncrementStat(Stat.Wisdom).ToString();
            inc_will.Text = Static.Classes.GetIncrementStat(Stat.Will).ToString();
            inc_min.Text = Static.Classes.GetIncrementStat(Stat.Mind).ToString();
            inc_cha.Text = Static.Classes.GetIncrementStat(Stat.Charisma).ToString();
            inc_point.Text = Static.Classes.GetIncrementStat(Stat.Point).ToString();
            inc_hp.Text = "HP: " + GetIncrementCalc(Stat.MaxHP);
            inc_mp.Text = "MP: " + GetIncrementCalc(Stat.MaxMP);
            inc_sp.Text = "SP: " + GetIncrementCalc(Stat.MaxSP);
            inc_regenhp.Text = "Regen HP: " + GetIncrementCalc(Stat.RegenHP);
            inc_regenmp.Text = "Regen MP: " + GetIncrementCalc(Stat.RegenMP);
            inc_regensp.Text = "Regen SP: " + GetIncrementCalc(Stat.RegenSP);
            inc_atk.Text = "Ataque: " + GetIncrementCalc(Stat.Attack);
            inc_acc.Text = "Precisão: " + GetIncrementCalc(Stat.Accuracy);
            inc_def.Text = "Defesa: " + GetIncrementCalc(Stat.Defense);
            inc_eva.Text = "Evasão: " + GetIncrementCalc(Stat.Evasion);
            inc_block.Text = "Bloqueio (Escudo): " + GetIncrementCalc(Stat.Block);
            inc_parry.Text = "Bloqueio (Arma): " + GetIncrementCalc(Stat.Parry);
            inc_crit_tax.Text = "Taxa Crítica: " + GetIncrementCalc(Stat.CriticalRate);
            inc_crit_dmg.Text = "Dano Crítico: " + GetIncrementCalc(Stat.CriticalDamage);
            inc_enmity.Text = "Inimizade: " + GetIncrementCalc(Stat.Enmity);
            inc_magatk.Text = "Ataque Mágico: " + GetIncrementCalc(Stat.MagicAttack);
            inc_magacc.Text = "Precisão Mágica: " + GetIncrementCalc(Stat.MagicAccuracy);
            inc_magdef.Text = "Defesa Mágica: " + GetIncrementCalc(Stat.MagicDefense);
            inc_magres.Text = "Resistência Mágica: " + GetIncrementCalc(Stat.MagicResist);
            inc_crit_taxmag.Text = "Taxa Crítica Mágica: " + GetIncrementCalc(Stat.MagicCriticalRate);
            inc_crit_dmgmag.Text = "Dano Crítico Mágico: " + GetIncrementCalc(Stat.MagicCriticalDamage);
            inc_supp.Text = "Supressão de Dano: " + GetIncrementCalc(Stat.DamageSuppression);
            inc_fire.Text = "Atributo Fogo: " + GetIncrementCalc(Stat.AttributeFire);
            inc_water.Text = "Atributo Água: " + GetIncrementCalc(Stat.AttributeWater);
            inc_earth.Text = "Atributo Terra: " + GetIncrementCalc(Stat.AttributeEarth);
            inc_wind.Text = "Atributo Vento: " + GetIncrementCalc(Stat.AttributeWind);
            inc_silence.Text = "Resistência Silêncio: "+ GetIncrementCalc(Stat.ResistSilence);
            inc_paral.Text = "Resistência Paralisia: "+ GetIncrementCalc(Stat.ResistParalysis);
            inc_stun.Text = "Resistência Atordoamento: " + GetIncrementCalc(Stat.ResistStun);
            inc_blind.Text = "Resistência Cegar: " + GetIncrementCalc(Stat.ResistBlind);
            inc_adddmg.Text = "Dano Adicional: " + GetIncrementCalc(Stat.AdditionalDamage);
            inc_heal.Text = "Poder de Cura: " + GetIncrementCalc(Stat.HealingPower);
            inc_con.Text = "Concentração: " + GetIncrementCalc(Stat.Concentration);
            inc_atkspeed.Text = "Vel. Ataque: " + GetIncrementCalc(Stat.AttackSpeed);
            inc_castspeed.Text = "Vel. Conjuração: " + GetIncrementCalc(Stat.CastSpeed);
            inc_crit_res_tax.Text = "Resistência Taxa Crítica: " + GetIncrementCalc(Stat.ResistCriticalRate);
            int_crit_res_dmg.Text = "Resistência Dano Crítico: " + GetIncrementCalc(Stat.ResistCriticalDamage);
            inc_crit_res_taxmag.Text = "Resistência Taxa Crítica Mágica: " + GetIncrementCalc(Stat.ResistMagicCriticalRate);
            inc_crit_res_dmgmag.Text = "Resistência Dano Crítico Mágico: " + GetIncrementCalc(Stat.ResistMagicCriticalDamage);
        }

        public void RefreshSimulator() {
            sim_hp.Text = "HP: " + Static.Classes.MaxHP;
            sim_mp.Text = "MP: " + Static.Classes.MaxMP;
            sim_sp.Text = "SP: " + Static.Classes.MaxSP;
            sim_regenhp.Text = "Regen HP: " + Static.Classes.RegenHP;
            sim_regenmp.Text = "Regen MP: " + Static.Classes.RegenMP;
            sim_regensp.Text = "Regen SP: " + Static.Classes.RegenSP;
            sim_level.Text = "Level: " + Static.Classes.Level;
            sim_str.Text = "Força: " + Static.Classes.Strenght;
            sim_dex.Text = "Destreza: " + Static.Classes.Dexterity;
            sim_agi.Text = "Agilidade: " + Static.Classes.Agility;
            sim_vit.Text = "Vitalidade: " + Static.Classes.Constitution;
            sim_int.Text = "Inteligência: " + Static.Classes.Intelligence;
            sim_wis.Text = "Sabedoria: " + Static.Classes.Wisdom;
            sim_will.Text = "Vontade: " + Static.Classes.Will;
            sim_min.Text = "Espírito: " + Static.Classes.Mind;
            sim_cha.Text = "Carisma: " + Static.Classes.Charisma;
            sim_point.Text = "Pontos: " + Static.Classes.Point;
            sim_block.Text = "Bloqueio: " + Static.Classes.Block;
            sim_parry.Text = "Bloqueio: " + Static.Classes.Parry;
            sim_supp.Text = "Supressão de Dano: " + Static.Classes.DamageSuppression;
            sim_enmity.Text = "Inimizade: " + Static.Classes.Enmity;
            sim_adddmg.Text = "Dano Adicional: " + Static.Classes.AdditionalDamage;
            sim_heal.Text = "Poder de Cura: " + Static.Classes.HealingPower;
            sim_con.Text = "Concentração: " + Static.Classes.Concentration;
            sim_velatk.Text = "Vel. Ataque: " + Static.Classes.AttackSpeed;
            sim_velcast.Text = "Vel. Conjuração: " + Static.Classes.CastSpeed;
            sim_atkmag.Text = "Ataque Mágico: " + Static.Classes.MagicAttack;
            sim_magacc.Text = "Precisão Mágica: " + Static.Classes.MagicAccuracy;
            sim_defmag.Text = "Defesa Mágica: " + Static.Classes.MagicDefense;
            sim_magres.Text = "Resistência Mágica: " + Static.Classes.MagicResist;
            sim_crit_taxmag.Text = "Taxa Critica Mágico: " + Static.Classes.MagicCriticalRate;
            sim_crit_dmgmag.Text = "Dano Crítico Mágico: " + Static.Classes.MagicCriticalDamage;
            sim_atk.Text = "Ataque: " + Static.Classes.Attack;
            sim_acc.Text = "Precisão: " + Static.Classes.Accuracy;
            sim_def.Text = "Defesa: " + Static.Classes.Defense;
            sim_eva.Text = "Evasão: " + Static.Classes.Evasion;
            sim_crit_tax.Text = "Taxa Crítica: " + Static.Classes.CriticalRate;
            sim_crit_dmg.Text = "Dano Crítico: " + Static.Classes.CriticalDamage;
            sim_fire.Text = "Atributo Fogo: " + Static.Classes.AttributeFire;
            sim_water.Text = "Atributo Água: " + Static.Classes.AttributeWater;
            sim_earth.Text = "Atributo Terra: " + Static.Classes.AttributeEarth;
            sim_wind.Text = "Atributo Vento: " + Static.Classes.AttributeWind;
            sim_stun.Text = "Res. Atordoamento: " + Static.Classes.ResistStun;
            sim_silence.Text = "Res. Silêncio: " + Static.Classes.ResistSilence;
            sim_paralys.Text = "Res. Paralisia: " + Static.Classes.ResistParalysis;
            sim_blind.Text = "Res. Cegar: " + Static.Classes.ResistBlind;
            sim_res_tax_mag.Text = "Res. T. Crit Mágico: " + Static.Classes.ResistMagicCriticalRate;
            sim_res_crit_mag.Text = "Res. D. Crít Mágico: " + Static.Classes.ResistMagicCriticalDamage;
            sim_res_tax.Text = "Res. Taxa Crítica: " + Static.Classes.ResistCriticalRate;
            sim_res_crit.Text = "Res. Dano Crítico: " + Static.Classes.ResistCriticalDamage;         
        }

        public void RefreshBaseTextBox() {
            base_id.Text = Static.Classes.ID.ToString();
            base_name.Text = Static.Classes.ClasseName;
            base_gender.SelectedIndex = Static.Classes.Gender;
            base_sprite_f.Text = Static.Classes.SpriteFemale.ToString();
            base_sprite_m.Text = Static.Classes.SpriteMale.ToString();

            if (base_increment.Items.Count > 0) { base_increment.SelectedIndex = Static.ListClasseIncrement.IndexOf(Static.Classes.ClasseIncrementID); }
         
            base_str.Text = Static.Classes.GetBaseStat(Stat.Strenght).ToString();
            base_dex.Text = Static.Classes.GetBaseStat(Stat.Dexterity).ToString();
            base_agi.Text = Static.Classes.GetBaseStat(Stat.Agility).ToString();
            base_const.Text = Static.Classes.GetBaseStat(Stat.Concentration).ToString();
            base_int.Text = Static.Classes.GetBaseStat(Stat.Intelligence).ToString();
            base_wis.Text = Static.Classes.GetBaseStat(Stat.Wisdom).ToString();
            base_will.Text = Static.Classes.GetBaseStat(Stat.Will).ToString();
            base_min.Text = Static.Classes.GetBaseStat(Stat.Mind).ToString();
            base_cha.Text = Static.Classes.GetBaseStat(Stat.Charisma).ToString();
            base_point.Text = Static.Classes.GetBaseStat(Stat.Point).ToString();
            base_level.Text = Static.Classes.GetBaseStat(Stat.Level).ToString();
            base_hp.Text = Static.Classes.GetBaseStat(Stat.MaxHP).ToString();
            base_mp.Text = Static.Classes.GetBaseStat(Stat.MaxMP).ToString();
            base_sp.Text = Static.Classes.GetBaseStat(Stat.MaxSP).ToString();
            base_regen_hp.Text = Static.Classes.GetBaseStat(Stat.RegenHP).ToString();
            base_regen_mp.Text = Static.Classes.GetBaseStat(Stat.RegenMP).ToString();
            base_regen_sp.Text = Static.Classes.GetBaseStat(Stat.RegenSP).ToString();
            base_atk.Text = Static.Classes.GetBaseStat(Stat.Attack).ToString();
            base_acc.Text = Static.Classes.GetBaseStat(Stat.Accuracy).ToString();
            base_def.Text = Static.Classes.GetBaseStat(Stat.Defense).ToString();
            base_eva.Text = Static.Classes.GetBaseStat(Stat.Evasion).ToString();
            base_block.Text = Static.Classes.GetBaseStat(Stat.Block).ToString();
            base_parry.Text = Static.Classes.GetBaseStat(Stat.Parry).ToString();
            base_crit_tax.Text = Static.Classes.GetBaseStat(Stat.CriticalRate).ToString();
            base_crit_dmg.Text = Static.Classes.GetBaseStat(Stat.CriticalDamage).ToString();
            base_mag_atk.Text = Static.Classes.GetBaseStat(Stat.MagicAttack).ToString();
            base_mag_acc.Text = Static.Classes.GetBaseStat(Stat.MagicAccuracy).ToString();
            base_mag_def.Text = Static.Classes.GetBaseStat(Stat.MagicDefense).ToString();
            base_mag_res.Text = Static.Classes.GetBaseStat(Stat.MagicResist).ToString();
            base_crit_taxmag.Text = Static.Classes.GetBaseStat(Stat.MagicCriticalRate).ToString();
            base_crit_dmgmag.Text = Static.Classes.GetBaseStat(Stat.MagicCriticalDamage).ToString();
            base_supp.Text = Static.Classes.GetBaseStat(Stat.DamageSuppression).ToString();
            base_fire.Text = Static.Classes.GetBaseStat(Stat.AttributeFire).ToString();
            base_water.Text = Static.Classes.GetBaseStat(Stat.AttributeWater).ToString();
            base_earth.Text = Static.Classes.GetBaseStat(Stat.AttributeEarth).ToString();
            base_wind.Text = Static.Classes.GetBaseStat(Stat.AttributeWind).ToString();
            base_res_crit_tax.Text = Static.Classes.GetBaseStat(Stat.ResistCriticalRate).ToString();
            base_res_crit_dmg.Text = Static.Classes.GetBaseStat(Stat.ResistCriticalDamage).ToString();
            base_res_crit_taxmag.Text = Static.Classes.GetBaseStat(Stat.ResistMagicCriticalRate).ToString();
            base_res_crit_dmgmag.Text = Static.Classes.GetBaseStat(Stat.ResistMagicCriticalDamage).ToString();
            base_enmity.Text = Static.Classes.GetBaseStat(Stat.Enmity).ToString();
            base_adddmg.Text = Static.Classes.GetBaseStat(Stat.AdditionalDamage).ToString();
            base_heal.Text = Static.Classes.GetBaseStat(Stat.HealingPower).ToString();
            base_con.Text = Static.Classes.GetBaseStat(Stat.Concentration).ToString();
            base_atkspeed.Text = Static.Classes.GetBaseStat(Stat.AttackSpeed).ToString();
            base_castspeed.Text = Static.Classes.GetBaseStat(Stat.CastSpeed).ToString();
            base_res_silence.Text = Static.Classes.GetBaseStat(Stat.ResistSilence).ToString();
            base_res_paralysis.Text = Static.Classes.GetBaseStat(Stat.ResistParalysis).ToString();
            base_res_stun.Text = Static.Classes.GetBaseStat(Stat.ResistStun).ToString();
            base_res_blind.Text = Static.Classes.GetBaseStat(Stat.ResistBlind).ToString();
        }
        #endregion 

        #region Simulator
        private void IncreaseDecreaseButtons(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            switch(button.Name)
            {
                case "sim_inc_level":
                    Static.Classes.SetIncDecStat(Stat.Level, true);
                    break;
                case "sim_inc_str":
                    Static.Classes.SetIncDecStat(Stat.Strenght, true);
                    break;
                case "sim_inc_dex":
                    Static.Classes.SetIncDecStat(Stat.Dexterity, true);
                    break;
                case "sim_inc_agi":
                    Static.Classes.SetIncDecStat(Stat.Agility, true);
                    break;
                case "sim_inc_const":
                    Static.Classes.SetIncDecStat(Stat.Constitution, true);
                    break;
                case "sim_inc_int":
                    Static.Classes.SetIncDecStat(Stat.Intelligence, true);
                    break;
                case "sim_inc_wis":
                    Static.Classes.SetIncDecStat(Stat.Wisdom, true);
                    break;
                case "sim_inc_will":
                    Static.Classes.SetIncDecStat(Stat.Will, true);
                    break;
                case "sim_inc_min":
                    Static.Classes.SetIncDecStat(Stat.Mind, true);
                    break;
                case "sim_inc_cha":
                    Static.Classes.SetIncDecStat(Stat.Charisma, true);
                    break;
                case "sim_dec_level":
                    Static.Classes.SetIncDecStat(Stat.Level, false);
                    break;
                case "sim_dec_str":
                    Static.Classes.SetIncDecStat(Stat.Strenght, false);
                    break;
                case "sim_dec_dex":
                    Static.Classes.SetIncDecStat(Stat.Dexterity, false);
                    break;
                case "sim_dec_agi":
                    Static.Classes.SetIncDecStat(Stat.Agility, false);
                    break;
                case "sim_dec_const":
                    Static.Classes.SetIncDecStat(Stat.Constitution, false);
                    break;
                case "sim_dec_int":
                    Static.Classes.SetIncDecStat(Stat.Intelligence, false);
                    break;
                case "sim_dec_wis":
                    Static.Classes.SetIncDecStat(Stat.Wisdom, false);
                    break;
                case "sim_dec_will":
                    Static.Classes.SetIncDecStat(Stat.Will, false);
                    break;
                case "sim_dec_min":
                    Static.Classes.SetIncDecStat(Stat.Mind, false);
                    break;
                case "sim_dec_cha":
                    Static.Classes.SetIncDecStat(Stat.Charisma, false);
                    break;
                case "sim_reset":
                    Static.Classes.ResetSimulatorIncrementDecrementStat();
                    break;
            }

            RefreshSimulator();
        }
        #endregion

        #region Classe Base
        /// <summary>
        /// Limpa todos os textbox.
        /// </summary>
        public void ClarBaseTextBox() {
            base_hp.Text = string.Empty;
            base_mp.Text = string.Empty;
            base_sp.Text = string.Empty;

            foreach (GroupBox group in panel_att_init.Controls) {
                foreach (var item in group.Controls) {
                    if (item.GetType() == typeof(TextBox)) {
                        TextBox obj = (TextBox)item;
                        obj.Text = string.Empty;
                    }
                }
            }
        }

        //Limpa o textbox.
        private void base_clear_Click(object sender, EventArgs e)
        {
            ClarBaseTextBox();
            RefreshSimulator();
        }

        /// <summary>
        /// Quando selecionado o indice, carrega a informação da classe.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void base_attribute_SelectedIndexChanged(object sender, EventArgs e) {
            var index = base_attribute.SelectedIndex;
            if (index < 0) { return; }

            MySQL.GetClasseBase(index);

            RefreshSimulator();

            RefreshBaseTextBox();
        }
  
        /// <summary>
        /// Atualiza a classe base.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void base_refresh_Click(object sender, EventArgs e) {
            base_refresh.Enabled = false;
            ClarBaseTextBox();
            InitialClasseBase();
            InitialClasseIncrement();
        }

        /// <summary>
        /// Deleta uma classe.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void base_delete_Click(object sender, EventArgs e) {
            var index = base_attribute.SelectedIndex;
            if (index == -1) { return; }

            var result = MessageBox.Show("Deseja deletar: " + base_attribute.SelectedItem + "?", "Aviso", MessageBoxButtons.YesNo);
            if (result == DialogResult.No) { return; }

            MySQL.DeleteClasseBase(index);

            ClarBaseTextBox();
            RefreshSimulator();

            InitialClasseBase();
            InitialClasseIncrement();
        }

        /// <summary>
        /// Quando o genero da classe for alterado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void base_gender_SelectedIndexChanged(object sender, EventArgs e) {
            var index = (short)base_gender.SelectedIndex;
            if (index == -1) { return; }

            Static.Classes.Gender = index;
        }

        /// <summary>
        /// Quando o nome da classe base for alterado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void base_name_TextChanged(object sender, EventArgs e) {
            if (base_name.Text.Length == 0) { Static.Classes.ClasseName = string.Empty; }
            else { Static.Classes.ClasseName = base_name.Text.Trim(); }
        }

        /// <summary>
        /// Selecionando o indice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void base_increment_SelectedIndexChanged(object sender, EventArgs e) {
            var index = base_increment.SelectedIndex;
            if (index == -1) { return; }

            Static.Classes.ClasseIncrementID = Static.ListClasseIncrement[index];
        }

        /// <summary>
        /// Atualiza uma classe.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void base_update_Click(object sender, EventArgs e) {
            var index = base_attribute.SelectedIndex;
            if (index == -1) { return; }

            if (!MySQL.ExistClasseID(Static.ListClasseBase[index])) {
                MessageBox.Show("A atual ID não existe no banco de dados para uma atualização. Insira como uma nova Base de Atributos.", "Erro");
                return;
            }

            MySQL.UpdateClasseBase(index);

            ClarBaseTextBox();
            RefreshSimulator();

            InitialClasseBase();
            InitialClasseIncrement();
        }
        #endregion

        #region Classe Increment
        /// <summary>
        /// Limpa todos os textos de incremento.
        /// </summary>
        public void ClearIncrementTextBox() {
            foreach (var item in panel_increment.Controls) {
                if (item.GetType() == typeof(TextBox)) {
                    TextBox obj = (TextBox)item;
                    obj.Text = string.Empty;
                }
            }
        }

        /// <summary>
        /// Nome de incremento quando alterado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void inc_name_TextChanged(object sender, EventArgs e) {
            if (inc_name.Text.Length == 0) { Static.Classes.IncrementName = string.Empty; }
            else { Static.Classes.IncrementName = inc_name.Text.Trim(); }
        }

        /// <summary>
        /// Combobox, quando o incremento for selecionado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void inc_increment_SelectedIndexChanged(object sender, EventArgs e) {
            var index = inc_increment.SelectedIndex;
            if (index == -1) { return; }

            MySQL.GetClasseIncrement(index);

            RefreshIncrement();
            RefreshSimulator();
        }

        /// <summary>
        /// Deleta um incremento.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void inc_delete_Click(object sender, EventArgs e) {
            var index = inc_increment.SelectedIndex;
            if (index == -1) { return; }

            var result = MessageBox.Show("Deseja deletar: " + inc_increment.SelectedItem + "?", "Aviso", MessageBoxButtons.YesNo);

            if (result == DialogResult.No) { return; }

            MySQL.DeleteClasseIncrement(index);

            Static.Classes.ClearIncrementData();

            RefreshIncrement(true);

            ClearIncrementTextBox();

            RefreshSimulator();

            InitialClasseBase();
            InitialClasseIncrement();
        }

        /// <summary>
        /// Atualização.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void inc_refresh_Click(object sender, EventArgs e) {
            inc_refresh.Enabled = false;
            InitialClasseIncrement();
        }

        /// <summary>
        /// Limpar classe e textbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void inc_clear_Click(object sender, EventArgs e) {
            Static.Classes.ClearIncrementData();
            RefreshIncrement(true);
            ClearIncrementTextBox();
            RefreshSimulator();
        }

        /// <summary>
        /// Atualiza os dados para o banco de dados.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void inc_update_Click(object sender, EventArgs e) {
            var index = inc_increment.SelectedIndex;
            if (index == -1) { return; }

            if (!MySQL.ExistIncrementID(Static.ListClasseIncrement[index])) {
                MessageBox.Show("A atual ID não existe no banco de dados para uma atualização. Insira como um novo Incremento.", "Erro");
                return;
            }

            MySQL.UpdateClasseIncrement(index);
            Static.Classes.ClearIncrementData();

            RefreshIncrement(true);
            ClearIncrementTextBox();
            RefreshSimulator();

            InitialClasseIncrement();
        }

        /// <summary>
        /// Painel de Incremento.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void IncrementEditButton(object sender, EventArgs e) {
            int[] statValue = new int[10];

            panel_edit.Visible = true;
            edit_level.Focus();
  
            Button button = (Button)sender;
           
            if (button.Name != "edit_ok" && button.Name != "edit_cancel")
            { SelectedButton = button.Name; }

            #region Button OK & CANCEL
            if (button.Name == "edit_ok")
            {
                if (edit_level.Text.Length == 0) { statValue[0] = 0; }
                else { statValue[0] = Convert.ToInt32(edit_level.Text.Trim()); }

                if (edit_str.Text.Length == 0) { statValue[1] = 0; } 
                else { statValue[1] = Convert.ToInt32(edit_str.Text.Trim()); }

                if (edit_dex.Text.Length == 0) { statValue[2] = 0; }
                else { statValue[2] = Convert.ToInt32(edit_dex.Text.Trim()); }

                if (edit_agi.Text.Length == 0) { statValue[3] = 0; }
                else { statValue[3] = Convert.ToInt32(edit_agi.Text.Trim()); }

                if (edit_const.Text.Length == 0) { statValue[4] = 0; }
                else { statValue[4] = Convert.ToInt32(edit_const.Text.Trim()); }

                if (edit_int.Text.Length == 0) { statValue[5] = 0; }
                else { statValue[5] = Convert.ToInt32(edit_int.Text.Trim()); }

                if (edit_wis.Text.Length == 0) { statValue[6] = 0; }
                else { statValue[6] = Convert.ToInt32(edit_wis.Text.Trim()); }

                if (edit_will.Text.Length == 0) { statValue[7] = 0; }
                else { statValue[7] = Convert.ToInt32(edit_will.Text.Trim()); }

                if (edit_min.Text.Length == 0) { statValue[8] = 0; }
                else { statValue[8] = Convert.ToInt32(edit_min.Text.Trim()); }

                if (edit_cha.Text.Length == 0) { statValue[9] = 0; }
                else { statValue[9] = Convert.ToInt32(edit_cha.Text.Trim()); }

                panel_edit.Visible = false;

                switch(SelectedButton)
                {
                    case "edit_hp":
                        SetIncrementStat(Stat.MaxHP, statValue);
                        break;
                    case "edit_mp":
                        SetIncrementStat(Stat.MaxMP, statValue);
                        break;
                    case "edit_sp":
                        SetIncrementStat(Stat.MaxSP, statValue);
                        break;
                    case "edit_regenhp":
                        SetIncrementStat(Stat.RegenHP, statValue);
                        break;
                    case "edit_regenmp":
                        SetIncrementStat(Stat.RegenMP, statValue);
                        break;
                    case "edit_regensp":
                        SetIncrementStat(Stat.RegenSP, statValue);
                        break;
                    case "edit_enmity":
                        SetIncrementStat(Stat.Enmity, statValue);
                        break;
                    case "edit_atk":
                        SetIncrementStat(Stat.Attack, statValue);
                        break;
                    case "edit_acc":
                        SetIncrementStat(Stat.Accuracy, statValue);
                        break;
                    case "edit_def":
                        SetIncrementStat(Stat.Defense, statValue);
                        break;
                    case "edit_eva":
                        SetIncrementStat(Stat.Evasion, statValue);
                        break;
                    case "edit_block":
                        SetIncrementStat(Stat.Block, statValue);
                        break;
                    case "edit_parry":
                        SetIncrementStat(Stat.Parry, statValue);
                        break;
                    case "edit_crit_tax":
                        SetIncrementStat(Stat.CriticalRate, statValue);
                        break;
                    case "edit_crit_dmg":
                        SetIncrementStat(Stat.CriticalDamage, statValue);
                        break;
                    case "edit_atkmag":
                        SetIncrementStat(Stat.MagicAttack, statValue);
                        break;
                    case "edit_magacc":
                        SetIncrementStat(Stat.MagicAccuracy, statValue);
                        break;
                    case "edit_magdef":
                        SetIncrementStat(Stat.MagicDefense, statValue);
                        break;
                    case "edit_magres":
                        SetIncrementStat(Stat.MagicResist, statValue);
                        break;
                    case "edit_crit_taxmag":
                        SetIncrementStat(Stat.MagicCriticalRate, statValue);
                        break;
                    case "edit_crit_dmgmag":
                        SetIncrementStat(Stat.MagicCriticalDamage, statValue);
                        break;
                    case "edit_supp":
                        SetIncrementStat(Stat.DamageSuppression, statValue);
                        break;
                    case "edit_adddmg":
                        SetIncrementStat(Stat.AdditionalDamage, statValue);
                        break;
                    case "edit_heal":
                        SetIncrementStat(Stat.HealingPower, statValue);
                        break;
                    case "edit_con":
                        SetIncrementStat(Stat.Concentration, statValue);
                        break;
                    case "edit_atkspeed":
                        SetIncrementStat(Stat.AttackSpeed, statValue);
                        break;
                    case "edit_castspeed":
                        SetIncrementStat(Stat.CastSpeed, statValue);
                        break;
                    case "edit_silence":
                        SetIncrementStat(Stat.ResistSilence, statValue);
                        break;
                    case "edit_paralysis":
                        SetIncrementStat(Stat.ResistParalysis, statValue);
                        break;
                    case "edit_stun":
                        SetIncrementStat(Stat.ResistStun, statValue);
                        break;
                    case "edit_blind":
                        SetIncrementStat(Stat.ResistBlind, statValue);
                        break;
                    case "edit_fire":
                        SetIncrementStat(Stat.AttributeFire, statValue);
                        break;
                    case "edit_water":
                        SetIncrementStat(Stat.AttributeWater, statValue);
                        break;
                    case "edit_earth":
                        SetIncrementStat(Stat.AttributeEarth, statValue);
                        break;
                    case "edit_wind":
                        SetIncrementStat(Stat.AttributeWind, statValue);
                        break;
                    case "edit_res_crit_tax":
                        SetIncrementStat(Stat.ResistCriticalRate, statValue);
                        break;
                    case "edit_res_crit_dmg":
                        SetIncrementStat(Stat.ResistCriticalDamage, statValue);
                        break;
                    case "edit_res_crit_taxmag":
                        SetIncrementStat(Stat.ResistMagicCriticalRate, statValue);
                        break;
                    case "edit_res_crit_dmgmag":
                        SetIncrementStat(Stat.ResistMagicCriticalDamage, statValue);
                        break;
                }

                RefreshIncrement();
                RefreshSimulator();
            }

            if (button.Name == "edit_cancel")
            {
                panel_edit.Visible = false;
            }
            #endregion


            if (SelectedButton == "edit_hp") { GetIncrementStat(Stat.MaxHP); return; }
            if (SelectedButton == "edit_mp") { GetIncrementStat(Stat.MaxMP); return; }
            if (SelectedButton == "edit_sp") { GetIncrementStat(Stat.MaxSP); return; }
            if (SelectedButton == "edit_regenhp") { GetIncrementStat(Stat.RegenHP); return; }
            if (SelectedButton == "edit_regenmp") { GetIncrementStat(Stat.RegenMP); return; }
            if (SelectedButton == "edit_regensp") { GetIncrementStat(Stat.RegenSP); return; }
            if (SelectedButton == "edit_enmity") { GetIncrementStat(Stat.Enmity); return; }
            if (SelectedButton == "edit_atk") { GetIncrementStat(Stat.Attack); return; }
            if (SelectedButton == "edit_acc") { GetIncrementStat(Stat.Accuracy); return; }
            if (SelectedButton == "edit_def") { GetIncrementStat(Stat.Defense); return; }
            if (SelectedButton == "edit_eva") { GetIncrementStat(Stat.Evasion); return; }
            if (SelectedButton == "edit_block") { GetIncrementStat(Stat.Block); return; }
            if (SelectedButton == "edit_parry") { GetIncrementStat(Stat.Parry); return; }
            if (SelectedButton == "edit_crit_tax") { GetIncrementStat(Stat.CriticalRate); return; }
            if (SelectedButton == "edit_crit_dmg") { GetIncrementStat(Stat.CriticalDamage); return; }
            if (SelectedButton == "edit_atkmag") { GetIncrementStat(Stat.MagicAttack); return; }
            if (SelectedButton == "edit_magacc") { GetIncrementStat(Stat.MagicAccuracy); return; }
            if (SelectedButton == "edit_magdef") { GetIncrementStat(Stat.MagicDefense); return; }
            if (SelectedButton == "edit_magres") { GetIncrementStat(Stat.MagicResist); return; }
            if (SelectedButton == "edit_crit_taxmag") { GetIncrementStat(Stat.MagicCriticalRate); return; }
            if (SelectedButton == "edit_crit_dmgmag") { GetIncrementStat(Stat.MagicCriticalDamage); return; }
            if (SelectedButton == "edit_supp") { GetIncrementStat(Stat.DamageSuppression); return; }
            if (SelectedButton == "edit_adddmg") { GetIncrementStat(Stat.AdditionalDamage); return; }
            if (SelectedButton == "edit_heal") { GetIncrementStat(Stat.HealingPower); return; }
            if (SelectedButton == "edit_con") { GetIncrementStat(Stat.Concentration); return; }
            if (SelectedButton == "edit_atkspeed") { GetIncrementStat(Stat.AttackSpeed); return; }
            if (SelectedButton == "edit_castspeed") { GetIncrementStat(Stat.CastSpeed); return; }
            if (SelectedButton == "edit_silence") { GetIncrementStat(Stat.ResistSilence); return; }
            if (SelectedButton == "edit_paralysis") { GetIncrementStat(Stat.ResistParalysis); return; }
            if (SelectedButton == "edit_stun") { GetIncrementStat(Stat.ResistStun); return; }
            if (SelectedButton == "edit_blind") { GetIncrementStat(Stat.ResistBlind); return; }
            if (SelectedButton == "edit_fire") { GetIncrementStat(Stat.AttributeFire); return; }
            if (SelectedButton == "edit_water") { GetIncrementStat(Stat.AttributeWater); return; }
            if (SelectedButton == "edit_earth") { GetIncrementStat(Stat.AttributeEarth); return; }
            if (SelectedButton == "edit_wind") { GetIncrementStat(Stat.AttributeWind); return; }
            if (SelectedButton == "edit_res_crit_tax") { GetIncrementStat(Stat.ResistCriticalRate); return; }
            if (SelectedButton == "edit_res_crit_dmg") { GetIncrementStat(Stat.ResistCriticalDamage); return; }
            if (SelectedButton == "edit_res_crit_taxmag") { GetIncrementStat(Stat.ResistMagicCriticalRate); return; }
            if (SelectedButton == "edit_res_crit_dmgmag") { GetIncrementStat(Stat.ResistMagicCriticalDamage); return; }
        }

        private void SetIncrementStat(Stat type, params int[] value) {
            Static.Classes.SetIncrementStat(type, value[0], 0);
            Static.Classes.SetIncrementStat(type, value[1], 1);
            Static.Classes.SetIncrementStat(type, value[2], 2);
            Static.Classes.SetIncrementStat(type, value[3], 3);
            Static.Classes.SetIncrementStat(type, value[4], 4);
            Static.Classes.SetIncrementStat(type, value[5], 5);
            Static.Classes.SetIncrementStat(type, value[6], 6);
            Static.Classes.SetIncrementStat(type, value[7], 7);
            Static.Classes.SetIncrementStat(type, value[8], 8);
            Static.Classes.SetIncrementStat(type, value[9], 9);
        }

        public void GetIncrementStat(Stat type)
        {
            edit_level.Text = Static.Classes.GetIncrementStat(type, 0).ToString();
            edit_str.Text = Static.Classes.GetIncrementStat(type, 1).ToString();
            edit_dex.Text = Static.Classes.GetIncrementStat(type, 2).ToString();
            edit_agi.Text = Static.Classes.GetIncrementStat(type, 3).ToString();
            edit_const.Text = Static.Classes.GetIncrementStat(type, 4).ToString();
            edit_int.Text = Static.Classes.GetIncrementStat(type, 5).ToString();
            edit_wis.Text = Static.Classes.GetIncrementStat(type, 6).ToString();
            edit_will.Text = Static.Classes.GetIncrementStat(type, 7).ToString();
            edit_min.Text = Static.Classes.GetIncrementStat(type, 8).ToString();
            edit_cha.Text = Static.Classes.GetIncrementStat(type, 9).ToString();
        }

        public int GetIncrementCalc(Stat type)
        {
            int result = Static.Classes.GetIncrementStat(type, 0);
            result += Static.Classes.GetIncrementStat(type, 1);
            result += Static.Classes.GetIncrementStat(type, 2);
            result += Static.Classes.GetIncrementStat(type, 3);
            result += Static.Classes.GetIncrementStat(type, 4);
            result += Static.Classes.GetIncrementStat(type, 5);
            result += Static.Classes.GetIncrementStat(type, 6);
            result += Static.Classes.GetIncrementStat(type, 7);
            result += Static.Classes.GetIncrementStat(type, 8);
            result += Static.Classes.GetIncrementStat(type, 9);

            return result;
        }
        #endregion

        /// <summary>
        /// Quando alterado o conteúdo, mover para a variavel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_TextChange(object sender, EventArgs e) {
            var text = (TextBox)sender;
            var num = 0; 

            if (text.Text.Length == 0) {
                num = 0;
            }
            else {
                Int32.TryParse(text.Text.Trim(), out num);
            }

            switch(text.Name) {
                case "inc_id":
                    Static.Classes.IncrementID = num;
                    break;
                case "inc_str":
                    Static.Classes.SetIncrementStat(Stat.Strenght, num);
                    break;
                case "inc_dex":
                    Static.Classes.SetIncrementStat(Stat.Dexterity, num);
                    break;
                case "inc_agi":
                    Static.Classes.SetIncrementStat(Stat.Agility, num);
                    break;
                case "inc_const":
                    Static.Classes.SetIncrementStat(Stat.Constitution, num);
                    break;
                case "inc_int":
                    Static.Classes.SetIncrementStat(Stat.Intelligence, num);
                    break;
                case "inc_wis":
                    Static.Classes.SetIncrementStat(Stat.Wisdom, num);
                    break;
                case "inc_will":
                    Static.Classes.SetIncrementStat(Stat.Will, num);
                    break;
                case "inc_min":
                    Static.Classes.SetIncrementStat(Stat.Mind, num);
                    break;
                case "inc_cha":
                    Static.Classes.SetIncrementStat(Stat.Charisma, num);
                    break;
                case "inc_point":
                    Static.Classes.SetIncrementStat(Stat.Point, num);
                    break;
                case "base_id":
                    Static.Classes.ID = num;
                    break;
                case "base_sprite_f":
                    Static.Classes.SpriteFemale = num;
                    break;
                case "base_sprite_m":
                    Static.Classes.SpriteMale = num;
                    break;
                case "base_level":
                    Static.Classes.SetBaseStat(Stat.Level, num);
                    break;
                case "base_str":
                    Static.Classes.SetBaseStat(Stat.Strenght, num);
                    break;
                case "base_dex":
                    Static.Classes.SetBaseStat(Stat.Dexterity, num);
                    break;
                case "base_agi":
                    Static.Classes.SetBaseStat(Stat.Agility, num);
                    break;
                case "base_const":
                    Static.Classes.SetBaseStat(Stat.Constitution, num);
                    break;
                case "base_int":
                    Static.Classes.SetBaseStat(Stat.Intelligence, num);
                    break;
                case "base_wis":
                    Static.Classes.SetBaseStat(Stat.Wisdom, num);
                    break;
                case "base_will":
                    Static.Classes.SetBaseStat(Stat.Will, num);
                    break;
                case "base_min":
                    Static.Classes.SetBaseStat(Stat.Mind, num);
                    break;
                case "base_cha":
                    Static.Classes.SetBaseStat(Stat.Charisma, num);
                    break;
                case "base_point":
                    Static.Classes.SetBaseStat(Stat.Point, num);
                    break;
                case "base_hp":
                    Static.Classes.SetBaseStat(Stat.MaxHP, num);
                    break;
                case "base_mp":
                    Static.Classes.SetBaseStat(Stat.MaxMP, num);
                    break;
                case "base_sp":
                    Static.Classes.SetBaseStat(Stat.MaxSP, num);
                    break;
                case "base_atk":
                    Static.Classes.SetBaseStat(Stat.Attack, num);
                    break;
                case "base_acc":
                    Static.Classes.SetBaseStat(Stat.Accuracy, num);
                    break;
                case "base_def":
                    Static.Classes.SetBaseStat(Stat.Defense, num);
                    break;
                case "base_eva":
                    Static.Classes.SetBaseStat(Stat.Evasion, num);
                    break;
                case "base_block":
                    Static.Classes.SetBaseStat(Stat.Block, num);
                    break;
                case "base_parry":
                    Static.Classes.SetBaseStat(Stat.Parry, num);
                    break;
                case "base_crit_tax":
                    Static.Classes.SetBaseStat(Stat.CriticalRate, num);
                    break;
                case "base_crit_dmg":
                    Static.Classes.SetBaseStat(Stat.CriticalDamage, num);
                    break;
                case "base_mag_atk":
                    Static.Classes.SetBaseStat(Stat.MagicAttack, num);
                    break;
                case "base_mag_acc":
                    Static.Classes.SetBaseStat(Stat.MagicAccuracy, num);
                    break;
                case "base_mag_def":
                    Static.Classes.SetBaseStat(Stat.MagicDefense, num);
                    break;
                case "base_mag_res":
                    Static.Classes.SetBaseStat(Stat.MagicResist, num);
                    break;
                case "base_crit_taxmag":
                    Static.Classes.SetBaseStat(Stat.MagicCriticalRate, num);
                    break;
                case "base_crit_dmgmag":
                    Static.Classes.SetBaseStat(Stat.MagicCriticalDamage, num);
                    break;
                case "base_supp":
                    Static.Classes.SetBaseStat(Stat.DamageSuppression, num);
                    break;
                case "base_fire":
                    Static.Classes.SetBaseStat(Stat.AttributeFire, num);
                    break;
                case "base_water":
                    Static.Classes.SetBaseStat(Stat.AttributeWater, num);
                    break;
                case "base_earth":
                    Static.Classes.SetBaseStat(Stat.AttributeEarth, num);
                    break;
                case "base_wind":
                    Static.Classes.SetBaseStat(Stat.AttributeWind, num);
                    break;
                case "base_res_crit_tax":
                    Static.Classes.SetBaseStat(Stat.ResistCriticalRate, num);
                    break;
                case "base_res_crit_dmg":
                    Static.Classes.SetBaseStat(Stat.ResistCriticalDamage, num);
                    break;
                case "base_res_crit_taxmag":
                    Static.Classes.SetBaseStat(Stat.ResistMagicCriticalRate, num);
                    break;
                case "base_res_crit_dmgmag":
                    Static.Classes.SetBaseStat(Stat.ResistMagicCriticalDamage, num);
                    break;
                case "base_enmity":
                    Static.Classes.SetBaseStat(Stat.Enmity, num);
                    break;
                case "base_adddmg":
                    Static.Classes.SetBaseStat(Stat.AdditionalDamage, num);
                    break;
                case "base_heal":
                    Static.Classes.SetBaseStat(Stat.HealingPower, num);
                    break;
                case "base_con":
                    Static.Classes.SetBaseStat(Stat.Concentration, num);
                    break;
                case "base_atkspeed":
                    Static.Classes.SetBaseStat(Stat.AttackSpeed, num);
                    break;
                case "base_castspeed":
                    Static.Classes.SetBaseStat(Stat.CastSpeed, num);
                    break;
                case "base_res_silence":
                    Static.Classes.SetBaseStat(Stat.ResistSilence, num);
                    break;
                case "base_res_paralysis":
                    Static.Classes.SetBaseStat(Stat.ResistParalysis, num);
                    break;
                case "base_res_stun":
                    Static.Classes.SetBaseStat(Stat.ResistStun, num);
                    break;
                case "base_res_blind":
                    Static.Classes.SetBaseStat(Stat.ResistBlind, num);
                    break;
                case "base_regen_hp":
                    Static.Classes.SetBaseStat(Stat.RegenHP, num);
                    break;
                case "base_regen_mp":
                    Static.Classes.SetBaseStat(Stat.RegenMP, num);
                    break;
                case "base_regen_sp":
                    Static.Classes.SetBaseStat(Stat.RegenSP, num);
                    break;
            }
            
            RefreshSimulator();
        }

        /// <summary>
        /// Só permite número em textbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8) e.Handled = true;
        }

        private void Form1_Load(object sender, EventArgs e) {
            Configuration.ParseConfigFile(Environment.CurrentDirectory + @"\Config.txt");

            string error = string.Empty;

            MySQL.Server = Configuration.GetString("Server");
            MySQL.Port = Configuration.GetInt32("Port");
            MySQL.Username = Configuration.GetString("User");
            MySQL.Password = Configuration.GetString("Pass");
            MySQL.Database = Configuration.GetString("DB");

            if (!MySQL.Connect(out error)) {
                MessageBox.Show("Ocorreu um erro: " + error);
                Application.Exit(); 
            }

            Configuration.CloseConfigFile();

            InitialClasseBase();
            InitialClasseIncrement();

            base_gender.SelectedIndex = 0;

            //#######################################
            base_level.TextChanged += TextBox_TextChange;
            base_id.TextChanged += TextBox_TextChange;
            base_sprite_f.TextChanged += TextBox_TextChange;
            base_sprite_m.TextChanged += TextBox_TextChange;
            base_str.TextChanged += TextBox_TextChange;
            base_dex.TextChanged += TextBox_TextChange;
            base_agi.TextChanged += TextBox_TextChange;
            base_const.TextChanged += TextBox_TextChange;
            base_int.TextChanged += TextBox_TextChange;
            base_wis.TextChanged += TextBox_TextChange;
            base_cha.TextChanged += TextBox_TextChange;
            base_will.TextChanged += TextBox_TextChange;
            base_min.TextChanged += TextBox_TextChange;
            base_point.TextChanged += TextBox_TextChange;
            base_hp.TextChanged += TextBox_TextChange;
            base_mp.TextChanged += TextBox_TextChange;
            base_sp.TextChanged += TextBox_TextChange;
            base_regen_hp.TextChanged += TextBox_TextChange;
            base_regen_mp.TextChanged += TextBox_TextChange;
            base_regen_sp.TextChanged += TextBox_TextChange;
            base_atk.TextChanged += TextBox_TextChange;
            base_acc.TextChanged += TextBox_TextChange;
            base_def.TextChanged += TextBox_TextChange;
            base_eva.TextChanged += TextBox_TextChange;
            base_block.TextChanged += TextBox_TextChange;
            base_con.TextChanged += TextBox_TextChange;
            base_parry.TextChanged += TextBox_TextChange;
            base_crit_tax.TextChanged += TextBox_TextChange;
            base_crit_dmg.TextChanged += TextBox_TextChange;
            base_mag_atk.TextChanged += TextBox_TextChange;
            base_mag_acc.TextChanged += TextBox_TextChange;
            base_mag_def.TextChanged += TextBox_TextChange;
            base_mag_res.TextChanged += TextBox_TextChange;
            base_crit_taxmag.TextChanged += TextBox_TextChange;
            base_crit_dmgmag.TextChanged += TextBox_TextChange;
            base_supp.TextChanged += TextBox_TextChange;
            base_fire.TextChanged += TextBox_TextChange;
            base_water.TextChanged += TextBox_TextChange;
            base_earth.TextChanged += TextBox_TextChange;
            base_wind.TextChanged += TextBox_TextChange;
            base_res_crit_tax.TextChanged += TextBox_TextChange;
            base_res_crit_dmg.TextChanged += TextBox_TextChange;
            base_res_crit_taxmag.TextChanged += TextBox_TextChange;
            base_res_crit_dmgmag.TextChanged += TextBox_TextChange;
            base_enmity.TextChanged += TextBox_TextChange;
            base_adddmg.TextChanged += TextBox_TextChange;
            base_heal.TextChanged += TextBox_TextChange;
            base_atkspeed.TextChanged += TextBox_TextChange;
            base_castspeed.TextChanged += TextBox_TextChange;
            base_res_silence.TextChanged += TextBox_TextChange;
            base_res_paralysis.TextChanged += TextBox_TextChange;
            base_res_stun.TextChanged += TextBox_TextChange;
            base_res_blind.TextChanged += TextBox_TextChange;
            // Increment
            inc_id.TextChanged += TextBox_TextChange;
            inc_str.TextChanged += TextBox_TextChange;
            inc_dex.TextChanged += TextBox_TextChange;
            inc_agi.TextChanged += TextBox_TextChange;
            inc_const.TextChanged += TextBox_TextChange;
            inc_int.TextChanged += TextBox_TextChange;
            inc_min.TextChanged += TextBox_TextChange;
            inc_wis.TextChanged += TextBox_TextChange;
            inc_cha.TextChanged += TextBox_TextChange;
            inc_will.TextChanged += TextBox_TextChange;
            inc_point.TextChanged += TextBox_TextChange;
            ///////

            base_level.KeyPress += TextBox_KeyPress;
            base_id.KeyPress += TextBox_KeyPress;
            base_sprite_f.KeyPress += TextBox_KeyPress;
            base_sprite_m.KeyPress += TextBox_KeyPress;   
            base_str.KeyPress += TextBox_KeyPress;
            base_dex.KeyPress += TextBox_KeyPress;
            base_agi.KeyPress += TextBox_KeyPress;
            base_const.KeyPress += TextBox_KeyPress;
            base_int.KeyPress += TextBox_KeyPress;
            base_min.KeyPress += TextBox_KeyPress;
            base_wis.KeyPress += TextBox_KeyPress;
            base_cha.KeyPress += TextBox_KeyPress;
            base_will.KeyPress += TextBox_KeyPress;
            base_point.KeyPress += TextBox_KeyPress;
            base_hp.KeyPress += TextBox_KeyPress;
            base_mp.KeyPress += TextBox_KeyPress;
            base_sp.KeyPress += TextBox_KeyPress;
            base_atk.KeyPress += TextBox_KeyPress;
            base_acc.KeyPress += TextBox_KeyPress;
            base_def.KeyPress += TextBox_KeyPress;
            base_eva.KeyPress += TextBox_KeyPress;
            base_block.KeyPress += TextBox_KeyPress;
            base_parry.KeyPress += TextBox_KeyPress;
            base_crit_tax.KeyPress += TextBox_KeyPress;
            base_crit_dmg.KeyPress += TextBox_KeyPress;
            base_mag_atk.KeyPress += TextBox_KeyPress;
            base_mag_acc.KeyPress += TextBox_KeyPress;
            base_mag_def.KeyPress += TextBox_KeyPress;
            base_mag_res.KeyPress += TextBox_KeyPress;
            base_crit_taxmag.KeyPress += TextBox_KeyPress;
            base_crit_dmgmag.KeyPress += TextBox_KeyPress;
            base_supp.KeyPress += TextBox_KeyPress;
            base_fire.KeyPress += TextBox_KeyPress;
            base_water.KeyPress += TextBox_KeyPress;
            base_earth.KeyPress += TextBox_KeyPress;
            base_wind.KeyPress += TextBox_KeyPress;
            base_res_crit_tax.KeyPress += TextBox_KeyPress;
            base_res_crit_dmg.KeyPress += TextBox_KeyPress;
            base_res_crit_taxmag.KeyPress += TextBox_KeyPress;
            base_res_crit_dmgmag.KeyPress += TextBox_KeyPress;
            base_enmity.KeyPress += TextBox_KeyPress;
            base_adddmg.KeyPress += TextBox_KeyPress;
            base_heal.KeyPress += TextBox_KeyPress;
            base_con.KeyPress += TextBox_KeyPress;
            base_atkspeed.KeyPress += TextBox_KeyPress;
            base_castspeed.KeyPress += TextBox_KeyPress;
            base_res_silence.KeyPress += TextBox_KeyPress;
            base_res_paralysis.KeyPress += TextBox_KeyPress;
            base_res_stun.KeyPress += TextBox_KeyPress;
            base_res_blind.KeyPress += TextBox_KeyPress;
            // Increment
            inc_id.KeyPress += TextBox_KeyPress;
            inc_str.KeyPress += TextBox_KeyPress;
            inc_dex.KeyPress += TextBox_KeyPress;
            inc_agi.KeyPress += TextBox_KeyPress;
            inc_const.KeyPress += TextBox_KeyPress;
            inc_int.KeyPress += TextBox_KeyPress;
            inc_min.KeyPress += TextBox_KeyPress;
            inc_point.KeyPress += TextBox_KeyPress;
            inc_wis.KeyPress += TextBox_KeyPress;
            inc_cha.KeyPress += TextBox_KeyPress;
            inc_will.KeyPress += TextBox_KeyPress;
            edit_level.KeyPress += TextBox_KeyPress;
            edit_str.KeyPress += TextBox_KeyPress;
            edit_dex.KeyPress += TextBox_KeyPress;
            edit_agi.KeyPress += TextBox_KeyPress;
            edit_const.KeyPress += TextBox_KeyPress;
            edit_int.KeyPress += TextBox_KeyPress;
            edit_wis.KeyPress += TextBox_KeyPress;
            edit_will.KeyPress += TextBox_KeyPress;
            edit_min.KeyPress += TextBox_KeyPress;
            edit_cha.KeyPress += TextBox_KeyPress;

            edit_ok.Click += IncrementEditButton;
            edit_cancel.Click += IncrementEditButton;
        }

        /// <summary>
        /// Cancela o fechamento do formulário para fechar a conexão com a DB.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            e.Cancel = true;
            MySQL.Disconnect();
            e.Cancel = false;
        }   
    }
}