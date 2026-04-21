using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ArakCLI
{
   public class Arak
    {
        public string Kódszám { get; set; }
        public string Megnevezés { get; set; }

        public int januar { get; set; }

        public int december { get; set; }

        public Arak(string sor) 
        {
            string[] adatok = sor.Split('\t');
            Kódszám = adatok[0];
            Megnevezés = adatok[1].Split(",")[0];
            januar = int.Parse(adatok[2]);
            december = int.Parse(adatok[3]);
        }

        public Arak(string kódszám, string megnevezés, int januar, int december)
        {
            Kódszám = kódszám;
            Megnevezés = megnevezés;
            this.januar = januar;
            this.december = december;
        }

        
       public int Valtozas()
        {
            return december-januar;
        }
    }
}
