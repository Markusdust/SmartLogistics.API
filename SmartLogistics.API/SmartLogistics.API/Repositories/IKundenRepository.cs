using SmartLogistics.API.DataModels;

namespace SmartLogistics.API.Repositories
{
    public interface IKundenRepository
    {
        Task<List<Kunde>> GetKundenAsync();

        Task<Kunde> GetKundeAsync(Guid kundeId);
    }
}
