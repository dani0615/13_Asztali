namespace hegyekCLI
{
    public class Program
    {
       public static List<hegycsucs> hegycsucsok = new List<hegycsucs>();
        static void Main(string[] args)
        {
            Console.WriteLine("Kérem a keresett szót:");
            string keresett = Console.ReadLine();

            Beolvas();
            Feladat8();
            Feladat11(keresett);
            Console.WriteLine("........");
        }

        private static void Feladat11(string keresett)
        {
            foreach (var hegy in hegycsucsok)
            {
                if (Tartalmaz(keresett, hegy.Nev, hegy.Hegyseg))
                {
                    Console.WriteLine(hegy.Nev);
                }
            }
        }

        private static bool Tartalmaz(string keresett, string hegyCsucs, string hegyseg)
        {
            if (hegyCsucs.Contains(keresett) || hegyseg.Contains(keresett))
            {
                return true;
            }
            return false;

        }

        private static void Feladat8()
        {
            var hegycsucs950m = hegycsucsok.Where(x => x.Magassag > 950).ToList();
            foreach (var item in hegycsucs950m)
            {
                Console.WriteLine(item);
            }
        }

        public static void Beolvas()
        {
            string[] sorok = File.ReadAllLines("hegyek.csv").Skip(1).ToArray();
            foreach (var item in sorok)
            {
                hegycsucsok.Add(new hegycsucs(item));
            }

        }
    }
}
