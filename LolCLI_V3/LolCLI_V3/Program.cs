namespace LolCLI_V3
{
    public class Program
    {
        public static List<Hos> Hosok = new List<Hos>();
        static void Main(string[] args)
        {
            Beolvas();
            Feladat2();
            Feladat3();
            Feladat5();
        }

        private static void Feladat5()
        {
            Hos legmagasabb = Hosok.MaxBy(x => x.ArmorLevel(10));
            Console.WriteLine($"5.Feladat: 10.szinten a legnagyobb páncél értékkel rendelkező hős: {legmagasabb.Name}; Páncél={legmagasabb.ArmorLevel(10)}");

        }

        private static void Feladat3()
        {
            Hos keresett = null;
            do
            {
                Console.Write("3.Feladat: Kérem adja meg a hős nevét:");
                string nev = Console.ReadLine();
                keresett = Hosok.FirstOrDefault(x => x.Name == nev);
                Console.WriteLine($"\t{keresett.Name} adatai: Mozgási sebesség{keresett.MoveSpeed}; Páncél: {keresett.Armor}; Kategória: {keresett.Category}");

            }
            while (keresett == null);
        }

        public static void Beolvas()
        {
            string[] sorok = File.ReadAllLines("champions2017_V3.txt").Skip(1).ToArray();
            foreach (var item in sorok)
            {
                Hosok.Add(new Hos(item));
            }

        }

        private static void Feladat2()
        {
            Console.WriteLine($"2.Feladat: Az állományban {Hosok.Count} hős található");
        }
    }
}
