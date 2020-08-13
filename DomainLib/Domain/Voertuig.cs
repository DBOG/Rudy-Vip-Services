using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLibrary
{
    public class Voertuig
    {
        public Voertuig()
        {
                
        }

        public Voertuig(string naam, decimal eersteUur, decimal nightLife, decimal wedding, decimal wellness)
        {
            Naam = naam;
            EersteUur = eersteUur;
            NightLife = nightLife;
            Wedding = wedding;
            Wellness = wellness;
        }

        public int Id { get; set; }
        public string Naam { get; set; }
        public decimal EersteUur { get; set; }
        public decimal NightLife { get; set; }
        public decimal Wedding { get; set; }
        public decimal Wellness { get; set; }
        public override string ToString()
        {
            return Naam;
        }

    }
}
