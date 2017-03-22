using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Elysium_Diamond.Common;
using Elysium_Diamond.GameClient;
using Elysium_Diamond.DirectX;
using SharpDX;
using SharpDX.Direct3D9;

namespace Elysium_Diamond.EngineWindow {
    public static class WindowCharacterStatus {
        private static EngineObject background;
        private static int X, Y;
        private static EngineButton[] button = new EngineButton[6];
        private static int showIndex;
        public static bool Visible = false;

        public static void Initialize() {
            X = 50; Y = 50;

            background = new EngineObject(Environment.CurrentDirectory + @"\Data\Graphics\stats_back.png");
            background.Size = new Size2(380, 544);
            background.Position = new Point(X, Y);
            background.SourceRect = new Rectangle(0, 0, 369, 536);

            button[0] = new EngineButton("vital", 128, 32);
            button[0].Index = 0;
            button[0].BorderRect = new Rectangle(20, 2, 86, 26);
            button[0].SourceRect = new Rectangle(0, 0, 128, 32);
            button[0].Position = new Point(X + 20, Y + 300);
            button[0].MouseUp += WindowCharacterStatus_MouseUp; 

            button[1] = new EngineButton("physical", 128, 32);
            button[1].Index = 1;
            button[1].BorderRect = new Rectangle(20, 2, 86, 26);
            button[1].SourceRect = new Rectangle(0, 0, 128, 32);
            button[1].Position = new Point(X + 20, Y + 330);
            button[1].MouseUp += WindowCharacterStatus_MouseUp;

            button[2] = new EngineButton("magic", 128, 32);
            button[2].Index = 2;
            button[2].BorderRect = new Rectangle(20, 2, 86, 26);
            button[2].SourceRect = new Rectangle(0, 0, 128, 32);
            button[2].Position = new Point(X + 20, Y + 360);
            button[2].MouseUp += WindowCharacterStatus_MouseUp;

            button[3] = new EngineButton("elemental", 128, 32);
            button[3].Index = 3;
            button[3].BorderRect = new Rectangle(20, 2, 86, 26);
            button[3].SourceRect = new Rectangle(0, 0, 128, 32);
            button[3].Position = new Point(X + 20, Y + 390);
            button[3].MouseUp += WindowCharacterStatus_MouseUp;

            button[4] = new EngineButton("resist", 128, 32);
            button[4].Index = 4;
            button[4].BorderRect = new Rectangle(20, 2, 86, 26);
            button[4].SourceRect = new Rectangle(0, 0, 128, 32);
            button[4].Position = new Point(X + 20, Y + 420);
            button[4].MouseUp += WindowCharacterStatus_MouseUp;

            button[5] = new EngineButton("unique", 128, 32);
            button[5].Index = 5;
            button[5].BorderRect = new Rectangle(20, 2, 86, 26);
            button[5].SourceRect = new Rectangle(0, 0, 128, 32);
            button[5].Position = new Point(X + 20, Y + 450);
            button[5].MouseUp += WindowCharacterStatus_MouseUp;
        }

        private static void WindowCharacterStatus_MouseUp(object sender, EventArgs e) {
            showIndex = ((EngineButton)sender).Index;  
        }

