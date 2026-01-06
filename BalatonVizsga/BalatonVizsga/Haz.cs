using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalatonVizsga
{
    public class Haz
    {
        public Haz(int telekadoszam, string utcaneve, string hazszam, string adoSav, int terulet)
        {
            Telekadoszam = telekadoszam;
            Utcaneve = utcaneve;
            Hazszam = hazszam;
            AdoSav = adoSav;
            Terulet = terulet;
        }

        public int Telekadoszam { get; private set; }
        public string Utcaneve { get; private set; }

        public string Hazszam { get; private set; }

        public string AdoSav { get; private set; }
        public int Terulet { get; private set; }

        
        public void SetAdoSav(string UjAdoSav) 
        {
            AdoSav = UjAdoSav;
        }
    }
}
