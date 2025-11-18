using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orokles_0916
{
    internal class Kismacska : Macska
    {
        //nem tudjuk felülírni a Beszel() metódust (sealed)
        public override string? ToString()
        {
            return $"A kismacska beszéde: {GetBeszed()}";
        }
    }
}
