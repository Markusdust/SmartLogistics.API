namespace SmartLogistics.API.DataModels
{
    public class Lagerplatz
    {
        public Guid Id { get; set; }
        public string Beschreibung { get; set; }
        public Guid ProduktId { get; set; }
        public int Menge { get; set; }
    }
}
