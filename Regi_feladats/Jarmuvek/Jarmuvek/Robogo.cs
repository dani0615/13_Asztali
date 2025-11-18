using System;

namespace Jarmuvek
{
    internal class Robogo : Jarmu, IKisGepjarmu
    {
        private int maxsebesseg;

        public Robogo(int aktualisSebesseg, string rendszam, int maxsebesseg)
            : base(aktualisSebesseg, rendszam)
        {
            this.maxsebesseg = maxsebesseg;
        }

        public bool Haladhat(int sebesseg)
        {
            return maxsebesseg <= sebesseg;
        }
        public override bool GyorsanhajtottE(int sebessegkorlat)
        {
            return aktualisSebesseg > sebessegkorlat;
        }

        public override string? ToString()
        {
            return"Robogo:"+base.ToString();
        }
    }
}