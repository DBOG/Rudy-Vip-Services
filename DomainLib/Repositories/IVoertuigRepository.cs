using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLibrary.Repositories
{
    public interface IVoertuigRepository
    {
        void AddVoertuig(Voertuig v);
        IEnumerable<Voertuig> ZoekVoertuig(string naam);
        Voertuig ZoekVoertuig(int id);
        IEnumerable<Voertuig> GetAllVoertuigen();
    }
}