using Newtonsoft.Json;

namespace PressBox.Domain.Models
{
    public class Team
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
