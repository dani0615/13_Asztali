using System.ComponentModel;

namespace tesztverseny
{
    public class Program
    {
        static List<Verseny> versenyek = new List<Verseny>();
        static string helyesvalasz;
        static void Main(string[] args)
        {
            Beolvas();
            Feladat2();
            f_telitalalat(helyesvalasz);
            telitalalat();
            f_szazalek(helyesvalasz);
            MentesFileba();
        }

        private static void MentesFileba()
        {
            
            StreamWriter sw = new StreamWriter("telitalalat.txt");
            foreach (var item in versenyek)
            {
                sw.WriteLine($"{item.Azonosito} {f_szazalek(item.Tipp)}%");
            }
            sw.Close();





        }

        private static int f_szazalek(string valaszok) 
        { 
            int darab = 0;
            for (int i = 0; i < valaszok.Length; i++)
            {
                if (valaszok[i] == helyesvalasz[i])
                {
                    darab++;
                }
            }
            return Convert.ToInt32((double)darab / valaszok.Length*100);

        }

        private static void telitalalat()
        {
            for (int i = 0; i < versenyek.Count; i++)
            {
                if (f_telitalalat(versenyek[i].Tipp) == true)
                  {
                    Console.WriteLine(versenyek[i].Azonosito);
                  }
            }
        }
           
        

        private static bool f_telitalalat(string valaszok)
        {
            return valaszok == helyesvalasz;
        }

        private static void Feladat2()
        {
            foreach (var item in versenyek)
            {
                Console.WriteLine(item);
            }
        }

        private static void Beolvas()
        {
            string[] adat = File.ReadAllLines("valaszok.txt");
            helyesvalasz = adat[0];
            for (int i = 1; i < adat.Length; i++) 
            {
                versenyek.Add(new Verseny(adat[i]));
            }
        }
    }
}
