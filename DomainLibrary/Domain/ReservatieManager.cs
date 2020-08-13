using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLibrary
{
    public class ReservatieManager
    {
        private List<Reservatie> Reservaties;
        public ReservatieManager()
        {
            Reservaties = new List<Reservatie>();

        }
        public void CreateNewReservation(int reservatieID, Klant klant, DateTime datum, Locaties ophaalLocatie, Locaties afzetLocatie, Voertuig gereseveerdeVoortuig, Arrangement arrangement, int aantalUren)
        {
            decimal subtotaal = 0;
            decimal aangerekendeKortingen = 0;
            decimal totaalExclusiefBtw = 0;
            decimal btwBedrag = 0;
            decimal teBetalenBedrag = 0;
            
            //calculate subtotal price
            if( arrangement == Arrangement.NightLife )
            {
                subtotaal = gereseveerdeVoortuig.NightLife;
            }
            else if( arrangement == Arrangement.Wellness ) 
            {
                subtotaal = gereseveerdeVoortuig.Wellness;
            }
            else if( arrangement == Arrangement.Wedding)
            {
                subtotaal = gereseveerdeVoortuig.Wedding;
            }
            else
            {
                subtotaal = gereseveerdeVoortuig.EersteUur;
                subtotaal += Math.Round(((gereseveerdeVoortuig.EersteUur * aantalUren - 1) / 100) * 65);
            }

            //add discount to subtotal and btw
            aangerekendeKortingen = GetDiscount(klant.Type);
            totaalExclusiefBtw = ((subtotaal / 100) * aangerekendeKortingen) - subtotaal;

            btwBedrag = (totaalExclusiefBtw / 100) * 6;

            teBetalenBedrag = totaalExclusiefBtw + btwBedrag;

            Reservatie r = new Reservatie(reservatieID, klant, datum, ophaalLocatie, afzetLocatie, gereseveerdeVoortuig, arrangement, aantalUren, subtotaal, aangerekendeKortingen, totaalExclusiefBtw, btwBedrag, teBetalenBedrag);

            Reservaties.Add(r);
            
        }
        private decimal GetDiscount(KlantType klantType)
        {
            decimal discount = 0;

            //ToDo: Get aantal reservaties dit jaar + add Jaartal in param
            int aantalReservaties = 0;

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
        private int GetLastReservationId()
        {
            return 1;
        }
    }
}
