using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using DomainLibrary;

namespace DataLayer
{
    public class ReservatieContext : DbContext
    {
        DbSet<Voertuig> Vloot { get; set; }
        DbSet<Klant> Klanten { get; set; }
        DbSet<Reservatie> reservaties { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=desktop-lcumeg0;Initial Catalog=RudyVip;Integrated Security=True");
        }
    }
}
