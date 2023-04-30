using SmartLogistics.API.DataModels;

namespace SmartLogistics.API.Repositories
{
    public interface IProdukteRepository
    {
        Task<List<Produkt>> GetProdukteAsync();

        Task<Produkt> GetProduktAsync(Guid produktId);

        Task<bool> Exists(Guid produktId);

        Task<Produkt> UpdateProdukte(Guid produktId, Produkt request);

        Task<Produkt> DeleteProdukt(Guid produktId);
        Task<Produkt> AddProdukt(Produkt request);
    }
}
