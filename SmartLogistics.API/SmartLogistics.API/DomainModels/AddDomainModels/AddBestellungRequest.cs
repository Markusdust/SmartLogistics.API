namespace SmartLogistics.API.DomainModels.AddDomainModels
{
    public class AddBestellungRequest
    {
        public Guid ProduktId { get; set; }
        public DateTime Erfassdatum { get; set; }
        public DateTime LieferungStart { get; set; }
        public DateTime LieferungEnde { get; set; }
        public Guid KundeId { get; set; }
        public string Prioritaet { get; set; }
        public string Lieferart { get; set; }
        public string Status { get; set; }
    }
}
