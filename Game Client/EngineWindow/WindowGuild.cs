using System;
using Elysium_Diamond.DirectX;
using Elysium_Diamond.Common;
using SharpDX;
using SharpDX.Direct3D9;
using Color = SharpDX.Color;


namespace Elysium_Diamond.GameWindow
{
    public class WindowGuild
    {    
        private static EngineObject guild_panel;
        private static EngineButton[] button = new EngineButton[5];
        private static int posx = 300;
        private static int posy = 200;

        public static bool Visible { get; set; }

        public static string GuildName { get; set; } = string.Empty;
        public static string GuildMaster { get; set; } = string.Empty;
        public static string Announcement { get; set; } = string.Empty;
        public static int Level { get; set; }
        public static long Exp { get; set; }
        public static long ExpMax { get; set; }
        public static int Ranking { get; set; }
        public static long Contribution { get; set; }
        public static int Member { get; set; }
        public static int MemberMax { get; set; }
        public static int Online { get; set; }

        private static bool needUpdate = true;
        public static bool NeedUpdate
        {
            get { return needUpdate; }
            set { needUpdate = value; }
        }

        public static void Initialize()
        {
            guild_panel = new EngineObject();
            guild_panel.Texture = EngineTexture.TextureFromFile(Settings.GamePath + @"\Data\Graphics\guild_panel_2.png", 430, 280);
            guild_panel.Size = new Size2(430, 280);
            guild_panel.SourceRect = new Rectangle(0, 0, 430, 280);
            guild_panel.Visible = true;
            guild_panel.Position = new Point(300, 200);
            guild_panel.Color = Color.White;
            guild_panel.Transparency = 255;

            button[0] = new EngineButton(Settings.lang, Settings.GamePath, "detail", 128, 32);
            button[0].Position = new Point(posx + 62, posy + 50);
            button[0].BorderRect = new Rectangle(20, 2, 86, 26);
            button[0].Enabled = true;
            button[0].Size = new Size2(128, 32);
            button[0].SourceRect = new Rectangle(0, 0, 128, 32);
            button[0].MouseUp += Detail_MouseUp;

            button[1] = new EngineButton(Settings.lang, Settings.GamePath, "quest", 128, 32);
            button[1].Position = new Point(posx + 165, posy + 50);
            button[1].BorderRect = new Rectangle(20, 2, 86, 26);
            button[1].Enabled = true;
            button[1].Size = new Size2(128, 32);
            button[1].SourceRect = new Rectangle(0, 0, 128, 32);
            button[1].MouseUp += Quest_MouseUp;

            button[2] = new EngineButton(Settings.lang, Settings.GamePath, "member", 128, 32);
            button[2].Position = new Point(posx + 270, posy + 50);
            button[2].BorderRect = new Rectangle(20, 2, 86, 26);
            button[2].Enabled = true;
            button[2].Size = new Size2(128, 32);
            button[2].SourceRect = new Rectangle(0, 0, 128, 32);
            button[2].MouseUp += Member_MouseUp;

            button[3] = new EngineButton(Settings.lang, Settings.GamePath, "invite", 128, 32);
            button[3].Position = new Point(posx + 165, posy + 210);
            button[3].BorderRect = new Rectangle(20, 2, 86, 26);
            button[3].Enabled = true;
            button[3].Size = new Size2(128, 32);
            button[3].SourceRect = new Rectangle(0, 0, 128, 32);
            button[3].MouseUp += Member_MouseUp;

            button[4] = new EngineButton(Settings.lang, Settings.GamePath, "panel", 128, 32);
            button[4].Position = new Point(posx + 270, posy + 210);
            button[4].BorderRect = new Rectangle(20, 2, 86, 26);
            button[4].Enabled = true;
            button[4].Size = new Size2(128, 32);
            button[4].SourceRect = new Rectangle(0, 0, 128, 32);
            button[4].MouseUp += Member_MouseUp;
        }

