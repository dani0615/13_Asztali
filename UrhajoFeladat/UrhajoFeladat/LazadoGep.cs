using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrhajoFeladat
{
    internal abstract class LazadoGep : IUrhajo
    {
        private double sebesseg;
        private bool meghibasodhatE;

        protected LazadoGep(double sebesseg, bool meghibasodhatE)
        {
            this.Sebesseg = sebesseg;
            this.MeghibasodhatE = meghibasodhatE;
        }

        public double Sebesseg { get => sebesseg; set => sebesseg = value; }
        public bool MeghibasodhatE { get => meghibasodhatE; set => meghibasodhatE = value; }

        public abstract bool ElkapjaAVonosugar();

        public bool LegyorsuljaE(IUrhajo Urhajo)
        {
            if (Urhajo is LazadoGep masikLazado)
            {
                if (masikLazado.MeghibasodhatE && this.MilyenGyors() > masikLazado.MilyenGyors())
                {
                    return true;
                }
            }
            else if (Urhajo is MilleniumFalcon)
            {
                if (this.MilyenGyors() > 2 * Urhajo.MilyenGyors())
                {
                    return true;
                }
            }
            return false;
        }

        public double MilyenGyors()
        {
            return Sebesseg;
        }

        public override string? ToString()
        {
            string meghibasodas = MeghibasodhatE ? "meghibásodhat" : "nem hibásodik meg";
            return $"A lázadógép sebessége: {MilyenGyors()}, {meghibasodas}.";


        }
    }

}
