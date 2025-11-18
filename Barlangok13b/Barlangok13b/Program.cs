



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
        }

        private static void Feladat6()
        {
            /*
             * Kérjen be egy védettségi szintet és tárolja el egy szöveges típusú változóban! Határozza
meg és írja a képernyőre a megadott védettségi szinthez tartozó leghosszabb barlang adatait!
Feltételezheti, hogy egyik védettségi szint esetében sem alakult ki a barlangok hosszánál
holtverseny. Ha a megadott védettégi szinttel nem található barlang az adatok között, akkor
a „Nincs ilyen védettségi szinttel barlang az adatok között!” felirat jelenjen meg!
             * 
             */
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

        private static void Feladat3()
        {
            string [] sorok = File.ReadAllLines("barlangok.txt").Skip(1).ToArray();
            foreach (var sor in sorok)
            {
                barlangs.Add(new Barlang(sor));
            }
        }
    }
}
