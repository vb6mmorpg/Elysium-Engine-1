using MySql.Data.MySqlClient;

namespace AccountEditor.Database {
    public class CommonDB {
        private MySqlConnection _connection;
        public string Server;
        public int Port;
        public string Username;
        public string Password;
        public string Database;

        public MySqlConnection Connection {
            get { return _connection; }
        }

        public bool Open(out string message) {
            var query = $"Server={Server};Port={Port};Database={Database};User ID={Username};Password={Password};";

            try {
                _connection = new MySqlConnection(query);
                _connection.Open();
            }
            catch (MySqlException ex) {
                message = ex.Message;
                return false;
            }

            message = string.Empty;
            return true;
        }

        public void Close() {
            if (_connection == null) return;
            _connection.Close();
            _connection.Dispose();
        }
    }
}
