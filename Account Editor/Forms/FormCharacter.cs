using System;
using System.Windows.Forms;
using DarkUI.Forms;
using DarkUI.Controls;
using AccountEditor.Database;


namespace AccountEditor {
    public partial class FormCharacter : DarkForm {
        /// <summary>
        /// Guarda a informação do personagem.
        /// </summary>
        private Character pData = new Character();

        public FormCharacter() {
            InitializeComponent();
        
            txt_sprite.KeyPress += TextBox_KeyPress;
            txt_level.KeyPress += TextBox_KeyPress;
            txt_exp.KeyPress += TextBox_KeyPress;
            txt_points.KeyPress += TextBox_KeyPress;
            txt_world.KeyPress += TextBox_KeyPress;
            txt_region.KeyPress += TextBox_KeyPress;
            txt_posx.KeyPress += TextBox_KeyPress;
            txt_posy.KeyPress += TextBox_KeyPress;
            txt_str.KeyPress += TextBox_KeyPress;
            txt_dex.KeyPress += TextBox_KeyPress;
            txt_agi.KeyPress += TextBox_KeyPress;
            txt_con.KeyPress += TextBox_KeyPress;
            txt_int.KeyPress += TextBox_KeyPress;
            txt_wis.KeyPress += TextBox_KeyPress;
            txt_wil.KeyPress += TextBox_KeyPress;
            txt_min.KeyPress += TextBox_KeyPress;
            txt_cha.KeyPress += TextBox_KeyPress;
        }

        /// <summary>
        /// Deleta o personagem.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void strip_delete_Click(object sender, EventArgs e) {
            if (pData.ID == 0) { return; }

            var result = DarkMessageBox.ShowWarning("Deseja realmente apagar o personagem?", "Aviso", DarkDialogButton.YesNo);
            if (result == DialogResult.No) { return; }

            if (CharacterDB.DeleteCharacter(pData.ID) > 0) {
                DarkMessageBox.ShowInformation("O personagem foi deletado.", "Aviso");

                //carrega novamente os nomes dos personagens.
                Program.AccountForm.FillPlayerNames();

                Close();
            } else {
                DarkMessageBox.ShowWarning("Não foi possível fazer a exclusão.", "Aviso");
            }            
        }

        /// <summary>
        /// Salva as alterações do personagem.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void strip_save_Click(object sender, EventArgs e) {
            if (txt_name.Text.Trim().Length < 4) {
                DarkMessageBox.ShowInformation("O nome de personagem precisa ser maior que 4 caracteres.", "Aviso");
                return;
            }

            //verifica todos os campos
            VerifyTextbox();

            //preenche os dados
            FillCharacterData();

