using Microsoft.EntityFrameworkCore;
using SmartLogistics.API.DataModels;
using System.Net;
using System.Reflection;

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

        public async Task<Kunde> GetKundeAsync(Guid kundeId)
        {
            return await context.Kunden
                .Include(nameof(Geschlecht)).Include(nameof(Adresse))
                .FirstOrDefaultAsync(x=> x.Id ==kundeId);
        }

        public async Task<List<Geschlecht>> GetGeschlechterAsync()
        {
            return await context.Geschlechter.ToListAsync();
        }
    }
}
