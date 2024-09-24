using System;
using UniFiApiProtectWebhookDotnet.Abstraction;

namespace UniFiApiProtectWebhookDotnet.Models.Dto
{
    internal class AlarmEvent : IAlarmEvent
    {
        public Guid AlarmId { get; set; }
        public IAlarm Alarm { get; set; } = new Alarm();
        public DateTime? Timestamp { get; set; }
    }
}
