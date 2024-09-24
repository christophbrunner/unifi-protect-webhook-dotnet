UniFi Protect Webhook helper
============================

A .NET (netstandard) helper library which parses the POST calls of UniFi Protect Webkooks.

UniFi Protect custom webhooks make it easy to connect UniFi Protect with other web services. They allow you to automatically respond to alerts, improve monitoring, and scale effortlessly. 

How to set up the webhooks in UniFi Protect can be found [here](https://help.ui.com/hc/en-us/articles/25478744592023-Send-UniFi-Protect-Alerts-to-Web-Services-using-Webhooks).

This library supports only the POST calls of the UniFi Protect Webhooks. It parses the JSON payload and provides a simple object model to work with.

[![NuGet](https://img.shields.io/nuget/v/UniFiApiProtectWebhookDotnet.svg)](https://www.nuget.org/packages/UniFiApiProtectWebhookDotnet/)

[![Continuous Integration (CI)](https://github.com/christophbrunner/unifi-protect-webhook-dotnet/actions/workflows/ci.yml/badge.svg)](https://github.com/christophbrunner/unifi-protect-webhook-dotnet/actions/workflows/ci.yml)

Usage
-----

Example with a MinimalApi:
```csharp
app.MapPost("/PostSample", async context =>
{
    IAlarmEvent? alarm = await context.Request.GetUniFiProtectAlarmData();
           
    if (alarm != null)
    {
        //HandleAlarm(alarm);
    }
});
```

Example with Controller:
```csharp
[ApiController]
[Route("[controller]")]
public class UniFiWebhookController : ControllerBase
{
    [HttpPost]
    public async void Post()
    {
        IAlarmEvent? alarmEvent = await HttpContext.Request.GetUniFiProtectAlarmData();

        if (alarmEvent != null)
        {
            //HandleAlarm(alarm);
        }
    }
}
```

Logging (optional)
------------------
The helper uses the [Microsoft.Extensions.Logging](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging) framework for logging.