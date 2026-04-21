using ArakCLI;

namespace EvVegiArakCLI
{
    internal class Program
    {
        public static List<Arak> arak = new List<Arak>();
        static void Main(string[] args)
        {
            Beolvas();
            Feladat1();
            Feladat3();
            Feladat5();
            Feladat6();
        }

        private static void Feladat6()
        {
            var olcsobbak = arak.Where(x => x.Valtozas() < 0);
            using (StreamWriter sw = new StreamWriter("Olcsobbak.txt"))
            {
                foreach (var item in olcsobbak)
                {
                    sw.WriteLine($"{item.Kódszám};{item.Megnevezés};{ Math.Abs(item.Valtozas())}");
                }
            }
        }

        private static void Feladat5()
        {

            Arak emelkedes = arak.MaxBy(x => x.Valtozas());
            Console.WriteLine("5. feladat:");
            Console.WriteLine($"A legnagyobb mértékben a {emelkedes.Megnevezés} emelkedett {emelkedes.Valtozas()} Ft-tal. ");
        }

        private static void Feladat3()
        {

            Console.WriteLine("3. feladat:\nKérem adja meg a termék kódját! ");
            string kod = Console.ReadLine();



            Arak? termek = arak.FirstOrDefault(x => x.Kódszám == kod);
            if (termek != null)
            {
                Console.WriteLine($" Termék neve:{termek.Megnevezés}, átlagára 2024-ben {((termek.januar + termek.december) / 2.0):F2} Ft");
            }
            else
            {
                Console.WriteLine("Nincs ilyen termék a listában :(");
            }
        }

        private static void Feladat1()
        {
            Console.WriteLine("1. feladat:");
            Console.WriteLine($"Az állományban {arak.Count} db termék található.");
        }

        private static void Beolvas()
        {

            string[] sor = File.ReadAllLines("arak2024.txt").Skip(1).ToArray();
            foreach (var item in sor)
            {
                arak.Add(new Arak(item));
            }
        }
    }
}
