using System;
using UniFiApiProtectWebhookDotnet.Abstraction;

namespace Sample.Calls
{
    public static class AlarmEventExtension
    {
        public static void WriteToConsole(this IAlarmEvent alarmEvent)
        {
            Console.WriteLine("========================================");

            Console.WriteLine($"Id: {alarmEvent.AlarmId}");
            Console.WriteLine($"Alarm: {alarmEvent.Alarm.Name}");
            Console.WriteLine($"{alarmEvent.Timestamp:F}");

            Console.WriteLine("Sources:");
            foreach (var source in alarmEvent.Alarm.Sources)
            {
                Console.WriteLine($" {source.Type} {source.Device}");
            }

            Console.WriteLine("Conditions:");
            foreach (var conditions in alarmEvent.Alarm.Conditions)
            {
                Console.WriteLine($" {conditions.Condition.Type} {conditions.Condition.Source}");
            }

            Console.WriteLine("Conditions:");
            foreach (var trigger in alarmEvent.Alarm.Triggers)
            {
                Console.WriteLine($" {trigger.Device} >  {trigger.Key}");
            }
        }
    }
}
