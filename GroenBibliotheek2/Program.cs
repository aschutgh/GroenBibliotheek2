using System;
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

            foreach (string boeknummer in tboeken.Keys)
            {
                Console.WriteLine("{0} / {1}; {2}; {3}; {4}, {5}", boeknummer, tboeken[boeknummer].Bnummer, tboeken[boeknummer].Btype, tboeken[boeknummer].Uitleendat, tboeken[boeknummer].Retourdat, tboeken[boeknummer].Boete);
            }

            //var uitleendat = DateTime.Parse("2018/08/01");
            //var retourdat = DateTime.Parse("2018/08/03");

            //var boek = new Boek("9321", uitleendat, retourdat);
            //Console.WriteLine(boek.Bnummer);
            //Console.WriteLine(boek.Btype);
            //Console.WriteLine(boek.Uitleendat);
            //Console.WriteLine(boek.Retourdat);
            //Console.WriteLine(boek.Boete);

        }
    }
}
