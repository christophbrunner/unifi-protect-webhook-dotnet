using Microsoft.AspNetCore.Mvc;
using Sample.Calls;
using UniFiApiProtectWebhookDotnet;
using UniFiApiProtectWebhookDotnet.Abstraction;

namespace Sample.ControllerApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UniFiWebhookController : ControllerBase
    {

        private readonly ILogger<UniFiWebhookController> _logger;

        public UniFiWebhookController(ILogger<UniFiWebhookController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async void Post()
        {
            IAlarmEvent? alarmEvent = await HttpContext.Request.GetUniFiProtectAlarmData(logger: _logger);

            if (alarmEvent != null)
            {
                alarmEvent.WriteToConsole();
            }
        }
    }
}
