namespace UniFiApiProtectWebhookDotnet.Abstraction
{
    /// <summary>
    /// Type of source definition for alarms
    /// </summary>
    public enum SourceType
    {
        /// <summary>
        /// Unknown source type
        /// </summary>
        Unknown,

        /// <summary>
        /// Whitelist (included devices)
        /// </summary>
        Include,

        /// <summary>
        /// Blacklist (exclude devices)
        /// </summary>
        Exclude
    }
}