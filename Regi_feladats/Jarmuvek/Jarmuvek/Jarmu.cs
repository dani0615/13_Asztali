using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jarmuvek
{
    internal abstract class Jarmu
    {
        protected int aktualisSebesseg;
        private string rendszam;

        public string Rendszam { get; set; }


        public Jarmu(int aktualisSebesseg, string rendszam)
        {
            this.aktualisSebesseg = aktualisSebesseg;
            this.rendszam = rendszam;
        }

        public abstract bool GyorsanhajtottE(int sebessegkorlat);
        

        public override string? ToString()
        {
            return $"{rendszam}- {aktualisSebesseg} km/h";
        }
    }
}
