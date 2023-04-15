using Microsoft.EntityFrameworkCore;
using SmartLogistics.API.DataModels;

namespace SmartLogistics.API.Repositories
{
    public class SqlKundenRepository : IKundenRepository
    {
        private readonly SmartLogisticsContext context;

        public SqlKundenRepository(SmartLogisticsContext context)
        {
            this.context = context;
        }



        public async Task<List<Kunde>> GetKundenAsync()
        {
            return await context.Kunden.Include(nameof(Geschlecht)).Include(nameof(Adresse)).ToListAsync();
        }
    }
}
