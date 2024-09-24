using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace UniFiApiProtectWebhookDotnet.JsonConverter
{
    internal class GenericEnumConverter<TEnum> : JsonConverter<TEnum>
        where TEnum : struct

    {
        public override TEnum Read(ref Utf8JsonReader reader, Type typeToConvert,
            JsonSerializerOptions options)
        {

            if (Enum.TryParse(reader.GetString(), true, out TEnum result))
            {
                return result;
            }

            return default;
        }

        public override void Write(Utf8JsonWriter writer, TEnum value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}