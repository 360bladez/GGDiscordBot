﻿using Newtonsoft.Json;

namespace DiscordBot.Bots.JsonConverts
{
    public struct RandomDog
    {
        [JsonProperty("message")]
        public string Message { get; private set; }
        [JsonProperty("status")]
        public string Status { get; private set; }
    }
}
