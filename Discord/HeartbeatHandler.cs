﻿using NLog;
using System.Threading;

namespace Discord
{
    class HeartbeatHandler
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        //static private int beat_interval = 1;
        static private int seq = 0;

        public static void handler(WebSocketSharp.WebSocket ws, int beat_interval)
        {
            while(true)
            {
                logger.Trace("Heartbeat Tick!");
                logger.Trace("Sending heartbeat");
                ws.Send("{\"op\":1, \"d\": + " + seq + "}");
                seq++;
                logger.Trace("Waiting for next heartbeat");
                Thread.Sleep(millisecondsTimeout: beat_interval);
            }
        }
    }
}
