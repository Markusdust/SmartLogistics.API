namespace SmartLogistics.API.Repositories
{
    public interface IMqttRepository
    {
        public string Batteriestatus { get; set; }
        public string Auftragsstatus { get; set; }
        public string Positionsstatus { get; set; }
        public bool Angemeldet { get; set; }

    }
}
