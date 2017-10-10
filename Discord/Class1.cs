using System.Net;
using Newtonsoft.Json;
using NLog;

namespace Discord
{
    public class DiscordCS
    {
        //Our logger
        private static Logger logger = LogManager.GetCurrentClassLogger();
        
        //The Discord gateway URL we have been given
        public string GatewayURL = string.Empty;

        //Discord API info
        public int APIVersion = 3;
        public string APIBaseURL = "https://discordapp.com/api/v";
        
        //<summary>Obtain the Discord gateway URL, connect to it, and login. Also sets up the heartbeat tick.</summary>
        //<param name="token">Your Discord bot token</param>
        public void Connect(string token)
        {
            logger.Trace("DiscordCS Connect() called");
            using (WebClient client = new WebClient())
            {
                logger.Debug("Getting gateway URL");
                string response = client.DownloadString(GenAPIURL("gateway"));
                logger.Trace("Deserializing JSON based response");
                dynamic json_response = JsonConvert.DeserializeObject(response);

                logger.Trace("Setting GatewayURL variable to the responded URL");
                GatewayURL = json_response.url;
            }
            
            logger.Trace("Gateway URL is now " + GatewayURL);
        }

        private string GenAPIURL(string endpoint)
        {
            string temp = APIBaseURL + APIVersion + "/" + endpoint;
            logger.Trace("Generating API URL: " + temp);
            return temp;
        }
    }
}
