using System;
using Newtonsoft.Json;

namespace PressBox.Domain.Models
{
    public class Match : BaseMatch
    {
        [JsonProperty("homeTeam")]
        public Team HomeTeam { get; set; }
        [JsonProperty("awayTeam")]
        public Team AwayTeam { get; set; }
    }
}
