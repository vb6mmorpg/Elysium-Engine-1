using System;
using Lidgren.Network;

namespace WorldServer.GameGuild {
    public partial class Guild {

        public static void UpdatePlayerStatus(int gID, int pID, bool online) {
            GuildMember gMember = FindGuildByID(gID).FindMemberByID(pID);         
            gMember.Status = online;

            //sendtoall 
        }

        public static void UpdateAnnouncement(int gID, string announcement) {
            Guild g = FindGuildByID(gID);
            g.Announcement = announcement;
        
            //sendtoall         
        }

        public static void UpdatePlayerSelfIntro(int gID, int pID, string message) {
            GuildMember gMember = FindGuildByID(gID).FindMemberByID(pID);
            gMember.SelfIntro = message;

            //sendtoall 
        }       
    }
}