            if (CharacterDB.SaveCharacterData(pData) > 0) {
                DarkMessageBox.ShowInformation("O personagem foi salvo.", "Aviso");

                //carrega novamente os nomes dos personagens.
                Program.AccountForm.FillPlayerNames();
            }
            else {
                DarkMessageBox.ShowWarning("Não foi possível salvar as informações.", "Aviso");
            }
        }

        /// <summary>
        /// Abre o form e carrega o personagem.
        /// </summary>
        /// <param name="charname"></param>
        public void Show(string charname) {
            Show();

            pData = CharacterDB.LoadCharacterData(charname);

            FillTextbox();

            //completa as classes
            var count = Static.Classes.Count;
            for (var n = 0; n < count; n++) {
                list_classes.Items.Add(new DarkListItem(Static.Classes[n].Name));
            }

            //seleciona a classe do usuario
            var index = Static.FindIndexByID(pData.ClasseID);
            if (index != -1) { list_classes.SelectItem(index); }
        }

        /// <summary>
        /// Verifica se os campos estão corretos.
        /// </summary>
        /// <returns></returns>
        private void VerifyTextbox() {
            if (txt_sprite.Text.Trim().Length == 0) { txt_sprite.Text = "1"; }
            if (txt_level.Text.Trim().Length == 0) { txt_level.Text = "1"; }
            if (txt_exp.Text.Trim().Length == 0) { txt_exp.Text = "0"; }
            if (txt_points.Text.Trim().Length == 0) { txt_points.Text = "0"; }
            if (txt_world.Text.Trim().Length == 0) { txt_world.Text = "1"; }
            if (txt_region.Text.Trim().Length == 0) { txt_region.Text = "1"; }
            if (txt_posx.Text.Trim().Length == 0) { txt_posx.Text = "0"; }
            if (txt_posy.Text.Trim().Length == 0) { txt_posy.Text = "0"; }
            if (txt_str.Text.Trim().Length == 0) { txt_str.Text = "0"; }
            if (txt_dex.Text.Trim().Length == 0) { txt_dex.Text = "0"; }
            if (txt_agi.Text.Trim().Length == 0) { txt_agi.Text = "0"; }
            if (txt_con.Text.Trim().Length == 0) { txt_con.Text = "0"; }
            if (txt_int.Text.Trim().Length == 0) { txt_int.Text = "0"; }
            if (txt_wis.Text.Trim().Length == 0) { txt_wis.Text = "0"; }
            if (txt_wil.Text.Trim().Length == 0) { txt_wil.Text = "0"; }
            if (txt_min.Text.Trim().Length == 0) { txt_min.Text = "0"; }
            if (txt_cha.Text.Trim().Length == 0) { txt_cha.Text = "0"; }
        }

        /// <summary>
        /// Preenche os controles com a informação do personagem.
        /// </summary>
        private void FillTextbox() {
            txt_name.Text = pData.Name;
            txt_sprite.Text = pData.Sprite.ToString();
            txt_level.Text = pData.Level.ToString();
            txt_exp.Text = pData.Exp.ToString();
            txt_points.Text = pData.Points.ToString();

            txt_world.Text = pData.WorldID.ToString();
            txt_region.Text = pData.RegionID.ToString();
            txt_posx.Text = pData.PosX.ToString();
            txt_posy.Text = pData.PosY.ToString();

            txt_str.Text = pData.Strenght.ToString();
            txt_dex.Text = pData.Dexterity.ToString();
            txt_agi.Text = pData.Agility.ToString();
            txt_con.Text = pData.Constitution.ToString();
            txt_int.Text = pData.Intelligence.ToString();
            txt_wis.Text = pData.Wisdom.ToString();
            txt_wil.Text = pData.Will.ToString();
            txt_min.Text = pData.Mind.ToString();
            txt_cha.Text = pData.Charisma.ToString();
        }

        /// <summary>
        /// Preenche o personagem com as informações dos controles.
        /// </summary>
        private void FillCharacterData() {
            pData.Name = txt_name.Text;
            pData.Sprite = short.Parse(txt_sprite.Text);
            pData.Level  = int.Parse(txt_level.Text);
            pData.Exp = int.Parse(txt_exp.Text);
            pData.Points = int.Parse(txt_points.Text);
            pData.WorldID = short.Parse(txt_world.Text);
            pData.RegionID = short.Parse(txt_region.Text);
            pData.PosX = short.Parse(txt_posx.Text);
            pData.PosY = short.Parse(txt_posy.Text);
            pData.Strenght = int.Parse(txt_str.Text);
            pData.Dexterity = int.Parse(txt_dex.Text);
            pData.Agility = int.Parse(txt_agi.Text);
            pData.Constitution = int.Parse(txt_con.Text);
            pData.Intelligence = int.Parse(txt_int.Text);
            pData.Wisdom = int.Parse(txt_wis.Text);
            pData.Will = int.Parse(txt_wil.Text);
            pData.Mind = int.Parse(txt_min.Text);
            pData.Charisma = int.Parse(txt_cha.Text);
            var index = list_classes.SelectedIndices[0];
            pData.ClasseID = Static.Classes[index].ID;

        }

        /// <summary>
        /// Não permite que letras sejam inseridas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsDigit(e.KeyChar) & e.KeyChar != (char)Keys.Back) { e.Handled = true; }
        }
    }
}
