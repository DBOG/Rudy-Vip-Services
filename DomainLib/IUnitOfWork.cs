using System;
using System.Collections.Generic;
using System.Text;
using DomainLibrary.Repositories;

namespace DomainLibrary
{
    public interface IUnitOfWork : IDisposable
    {
        IKlantRepository Klanten { get; }
        IVoertuigRepository Voertuigen { get; }
        IReservatieRepository Reservaties { get; }
        int Complete();
    }
}
