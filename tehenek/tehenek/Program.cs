


namespace tehenek
{
    internal class Program
    {
        static List<Tehen> happycows = new List<Tehen>();
        static void Main(string[] args)
        {
            //beolvasás fájlbó
            Feladat2();
            Feladat3();
            Feladat6();
            Feladat7();
        }

        private static void Feladat7()
        {
            Console.WriteLine("7. Feladat");
            Console.WriteLine("Kérek egy azonosítót:");
            string azon = Console.ReadLine();

            foreach (var tehen in happycows)
            {
                if (tehen.Id.StartsWith(azon))   
                {
                    Console.WriteLine($"Tehen ID: {tehen.Id}, Heti Atlag: {tehen.hetiAtlag()}");
                }                
                
            }
        }

        private static void Feladat6()
        {
            int db = 0;
            StreamWriter sw = new StreamWriter("joltejelok.txt");
            foreach (var tehen in happycows)
            {
                if (tehen.hetiAtlag() != -1)
                {
                    sw.WriteLine($"{tehen.Id};{tehen.hetiAtlag()}");
                    db++;
                }
            }
            sw.Close();
            Console.WriteLine($"Feladat 6\n{db} sor írtam az állományba.");
        }

        private static void Feladat2()
        {
            string[] sorok = File.ReadAllLines("hozam.txt");
            foreach (var sor in sorok)
            {
                string id = sor.Split(";")[0];
                string nap = sor.Split(";")[1];
                string mennyiseg = sor.Split(";")[2];

                Tehen aktTehen = new Tehen(id);

                if (!happycows.Contains(aktTehen))
                {
                    happycows.Add(aktTehen);
                }
                int index = happycows.IndexOf(aktTehen);
                happycows[index].EredmenytRogzit(nap, mennyiseg);
            }
        }

        private static void Feladat3()
        {
            Console.WriteLine($"Feladat 3\nAz állomány {happycows.Count} adatait tartalmazza.");
        }
    }
}
