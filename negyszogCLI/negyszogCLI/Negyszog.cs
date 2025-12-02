using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negyszogCLI
{
    public class Negyszog
    {


        public int Aoldal { get; private set; }
        public int Boldal { get; private set; }
        public int Coldal { get; private set; }

        public int Doldal { get; private set; }

        public Negyszog(string sor)
        {
            string[] adatok = sor.Split(' ');
            Aoldal = int.Parse(adatok[0]);
            Boldal = int.Parse(adatok[1]);
            Coldal = int.Parse(adatok[2]);
            Doldal = int.Parse(adatok[3]);
        }


        //a leghosszabb oldal kevesebb mint a masik 3 oldal osszege
        public bool LeghosszabbOldal()
        {
            List<int> oldalak = new List<int> { Aoldal, Boldal, Coldal, Doldal };
            int leghosszabb = oldalak.Max();
            int osszeg = oldalak.Sum() - leghosszabb;
            return leghosszabb < osszeg;


        }

        public override string ToString()
        {
            return $"A: {Aoldal}, B: {Boldal}, C: {Coldal}, D: {Doldal}";
        }



    }
}
