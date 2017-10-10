using System;
using System.Collections.Generic;
using Discord;

namespace SydBot
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            DiscordCS discord = new DiscordCS();
            
            discord.Connect("");

            return;
        }
    }
}