using System;
using DarkUI.Forms;
using DarkUI.Controls;
using AccountEditor.Database;

namespace AccountEditor {
    public partial class NewCharacter : DarkForm {
        private int _accountID, _charSlot;

        public NewCharacter() {
            InitializeComponent();
        }

        /// <summary>
        /// Insere um novo personagem.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void strip_save_Click(object sender, System.EventArgs e) {
            VerifyTextbox();

            if (CharacterDB.ExistCharacter(txt_user.Text)) {
                DarkMessageBox.ShowWarning("Este usuário já está sendo utilizado.", "Aviso");
                return;
            }

            var index = list_classes.SelectedIndices[0];
            var character = FillCharacterData();
            var classe = Static.Classes[index];

            if (CharacterDB.InsertCharacter(_accountID, character, classe) > 0) {
                DarkMessageBox.ShowInformation("O personagem foi cadastrado.", "Aviso");
                Program.AccountForm.FillPlayerNames();
                Clear();
            }
            else {
                DarkMessageBox.ShowWarning("Não foi possível cadastrar.", "Aviso");
            }
        }

        public void Show(int accountID, int charslot) {
            _accountID = accountID;
            _charSlot = charslot;

            Show();

            var count = Static.Classes.Count;
            for (var n = 0; n < count; n++) {
                list_classes.Items.Add(new DarkListItem(Static.Classes[n].Name));
            }
        }

        /// <summary>
        /// Preenche com os dados do controle.
        /// </summary>
        /// <returns></returns>
        private Character FillCharacterData() {
            var character = new Character();
            var index = list_classes.SelectedIndices[0];

            character.Name = txt_user.Text.Trim();
            character.Sprite = Convert.ToInt16(txt_sprite.Text.Trim());
            character.WorldID = Convert.ToInt16(txt_world.Text.Trim());
            character.RegionID = Convert.ToInt16(txt_region.Text.Trim());
            character.PosX = Convert.ToInt16(txt_posx.Text.Trim());
            character.PosY = Convert.ToInt16(txt_posy.Text.Trim());
            character.ClasseID = Static.Classes[index].ID;
            character.CharSlot = _charSlot;

            return character;
        }

        /// <summary>
        /// Verifica se os campos estão corretos.
        /// </summary>
        /// <returns></returns>
        private void VerifyTextbox() {
            if (txt_sprite.Text.Trim().Length == 0) { txt_sprite.Text = "1"; }
            if (txt_world.Text.Trim().Length == 0) { txt_world.Text = "1"; }
            if (txt_region.Text.Trim().Length == 0) { txt_region.Text = "1"; }
            if (txt_posx.Text.Trim().Length == 0) { txt_posx.Text = "0"; }
            if (txt_posy.Text.Trim().Length == 0) { txt_posy.Text = "0"; }
        }

        private void Clear() {
            txt_user.Clear();
            txt_sprite.Text = "1";
            txt_world.Text = "1";
            txt_region.Text = "1";
            txt_posx.Text = "0";
            txt_posy.Text = "0";
        }


    }
}
