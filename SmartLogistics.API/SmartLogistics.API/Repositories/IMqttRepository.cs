using SmartLogistics.API.DataModels;

namespace SmartLogistics.API.Repositories
{
    public interface IMqttRepository
    {
        public string BatteryLevel { get; set; }
    }
}
