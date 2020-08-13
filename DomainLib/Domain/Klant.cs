using System;

namespace DomainLibrary
{
    public class Klant
    {
        public Klant(){}
        public Klant(KlantType type, string naam, string btwNummer,string adres)
        {
            Type = type;
            Naam = naam;
            BtwNummer = btwNummer;
            Adres = adres;
        }
        public int KlantID { get; set; }
        public KlantType Type { get; set; }
        public string Naam { get; set; }
        public string BtwNummer { get; set; }
        public string Adres { get; set; }
        public override string ToString()
        {
            return Naam;
        }
    }
}
