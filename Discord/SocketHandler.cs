using Newtonsoft.Json;
using NLog;
using System;

namespace Discord
{
    class SocketHandler
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static void OnMessage(WebSocketSharp.WebSocket ws, object sender, WebSocketSharp.MessageEventArgs e) 
        {
            logger.Trace("WebSocket message: " + e.Data);

            logger.Trace("Deserializing WebSocket message");
            dynamic json_data = JsonConvert.DeserializeObject(e.Data);

            logger.Trace("Decoding OPcode");
            if (json_data.op == "10")
            {
                HeartbeatHandler handler = new HeartbeatHandler(ws, Convert.ToInt32(json_data.d.heartbeat_interval));
            }
        }
    }
}