        public static void Draw() {
            if (!Visible) return;

            background.Draw();

            button[0].Draw();
            button[1].Draw();
            button[2].Draw();
            button[3].Draw();
            button[4].Draw();
            button[5].Draw();

            switch (showIndex) {
                case 0:
                    ShowVitalStats();
                break;
                case 1:
                    ShowPhysicalStats();
                break;
                case 2:
                    ShowMagicStats();
                break;
                case 3:
                    ShowElementalStats();
                break;
                case 4:
                    ShowResistStats();
                break;
                case 5:
                    ShowUniqueStats();
                break;
            }

            EngineFont.DrawText(null, "Character Status", new Size2(380, 20), new Point(X, Y + 18), Color.White, EngineFontStyle.Bold, FontDrawFlags.Center, true);
            EngineFont.DrawText(null, Client.PlayerLocal.Name + " Lv. " + Client.PlayerLocal.Level, new Size2(380, 20), new Point(X, Y + 35), Color.White, EngineFontStyle.Bold, FontDrawFlags.Center, true);

            EngineFont.DrawText(null, "Strenght", X + 70, Y + 70, Color.White, EngineFontStyle.Regular);
            EngineFont.DrawText(null, Client.PlayerLocal.Strenght + "", X + 260, Y + 70, Color.White, EngineFontStyle.Regular);

            EngineFont.DrawText(null, "Dexterity", X + 70, Y + 90, Color.White, EngineFontStyle.Regular);
            EngineFont.DrawText(null, Client.PlayerLocal.Dexterity + "", X + 260, Y + 90, Color.White, EngineFontStyle.Regular);

            EngineFont.DrawText(null, "Agility", X + 70, Y + 110, Color.White, EngineFontStyle.Regular);
            EngineFont.DrawText(null, Client.PlayerLocal.Agility + "", X + 260, Y + 110, Color.White, EngineFontStyle.Regular);

            EngineFont.DrawText(null, "Constitution", X + 70, Y + 130, Color.White, EngineFontStyle.Regular);
            EngineFont.DrawText(null, Client.PlayerLocal.Constitution + "", X + 260, Y + 130, Color.White, EngineFontStyle.Regular);

            EngineFont.DrawText(null, "Intelligence", X + 70, Y + 150, Color.White, EngineFontStyle.Regular);
            EngineFont.DrawText(null, Client.PlayerLocal.Intelligence + "", X + 260, Y + 150, Color.White, EngineFontStyle.Regular);

            EngineFont.DrawText(null, "Wisdom", X + 70, Y + 170, Color.White, EngineFontStyle.Regular);
            EngineFont.DrawText(null, Client.PlayerLocal.Wisdom + "", X + 260, Y + 170, Color.White, EngineFontStyle.Regular);

            EngineFont.DrawText(null, "Will", X + 70, Y + 190, Color.White, EngineFontStyle.Regular);
            EngineFont.DrawText(null, Client.PlayerLocal.Will + "", X + 260, Y + 190, Color.White, EngineFontStyle.Regular);

            EngineFont.DrawText(null, "Mind", X + 70, Y + 210, Color.White, EngineFontStyle.Regular);
            EngineFont.DrawText(null, Client.PlayerLocal.Mind + "", X + 260, Y + 210, Color.White, EngineFontStyle.Regular);

            EngineFont.DrawText(null, "Charisma", X + 70, Y + 230, Color.White, EngineFontStyle.Regular);
            EngineFont.DrawText(null, Client.PlayerLocal.Charisma + "", X + 260, Y + 230, Color.White, EngineFontStyle.Regular);

            EngineFont.DrawText(null, "Points", X + 70, Y + 250, Color.White, EngineFontStyle.Regular);
            EngineFont.DrawText(null, Client.PlayerLocal.Points + "", X + 260, Y + 250, Color.White, EngineFontStyle.Regular);
        }

