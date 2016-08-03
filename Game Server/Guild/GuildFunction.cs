using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameServer.GameGuild {
    public partial class Guild {
        public static void AddData() {
            Data.Add(new GuildData());
        }

        public static int MaxLevel {
            get { return Data.Count - 1; }
        }

        public static long GetDataExp(int index) {
            if (index >= MaxLevel) { index = MaxLevel; }
            return Data[index].Exp;
        }

        public static void SetDataExp(int index, long value) {
            if (index >= MaxLevel) { index = MaxLevel; }
            Data[index].Exp = value;
        }

        public static long GetDataContribution(int index) {
            if (index >= MaxLevel) { index = MaxLevel; }
            return Data[index].Contribution;
        }

        public static void SetDataContribution(int index, long value) {
            if (index >= MaxLevel) { index = MaxLevel; }
            Data[index].Contribution = value;
        }

        public static long GetDataMoney(int index) {
            if (index >= MaxLevel) { index = MaxLevel; }
            return Data[index].Money;
        }

        public static void SetDataMoney(int index, long value) {
            if (index >= MaxLevel) { index = MaxLevel; }
            Data[index].Money = value;
        }

        public static int GetDataMaxMember(int index) {
            if (index >= MaxLevel) { index = MaxLevel; }
            return Data[index].MaxMember;
        }

        public static void SetDataMaxMember(int index, int value) {
            if (index >= MaxLevel) { index = MaxLevel; }
            Data[index].MaxMember = value;
        }
    }
}
