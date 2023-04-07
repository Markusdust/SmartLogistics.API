namespace SmartLogistics.API
{
    public class Lieferung
    {
        public Guid Id { get; set; }
        public string Status { get; set; }
        public string Priorität { get; set; }
        public string Lieferart { get; set; } 
        public Guid BestellId { get; set; }
    }
}
