using UniFiApiProtectWebhookDotnet.Abstraction;

namespace UniFiApiProtectWebhookDotnet.Models.Dto
{
    internal class Condition : ICondition
    {
        public ConditionType Type { get; set; } = ConditionType.Unknown;
        public string Source { get; set; } = string.Empty;
    }
}