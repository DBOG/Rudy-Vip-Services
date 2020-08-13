using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using DomainLibrary;

namespace DataLayer
{
    public class ReservatieContext : DbContext
    {
        public DbSet<Voertuig> Vloot { get; set; }
        public DbSet<Klant> Klanten { get; set; }
        public DbSet<Reservatie> reservaties { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=desktop-lcumeg0;Initial Catalog=RudyVip;Integrated Security=True");
        }
    }
}
