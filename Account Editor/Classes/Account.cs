using System;

namespace AccountEditor {
    public class Account {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string[] CharacterName { get; set; } = new string[Static.MAX_CHARACTER];
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public byte Language { get; set; }
        public string Pin { get; set; }
        public short Access { get; set; }
        public int Cash { get; set; }
        public byte Activated { get; set; }
        public byte LoggedIn { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateLastLogin { get; set; }
        public string CreatorIp { get; set; }
        public string CurrentIp { get; set; }
        public string IpLast { get; set; }

        public Account() {
            Email = string.Empty;
            FirstName = string.Empty;
            LastName = string.Empty;
            Country = string.Empty;
            Pin = string.Empty;

            CreatorIp = string.Empty;
            CurrentIp = string.Empty;
            IpLast = string.Empty;
        }
    }
 }
