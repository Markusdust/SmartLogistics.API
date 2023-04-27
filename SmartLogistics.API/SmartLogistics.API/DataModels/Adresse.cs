namespace SmartLogistics.API.DataModels
{
    public class Adresse
    {
        public Guid Id { get; set; }
        public string Strasse { get; set; }
        public string Hausnummer { get; set; }
        //public Guid OrtId { get; set; }

        //navigaiton Property
        public Ort Ort{ get; set; } 
        public Guid KundeId { get; set; }
    }
}
