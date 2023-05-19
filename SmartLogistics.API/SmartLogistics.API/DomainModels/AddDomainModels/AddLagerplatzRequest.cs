namespace SmartLogistics.API.DomainModels.AddDomainModels
{
    public class AddLagerplatzRequest
    {
        public string Beschreibung { get; set; }
        public Guid ProduktId { get; set; }
        public int Menge { get; set; }
    }
}
