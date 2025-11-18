




namespace Barlangok13b
{
    internal class Program
    {
       static List<Barlang> barlangs = new List<Barlang>();
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Feladat3();
            Feladat4();
            Feladat5();
            Feladat6();
            Feladat7();
        }

        private static void Feladat7()
        {
            Dictionary<string,int> statisztika = new Dictionary<string, int>();
            foreach(var item in barlangs) 
            {
                if (!statisztika.ContainsKey(item.Vedettseg))
                {
                    statisztika.Add(item.Vedettseg, 1);
                }
                else 
                {
                    statisztika[item.Vedettseg]++;
                }

                Console.WriteLine("7.Feladat : Statisztika");
                foreach(var stat in statisztika)
                {
                    Console.WriteLine($"\t{stat.Key}:".PadRight(31, '-'));
                    Console.WriteLine($">{stat.Value} db");
                }
                

            }
        }

        private static void Feladat6()
        {
            
            Console.WriteLine("Kérek egy védettségi szintet: ");
            string Vedettsegi = Console.ReadLine();
            var Leghosszabb = barlangs.Where(x => x.Vedettseg == Vedettsegi).Max(x => x.Hossz);
            //a kíírásnál kell azon, név, hossz ,mélység, település
            var barlang = barlangs.FirstOrDefault(x => x.Vedettseg == Vedettsegi && x.Hossz == Leghosszabb);
            Console.WriteLine(barlang != null ? barlang.ToString() : "Nincs ilyen védettségi szinttel barlang az adatok között!");


        }

        private static void Feladat5()
        {
            var melyseg = barlangs.Where(x=> x.Telepules.StartsWith("Miskolc")).Average(x=> x.Melyseg);
            Console.WriteLine($"AZ átlagos mélység:{melyseg:F3} m");
        }

        private static void Feladat4()
        {
            Console.WriteLine($"Barlangok száma:{barlangs.Count}");
        }

        public static void Feladat3()
        {
            string [] sorok = File.ReadAllLines("barlangok.txt").Skip(1).ToArray();
            foreach (var sor in sorok)
            {
                barlangs.Add(new Barlang(sor));
            }
        }
    }
}
