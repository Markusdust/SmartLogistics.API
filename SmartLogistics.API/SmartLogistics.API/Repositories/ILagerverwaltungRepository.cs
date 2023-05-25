using SmartLogistics.API.DataModels;

namespace SmartLogistics.API.Repositories
{
    public interface ILagerverwaltungRepository
    {
        Task<List<Lagerverwaltung>> GetAllLagerverwaltungAsync();

        Task<Lagerverwaltung> GetLagerverwaltungAsync(Guid lagerverwaltungId);

        Task<bool> Exists(Guid lagerverwaltungId);

        Task<Lagerverwaltung> UpdateLaberverwaltung(Guid lagerverwaltungId, Lagerverwaltung request);

        Task<Lagerverwaltung> DeleteLagerverwaltung(Guid lagerverwaltungId);
        Task<Lagerverwaltung> AddLagerverwaltung(Lagerverwaltung request);
    }
}
