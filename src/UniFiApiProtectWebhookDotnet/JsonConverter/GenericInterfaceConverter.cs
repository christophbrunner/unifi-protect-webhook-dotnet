using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace UniFiApiProtectWebhookDotnet.JsonConverter
{
    internal class GenericInterfaceConverter<TInterface, TInstance> : JsonConverter<TInterface>
        where TInstance : TInterface, new() where TInterface : class
    {

        public override TInterface? Read(ref Utf8JsonReader reader, Type typeToConvert,
            JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.StartObject)
            {

                return JsonSerializer.Deserialize<TInstance>(ref reader, options);
            }

            return new TInstance();
        }

        public override void Write(Utf8JsonWriter writer, TInterface value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}