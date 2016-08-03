namespace Account_Editor
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpSearch = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.grpChars = new System.Windows.Forms.GroupBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.lstChars = new System.Windows.Forms.ListBox();
            this.grpData = new System.Windows.Forms.GroupBox();
            this.cmbActive = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblLogged = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblIpCurrent = new System.Windows.Forms.Label();
            this.lblIpLogin = new System.Windows.Forms.Label();
            this.lblIpRegister = new System.Windows.Forms.Label();
            this.lblDLogin = new System.Windows.Forms.Label();
            this.lblDRegister = new System.Windows.Forms.Label();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.lblLocation = new System.Windows.Forms.Label();
            this.txtCash = new System.Windows.Forms.TextBox();
            this.lblCash = new System.Windows.Forms.Label();
            this.cmbAccess = new System.Windows.Forms.ComboBox();
            this.lblAccess = new System.Windows.Forms.Label();
            this.txtAccount = new System.Windows.Forms.TextBox();
            this.cmbLanguage = new System.Windows.Forms.ComboBox();
            this.lblLanguage = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtPin = new System.Windows.Forms.TextBox();
            this.lblPin = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.lblPass = new System.Windows.Forms.Label();
            this.lblAccount = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.pnlConsole = new System.Windows.Forms.Panel();
            this.rtxtConsole = new System.Windows.Forms.RichTextBox();
            this.grpSearch.SuspendLayout();
            this.grpChars.SuspendLayout();
            this.grpData.SuspendLayout();
            this.pnlConsole.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpSearch
            // 
            this.grpSearch.BackColor = System.Drawing.SystemColors.Control;
            this.grpSearch.Controls.Add(this.btnSearch);
            this.grpSearch.Controls.Add(this.txtSearch);
            this.grpSearch.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.grpSearch.Location = new System.Drawing.Point(12, 12);
            this.grpSearch.Name = "grpSearch";
            this.grpSearch.Size = new System.Drawing.Size(335, 41);
            this.grpSearch.TabIndex = 0;
            this.grpSearch.TabStop = false;
            this.grpSearch.Text = "Usuário:";
            // 
            // btnSearch
            // 
            this.btnSearch.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSearch.Location = new System.Drawing.Point(267, 14);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(63, 22);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Procurar";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(6, 15);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(262, 20);
            this.txtSearch.TabIndex = 0;
            // 
            // grpChars
            // 
            this.grpChars.BackColor = System.Drawing.SystemColors.Control;
            this.grpChars.Controls.Add(this.btnEdit);
            this.grpChars.Controls.Add(this.lstChars);
            this.grpChars.Enabled = false;
            this.grpChars.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.grpChars.Location = new System.Drawing.Point(12, 55);
            this.grpChars.Name = "grpChars";
            this.grpChars.Size = new System.Drawing.Size(335, 107);
            this.grpChars.TabIndex = 1;
            this.grpChars.TabStop = false;
            this.grpChars.Text = "Personagens";
            // 
            // btnEdit
            // 
            this.btnEdit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnEdit.Location = new System.Drawing.Point(5, 75);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(325, 26);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Editar";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // lstChars
            // 
            this.lstChars.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstChars.FormattingEnabled = true;
            this.lstChars.Items.AddRange(new object[] {
            "-",
            "-",
            "-",
            "-"});
            this.lstChars.Location = new System.Drawing.Point(6, 19);
            this.lstChars.Name = "lstChars";
            this.lstChars.Size = new System.Drawing.Size(323, 54);
            this.lstChars.TabIndex = 0;
            // 
            // grpData
            // 
            this.grpData.BackColor = System.Drawing.SystemColors.Control;
            this.grpData.Controls.Add(this.cmbActive);
            this.grpData.Controls.Add(this.label2);
            this.grpData.Controls.Add(this.lblLogged);
            this.grpData.Controls.Add(this.btnSave);
            this.grpData.Controls.Add(this.lblIpCurrent);
            this.grpData.Controls.Add(this.lblIpLogin);
            this.grpData.Controls.Add(this.lblIpRegister);
            this.grpData.Controls.Add(this.lblDLogin);
            this.grpData.Controls.Add(this.lblDRegister);
            this.grpData.Controls.Add(this.txtLocation);
            this.grpData.Controls.Add(this.lblLocation);
            this.grpData.Controls.Add(this.txtCash);
            this.grpData.Controls.Add(this.lblCash);
            this.grpData.Controls.Add(this.cmbAccess);
            this.grpData.Controls.Add(this.lblAccess);
            this.grpData.Controls.Add(this.txtAccount);
            this.grpData.Controls.Add(this.cmbLanguage);
            this.grpData.Controls.Add(this.lblLanguage);
            this.grpData.Controls.Add(this.txtEmail);
            this.grpData.Controls.Add(this.lblEmail);
            this.grpData.Controls.Add(this.txtLastName);
            this.grpData.Controls.Add(this.txtName);
            this.grpData.Controls.Add(this.txtPin);
            this.grpData.Controls.Add(this.lblPin);
            this.grpData.Controls.Add(this.lblLastName);
            this.grpData.Controls.Add(this.lblName);
            this.grpData.Controls.Add(this.txtPass);
            this.grpData.Controls.Add(this.lblPass);
            this.grpData.Controls.Add(this.lblAccount);
            this.grpData.Controls.Add(this.lblID);
            this.grpData.Enabled = false;
            this.grpData.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.grpData.Location = new System.Drawing.Point(353, 12);
            this.grpData.Name = "grpData";
            this.grpData.Size = new System.Drawing.Size(428, 256);
            this.grpData.TabIndex = 2;
            this.grpData.TabStop = false;
            this.grpData.Text = "Dados:";
            this.grpData.Visible = false;
            // 
            // cmbActive
            // 
            this.cmbActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbActive.FormattingEnabled = true;
            this.cmbActive.IntegralHeight = false;
            this.cmbActive.ItemHeight = 12;
            this.cmbActive.Items.AddRange(new object[] {
            "Não",
            "Sim"});
            this.cmbActive.Location = new System.Drawing.Point(278, 118);
            this.cmbActive.Name = "cmbActive";
            this.cmbActive.Size = new System.Drawing.Size(44, 20);
            this.cmbActive.TabIndex = 32;
            this.cmbActive.Text = "Não";
            this.cmbActive.SelectedIndexChanged += new System.EventHandler(this.cmbActive_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(241, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 18);
            this.label2.TabIndex = 31;
            this.label2.Text = "Ativo: ";
            // 
            // lblLogged
            // 
            this.lblLogged.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblLogged.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblLogged.Location = new System.Drawing.Point(328, 118);
            this.lblLogged.Name = "lblLogged";
            this.lblLogged.Size = new System.Drawing.Size(94, 20);
            this.lblLogged.TabIndex = 30;
            this.lblLogged.Text = "Offline";
            this.lblLogged.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSave.Location = new System.Drawing.Point(5, 220);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(418, 31);
            this.btnSave.TabIndex = 29;
            this.btnSave.Text = "Salvar";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblIpCurrent
            // 
            this.lblIpCurrent.BackColor = System.Drawing.SystemColors.Control;
            this.lblIpCurrent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIpCurrent.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblIpCurrent.Location = new System.Drawing.Point(6, 196);
            this.lblIpCurrent.Name = "lblIpCurrent";
            this.lblIpCurrent.Size = new System.Drawing.Size(229, 18);
            this.lblIpCurrent.TabIndex = 28;
            this.lblIpCurrent.Text = "IP Atual: 0.0.0.0";
            // 
            // lblIpLogin
            // 
            this.lblIpLogin.BackColor = System.Drawing.SystemColors.Control;
            this.lblIpLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIpLogin.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblIpLogin.Location = new System.Drawing.Point(6, 171);
            this.lblIpLogin.Name = "lblIpLogin";
            this.lblIpLogin.Size = new System.Drawing.Size(229, 18);
            this.lblIpLogin.TabIndex = 27;
            this.lblIpLogin.Text = "IP do Ultimo Login: 0.0.0.0";
            // 
            // lblIpRegister
            // 
            this.lblIpRegister.BackColor = System.Drawing.SystemColors.Control;
            this.lblIpRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIpRegister.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblIpRegister.Location = new System.Drawing.Point(6, 145);
            this.lblIpRegister.Name = "lblIpRegister";
            this.lblIpRegister.Size = new System.Drawing.Size(229, 18);
            this.lblIpRegister.TabIndex = 26;
            this.lblIpRegister.Text = "IP de Registro: ";
            // 
            // lblDLogin
            // 
            this.lblDLogin.BackColor = System.Drawing.SystemColors.Control;
            this.lblDLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDLogin.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblDLogin.Location = new System.Drawing.Point(241, 180);
            this.lblDLogin.Name = "lblDLogin";
            this.lblDLogin.Size = new System.Drawing.Size(181, 34);
            this.lblDLogin.TabIndex = 25;
            this.lblDLogin.Text = "D. de Login:";
            // 
            // lblDRegister
            // 
            this.lblDRegister.BackColor = System.Drawing.SystemColors.Control;
            this.lblDRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDRegister.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblDRegister.Location = new System.Drawing.Point(241, 145);
            this.lblDRegister.Name = "lblDRegister";
            this.lblDRegister.Size = new System.Drawing.Size(181, 35);
            this.lblDRegister.TabIndex = 24;
            this.lblDRegister.Text = "D. de Registro: ";
            // 
            // txtLocation
            // 
            this.txtLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLocation.Location = new System.Drawing.Point(78, 118);
            this.txtLocation.MaxLength = 30;
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(157, 20);
            this.txtLocation.TabIndex = 22;
            this.txtLocation.TextChanged += new System.EventHandler(this.txtLocation_TextChanged);
            // 
            // lblLocation
            // 
            this.lblLocation.BackColor = System.Drawing.SystemColors.Control;
            this.lblLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocation.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblLocation.Location = new System.Drawing.Point(6, 119);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(81, 18);
            this.lblLocation.TabIndex = 23;
            this.lblLocation.Text = "Localidade: ";
            // 
            // txtCash
            // 
            this.txtCash.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCash.Location = new System.Drawing.Point(350, 92);
            this.txtCash.MaxLength = 10;
            this.txtCash.Name = "txtCash";
            this.txtCash.Size = new System.Drawing.Size(72, 20);
            this.txtCash.TabIndex = 21;
            this.txtCash.TextChanged += new System.EventHandler(this.txtCash_TextChanged);
            this.txtCash.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCash_KeyPress);
            // 
            // lblCash
            // 
            this.lblCash.BackColor = System.Drawing.SystemColors.Control;
            this.lblCash.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCash.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCash.Location = new System.Drawing.Point(311, 93);
            this.lblCash.Name = "lblCash";
            this.lblCash.Size = new System.Drawing.Size(55, 18);
            this.lblCash.TabIndex = 20;
            this.lblCash.Text = "Cash:";
            // 
            // cmbAccess
            // 
            this.cmbAccess.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAccess.FormattingEnabled = true;
            this.cmbAccess.IntegralHeight = false;
            this.cmbAccess.ItemHeight = 12;
            this.cmbAccess.Items.AddRange(new object[] {
            "Normal",
            "Moderador",
            "Admininistrador"});
            this.cmbAccess.Location = new System.Drawing.Point(205, 92);
            this.cmbAccess.Name = "cmbAccess";
            this.cmbAccess.Size = new System.Drawing.Size(100, 20);
            this.cmbAccess.TabIndex = 19;
            this.cmbAccess.Text = "Nenhum";
            this.cmbAccess.SelectedIndexChanged += new System.EventHandler(this.cmbAccess_SelectedIndexChanged);
            // 
            // lblAccess
            // 
            this.lblAccess.BackColor = System.Drawing.SystemColors.Control;
            this.lblAccess.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccess.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblAccess.Location = new System.Drawing.Point(156, 93);
            this.lblAccess.Name = "lblAccess";
            this.lblAccess.Size = new System.Drawing.Size(61, 18);
            this.lblAccess.TabIndex = 18;
            this.lblAccess.Text = "Acesso: ";
            // 
            // txtAccount
            // 
            this.txtAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccount.Location = new System.Drawing.Point(118, 13);
            this.txtAccount.MaxLength = 30;
            this.txtAccount.Name = "txtAccount";
            this.txtAccount.Size = new System.Drawing.Size(135, 21);
            this.txtAccount.TabIndex = 17;
            this.txtAccount.TextChanged += new System.EventHandler(this.txtAccount_TextChanged);
            // 
            // cmbLanguage
            // 
            this.cmbLanguage.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLanguage.FormattingEnabled = true;
            this.cmbLanguage.IntegralHeight = false;
            this.cmbLanguage.ItemHeight = 12;
            this.cmbLanguage.Items.AddRange(new object[] {
            "Português",
            "Inglês",
            "Japonês"});
            this.cmbLanguage.Location = new System.Drawing.Point(55, 92);
            this.cmbLanguage.Name = "cmbLanguage";
            this.cmbLanguage.Size = new System.Drawing.Size(95, 20);
            this.cmbLanguage.TabIndex = 16;
            this.cmbLanguage.Text = "Nenhum";
            this.cmbLanguage.SelectedIndexChanged += new System.EventHandler(this.cmbLanguage_SelectedIndexChanged);
            // 
            // lblLanguage
            // 
            this.lblLanguage.BackColor = System.Drawing.SystemColors.Control;
            this.lblLanguage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLanguage.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblLanguage.Location = new System.Drawing.Point(6, 93);
            this.lblLanguage.Name = "lblLanguage";
            this.lblLanguage.Size = new System.Drawing.Size(61, 18);
            this.lblLanguage.TabIndex = 15;
            this.lblLanguage.Text = "Idioma: ";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(49, 40);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(273, 20);
            this.txtEmail.TabIndex = 14;
            this.txtEmail.TextChanged += new System.EventHandler(this.txtEmail_TextChanged);
            // 
            // lblEmail
            // 
            this.lblEmail.BackColor = System.Drawing.SystemColors.Control;
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblEmail.Location = new System.Drawing.Point(6, 41);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(46, 18);
            this.lblEmail.TabIndex = 13;
            this.lblEmail.Text = "Email: ";
            // 
            // txtLastName
            // 
            this.txtLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLastName.Location = new System.Drawing.Point(291, 66);
            this.txtLastName.MaxLength = 30;
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(131, 20);
            this.txtLastName.TabIndex = 12;
            this.txtLastName.TextChanged += new System.EventHandler(this.txtLastName_TextChanged);
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(49, 66);
            this.txtName.MaxLength = 30;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(159, 20);
            this.txtName.TabIndex = 11;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // txtPin
            // 
            this.txtPin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPin.Location = new System.Drawing.Point(356, 40);
            this.txtPin.MaxLength = 10;
            this.txtPin.Name = "txtPin";
            this.txtPin.Size = new System.Drawing.Size(66, 20);
            this.txtPin.TabIndex = 10;
            this.txtPin.TextChanged += new System.EventHandler(this.txtPin_TextChanged);
            this.txtPin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPin_KeyPress);
            // 
            // lblPin
            // 
            this.lblPin.BackColor = System.Drawing.SystemColors.Control;
            this.lblPin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPin.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblPin.Location = new System.Drawing.Point(328, 41);
            this.lblPin.Name = "lblPin";
            this.lblPin.Size = new System.Drawing.Size(31, 18);
            this.lblPin.TabIndex = 9;
            this.lblPin.Text = "Pin:";
            // 
            // lblLastName
            // 
            this.lblLastName.BackColor = System.Drawing.SystemColors.Control;
            this.lblLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblLastName.Location = new System.Drawing.Point(214, 67);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(91, 18);
            this.lblLastName.TabIndex = 8;
            this.lblLastName.Text = "Sobrenome: ";
            // 
            // lblName
            // 
            this.lblName.BackColor = System.Drawing.SystemColors.Control;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblName.Location = new System.Drawing.Point(6, 67);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(46, 18);
            this.lblName.TabIndex = 7;
            this.lblName.Text = "Nome: ";
            // 
            // txtPass
            // 
            this.txtPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPass.Location = new System.Drawing.Point(306, 13);
            this.txtPass.MaxLength = 30;
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(116, 21);
            this.txtPass.TabIndex = 5;
            this.txtPass.TextChanged += new System.EventHandler(this.txtPass_TextChanged);
            // 
            // lblPass
            // 
            this.lblPass.BackColor = System.Drawing.SystemColors.Control;
            this.lblPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPass.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblPass.Location = new System.Drawing.Point(259, 14);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(63, 19);
            this.lblPass.TabIndex = 6;
            this.lblPass.Text = "Senha: ";
            // 
            // lblAccount
            // 
            this.lblAccount.BackColor = System.Drawing.SystemColors.Control;
            this.lblAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccount.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblAccount.Location = new System.Drawing.Point(73, 14);
            this.lblAccount.Name = "lblAccount";
            this.lblAccount.Size = new System.Drawing.Size(52, 19);
            this.lblAccount.TabIndex = 4;
            this.lblAccount.Text = "Conta: ";
            // 
            // lblID
            // 
            this.lblID.BackColor = System.Drawing.SystemColors.Control;
            this.lblID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblID.Location = new System.Drawing.Point(6, 14);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(61, 19);
            this.lblID.TabIndex = 3;
            this.lblID.Text = "ID: ";
            // 
            // pnlConsole
            // 
            this.pnlConsole.BackColor = System.Drawing.SystemColors.Control;
            this.pnlConsole.Controls.Add(this.rtxtConsole);
            this.pnlConsole.Location = new System.Drawing.Point(12, 168);
            this.pnlConsole.Name = "pnlConsole";
            this.pnlConsole.Size = new System.Drawing.Size(335, 100);
            this.pnlConsole.TabIndex = 4;
            // 
            // rtxtConsole
            // 
            this.rtxtConsole.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxtConsole.BackColor = System.Drawing.SystemColors.Control;
            this.rtxtConsole.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtxtConsole.Cursor = System.Windows.Forms.Cursors.Default;
            this.rtxtConsole.Enabled = false;
            this.rtxtConsole.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxtConsole.Location = new System.Drawing.Point(3, 2);
            this.rtxtConsole.Name = "rtxtConsole";
            this.rtxtConsole.ReadOnly = true;
            this.rtxtConsole.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rtxtConsole.ShortcutsEnabled = false;
            this.rtxtConsole.Size = new System.Drawing.Size(329, 97);
            this.rtxtConsole.TabIndex = 4;
            this.rtxtConsole.Text = "";
            this.rtxtConsole.WordWrap = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(790, 277);
            this.Controls.Add(this.pnlConsole);
            this.Controls.Add(this.grpData);
            this.Controls.Add(this.grpChars);
            this.Controls.Add(this.grpSearch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.Text = "Editar Contas";
            this.grpSearch.ResumeLayout(false);
            this.grpSearch.PerformLayout();
            this.grpChars.ResumeLayout(false);
            this.grpData.ResumeLayout(false);
            this.grpData.PerformLayout();
            this.pnlConsole.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.GroupBox grpChars;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.GroupBox grpData;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.ComboBox cmbLanguage;
        private System.Windows.Forms.Label lblLanguage;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtPin;
        private System.Windows.Forms.Label lblPin;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.Label lblAccount;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblIpCurrent;
        private System.Windows.Forms.Label lblIpLogin;
        private System.Windows.Forms.Label lblIpRegister;
        private System.Windows.Forms.Label lblDLogin;
        private System.Windows.Forms.Label lblDRegister;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.TextBox txtCash;
        private System.Windows.Forms.Label lblCash;
        private System.Windows.Forms.ComboBox cmbAccess;
        private System.Windows.Forms.Label lblAccess;
        private System.Windows.Forms.TextBox txtAccount;
        private System.Windows.Forms.ComboBox cmbActive;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblLogged;
        public System.Windows.Forms.Panel pnlConsole;
        private System.Windows.Forms.RichTextBox rtxtConsole;
        public System.Windows.Forms.ListBox lstChars;
    }
}

