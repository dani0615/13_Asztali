
using System.Data.SqlTypes;

namespace negyszogCLI
{
    public class Program
    {
       public static List<Negyszog> negyszogek = new List<Negyszog>();
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Beolvas();
            NegyszogAdatok();
            LeghosszabbOldal();




        }

        private static void NegyszogAdatok()
        {
            Console.WriteLine("Négyszögek:");
            foreach (var negyszog in negyszogek)
            {
                Console.WriteLine(negyszog);
            }
        }

        private static void LeghosszabbOldal()
        {
            Console.WriteLine("Szerkeszthető:");
            foreach (var negyszog in negyszogek)
            {
                if (negyszog.LeghosszabbOldal())
                {
                    Console.WriteLine(negyszog);

                }


            }



        }

        private static void Beolvas()
        {
            try
            {
                string fajlNev = "negyszogek.csv";
                string[] sorok = File.ReadAllLines(fajlNev);
                foreach (var sor in sorok)
                {
                    negyszogek.Add(new Negyszog(sor));
                }
                Console.WriteLine("Sikeres beolvasás");

            }
            catch (Exception ex)
            {

                Console.WriteLine($"Hiba történt: {ex.Message}");
            }
        }

        public static bool ParalelogrammaE(Negyszog n)
        {
            if (n.Aoldal == n.Coldal && n.Boldal == n.Doldal)
            {
                return true;
            }
            return false;
        }

        public static bool RombuszE(Negyszog n)
        {
            if (n.Aoldal == n.Boldal && n.Aoldal == n.Coldal && n.Coldal == n.Doldal && n.Boldal == n.Coldal)
            {
                return true;
            }
            return false;
        }
    }
}
