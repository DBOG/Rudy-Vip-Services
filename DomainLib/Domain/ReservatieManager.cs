using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLibrary
{
    public class ReservatieManager
    {
        private IUnitOfWork uow;
        public ReservatieManager(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public void CreateNewReservation(Reservatie r)
        {
            uow.Reservaties.AddReservatie(r);
            uow.Complete();
        }
        public Reservatie CalculatePriceForPreview(Klant klant, DateTime datum, Locaties ophaalLocatie, Locaties afzetLocatie, Voertuig gereseveerdeVoortuig, Arrangement arrangement, int aantalUren)
        {
            decimal subtotaal = 0;
            decimal aangerekendeKortingen = 0;
            decimal totaalExclusiefBtw = 0;
            decimal btwBedrag = 0;
            decimal teBetalenBedrag = 0;

            //calculate subtotal price
            if (arrangement == Arrangement.NightLife)
            {
                subtotaal = gereseveerdeVoortuig.NightLife;
            }
            else if (arrangement == Arrangement.Wellness)
            {
                subtotaal = gereseveerdeVoortuig.Wellness;
            }
            else if (arrangement == Arrangement.Wedding)
            {
                subtotaal = gereseveerdeVoortuig.Wedding;
            }
            else
            {
                subtotaal = gereseveerdeVoortuig.EersteUur;
                subtotaal += Math.Round(((gereseveerdeVoortuig.EersteUur * aantalUren - 1) / 100) * 65);
            }

            //add discount to subtotal and btw
            aangerekendeKortingen = GetDiscount(klant.Type, klant.Naam, datum);
            totaalExclusiefBtw = subtotaal - ((subtotaal / 100) * aangerekendeKortingen);

            btwBedrag = (totaalExclusiefBtw / 100) * 6;

            teBetalenBedrag = totaalExclusiefBtw + btwBedrag;

            Reservatie r = new Reservatie(klant, datum, ophaalLocatie, afzetLocatie, gereseveerdeVoortuig, arrangement, aantalUren, subtotaal, aangerekendeKortingen, totaalExclusiefBtw, btwBedrag, teBetalenBedrag);

            return r;


        }
        public void AddKlant(Klant klant)
        {
            uow.Klanten.AddKlant(klant);
            uow.Complete();
        }
        public void AddVoertuig(Voertuig voertuig)
        {
            uow.Voertuigen.AddVoertuig(voertuig);
            uow.Complete();
        }
        public Voertuig ZoekVoertuigById(int id)
        {
            return uow.Voertuigen.ZoekVoertuig(id);
        }
        public void CancelReservation(List<Reservatie> reservaties)
        {
            uow.Reservaties.CancelReservations(reservaties);
            uow.Complete();
        }
        private decimal GetDiscount(KlantType klantType, string klantNaam, DateTime year)
        {
            decimal discount = 0;

            int aantalReservaties = uow.Reservaties.ZoekReservatiesVanJaartal(klantNaam, year);

            if(klantType == KlantType.Vip)
            {
                if(aantalReservaties >= 2)
                    discount = 5;
                if(aantalReservaties >= 7)
                    discount = 7.5M;
                if (aantalReservaties >= 15)
                    discount = 10;
            }
            else if(klantType == KlantType.Planner)
            {
                if (aantalReservaties >= 5)
                    discount = 7.5M;
                if (aantalReservaties >= 10)
                    discount = 10;
                if (aantalReservaties >= 15)
                    discount = 12.50M;
                if (aantalReservaties >= 20)
                    discount = 15;
                if (aantalReservaties >= 25)
                    discount = 25;
            }
            //else discount = 0

            return discount;
        }
        public Klant getKlantByID(int id)
        {
            return uow.Klanten.ZoekKlant(id);
        }
        public List<Klant> getKlantenByName(string name)
        {
            List<Klant> klanten = new List<Klant>();
            foreach(var v in uow.Klanten.ZoekKlant(name))
            {
                klanten.Add(v);
            }
            return klanten;
        }
        public List<Voertuig> getVoertuigen()
        {
            List<Voertuig> voertuig = new List<Voertuig>();
            foreach (var v in uow.Voertuigen.GetAllVoertuigen())
            {
                voertuig.Add(v);
            }
            return voertuig;
        }
        public List<Voertuig> getVoertuigenUnAvailableOnDate(DateTime date)
        {
            List<Voertuig> voertuigen = new List<Voertuig>();
            foreach(var v in uow.Reservaties.ZoekReservatieForCarAvailablity(date))
            {
                if(v.AutoBinnenGebracht.Hour + 6 > date.Hour)
                    voertuigen.Add(v.GereserveerdeVoertuig);
            }
            return voertuigen;
        }
        public List<Reservatie> GetReservatiesByKlantNaam(string naam)
        {
            List<Reservatie> reservaties = new List<Reservatie>();
            foreach (var v in uow.Reservaties.ZoekReservatie(naam))
                reservaties.Add(v);
            return reservaties;
        }
        public List<Reservatie> GetReservatiesByKlantAndDatum(string naam, DateTime date)
        {
            List<Reservatie> reservaties = new List<Reservatie>();
            foreach (var v in uow.Reservaties.ZoekReservatie(naam, date))
                reservaties.Add(v);
            return reservaties;
        }
        public List<Reservatie> GetReservatiesByDatum(DateTime date)
        {
            List<Reservatie> reservaties = new List<Reservatie>();
            foreach (var v in uow.Reservaties.ZoekReservatie(date))
                reservaties.Add(v);
            return reservaties;
        }
    }
}
