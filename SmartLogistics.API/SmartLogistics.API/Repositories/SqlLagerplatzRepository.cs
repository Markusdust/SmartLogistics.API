using Microsoft.EntityFrameworkCore;
using SmartLogistics.API.DataModels;

namespace SmartLogistics.API.Repositories
{
    public class SqlLagerplatzRepository : ILagerplatzRepository
    {
        private readonly SmartLogisticsContext context;

        public SqlLagerplatzRepository(SmartLogisticsContext context)
        {
            this.context = context;
        }
        public async Task<List<Lagerplatz>> GetAllLagerplatzAsync()
        {
            return await context.Lagerplatz.ToListAsync();
        }
        public async Task<Lagerplatz> GetLagerplatzAsync(Guid lagerplatzId)
        {
            return await context.Lagerplatz.FirstOrDefaultAsync(x => x.Id == lagerplatzId);
        }
        public async Task<bool> Exists(Guid lagerplatzId)
        {
            return await context.Lagerplatz.AnyAsync(x => x.Id == lagerplatzId);
        }
        public async Task<Lagerplatz> UpdateLagerplatz(Guid lagerplatzId, Lagerplatz request)
        {
            var existingLagerplatz = await GetLagerplatzAsync(lagerplatzId);
            if (existingLagerplatz != null)
            {
                existingLagerplatz.Beschreibung = request.Beschreibung;
                existingLagerplatz.ProduktId = request.ProduktId;
                existingLagerplatz.Menge = request.Menge;

                await context.SaveChangesAsync();
                return existingLagerplatz;
            }

            return null;
        }
        public async Task<Lagerplatz> DeleteLagerplatz(Guid lagerplatzId)
        {
            var lagerpaltz = await GetLagerplatzAsync(lagerplatzId);
            if (lagerpaltz != null)
            {
                context.Lagerplatz.Remove(lagerpaltz);
                await context.SaveChangesAsync();
            }

            return null;
        }
        public async Task<Lagerplatz> AddLagerplatz(Lagerplatz request)
        {
            var newLagerplatz = await context.Lagerplatz.AddAsync(request);
            await context.SaveChangesAsync();
            return newLagerplatz.Entity;
        }

        

        

       

        

        
    }
}
