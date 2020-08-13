using System;
using DomainLibrary;
using System.IO;
using System.Collections.Generic;
using DataLayer;

namespace ConsoleAppPresentationLayer
{
    class Program
    {
        static void Main(string[] args)
        {
            ReservatieManager rm = new ReservatieManager(new UnitOfWork(new ReservatieContext()));
            Dictionary<int, string[]> klanten = new Dictionary<int, string[]>();
            Dictionary<int, string[]> autos = new Dictionary<int, string[]>();
            string line;
            string[] arr;
            using (StreamReader sr = new StreamReader(@"D:\Hogent\Programmeren\Prog Project\Vip Services Rudy 2020\klantenlijst.txt"))
            {
                while((line = sr.ReadLine()) != null)
                {
                    if (!line.StartsWith("k"))
                    {
                        arr = line.Split(",");
                        klanten.Add(int.Parse(arr[0]), arr);
                    }
                }
            }

            //vehicles
            using (StreamReader sr = new StreamReader(@"D:\Hogent\Programmeren\Prog Project\Vip Services Rudy 2020\vehicles.txt"))
            {
                int counter = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    arr = line.Split(";");
                    autos.Add(counter++, arr);
                }
            }

            foreach(KeyValuePair<int, string[]> car in autos)
            {
                string naam = car.Value[0];
                decimal eersteUur = decimal.Parse(car.Value[1]);
                decimal nightlife = decimal.Parse(car.Value[2]);
                decimal wedding = decimal.Parse(car.Value[3]);
                decimal wellness = decimal.Parse(car.Value[4]);

                Voertuig v = new Voertuig( naam, eersteUur, nightlife, wedding, wellness);
                rm.AddVoertuig(v);
            }
            //int c = 0;
            //foreach(KeyValuePair<int, string[]> klant in klanten)
            //{
            //    Console.WriteLine(c++);
            //    string klantnaam = klant.Value[1];
            //    string categorie = klant.Value[2];
            //    string btwnmr = klant.Value[3];
            //    string adres = klant.Value[4];

            //    KlantType type;
            //    if (categorie == "particulier") type = KlantType.Particulier;
            //    else if (categorie == "vip") type = KlantType.Vip;
            //    else type = KlantType.Planner;

            //    Klant k = new Klant(type, klantnaam, btwnmr, adres);
            //    rm.AddKlant(k);
            //}
        }
    }
}
