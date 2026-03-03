using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LakokCLI
{
    public class Lakas
    {
        public string cim { get; set; }
        public int lakokSzama { get; set; }
        public string lakokNeve { get; set; }
        public int terulet { get; set; }
        public int tartozas { get; set; }

        public Lakas(string cim, int lakokSzama, string lakokNeve, int terulet, int tartozas)
        {
            this.cim = cim;
            this.lakokSzama = lakokSzama;
            this.lakokNeve = lakokNeve;
            this.terulet = terulet;
            this.tartozas = tartozas;
        }

        public Lakas(string line)
        {

            string[] adatok = line.Split(',');
            cim = adatok[0] + adatok[1];
            lakokSzama = int.Parse(adatok[2]);
            lakokNeve = adatok[3];
            terulet = int.Parse(adatok[4]);
            tartozas = int.Parse(adatok[5]);
        }
        public bool Tartozik()
        {
            return tartozas != 0;
        }

        public void Kiegyenlit()
        {
            this.tartozas = 0;
        }

        public bool Tulzsufolt()
        {
            double max_lakok_szama = (terulet - 40) / 4;
            return lakokSzama > max_lakok_szama;
        }

       
    }
}
