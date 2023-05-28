namespace SmartLogistics.API.DataModels
{
    public class Bestellung
    {
        public Guid Id { get; set; }
        public Guid ProduktId { get; set; }
        public DateTime Erfassdatum { get; set; }
        public DateTime LieferungStart { get; set; }
        public DateTime LieferungEnde { get; set; }
        public Guid KundenId { get; set; }
        public string Priorität { get; set; }
        public string Lieferart { get; set; }
        public string Status { get; set; }
    }
}
