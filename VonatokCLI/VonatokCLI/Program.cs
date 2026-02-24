using System.Text.Json;

namespace VonatokCLI
{
    internal class Program
    {
        static List<Varakozas> varakozasok = new List<Varakozas>();
        static List<Varakozas> varakozasokJson = new List<Varakozas>();
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            LoadFromFile();
            //BeolvasasJson();
            Feladat1();
            Feladat2();
            Feladat3();
            Feladat4();
        }

        private static void Feladat4()
        {
            int maxVarakozasiIdo = varakozasok.Max(v => v.VarakozasIdo);
            Console.WriteLine($"A leghosszabb várakozás:{maxVarakozasiIdo} perc");
            Console.Write("Az érintett állomás(ok): ");
            foreach (Varakozas varakozas in varakozasok)
            {
                if (varakozas.VarakozasIdo == maxVarakozasiIdo)
                {
                    Console.Write($"{varakozas.Allomas},");
                }
            }
        }

        private static void BeolvasasJson()
        {
            string fajl = File.ReadAllText("varakozas.json");
            varakozasokJson = JsonSerializer.Deserialize<List<Varakozas>>(fajl);
        }

        private static void Feladat3()
        {
            int varakozasiIdo;
            int varakozasDB=0;
            Console.Write("Hány percnél hosszabb várakozást keressek? ");
            varakozasiIdo = int.Parse(Console.ReadLine());
            
            foreach (Varakozas varakozas in varakozasok)
            {
                if (varakozas.VarakozasIdo > varakozasiIdo)
                {
                    varakozasDB++;
                }
            }
            Console.WriteLine($"{varakozasiIdo}percnél hosszabb várakozások száma: {varakozasDB}");
        }

        private static void Feladat2()
        {
            string allomas;
            Console.WriteLine("Kérem adjon meg egy állomást");
            allomas = Console.ReadLine();
            bool vanE = false;
            foreach (Varakozas vonat in varakozasok)
            {
                if (vonat.Allomas == allomas)
                {
                    Console.WriteLine($"A vonal száma: {vonat.Vonal}");
                    vanE = true;
                    break;
                }
            }
            if (!vanE)
            {
                Console.WriteLine("Hiányzó adat.");
            }
        }

        private static void Feladat1()
        {
            
            string vonalSzama;
            Console.WriteLine("Kérem adjon meg egy vonalszámot:");
            vonalSzama = Console.ReadLine();
            foreach (Varakozas varakozas in varakozasok)
            {
                if (varakozas.Vonal == vonalSzama)
                {
                    Console.WriteLine(varakozas);
                }
            }

        }

        private static void LoadFromFile()
        {
            string[] sorok = File.ReadAllLines("varakozas.txt").Skip(1).ToArray();
            foreach (string sor in sorok) 
            {
                varakozasok.Add(new Varakozas(sor));
            }
        }
    }
}
