using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Account_Editor.MySQL;

namespace Account_Editor
{
    public partial class EditChar : Form
    {
        /// <summary>
        /// Variaveis
        /// </summary>
        public Characters_DB Character;

        // Inicialiar
        public EditChar()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Atualizar dados do Formulário
        /// </summary>
        public void UpdateData()
        {
            // Aqui ficarão as atualiações
            // Dados
            lblID.Text = "ID: " + Character.ID;
            lblSlot.Text = "Slot: " + (Character.Slot + 1);
            lblIDAccount.Text = "Id da Conta: " + Account_DB.ID;
            txtName.Text = Character.Name;
            cmbClass.SelectedIndex = Character.Class_ID;
            cmbGender.SelectedIndex = Character.Gender;
            txtGuild.Text = Character.Guild_ID.ToString();
            txtSprite.Text = Character.Sprite.ToString();
            txtLevel.Text = Character.Level.ToString();
            txtExp.Text = Character.EXP.ToString();

            // Vitais
            txtHP.Text = Character.HP.ToString();
            txtMP.Text = Character.MP.ToString();
            txtSP.Text = Character.SP.ToString();

            // Stats
            txtStr.Text = Character.Strenght.ToString();
            txtDex.Text = Character.Dexterity.ToString();
            txtAgi.Text = Character.Agility.ToString();
            txtVit.Text = Character.Vitality.ToString();
            txtInt.Text = Character.Intelligence.ToString();
            txtMind.Text = Character.Mind.ToString();
            txtPoints.Text = Character.Points.ToString();

            // Localização
            txtWorld.Text = Character.World.ToString();
            txtLand.Text = Character.Region.ToString();
            txtX.Text = Character.X.ToString();
            txtY.Text = Character.Y.ToString();

            btnSave.Enabled = false; // Desabilitar botão de salvar
        }

        // Cancelar
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            btnSave.Enabled = false;
        }

        /// <summary>
        /// Habilitar o botão de salvar quando tiver alguma modificação
        /// </summary>
        private void All_Changed(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        /// <summary>
        /// Permitir apenas numero em algumas textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void All_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Atualizar Variaveis da conta para serem salvas no Database
            // Dados
            Character.Name = txtName.Text.Trim();
            Character.Class_ID = cmbClass.SelectedIndex;
            Character.Gender = cmbGender.SelectedIndex;
            Character.Guild_ID = int.Parse(txtGuild.Text.Trim());
            Character.Sprite = int.Parse(txtSprite.Text.Trim());
            Character.Level = int.Parse(txtLevel.Text.Trim());
            Character.EXP = long.Parse(txtExp.Text.Trim());

            // Vitais
            Character.HP = int.Parse(txtHP.Text.Trim());
            Character.MP = int.Parse(txtMP.Text.Trim());
            Character.SP = int.Parse(txtSP.Text.Trim());

            // Stats
            Character.Strenght = int.Parse(txtStr.Text.Trim());
            Character.Dexterity = int.Parse(txtDex.Text.Trim());
            Character.Agility = int.Parse(txtAgi.Text.Trim());
            Character.Vitality = int.Parse(txtVit.Text.Trim());
            Character.Intelligence = int.Parse(txtInt.Text.Trim());
            Character.Mind = int.Parse(txtMind.Text.Trim());
            Character.Points = int.Parse(txtPoints.Text.Trim());

            // Iniciar função de salvar
            if (Character.Save())
            {
                Program.EditForm.WriteLog("Personagem " + Character.Name.Trim() + " foi modificado!", Color.DarkCyan);
                Program.EditForm.LoadChars();
            }
            else // Caso aconteça algum erro durante o salvamento
            {
                Program.EditForm.WriteLog("Houve algum erro ao savar o personagem", Color.Red);
            }

            this.Visible = false;
        }

    }
}
