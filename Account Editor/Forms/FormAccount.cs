using System;
using System.Windows.Forms;
using DarkUI.Controls;
using DarkUI.Forms;
using AccountEditor.Database;

namespace AccountEditor {
    public partial class FormAccount : DarkForm {
        /// <summary>
        /// Guarda a informação do usuário.
        /// </summary>
        Account pData = new Account();

        public FormAccount() {
            InitializeComponent();

            btn_char1.Click += ButtonChar_Click;
            btn_char2.Click += ButtonChar_Click;
            btn_char3.Click += ButtonChar_Click;
            btn_char4.Click += ButtonChar_Click;

            txt_pin.KeyPress += TextBox_KeyPress;
            txt_cash.KeyPress += TextBox_KeyPress;
            txt_access.KeyPress += TextBox_KeyPress;
            txt_language.KeyPress += TextBox_KeyPress;

        }

        /// <summary>
        /// Apaga o usuário.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void strip_delete_Click(object sender, EventArgs e) {
            if (pData.ID == 0) {
                DarkMessageBox.ShowInformation("Você precisa carregar um usuário para fazer essa ação.", "Aviso");
                return;
            }

            var result = DarkMessageBox.ShowWarning("Deseja realmente apagar este usuário?", "Aviso", DarkDialogButton.YesNo);
            if (result == DialogResult.No) { return; }

            if (AccountDB.DeleteAccountData(pData.ID) > 0) {
                if (CharacterDB.DeleteAllCharacter(pData.ID) > 0) {
                    DarkMessageBox.ShowInformation("Usuário deletado.", "Aviso");

                    Clear();
                    return;
                }
            }

            DarkMessageBox.ShowWarning("Não foi possível fazer a exclusão.", "Aviso");
        }

        /// <summary>
        /// Salva os dados.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void strip_save_Click(object sender, EventArgs e) {
            if (!VerifyTextbox()) { return; }

            FillPlayerData();

            if (AccountDB.SaveAccountData(pData) > 0) {
                DarkMessageBox.ShowInformation("As informações do usuário foram atualizadas.", "Aviso");

                Clear();
                return;
            }

