using SmartLogistics.API.DataModels;

namespace SmartLogistics.API.DomainModels
{
    public class LagerverwaltungDto
    {
        public Guid Id { get; set; }
        public string Beschreibung { get; set; }
        public Guid ProduktId { get; set; }
        public int Menge { get; set; }

        //Navigation Properties
        public Produkt Produkt { get; set; }
    }
}

