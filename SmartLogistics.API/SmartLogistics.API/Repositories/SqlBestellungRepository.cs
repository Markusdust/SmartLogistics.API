using Microsoft.EntityFrameworkCore;
using SmartLogistics.API.DataModels;

namespace SmartLogistics.API.Repositories
{
    public class SqlBestellungRepository : IBestellungRepository
    {
        private readonly SmartLogisticsContext context;

        public SqlBestellungRepository(SmartLogisticsContext context)
        {
            this.context = context;
        }

        public async Task<List<Bestellung>> GetBestellungenAsync()
        {
            return await context.Bestellungen.Include(nameof(Geschlecht)).Include(nameof(Adresse)).ToListAsync();
        }

        public async Task<Bestellung> GetBestellungAsync(Guid bestellungId)
        {
            throw new NotImplementedException();
        }
        public async Task<bool> Exists(Guid bestellungId)
        {
            throw new NotImplementedException();
        }

        public async Task<Bestellung> UpdateBestellung(Guid kundenId, Bestellung request)
        {
            throw new NotImplementedException();
        }

        public async Task<Bestellung> DeleteBestellung(Guid bestellungId)
        {
            throw new NotImplementedException();
        }

        public async Task<Bestellung> AddBestellung(Bestellung request)
        {
            throw new NotImplementedException();
        }
    }
}

