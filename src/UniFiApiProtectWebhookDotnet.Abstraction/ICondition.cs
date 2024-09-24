namespace UniFiApiProtectWebhookDotnet.Abstraction
{
    /// <summary>
    /// Condition definition for alarms
    /// </summary>
    public interface ICondition
    {
        /// <summary>
        /// Type of the condition (e.g. is)
        /// </summary>
        ConditionType Type { get; set; }

        /// <summary>
        /// Source of the condition (e.g. motion, vehicle)
        /// </summary>
        string Source { get; set; }
    }
}