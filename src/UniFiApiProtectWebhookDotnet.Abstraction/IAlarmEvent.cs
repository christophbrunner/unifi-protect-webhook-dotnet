using System;

namespace UniFiApiProtectWebhookDotnet.Abstraction
{
    /// <summary>
    /// Alarm event
    /// </summary>
    public interface IAlarmEvent
    {
        /// <summary>
        /// Id of the alarm (not part of the payload)
        /// </summary>
        Guid AlarmId { get; set; }

        /// <summary>
        /// Alarm details
        /// </summary>
        IAlarm Alarm { get; set; }

        /// <summary>
        /// Date of the alarm
        /// </summary>
        DateTime? Timestamp { get; set; }
    }
}