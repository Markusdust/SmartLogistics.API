namespace SmartLogistics.API.DomainModels.UpdateDomainModels
{
    public class UpdateLagerverwaltungRequest
    {
        public string Beschreibung { get; set; }
        public Guid ProduktId { get; set; }
        public int Menge { get; set; }
    }
}
