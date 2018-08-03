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
        static void Main(string[] args)
        {
            var uitleendat = DateTime.Parse("2018/08/01");
            var retourdat = DateTime.Parse("2018/08/03");

            var boek = new Boek("9321", uitleendat, retourdat);
            Console.WriteLine(boek.Bnummer);
            Console.WriteLine(boek.Btype);
            Console.WriteLine(boek.Uitleendat);
            Console.WriteLine(boek.Retourdat);
            Console.WriteLine(boek.Boete);

            uitleendat = DateTime.Parse("2018/07/01");
            retourdat = DateTime.Parse("2018/07/29");

            boek = new Boek("3321", uitleendat, retourdat);
            Console.WriteLine(boek.Bnummer);
            Console.WriteLine(boek.Btype);
            Console.WriteLine(boek.Uitleendat);
            Console.WriteLine(boek.Retourdat);
            Console.WriteLine(boek.Boete);
        }
    }
}