        public static void ShowVitalStats() {
            EngineFont.DrawText(null, "MaxHP", X + 140, Y + 300, Color.White, EngineFontStyle.Regular);
            EngineFont.DrawText(null, Client.PlayerLocal.MaxHP + "", X + 295, Y + 300, Color.White, EngineFontStyle.Regular);

            EngineFont.DrawText(null, "HP", X + 140, Y + 320, Color.White, EngineFontStyle.Regular);
            EngineFont.DrawText(null, Client.PlayerLocal.HP + "", X + 295, Y + 320, Color.White, EngineFontStyle.Regular);

            EngineFont.DrawText(null, "MaxMP", X + 140, Y + 340, Color.White, EngineFontStyle.Regular);
            EngineFont.DrawText(null, Client.PlayerLocal.MaxMP + "", X + 295, Y + 340, Color.White, EngineFontStyle.Regular);

            EngineFont.DrawText(null, "MP", X + 140, Y + 360, Color.White, EngineFontStyle.Regular);
            EngineFont.DrawText(null, Client.PlayerLocal.MP + "", X + 295, Y + 360, Color.White, EngineFontStyle.Regular);

            EngineFont.DrawText(null, "MaxSP", X + 140, Y + 380, Color.White, EngineFontStyle.Regular);
            EngineFont.DrawText(null, Client.PlayerLocal.MaxSP + "", X + 295, Y + 380, Color.White, EngineFontStyle.Regular);

            EngineFont.DrawText(null, "SP", X + 140, Y + 400, Color.White, EngineFontStyle.Regular);
            EngineFont.DrawText(null, Client.PlayerLocal.SP + "", X + 295, Y + 400, Color.White, EngineFontStyle.Regular);    

            EngineFont.DrawText(null, "Regen HP", X + 140, Y + 420, Color.White, EngineFontStyle.Regular);
            EngineFont.DrawText(null, Client.PlayerLocal.RegenHP + "", X + 295, Y + 420, Color.White, EngineFontStyle.Regular);

            EngineFont.DrawText(null, "Regen MP", X + 140, Y + 440, Color.White, EngineFontStyle.Regular);
            EngineFont.DrawText(null, Client.PlayerLocal.RegenMP + "", X + 295, Y + 440, Color.White, EngineFontStyle.Regular);

            EngineFont.DrawText(null, "Regen SP", X + 140, Y + 460, Color.White, EngineFontStyle.Regular);
            EngineFont.DrawText(null, Client.PlayerLocal.RegenSP + "", X + 295, Y + 460, Color.White, EngineFontStyle.Regular);
        }

        public static void ShowPhysicalStats() {
            EngineFont.DrawText(null, "Ataque", X + 140, Y + 300, Color.White, EngineFontStyle.Regular);
            EngineFont.DrawText(null, Client.PlayerLocal.Attack + "", X + 295, Y + 300, Color.White, EngineFontStyle.Regular);

            EngineFont.DrawText(null, "Precisão", X + 140, Y + 320, Color.White, EngineFontStyle.Regular);
            EngineFont.DrawText(null, Client.PlayerLocal.Accuracy + "", X + 295, Y + 320, Color.White, EngineFontStyle.Regular);

            EngineFont.DrawText(null, "Defesa", X + 140, Y + 340, Color.White, EngineFontStyle.Regular);
            EngineFont.DrawText(null, Client.PlayerLocal.Defense + "", X + 295, Y + 340, Color.White, EngineFontStyle.Regular);

            EngineFont.DrawText(null, "Evasão", X + 140, Y + 360, Color.White, EngineFontStyle.Regular);
            EngineFont.DrawText(null, Client.PlayerLocal.Evasion + "", X + 295, Y + 360, Color.White, EngineFontStyle.Regular);

            EngineFont.DrawText(null, "Bloqueio (Escudo)", X + 140, Y + 380, Color.White, EngineFontStyle.Regular);
            EngineFont.DrawText(null, Client.PlayerLocal.Block + "", X + 295, Y + 380, Color.White, EngineFontStyle.Regular);

            EngineFont.DrawText(null, "Bloqueio (Arma)", X + 140, Y + 400, Color.White, EngineFontStyle.Regular);
            EngineFont.DrawText(null, Client.PlayerLocal.Parry + "", X + 295, Y + 400, Color.White, EngineFontStyle.Regular);

            EngineFont.DrawText(null, "Taxa Crítica", X + 140, Y + 420, Color.White, EngineFontStyle.Regular);
            EngineFont.DrawText(null, Client.PlayerLocal.CriticalRate + "", X + 295, Y + 420, Color.White, EngineFontStyle.Regular);

            EngineFont.DrawText(null, "Dano Crítico", X + 140, Y + 440, Color.White, EngineFontStyle.Regular);
            EngineFont.DrawText(null, Client.PlayerLocal.CriticalDamage + "", X + 295, Y + 440, Color.White, EngineFontStyle.Regular);

            EngineFont.DrawText(null, "Velocidade Ataque", X + 140, Y + 460, Color.White, EngineFontStyle.Regular);
            EngineFont.DrawText(null, Client.PlayerLocal.AttackSpeed + "", X + 295, Y + 460, Color.White, EngineFontStyle.Regular);
        }

