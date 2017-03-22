public struct IPAddress {
    public string IP { get; set; }
    public int Port { get; set; }

    public IPAddress(string ip) {
        IP = ip;
        Port = 0;
    }

    public IPAddress(string ip, int port) {
        IP = ip;
        Port = port; 
    } 

    public void Clear() {
        IP = string.Empty;
        Port = 0;
    }
}

