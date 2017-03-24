namespace AccountEditor {
    partial class FormCharacter {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCharacter));
            this.darkToolStrip1 = new DarkUI.Controls.DarkToolStrip();
            this.strip_save = new System.Windows.Forms.ToolStripButton();
            this.strip_delete = new System.Windows.Forms.ToolStripButton();
            this.darkSeparator1 = new DarkUI.Controls.DarkSeparator();
            this.section_find = new DarkUI.Controls.DarkSectionPanel();
            this.txt_points = new DarkUI.Controls.DarkTextBox();
            this.darkLabel16 = new DarkUI.Controls.DarkLabel();
            this.txt_exp = new DarkUI.Controls.DarkTextBox();
            this.darkLabel11 = new DarkUI.Controls.DarkLabel();
            this.txt_level = new DarkUI.Controls.DarkTextBox();
            this.darkLabel10 = new DarkUI.Controls.DarkLabel();
            this.txt_sprite = new DarkUI.Controls.DarkTextBox();
            this.darkLabel9 = new DarkUI.Controls.DarkLabel();
            this.txt_name = new DarkUI.Controls.DarkTextBox();
            this.darkLabel8 = new DarkUI.Controls.DarkLabel();
            this.darkSectionPanel2 = new DarkUI.Controls.DarkSectionPanel();
            this.txt_wis = new DarkUI.Controls.DarkTextBox();
            this.darkLabel3 = new DarkUI.Controls.DarkLabel();
            this.txt_int = new DarkUI.Controls.DarkTextBox();
            this.darkLabel1 = new DarkUI.Controls.DarkLabel();
            this.txt_wil = new DarkUI.Controls.DarkTextBox();
            this.darkLabel20 = new DarkUI.Controls.DarkLabel();
            this.txt_cha = new DarkUI.Controls.DarkTextBox();
            this.darkLabel21 = new DarkUI.Controls.DarkLabel();
            this.txt_con = new DarkUI.Controls.DarkTextBox();
            this.darkLabel7 = new DarkUI.Controls.DarkLabel();
            this.txt_min = new DarkUI.Controls.DarkTextBox();
            this.darkLabel6 = new DarkUI.Controls.DarkLabel();
            this.txt_agi = new DarkUI.Controls.DarkTextBox();
            this.darkLabel5 = new DarkUI.Controls.DarkLabel();
            this.txt_dex = new DarkUI.Controls.DarkTextBox();
            this.darkLabel4 = new DarkUI.Controls.DarkLabel();
            this.txt_str = new DarkUI.Controls.DarkTextBox();
            this.darkLabel2 = new DarkUI.Controls.DarkLabel();
            this.darkSectionPanel1 = new DarkUI.Controls.DarkSectionPanel();
            this.list_classes = new DarkUI.Controls.DarkListView();
            this.darkSectionPanel3 = new DarkUI.Controls.DarkSectionPanel();
            this.txt_world = new DarkUI.Controls.DarkTextBox();
            this.darkLabel12 = new DarkUI.Controls.DarkLabel();
            this.txt_region = new DarkUI.Controls.DarkTextBox();
            this.darkLabel13 = new DarkUI.Controls.DarkLabel();
            this.txt_posy = new DarkUI.Controls.DarkTextBox();
            this.darkLabel14 = new DarkUI.Controls.DarkLabel();
            this.txt_posx = new DarkUI.Controls.DarkTextBox();
            this.darkLabel15 = new DarkUI.Controls.DarkLabel();
            this.darkToolStrip1.SuspendLayout();
            this.section_find.SuspendLayout();
            this.darkSectionPanel2.SuspendLayout();
            this.darkSectionPanel1.SuspendLayout();
            this.darkSectionPanel3.SuspendLayout();
            this.SuspendLayout();
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
            this.darkToolStrip1.Size = new System.Drawing.Size(574, 28);
            this.darkToolStrip1.TabIndex = 0;
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
            this.strip_delete.Text = "toolStripButton2";
            this.strip_delete.Click += new System.EventHandler(this.strip_delete_Click);
            // 
            // darkSeparator1
            // 
            this.darkSeparator1.Dock = System.Windows.Forms.DockStyle.Top;
            this.darkSeparator1.Location = new System.Drawing.Point(0, 28);
            this.darkSeparator1.Name = "darkSeparator1";
            this.darkSeparator1.Size = new System.Drawing.Size(574, 2);
            this.darkSeparator1.TabIndex = 1;
            this.darkSeparator1.Text = "darkSeparator1";
            // 
            // section_find
            // 
            this.section_find.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.section_find.Controls.Add(this.txt_points);
            this.section_find.Controls.Add(this.darkLabel16);
            this.section_find.Controls.Add(this.txt_exp);
            this.section_find.Controls.Add(this.darkLabel11);
            this.section_find.Controls.Add(this.txt_level);
            this.section_find.Controls.Add(this.darkLabel10);
            this.section_find.Controls.Add(this.txt_sprite);
            this.section_find.Controls.Add(this.darkLabel9);
            this.section_find.Controls.Add(this.txt_name);
            this.section_find.Controls.Add(this.darkLabel8);
            this.section_find.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.section_find.Location = new System.Drawing.Point(12, 42);
            this.section_find.Name = "section_find";
            this.section_find.SectionHeader = "Informação";
            this.section_find.Size = new System.Drawing.Size(174, 273);
            this.section_find.TabIndex = 2;
            // 
            // txt_points
            // 
            this.txt_points.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txt_points.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_points.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txt_points.Location = new System.Drawing.Point(12, 231);
            this.txt_points.Name = "txt_points";
            this.txt_points.Size = new System.Drawing.Size(145, 23);
            this.txt_points.TabIndex = 4;
            this.txt_points.Text = "0";
            // 
            // darkLabel16
            // 
            this.darkLabel16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel16.Location = new System.Drawing.Point(10, 213);
            this.darkLabel16.Name = "darkLabel16";
            this.darkLabel16.Size = new System.Drawing.Size(136, 15);
            this.darkLabel16.TabIndex = 15;
            this.darkLabel16.Text = "Pontos de atributo";
            // 
            // txt_exp
            // 
            this.txt_exp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txt_exp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_exp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txt_exp.Location = new System.Drawing.Point(12, 184);
            this.txt_exp.Name = "txt_exp";
            this.txt_exp.Size = new System.Drawing.Size(145, 23);
            this.txt_exp.TabIndex = 3;
            this.txt_exp.Text = "0";
            // 
            // darkLabel11
            // 
            this.darkLabel11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel11.Location = new System.Drawing.Point(10, 166);
            this.darkLabel11.Name = "darkLabel11";
            this.darkLabel11.Size = new System.Drawing.Size(78, 15);
            this.darkLabel11.TabIndex = 13;
            this.darkLabel11.Text = "Experiência";
            // 
            // txt_level
            // 
            this.txt_level.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txt_level.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_level.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txt_level.Location = new System.Drawing.Point(12, 138);
            this.txt_level.Name = "txt_level";
            this.txt_level.Size = new System.Drawing.Size(145, 23);
            this.txt_level.TabIndex = 2;
            this.txt_level.Text = "1";
            // 
            // darkLabel10
            // 
            this.darkLabel10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel10.Location = new System.Drawing.Point(10, 120);
            this.darkLabel10.Name = "darkLabel10";
            this.darkLabel10.Size = new System.Drawing.Size(78, 15);
            this.darkLabel10.TabIndex = 11;
            this.darkLabel10.Text = "Level";
            // 
            // txt_sprite
            // 
            this.txt_sprite.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txt_sprite.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_sprite.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txt_sprite.Location = new System.Drawing.Point(12, 94);
            this.txt_sprite.Name = "txt_sprite";
            this.txt_sprite.Size = new System.Drawing.Size(145, 23);
            this.txt_sprite.TabIndex = 1;
            this.txt_sprite.Text = "1";
            // 
            // darkLabel9
            // 
            this.darkLabel9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel9.Location = new System.Drawing.Point(10, 76);
            this.darkLabel9.Name = "darkLabel9";
            this.darkLabel9.Size = new System.Drawing.Size(78, 15);
            this.darkLabel9.TabIndex = 9;
            this.darkLabel9.Text = "Sprite";
            // 
            // txt_name
            // 
            this.txt_name.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txt_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_name.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txt_name.Location = new System.Drawing.Point(12, 50);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(145, 23);
            this.txt_name.TabIndex = 0;
            // 
            // darkLabel8
            // 
            this.darkLabel8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel8.Location = new System.Drawing.Point(12, 32);
            this.darkLabel8.Name = "darkLabel8";
            this.darkLabel8.Size = new System.Drawing.Size(78, 15);
            this.darkLabel8.TabIndex = 7;
            this.darkLabel8.Text = "Nome";
            // 
            // darkSectionPanel2
            // 
            this.darkSectionPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.darkSectionPanel2.Controls.Add(this.txt_wis);
            this.darkSectionPanel2.Controls.Add(this.darkLabel3);
            this.darkSectionPanel2.Controls.Add(this.txt_int);
            this.darkSectionPanel2.Controls.Add(this.darkLabel1);
            this.darkSectionPanel2.Controls.Add(this.txt_wil);
            this.darkSectionPanel2.Controls.Add(this.darkLabel20);
            this.darkSectionPanel2.Controls.Add(this.txt_cha);
            this.darkSectionPanel2.Controls.Add(this.darkLabel21);
            this.darkSectionPanel2.Controls.Add(this.txt_con);
            this.darkSectionPanel2.Controls.Add(this.darkLabel7);
            this.darkSectionPanel2.Controls.Add(this.txt_min);
            this.darkSectionPanel2.Controls.Add(this.darkLabel6);
            this.darkSectionPanel2.Controls.Add(this.txt_agi);
            this.darkSectionPanel2.Controls.Add(this.darkLabel5);
            this.darkSectionPanel2.Controls.Add(this.txt_dex);
            this.darkSectionPanel2.Controls.Add(this.darkLabel4);
            this.darkSectionPanel2.Controls.Add(this.txt_str);
            this.darkSectionPanel2.Controls.Add(this.darkLabel2);
            this.darkSectionPanel2.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.darkSectionPanel2.Location = new System.Drawing.Point(192, 42);
            this.darkSectionPanel2.Name = "darkSectionPanel2";
            this.darkSectionPanel2.SectionHeader = "Atributos";
            this.darkSectionPanel2.Size = new System.Drawing.Size(174, 451);
            this.darkSectionPanel2.TabIndex = 5;
            // 
            // txt_wis
            // 
            this.txt_wis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txt_wis.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_wis.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txt_wis.Location = new System.Drawing.Point(10, 275);
            this.txt_wis.Name = "txt_wis";
            this.txt_wis.Size = new System.Drawing.Size(145, 23);
            this.txt_wis.TabIndex = 14;
            this.txt_wis.Text = "0";
            // 
            // darkLabel3
            // 
            this.darkLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel3.Location = new System.Drawing.Point(10, 257);
            this.darkLabel3.Name = "darkLabel3";
            this.darkLabel3.Size = new System.Drawing.Size(78, 15);
            this.darkLabel3.TabIndex = 25;
            this.darkLabel3.Text = "Sabedoria";
            // 
            // txt_int
            // 
            this.txt_int.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txt_int.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_int.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txt_int.Location = new System.Drawing.Point(10, 231);
            this.txt_int.Name = "txt_int";
            this.txt_int.Size = new System.Drawing.Size(145, 23);
            this.txt_int.TabIndex = 13;
            this.txt_int.Text = "0";
            // 
            // darkLabel1
            // 
            this.darkLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel1.Location = new System.Drawing.Point(10, 213);
            this.darkLabel1.Name = "darkLabel1";
            this.darkLabel1.Size = new System.Drawing.Size(78, 15);
            this.darkLabel1.TabIndex = 23;
            this.darkLabel1.Text = "Inteligência";
            // 
            // txt_wil
            // 
            this.txt_wil.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txt_wil.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_wil.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txt_wil.Location = new System.Drawing.Point(10, 319);
            this.txt_wil.Name = "txt_wil";
            this.txt_wil.Size = new System.Drawing.Size(145, 23);
            this.txt_wil.TabIndex = 15;
            this.txt_wil.Text = "0";
            // 
            // darkLabel20
            // 
            this.darkLabel20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel20.Location = new System.Drawing.Point(10, 301);
            this.darkLabel20.Name = "darkLabel20";
            this.darkLabel20.Size = new System.Drawing.Size(78, 15);
            this.darkLabel20.TabIndex = 19;
            this.darkLabel20.Text = "Vontade";
            // 
            // txt_cha
            // 
            this.txt_cha.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txt_cha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_cha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txt_cha.Location = new System.Drawing.Point(10, 410);
            this.txt_cha.Name = "txt_cha";
            this.txt_cha.Size = new System.Drawing.Size(145, 23);
            this.txt_cha.TabIndex = 17;
            this.txt_cha.Text = "0";
            // 
            // darkLabel21
            // 
            this.darkLabel21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel21.Location = new System.Drawing.Point(10, 392);
            this.darkLabel21.Name = "darkLabel21";
            this.darkLabel21.Size = new System.Drawing.Size(78, 15);
            this.darkLabel21.TabIndex = 13;
            this.darkLabel21.Text = "Carísma";
            // 
            // txt_con
            // 
            this.txt_con.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txt_con.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_con.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txt_con.Location = new System.Drawing.Point(10, 184);
            this.txt_con.Name = "txt_con";
            this.txt_con.Size = new System.Drawing.Size(145, 23);
            this.txt_con.TabIndex = 12;
            this.txt_con.Text = "0";
            // 
            // darkLabel7
            // 
            this.darkLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel7.Location = new System.Drawing.Point(10, 166);
            this.darkLabel7.Name = "darkLabel7";
            this.darkLabel7.Size = new System.Drawing.Size(78, 15);
            this.darkLabel7.TabIndex = 11;
            this.darkLabel7.Text = "Constituição";
            // 
            // txt_min
            // 
            this.txt_min.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txt_min.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_min.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txt_min.Location = new System.Drawing.Point(10, 364);
            this.txt_min.Name = "txt_min";
            this.txt_min.Size = new System.Drawing.Size(145, 23);
            this.txt_min.TabIndex = 16;
            this.txt_min.Text = "0";
            // 
            // darkLabel6
            // 
            this.darkLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel6.Location = new System.Drawing.Point(10, 346);
            this.darkLabel6.Name = "darkLabel6";
            this.darkLabel6.Size = new System.Drawing.Size(78, 15);
            this.darkLabel6.TabIndex = 9;
            this.darkLabel6.Text = "Espírito";
            // 
            // txt_agi
            // 
            this.txt_agi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txt_agi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_agi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txt_agi.Location = new System.Drawing.Point(10, 138);
            this.txt_agi.Name = "txt_agi";
            this.txt_agi.Size = new System.Drawing.Size(145, 23);
            this.txt_agi.TabIndex = 11;
            this.txt_agi.Text = "0";
            // 
            // darkLabel5
            // 
            this.darkLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel5.Location = new System.Drawing.Point(10, 120);
            this.darkLabel5.Name = "darkLabel5";
            this.darkLabel5.Size = new System.Drawing.Size(78, 15);
            this.darkLabel5.TabIndex = 7;
            this.darkLabel5.Text = "Agilidade";
            // 
            // txt_dex
            // 
            this.txt_dex.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txt_dex.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_dex.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txt_dex.Location = new System.Drawing.Point(10, 94);
            this.txt_dex.Name = "txt_dex";
            this.txt_dex.Size = new System.Drawing.Size(145, 23);
            this.txt_dex.TabIndex = 10;
            this.txt_dex.Text = "0";
            // 
            // darkLabel4
            // 
            this.darkLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel4.Location = new System.Drawing.Point(10, 76);
            this.darkLabel4.Name = "darkLabel4";
            this.darkLabel4.Size = new System.Drawing.Size(78, 15);
            this.darkLabel4.TabIndex = 5;
            this.darkLabel4.Text = "Destreza";
            // 
            // txt_str
            // 
            this.txt_str.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txt_str.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_str.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txt_str.Location = new System.Drawing.Point(10, 50);
            this.txt_str.Name = "txt_str";
            this.txt_str.Size = new System.Drawing.Size(145, 23);
            this.txt_str.TabIndex = 9;
            this.txt_str.Text = "0";
            // 
            // darkLabel2
            // 
            this.darkLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel2.Location = new System.Drawing.Point(10, 32);
            this.darkLabel2.Name = "darkLabel2";
            this.darkLabel2.Size = new System.Drawing.Size(78, 15);
            this.darkLabel2.TabIndex = 1;
            this.darkLabel2.Text = "Força";
            // 
            // darkSectionPanel1
            // 
            this.darkSectionPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.darkSectionPanel1.Controls.Add(this.list_classes);
            this.darkSectionPanel1.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.darkSectionPanel1.Location = new System.Drawing.Point(372, 42);
            this.darkSectionPanel1.Name = "darkSectionPanel1";
            this.darkSectionPanel1.SectionHeader = "Classe";
            this.darkSectionPanel1.Size = new System.Drawing.Size(189, 451);
            this.darkSectionPanel1.TabIndex = 6;
            // 
            // list_classes
            // 
            this.list_classes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.list_classes.Location = new System.Drawing.Point(1, 25);
            this.list_classes.Name = "list_classes";
            this.list_classes.Size = new System.Drawing.Size(185, 423);
            this.list_classes.TabIndex = 18;
            this.list_classes.Text = "darkListView1";
            // 
            // darkSectionPanel3
            // 
            this.darkSectionPanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.darkSectionPanel3.Controls.Add(this.txt_world);
            this.darkSectionPanel3.Controls.Add(this.darkLabel12);
            this.darkSectionPanel3.Controls.Add(this.txt_region);
            this.darkSectionPanel3.Controls.Add(this.darkLabel13);
            this.darkSectionPanel3.Controls.Add(this.txt_posy);
            this.darkSectionPanel3.Controls.Add(this.darkLabel14);
            this.darkSectionPanel3.Controls.Add(this.txt_posx);
            this.darkSectionPanel3.Controls.Add(this.darkLabel15);
            this.darkSectionPanel3.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.darkSectionPanel3.Location = new System.Drawing.Point(12, 321);
            this.darkSectionPanel3.Name = "darkSectionPanel3";
            this.darkSectionPanel3.SectionHeader = "Localidade";
            this.darkSectionPanel3.Size = new System.Drawing.Size(174, 172);
            this.darkSectionPanel3.TabIndex = 7;
            // 
            // txt_world
            // 
            this.txt_world.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txt_world.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_world.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txt_world.Location = new System.Drawing.Point(10, 50);
            this.txt_world.Name = "txt_world";
            this.txt_world.Size = new System.Drawing.Size(65, 23);
            this.txt_world.TabIndex = 5;
            this.txt_world.Text = "1";
            // 
            // darkLabel12
            // 
            this.darkLabel12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel12.Location = new System.Drawing.Point(10, 32);
            this.darkLabel12.Name = "darkLabel12";
            this.darkLabel12.Size = new System.Drawing.Size(65, 15);
            this.darkLabel12.TabIndex = 33;
            this.darkLabel12.Text = "Mundo";
            // 
            // txt_region
            // 
            this.txt_region.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txt_region.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_region.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txt_region.Location = new System.Drawing.Point(92, 50);
            this.txt_region.Name = "txt_region";
            this.txt_region.Size = new System.Drawing.Size(65, 23);
            this.txt_region.TabIndex = 6;
            this.txt_region.Text = "0";
            // 
            // darkLabel13
            // 
            this.darkLabel13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel13.Location = new System.Drawing.Point(91, 32);
            this.darkLabel13.Name = "darkLabel13";
            this.darkLabel13.Size = new System.Drawing.Size(62, 15);
            this.darkLabel13.TabIndex = 31;
            this.darkLabel13.Text = "Região";
            // 
            // txt_posy
            // 
            this.txt_posy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txt_posy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_posy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txt_posy.Location = new System.Drawing.Point(92, 105);
            this.txt_posy.Name = "txt_posy";
            this.txt_posy.Size = new System.Drawing.Size(65, 23);
            this.txt_posy.TabIndex = 8;
            this.txt_posy.Text = "0";
            // 
            // darkLabel14
            // 
            this.darkLabel14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel14.Location = new System.Drawing.Point(89, 87);
            this.darkLabel14.Name = "darkLabel14";
            this.darkLabel14.Size = new System.Drawing.Size(64, 15);
            this.darkLabel14.TabIndex = 30;
            this.darkLabel14.Text = "Y";
            // 
            // txt_posx
            // 
            this.txt_posx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txt_posx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_posx.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txt_posx.Location = new System.Drawing.Point(10, 105);
            this.txt_posx.Name = "txt_posx";
            this.txt_posx.Size = new System.Drawing.Size(65, 23);
            this.txt_posx.TabIndex = 7;
            this.txt_posx.Text = "0";
            // 
            // darkLabel15
            // 
            this.darkLabel15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel15.Location = new System.Drawing.Point(10, 85);
            this.darkLabel15.Name = "darkLabel15";
            this.darkLabel15.Size = new System.Drawing.Size(65, 15);
            this.darkLabel15.TabIndex = 27;
            this.darkLabel15.Text = "X";
            // 
            // FormCharacter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 508);
            this.Controls.Add(this.darkSectionPanel3);
            this.Controls.Add(this.darkSectionPanel1);
            this.Controls.Add(this.darkSectionPanel2);
            this.Controls.Add(this.section_find);
            this.Controls.Add(this.darkSeparator1);
            this.Controls.Add(this.darkToolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormCharacter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Personagem";
            this.darkToolStrip1.ResumeLayout(false);
            this.darkToolStrip1.PerformLayout();
            this.section_find.ResumeLayout(false);
            this.section_find.PerformLayout();
            this.darkSectionPanel2.ResumeLayout(false);
            this.darkSectionPanel2.PerformLayout();
            this.darkSectionPanel1.ResumeLayout(false);
            this.darkSectionPanel3.ResumeLayout(false);
            this.darkSectionPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DarkUI.Controls.DarkToolStrip darkToolStrip1;
        private System.Windows.Forms.ToolStripButton strip_save;
        private DarkUI.Controls.DarkSeparator darkSeparator1;
        private DarkUI.Controls.DarkSectionPanel section_find;
        private DarkUI.Controls.DarkSectionPanel darkSectionPanel2;
        private DarkUI.Controls.DarkTextBox txt_wis;
        private DarkUI.Controls.DarkLabel darkLabel3;
        private DarkUI.Controls.DarkTextBox txt_int;
        private DarkUI.Controls.DarkLabel darkLabel1;
        private DarkUI.Controls.DarkTextBox txt_wil;
        private DarkUI.Controls.DarkLabel darkLabel20;
        private DarkUI.Controls.DarkTextBox txt_cha;
        private DarkUI.Controls.DarkLabel darkLabel21;
        private DarkUI.Controls.DarkTextBox txt_con;
        private DarkUI.Controls.DarkLabel darkLabel7;
        private DarkUI.Controls.DarkTextBox txt_min;
        private DarkUI.Controls.DarkLabel darkLabel6;
        private DarkUI.Controls.DarkTextBox txt_agi;
        private DarkUI.Controls.DarkLabel darkLabel5;
        private DarkUI.Controls.DarkTextBox txt_dex;
        private DarkUI.Controls.DarkLabel darkLabel4;
        private DarkUI.Controls.DarkTextBox txt_str;
        private DarkUI.Controls.DarkLabel darkLabel2;
        private DarkUI.Controls.DarkTextBox txt_exp;
        private DarkUI.Controls.DarkLabel darkLabel11;
        private DarkUI.Controls.DarkTextBox txt_level;
        private DarkUI.Controls.DarkLabel darkLabel10;
        private DarkUI.Controls.DarkTextBox txt_sprite;
        private DarkUI.Controls.DarkLabel darkLabel9;
        private DarkUI.Controls.DarkTextBox txt_name;
        private DarkUI.Controls.DarkLabel darkLabel8;
        private DarkUI.Controls.DarkSectionPanel darkSectionPanel1;
        private DarkUI.Controls.DarkSectionPanel darkSectionPanel3;
        private DarkUI.Controls.DarkTextBox txt_world;
        private DarkUI.Controls.DarkLabel darkLabel12;
        private DarkUI.Controls.DarkTextBox txt_region;
        private DarkUI.Controls.DarkLabel darkLabel13;
        private DarkUI.Controls.DarkTextBox txt_posy;
        private DarkUI.Controls.DarkLabel darkLabel14;
        private DarkUI.Controls.DarkTextBox txt_posx;
        private DarkUI.Controls.DarkLabel darkLabel15;
        private DarkUI.Controls.DarkTextBox txt_points;
        private DarkUI.Controls.DarkLabel darkLabel16;
        private DarkUI.Controls.DarkListView list_classes;
        private System.Windows.Forms.ToolStripButton strip_delete;
    }
}