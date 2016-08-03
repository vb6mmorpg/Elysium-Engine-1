using System;
using System.Text;
using System.Runtime.InteropServices;
using Elysium_Diamond.Common;

//http://www.codeproject.com/Articles/63094/Simple-MCI-Player

public class EngineMusic {
    private string command;
    private bool isOpen;
    [DllImport("winmm.dll")]

    private static extern long mciSendString(string strCommand, StringBuilder strReturn, int iReturnLength, IntPtr hwndCallback);

    public string Alias { get; set; }
    public string File { get; set; }
    private bool AlreadyStopped { get; set; }
    private bool AlreadyOpened { get; set; }

    public EngineMusic(string file, string alias) {
        File = Settings.GamePath + @"\Data\Music\" + file;
        Alias = alias;
    }

    public void Close() {
        if (AlreadyStopped) { return; }

        command = "close " + Alias;
        mciSendString(command, null, 0, IntPtr.Zero);
        isOpen = false;
        AlreadyStopped = true;
        AlreadyOpened = false;
    }

    public void Open() {
        command = "open \"" + File + "\" type mpegvideo alias " + Alias;
        mciSendString(command, null, 0, IntPtr.Zero);
        isOpen = true;
    }

    public void Play(bool loop) {
        if (AlreadyOpened) { return; }

        if (isOpen) {
            command = "play " + Alias;
            if (loop)
                command += " REPEAT";
            
            mciSendString(command, null, 0, IntPtr.Zero);
            AlreadyOpened = true;
            AlreadyStopped = false;
        }
    }
}