namespace SmartLogistics.API.DomainModels
{
    public class BestellungDto
    {
        public Guid Id { get; set; }
        public DateTime Erfassdatum { get; set; }
        public DateTime LieferungStart { get; set; }
        public DateTime LieferungEnde { get; set; }
        public Guid KundenId { get; set; }
    }
}
