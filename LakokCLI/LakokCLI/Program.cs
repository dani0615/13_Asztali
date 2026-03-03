using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LakokCLI
{
    public class Program
    {
        public static List<Lakas> lakasok = new List<Lakas>();
        static void Main(string[] args)
        {
            loadFromFile();
            Feladat6();
            Feladat7();
            Feladat8();
        }

        private static void Feladat8()
        {
            Console.WriteLine("\n8. Feladat: Tartozó lakások listázása:");
            foreach (var lakas in lakasok.Where(l => l.Tartozik()))
            {
                Console.WriteLine($"\t{lakas.cim}, {lakas.lakokNeve} - {lakas.tartozas} Ft");
            }
        }

        private static void Feladat7()
        {
            double atlagTartozasLakas = lakasok.Average(l => l.tartozas);
            Console.WriteLine($"\n7. Feladat: Átlagos tartozás lakásonként: {atlagTartozasLakas:F0}Ft");

            double osszTartozas = lakasok.Sum(l => l.tartozas);
            int osszLakok = lakasok.Sum(l => l.lakokSzama);
            double atlagTartozasSzemely = (double)osszTartozas / osszLakok;
            Console.WriteLine($"Átlagos tartozás személyenként: {atlagTartozasSzemely:F0}Ft");
        }

        private static void Feladat6()
        {
            Console.WriteLine("6. Feladat: Túlzsúfolt lakások listázása:");
            foreach (var lakas in lakasok.Where(l => l.Tulzsufolt()))
            {
                Console.WriteLine($"\t{lakas.cim}, {lakas.lakokSzama} fő ");
            }
        }

        public static void loadFromFile()
        {
            string[] sorok = File.ReadAllLines("lakok.csv").Skip(1).ToArray();
            foreach (var s in sorok)
            {
                lakasok.Add(new Lakas(s));
            }
        }
    }
}
