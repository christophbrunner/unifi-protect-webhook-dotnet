namespace UniFiApiProtectWebhookDotnet.Abstraction
{
    /// <summary>
    /// Source definition for alarms
    /// </summary>
    public interface ISource
    {
        /// <summary>
        /// Type of the source (e.g. exclude)
        /// </summary>
        SourceType Type { get; set; }

        /// <summary>
        /// Device from which the source is
        /// </summary>
        string Device { get; set; }
    }
}