        public static void ShowMagicStats() {
            EngineFont.DrawText(null, "Ataque Mágico", X + 140, Y + 300, Color.White, EngineFontStyle.Regular);
            EngineFont.DrawText(null, Client.PlayerLocal.MagicAttack + "", X + 295, Y + 300, Color.White, EngineFontStyle.Regular);

            EngineFont.DrawText(null, "Precisão Mágica", X + 140, Y + 320, Color.White, EngineFontStyle.Regular);
            EngineFont.DrawText(null, Client.PlayerLocal.MagicAccuracy + "", X + 295, Y + 320, Color.White, EngineFontStyle.Regular);

            EngineFont.DrawText(null, "Defesa Mágica", X + 140, Y + 340, Color.White, EngineFontStyle.Regular);
            EngineFont.DrawText(null, Client.PlayerLocal.MagicDefense + "", X + 295, Y + 340, Color.White, EngineFontStyle.Regular);

            EngineFont.DrawText(null, "Resistência Mágica", X + 140, Y + 360, Color.White, EngineFontStyle.Regular);
            EngineFont.DrawText(null, Client.PlayerLocal.MagicResist + "", X + 295, Y + 360, Color.White, EngineFontStyle.Regular);

            EngineFont.DrawText(null, "Taxa Crítica Mágica", X + 140, Y + 380, Color.White, EngineFontStyle.Regular);
            EngineFont.DrawText(null, Client.PlayerLocal.MagicCriticalRate + "", X + 295, Y + 380, Color.White, EngineFontStyle.Regular);

            EngineFont.DrawText(null, "Dano Crítico Mágico", X + 140, Y + 400, Color.White, EngineFontStyle.Regular);
            EngineFont.DrawText(null, Client.PlayerLocal.MagicCriticalDamage + "", X + 295, Y + 400, Color.White, EngineFontStyle.Regular);

            EngineFont.DrawText(null, "Velocidade Conjuração", X + 140, Y + 420, Color.White, EngineFontStyle.Regular);
            EngineFont.DrawText(null, Client.PlayerLocal.CastSpeed + "", X + 295, Y + 420, Color.White, EngineFontStyle.Regular);
        }

        public static void ShowElementalStats() {
            EngineFont.DrawText(null, "Elemento Fogo", X + 140, Y + 300, Color.White, EngineFontStyle.Regular);
            EngineFont.DrawText(null, Client.PlayerLocal.AttributeFire + "", X + 295, Y + 300, Color.White, EngineFontStyle.Regular);

            EngineFont.DrawText(null, "Elemento Água", X + 140, Y + 320, Color.White, EngineFontStyle.Regular);
            EngineFont.DrawText(null, Client.PlayerLocal.AttributeWater + "", X + 295, Y + 320, Color.White, EngineFontStyle.Regular);

            EngineFont.DrawText(null, "Elemento Terra", X + 140, Y + 340, Color.White, EngineFontStyle.Regular);
            EngineFont.DrawText(null, Client.PlayerLocal.AttributeEarth + "", X + 295, Y + 340, Color.White, EngineFontStyle.Regular);

            EngineFont.DrawText(null, "Elemento Ar", X + 140, Y + 360, Color.White, EngineFontStyle.Regular);
            EngineFont.DrawText(null, Client.PlayerLocal.AttributeWind + "", X + 295, Y + 360, Color.White, EngineFontStyle.Regular);
        }

