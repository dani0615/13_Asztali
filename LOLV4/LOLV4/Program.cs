using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace LOLV4
{
    public class Program
    {
        public static List<Hos> hosok = new List<Hos>();
        static void Main(string[] args)
        {
            Feladat1();
            Feladat2();
            Feladat3();
            Feladat5();

        }

        private static void Feladat5()
        {
           var lvl5LegkisebbSebzes = hosok.MinBy(x => x.ADLevel(5));
            Console.WriteLine($"5.Feladat: 5.szinten a legkisebb sebzéssel rendelkező hős {lvl5LegkisebbSebzes.Name}; sebzés={lvl5LegkisebbSebzes.ADLevel(5)}");
        }

        private static void Feladat3()
        {
            Hos keresettHos = null;
            do
            {
                Console.Write("3.Feladat: Kérem adja meg a hős nevét:");
                string keresettNev = Console.ReadLine();
                keresettHos = hosok.FirstOrDefault(x => x.Name.ToLower() == keresettNev.ToLower());
            }
            while (keresettHos == null);
            Console.WriteLine($"\t{keresettHos.Name} adatai HP:{keresettHos.HP}; Sebzés:{keresettHos.AttackDamage}");


        }

        private static void Feladat2()
        {
            Console.WriteLine($"2. Feladat: Az állományban {hosok.Count} hős található");
        }

        public static void Feladat1()
        {
            string file = "champions2017_V4.txt";
            string[] lines = File.ReadAllLines(file).Skip(1).ToArray();
            foreach (var item in lines)
            {
                hosok.Add(new Hos(item));

            }
        }

       
        
    }

   
}
