


namespace BalatonVizsga
{
    public class Program
    {
       public static List<Haz> hazak = new List<Haz>();
       public static int[] AdoKategoriak = new int[3];
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            
            Feladat2();
            Feladat3();
            Feladat5();
            Feladat6();
        }

        private static void Feladat6()
        {
            StreamWriter sw = new StreamWriter("teljes.txt");
            foreach (Haz i in hazak)
            {
                sw.WriteLine($"{i.Telekadoszam} {i.Utcaneve} {i.Hazszam} {i.AdoSav} {i.Terulet} {Ado(i.AdoSav, i.Terulet)}");
            }
            sw.Close();
        }

        private static void Feladat5()
        {
            List<int> ATelkek = new();
            List<int> BTelkek = new();
            List<int> CTelkek = new();

            foreach (Haz haz in hazak) 
            {
                switch (haz.AdoSav) 
                {
                    case "A":
                        ATelkek.Add(Ado(haz.AdoSav, haz.Terulet));
                        break;
                    case "B":
                        BTelkek.Add(Ado(haz.AdoSav, haz.Terulet));
                        break;
                    case "C":
                        CTelkek.Add(Ado(haz.AdoSav, haz.Terulet));
                        break;
                }
            }

        }



        public static int Ado(string adosav, int terulet)
        {
            Beolvasas();
            int ado = 0;
            if (adosav == "A") 
            {
                ado= AdoKategoriak[0] * terulet;
            }
            else if (adosav == "B")
            {
                ado =AdoKategoriak[1] * terulet;
            }
            else
            {
                ado= AdoKategoriak[2] * terulet;
            }
           
            if (ado < 10000)
            {
                return 0;
            }
            return ado;
        }

        

        private static void Feladat3()
        {
            Console.WriteLine("3.feladat . Egy tulajdonos adószáma: ");
            int adoszam = int.Parse(Console.ReadLine());
            bool van = false;
            foreach (var haz in hazak)
            {
                if (haz.Telekadoszam == adoszam)
                {
                    Console.WriteLine($"{haz.Utcaneve} {haz.Hazszam}");
                    van = true;

                }
            }
            if (!van)
            {
                Console.WriteLine("Nem szerepel az adatállományban.");
            }

        }

        

        private static void Feladat2()
        {
            Console.WriteLine($"2.feladat. A mintában {hazak.Count} telek szerepel.");
        }

        private static void Beolvasas()
        {
            string[] sorok = File.ReadAllLines("utca.txt");
            string[] arakSzoveg = sorok[0].Split(' ');
            AdoKategoriak[0] = int.Parse(arakSzoveg[0]);
            AdoKategoriak[1] = int.Parse(arakSzoveg[1]);
            AdoKategoriak[2] = int.Parse(arakSzoveg[2]);


            for (int i = 1; i < sorok.Length; i++)
            {
                string[] adat = sorok[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);


                if (adat.Length >= 5)
                {
                    hazak.Add(new Haz(
                        int.Parse(adat[0]),
                        adat[1],
                        adat[2],
                        adat[3],
                        int.Parse(adat[4])
                    ));
                }
            }
        }
    } 
}