            DarkMessageBox.ShowWarning("Não foi possível salvar os dados.", "Aviso");
        }

        /// <summary>
        /// Realiza a pesquisa e preenche com os dados.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_find_Click(object sender, EventArgs e) {
            var user = txt_finduser.Text.Trim();

            if (string.IsNullOrEmpty(user)) { return; }

            if (!ExistAccount()) {
                DarkMessageBox.ShowError("Usuário não encontrado.", "Aviso");
                return;
            }

            pData = AccountDB.LoadAccountData(user);
            pData.CharacterName = CharacterDB.GetCharacterNames(pData.ID);

            FillControl();
        }

        /// <summary>
        /// Botões de cada slot de personagem.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonChar_Click(object sender, EventArgs e) {
            if (pData.ID == 0) { return; }

            var button = (DarkButton)sender;

            if (button.Text == "...") {
                NewCharacter newCharacter = new NewCharacter();
                // ####gambiarra####
                //aproveita o uso do TabIndex para simular um índice do controle.
                newCharacter.Show(pData.ID, button.TabIndex - 2);
                // ####gambiarra####
            }
            else {
                FormCharacter formCharacter = new FormCharacter();
                formCharacter.Show(button.Text);
            }
        }

        /// <summary>
        /// Verifica se os campos estão corretos.
        /// </summary>
        /// <returns></returns>
        private bool VerifyTextbox() {
            if (txt_user.Text.Trim().Length < 4) {
                DarkMessageBox.ShowInformation("O nome de usuário deve ser maior que 4 digítos.", "Informação");
                return false;
            }

            if (txt_password.Text.Trim().Length < 4) {
                DarkMessageBox.ShowInformation("A senha de usuário deve ser maior que 4 digítos.", "Informação");
                return false;
            }

            if (txt_language.Text.Trim().Length == 0) { txt_language.Text = "1"; }
            if (txt_access.Text.Trim().Length == 0) { txt_access.Text = "1"; }             
            if (txt_cash.Text.Trim().Length == 0) { txt_cash.Text = "0";}

            return true;
        }

        /// <summary>
        /// Verifica se o usuário já existe.
        /// </summary>
        /// <returns></returns>
        private bool ExistAccount() {
            return (AccountDB.ExistAccount(txt_finduser.Text.Trim())) ? true : false;
        }

        /// <summary>
        /// Preenche os controles com a informação do usuário.
        /// </summary>
        private void FillControl() {
            lbl_id.Text = $"Identidade {pData.ID}";
            txt_user.Text = pData.Username;
            txt_password.Text = pData.Password;
            txt_email.Text = pData.Email;
            txt_name.Text = pData.FirstName;
            txt_lastname.Text = pData.LastName;
            txt_country.Text = pData.Country;
            txt_language.Text = pData.Language.ToString();
            txt_pin.Text = pData.Pin;
            txt_access.Text = pData.Access.ToString();
            txt_cash.Text = pData.Cash.ToString();
            lbl_ipactual.Text = pData.CurrentIp;
            lbl_iplast.Text = pData.IpLast;
            lbl_ipregister.Text = pData.CreatorIp;
            lbl_datelastlogin.Text = pData.DateLastLogin.ToString();
            lbl_dateregister.Text = pData.DateCreated.ToString();
            check_activated.Checked = Convert.ToBoolean(pData.Activated);

            FillPlayerNames();
        } 

        /// <summary>
        /// Preenche o usuário com os dados dos controles.
        /// </summary>
        private void FillPlayerData() {
            pData.Username = txt_user.Text.Trim();
            pData.Password = txt_password.Text.Trim();
            pData.Email = txt_email.Text.Trim();
            pData.FirstName = txt_name.Text.Trim();
            pData.LastName = txt_lastname.Text.Trim();
            pData.Country = txt_country.Text.Trim();
            pData.Language = Convert.ToByte(txt_language.Text.Trim());
            pData.Pin = txt_pin.Text.Trim();
            pData.Access = Convert.ToInt16(txt_access.Text.Trim());
            pData.Cash = Convert.ToInt16(txt_cash.Text.Trim());
            pData.Activated = Convert.ToByte(check_activated.Checked);
        }

        /// <summary>
        /// Atualiza os nomes dos personagens.
        /// </summary>
        public void FillPlayerNames() {
            pData.CharacterName = CharacterDB.GetCharacterNames(pData.ID);

            btn_char1.Text = pData.CharacterName[0];
            btn_char2.Text = pData.CharacterName[1];
            btn_char3.Text = pData.CharacterName[2];
            btn_char4.Text = pData.CharacterName[3];
        }

        /// <summary>
        /// Limpa os dados dos controles.
        /// </summary>
        private void Clear() {
            txt_finduser.Clear();

            lbl_id.Text = $"Identidade 0";
            txt_user.Text = string.Empty;
            txt_password.Text = string.Empty;
            txt_email.Text = string.Empty;
            txt_name.Text = string.Empty;
            txt_lastname.Text = string.Empty;
            txt_country.Text = string.Empty;
            txt_language.Text = "1";
            txt_pin.Text = "0";
            txt_access.Text = "1";
            txt_cash.Text = "0";
            lbl_ipactual.Text = "0.0.0.0";
            lbl_iplast.Text = "0.0.0.0";
            lbl_ipregister.Text = "0.0.0.0";
            lbl_datelastlogin.Text = "##/##/####";
            lbl_dateregister.Text = "##/##/####";
            check_activated.Checked = false;

            btn_char1.Text = "...";
            btn_char2.Text = "...";
            btn_char3.Text = "...";
            btn_char4.Text = "...";
        }

        /// <summary>
        /// Não permite que letras sejam inseridas em alguns textbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsDigit(e.KeyChar) & e.KeyChar != (char)Keys.Back) { e.Handled = true; }
        }
    }
}
