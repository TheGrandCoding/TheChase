using Newtonsoft.Json;
using System;
using System.ComponentModel;

namespace TheChase.Classes
{
    public class MasterlistServer
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("extIP")]
        public string ExternalIP { get; set; }
        [JsonProperty("intIP")]
        public string InternalIP { get; set; }
        [JsonProperty("type")]
        public string Game { get; set; }
        [JsonProperty("hasPw")]
        public bool Password { get; set; }
        [JsonProperty("count", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        [DefaultValue(0)]
        public int CurrentPlayers { get; set; }
        [JsonProperty("max", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        [DefaultValue(0)]
        public int MaximumPlayers { get; set; }

        public MasterlistServer(string name, string ext, string ipIn, string game, bool pass)
        {
            Name = name;
            ExternalIP = ext;
            InternalIP = ipIn;
            Game = game.ToLower();
            Password = pass;
            LastHeartBeat = DateTime.Now;
        }

        [JsonIgnore]
        public DateTime LastHeartBeat { get; set; }

        [JsonIgnore]
        public int Nonce { get; set; }
    }
}
