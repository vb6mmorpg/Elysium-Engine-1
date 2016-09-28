using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Elysium_Diamond.DirectX;
using Elysium_Diamond.Network;
using Elysium_Diamond.GameWindow;
using Elysium_Diamond.Resource;
using Microsoft.VisualBasic;

using System.IO;
using System.Security.Cryptography;

namespace Elysium_Diamond
{
    public partial class CreateDevice : Form
    {
        public string ImeModeIso = string.Empty;
        public bool ImeModeOn = false;
        public bool gameRunning = true;

        IntPtr m_hImc;
        // IME系定義 
        private const int CFS_DEFAULT = 0x0000;
        private const int CFS_RECT = 0x0001;
        private const int CFS_POINT = 0x0002;
        private const int CFS_FORCE_POSITION = 0x0020;
        private const int CFS_CANDIDATEPOS = 0x0040;
        private const int CFS_EXCLUDE = 0x0080;

        // IME系メッセージ 
        private const int WM_IME_STARTCOMPOSITION = 0x010D;
        private const int WM_IME_ENDCOMPOSITION = 0x010E;
        private const int WM_IME_COMPOSITION = 0x010F;
        private const int WM_CHAR = 0x102;
        private const int GCS_RESULTREADSTR = 0x0200;
        private const int WM_IME_SETCONTEXT = 0x0281;

