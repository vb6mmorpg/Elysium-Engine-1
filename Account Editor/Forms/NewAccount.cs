using System;
using System.Windows.Forms;
using DarkUI.Forms;
using AccountEditor.Database;

namespace AccountEditor {
    public partial class NewAccount : DarkForm {
        public NewAccount() {
            InitializeComponent();

            txt_cash.KeyPress += TextBox_KeyPress;
            txt_access.KeyPress += TextBox_KeyPress;
            txt_pin.KeyPress += TextBox_KeyPress;
        }

        /// <summary>
        /// Salva o novo usuário.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_save_Click(object sender, EventArgs e) {
            if (!VerifyTextbox()) { return; }

            if (ExistAccount()) {
                DarkMessageBox.ShowInformation("Este usuário já está cadastrado.", "Aviso");
                return;
            }

            if (AccountDB.InsertAccount(FillAccountData()) > 0) {
                DarkMessageBox.ShowInformation("O usuário foi cadastrado.", "Sucesso");
                Clear();
            }
            else {
                DarkMessageBox.ShowError("Não foi possível cadastrar.", "Aviso");
            }
        }

        /// <summary>
        /// Preenche o usuário com os dados dos controles
        /// </summary>
        /// <returns></returns>
        private Account FillAccountData() {
            var pData = new Account();
            pData.Username = txt_user.Text.Trim();
            pData.Password = txt_password.Text.Trim();
            pData.Email = txt_email.Text.Trim();
            pData.FirstName = txt_name.Text.Trim();
            pData.LastName = txt_lastname.Text.Trim();
            pData.Country = txt_country.Text.Trim();
            pData.Language = 1;
            pData.Pin = txt_pin.Text.Trim();
            pData.Access = Convert.ToInt16(txt_access.Text.Trim());
            pData.Cash = Convert.ToInt32(txt_cash.Text.Trim());
            pData.Activated = 1;

            return pData;
        }

        /// <summary>
        /// Verifica se o usuário já existe.
        /// </summary>
        /// <returns></returns>
        private bool ExistAccount() {
            return (AccountDB.ExistAccount(txt_user.Text.Trim())) ? true : false;
        }

        /// <summary>
        /// Verifica se há dados corretos no textbox.
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

            return true;
        }

        /// <summary>
        /// Não permite que letras sejam inseridas em alguns textbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsDigit(e.KeyChar) & e.KeyChar != (char)Keys.Back) { e.Handled = true; }
        }

        /// <summary>
        /// Limpa todos campos.
        /// </summary>
        private void Clear() {
            txt_user.Clear();
            txt_password.Clear();
            txt_email.Clear();
            txt_name.Clear();
            txt_lastname.Clear();
            txt_country.Clear();
            txt_language.Clear();
            txt_pin.Clear();
            txt_access.Text = "1";
            txt_cash.Text = "0";
        }
    }
}
