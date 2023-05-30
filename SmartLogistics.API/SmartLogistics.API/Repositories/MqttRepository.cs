namespace SmartLogistics.API.Repositories
{
    public class MqttRepository : IMqttRepository
    {
        public string BatteryLevel { get; set; }
        public string Bestellungsablauf { get; set; }
    }
}
