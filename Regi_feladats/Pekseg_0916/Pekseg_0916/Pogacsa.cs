using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pekseg_0916
{
    internal class Pogacsa : Peksutemeny
    {
        public Pogacsa(double mennyiseg, double alapar) : base(mennyiseg, alapar)
        {

        }
        public override void Megkostol()
        {
            Mennyiseg--;
        }

        public override string? ToString()
        {
            return "Pogacsa" +base.ToString();
        }
    }
}
