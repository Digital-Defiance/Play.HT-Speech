using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TTSPlay.HT
{
    public class Voice
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("gender")]
        [JsonConverter(typeof(GenderConverter))]
        public Gender gender { get; set; }
        [JsonPropertyName("voice_engine")]
        public string VoiceEngine { get; set; }
    }
}
