using System;
using Newtonsoft.Json;

namespace PressBox.Domain.Models
{
    public class BaseMatch
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("date")]
        public DateTime Date { get; set; }
        [JsonProperty("gameWeek")]
        public int GameWeek { get; set; }
        [JsonProperty("venue")]
        public string Venue { get; set; }
    }
}
