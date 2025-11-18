using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orokles_0916
{
    internal class Macska : Allat
    {
        public sealed override void Beszel() //felülirás megállítása
        {
            this.beszede = "Miau";
        }

        public override string? ToString()
        {
            return $"A macska beszéde: {GetBeszed()}";
        }
    }
}
