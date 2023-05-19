namespace SmartLogistics.API.DomainModels
{
    public class LagerplatzDto
    {
        public Guid Id { get; set; }
        public string Beschreibung { get; set; }
        public Guid ProduktId { get; set; }
        public int Menge { get; set; }
    }
}
