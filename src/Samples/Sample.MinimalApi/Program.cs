using Sample.Calls;
using UniFiApiProtectWebhookDotnet;
using UniFiApiProtectWebhookDotnet.Abstraction;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseHttpsRedirection();

app.MapPost("/PostSample", async context =>
{
    try
    {
        IAlarmEvent? alarm = await context.Request.GetUniFiProtectAlarmData();
            
        // handle exceptions inside the extraction
        //var alarm = await context.Request.GetUniFiProtectAlarmData((Exception ex) =>
        //{
        //    Console.WriteLine(ex);
        //});


        if (alarm != null)
        {
            alarm.WriteToConsole();
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
});

app.MapGet("/", context =>
{
    context.Response.Redirect("https://github.com/christophbrunner/unifi-protect-webhook-dotnet");
    return Task.CompletedTask;
});

app.Run();