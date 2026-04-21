using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NASACLI
{
    public class Program
    {
       public static List<Kuldetes> kuldetesek = new List<Kuldetes>();

        static void Main(string[] args)
        {
            Beolvas();
            Feladat3();
            Feladat4();
            Feladat5();
            Feladat6();
        }

        public static void Beolvas()
        {
            if (File.Exists("NASAmissions.txt"))
            {
                string[] sorok = File.ReadAllLines("NASAmissions.txt").Skip(1).ToArray();
                foreach (var sor in sorok)
                {
                    kuldetesek.Add(new Kuldetes(sor));   
                }
            }
        }

        private static void Feladat3()
        {
            Console.WriteLine($"3. feladat: {kuldetesek.Count} küldetés található az állományban.");
        }

        private static void Feladat4()
        {
            string keresett;
            Kuldetes talalat;
            do
            {
                talalat = null;
                Console.Write("4. feladat: Adja meg egy küldetés nevének egy részletét: ");
                keresett = Console.ReadLine().ToLower();
                talalat = kuldetesek.LastOrDefault(k=> k.Nev.ToLower().Contains(keresett));
                
                //foreach (var k in kuldetesek)
                //{
                //    if (k.Nev.ToLower().Contains(keresett))
                //    {
                //        talalat = k;
                //    }
                //}

            } while (talalat == null);

            Console.WriteLine($"Talált küldetés: {talalat.Nev}, {talalat.Ev}, {talalat.Celpont}, {(talalat.Sikeres ? "Sikeres" : "Sikertelen")}");
            
        }

        private static void Feladat5()
        {
            Console.WriteLine("\n5. feladat: Küldetések kockázati szintjei:");
            var magasKockazat = kuldetesek.Where(k => k.KockazatiSzint() == "Magas");
            foreach (var k in magasKockazat)
            {
                Console.WriteLine($"{k.Nev}: {k.KockazatiSzint()}");
            }
        }

        private static void Feladat6()
        {
                Kuldetes legkisebb = kuldetesek[0];
                foreach (var k in kuldetesek)
                {
                    if (k.HasznosTeher < legkisebb.HasznosTeher)
                    {
                        legkisebb = k;
                    }
                }
                Console.WriteLine($"\n6. feladat: A legkisebb hasznos teher: {legkisebb.HasznosTeher} kg ({legkisebb.Nev})");
            }
        }
    }

