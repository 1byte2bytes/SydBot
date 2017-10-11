using System.IO;
using Newtonsoft.Json;

namespace Discord
{
    class IdentifyOpcode
    {
        //A very shitty implementation, fix this
        public static string gettext(string token)
        {
            using (StreamReader fs = new StreamReader("bot.json"))
            {
                dynamic json_data = JsonConvert.DeserializeObject(fs.ReadToEnd());
                return
                    "{ \"token\": \"" + json_data.token + "\"," +
                    "\"properties\": { \"$os\": \"linux\", \"$browser\": \"DiscordCS\", \"$device\": \"DiscordCS\"}," +
                    "\"compress\": false," +
                    "\"large_threshold\": " + json_data.largeserver + "," +
                    "\"presence\": { \"game\": { \"name\": \"" + json_data.status_msg + "\", \"type\": 0 }, \"status\": \"online\", \"since\": null, \"afk\": false}}";
            }
        }
    }

    class ErrorOpcode
    {

    }
}
