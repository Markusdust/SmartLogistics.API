using SmartLogistics.API.DataModels;

namespace SmartLogistics.API.DomainModels
{
    public class KundeDto
    {
        public Guid Id { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public DateTime Geburtsdatum { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public Guid GeschlechtId { get; set; }

        public GeschlechtDto Geschlecht { get; set; }
        public AdresseDto Adresse { get; set; }
    }
}
