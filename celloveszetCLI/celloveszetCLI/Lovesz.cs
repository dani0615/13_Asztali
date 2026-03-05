using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace celloveszetCLI
{
    public class Lovesz
    {
        public string Nev { get; private set; }
        public int ElsoLoves { get; private set; }
        public int MasodikLoves { get; private set; }
        public int HarmadikLoves { get; private set; }
        public int NegyedikLoves { get; private set; }

        public Lovesz(string sor) 
        {
            string[] adatok = sor.Split(';');
            Nev = adatok[0];
            ElsoLoves = int.Parse(adatok[1]);
            MasodikLoves = int.Parse(adatok[2]);
            HarmadikLoves = int.Parse(adatok[3]);
            NegyedikLoves = int.Parse(adatok[4]);
        }
        
        public int Legnagyobb()
        {
            return Math.Max(ElsoLoves, Math.Max(MasodikLoves, Math.Max(HarmadikLoves, NegyedikLoves)));
        }

        public int OsszPontszam()
        {
            return ElsoLoves + MasodikLoves + HarmadikLoves + NegyedikLoves;
        }

    }
}
