namespace SmartLogistics.API.DomainModels
{
    public class AddKundeRequest
    {
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public string Geburtsdatum { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public Guid GeschlechtId { get; set; }

        public string Strasse { get; set; }
        public string Hausnummer { get; set; }

        public string Ortschaft { get; set; }
        public int Postleitzahl { get; set; }

        //public Guid OrtId { get; set; }
    }
}
