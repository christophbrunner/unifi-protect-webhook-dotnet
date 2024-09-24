using System;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;

[assembly: InternalsVisibleTo("UniFiApiProtectWebhookDotnet.Tests")]

namespace UniFiApiProtectWebhookDotnet.JsonConverter
{
    internal class NullableDateTimeConverter : JsonConverter<DateTime?>
    {
        public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                string? dateString = reader.GetString();
                if (string.IsNullOrEmpty(dateString))
                {
                    return null;
                }

                if (DateTime.TryParse(dateString, out DateTime dateValue))
                {
                    return dateValue.ToLocalTime();
                }

                return null;
            }

            if (reader.TokenType == JsonTokenType.Number)
            {
                long unixTimeStamp = reader.GetInt64();
                DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                dateTime = dateTime.AddMilliseconds(unixTimeStamp).ToLocalTime();
                return dateTime;
            }

            return reader.GetDateTime();
        }

        public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}