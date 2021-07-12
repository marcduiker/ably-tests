using Ably.Demo;
using IO.Ably;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Startup))]
namespace Ably.Demo
{

    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddSingleton<IRealtimeClient>(
                new AblyRealtime(System.Environment.GetEnvironmentVariable("AblyRealTime_ApiKey")));
        }
    }
}