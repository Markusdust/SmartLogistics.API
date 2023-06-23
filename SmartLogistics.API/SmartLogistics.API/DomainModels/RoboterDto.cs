namespace SmartLogistics.API.DomainModels
{
    public class RoboterDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Batterie { get; set; }
        public string PositionsStatus { get; set; }
        public string AuftragsId { get; set; }
    }
}
