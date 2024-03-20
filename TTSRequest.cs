using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TTSPlay.HT
{
    public class TTSRequest
    {
        [JsonPropertyName("text")]
        public string Text { get; set; }
        [JsonPropertyName("voice")]
        public string Voice { get; set; }
        [JsonPropertyName("output_format")]
        public string OutputFormat { get; set; }
        [JsonPropertyName("speed")]
        public int Speed { get; set; }
        [JsonPropertyName("sample_rate")]
        public int SampleRate { get; set; }
        [JsonPropertyName("voice_engine")]
        public string VoiceEngine { get; set; }
    }
}
