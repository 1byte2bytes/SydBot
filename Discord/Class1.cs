using System;
using System.Net;

namespace Discord
{
    public class DiscordCS
    {
        //The Discord gateway URL we have been given
        public string GatewayURL = string.Empty;

        //Discord API info
        public int APIVersion = 3;
        public string APIBaseURL = "https://discordapp.com/api/v";
        
        //<summary>Obtain the Discord gateway URL, connect to it, and login. Also sets up the heartbeat tick.</summary>
        //<param name="token">Your Discord bot token</param>
        public void Connect(string token)
        {
            using (WebClient client = new WebClient())
            {
                GatewayURL = client.DownloadString(GenAPIURL("gateway"));
            }
            
            System.Console.WriteLine(GatewayURL);
        }

        private string GenAPIURL(string endpoint)
        {
            return APIBaseURL + APIVersion + "/" + endpoint;
        }
    }
}