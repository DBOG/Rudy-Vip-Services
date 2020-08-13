using System;

namespace DomainLibrary
{
    public class Klant
    {
        public Klant()
        {
        }

        public Klant(int klantNummer, KlantType type, string naam, string voorNaam, string btwNummer, string gemeente, string postCode, string straat, string huisNummer, string busNr, int aantalReservatiesDitJaar)
        {
            KlantID = klantNummer;
            Type = type;
            Naam = naam;
            VoorNaam = voorNaam;
            BtwNummer = btwNummer;
            Gemeente = gemeente;
            PostCode = postCode;
            Straat = straat;
            HuisNummer = huisNummer;
            BusNr = busNr;
            AantalReservatiesDitJaar = aantalReservatiesDitJaar;
        }

        public int KlantID { get; set; }
        public KlantType Type { get; set; }
        public string Naam { get; set; }

        public string VoorNaam { get; set; }
        public string BtwNummer { get; set; }

        public string Gemeente { get; set; }
        public string PostCode { get; set; }
        public string Straat { get; set; }
        public string HuisNummer { get; set; }
        public string BusNr { get; set; }


        public int AantalReservatiesDitJaar { get; set; }
    }
}
