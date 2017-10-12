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

            logger.Trace("Decoding OPcode " + json_data.op);
            if (json_data.op == "10")
            {
                System.Threading.Thread t = new System.Threading.Thread(delegate(){
                    HeartbeatHandler.handler(ws, Convert.ToInt32(json_data.d.heartbeat_interval));
                });
                t.Start();

                logger.Trace("Sending Indentify (opcode 2)");
                string identify = "{\"op\": 2, \"d\": " + IdentifyOpcode.gettext() + "}";
                logger.Trace("Identify data sent: " + identify);
                ws.SendAsync(identify, null);
            }
        }
    }
}
