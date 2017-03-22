namespace WorldServer
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.file_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.min_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quit_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.config_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clear_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClearScreenSeconds = new System.Windows.Forms.ToolStripMenuItem();
            this.Logs = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadGuild_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadChar_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadClasse_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadServerData_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.config_TabPage = new System.Windows.Forms.TabControl();
            this.general_TabPage = new System.Windows.Forms.TabPage();
            this.general_textbox = new System.Windows.Forms.RichTextBox();
            this.timerClear = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip.SuspendLayout();
            this.config_TabPage.SuspendLayout();
            this.general_TabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.file_MenuItem,
            this.config_MenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(565, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // file_MenuItem
            // 
            this.file_MenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.min_MenuItem,
            this.quit_MenuItem});
            this.file_MenuItem.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.file_MenuItem.Name = "file_MenuItem";
            this.file_MenuItem.Size = new System.Drawing.Size(66, 20);
            this.file_MenuItem.Text = "Arquivo";
            // 
            // min_MenuItem
            // 
            this.min_MenuItem.Name = "min_MenuItem";
            this.min_MenuItem.Size = new System.Drawing.Size(132, 22);
            this.min_MenuItem.Text = "Minimizar";
            this.min_MenuItem.Click += new System.EventHandler(this.min_MenuItem_Click);
            // 
            // quit_MenuItem
            // 
            this.quit_MenuItem.Name = "quit_MenuItem";
            this.quit_MenuItem.Size = new System.Drawing.Size(132, 22);
            this.quit_MenuItem.Text = "Sair";
            this.quit_MenuItem.Click += new System.EventHandler(this.quit_MenuItem_Click);
            // 
            // config_MenuItem
            // 
            this.config_MenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clear_MenuItem,
            this.Logs,
            this.reloadGuild_MenuItem,
            this.reloadChar_MenuItem,
            this.reloadClasse_MenuItem,
            this.reloadServerData_MenuItem});
            this.config_MenuItem.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.config_MenuItem.Name = "config_MenuItem";
            this.config_MenuItem.Size = new System.Drawing.Size(102, 20);
            this.config_MenuItem.Text = "Configuração";
            // 
            // clear_MenuItem
            // 
            this.clear_MenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ClearScreenSeconds});
            this.clear_MenuItem.Name = "clear_MenuItem";
            this.clear_MenuItem.Size = new System.Drawing.Size(256, 22);
            this.clear_MenuItem.Text = "Limpar Tela";
            this.clear_MenuItem.Click += new System.EventHandler(this.clear_MenuItem_Click);
            // 
            // ClearScreenSeconds
            // 
            this.ClearScreenSeconds.Name = "ClearScreenSeconds";
            this.ClearScreenSeconds.Size = new System.Drawing.Size(156, 22);
            this.ClearScreenSeconds.Text = "30 segundos";
            this.ClearScreenSeconds.Click += new System.EventHandler(this.ClearScreenSeconds_Click);
            // 
            // Logs
            // 
            this.Logs.CheckOnClick = true;
            this.Logs.Name = "Logs";
            this.Logs.Size = new System.Drawing.Size(256, 22);
            this.Logs.Text = "Desabilitar logs no programa";
            // 
            // reloadGuild_MenuItem
            // 
            this.reloadGuild_MenuItem.Name = "reloadGuild_MenuItem";
            this.reloadGuild_MenuItem.Size = new System.Drawing.Size(256, 22);
            this.reloadGuild_MenuItem.Text = "Recarregar Guilds";
            this.reloadGuild_MenuItem.Click += new System.EventHandler(this.reloadGuild_MenuItem_Click);
            // 
            // reloadChar_MenuItem
            // 
            this.reloadChar_MenuItem.Enabled = false;
            this.reloadChar_MenuItem.Name = "reloadChar_MenuItem";
            this.reloadChar_MenuItem.Size = new System.Drawing.Size(256, 22);
            this.reloadChar_MenuItem.Text = "Recarregar Character";
            this.reloadChar_MenuItem.Click += new System.EventHandler(this.reloadChar_MenuItem_Click);
            // 
            // reloadClasse_MenuItem
            // 
            this.reloadClasse_MenuItem.Name = "reloadClasse_MenuItem";
            this.reloadClasse_MenuItem.Size = new System.Drawing.Size(256, 22);
            this.reloadClasse_MenuItem.Text = "Recarregar Classe";
            this.reloadClasse_MenuItem.Click += new System.EventHandler(this.reloadClasse_MenuItem_Click);
            // 
            // reloadServerData_MenuItem
            // 
            this.reloadServerData_MenuItem.Name = "reloadServerData_MenuItem";
            this.reloadServerData_MenuItem.Size = new System.Drawing.Size(256, 22);
            this.reloadServerData_MenuItem.Text = "Recarregar Game Server IP";
            this.reloadServerData_MenuItem.Click += new System.EventHandler(this.reloadServerData_MenuItem_Click);
            // 
            // config_TabPage
            // 
            this.config_TabPage.Controls.Add(this.general_TabPage);
            this.config_TabPage.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.config_TabPage.Location = new System.Drawing.Point(16, 33);
            this.config_TabPage.Name = "config_TabPage";
            this.config_TabPage.SelectedIndex = 0;
            this.config_TabPage.Size = new System.Drawing.Size(537, 345);
            this.config_TabPage.TabIndex = 1;
            // 
            // general_TabPage
            // 
            this.general_TabPage.Controls.Add(this.general_textbox);
            this.general_TabPage.Location = new System.Drawing.Point(4, 25);
            this.general_TabPage.Name = "general_TabPage";
            this.general_TabPage.Padding = new System.Windows.Forms.Padding(3);
            this.general_TabPage.Size = new System.Drawing.Size(529, 316);
            this.general_TabPage.TabIndex = 0;
            this.general_TabPage.Text = "Geral";
            this.general_TabPage.UseVisualStyleBackColor = true;
            // 
            // general_textbox
            // 
            this.general_textbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.general_textbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.general_textbox.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.general_textbox.Location = new System.Drawing.Point(3, 3);
            this.general_textbox.Name = "general_textbox";
            this.general_textbox.ReadOnly = true;
            this.general_textbox.Size = new System.Drawing.Size(523, 310);
            this.general_textbox.TabIndex = 0;
            this.general_textbox.Text = "";
            // 
            // timerClear
            // 
            this.timerClear.Interval = 30000;
            this.timerClear.Tick += new System.EventHandler(this.timerClear_Tick);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 850;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 390);
            this.Controls.Add(this.config_TabPage);
            this.Controls.Add(this.menuStrip);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "World Server @ ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.config_TabPage.ResumeLayout(false);
            this.general_TabPage.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem file_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem min_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem quit_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem config_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem clear_MenuItem;
        private System.Windows.Forms.TabControl config_TabPage;
        private System.Windows.Forms.TabPage general_TabPage;
        public System.Windows.Forms.RichTextBox general_textbox;
        public System.Windows.Forms.MenuStrip menuStrip;
        public System.Windows.Forms.ToolStripMenuItem Logs;
        private System.Windows.Forms.ToolStripMenuItem reloadGuild_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem reloadChar_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem reloadClasse_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem reloadServerData_MenuItem;
        private System.Windows.Forms.Timer timerClear;
        private System.Windows.Forms.ToolStripMenuItem ClearScreenSeconds;
        private System.Windows.Forms.Timer timer1;
    }
}