        public static void Draw()
        {
            if (!Visible) { return; }
            if (GuildName.CompareTo(string.Empty) == 0) { return; }

            guild_panel.Draw();
            button[0].Draw();
            button[1].Draw();
            button[2].Draw();
            button[3].Draw();
            button[4].Draw();

            if (Settings.lang == Language.Portuguese)
            {
                EngineFont.DrawText(null, GuildName, new Size2(430, 0), new Point(posx, posy + 40), Color.BlueViolet, EngineFontStyle.Bold, FontDrawFlags.Left, true);
                EngineFont.DrawText(null, "Guild Master: " + GuildMaster, new Size2(430, 0), new Point(posx, posy + 100), Color.White, EngineFontStyle.Regular, FontDrawFlags.Left, true);
                EngineFont.DrawText(null, "Level: " + Level, posx + 60, posy + 120, Color.White, EngineFontStyle.Regular);
                EngineFont.DrawText(null, "Experiência:  " + Exp + " / " + ExpMax, posx + 190, posy + 120, Color.White, EngineFontStyle.Regular);
                EngineFont.DrawText(null, "Ranking: " + Ranking, posx + 60, posy + 134, Color.White, EngineFontStyle.Regular);
                EngineFont.DrawText(null, "Contribuição: " + Contribution, posx + 190, posy + 140, Color.White, EngineFontStyle.Regular);
                EngineFont.DrawText(null, "Membros: " + Member + " / " + MemberMax, posx + 60, posy + 160, Color.Coral, EngineFontStyle.Regular);
                EngineFont.DrawText(null, "Online: " + Online, posx + 190, posy + 160, Color.Coral, EngineFontStyle.Regular);
                EngineFont.DrawText(null, "Mensagem: ", posx + 60, posy + 180, Color.CornflowerBlue, EngineFontStyle.Regular);
                EngineFont.DrawText(null, Announcement, posx + 145, posy + 180, Color.White, EngineFontStyle.Regular);
            }

            if (Settings.lang == Language.Japanese)
            {
                EngineFont.DrawText(null, GuildName, new Size2(365, 0), new Point(posx, posy + 40), Color.BlueViolet, EngineFontStyle.Bold, FontDrawFlags.Left, true);
                EngineFont.DrawText(null, "ギルドマスター: " + GuildMaster, new Size2(365, 0), new Point(posx, posy + 100), Color.White, EngineFontStyle.Regular, FontDrawFlags.Left, true);
                EngineFont.DrawText(null, "レベル: " + Level, posx + 35, posy + 11, Color.White, EngineFontStyle.Regular);
                EngineFont.DrawText(null, "経験値: " + Exp + " / " + ExpMax, posx + 170, posy + 110, Color.White, EngineFontStyle.Regular);
                EngineFont.DrawText(null, "ランキング: " + Ranking, posx + 35, posy + 130, Color.White, EngineFontStyle.Regular);
                EngineFont.DrawText(null, "ポイント: " + Contribution, posx + 170, posy + 130, Color.White, EngineFontStyle.Regular);
                EngineFont.DrawText(null, "メンバー: " + Member + " / " + MemberMax, posx + 35, posy + 150, Color.Coral, EngineFontStyle.Regular);
                EngineFont.DrawText(null, "オンライン: " + Online, posx + 170, posy + 150, Color.Coral, EngineFontStyle.Regular);
                EngineFont.DrawText(null, "メッセージ: ", posx + 35, posy + 180, Color.CornflowerBlue, EngineFontStyle.Regular);
                EngineFont.DrawText(null, Announcement, posx + 100, posy + 180, Color.White, EngineFontStyle.Regular);
            }
        }

        private static void Member_MouseUp(object sender, EventArgs e)
        {
          
        }

        private static void Quest_MouseUp(object sender, EventArgs e)
        {

        }

        private static void Detail_MouseUp(object sender, EventArgs e)
        {

        }
    }
}
