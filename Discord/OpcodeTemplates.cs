using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discord
{
    class IdentifyOpcode
    {
        //A very shitty implementation, fix this
        public static string gettext(string token)
        {
            return
                "{ \"token\": \"" + token + "\"," +
                "\"properties\": { \"$os\": \"linux\", \"$browser\": \"DiscordCS\", \"$device\": \"DiscordCS\"}," +
                "\"compress\": false," +
                "\"large_threshold\": 50," +
                "\"presence\": { \"game\": { \"name\": \"SydBot Alpha\", \"type\": 0 }, \"status\": \"online\", \"since\": null, \"afk\": false}}";
        }
    }

    class ErrorOpcode
    {

    }
}
