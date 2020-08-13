using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLibrary
{
    public class Reservatie
    {
        public Reservatie()
        {

        }

        public Reservatie(int reservatieId, Klant klant, DateTime datum, Locaties ophaalLocatie, Locaties afzetLocatie, Voertuig gereserveerdeVoertuig, Arrangement arrangement, int aantalUren, decimal subtotaal, decimal aangerekendeKortingen, decimal totaalExclusiefBtw, decimal btwBedrag, decimal teBetalenBedrag)
        {
            ReservatieId = reservatieId;
            Klant = klant;
            Datum = datum;
            OphaalLocatie = ophaalLocatie;
            AfzetLocatie = afzetLocatie;
            GereserveerdeVoertuig = gereserveerdeVoertuig;
            Arrangement = arrangement;
            AantalUren = aantalUren;
            Subtotaal = subtotaal;
            AangerekendeKortingen = aangerekendeKortingen;
            TotaalExclusiefBtw = totaalExclusiefBtw;
            BtwBedrag = btwBedrag;
            TeBetalenBedrag = teBetalenBedrag;
        }

        public int ReservatieId { get; set; }
        public Klant Klant { get; set; }
        public DateTime Datum { get; set; }
        public Locaties OphaalLocatie { get; set; }
        public Locaties AfzetLocatie { get; set; }
        public Voertuig GereserveerdeVoertuig { get; set; }
        public Arrangement Arrangement { get; set; }//
        public int AantalUren { get; set; }
        public decimal Subtotaal { get; set; }
        public decimal AangerekendeKortingen { get; set; }
        public decimal TotaalExclusiefBtw { get; set; }
        public decimal BtwBedrag { get; set; }
        public decimal TeBetalenBedrag { get; set; }

    }
}
