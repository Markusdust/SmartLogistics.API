using SmartLogistics.API.DataModels;

namespace SmartLogistics.API.Repositories
{
    public interface IBestellungRepository
    {
        Task<List<Bestellung>> GetBestellungenAsync();

        Task<Bestellung> GetBestellungAsync(Guid bestellungId);

        Task<bool> Exists(Guid bestellungId);

        Task<Bestellung> UpdateBestellung(Guid kundenId, Bestellung request);

        Task<Bestellung> DeleteBestellung(Guid bestellungId);
        Task<Bestellung> AddBestellung(Bestellung request);
    }
}
