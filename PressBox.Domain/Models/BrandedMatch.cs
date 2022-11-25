using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace PressBox.Domain.Models
{
    public class BrandedMatch : BaseMatch
    {
        [JsonProperty("homeTeam")]
        public BrandedTeam HomeTeam { get; set; }
        [JsonProperty("awayTeam")]
        public BrandedTeam AwayTeam { get; set; }
    }
}
