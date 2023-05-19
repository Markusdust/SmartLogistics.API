using SmartLogistics.API.DataModels;

namespace SmartLogistics.API.Repositories
{
    public interface IMqttRepository
    {
        public string GetBatteryAsync();
    }
}
