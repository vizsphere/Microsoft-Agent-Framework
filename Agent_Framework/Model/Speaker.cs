using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Agent_Framework.Model
{
    public class Speaker
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("bio")]
        public string Bio { get; set; }

        [JsonPropertyName("webSite")]
        public string WebSite { get; set; }
    }
}
