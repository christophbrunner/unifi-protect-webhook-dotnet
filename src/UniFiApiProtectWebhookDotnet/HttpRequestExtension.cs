using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using UniFiApiProtectWebhookDotnet.Abstraction;

namespace UniFiApiProtectWebhookDotnet
{
    public static class HttpRequestExtension
    {
        /// <summary>
        /// Extract the UniFi protect alarm data from the request.
        /// Returns null if no data available, or an error occurred.
        /// </summary>
        /// <param name="request">HttpRequest</param>
        /// <param name="onError">Action delegate which is called if an error occurs during extraction. (optional)</param>
        /// <param name="logger">Logger (optional)</param>
        /// <returns>AlarmEvent or NULL</returns>
        public static async Task<IAlarmEvent?> GetUniFiProtectAlarmData(this HttpRequest request,
            Action<Exception>? onError = null, ILogger? logger = null)
        {
            try
            {
                CheckHttpMethode(request);

                using StreamReader reader = new StreamReader(request.Body);

                string body = await reader.ReadToEndAsync();

                IAlarmEvent result = UniFiProtectAlarmDataParser.GetUniFiProtectAlarmData(body);

                ExtractAlarmId(result, request);

                return result;
            }
            catch (Exception ex)
            {
                logger?.LogError(ex, "Error on {Methode}", nameof(GetUniFiProtectAlarmData));
                onError?.Invoke(ex);
            }

            return null;
        }

        private static void CheckHttpMethode(HttpRequest request)
        {
            if (request.Method != "POST")
            {
                throw new Exception($"{request.Method} is not supported. Only POST supported");
            }
        }

        private static void ExtractAlarmId(IAlarmEvent result, HttpRequest request)
        {
            if (request.Headers.ContainsKey("POST"))
            {
                string? alarmId = request.Headers["POST"].FirstOrDefault();

                if (Guid.TryParse(alarmId, out var alarmGuid))
                {
                    result.AlarmId = alarmGuid;
                }
            }
        }
    }
}