using System;
using System.Text.Json.Serialization;

namespace Ably.Demo
{
    public class DeviceEvent
    {
        public string Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public DeviceStatus Status { get; set; }
    }

    public enum DeviceStatus
    {
        Off = 0,
        On = 1,
        StandBy = 2
    }
}