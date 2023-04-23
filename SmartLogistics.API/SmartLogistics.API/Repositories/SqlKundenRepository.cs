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

        public async Task<bool> Exists(Guid kundenId)
        {
            return await context.Kunden.AnyAsync(x=> x.Id == kundenId);
        }

        public async Task<Kunde> UpdateKunde(Guid kundenId, Kunde request)
        {
            var existingKunde = await GetKundeAsync(kundenId);
            if (existingKunde != null)
            {
                existingKunde.Vorname = request.Vorname;
                existingKunde.Nachname = request.Nachname;
                existingKunde.Geburtsdatum = request.Geburtsdatum;
                existingKunde.Email = request.Email;
                existingKunde.Telefon = request.Telefon;
                existingKunde.GeschlechtId= request.GeschlechtId;
                existingKunde.Adresse.Strasse = request.Adresse.Strasse;
                existingKunde.Adresse.Hausnummer = request.Adresse.Hausnummer;

                await context.SaveChangesAsync();
                return existingKunde;
            }

            return null;
        }

        public async Task<Kunde> DeleteKunde(Guid kundenId)
        {
            var kunde = await GetKundeAsync(kundenId);
            if(kunde != null)
            {
                context.Kunden.Remove(kunde);
                await context.SaveChangesAsync();
            }

            return null;
        }

        public async Task<Kunde> AddKunde(Kunde request)
        {
            var newKunde= await context.Kunden.AddAsync(request);
            context.SaveChangesAsync();
            return newKunde.Entity;
        }
    }
}
