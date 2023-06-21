using SmartLogistics.API.DataModels;

namespace SmartLogistics.API.Repositories
{
    public interface IMqttRepository
    {
        public string RoboterId { get; set; }
        public string Batteriestatus { get; set; }
        public string AuftragsId { get; set; }
        public string Auftragsstatus { get; set; }
        public string Positionsstatus { get; set; }
        public string Angemeldet { get; set; }

        Task<Bestellung> GetBestellungAsync(Guid bestellungId);
        Task<Bestellung> ChangeLieferstatusTest(Guid bestellungId, string auftragsStatus);

    }
}
