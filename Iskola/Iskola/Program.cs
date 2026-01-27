
namespace Iskola
{
    internal class Program
    {
        static List<Tanulo> tanulok = new List<Tanulo>();
        static void Main(string[] args)
        {
            
            LoadFromFile();
            Feladat3();
            Feladat4();
            Feladat6();
        }

        private static void Feladat6()
        {
            
            using (StreamWriter sw = new StreamWriter("azonositok.txt"))
            {
                foreach (var tanulo in tanulok)
                {
                    sw.WriteLine($"{tanulo.DiakNeve};{tanulo.Azonosito()}");
                }
            }
        }

        private static void Feladat4()
        {
            Console.WriteLine($"{tanulok[0].Azonosito}");
        }

        private static void Feladat3()
        {
            Console.WriteLine($"3. Feladat: Tanulók száma: {tanulok.Count} fő");
            foreach (var tanulo in tanulok)
            {
                Console.WriteLine($"");
            }
        }
        private static void LoadFromFile()
        {
                string[]adatok= File.ReadAllLines("nevek.txt");
              foreach (var sor in adatok)
              {
                 tanulok.Add(new Tanulo(sor));
            }

        }
    }
}