        private const int LF_FACESIZE = 32;

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct LOGFONT {
            public int lfHeight;
            public int lfWidth;
            public int lfEscapement;
            public int lfOrientation;
            public int lfWeight;
            public byte lfItalic;
            public byte lfUnderline;
            public byte lfStrikeOut;
            public byte lfCharSet;
            public byte lfOutPrecision;
            public byte lfClipPrecision;
            public byte lfQuality;
            public byte lfPitchAndFamily;

            // stringでいけると書いてあったがうまく動かないのでこれで 
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = LF_FACESIZE * 2)]
            public byte[] lfFaceName;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct POINTAPI {
            public int x;
            public int y;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct COMPOSITIONFORM {
            public uint dwStyle;
            public POINTAPI ptCurrentPos;
            public RECT rcArea;
        }

        // Imm系メソッド 
        [DllImport("Imm32.dll")]
        private static extern bool ImmAssociateContext(IntPtr hWnd, IntPtr hIMC);

        [DllImport("imm32.dll")]
        public static extern IntPtr ImmGetContext(IntPtr hWnd);

        [DllImport("imm32.dll")]
        public static extern bool ImmSetCompositionWindow(IntPtr hIMC, ref COMPOSITIONFORM lpCompForm);

        [DllImport("imm32.dll")]
        public static extern int ImmSetCompositionFont(IntPtr hIMC, ref LOGFONT lplf);

        [DllImport("imm32.dll")]
        public static extern int ImmReleaseContext(IntPtr hWnd, IntPtr hIMC);

        [DllImport("imm32.dll", CharSet = CharSet.Unicode)]
        public static extern int ImmGetCompositionString(IntPtr hIMC, uint dwIndex, StringBuilder lpBuf, uint dwBufLen);

        /// IMEで入力された文字列を取得 
        private string GetImeString() {
            IntPtr hIMC = ImmGetContext(this.Handle);
            StringBuilder buf;

            try {
                // 訳のわからん処理だがこうしないとゴミる模様 
                int strLen = ImmGetCompositionString(hIMC, 0x800, null, 0);
                buf = new StringBuilder(strLen);
                int getSize = ImmGetCompositionString(hIMC, 0x800, buf, (uint)strLen);
                byte[] by = System.Text.Encoding.Unicode.GetBytes(buf.ToString());
                return System.Text.Encoding.Unicode.GetString(by, 0, strLen);
            }
            finally {
                ImmReleaseContext(this.Handle, hIMC);
            }
        }

        // ImmSetCompositionWindowとImmSetCompositionFontのラッパー 
        protected void SetImeContext(bool setFont) {
            IntPtr hIMC = ImmGetContext(this.Handle);

            if (hIMC == IntPtr.Zero) return;

            try {
                // ウィンドウセット 
                COMPOSITIONFORM form = new COMPOSITIONFORM();
                form.dwStyle = CFS_POINT;
                form.ptCurrentPos.x = 55;// MEMO:X位置設定 
                form.ptCurrentPos.y = 55;// MEMO:Y位置設定 
                ImmSetCompositionWindow(hIMC, ref form);

                // if (withFont) {
                // なんかラッパかまして変換しないとうまくいかない 
                //   object logFontWrap = new LOGFONT();
                //  this.Font.ToLogFont(logFontWrap);
                //   LOGFONT logFont = (GDIMagician.LOGFONT)logFontWrap;
                //  byte[] by = Encoding.Default.GetBytes(this.Font.Name); // MEMO:英語環境とかの挙動怪しいかも？ 
                //   for (int i = 0; i < logFont.lfFaceName.Length; i++) {
                //      logFont.lfFaceName[i] = (i >= by.Length) ? (byte)0 : by[i];
                //   }
                //     ImmSetCompositionFont(hIMC, ref logFont);
                // } */
            }
            finally {
                ImmReleaseContext(this.Handle, hIMC);
            }
        }

        protected override void WndProc(ref System.Windows.Forms.Message m) {
            if (m.Msg == WM_IME_SETCONTEXT && m.WParam.ToInt32() == 1) {
                ImmAssociateContext(this.Handle, (IntPtr)m_hImc);
            }

            switch (m.Msg) {
                case WM_IME_STARTCOMPOSITION:
                    // 入力コンテキストのセット 
                    SetImeContext(true);
                    break;

                case WM_IME_ENDCOMPOSITION:
                    //  this.Text = getImeString();
                    // MEMO:文字列入力処理はここでやってもいいが、ここだとなぜかたまにずれる 
                    break;

                case WM_IME_COMPOSITION:
                    string getStr = GetImeString();
                    if (!string.IsNullOrEmpty(getStr)) {
                        // MEMO:文字列入力処理 
                        // if (EngineCore.GameState == 4) { WindowNewCharacter.textbox.Text += getStr; }                                     
                    }

                    SetImeContext(false);
                    break;
            }

            base.WndProc(ref m);
        }

        #region Peek Message
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool PeekMessage(out Message msg, IntPtr hWnd, uint messageFilterMin, uint messageFilterMax, uint flags);

        /// <summary>Windows Message</summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct Message
        {
            public IntPtr hWnd;
            public IntPtr msg;
            public IntPtr wParam;
            public IntPtr lParam;
            public uint time;
            public System.Drawing.Point p;
        } 

        public void OnApplicationIdle(object sender, EventArgs e)
        {
            while (this.AppStillIdle)
            {
                 EngineCore.Update();
                 EngineCore.Render();
            }

            if (!gameRunning) { EngineCore.Exit(); }
        }

        private bool AppStillIdle
        {
            get
            {
                Message msg;
                return !PeekMessage(out msg, IntPtr.Zero, 0, 0, 0);
            }
        }
        #endregion

        public CreateDevice()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, false);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, false);
            this.SetStyle(ControlStyles.Opaque, true);
        }

        private void CreateDevice_MouseMove(object sender, MouseEventArgs e)
        {
            EngineCore.MousePosition = new SharpDX.Point(this.PointToClient(MousePosition).X, this.PointToClient(MousePosition).Y);
        }

        private void CreateDevice_MouseUp(object sender, MouseEventArgs e)
        {
            EngineCore.MouseDown = false;
        }

        private void CreateDevice_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) { EngineCore.MouseDown = true; }
        }

        private void CreateDevice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) { gameRunning = false; }

           // if (e.KeyCode == Keys.J) { NetworkPacket.CreateGuild("銀魂"); }

          //  if (e.KeyCode == Keys.W) { GameCharacter.DirUp = true; GameCharacter.DirDown = false; GameCharacter.DirLeft = false; GameCharacter.DirRight = false; }
        //    if (e.KeyCode == Keys.S) { GameCharacter.DirUp = false; GameCharacter.DirDown = true; GameCharacter.DirLeft = false; GameCharacter.DirRight = false; }
        //    if (e.KeyCode == Keys.A) { GameCharacter.DirUp = false; GameCharacter.DirDown = false; GameCharacter.DirLeft = true; GameCharacter.DirRight = false; }
       //     if (e.KeyCode == Keys.D) { GameCharacter.DirUp = false; GameCharacter.DirDown = false; GameCharacter.DirLeft = false; GameCharacter.DirRight = true; }

            if (EngineCore.GameState == 6)
            {
                if (WindowGuild.GuildName.CompareTo(string.Empty) == 0) { return; }

                if (e.KeyCode == Keys.G)
                {
                    if (WindowGuild.Visible) 
                    { 
                        WindowGuild.Visible = false; 
                    }
                    else
                    {
                        WindowGuild.Visible = true; 
                    }
                }
            }
        }

        private void CreateDevice_Load(object sender, EventArgs e)
        {
            m_hImc = ImmGetContext(this.Handle);

            var md5 = MD5.Create();

            Common.Settings.CheckSumClient = BitConverter.ToString(md5.ComputeHash(File.ReadAllBytes("Elysium Diamond.exe")));
        }
 
        private void CreateDevice_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region GameState 1
            if (EngineCore.GameState == 1)
            {   
                if (e.KeyChar == Convert.ToChar(Keys.Enter))
                {
                    WindowLogin.Login();
                }

                if (e.KeyChar == Convert.ToChar(Keys.Tab))
                {
                    if (WindowLogin.TextBox[0].CursorEnabled == true)
                    {
                        if (WindowLogin.TextBox[0].Enabled == false) return;
                        WindowLogin.TextBox[0].CursorEnabled = false;
                        WindowLogin.TextBox[1].CursorEnabled = true;
                        WindowLogin.TextBox[1].CursorState = 0;
                    }
                    else
                    {
                        if (WindowLogin.TextBox[1].Enabled == false) return;
                        WindowLogin.TextBox[0].CursorEnabled = true;
                        WindowLogin.TextBox[1].CursorEnabled = false;
                        WindowLogin.TextBox[0].CursorState = 0;
                    }

                    return;
                }


                if (ImeModeOn) { return; }


                if (WindowLogin.TextBox[0].CursorEnabled == true)
                {
                    if (WindowLogin.TextBox[0].Enabled == false) { return; }

                    //if (char.IsLetterOrDigit(e.KeyChar) || char.(e.KeyChar))

                    if (Convert.ToInt32(e.KeyChar) == 8) { if (WindowLogin.TextBox[0].Text.Length > 0) { WindowLogin.TextBox[0].RemoveText(); } }

                    if (char.IsLetterOrDigit(e.KeyChar)) {
                        if (WindowLogin.TextBox[0].Text.Length <= 27) {
                            //retorna se o ime estiver ativado
                            WindowLogin.TextBox[0].AddText(e.KeyChar);
                        } 
                    }           
                }


                if (WindowLogin.TextBox[1].CursorEnabled == true)
                {
                    if (WindowLogin.TextBox[1].Enabled == false) return;

                    if (Convert.ToInt32(e.KeyChar) == 8) { if (WindowLogin.TextBox[1].Text.Length > 0) { WindowLogin.TextBox[1].RemoveText(); } }

                    if (char.IsLetterOrDigit(e.KeyChar)) { 
                        if (WindowLogin.TextBox[1].Text.Length <= 27) { 
                            WindowLogin.TextBox[1].AddText(e.KeyChar);
                        } 
                    }                  
                }

                return;
            }
