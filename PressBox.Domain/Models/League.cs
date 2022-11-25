using Newtonsoft.Json;

namespace PressBox.Domain.Models
{
    public class League
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
