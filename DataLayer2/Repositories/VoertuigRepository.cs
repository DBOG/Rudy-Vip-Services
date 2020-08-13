using System;
using System.Collections.Generic;
using System.Text;
using DomainLibrary;
using DomainLibrary.Repositories;
using System.Linq;

namespace DataLayer.Repositories
{
    class VoertuigRepository : IVoertuigRepository
    {
        ReservatieContext context;
        public VoertuigRepository(ReservatieContext context)
        {
            this.context = context;
        }
        public void AddVoertuig(Voertuig v)
        {
            context.Add(v);
        }
        public IEnumerable<Voertuig> ZoekVoertuig(string naam)
        {
            return context.Vloot.Where(s => s.Naam.Equals(naam));
        }
        public Voertuig ZoekVoertuig(int id)
        {
            return context.Vloot.Find(id);
        }
        public IEnumerable<Voertuig> GetAllVoertuigen()
        {
            return context.Vloot.AsEnumerable<Voertuig>();
        }
    }
}
