namespace UniFiApiProtectWebhookDotnet.Abstraction
{
    /// <summary>
    /// Wrapper for the condition for the alarm
    /// </summary>
    public interface IConditionWrapper
    {
        /// <summary>
        /// List of the conditions
        /// </summary>
        ICondition Condition { get; set; }
    }
}
