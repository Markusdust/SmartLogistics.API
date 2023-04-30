using Microsoft.EntityFrameworkCore;
using SmartLogistics.API.DataModels;

namespace SmartLogistics.API.Repositories
{
    public class SqlProduktRepository : IProdukteRepository
    {
        private readonly SmartLogisticsContext context;

        public SqlProduktRepository(SmartLogisticsContext context)
        {
            this.context = context;
        }

        public async Task<List<Produkt>> GetProdukteAsync()
        {
            return await context.Produkte.ToListAsync();
        }
        public async Task<Produkt> GetProduktAsync(Guid produktId)
        {
            return await context.Produkte.FirstOrDefaultAsync(x => x.Id == produktId);
        }

        public async Task<bool> Exists(Guid produktId)
        {
            return await context.Produkte.AnyAsync(x => x.Id == produktId);
        }
        public async Task<Produkt> UpdateProdukte(Guid produktId, Produkt request)
        {
            var existingProdukt = await GetProduktAsync(produktId);
            if (existingProdukt != null)
            {
                existingProdukt.Name = request.Name;

                await context.SaveChangesAsync();
                return existingProdukt;
            }

            return null;
        }
        public async Task<Produkt> DeleteProdukt(Guid produktId)
        {
            var produkt = await GetProduktAsync(produktId);
            if (produkt != null)
            {
                context.Produkte.Remove(produkt);
                await context.SaveChangesAsync();
            }

            return null;
        }
        public async Task<Produkt> AddProdukt(Produkt request)
        {
            var newProdukt = await context.Produkte.AddAsync(request);
            await context.SaveChangesAsync();
            return newProdukt.Entity;
        }
    }
}
