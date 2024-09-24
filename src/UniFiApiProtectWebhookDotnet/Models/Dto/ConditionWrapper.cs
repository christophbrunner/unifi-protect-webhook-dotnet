using UniFiApiProtectWebhookDotnet.Abstraction;

namespace UniFiApiProtectWebhookDotnet.Models.Dto
{
    internal class ConditionWrapper : IConditionWrapper
    {
        public ICondition Condition { get; set; } = new Condition();
    }
}