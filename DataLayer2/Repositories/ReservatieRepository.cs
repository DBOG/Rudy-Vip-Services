using System;
using System.Collections.Generic;
using System.Text;
using DomainLibrary;
using DomainLibrary.Repositories;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repositories
{
    class ReservatieRepository : IReservatieRepository
    {
        private ReservatieContext context;

        public ReservatieRepository(ReservatieContext context)
        {
            this.context = context;
        }
        public void AddReservatie(Reservatie reservatie)
        {
            context.reservaties.Add(reservatie);
        }
        public IEnumerable<Reservatie> Find(DateTime start, DateTime end)
        {
            return context.reservaties.Where(s=>s.Datum<=end&&s.Datum>= start).OrderBy(s => s.Datum).AsEnumerable<Reservatie>();
        }
        public IEnumerable<Reservatie> FindAll()
        {
            return context.reservaties.OrderBy(s => s.Datum).AsEnumerable<Reservatie>();
        }
        public IEnumerable<Reservatie> FindLatestReservations(int number)
        {
            return context.reservaties.OrderBy(s => s.Datum).Take(number).AsEnumerable<Reservatie>();

        }
        public IEnumerable<Reservatie> ZoekReservatieForCarAvailablity(DateTime datum)
        {
            return context.reservaties.Where(s => s.Datum.DayOfYear.Equals(datum.DayOfYear) && s.Datum.DayOfYear - 1 == datum.DayOfYear - 1);
        }
        public IEnumerable<Reservatie> ZoekReservatie(string klantNaam)
        {
            return context.reservaties.Where(s => s.klant.Naam.Contains(klantNaam)).Include(s => s.klant).Include(v => v.GereserveerdeVoertuig);
        }
        public IEnumerable<Reservatie> ZoekReservatie(DateTime datum)
        {
            return context.reservaties.Where(s => s.Datum.DayOfYear.Equals(datum.DayOfYear)).Include(s => s.klant).Include(v => v.GereserveerdeVoertuig);
        }
        public IEnumerable<Reservatie> ZoekReservatie(string klantNaam, DateTime datum)
        {
            return context.reservaties.Where(s => s.Datum.DayOfYear.Equals(datum.DayOfYear) && s.klant.Naam.Contains(klantNaam)).Include(s => s.klant).Include(v => v.GereserveerdeVoertuig);
        }
        public int ZoekReservatiesVanJaartal(string klantNaam, DateTime datum)
        {
            return context.reservaties.Where(s => s.klant.Naam.Equals(klantNaam) && s.Datum.Year.Equals(datum.Year)).Count();
        }
        public int LastReservatieId()
        {
            return context.reservaties.Count();
        }
        public void CancelReservations(List<Reservatie> reservaties)
        {
            foreach (Reservatie r in reservaties)
                context.reservaties.Remove(r);

        }
    }
}
