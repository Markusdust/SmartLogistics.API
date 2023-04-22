using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using SmartLogistics.API.DataModels;
using SmartLogistics.API.DomainModels;

namespace SmartLogistics.API.Repositories
{
    public interface IKundenRepository
    {
        Task<List<Kunde>> GetKundenAsync();

        Task<Kunde> GetKundeAsync(Guid kundeId);

        Task<List<Geschlecht>> GetGeschlechterAsync();

        Task<bool>Exists(Guid kundenId);

        Task<Kunde> UpdateKunde(Guid kundenId, Kunde request);
    }
}