        public static void ShowUniqueStats() {
            EngineFont.DrawText(null, "Concentração", X + 140, Y + 300, Color.White, EngineFontStyle.Regular);
            EngineFont.DrawText(null, Client.PlayerLocal.Concentration + "", X + 295, Y + 300, Color.White, EngineFontStyle.Regular);

            EngineFont.DrawText(null, "Poder de Cura", X + 140, Y + 320, Color.White, EngineFontStyle.Regular);
            EngineFont.DrawText(null, Client.PlayerLocal.HealingPower + "", X + 295, Y + 320, Color.White, EngineFontStyle.Regular);

            EngineFont.DrawText(null, "Inimizade", X + 140, Y + 340, Color.White, EngineFontStyle.Regular);
            EngineFont.DrawText(null, Client.PlayerLocal.Enmity + "", X + 295, Y + 340, Color.White, EngineFontStyle.Regular);

            EngineFont.DrawText(null, "Supressão de Dano", X + 140, Y + 360, Color.White, EngineFontStyle.Regular);
            EngineFont.DrawText(null, Client.PlayerLocal.DamageSuppression + "", X + 295, Y + 360, Color.White, EngineFontStyle.Regular);
        }

        public static void ShowResistStats() {
            EngineFont.DrawText(null, "Res. Atordoamento", X + 140, Y + 300, Color.White, EngineFontStyle.Regular);
            EngineFont.DrawText(null, Client.PlayerLocal.ResistStun + "", X + 295, Y + 300, Color.White, EngineFontStyle.Regular);

            EngineFont.DrawText(null, "Res. Paralisia", X + 140, Y + 320, Color.White, EngineFontStyle.Regular);
            EngineFont.DrawText(null, Client.PlayerLocal.ResistParalysis + "", X + 295, Y + 320, Color.White, EngineFontStyle.Regular);

            EngineFont.DrawText(null, "Res. Silêncio", X + 140, Y + 340, Color.White, EngineFontStyle.Regular);
            EngineFont.DrawText(null, Client.PlayerLocal.ResistSilence + "", X + 295, Y + 340, Color.White, EngineFontStyle.Regular);

            EngineFont.DrawText(null, "Res. Cegueira", X + 140, Y + 360, Color.White, EngineFontStyle.Regular);
            EngineFont.DrawText(null, Client.PlayerLocal.ResistBlind + "", X + 295, Y + 360, Color.White, EngineFontStyle.Regular);

            EngineFont.DrawText(null, "Res. Taxa Crítica", X + 140, Y + 380, Color.White, EngineFontStyle.Regular);
            EngineFont.DrawText(null, Client.PlayerLocal.ResistCriticalRate + "", X + 295, Y + 380, Color.White, EngineFontStyle.Regular);

            EngineFont.DrawText(null, "Res. Dano Crítico", X + 140, Y + 400, Color.White, EngineFontStyle.Regular);
            EngineFont.DrawText(null, Client.PlayerLocal.ResistCriticalDamage + "", X + 295, Y + 400, Color.White, EngineFontStyle.Regular);

            EngineFont.DrawText(null, "Res. Taxa Crít. Mág.", X + 140, Y + 420, Color.White, EngineFontStyle.Regular);
            EngineFont.DrawText(null, Client.PlayerLocal.ResistMagicCriticalRate + "", X + 295, Y + 420, Color.White, EngineFontStyle.Regular);

            EngineFont.DrawText(null, "Res. Dano Crít. Mág.", X + 140, Y + 440, Color.White, EngineFontStyle.Regular);
            EngineFont.DrawText(null, Client.PlayerLocal.ResistMagicCriticalDamage + "", X + 295, Y + 440, Color.White, EngineFontStyle.Regular);
        }
    }
}
