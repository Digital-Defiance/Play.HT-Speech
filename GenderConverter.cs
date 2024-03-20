using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

namespace TTSPlay.HT
{
    public class GenderConverter : JsonConverter<Gender>
    {
        public override Gender Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                string genderStr = reader.GetString();
                if (genderStr.Equals("male", StringComparison.OrdinalIgnoreCase))
                {
                    return Gender.Male;
                }
                else if (genderStr.Equals("female", StringComparison.OrdinalIgnoreCase))
                {
                    return Gender.Female;
                }
            }

            throw new JsonException("Unable to parse Gender value.");
        }

        public override void Write(Utf8JsonWriter writer, Gender value, JsonSerializerOptions options)
        {
            string genderStr = value.ToString().ToLower();
            writer.WriteStringValue(genderStr);
        }
    }
}
