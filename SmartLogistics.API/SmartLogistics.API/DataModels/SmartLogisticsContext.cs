using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Diagnostics;

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
        public DbSet<Lagerverwaltung> Lagerverwaltung{ get; set; }

        //private readonly StreamWriter _logStream = new StreamWriter("mylogs.txt", append: true);

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    options.LogTo(_logStream.WriteLine, LogLevel.Information);
        //}

        //public override void Dispose()
        //{
        //    base.Dispose();
        //    _logStream.Dispose();
        //}

        //public override async ValueTask DisposeAsync()
        //{
        //    await base.DisposeAsync();
        //    await _logStream.DisposeAsync();
        //}
    }
}
