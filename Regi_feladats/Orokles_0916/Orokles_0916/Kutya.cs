using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orokles_0916
{
    internal class Kutya : Allat
    {

        public new void Beszel() //Metódus elrejtés
        {
            this.beszede = "Vau-vau";
        }


        public override string? ToString()
        {
            return $"A kutya beszéde: {GetBeszed()}";
        }
    }
}



