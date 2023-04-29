using Microsoft.EntityFrameworkCore;
using SmartLogistics.API.DataModels;
using System.Reflection.Metadata;

namespace SmartLogistics.API.Repositories
{
    public class SqlGeschlechtRepository : IGeschlechtRepsitory
    {
        private readonly SmartLogisticsContext context;

        public SqlGeschlechtRepository(SmartLogisticsContext context)
        {
            this.context = context;
        }

        public Task<Geschlecht> AddGeschlecht(Geschlecht request)
        {
            throw new NotImplementedException();
        }

        public async Task<Geschlecht> GetGeschlechtAsync(Guid geschlechtId)
        {
            return await context.Geschlechter.FirstOrDefaultAsync(x => x.Id == geschlechtId);
        }

        public async Task<List<Geschlecht>> GetGeschlechterAsync()
        {
            return await context.Geschlechter.ToListAsync();
        }
    }
}