#endregion

            #region GameState 3
            if (EngineCore.GameState == 3)
            {
                if (!EngineInputBox.Visible) { return; }

                if (EngineInputBox.TextBox.CursorEnabled == true)
                {
                    if (EngineInputBox.TextBox.Enabled == false) return;

                    if (Convert.ToInt32(e.KeyChar) == 8) { if (EngineInputBox.TextBox.Text.Length > 0) { EngineInputBox.TextBox.RemoveText(); } }

                    if (ImeModeOn) { return; }
                    if (char.IsDigit(e.KeyChar) || char.IsLetter(e.KeyChar)) { if (EngineInputBox.TextBox.Text.Length <= 12) { EngineInputBox.TextBox.AddText(e.KeyChar); } }
             
                }

                return;
            }
            #endregion

            #region GameState 4
            if (EngineCore.GameState == 4)
            {
                if (WindowNewCharacter.textbox.CursorEnabled == true)
                {
                    if (WindowNewCharacter.textbox.Enabled == false) return;

                    if (Convert.ToInt32(e.KeyChar) == 8) { if (WindowNewCharacter.textbox.Text.Length > 0) { WindowNewCharacter.textbox.RemoveText(); } }

                    if (ImeModeOn) { return; }
                    if (char.IsDigit(e.KeyChar) || char.IsLetter(e.KeyChar)) { if (WindowNewCharacter.textbox.Text.Length <= 12) { WindowNewCharacter.textbox.AddText(e.KeyChar); } }
                }  

                return;
            }
            #endregion

        }

        private void CreateDevice_FormClosing(object sender, FormClosingEventArgs e) {
            ImmReleaseContext(this.Handle, m_hImc);
        }

        private void CreateDevice_InputLanguageChanged(object sender, InputLanguageChangedEventArgs e) {
            ImeModeIso = e.Culture.TwoLetterISOLanguageName;

            if (ImeModeIso == "en" | ImeModeIso == "pt") {
                ImeModeOn = false;
            } else {
                ImeModeOn = true;
            }
  

            // Get IMC Handle
          /*  IME.imcHandle = IME.ImmGetContext(this.Handle);

            // Get language and layout details
            keys.languageFullName = e.InputLanguage.Culture.EnglishName;
            keys.languageShortName = e.InputLanguage.Culture.TwoLetterISOLanguageName;
            keys.layoutID = e.InputLanguage.Culture.KeyboardLayoutId;

            // Get current Conversion and Sentence Modes into IME.current*
            IME.ImmGetConversionStatus(IME.imcHandle, ref IME.currentConversionMode, ref IME.currentSentenceMode);

            if (IME.currentConversionMode == 0 && keys.languageShortName == "ja") {
                IME.currentConversionMode = (int)IME.ConversionMode.IME_CMODE_NATIVE;
                IME.currentSentenceMode = (int)IME.SentenceMode.IME_SMODE_AUTOMATIC;

                IME.ImmSetConversionStatus(IME.imcHandle, (int)IME.ConversionMode.IME_CMODE_NATIVE | (int)IME.ConversionMode.IME_CMODE_FULLSHAPE, (int)IME.SentenceMode.IME_SMODE_AUTOMATIC);

            }

            if (IME.currentConversionMode != 0 && keys.languageShortName == "en") {
                IME.currentConversionMode = 0;
                IME.currentSentenceMode = (int)IME.SentenceMode.IME_SMODE_NONE;

                IME.ImmSetConversionStatus(IME.imcHandle, (int)IME.ConversionMode.IME_CMODE_ALPHANUMERIC, (int)IME.SentenceMode.IME_SMODE_NONE);

            }

            // Release IMC Handle
            IME.ImmReleaseContext(this.Handle, IME.imcHandle);

            base.OnInputLanguageChanged(e);
             */
        }

        private void CreateDevice_ImeModeChanged(object sender, EventArgs e) {
          
  
        }
    }
}


