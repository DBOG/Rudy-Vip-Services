using System;
using System.Collections.Generic;
using System.Text;
using DomainLibrary;
using DomainLibrary.Repositories;
using DataLayer.Repositories;

namespace DataLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private ReservatieContext context;
        public UnitOfWork(ReservatieContext context)
        {
            this.context = context;
            Voertuigen = new VoertuigRepository(context);
            Klanten = new KlantenRepository(context);
            Reservaties = new ReservatieRepository(context);

        }
        public IVoertuigRepository Voertuigen { get; set; }
        public IKlantRepository Klanten { get; set; }
        public IReservatieRepository Reservaties { get; set; }

        public int Complete()
        {
            try
            {
                return context.SaveChanges();
            }
            catch(Exception)
            {
                throw;
            }
        }
        public void Dispose()
        {
            context.Dispose();
        }
    }
}
