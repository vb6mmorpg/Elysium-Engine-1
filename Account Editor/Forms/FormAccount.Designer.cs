namespace AccountEditor {
    partial class FormAccount {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAccount));
            this.section_find = new DarkUI.Controls.DarkSectionPanel();
            this.btn_find = new DarkUI.Controls.DarkButton();
            this.txt_finduser = new DarkUI.Controls.DarkTextBox();
            this.darkSectionPanel1 = new DarkUI.Controls.DarkSectionPanel();
            this.btn_char4 = new DarkUI.Controls.DarkButton();
            this.btn_char3 = new DarkUI.Controls.DarkButton();
            this.btn_char2 = new DarkUI.Controls.DarkButton();
            this.btn_char1 = new DarkUI.Controls.DarkButton();
            this.darkSectionPanel2 = new DarkUI.Controls.DarkSectionPanel();
            this.darkCheckBox1 = new DarkUI.Controls.DarkCheckBox();
            this.lbl_id = new DarkUI.Controls.DarkLabel();
            this.check_activated = new DarkUI.Controls.DarkCheckBox();
            this.txt_pin = new DarkUI.Controls.DarkTextBox();
            this.darkLabel1 = new DarkUI.Controls.DarkLabel();
            this.txt_cash = new DarkUI.Controls.DarkTextBox();
            this.darkLabel20 = new DarkUI.Controls.DarkLabel();
            this.txt_access = new DarkUI.Controls.DarkTextBox();
            this.darkLabel23 = new DarkUI.Controls.DarkLabel();
            this.txt_language = new DarkUI.Controls.DarkTextBox();
            this.darkLabel21 = new DarkUI.Controls.DarkLabel();
            this.txt_country = new DarkUI.Controls.DarkTextBox();
            this.darkLabel7 = new DarkUI.Controls.DarkLabel();
            this.txt_lastname = new DarkUI.Controls.DarkTextBox();
            this.darkLabel6 = new DarkUI.Controls.DarkLabel();
            this.txt_name = new DarkUI.Controls.DarkTextBox();
            this.darkLabel5 = new DarkUI.Controls.DarkLabel();
            this.txt_email = new DarkUI.Controls.DarkTextBox();
            this.darkLabel4 = new DarkUI.Controls.DarkLabel();
            this.txt_password = new DarkUI.Controls.DarkTextBox();
            this.darkLabel3 = new DarkUI.Controls.DarkLabel();
            this.txt_user = new DarkUI.Controls.DarkTextBox();
            this.darkLabel2 = new DarkUI.Controls.DarkLabel();
            this.darkSectionPanel3 = new DarkUI.Controls.DarkSectionPanel();
            this.lbl_datelastlogin = new DarkUI.Controls.DarkLabel();
            this.lbl_dateregister = new DarkUI.Controls.DarkLabel();
            this.lbl_ipactual = new DarkUI.Controls.DarkLabel();
            this.lbl_iplast = new DarkUI.Controls.DarkLabel();
            this.lbl_ipregister = new DarkUI.Controls.DarkLabel();
            this.darkLabel12 = new DarkUI.Controls.DarkLabel();
            this.darkLabel11 = new DarkUI.Controls.DarkLabel();
            this.darkLabel10 = new DarkUI.Controls.DarkLabel();
            this.darkLabel9 = new DarkUI.Controls.DarkLabel();
            this.darkLabel8 = new DarkUI.Controls.DarkLabel();
            this.darkToolStrip1 = new DarkUI.Controls.DarkToolStrip();
            this.strip_save = new System.Windows.Forms.ToolStripButton();
            this.strip_delete = new System.Windows.Forms.ToolStripButton();
            this.darkSeparator1 = new DarkUI.Controls.DarkSeparator();
            this.section_find.SuspendLayout();
            this.darkSectionPanel1.SuspendLayout();
            this.darkSectionPanel2.SuspendLayout();
            this.darkSectionPanel3.SuspendLayout();
            this.darkToolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // section_find
            // 
            this.section_find.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.section_find.Controls.Add(this.btn_find);
            this.section_find.Controls.Add(this.txt_finduser);
            this.section_find.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.section_find.Location = new System.Drawing.Point(12, 46);
            this.section_find.Name = "section_find";
            this.section_find.SectionHeader = "Procurar usuário";
            this.section_find.Size = new System.Drawing.Size(264, 62);
            this.section_find.TabIndex = 1;
            // 
            // btn_find
            // 
            this.btn_find.Location = new System.Drawing.Point(165, 28);
            this.btn_find.Name = "btn_find";
            this.btn_find.Padding = new System.Windows.Forms.Padding(5);
            this.btn_find.Size = new System.Drawing.Size(86, 23);
            this.btn_find.TabIndex = 1;
            this.btn_find.Text = "Procurar";
            this.btn_find.Click += new System.EventHandler(this.btn_find_Click);
            // 
            // txt_finduser
            // 
            this.txt_finduser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txt_finduser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_finduser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txt_finduser.Location = new System.Drawing.Point(8, 28);
            this.txt_finduser.Name = "txt_finduser";
            this.txt_finduser.Size = new System.Drawing.Size(151, 23);
            this.txt_finduser.TabIndex = 0;
            // 
            // darkSectionPanel1
            // 
            this.darkSectionPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.darkSectionPanel1.Controls.Add(this.btn_char4);
            this.darkSectionPanel1.Controls.Add(this.btn_char3);
            this.darkSectionPanel1.Controls.Add(this.btn_char2);
            this.darkSectionPanel1.Controls.Add(this.btn_char1);
            this.darkSectionPanel1.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.darkSectionPanel1.Location = new System.Drawing.Point(12, 114);
            this.darkSectionPanel1.Name = "darkSectionPanel1";
            this.darkSectionPanel1.SectionHeader = "Personagens";
            this.darkSectionPanel1.Size = new System.Drawing.Size(264, 154);
            this.darkSectionPanel1.TabIndex = 3;
            // 
            // btn_char4
            // 
            this.btn_char4.Location = new System.Drawing.Point(12, 115);
            this.btn_char4.Name = "btn_char4";
            this.btn_char4.Padding = new System.Windows.Forms.Padding(5);
            this.btn_char4.Size = new System.Drawing.Size(237, 23);
            this.btn_char4.TabIndex = 5;
            this.btn_char4.Text = "...";
            // 
            // btn_char3
            // 
            this.btn_char3.Location = new System.Drawing.Point(12, 86);
            this.btn_char3.Name = "btn_char3";
            this.btn_char3.Padding = new System.Windows.Forms.Padding(5);
            this.btn_char3.Size = new System.Drawing.Size(237, 23);
            this.btn_char3.TabIndex = 4;
            this.btn_char3.Text = "...";
            // 
            // btn_char2
            // 
            this.btn_char2.Location = new System.Drawing.Point(12, 57);
            this.btn_char2.Name = "btn_char2";
            this.btn_char2.Padding = new System.Windows.Forms.Padding(5);
            this.btn_char2.Size = new System.Drawing.Size(237, 23);
            this.btn_char2.TabIndex = 3;
            this.btn_char2.Text = "...";
            // 
            // btn_char1
            // 
            this.btn_char1.Location = new System.Drawing.Point(12, 28);
            this.btn_char1.Name = "btn_char1";
            this.btn_char1.Padding = new System.Windows.Forms.Padding(5);
            this.btn_char1.Size = new System.Drawing.Size(237, 23);
            this.btn_char1.TabIndex = 2;
            this.btn_char1.Text = "...";
            // 
            // darkSectionPanel2
            // 
            this.darkSectionPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.darkSectionPanel2.Controls.Add(this.darkCheckBox1);
            this.darkSectionPanel2.Controls.Add(this.lbl_id);
            this.darkSectionPanel2.Controls.Add(this.check_activated);
            this.darkSectionPanel2.Controls.Add(this.txt_pin);
            this.darkSectionPanel2.Controls.Add(this.darkLabel1);
            this.darkSectionPanel2.Controls.Add(this.txt_cash);
            this.darkSectionPanel2.Controls.Add(this.darkLabel20);
            this.darkSectionPanel2.Controls.Add(this.txt_access);
            this.darkSectionPanel2.Controls.Add(this.darkLabel23);
            this.darkSectionPanel2.Controls.Add(this.txt_language);
            this.darkSectionPanel2.Controls.Add(this.darkLabel21);
            this.darkSectionPanel2.Controls.Add(this.txt_country);
            this.darkSectionPanel2.Controls.Add(this.darkLabel7);
            this.darkSectionPanel2.Controls.Add(this.txt_lastname);
            this.darkSectionPanel2.Controls.Add(this.darkLabel6);
            this.darkSectionPanel2.Controls.Add(this.txt_name);
            this.darkSectionPanel2.Controls.Add(this.darkLabel5);
            this.darkSectionPanel2.Controls.Add(this.txt_email);
            this.darkSectionPanel2.Controls.Add(this.darkLabel4);
            this.darkSectionPanel2.Controls.Add(this.txt_password);
            this.darkSectionPanel2.Controls.Add(this.darkLabel3);
            this.darkSectionPanel2.Controls.Add(this.txt_user);
            this.darkSectionPanel2.Controls.Add(this.darkLabel2);
            this.darkSectionPanel2.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.darkSectionPanel2.Location = new System.Drawing.Point(282, 46);
            this.darkSectionPanel2.Name = "darkSectionPanel2";
            this.darkSectionPanel2.SectionHeader = "Dados pessoais";
            this.darkSectionPanel2.Size = new System.Drawing.Size(342, 365);
            this.darkSectionPanel2.TabIndex = 4;
            // 
            // darkCheckBox1
            // 
            this.darkCheckBox1.AutoSize = true;
            this.darkCheckBox1.Enabled = false;
            this.darkCheckBox1.Location = new System.Drawing.Point(177, 35);
            this.darkCheckBox1.Name = "darkCheckBox1";
            this.darkCheckBox1.Size = new System.Drawing.Size(133, 19);
            this.darkCheckBox1.TabIndex = 6;
            this.darkCheckBox1.Text = "Usuário conectado";
            // 
            // lbl_id
            // 
            this.lbl_id.AutoSize = true;
            this.lbl_id.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.lbl_id.Location = new System.Drawing.Point(12, 36);
            this.lbl_id.Name = "lbl_id";
            this.lbl_id.Size = new System.Drawing.Size(80, 15);
            this.lbl_id.TabIndex = 27;
            this.lbl_id.Text = "Identidade 0";
            // 
            // check_activated
            // 
            this.check_activated.AutoSize = true;
            this.check_activated.Location = new System.Drawing.Point(177, 58);
            this.check_activated.Name = "check_activated";
            this.check_activated.Size = new System.Drawing.Size(117, 19);
            this.check_activated.TabIndex = 7;
            this.check_activated.Text = "Usuário ativado";
            // 
            // txt_pin
            // 
            this.txt_pin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txt_pin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_pin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txt_pin.Location = new System.Drawing.Point(15, 279);
            this.txt_pin.MaxLength = 8;
            this.txt_pin.Name = "txt_pin";
            this.txt_pin.Size = new System.Drawing.Size(145, 23);
            this.txt_pin.TabIndex = 15;
            // 
            // darkLabel1
            // 
            this.darkLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel1.Location = new System.Drawing.Point(12, 261);
            this.darkLabel1.Name = "darkLabel1";
            this.darkLabel1.Size = new System.Drawing.Size(78, 15);
            this.darkLabel1.TabIndex = 23;
            this.darkLabel1.Text = "Pin";
            // 
            // txt_cash
            // 
            this.txt_cash.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txt_cash.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_cash.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txt_cash.Location = new System.Drawing.Point(15, 323);
            this.txt_cash.MaxLength = 11;
            this.txt_cash.Name = "txt_cash";
            this.txt_cash.Size = new System.Drawing.Size(145, 23);
            this.txt_cash.TabIndex = 17;
            this.txt_cash.Text = "0";
            // 
            // darkLabel20
            // 
            this.darkLabel20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel20.Location = new System.Drawing.Point(12, 305);
            this.darkLabel20.Name = "darkLabel20";
            this.darkLabel20.Size = new System.Drawing.Size(78, 15);
            this.darkLabel20.TabIndex = 19;
            this.darkLabel20.Text = "Cash";
            // 
            // txt_access
            // 
            this.txt_access.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txt_access.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_access.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txt_access.Location = new System.Drawing.Point(177, 279);
            this.txt_access.MaxLength = 10;
            this.txt_access.Name = "txt_access";
            this.txt_access.Size = new System.Drawing.Size(145, 23);
            this.txt_access.TabIndex = 16;
            this.txt_access.Text = "0";
            // 
            // darkLabel23
            // 
            this.darkLabel23.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel23.Location = new System.Drawing.Point(174, 261);
            this.darkLabel23.Name = "darkLabel23";
            this.darkLabel23.Size = new System.Drawing.Size(113, 15);
            this.darkLabel23.TabIndex = 18;
            this.darkLabel23.Text = "Nível de acesso";
            // 
            // txt_language
            // 
            this.txt_language.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txt_language.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_language.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txt_language.Location = new System.Drawing.Point(177, 232);
            this.txt_language.MaxLength = 50;
            this.txt_language.Name = "txt_language";
            this.txt_language.Size = new System.Drawing.Size(145, 23);
            this.txt_language.TabIndex = 14;
            this.txt_language.Text = "1";
            // 
            // darkLabel21
            // 
            this.darkLabel21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel21.Location = new System.Drawing.Point(174, 214);
            this.darkLabel21.Name = "darkLabel21";
            this.darkLabel21.Size = new System.Drawing.Size(78, 15);
            this.darkLabel21.TabIndex = 13;
            this.darkLabel21.Text = "Idioma";
            // 
            // txt_country
            // 
            this.txt_country.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txt_country.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_country.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txt_country.Location = new System.Drawing.Point(15, 232);
            this.txt_country.MaxLength = 50;
            this.txt_country.Name = "txt_country";
            this.txt_country.Size = new System.Drawing.Size(145, 23);
            this.txt_country.TabIndex = 13;
            // 
            // darkLabel7
            // 
            this.darkLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel7.Location = new System.Drawing.Point(12, 214);
            this.darkLabel7.Name = "darkLabel7";
            this.darkLabel7.Size = new System.Drawing.Size(78, 15);
            this.darkLabel7.TabIndex = 11;
            this.darkLabel7.Text = "País";
            // 
            // txt_lastname
            // 
            this.txt_lastname.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txt_lastname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_lastname.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txt_lastname.Location = new System.Drawing.Point(177, 186);
            this.txt_lastname.MaxLength = 50;
            this.txt_lastname.Name = "txt_lastname";
            this.txt_lastname.Size = new System.Drawing.Size(145, 23);
            this.txt_lastname.TabIndex = 12;
            // 
            // darkLabel6
            // 
            this.darkLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel6.Location = new System.Drawing.Point(174, 168);
            this.darkLabel6.Name = "darkLabel6";
            this.darkLabel6.Size = new System.Drawing.Size(78, 15);
            this.darkLabel6.TabIndex = 9;
            this.darkLabel6.Text = "Sobrenome";
            // 
            // txt_name
            // 
            this.txt_name.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txt_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_name.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txt_name.Location = new System.Drawing.Point(15, 186);
            this.txt_name.MaxLength = 50;
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(145, 23);
            this.txt_name.TabIndex = 11;
            // 
            // darkLabel5
            // 
            this.darkLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel5.Location = new System.Drawing.Point(12, 168);
            this.darkLabel5.Name = "darkLabel5";
            this.darkLabel5.Size = new System.Drawing.Size(78, 15);
            this.darkLabel5.TabIndex = 7;
            this.darkLabel5.Text = "Nome";
            // 
            // txt_email
            // 
            this.txt_email.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txt_email.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_email.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txt_email.Location = new System.Drawing.Point(15, 142);
            this.txt_email.MaxLength = 150;
            this.txt_email.Name = "txt_email";
            this.txt_email.Size = new System.Drawing.Size(307, 23);
            this.txt_email.TabIndex = 10;
            // 
            // darkLabel4
            // 
            this.darkLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel4.Location = new System.Drawing.Point(12, 124);
            this.darkLabel4.Name = "darkLabel4";
            this.darkLabel4.Size = new System.Drawing.Size(78, 15);
            this.darkLabel4.TabIndex = 5;
            this.darkLabel4.Text = "Email";
            // 
            // txt_password
            // 
            this.txt_password.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txt_password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_password.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txt_password.Location = new System.Drawing.Point(177, 98);
            this.txt_password.MaxLength = 255;
            this.txt_password.Name = "txt_password";
            this.txt_password.Size = new System.Drawing.Size(145, 23);
            this.txt_password.TabIndex = 9;
            // 
            // darkLabel3
            // 
            this.darkLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel3.Location = new System.Drawing.Point(174, 80);
            this.darkLabel3.Name = "darkLabel3";
            this.darkLabel3.Size = new System.Drawing.Size(78, 15);
            this.darkLabel3.TabIndex = 3;
            this.darkLabel3.Text = "Senha";
            // 
            // txt_user
            // 
            this.txt_user.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txt_user.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_user.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txt_user.Location = new System.Drawing.Point(15, 98);
            this.txt_user.MaxLength = 25;
            this.txt_user.Name = "txt_user";
            this.txt_user.Size = new System.Drawing.Size(145, 23);
            this.txt_user.TabIndex = 8;
            // 
            // darkLabel2
            // 
            this.darkLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel2.Location = new System.Drawing.Point(12, 80);
            this.darkLabel2.Name = "darkLabel2";
            this.darkLabel2.Size = new System.Drawing.Size(78, 15);
            this.darkLabel2.TabIndex = 1;
            this.darkLabel2.Text = "Usuário";
            // 
            // darkSectionPanel3
            // 
            this.darkSectionPanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.darkSectionPanel3.Controls.Add(this.lbl_datelastlogin);
            this.darkSectionPanel3.Controls.Add(this.lbl_dateregister);
            this.darkSectionPanel3.Controls.Add(this.lbl_ipactual);
            this.darkSectionPanel3.Controls.Add(this.lbl_iplast);
            this.darkSectionPanel3.Controls.Add(this.lbl_ipregister);
            this.darkSectionPanel3.Controls.Add(this.darkLabel12);
            this.darkSectionPanel3.Controls.Add(this.darkLabel11);
            this.darkSectionPanel3.Controls.Add(this.darkLabel10);
            this.darkSectionPanel3.Controls.Add(this.darkLabel9);
            this.darkSectionPanel3.Controls.Add(this.darkLabel8);
            this.darkSectionPanel3.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.darkSectionPanel3.Location = new System.Drawing.Point(12, 274);
            this.darkSectionPanel3.Name = "darkSectionPanel3";
            this.darkSectionPanel3.SectionHeader = "Informações de registro";
            this.darkSectionPanel3.Size = new System.Drawing.Size(264, 137);
            this.darkSectionPanel3.TabIndex = 5;
            // 
            // lbl_datelastlogin
            // 
            this.lbl_datelastlogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.lbl_datelastlogin.Location = new System.Drawing.Point(156, 110);
            this.lbl_datelastlogin.Name = "lbl_datelastlogin";
            this.lbl_datelastlogin.Size = new System.Drawing.Size(102, 15);
            this.lbl_datelastlogin.TabIndex = 15;
            this.lbl_datelastlogin.Text = "##/##/####";
            this.lbl_datelastlogin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_dateregister
            // 
            this.lbl_dateregister.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.lbl_dateregister.Location = new System.Drawing.Point(156, 90);
            this.lbl_dateregister.Name = "lbl_dateregister";
            this.lbl_dateregister.Size = new System.Drawing.Size(102, 15);
            this.lbl_dateregister.TabIndex = 14;
            this.lbl_dateregister.Text = "##/##/####";
            this.lbl_dateregister.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_ipactual
            // 
            this.lbl_ipactual.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.lbl_ipactual.Location = new System.Drawing.Point(156, 70);
            this.lbl_ipactual.Name = "lbl_ipactual";
            this.lbl_ipactual.Size = new System.Drawing.Size(107, 15);
            this.lbl_ipactual.TabIndex = 13;
            this.lbl_ipactual.Text = "0.0.0.0";
            this.lbl_ipactual.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_iplast
            // 
            this.lbl_iplast.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.lbl_iplast.Location = new System.Drawing.Point(156, 50);
            this.lbl_iplast.Name = "lbl_iplast";
            this.lbl_iplast.Size = new System.Drawing.Size(107, 15);
            this.lbl_iplast.TabIndex = 12;
            this.lbl_iplast.Text = "0.0.0.0";
            this.lbl_iplast.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_ipregister
            // 
            this.lbl_ipregister.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.lbl_ipregister.Location = new System.Drawing.Point(156, 30);
            this.lbl_ipregister.Name = "lbl_ipregister";
            this.lbl_ipregister.Size = new System.Drawing.Size(107, 15);
            this.lbl_ipregister.TabIndex = 11;
            this.lbl_ipregister.Text = "0.0.0.0";
            this.lbl_ipregister.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // darkLabel12
            // 
            this.darkLabel12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel12.Location = new System.Drawing.Point(11, 110);
            this.darkLabel12.Name = "darkLabel12";
            this.darkLabel12.Size = new System.Drawing.Size(129, 15);
            this.darkLabel12.TabIndex = 10;
            this.darkLabel12.Text = "Data de último login";
            // 
            // darkLabel11
            // 
            this.darkLabel11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel11.Location = new System.Drawing.Point(11, 90);
            this.darkLabel11.Name = "darkLabel11";
            this.darkLabel11.Size = new System.Drawing.Size(129, 15);
            this.darkLabel11.TabIndex = 9;
            this.darkLabel11.Text = "Data de cadastro";
            // 
            // darkLabel10
            // 
            this.darkLabel10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel10.Location = new System.Drawing.Point(11, 70);
            this.darkLabel10.Name = "darkLabel10";
            this.darkLabel10.Size = new System.Drawing.Size(121, 15);
            this.darkLabel10.TabIndex = 8;
            this.darkLabel10.Text = "Endereço IP atual";
            // 
            // darkLabel9
            // 
            this.darkLabel9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel9.Location = new System.Drawing.Point(11, 50);
            this.darkLabel9.Name = "darkLabel9";
            this.darkLabel9.Size = new System.Drawing.Size(139, 15);
            this.darkLabel9.TabIndex = 7;
            this.darkLabel9.Text = "Endereço IP último ";
            // 
            // darkLabel8
            // 
            this.darkLabel8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel8.Location = new System.Drawing.Point(11, 30);
            this.darkLabel8.Name = "darkLabel8";
            this.darkLabel8.Size = new System.Drawing.Size(148, 15);
            this.darkLabel8.TabIndex = 6;
            this.darkLabel8.Text = "Endereço IP de registro";
            // 
            // darkToolStrip1
            // 
            this.darkToolStrip1.AutoSize = false;
            this.darkToolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.darkToolStrip1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.strip_save,
            this.strip_delete});
            this.darkToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.darkToolStrip1.Name = "darkToolStrip1";
            this.darkToolStrip1.Padding = new System.Windows.Forms.Padding(5, 0, 1, 0);
            this.darkToolStrip1.Size = new System.Drawing.Size(638, 28);
            this.darkToolStrip1.TabIndex = 7;
            this.darkToolStrip1.Text = "darkToolStrip1";
            // 
            // strip_save
            // 
            this.strip_save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.strip_save.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.strip_save.Image = ((System.Drawing.Image)(resources.GetObject("strip_save.Image")));
            this.strip_save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.strip_save.Name = "strip_save";
            this.strip_save.Size = new System.Drawing.Size(23, 25);
            this.strip_save.Text = "toolStripButton1";
            this.strip_save.ToolTipText = "Salvar as informações de usuário.";
            this.strip_save.Click += new System.EventHandler(this.strip_save_Click);
            // 
            // strip_delete
            // 
            this.strip_delete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.strip_delete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.strip_delete.Image = ((System.Drawing.Image)(resources.GetObject("strip_delete.Image")));
            this.strip_delete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.strip_delete.Name = "strip_delete";
            this.strip_delete.Size = new System.Drawing.Size(23, 25);
            this.strip_delete.Text = "toolStripButton1";
            this.strip_delete.Click += new System.EventHandler(this.strip_delete_Click);
            // 
            // darkSeparator1
            // 
            this.darkSeparator1.Dock = System.Windows.Forms.DockStyle.Top;
            this.darkSeparator1.Location = new System.Drawing.Point(0, 28);
            this.darkSeparator1.Name = "darkSeparator1";
            this.darkSeparator1.Size = new System.Drawing.Size(638, 2);
            this.darkSeparator1.TabIndex = 8;
            this.darkSeparator1.Text = "darkSeparator1";
            // 
            // FormAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 426);
            this.Controls.Add(this.darkSeparator1);
            this.Controls.Add(this.darkToolStrip1);
            this.Controls.Add(this.darkSectionPanel3);
            this.Controls.Add(this.darkSectionPanel2);
            this.Controls.Add(this.darkSectionPanel1);
            this.Controls.Add(this.section_find);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormAccount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Usuário";
            this.section_find.ResumeLayout(false);
            this.section_find.PerformLayout();
            this.darkSectionPanel1.ResumeLayout(false);
            this.darkSectionPanel2.ResumeLayout(false);
            this.darkSectionPanel2.PerformLayout();
            this.darkSectionPanel3.ResumeLayout(false);
            this.darkToolStrip1.ResumeLayout(false);
            this.darkToolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private DarkUI.Controls.DarkSectionPanel section_find;
        private DarkUI.Controls.DarkButton btn_find;
        private DarkUI.Controls.DarkTextBox txt_finduser;
        private DarkUI.Controls.DarkSectionPanel darkSectionPanel1;
        private DarkUI.Controls.DarkButton btn_char4;
        private DarkUI.Controls.DarkButton btn_char3;
        private DarkUI.Controls.DarkButton btn_char2;
        private DarkUI.Controls.DarkButton btn_char1;
        private DarkUI.Controls.DarkSectionPanel darkSectionPanel2;
        private DarkUI.Controls.DarkTextBox txt_country;
        private DarkUI.Controls.DarkLabel darkLabel7;
        private DarkUI.Controls.DarkTextBox txt_lastname;
        private DarkUI.Controls.DarkLabel darkLabel6;
        private DarkUI.Controls.DarkTextBox txt_name;
        private DarkUI.Controls.DarkLabel darkLabel5;
        private DarkUI.Controls.DarkTextBox txt_email;
        private DarkUI.Controls.DarkLabel darkLabel4;
        private DarkUI.Controls.DarkTextBox txt_password;
        private DarkUI.Controls.DarkLabel darkLabel3;
        private DarkUI.Controls.DarkTextBox txt_user;
        private DarkUI.Controls.DarkLabel darkLabel2;
        private DarkUI.Controls.DarkTextBox txt_language;
        private DarkUI.Controls.DarkLabel darkLabel21;
        private DarkUI.Controls.DarkSectionPanel darkSectionPanel3;
        private DarkUI.Controls.DarkLabel lbl_datelastlogin;
        private DarkUI.Controls.DarkLabel lbl_dateregister;
        private DarkUI.Controls.DarkLabel lbl_ipactual;
        private DarkUI.Controls.DarkLabel lbl_iplast;
        private DarkUI.Controls.DarkLabel lbl_ipregister;
        private DarkUI.Controls.DarkLabel darkLabel12;
        private DarkUI.Controls.DarkLabel darkLabel11;
        private DarkUI.Controls.DarkLabel darkLabel10;
        private DarkUI.Controls.DarkLabel darkLabel9;
        private DarkUI.Controls.DarkLabel darkLabel8;
        private DarkUI.Controls.DarkToolStrip darkToolStrip1;
        private System.Windows.Forms.ToolStripButton strip_save;
        private DarkUI.Controls.DarkSeparator darkSeparator1;
        private DarkUI.Controls.DarkLabel lbl_id;
        private DarkUI.Controls.DarkCheckBox check_activated;
        private DarkUI.Controls.DarkTextBox txt_pin;
        private DarkUI.Controls.DarkLabel darkLabel1;
        private DarkUI.Controls.DarkTextBox txt_cash;
        private DarkUI.Controls.DarkLabel darkLabel20;
        private DarkUI.Controls.DarkTextBox txt_access;
        private DarkUI.Controls.DarkLabel darkLabel23;
        private DarkUI.Controls.DarkCheckBox darkCheckBox1;
        private System.Windows.Forms.ToolStripButton strip_delete;
    }
}

