using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pekseg_0916
{
    internal abstract class Peksutemeny : IArlap
    {
        protected double Mennyiseg;
        private double Alapar;

        public Peksutemeny(double mennyiseg, double alapar)
        {
            Mennyiseg = mennyiseg;
            Alapar = alapar;
        }

        public abstract void Megkostol();
        

        public double MennyibeKerul()
        {
            return Mennyiseg * Alapar;
        }

        public override string? ToString()
        {
            return $"{Mennyiseg} db - {MennyibeKerul()} Ft";
        }
    }
}
