using System.Runtime.CompilerServices;
using System.Text.Json;
using UniFiApiProtectWebhookDotnet.JsonConverter;

[assembly: InternalsVisibleTo("UniFiApiDotnet")]

namespace UniFiApiProtectWebhookDotnet.Tests
{
    public class NullableDateTimeConverterTests
    {
        private readonly NullableDateTimeConverter _converter = new();

        [Fact]
        public void Read_WithValidDateTimeString_ReturnsCorrectDateTime()
        {
            // Arrange
            string json = "\"2023-09-13T10:15:30\"";
            Utf8JsonReader reader = new Utf8JsonReader(System.Text.Encoding.UTF8.GetBytes(json));
            reader.Read(); // Move to the first token

            // Act
            DateTime? result = _converter.Read(ref reader, typeof(DateTime), new JsonSerializerOptions());

            // Assert
            Assert.NotNull(result);
            Assert.Equal(DateTime.Parse("2023-09-13T10:15:30").ToLocalTime(), result.Value);
        }

        [Fact]
        public void Read_WithEmptyString_ReturnsNull()
        {
            // Arrange
            string json = "\"\"";
            Utf8JsonReader reader = new Utf8JsonReader(System.Text.Encoding.UTF8.GetBytes(json));
            reader.Read(); // Move to the first token

            // Act
            DateTime? result = _converter.Read(ref reader, typeof(DateTime), new JsonSerializerOptions());

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void Read_WithInvalidString_ReturnsNull()
        {
            // Arrange
            string json = "\"Invalid Date\"";
            Utf8JsonReader reader = new Utf8JsonReader(System.Text.Encoding.UTF8.GetBytes(json));
            reader.Read(); // Move to the first token

            // Act
            DateTime? result = _converter.Read(ref reader, typeof(DateTime), new JsonSerializerOptions());

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void Read_WithUnixTimeNumber_ReturnsCorrectDateTime()
        {
            // Arrange
            long unixTime = 169459173; // Equivalent to 2023-09-13T10:15:30Z
            string json = unixTime.ToString();
            Utf8JsonReader reader = new Utf8JsonReader(System.Text.Encoding.UTF8.GetBytes(json));
            reader.Read(); // Move to the first token

            // Act
            DateTime? result = _converter.Read(ref reader, typeof(DateTime), new JsonSerializerOptions());

            // Assert
            Assert.NotNull(result);
            Assert.Equal(DateTimeOffset.FromUnixTimeMilliseconds(unixTime).ToLocalTime().DateTime, result.Value);
        }

        [Fact]
        public void Read_WithDateTimeToken_ReturnsCorrectDateTime()
        {
            // Arrange
            string json = "\"2023-09-13T10:15:30Z\"";
            Utf8JsonReader reader = new Utf8JsonReader(System.Text.Encoding.UTF8.GetBytes(json));
            reader.Read(); // Move to the first token

            // Act
            DateTime? result = _converter.Read(ref reader, typeof(DateTime), new JsonSerializerOptions());

            // Assert
            Assert.NotNull(result);
            Assert.Equal(DateTime.Parse("2023-09-13T10:15:30Z").ToLocalTime(), result.Value);
        }

        [Fact]
        public void Read_WithNonDateStringToken_ReturnsNull()
        {
            // Arrange
            string json = "\"not a date\"";
            Utf8JsonReader reader = new Utf8JsonReader(System.Text.Encoding.UTF8.GetBytes(json));
            reader.Read(); // Move to the first token

            // Act
            DateTime? result = _converter.Read(ref reader, typeof(DateTime), new JsonSerializerOptions());

            // Assert
            Assert.Null(result);
        }
    }
}