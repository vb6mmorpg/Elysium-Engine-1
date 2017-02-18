using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Account_Editor.Common;
using Account_Editor.MySQL;

namespace Account_Editor
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Variaveis
        /// </summary>
        public Common_DB LS_Database;
        public Common_DB GS_Database;
        public EditChar[] FormEdit;

        public void LoadChars()
        {
            // Carregar Personagens
            FormEdit = new EditChar[4];
            lstChars.Items.Clear();
            for (int i = 0; i <= 3; i++)
            {
                FormEdit[i] = new EditChar();
                FormEdit[i].Character = new Characters_DB();
                if (FormEdit[i].Character.Load(Account_DB.ID, i))
                {
                    lstChars.Items.Add("- " + FormEdit[i].Character.Name);
                }
                else
                {
                    lstChars.Items.Add("- Vazio");
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (LS_Database.mysql_connection.State != ConnectionState.Closed)
            {
                if (Account_DB.Load(txtSearch.Text))
                {
                    // Atualizar Janela
                    grpChars.Enabled = true;
                    grpData.Enabled = true;
                    grpData.Visible = true;
                    this.Width = 808;
                    pnlConsole.Top = 166;
                    pnlConsole.Height = 100;
                    rtxtConsole.ScrollToCaret();

                    // Atualiar Textos e Labeis
                    lblID.Text = "ID: " + Account_DB.ID;
                    txtAccount.Text = Account_DB.Account;
                    txtPass.Text = Account_DB.Password;
                    txtEmail.Text = Account_DB.Email;
                    txtPin.Text = Account_DB.Pin;
                    txtCash.Text = Account_DB.Cash.ToString();
                    cmbLanguage.SelectedIndex = Account_DB.Language - 1;
                    cmbAccess.SelectedIndex = Account_DB.Access - 1;
                    cmbActive.SelectedIndex = Convert.ToInt32(Account_DB.Active);
                    txtName.Text = Account_DB.FirstName;
                    txtLastName.Text = Account_DB.LastName;
                    txtLocation.Text = Account_DB.Location;
                    lblDRegister.Text = "D. de Registro: " + Account_DB.Date_Register.ToString();
                    lblDLogin.Text = "D. de Login: " + Account_DB.Date_Login.ToString();
                    lblIpRegister.Text = "IP de Registro: " + Account_DB.Creator_Ip;
                    lblIpLogin.Text = "Ip do Ultimo Login: " + Account_DB.Last_Ip;
                    lblIpCurrent.Text = "Ip Atual: " + Account_DB.Current_Ip;

                    // Checar se o jogador está conectado, ou não
                    // 1 = Conectado    2 = Desconectado
                    if (Account_DB.Logged == 1)
                    {
                        lblLogged.ForeColor = Color.Green;
                        lblLogged.Text = "Online";
                    }
                    else
                    {
                        lblLogged.ForeColor = Color.Red;
                        lblLogged.Text = "Offline";
                    }

                    LoadChars();

                    // Atualizar console
                    rtxtConsole.ScrollToCaret();
                    btnSave.Enabled = false;
                    WriteLog("Conta " + Account_DB.Account + " Carregada.", Color.DarkCyan);
                }
                else // Caso esse conta não exista, o formulário fica pequenino e exibe mensagem
                {
                    // Desabilitar caixas
                    grpChars.Enabled = false;
                    grpData.Enabled = false;
                    grpData.Visible = false;
                    btnSave.Enabled = false;

                    // Ajustar tamanho da janela
                    this.Width = 375;
                    pnlConsole.Top = 56;
                    pnlConsole.Height = 209;

                    // Atualizar console
                    rtxtConsole.ScrollToCaret();
                    WriteLog("Essa conta não existe!", Color.Red);
                }
            }
            else // Caso esteja desconectado do servidor, reconectar!
            {
                Connect_Mysql();
                if (LS_Database.mysql_connection.State != ConnectionState.Closed) 
                {
                    // Reniciar função depois de conectado
                    this.btnSearch_Click(null, null);
                    rtxtConsole.ScrollToCaret();
                }
            }
        }

        /// <summary>
        /// Conectar com o servidor MySQL
        /// </summary>
        public void Connect_Mysql()
        {
            string tempError = string.Empty;
            
            // Arquivo de configuração.
            string sConfig = "Config.txt";

            // Iniciar LoginServer_DB
            try 
            {
                // Definir dados do Login Server
                LS_Database = new Common_DB();
                LS_Database.Server = ConfigGet.ConfigGetString(sConfig, "LS_MySQL_IP");
                LS_Database.Port = (int)ConfigGet.ConfigGetLong(sConfig, "LS_MySQL_Port");
                LS_Database.Username = ConfigGet.ConfigGetString(sConfig, "LS_MySQL_User");
                LS_Database.Password = ConfigGet.ConfigGetString(sConfig, "LS_MySQL_Pass");
                LS_Database.Database = ConfigGet.ConfigGetString(sConfig, "LS_MySQL_DB");
               
                // Iniciar conexão
                if (!LS_Database.Connect(out tempError))
                {
                    WriteLog(tempError, Color.Red);
                }
                else // Se não der error
                {
                    WriteLog("Conectado com o Login DB", Color.DarkCyan);
                }
            }
            catch (Exception ex) // Caso dê um error diferente
            {
                WriteLog(ex.Message, Color.Red);
            }

            // Iniciar GameServer_DB
            try
            {
                // Definir dados do Login Server
                GS_Database = new Common_DB();
                GS_Database.Server = ConfigGet.ConfigGetString(sConfig, "GS_MySQL_IP");
                GS_Database.Port = (int)ConfigGet.ConfigGetLong(sConfig, "GS_MySQL_Port");
                GS_Database.Username = ConfigGet.ConfigGetString(sConfig, "GS_MySQL_User");
                GS_Database.Password = ConfigGet.ConfigGetString(sConfig, "GS_MySQL_Pass");
                GS_Database.Database = ConfigGet.ConfigGetString(sConfig, "GS_MySQL_DB");

                // Iniciar conexão
                if (!GS_Database.Connect(out tempError))
                {
                    WriteLog(tempError, Color.Red);
                }
                else // Se não der error
                {
                    WriteLog("Conectado com o Game DB", Color.DarkCyan);
                }
            }
            catch (Exception ex) // Caso dê um error diferente
            {
                WriteLog(ex.Message, Color.Red);
            }
        }


        /// <summary>
        /// Texto para ser exibido no console
        /// </summary>
        /// <param name="log">Texto do Log</param>
        /// <param name="color">Cor do Texto</param>
        public void WriteLog(string log, Color color)
        {
            rtxtConsole.SelectionStart = rtxtConsole.TextLength;
            rtxtConsole.SelectionLength = 0;

            rtxtConsole.SelectionColor = color;
            rtxtConsole.AppendText(Environment.NewLine + DateTime.Now + ": " + log);
            rtxtConsole.SelectionColor = color;
            rtxtConsole.ScrollToCaret();
            Application.DoEvents();
        }

        // Função ao Clicar no botão Salvar
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Checar se o Pin tem 8 ou 0 Digitos
            if (txtPin.TextLength != 8 && txtPin.TextLength != 0)
            {
                WriteLog("O Pin deve conter 8 ou 0 caracteres.", Color.Red);
                return; 
            }

            // Atualizar Variaveis da conta para serem salvas no Database
            Account_DB.Account = txtAccount.Text;
            Account_DB.Password = txtPass.Text;
            Account_DB.Email = txtEmail.Text;
            Account_DB.Pin = txtPin.Text;
            Account_DB.Cash = int.Parse(txtCash.Text);
            Account_DB.Language = Convert.ToByte(cmbLanguage.SelectedIndex + 1);
            Account_DB.Active = Convert.ToByte(cmbActive.SelectedIndex);
            Account_DB.FirstName = txtName.Text;
            Account_DB.LastName = txtLastName.Text;
            Account_DB.Location = txtLocation.Text;

            // Iniciar função de salvar
            if (Account_DB.Save(Account_DB.ID))
            {
                WriteLog("Conta " + Account_DB.ID + " foi modificada!", Color.DarkCyan);
            }
            else // Caso aconteça algum erro durante o salvamento
            {
                WriteLog("Houve algum erro ao savar a conta", Color.Red);
            }
        }

        // Função ao clicar no botão de editar
        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Checar se existe um personagem no Slot
            if (FormEdit[lstChars.SelectedIndex].Character.ID > 0)
            {
                    // Caso a janela já está visivel
                if (!FormEdit[lstChars.SelectedIndex].Visible)
                {
                    FormEdit[lstChars.SelectedIndex].Show();
                    FormEdit[lstChars.SelectedIndex].UpdateData();
                }
                else // Se estiver visivel apenas reativa
                {
                    FormEdit[lstChars.SelectedIndex].Activate();
                }
            }
        }

        #region "Funções das TexBoxs e Modificações"
        private void txtPin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void txtCash_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void txtAccount_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void txtPin_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void cmbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void cmbAccess_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void txtCash_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void txtLocation_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void cmbActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }
        #endregion

    }
}
