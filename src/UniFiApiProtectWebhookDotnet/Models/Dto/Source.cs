using UniFiApiProtectWebhookDotnet.Abstraction;

namespace UniFiApiProtectWebhookDotnet.Models.Dto
{
    internal class Source : ISource
    {
        public SourceType Type { get; set; } = SourceType.Unknown;
        public string Device { get; set; } = string.Empty;
    }
}