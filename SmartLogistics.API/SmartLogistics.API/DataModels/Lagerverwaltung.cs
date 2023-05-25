namespace SmartLogistics.API.DataModels
{
    public class Lagerverwaltung
    {
        public Guid Id { get; set; }
        public string Beschreibung { get; set; }
        public Guid ProduktId { get; set; }
        public int Menge { get; set; }

        //Navigation Properties
        public Produkt Produkt { get; set; }
    }
}
