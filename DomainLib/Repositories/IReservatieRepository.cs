using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLibrary.Repositories
{
    public interface IReservatieRepository
    {
        void AddReservatie(Reservatie reservatie);
        IEnumerable<Reservatie> Find(DateTime start, DateTime end);
        IEnumerable<Reservatie> FindAll();
        IEnumerable<Reservatie> FindLatestReservations(int number);
        IEnumerable<Reservatie> ZoekReservatie(string klantNaam);
        IEnumerable<Reservatie> ZoekReservatieForCarAvailablity(DateTime datum);
        IEnumerable<Reservatie> ZoekReservatie(DateTime datum);
        IEnumerable<Reservatie> ZoekReservatie(string klantNaam, DateTime datum);
        int ZoekReservatiesVanJaartal(string klantNaam, DateTime datum);
        int LastReservatieId();
        void CancelReservations(List<Reservatie> reservaties);
    }
}
