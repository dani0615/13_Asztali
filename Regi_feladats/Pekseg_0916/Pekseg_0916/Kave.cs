using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pekseg_0916
{
    internal class Kave : IArlap
    {
       private bool habosE;
       const int CSESZEKAVE = 180;

        public Kave(bool habosE)
        {
            this.habosE = habosE;
        }

        public double MennyibeKerul()
        {
            if (habosE)
            {
                return CSESZEKAVE*1.5;
            }
            else
            return CSESZEKAVE;
        }

        public override string? ToString()
        { 
            return (habosE ? "Habos" : "Nem habos") + " kávé - " + MennyibeKerul() + " Ft";
        }

        static void Vasarlok() 
        {
            Console.WriteLine("Add meg fajl elérési útját.");
            string fajl = Console.ReadLine();
            Console.WriteLine("Add meg a fajl nevét.");
            string nev = Console.ReadLine();
            string[] sorok = File.ReadAllLines(fajl + nev);
        }
    }
}
