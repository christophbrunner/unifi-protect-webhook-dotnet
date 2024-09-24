using UniFiApiProtectWebhookDotnet.Abstraction;

namespace UniFiApiProtectWebhookDotnet.Models.Dto
{
    internal class Trigger : ITrigger
    {
        public string Key { get; set; } = string.Empty;
        public string Device { get; set; } = string.Empty;
    }
}