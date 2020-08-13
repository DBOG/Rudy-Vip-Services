using System;
using System.Collections.Generic;
using System.Text;
using DomainLibrary;
using DomainLibrary.Repositories;
using System.Linq;
namespace DataLayer.Repositories
{
    class KlantenRepository : IKlantRepository
    {
        private ReservatieContext context;
        public KlantenRepository(ReservatieContext context)
        {
            this.context = context;
        }
        public void AddKlant(Klant klant)
        {
            context.Add(klant);
        }
        public Klant ZoekKlant(int id)
        {
            return context.Klanten.Find(id);
        }
        public IEnumerable<Klant> ZoekKlant(string naam)
        {
            return context.Klanten.Where(s => s.Naam.Contains(naam));
        }
    }
}
