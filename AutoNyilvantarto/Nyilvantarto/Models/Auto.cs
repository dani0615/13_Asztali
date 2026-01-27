using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nyilvantarto.Models
{
    public  class Auto
    {
        public Auto(string marka, string tipus, int gyartasiEv)
        {
            Marka = marka;
            Tipus = tipus;
            GyartasiEv = gyartasiEv;
        }

        public string Marka { get; private set; }
        public string Tipus { get; private set; }
        public int GyartasiEv { get; private set; }

        public Auto()
        {
        }


    }
}
