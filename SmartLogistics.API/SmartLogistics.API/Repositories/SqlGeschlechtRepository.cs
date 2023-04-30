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

        public async Task<List<Geschlecht>> GetGeschlechterAsync()
        {
            return await context.Geschlechter.ToListAsync();
        }

        public async Task<Geschlecht> GetGeschlechtAsync(Guid geschlechtId)
        {
            return await context.Geschlechter.FirstOrDefaultAsync(x => x.Id == geschlechtId);
        }
        public async Task<bool> Exists(Guid geschlechtId)
        {
            return await context.Geschlechter.AnyAsync(x => x.Id == geschlechtId);
        }

        public async Task<Geschlecht> UpdateGeschlecht(Guid geschlechtId, Geschlecht request)
        {
            var existingGeschlecht = await GetGeschlechtAsync(geschlechtId);
            if (existingGeschlecht != null)
            {
                existingGeschlecht.Beschreibung = request.Beschreibung;

                await context.SaveChangesAsync();
                return existingGeschlecht;
            }

            return null;
        }

        public async Task<Geschlecht> DeletGeschlecht(Guid geschlechtId)
        {
            var geschlecht = await GetGeschlechtAsync(geschlechtId);
            if (geschlecht != null)
            {
                context.Geschlechter.Remove(geschlecht);
                await context.SaveChangesAsync();
            }

            return null;
        }

        public async Task<Geschlecht> AddGeschlecht(Geschlecht request)
        {
            var newGeschlecht = await context.Geschlechter.AddAsync(request);
            await context.SaveChangesAsync();
            return newGeschlecht.Entity;
        }
    }
}
