namespace UniFiApiProtectWebhookDotnet.Abstraction
{
    /// <summary>
    /// Type of condition definition for alarms
    /// </summary>
    public enum ConditionType
    {
        /// <summary>
        /// Unknown condition type
        /// </summary>
        Unknown,

        /// <summary>
        /// Is
        /// </summary>
        Is,

        /// <summary>
        /// IsNot (currently never used)
        /// </summary>
        IsNot
    }
}