using System;
using System.Text.Json;
using UniFiApiProtectWebhookDotnet.Abstraction;
using UniFiApiProtectWebhookDotnet.JsonConverter;
using UniFiApiProtectWebhookDotnet.Models.Dto;

namespace UniFiApiProtectWebhookDotnet
{
    public static class UniFiProtectAlarmDataParser
    {
        /// <summary>
        /// Extract the UniFi protect alarm data from the json string.
        /// Throws an exception if no data available, or an error occurred.
        /// </summary>
        /// <param name="json"></param>
        /// <returns>AlarmEvent</returns>
        public static IAlarmEvent GetUniFiProtectAlarmData(string json)
        {
            IAlarmEvent? result = JsonSerializer.Deserialize<AlarmEvent>(json, new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true,
                Converters =
                {
                    new NullableDateTimeConverter(),
                    new GenericInterfaceConverter<IAlarm, Alarm>(),
                    new GenericInterfaceConverter<ICondition, Condition>(),
                    new GenericInterfaceConverter<IConditionWrapper, ConditionWrapper>(),
                    new GenericInterfaceConverter<ISource, Source>(),
                    new GenericInterfaceConverter<ITrigger, Trigger>(),
                    new GenericEnumConverter<SourceType>(),
                    new GenericEnumConverter<ConditionType>()
                }
            });

            if (result == null)
            {
                throw new Exception("No data available");
            }

            return result;
        }
    }
}