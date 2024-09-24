namespace UniFiApiProtectWebhookDotnet.Abstraction
{
    /// <summary>
    /// Structure of the trigger
    /// </summary>
    public interface ITrigger
    {
        /// <summary>
        /// Key of the trigger (e.g. motion, person)
        /// </summary>
        string Key { get; set; }

        /// <summary>
        /// Device which triggered the alarm
        /// </summary>
        string Device { get; set; }
    }
}