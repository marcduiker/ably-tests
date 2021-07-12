using Bogus;

namespace Ably.Demo
{
    public class DeviceEventFaker : Faker<DeviceEvent>
    {
        public DeviceEventFaker()
        {
            RuleFor(device => device.Id, faker => faker.Random.Guid().ToString());
            RuleFor(device => device.Status, faker => faker.PickRandom<DeviceStatus>());
            RuleFor(device => device.Latitude, faker => faker.Address.Latitude());
            RuleFor(device => device.Longitude, faker => faker.Address.Longitude());
        }
    }
}