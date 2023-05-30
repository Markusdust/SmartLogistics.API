namespace SmartLogistics.API.Repositories
{
    public interface IMqttRepository
    {
        public string BatteryLevel { get; set; }

        public string Bestellungsablauf { get; set; } 
    }
}
