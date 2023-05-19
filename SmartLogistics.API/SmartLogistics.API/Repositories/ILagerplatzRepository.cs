using SmartLogistics.API.DataModels;

namespace SmartLogistics.API.Repositories
{
    public interface ILagerplatzRepository
    {
        Task<List<Lagerplatz>> GetAllLagerplatzAsync();

        Task<Lagerplatz> GetLagerplatzAsync(Guid lagerplatzId);

        Task<bool> Exists(Guid lagerplatzId);

        Task<Lagerplatz> UpdateLagerplatz(Guid lagerplatzId, Lagerplatz request);

        Task<Lagerplatz> DeleteLagerplatz(Guid lagerplatzId);
        Task<Lagerplatz> AddLagerplatz(Lagerplatz request);
    }
}
