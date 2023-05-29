namespace SmartLogistics.API.DataModels
{
    public class Kunde
    {
        public Guid Id { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set;}
        public DateTime Geburtsdatum { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public Guid GeschlechtId { get; set; }

        //Navigation Properties
        public Geschlecht Geschlecht { get; set; }
        public Adresse Adresse { get; set; }

      //  public ICollection<Bestellung> Bestellungen { get; set; }

    }
}
