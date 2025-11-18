using System;
using System.Collections.Generic;
using System.Linq;

namespace ElektronikaiEszközök
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Telefon telefon1 = new Telefon();
            Telefon telefon2 = new Telefon();
            Zseblámpa zseblampa1 = new Zseblámpa();
            Zseblámpa zseblampa2 = new Zseblámpa();

            
            List<IKapcsolhato> eszkozok = new List<IKapcsolhato>
            {
                telefon1,
                telefon2,
                zseblampa1,
                zseblampa2
            };

           
            telefon1.Bekapcsol(); 
            telefon2.Toltes(-50); 
            telefon2.Bekapcsol();
            zseblampa1.Bekapcsol(); 
            zseblampa2.Kikapcsol(); 

            // 1. Eszközök állapotának kiírása
            Console.WriteLine("\n1. Eszközök állapotának kiírása:");
            EszkozokAllapotKiirasa(eszkozok);

            // 2. Bekapcsolt eszközök számlálása
            Console.WriteLine("\n2. Bekapcsolt eszközök számlálása:");
            int bekapcsoltakSzama = BekapcsoltEszkozokSzamlalasa(eszkozok);
            Console.WriteLine($"Bekapcsolt eszközök száma: {bekapcsoltakSzama}");

            // 3. Eszközök kikapcsolása
            Console.WriteLine("\n3. Eszközök kikapcsolása:");
            EszkozokKikapcsolasa(eszkozok);
            EszkozokAllapotKiirasa(eszkozok); 

            // 4. Zseblámpák keresése és állapotuk kiírása
            Console.WriteLine("\n4. Zseblámpák keresése:");
            List<Zseblámpa> zseblampak = GetZseblampak(eszkozok);
            ZseblampakAllapotKiirasa(zseblampak);

            Console.ReadLine(); 
        }

        // 1. Metódus: Eszközök állapotának kiírása
        static void EszkozokAllapotKiirasa(List<IKapcsolhato> eszkozok)
        {
            foreach (var eszkoz in eszkozok)
            {
                string tipus = eszkoz is Telefon ? "Telefon" : "Zseblámpa";
                string allapot = eszkoz.Bekapcsolva ? "bekapcsolva" : "kikapcsolva";
                Console.WriteLine($"{tipus} állapota: {allapot}.");
            }
        }

        // 2. Metódus: Bekapcsolt eszközök számlálása
        static int BekapcsoltEszkozokSzamlalasa(List<IKapcsolhato> eszkozok)
        {
            int szam = 0;
            foreach (var eszkoz in eszkozok)
            {
                if (eszkoz.Bekapcsolva)
                {
                    szam++;
                }
            }
            return szam;
        }

        // 3. Metódus: Eszközök kikapcsolása
        static void EszkozokKikapcsolasa(List<IKapcsolhato> eszkozok)
        {
            foreach (var eszkoz in eszkozok)
            {
                if (eszkoz.Bekapcsolva)
                {
                    eszkoz.Kikapcsol();
                }
            }
        }

        // 4. Metódus: Zseblámpák keresése
        static List<Zseblámpa> GetZseblampak(List<IKapcsolhato> eszkozok)
        {
            return eszkozok.OfType<Zseblámpa>().ToList();
        }

        
        static void ZseblampakAllapotKiirasa(List<Zseblámpa> zseblampak)
        {
            foreach (var zseblampa in zseblampak)
            {
                string allapot = zseblampa.Bekapcsolva ? "bekapcsolva" : "kikapcsolva";
                Console.WriteLine($"Zseblámpa állapota: {allapot}.");
            }
        }
    }
}