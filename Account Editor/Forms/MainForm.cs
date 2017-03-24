using System;
using DarkUI.Forms;
using AccountEditor.Database;

namespace AccountEditor {
    public partial class MainForm : DarkForm {

        public MainForm() {
            InitializeComponent();
        }

        private void btn_edit_Click(object sender, EventArgs e) {
            Program.AccountForm = new FormAccount();     
            Program.AccountForm.Show();
        }

        private void btn_new_Click(object sender, EventArgs e) {
            NewAccount newAccount = new NewAccount();
            newAccount.Show();
        }

        private void MainForm_Load(object sender, EventArgs e) {
            InitializeDatabase();

            Static.Classes = ClasseDB.LoadClasseData();
        }

        private void InitializeDatabase() {
            // carrega o arquivo de configuração
            Configuration.ParseConfigFile("config.txt");
            MySQL.LoginDB = new CommonDB();
            MySQL.LoginDB.Server = Configuration.GetString("login_ip");
            MySQL.LoginDB.Port = Configuration.GetInt32("login_port");
            MySQL.LoginDB.Username = Configuration.GetString("login_user");
            MySQL.LoginDB.Password = Configuration.GetString("login_password");
            MySQL.LoginDB.Database = Configuration.GetString("login_database");

            MySQL.GameDB = new CommonDB();
            MySQL.GameDB.Server = Configuration.GetString("game_ip");
            MySQL.GameDB.Port = Configuration.GetInt32("game_port");
            MySQL.GameDB.Username = Configuration.GetString("game_user");
            MySQL.GameDB.Password = Configuration.GetString("game_password");
            MySQL.GameDB.Database = Configuration.GetString("game_database");

            var error = string.Empty;
            if (!MySQL.LoginDB.Open(out error)) {
                DarkMessageBox.ShowError(error, "Ocorreu um erro ao conectar ao MySQL.");
                return;
            }

            if (!MySQL.GameDB.Open(out error)) {
                DarkMessageBox.ShowError(error, "Ocorreu um erro ao conectar ao MySQL.");
                return;
            }
        }
    }
}
