using System;
using System.Threading.Tasks;
using Bogus;
using IO.Ably;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace Ably.Demo
{
    public class TimerTriggerEventPublisher
    {
        private readonly IRealtimeClient _realtimeClient;

        public TimerTriggerEventPublisher(IRealtimeClient realtimeClient)
        {
            _realtimeClient = realtimeClient;
        }

        [FunctionName(nameof(TimerTriggerEventPublisher))]
        public async Task Run([TimerTrigger("0 */1 * * * *")] TimerInfo myTimer, ILogger log)
        {
            var deviceEventFaker = new DeviceEventFaker();
            var deviceEvent = deviceEventFaker.Generate();

            var channelName = Environment.GetEnvironmentVariable("AblyRealTime_ChannelPublish");
            var channel = _realtimeClient.Channels.Get(channelName);

            var result = await channel.PublishAsync("deviceEvent", deviceEvent);
            if (result.IsFailure)
            {
                throw new Exception(result.Error.Message, result.Error.InnerException);
            }
        }
    }
}
