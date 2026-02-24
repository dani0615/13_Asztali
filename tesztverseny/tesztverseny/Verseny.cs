using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tesztverseny
{
    internal class Verseny
    {
        public Verseny(string azonosito, string tipp)
        {
            Azonosito = azonosito;
            Tipp = tipp;
        }

        public Verseny(string sor) 
        {
            var adatok = sor.Split(" ");
            Azonosito = adatok[0];
            Tipp = adatok[1];
        }

        public string Azonosito { get; set; }
        public string Tipp { get; set; }

        public override string? ToString()
        {
            return $"{Azonosito} {Tipp}";
        }
    }
}
