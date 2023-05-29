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
            return await context.Bestellungen.Include(nameof(Kunde)).Include(nameof(Produkt)).ToListAsync();
        }

        public async Task<Bestellung> GetBestellungAsync(Guid bestellungId)
        {
            return await context.Bestellungen
               .Include(nameof(Kunde)).Include(nameof(Produkt))
               .FirstOrDefaultAsync(x => x.Id == bestellungId);
        }
        public async Task<bool> Exists(Guid bestellungId)
        {
            return await context.Bestellungen.AnyAsync(x => x.Id == bestellungId);
        }

        public async Task<Bestellung> UpdateBestellung(Guid bestellungId, Bestellung request)
        {
            var existingBestellung = await GetBestellungAsync(bestellungId);
            if (existingBestellung != null)
            {
                existingBestellung.ProduktId = request.ProduktId;
                existingBestellung.Erfassdatum = request.Erfassdatum;
                existingBestellung.Lieferart = request.Lieferart;
                existingBestellung.LieferungEnde = request.LieferungEnde;
                existingBestellung.KundeId = request.KundeId;
                existingBestellung.Priorität = request.Priorität;
                existingBestellung.Lieferart = request.Lieferart;
                existingBestellung.Status  = request.Status;


                await context.SaveChangesAsync();
                return existingBestellung;
            }

            return null;
        }

        public async Task<Bestellung> DeleteBestellung(Guid bestellungId)
        {
            var bestellung = await GetBestellungAsync(bestellungId);
            if (bestellung != null)
            {
                context.Bestellungen.Remove(bestellung);
                await context.SaveChangesAsync();
            }

            return null;
        }

        public async Task<Bestellung> AddBestellung(Bestellung request)
        {
            var newBestellung = await context.Bestellungen.AddAsync(request);
            await context.SaveChangesAsync();
            return newBestellung.Entity;
        }
    }
}

