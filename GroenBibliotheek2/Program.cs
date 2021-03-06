﻿using System;
using System.Collections.Generic;


namespace GroenBibliotheek2
{
    public class Boek
    {
        public Boek(string bnummer, DateTime uitleendat, DateTime retourdat)
        {
            Bnummer = bnummer;
            Uitleendat = uitleendat;
            Retourdat = retourdat;
            Boete = 0.0;
            Btype = bnummer.Substring(0, 1) == "9" ? "roman" : "studieboek";

        }

        public string Bnummer { get; set; }
        public string Btype { get; set; }
        public DateTime Uitleendat { get; set; }
        public DateTime Retourdat { get; set; }
        public Double Boete { get; set; }

        public override string ToString()
        {
            return Bnummer + " " + Btype + " " + Uitleendat + " " + Retourdat + " " + Boete;
        }
    }

    class Program
    {

        static string vraagUitleendatum()
        {
            Console.Write("Geef uitleendatum in formaat jjjj/mm/dd: ");
            return Console.ReadLine();
        }

        static string vraagBoeknummer()
        {
            Console.Write("Geef boeknummer van vier cijfers: ");
            return Console.ReadLine();
        }

        static string vraagRetourdatum()
        {
            Console.Write("Geef retourdatum in formaat jjjj/mm/dd: ");
            return Console.ReadLine();
        }

        static void vraagBoekinfo(ref Dictionary<string, Boek> tboeken)
        {
            string boeknummer = vraagBoeknummer();
            DateTime uitleendat = DateTime.Parse(vraagUitleendatum());
            DateTime retourdat = DateTime.Parse(vraagRetourdatum());
            var nieuwboek = new Boek(boeknummer, uitleendat, retourdat);
            tboeken.Add(boeknummer, nieuwboek);

        }

        static void berekenBoetePerBoek(ref Dictionary<string, Boek> tboeken)
        {
            foreach(string boeknum in tboeken.Keys)
            {
                switch (tboeken[boeknum].Btype)
                {
                    case "roman":
                        TimeSpan ad = tboeken[boeknum].Retourdat - tboeken[boeknum].Uitleendat;
                        if (ad.Days > 21)
                        {
                            tboeken[boeknum].Boete = (ad.Days - 21) * 0.25;
                        }
                        break;
                    case "studieboek":
                        ad = tboeken[boeknum].Retourdat - tboeken[boeknum].Uitleendat;
                        if (ad.Days > 30)
                        {
                            tboeken[boeknum].Boete = ((ad.Days - 30) / 7) * 1; // expliciet uitrekenen
                            if ((ad.Days - 30) % 7 > 0)
                            {
                                tboeken[boeknum].Boete += 1; // voor een deel v.d. week krijg je ook een euro boete
                            }
                        }
                        break;
                }
            }

        }

        static double berekenTotaleBoete(ref Dictionary<string, Boek> tboeken)
        {
            double tboete = 0.0;

            foreach(string boeknum in tboeken.Keys)
            {
                tboete += tboeken[boeknum].Boete;
            }

            return tboete;
        }

        static void Main(string[] args)
        {
            var tboeken = new Dictionary<string, Boek>();
            Console.WriteLine("Welkom bij de bibliotheek!");
            var meerboeken = true;
            while (meerboeken == true)
            {
                vraagBoekinfo(ref tboeken);
                Console.Write("Wil je meer boeken invoeren? (ja of nee) ");
                if (Console.ReadLine() == "nee")
                {
                    meerboeken = false;
                }
            }

            berekenBoetePerBoek(ref tboeken);

            foreach (string boeknummer in tboeken.Keys)
            {
                Console.WriteLine("{0} / {1}", boeknummer, tboeken[boeknummer]);
            }

            Console.WriteLine("U moet een totale boete betalen ter hoogte van: {0}", berekenTotaleBoete(ref tboeken));

        }
    }
}
