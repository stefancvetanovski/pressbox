using Newtonsoft.Json;

namespace PressBox.Domain.Models
{
    public class BrandEntity
    {
        [JsonProperty("teamId")]
        public string TeamId { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("primaryColor")]
        public string PrimaryColor { get; set; }
        [JsonProperty("abbreviation")]
        public string Abbreviation { get; set; }
    }
}
