using Microsoft.EntityFrameworkCore;
using SmartLogistics.API.DataModels;

namespace SmartLogistics.API.Repositories
{
    public class SqlLagerverwaltungRepository : ILagerverwaltungRepository
    {
        private readonly SmartLogisticsContext context;

        public SqlLagerverwaltungRepository(SmartLogisticsContext context)
        {
            this.context = context;
        }
        public async Task<List<Lagerverwaltung>> GetAllLagerverwaltungAsync()
        {
            return await context.Lagerverwaltung.Include(nameof(Produkt)).ToListAsync();
        }
        public async Task<Lagerverwaltung> GetLagerverwaltungAsync(Guid lagerverwaltungId)
        {
            return await context.Lagerverwaltung.Include(nameof(Produkt)).FirstOrDefaultAsync(x => x.Id == lagerverwaltungId);
        }
        public async Task<bool> Exists(Guid lagerverwaltungId)
        {
            return await context.Lagerverwaltung.AnyAsync(x => x.Id == lagerverwaltungId);
        }
        public async Task<Lagerverwaltung> UpdateLaberverwaltung(Guid lagerverwaltungId, Lagerverwaltung request)
        {
            var existingLagerverwaltung = await GetLagerverwaltungAsync(lagerverwaltungId);
            if (existingLagerverwaltung != null)
            {
                existingLagerverwaltung.Beschreibung = request.Beschreibung;
                existingLagerverwaltung.ProduktId = request.ProduktId;
                existingLagerverwaltung.Menge = request.Menge;

                await context.SaveChangesAsync();
                return existingLagerverwaltung;
            }

            return null;
        }
        public async Task<Lagerverwaltung> DeleteLagerverwaltung(Guid lagerverwaltungId)
        {
            var lagerverwaltung = await GetLagerverwaltungAsync(lagerverwaltungId);
            if (lagerverwaltung != null)
            {
                context.Lagerverwaltung.Remove(lagerverwaltung);
                await context.SaveChangesAsync();
            }

            return null;
        }
        public async Task<Lagerverwaltung> AddLagerverwaltung(Lagerverwaltung request)
        {
            var newLagerverwaltung = await context.Lagerverwaltung.AddAsync(request);
            await context.SaveChangesAsync();
            return newLagerverwaltung.Entity;
        }

        

        

       

        

        
    }
}
