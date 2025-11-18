using System;

namespace Jarmuvek
{
    internal class AudiS8 : Jarmu
    {
        private bool lezerblokkolo;

        public AudiS8(int aktualisSebesseg, string rendszam, bool lezerblokkolo)
            : base(aktualisSebesseg, rendszam)
        {
            this.lezerblokkolo = lezerblokkolo;
        }

        public override bool GyorsanhajtottE(int sebessegkorlat)
        {
            if (lezerblokkolo)
            {
                return false;
            }
            return aktualisSebesseg > sebessegkorlat;
        }

        public override string? ToString()
        {
            return "Audi:" + base.ToString() + (lezerblokkolo ? " Van blokkolo" : " Nincs blokkolo");
        }
    }
}