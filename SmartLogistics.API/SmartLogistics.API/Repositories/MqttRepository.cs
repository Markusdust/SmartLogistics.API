using Azure.Core;
using Microsoft.EntityFrameworkCore;
using SmartLogistics.API.DataModels;

namespace SmartLogistics.API.Repositories
{
    public class MqttRepository : IMqttRepository
    {
        private readonly SmartLogisticsContext context;

        public MqttRepository(SmartLogisticsContext context)
        {
            this.context = context;
        }

        public string RoboterId { get; set; }
        public string Batteriestatus { get; set; }
        public string AuftragsId { get; set; }
        public string Auftragsstatus { get; set; }
        public string Positionsstatus { get; set; }
        public string Angemeldet { get; set; }
        public string Komplettstring { get; set; }

        //public async Task<List<Bestellung>> GetBestellungenAsync()
        //{
        //    return await context.Bestellungen.Include(nameof(Kunde)).Include(nameof(Produkt)).ToListAsync();
        //}

        public async Task<Bestellung> GetBestellungAsync(Guid bestellungId)
        {
            return await context.Bestellungen
               .Include(nameof(Kunde)).Include(nameof(Produkt))
               .FirstOrDefaultAsync(x => x.Id == bestellungId);
        }

        public async Task<Bestellung> ChangeLieferstatusTest(Guid bestellungId, string bestellstatus)
        {

            var request = await GetBestellungAsync(bestellungId);

            request.Status = bestellstatus;

            var existingBestellung = await GetBestellungAsync(bestellungId);
            if (existingBestellung != null)
            {
                existingBestellung.ProduktId = request.ProduktId;
                existingBestellung.Erfassdatum = request.Erfassdatum;
                existingBestellung.Lieferart = request.Lieferart;
                existingBestellung.LieferungEnde = request.LieferungEnde;
                existingBestellung.KundeId = request.KundeId;
                existingBestellung.Prioritaet = request.Prioritaet;
                existingBestellung.Status = request.Status;


                await context.SaveChangesAsync();
                return existingBestellung;
            }

            return null;
        }
    }
}
