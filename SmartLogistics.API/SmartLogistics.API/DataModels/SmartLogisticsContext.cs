using Microsoft.EntityFrameworkCore;

namespace SmartLogistics.API.DataModels
{
    public class SmartLogisticsContext : DbContext
    {
        public SmartLogisticsContext(DbContextOptions<SmartLogisticsContext> options) : base(options)
        {
            
        }

        public DbSet<Kunde> Kunden { get; set; }
        public DbSet<Geschlecht> Geschlechter { get; set; }
        public DbSet<Adresse> Adressen { get; set; }
        public DbSet<Ort> Orte { get; set; }
        public DbSet<Bestellung> Bestellungen { get; set; }
        public DbSet<Lieferung> Lieferungen { get; set; }
        public DbSet<Produkt> Produkte { get; set; }
        public DbSet<Roboter> Roboter { get; set; }
    }
}
