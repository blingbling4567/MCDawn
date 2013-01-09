/*Q
	Copyright 2010 MCSharp team (Modified for use with MCZall/MCLawl) Licensed under the
	Educational Community License, Version 2.0 (the "License"); you may
	not use this file except in compliance with the License. You may
	obtain a copy of the License at
	
	http://www.osedu.org/licenses/ECL-2.0
	
	Unless required by applicable law or agreed to in writing,
	software distributed under the License is distributed on an "AS IS"
	BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express
	or implied. See the License for the specific language governing
	permissions and limitations under the License.
*/
using System;

namespace MCDawn
{
    public class CmdInfo : Command
    {
        public override string name { get { return "info"; } }
        public override string[] aliases { get { return new string[] { }; } }
        public override string type { get { return "information"; } }
        public override bool museumUsable { get { return true; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Banned; } }
        public CmdInfo() { }

        public override void Use(Player p, string message)
        {
            if (message != "") 
            { 
                Help(p); 
            }
            else
            {
                Player.SendMessage(p, "This server runs on &bMCDawn" + "&g, a Minecraft Classic Server Software that is created by the MCDawn Dev Team. Using MCLawl as a basis, it is actively developed with numerous administration tools and options made for server owners, admins, and operators. Whilst providing a quality set of moderation tools, MCDawn simultaneously offers a unique experience for players in-game with a wide variety of blocks and commands for excellent builders.");
                Player.SendMessage(p, "This server's version: &a" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString());

                TimeSpan up = DateTime.Now - Server.timeOnline;
                string upTime = "Time online: &b";
                if (up.Days == 1) upTime += up.Days + " day, ";
                else if (up.Days > 0) upTime += up.Days + " days, ";
                if (up.Hours == 1) upTime += up.Hours + " hour, ";
                else if (up.Days > 0 || up.Hours > 0) upTime += up.Hours + " hours, ";
                if (up.Minutes == 1) upTime += up.Minutes + " minute and ";
                else if (up.Hours > 0 || up.Days > 0 || up.Minutes > 0) upTime += up.Minutes + " minutes and ";
                if (up.Seconds == 1) upTime += up.Seconds + " second";
                else upTime += up.Seconds + " seconds";
                Player.SendMessage(p, upTime);

                if (Server.updateTimer.Interval > 100) Player.SendMessage(p, "Server is currently in &5Low Lag" + "&g mode.");
            }
        }
        public override void Help(Player p)
        {
            Player.SendMessage(p, "/info - Displays the server information.");
        }
    }
}
