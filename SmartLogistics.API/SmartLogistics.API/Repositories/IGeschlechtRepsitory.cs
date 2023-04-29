using SmartLogistics.API.DataModels;

namespace SmartLogistics.API.Repositories
{
    public interface  IGeschlechtRepsitory
    {
        Task<List<Geschlecht>> GetGeschlechterAsync();

        Task<Geschlecht> GetGeschlechtAsync(Guid geschlechtId);

        Task<bool> Exists(Guid geschlechtId);

        Task<Geschlecht> UpdateGeschlecht(Guid geschlechtId, Geschlecht request);

        Task<Geschlecht> DeletGeschlecht(Guid geschlechtId);

        Task<Geschlecht> AddGeschlecht(Geschlecht request);
    }
}
