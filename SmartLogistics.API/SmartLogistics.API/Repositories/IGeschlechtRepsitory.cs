using SmartLogistics.API.DataModels;

namespace SmartLogistics.API.Repositories
{
    public interface  IGeschlechtRepsitory
    {
        Task<List<Geschlecht>> GetGeschlechterAsync();
        Task<Geschlecht> GetGeschlechtAsync(Guid geschlechtId);
        Task<Geschlecht> AddGeschlecht(Geschlecht request);
    }
}
