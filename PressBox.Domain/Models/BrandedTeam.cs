using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace PressBox.Domain.Models
{
    public class BrandedTeam : Team
    {
        [JsonProperty("brand")]
        public BrandEntity Brand { get; set; }
    }
}
