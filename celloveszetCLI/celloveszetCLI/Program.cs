namespace celloveszetCLI
{
    internal class Program
    {
        public static List<Lovesz> loveszek = new List<Lovesz>();
        static void Main(string[] args)
        {
            LoadFromFile();
            Feladat9();
            Feladat10();
            Feladat11();
        }
        
        private static void Feladat11()
        {
            int minAtlag = loveszek.Min(x => x.OsszPontszam() / 4);
            var leggyengebbLovesz = loveszek.First(x => x.OsszPontszam() / 4 == minAtlag);
            Console.WriteLine("A leggyengebbatlagu találot lövő eredményei:");
            Console.WriteLine($"{leggyengebbLovesz.Nev} {minAtlag}");

        }

        private static void Feladat10()
        {
            int maxPontszam = loveszek.Max(x => x.OsszPontszam());
            var legjobbLovesz = loveszek.First(x => x.OsszPontszam() == maxPontszam);
           
                Console.WriteLine("A legnagyobb találatot lövő eredményei:");
                //Max pontszam alapjan megkeressuk a legjobb lövészt
                foreach (var item in loveszek)
                {
                    if (item.OsszPontszam() == maxPontszam)
                    {
                        Console.WriteLine($"{item.Nev} {item.ElsoLoves} {item.MasodikLoves} {item.HarmadikLoves} {item.NegyedikLoves}");
                    }
                }
            }
        

        
        private static void Feladat9()
        {
            foreach (var item in loveszek)
            {
                Console.WriteLine($"{item.Nev} {item.Legnagyobb()}");
            }

        }

        private static void LoadFromFile()
        {
            string[] sorok = File.ReadAllLines("lovesek.csv");
            foreach (var item in sorok)
            {
                loveszek.Add(new Lovesz(item));
            }
        }
    }
}
