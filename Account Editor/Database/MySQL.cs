namespace AccountEditor.Database {
    public static class MySQL {
        /// <summary>
        /// Conexão com o login db.
        /// </summary>
        public static CommonDB LoginDB { get; set; }

        /// <summary>
        /// Conexão com o game db.
        /// </summary>
        public static CommonDB GameDB { get; set; }
    }
}
