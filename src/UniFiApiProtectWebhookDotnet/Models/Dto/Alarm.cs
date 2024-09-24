using System;
using System.Collections.Generic;
using UniFiApiProtectWebhookDotnet.Abstraction;

namespace UniFiApiProtectWebhookDotnet.Models.Dto
{
    internal class Alarm : IAlarm
    {
        public string Name { get; set; } = string.Empty;
        public IEnumerable<ISource> Sources { get; set; } = Array.Empty<ISource>();
        public IEnumerable<IConditionWrapper> Conditions { get; set; } = Array.Empty<IConditionWrapper>();
        public IEnumerable<ITrigger> Triggers { get; set; } = Array.Empty<ITrigger>();
    }
}
