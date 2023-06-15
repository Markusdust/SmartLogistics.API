namespace SmartLogistics.API.Repositories
{
    public class MqttRepository : IMqttRepository
    {
        public string RoboterId { get; set; }
        public string Batteriestatus { get; set; }
        public string AuftragsId { get; set; }
        public string Auftragsstatus { get; set; }
        public string Positionsstatus { get; set; }
        public string Angemeldet { get; set; }
    }
}
