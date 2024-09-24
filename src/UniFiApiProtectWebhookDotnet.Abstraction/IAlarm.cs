using System.Collections.Generic;

namespace UniFiApiProtectWebhookDotnet.Abstraction
{
    /// <summary>
    /// Data structure of the alarm (with Id)
    /// </summary>
    public interface IAlarm
    {
        /// <summary>
        /// Name of the alarm definition (e.g. Motion, Admin Recording Clips Manipulations)
        /// </summary>
        string Name {get; set; }

        /// <summary>
        /// List of the Sources of the alarm definition
        /// </summary>
        IEnumerable<ISource> Sources { get; set; }

        /// <summary>
        /// List of the conditions for the alarm definition
        /// </summary>
        IEnumerable<IConditionWrapper> Conditions { get; set; }

        /// <summary>
        /// Triggers of the alarm
        /// </summary>
        IEnumerable<ITrigger> Triggers { get; set; }
    }
}