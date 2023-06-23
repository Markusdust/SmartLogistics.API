namespace SmartLogistics.API.DataModels
{
    public class Roboter
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Batterie { get; set; }
        public string PositionsStatus { get; set; }
        public string AuftragsId { get; set; }
    }
}
