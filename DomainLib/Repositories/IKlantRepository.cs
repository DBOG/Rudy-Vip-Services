using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLibrary.Repositories
{
    public interface IKlantRepository
    {
        void AddKlant(Klant klant);
        Klant ZoekKlant(int id);
        IEnumerable<Klant> ZoekKlant(string naam);

    }
}
