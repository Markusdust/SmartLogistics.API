using SmartLogistics.API.DataModels;

namespace SmartLogistics.API.DomainModels
{
    public class AdresseDto
    {
        public Guid Id { get; set; }
        public string Strasse { get; set; }
        public string Hausnummer { get; set; }
        //public Guid OrtId { get; set; }


        public Ort Ort { get; set; }
        public Guid KundeId { get; set; }
    }
}
