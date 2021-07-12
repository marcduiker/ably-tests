using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace Ably.Demo
{
    public class HttpTriggerEventSubscriber
    {
        [FunctionName(nameof(HttpTriggerEventSubscriber))]
        public async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Function, "POST")] HttpRequestMessage message,
            ILogger log)
        {
            var deviceEvent = await message.Content.ReadAsAsync<DeviceEvent>();
            if (deviceEvent != null)
            {
                log.LogInformation($"Received event: {deviceEvent.Id}-{deviceEvent.Status}", deviceEvent.Id, deviceEvent.Status);
            }
            else
            {
                log.LogError("Unable to get DeviceEvent data from HTTP request.");
            }

            return new HttpResponseMessage(HttpStatusCode.Accepted);
        }
    }
}
